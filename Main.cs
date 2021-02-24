using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomAutoRecorder
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        OleDbConnection bg = new OleDbConnection(MainClass.conn);
        bool isStarted, isEBA, isCancel = false;
        int delay = 50000;
        int ix = -1;
        string day = "";

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Icon = null;
            notifyIcon1.Dispose();
            Application.Exit();
        }
        List<int> Lesson_IDs = new List<int>();
        List<string> Days = new List<string>() {
            "Paz",
            "Pzt",
            "Sali",
            "Cars",
            "Pers",
            "Cuma",
            "Cumt"
        };
        public void RefLessons()
        {
            Lesson_IDs.Clear();
            lbDersler.Items.Clear();
            bg.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Lessons", bg);
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                Lesson_IDs.Add(Convert.ToInt32(read["ID"]));
                lbDersler.Items.Add(read["Lesson_Name"].ToString());
            }
            bg.Close();
        }
        public void RefProgram()
        {
            string[] spl = Properties.Settings.Default.LessonTime.Split('|');
            ListBox nully = new ListBox();
            for (int i = 0; i < spl.Count(); i++)
            {
                nully.Items.Add("Boş");
            }

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

            //DATABASE
            bg.Open();
            List<int> delIDs = new List<int>();
            OleDbCommand cmd = new OleDbCommand("Select *From LessonProgram", bg);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int lesson_id = Convert.ToInt32(reader["Lesson_ID"]);
                int day = Convert.ToInt32(reader["Day"]);
                int order = Convert.ToInt32(reader["Order"]);

                string lesson_name = lbDersler.Items[Lesson_IDs.IndexOf(lesson_id)].ToString();

                ListBox lb = this.Controls.Find("lb" + Days[day], true)[0] as ListBox;
                if (lb.Items.Count - 1 < order)
                {
                    delIDs.Add(Convert.ToInt32(reader["ID"]));
                }
                else
                {
                    lb.Items[order] = lesson_name;
                }
            }
            try
            {
                delIDs.ForEach(x => new OleDbCommand("DELETE FROM LessonProgram where [ID]=" + x + "", bg).ExecuteNonQuery());
            }
            catch (OleDbException)
            {
                MessageBox.Show("Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bg.Close();

        }
        public Task<bool> StartLesson(bool withOBS, bool ebaMode, int id)
        {
            return Task.Run(() =>
            {
                try
                {
                    StopLesson(true);
                    Thread.Sleep(Convert.ToInt32(Properties.Settings.Default.DZA * 1000)); //Ders Zaman Aşımı 
                    if (ebaMode)
                    {
                        string[] tpass = Properties.Settings.Default.TCKNPASS.Split('#');
                        if (tpass.Length != 2) return false;
                        new Browser(Encryption.Decrypt(tpass[0]), Encryption.Decrypt(tpass[1]), false).ShowDialog();
                    }
                    else
                    {
                        string lesson_id = GetInfo("Select Lesson_Zoom_ID From Lessons where [ID]=" + id + "").ToString();
                        string pass = GetInfo("Select Lesson_Zoom_Pass From Lessons where [ID]=" + id + "").ToString();
                        string link = "https://us04web.zoom.us/j/" + lesson_id + "?pwd=" + pass;
                        Process.Start(string.Format("zoommtg://zoom.us/join?confno={0}&pwd={1}&zc=0", lesson_id, pass));
                    }
                    string path = Properties.Settings.Default.OBSPath;
                    if (withOBS && File.Exists(Properties.Settings.Default.OBSPath))
                    {
                        Thread.Sleep(Convert.ToInt32(Properties.Settings.Default.KZA * 1000)); //OBS Zaman Aşımı 
                        var info = new ProcessStartInfo
                        {
                            WorkingDirectory = Path.GetDirectoryName(path),
                            FileName = Properties.Settings.Default.OBSPath,
                            Arguments = "--startrecording"
                        };
                        Process.Start(info);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata İçeriği:\n" + ex.Message, "KRİTİK HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            });
        }
        public void StopLesson(bool withOBS)
        {
            try
            {
                foreach (var i in Process.GetProcessesByName("Zoom")) i.Kill();

                if (withOBS)
                {
                    var obs = Process.GetProcessesByName("obs64").ToList();
                    var obs32 = Process.GetProcessesByName("obs64").ToList();
                    Thread.Sleep(Convert.ToInt32(Properties.Settings.Default.KZA * 1000)); //OBS Zaman Aşımı 
                    obs.ForEach(x => x.Kill());
                    obs32.ForEach(x => x.Kill());
                }
            }
            catch (Exception)
            {
                
            }
        }
        private object GetInfo(string q)
        {
            object ret = "";
            bg.Open();
            OleDbCommand cmd = new OleDbCommand(q, bg);
            OleDbDataReader read = cmd.ExecuteReader();
            if (read.Read()) ret = read[0];
            bg.Close();
            return ret;
        }
        private void BwDoWork(object sender, DoWorkEventArgs e)
        {
            while (!isCancel)
            {
                int day = (int)DateTime.Now.DayOfWeek;
                ListBox lb = Controls.Find("lb" + Days[day], true)[0] as ListBox;

                string hour = DateTime.Now.ToString("HH.mm");
                List<string> times = Properties.Settings.Default.LessonTime.Split('|').ToList();
                if (!isStarted && times.Any(x => !string.IsNullOrEmpty(x) && DateTime.Parse(x).ToString("HH.mm") == hour))
                {
                    ix = times.IndexOf(times.FirstOrDefault(x => DateTime.Parse(x).ToString("HH.mm") == hour));
                    if (ix >= 0 && lb.Items[ix].ToString() != "Boş" && !MainClass.OnceDontOpen.Any(x => x == ix.ToString()))
                    {
                        int id = Lesson_IDs[lbDersler.Items.IndexOf(lb.Items[ix])];
                        string teacher = GetInfo($"Select Lesson_Teacher From Lessons where [ID]={id}").ToString();

                        notifyIcon1.BalloonTipTitle = string.Format($"{lb.Items[ix]} Dersi Başladı!");
                        notifyIcon1.BalloonTipText = $"Otomatik ders başlatma özelliği açık olduğundan ders otomatik başlatılıyor.\nÖğretmen: {teacher}";
                        notifyIcon1.ShowBalloonTip(2000);

                        var data = GetInfo($"Select EBAMode From LessonProgram where [Lesson_ID]={id} AND [Day]={day} AND [Order]={ix}");
                        if (data == null) return;
                        isEBA = Convert.ToBoolean(data);
                        Task tsk = StartLesson(true, isEBA, id);
                        tsk.Wait();
                        isStarted = true;
                        delay = 5300;
                    }
                }
                else if (isStarted)
                {
                    if (isEBA)
                    {
                        string finish = DateTime.Parse(times[ix]).AddMinutes(31).ToString("HH.mm");
                        if (DateTime.Now.ToString("HH.mm") == finish)
                        {
                            StopLesson(true);
                            delay = 50000;
                            isStarted = false;
                            isEBA = false;
                        }
                    }
                    else
                    {
                        if (Process.GetProcessesByName("Zoom").All(x => x.MainWindowTitle == "Zoom" || string.IsNullOrWhiteSpace(x.MainWindowTitle)))
                        {
                            string time = DateTime.Now.ToString("HH.mm.ss");
                            System.Threading.Thread.Sleep(6000);
                            if (Process.GetProcessesByName("Zoom").All(x => x.MainWindowTitle == "Zoom" || string.IsNullOrWhiteSpace(x.MainWindowTitle)))
                            {
                                StopLesson(true);
                                delay = 50000;
                                isStarted = false;
                            }
                        }
                    }
                }
                Thread.Sleep(delay);
            }
            e.Cancel = true;
        }
        public void RefBG()
        {
            if (Properties.Settings.Default.AutoStart)
            {
                
                btnAutoZoom.Text = "Otomatik Dersi Durdur";
                isCancel = false;
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();

            }
            else
            {
                btnAutoZoom.Text = "Otomatik Dersi Başlat";
                isCancel = true;
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            RefLessons();
            RefProgram();
            RefBG();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(btnReset, "Yenile");
            tip.SetToolTip(button3, "Ders Programı Ayarları");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MainClass.OpenForm(new Settings());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MainClass.OpenForm(new Lessons());
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (e.KeyData == Keys.Escape)
            {
                lb.SelectedIndex = -1;
            }
            else if (e.KeyData == Keys.Delete && lb.SelectedItems.Count > 0)
            {
                int day = Days.IndexOf(lb.Name.Replace("lb", ""));
                bg.Open();
                try
                {
                    new OleDbCommand($"DELETE FROM LessonProgram where [Order]={lb.SelectedIndex} AND [Day]={day}", bg).ExecuteNonQuery();
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bg.Close();
                lb.Items[lb.SelectedIndex] = "Boş";
                lb.SelectedIndex = -1;
            }
        }
        private void OnClick(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (Control.ModifierKeys == Keys.Shift && lb.SelectedItems.Count > 0)
            {
                int index = lbDersler.Items.IndexOf(lb.SelectedItem.ToString());
                StringBuilder builder = new StringBuilder();
                if (lb.SelectedItem.ToString() != "Boş")
                {
                    string teacher = GetInfo($"Select Lesson_Teacher From Lessons where [ID]={Lesson_IDs[index]}").ToString();
                    builder.AppendLine("Ders Adı: " + lb.SelectedItem.ToString());
                    builder.AppendLine("Öğretmen: " + teacher);
                }
                builder.AppendLine("Başlama Saati: " + DateTime.Parse(Properties.Settings.Default.LessonTime.Split('|')[lb.SelectedIndex]).ToString("HH.mm"));
                MessageBox.Show(builder.ToString(), "DERS HAKKINDA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lb.SelectedIndex = -1;
            }
        }
        private void OnDoubleClick(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if (lb.SelectedItems.Count > 0 && lb.SelectedItem.ToString() != "Boş")
            {
                int index = lbDersler.Items.IndexOf(lb.SelectedItem.ToString());
                var data = GetInfo($"Select EBAMode From LessonProgram where [Lesson_ID]={Lesson_IDs[index]} AND [Day]={Days.IndexOf(lb.Name.Replace("lb", ""))} AND [Order]={lb.SelectedIndex}");
                if (data == null || string.IsNullOrWhiteSpace(data.ToString())) data = false;
                bool check = Convert.ToBoolean(data);
                if (check)
                {
                    string[] times = Properties.Settings.Default.LessonTime.Split('|');
                    bool y = false;
                    foreach (string time in times)
                    {
                        DateTime dtime = new DateTime(1, 1, 1, DateTime.Parse(time).Hour, DateTime.Parse(time).Minute, 0);
                        DateTime now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                        if (now >= dtime && now < dtime.AddMinutes(30)) y = true;
                    }
                    if (!y) return;
                }
                StartLesson(Properties.Settings.Default.RecordLesson, check, Lesson_IDs[index]).Wait();
                if (backgroundWorker1.IsBusy)
                {
                    isStarted = true;
                }
                lb.SelectedIndex = -1;
            }
        }
        private void lbDersler_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbDersler.SelectedItems.Count > 0 && ModifierKeys == Keys.None)
            {
                DoDragDrop(lbDersler.SelectedIndex, DragDropEffects.Move);
                lbDersler.SelectedIndex = -1;
            }

        }
        private void OnDragDrop(object sender, DragEventArgs e)
        {
            ListBox lb = sender as ListBox;
            int ix = lb.SelectedIndex;
            if (ix >= 0)
            {
                int index = Convert.ToInt32(e.Data.GetData("System.Int32"));
                string lesson_name = lbDersler.Items[index].ToString();
                int day = Days.IndexOf(lb.Name.Replace("lb", ""));

                lb.Items[ix] = lesson_name;
                lb.SelectedIndex = -1;

                OleDbCommand cmd = new OleDbCommand();
                string cmdtext = "";
                bg.Open();
                OleDbCommand ole = new OleDbCommand($"Select [ID] From LessonProgram where [Day]={day} AND [Order]={ix}", bg);
                var reader = ole.ExecuteReader();
                try
                {
                    if (reader.Read()) cmdtext = $"UPDATE LessonProgram set Lesson_ID=? where [ID]={reader["ID"].ToString()}";
                    else cmdtext = "INSERT INTO LessonProgram (Lesson_ID,[Day],[Order]) values (?,?,?)";
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cmd.CommandText = cmdtext;
                cmd.Connection = bg;
                cmd.Parameters.AddWithValue("?", Lesson_IDs[index]);
                cmd.Parameters.AddWithValue("?", day);
                cmd.Parameters.AddWithValue("?", ix);
                cmd.ExecuteNonQuery();
                bg.Close();
            }
        }
        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void lbDersler_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && lbDersler.SelectedItems.Count > 0)
            {
                int id = Lesson_IDs[lbDersler.SelectedIndex];
                StartLesson(false, false, id);
                lbDersler.SelectedIndex = -1;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MainClass.OpenForm(new SetProgram());
        }
        private void btnAppClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Uyarı";
            notifyIcon1.BalloonTipText = "Otomatik ders özelliği kapatıldı!";
            notifyIcon1.ShowBalloonTip(2000);
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
        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                btnAppHS.Text = "Programı Göster";
                this.Hide();
            }

        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Adı: Zoom Otomatik Kaydedici");
            builder.AppendLine("Sürüm: " + MainClass.version);
            builder.AppendLine("Firma: Corelium Development INC");
            builder.AppendLine("Geliştirici: Furkan M Yılmaz");
            builder.AppendLine("Tüm Hakları Saklıdır @ 2021");

            MessageBox.Show(builder.ToString(), "Z.O.K. Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnAutoZoom_Click(object sender, EventArgs e)
        {
            if (btnAutoZoom.Text == "Otomatik Dersi Başlat")
            {
                btnAutoZoom.Text = "Otomatik Dersi Durdur";
                isCancel = false;
                if (!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                btnAutoZoom.Text = "Otomatik Dersi Başlat";
                isCancel = true;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) backgroundWorker1.CancelAsync();
            isEBA = false;
            isStarted = false;
            RefLessons();
            RefProgram();
            RefBG();
            btnAppHS.Text = "Programı Gizle";
            if (Control.ModifierKeys == Keys.Shift && !string.IsNullOrEmpty(Properties.Settings.Default.LessonTime))
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
                isStarted = true;
            }
            
        }
        private void OnClickLB(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListBox lb = sender as ListBox;
                int index = lb.SelectedIndex;
                if (index >= 0)
                {
                    day = lb.Name.Replace("lb", "");
                    if (lb.Items[index].ToString() != "Boş")
                    {
                        lb.ContextMenuStrip.Items[0].Visible = true;
                        lb.ContextMenuStrip.Items[1].Visible = true;
                        int id = Lesson_IDs[lbDersler.Items.IndexOf(lb.SelectedItem.ToString())];
                        bool check = Convert.ToBoolean(GetInfo($"Select EBAMode From LessonProgram where [Lesson_ID]={id} AND [Day]={Days.IndexOf(day)} AND [Order]={index}"));
                        if (check) lb.ContextMenuStrip.Items[0].Text = "EBA Kapat";
                        else lb.ContextMenuStrip.Items[0].Text = "EBA Aç";
                        if ((int)DateTime.Now.DayOfWeek == Days.IndexOf(day)) lb.ContextMenuStrip.Items[2].Visible = true;
                        else lb.ContextMenuStrip.Items[2].Visible = false;
                    }
                    else
                    {
                        lb.ContextMenuStrip.Items[0].Visible = false;
                        lb.ContextMenuStrip.Items[1].Visible = false;
                        lb.ContextMenuStrip.Items[2].Visible = false;
                        lb.SelectedIndex = -1;
                    }
                }
                else
                {
                    lb.ContextMenuStrip.Items[0].Visible = false;
                    lb.ContextMenuStrip.Items[1].Visible = false;
                    lb.ContextMenuStrip.Items[2].Visible = false;
                }

            }
        }
        private void btnEBA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(day)) return;
            ListBox lb = this.Controls.Find("lb" + day, true)[0] as ListBox;
            int id = Lesson_IDs[lbDersler.Items.IndexOf(lb.SelectedItem.ToString())];
            bg.Open();
            bool eba = false;
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
            try
            {
                new OleDbCommand($"UPDATE LessonProgram set EBAMode={eba} where [Lesson_ID]={id} AND [Order]={lb.SelectedIndex} AND [Day]={Days.IndexOf(day)}", bg).ExecuteNonQuery();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            bg.Close();
            lb.SelectedIndex = -1;
        }
        private void btnOnce_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(day)) return;
            ListBox lb = Controls.Find("lb" + day, true)[0] as ListBox;
            string ix = lb.SelectedIndex.ToString();
            string item = MainClass.OnceDontOpen.FirstOrDefault(x => x == ix);
            var sndr = sender as ToolStripMenuItem;
            if (!string.IsNullOrEmpty(item))
            {
                MainClass.OnceDontOpen.Remove(item.ToString());
                sndr.Text = "Bir Kereliğine Açma";
            }
            else
            {
                MainClass.OnceDontOpen.Add(ix);
                sndr.Text = "Her Zaman Aç";
            }
            lb.SelectedIndex = -1;
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
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
            {
                MessageBox.Show("EBA giriş bilgileri ayarlanmadı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnProgDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(day)) return;
            ListBox lb = this.Controls.Find("lb" + day, true)[0] as ListBox;
            OnKeyDown(lb, new KeyEventArgs(Keys.Delete));
        }
    }
}
