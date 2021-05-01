using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZoomAutoRecorder.Utils;

namespace ZoomAutoRecorder
{
    public partial class Main : Form
    {
        public static List<Lesson> Lessons;
        public readonly static List<string> Days = new List<string>() {
            "Paz",
            "Pzt",
            "Sali",
            "Cars",
            "Pers",
            "Cuma",
            "Cumt"
        };

        public static Database.General Manager;
        public static ZoomEntities ZoomEntities;
        public static BGWorker BGWorker;
        public static ConfigManagement Cfg;
        
        string day = "";
        ListBox lbToday => Controls.Find($"lb{day}", true)[0] as ListBox;
        ListBox Selected;
       
        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            Lessons = new List<Lesson>();
            Manager = new Database.General();
            ZoomEntities = new ZoomEntities();
            BGWorker = new BGWorker(ref backgroundWorker1);
            Cfg = new ConfigManagement();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Manager.RefLessons();
            RefProgram();
            RefBG();
            Manager.Update.CheckUpdate();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(btnReset, "Yenile");
            tip.SetToolTip(btnProgramSettings, "Program Ayarları");
            tip.SetToolTip(barDownload, "Yeni sürüm indiriliyor...");
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //notify.BalloonTipClosed += (s, f) => { var thisIcon = (NotifyIcon)s; thisIcon.Visible = false; thisIcon.Dispose(); };
            notify.Visible = false;
            notify.Icon = null;
            notify.Dispose();
            try
            {
                if (CefSharp.Cef.IsInitialized) CefSharp.Cef.Shutdown();
            }
            catch (Exception)
            {

            }
            Application.Exit();
        }
        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                btnAppHS.Text = "Programı Göster";
                this.Hide();
            }
        }

        public static void ShowError(string message, string title = "HATA")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowInfo(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowAsk(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
        public void ShowBalloon(string title, string message, int timeout = 2000)
        {
            notify.BalloonTipTitle = title;
            notify.BalloonTipText = message;
            notify.ShowBalloonTip(timeout);
        }
        public static bool CheckBetweenDates(DateTime date)
        {
            DateTime date1 = new DateTime(1, 1, 1, date.Hour, date.Minute, 0);
            DateTime date2 = date1.AddMinutes(30);
            date = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, 0);

            return date >= date1 && date < date2;
        }

        public void RefProgram()
        {
            string[] spl = Properties.Settings.Default.LessonTime.Split('|');
            ListBox nully = new ListBox();
            for (int i = 0; i < spl.Count(); i++)
                nully.Items.Add("Boş");

            lbPzt.Items.Clear();
            lbPzt.Items.AddRange(nully.Items);
            lbSali.Items.Clear();
            lbSali.Items.AddRange(nully.Items);
            lbCars.Items.Clear();
            lbCars.Items.AddRange(nully.Items);
            lbPers.Items.Clear();
            lbPers.Items.AddRange(nully.Items);
            lbCuma.Items.Clear();
            lbCuma.Items.AddRange(nully.Items);
            lbCumt.Items.Clear();
            lbCumt.Items.AddRange(nully.Items);
            lbPaz.Items.Clear();
            lbPaz.Items.AddRange(nully.Items);

            Manager.RefreshProgram();
        }
        public void RefBG()
        {
            if (Properties.Settings.Default.AutoStart)
            {
                btnAutoZoom.Text = "Otomatik Toplantıyı Durdur";
                BGWorker.isCancel = false;
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                btnAutoZoom.Text = "Otomatik Toplantıyı Başlat";
                BGWorker.isCancel = true;
            }
        }
        
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift) //YEDEKLE
            {
                Cfg.BackupConfig();
                ShowInfo("Yedekleme başarılı.", "BAŞARILI");
            }
            else if (Control.ModifierKeys == Keys.Control) //YEDEKTEN GERİ YÜKLE
            {
                openFileDialog1.InitialDirectory = System.IO.Path.Combine(Application.StartupPath, "Backups");
                var dialog = openFileDialog1.ShowDialog();
                if (dialog != DialogResult.OK) return;

                string path = openFileDialog1.FileName;
                Cfg.RestoreConfig(path);
                RefProgram();
                ShowInfo("Geri yükleme başarılı.", "BAŞARILI");
            }
            else
                MainClass.OpenForm(new Settings());
        }
        private void btnLessons_Click(object sender, EventArgs e)
        {
            MainClass.OpenForm(new Lessons());
        }
        private void btnProgramSettings_Click(object sender, EventArgs e)
        {
            MainClass.OpenForm(new SetProgram());
        }
        private void btnAppClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbDersler_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbDersler.SelectedItems.Count > 0 && ModifierKeys == Keys.None)
            {
                DoDragDrop(lbDersler.SelectedItem, DragDropEffects.Move);
                lbDersler.SelectedIndex = -1;
            }
        }
        private async void lbDersler_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && lbDersler.SelectedItems.Count > 0)
            {
                Lesson lesson = Lessons.FirstOrDefault(x => x.Name == lbDersler.SelectedItem.ToString());
                await ZoomEntities.StartLesson(false, false, lesson);
                lbDersler.SelectedIndex = -1;
            }
        }
        
        private void btnAppHS_Click(object sender, EventArgs e)
        {
            if (btnAppHS.Text == "Programı Gizle")
            {
                this.Hide();
                btnAppHS.Text = "Programı Göster";
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                btnAppHS.Text = "Programı Gizle";
            }
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Adı: Zoom Otomatik Kaydedici");
            builder.AppendLine("Sürüm: " + MainClass.version);
            builder.AppendLine("Firma: Corelium Development INC");
            builder.AppendLine("Geliştirici: F.M. Yılmaz");
            builder.AppendLine("Tüm Hakları Saklıdır @ 2021");

            ShowInfo(builder.ToString(), "Z.O.K. Hakkında");
        }
        private void btnAutoZoom_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoStart = !Properties.Settings.Default.AutoStart;
            RefBG();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Manager.RefLessons();
            RefProgram();
            BGWorker.isEBA = false;
            BGWorker.isStarted = false;
            RefBG();
            btnAppHS.Text = "Programı Gizle";
            if (Control.ModifierKeys == Keys.Control)
                for (int i = 0; i < Days.Count; i++)
                    (Controls.Find($"lb{Days[i]}", true)[0] as ListBox).SelectedIndex = -1;
            else if (Control.ModifierKeys == Keys.Shift && !string.IsNullOrEmpty(Properties.Settings.Default.LessonTime)) //Ders önceden açıldı mı?
            {
                string[] times = Properties.Settings.Default.LessonTime.Split('|');
                bool y = false;
                foreach (string time in times)
                {
                    DateTime dtime = new DateTime(1, 1, 1, DateTime.Parse(time).Hour, DateTime.Parse(time).Minute, 0);
                    DateTime now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                    if (now >= dtime && now < dtime.AddMinutes(30)) y = true;
                }
                if (!y || !backgroundWorker1.IsBusy) return;
                BGWorker.isStarted = true;
            }
            
            
        }
        private void btnEBA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(day)) return;
            int lid = Lessons.FirstOrDefault(x => x.Name == lbToday.SelectedItem.ToString()).ID;
            bool eba;
            if (btnEBA.Text == "EBA Aç")
            {
                btnEBA.Text = "EBA Kapat";
                eba = true;
            }
            else
            {
                btnEBA.Text = "EBA Aç";
                eba = false;
            }
            Manager.EBASwitch(lid, Days.IndexOf(day), eba, lbToday.SelectedIndex);
            lbToday.SelectedIndex = -1;
        }
        private void btnOnce_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(day)) return;
            var sndr = sender as ToolStripMenuItem;
            if (MainClass.OnceDontOpen.Contains(lbToday.SelectedIndex))
            {
                MainClass.OnceDontOpen.Remove(lbToday.SelectedIndex);
                sndr.Text = "Bir Kereliğine Açma";
            }
            else
            {
                MainClass.OnceDontOpen.Add(lbToday.SelectedIndex);
                sndr.Text = "Her Zaman Aç";
            }
            lbToday.SelectedIndex = -1;
        }
        private void notify_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                btnAppHS.Text = "Programı Gizle";
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                btnAppHS.Text = "Programı Göster";
            }
        }
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            string[] tcknpass = Properties.Settings.Default.TCKNPASS.Split('#');
            if (tcknpass.Count() == 2)
            {
                new Browser(Encryption.Decrypt(tcknpass[0]), Encryption.Decrypt(tcknpass[1]), true).Show();
                this.WindowState = FormWindowState.Minimized;
            }
            else
                ShowError("EBA giriş bilgileri ayarlanmadı!");
        }
        private void btnProgDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(day)) return;
            OnKeyDown(lbToday, new KeyEventArgs(Keys.Delete));
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (e.KeyData == Keys.Escape)
                lb.SelectedIndex = -1;
            else if (e.KeyData == Keys.Delete && lb.SelectedItems.Count > 0)
            {
                int day = Days.IndexOf(lb.Name.Replace("lb", ""));
                Manager.DeleteLessonFromProgram(lb.SelectedIndex, day);
                lb.Items[lb.SelectedIndex] = "Boş";
                lb.SelectedIndex = -1;
            }
        }
        private void OnClick(object sender, MouseEventArgs e)
        {
            Selected = sender as ListBox;
        }
        private void OnClickLB(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListBox lb = sender as ListBox;
                if (lb.SelectedIndex >= 0)
                {
                    day = lb.Name.Replace("lb", "");
                    if (lb.SelectedItem.ToString() != "Boş")
                    {
                        Lesson lesson = Lessons.FirstOrDefault(x => x.Name == lb.SelectedItem.ToString());
                        
                        lb.ContextMenuStrip.Items[0].Visible = true;
                        bool check = Manager.GetEBAState(lesson.ID, Days.IndexOf(day), lb.SelectedIndex);
                        if (check) lb.ContextMenuStrip.Items[0].Text = "EBA Kapat";
                        else lb.ContextMenuStrip.Items[0].Text = "EBA Aç";

                        lb.ContextMenuStrip.Items[1].Visible = true;

                        if ((int)DateTime.Now.DayOfWeek == Days.IndexOf(day))
                        {
                            lb.ContextMenuStrip.Items[2].Visible = true;
                            if (MainClass.OnceDontOpen.Contains(lb.SelectedIndex))
                                lb.ContextMenuStrip.Items[2].Text = "Her Zaman Aç";
                            else
                                lb.ContextMenuStrip.Items[2].Text = "Bir Kereliğine Açma";
                        }
                        else lb.ContextMenuStrip.Items[2].Visible = false;

                        lb.ContextMenuStrip.Items[3].Visible = true;

                        lb.ContextMenuStrip.Items[4].Visible = true;
                        string[] times = Properties.Settings.Default.LessonTime.Split('|');
                        if (BGWorker.isStarted && ZoomEntities.StartedLessonID == lesson.ID)
                            lb.ContextMenuStrip.Items[4].Text = "Durdur";
                        else
                            lb.ContextMenuStrip.Items[4].Text = "Başlat";
                        return;
                    }
                }

                lb.ContextMenuStrip.Items[0].Visible = false;
                lb.ContextMenuStrip.Items[1].Visible = false;
                lb.ContextMenuStrip.Items[2].Visible = false;
                lb.ContextMenuStrip.Items[3].Visible = false;
                lb.ContextMenuStrip.Items[4].Visible = false;
                lb.SelectedIndex = -1;
            }
        }
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedIndex >= 0)
            {
                string name = e.Data.GetData("System.String").ToString();
                Lesson lesson = Lessons.FirstOrDefault(x => x.Name == name);
                int day = Days.IndexOf(lb.Name.Replace("lb", ""));
                Manager.AddLessonToProgram(lesson, lb.SelectedIndex, day);
                lb.Items[lb.SelectedIndex] = name;
                lb.SelectedIndex = -1;
            }
        }
        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private async void OnDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedItems.Count <= 0 || lb.SelectedItem.ToString() == "Boş") return;

            Lesson lesson = Lessons.FirstOrDefault(x => x.Name == lb.SelectedItem.ToString());
            int index = lbDersler.Items.IndexOf(lb.SelectedItem.ToString());
            bool check = Manager.GetEBAState(lesson.ID, Days.IndexOf(lb.Name.Replace("lb", "")), lb.SelectedIndex);

            if (check)
            {
                string[] times = Properties.Settings.Default.LessonTime.Split('|');
                if (!CheckBetweenDates(DateTime.Parse(times[lb.SelectedIndex])))
                {
                    lb.SelectedIndex = -1;
                    return;
                }
            }
            
            if (backgroundWorker1.IsBusy)
            {
                BGWorker.isStarted = true;
                if (check)
                {
                    BGWorker.isEBA = check;
                    BGWorker.ix = lb.SelectedIndex;
                }
            }
            lb.SelectedIndex = -1;
            await ZoomEntities.StartLesson(Properties.Settings.Default.RecordLesson, check, lesson);
        }

        private void btnLessonInfo_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            if (Selected.SelectedItem.ToString() != "Boş")
            {
                Lesson lesson = Lessons.FirstOrDefault(x => x.Name == Selected.SelectedItem.ToString());
                builder.AppendLine("Toplantı Adı: " + lesson.Name);
                builder.AppendLine("Öğretmen: " + lesson.Teacher);
            }
            builder.AppendLine("Başlama Saati: " + DateTime.Parse(Properties.Settings.Default.LessonTime.Split('|')[Selected.SelectedIndex]).ToString("HH.mm"));
            ShowInfo(builder.ToString(), "TOPLANTI HAKKINDA");
            Selected.SelectedIndex = -1;
        }
        private void btnStartProgramLesson_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if (item.Text == "Başlat")
            {
                OnDoubleClick(Selected, null);
                item.Text = "Durdur";
            }
            else
            {
                if (backgroundWorker1.IsBusy)
                {
                    BGWorker.ix = -1;
                    BGWorker.isStarted = false;
                    BGWorker.isEBA = false;
                }
                ZoomEntities.StopLesson(true);
                item.Text = "Başlat";
            }
            Selected.SelectedIndex = -1;
        }

        private void btnAdditional_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoStart)
                MainClass.OpenForm(new AdditionalProgram());
            else
                ShowError("Bu özelliğin kullanılabilmesi için otomatik toplantı özelliğinin aktif olması gerekmektedir.");
        }
    }
}
