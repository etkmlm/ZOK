using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomAutoRecorder
{
    public partial class Settings : Form
    {
        bool advanced = false;
        int[] delays = { 50, 25, 10, 0 };

        public Settings()
        {
            InitializeComponent();
        }

        private bool Save(bool safe = false)
        {
            string zoom = txtZoomPath.Text;
            string obs = txtOBSPath.Text;
            if (!File.Exists(zoom))
            {
                Main.ShowError("Zoom yolu geçerli değil!");
                return false;
            }
            if (chkKaydet.Checked && !File.Exists(obs))
            {
                Main.ShowError("Ders kaydetme modu aktifken OBS yolu boş bırakılamaz!");
                return false;
            }
            
            Properties.Settings.Default.ZoomPath = txtZoomPath.Text;
            Properties.Settings.Default.OBSPath = txtOBSPath.Text;
            Properties.Settings.Default.AutoStart = chkOto.Checked;
            Properties.Settings.Default.RecordLesson = chkKaydet.Checked;
            Properties.Settings.Default.AutoMode = chkOtoMod.Checked;
            Properties.Settings.Default.WorkerDelay = Convert.ToInt32(nudDelay.Value) * 1000;
            Properties.Settings.Default.DZA = Convert.ToDouble(nudDers.Value);
            Properties.Settings.Default.KZA = Convert.ToDouble(nudKayit.Value);
            Properties.Settings.Default.Save();
            ((Main)Application.OpenForms["Main"]).RefBG();
            return true;
        }
        private void btnZoom_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = txtZoomPath.Text;
            openFileDialog1.ShowDialog();
            txtZoomPath.Text = openFileDialog1.FileName;
        }
        private void btnOBS_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = txtOBSPath.Text;
            openFileDialog1.ShowDialog();
            txtOBSPath.Text = openFileDialog1.FileName;
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            this.Size = new Size(450, 310);
            ToolTip tip = new ToolTip();
            tip.SetToolTip(lblDZA, "Toplantının başlaması için zaman aşımı.");
            tip.SetToolTip(lblKZA, "Toplantı kaydının başlaması için zaman aşımı.");
            tip.SetToolTip(chkOtoMod, "EBA açılmazsa otomatik olarak Zoom linkine girer.");
            tip.SetToolTip(lblD, "Zaman kontrolü için gecikme. (Gecikme ile performans doğru orantılıdır.)");

            txtZoomPath.Text = Properties.Settings.Default.ZoomPath;
            txtOBSPath.Text = Properties.Settings.Default.OBSPath;
            chkOto.Checked = Properties.Settings.Default.AutoStart;
            chkOtoMod.Enabled = chkOto.Checked;
            comboDelay.Enabled = chkOto.Checked;
            chkOtoMod.Checked = Properties.Settings.Default.AutoMode;
            chkKaydet.Checked = Properties.Settings.Default.RecordLesson;
            txtOBSPath.Enabled = chkKaydet.Checked;
            btnOBS.Enabled = chkKaydet.Checked;
            nudKayit.Enabled = chkKaydet.Checked;
            nudDers.Value = Convert.ToDecimal(Properties.Settings.Default.DZA);
            nudKayit.Value = Convert.ToDecimal(Properties.Settings.Default.KZA);

            int delay = Properties.Settings.Default.WorkerDelay / 1000;

            if (delays.Contains(delay))
                comboDelay.SelectedIndex = Array.IndexOf(delays, delay);
            else
            {
                comboDelay.SelectedIndex = 3;
                nudDelay.Enabled = true;
                nudDelay.Value = delay;
            }

            this.ActiveControl = label1;
        }
        private void btnDefault_Click(object sender, EventArgs e)
        {
            txtOBSPath.Clear();
            txtZoomPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Zoom", "bin", "Zoom.exe");
            chkOto.Checked = true;
            chkKaydet.Checked = false;
            chkOtoMod.Checked = false;
            nudDers.Value = 1.5m;
            nudKayit.Value = 2;
            comboDelay.SelectedIndex = 0;
            Save();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool s = Save();
            if (!s) return;
            Main.ShowInfo("Ayarlarınız kaydedildi!", "BİLGİLENDİRME");
            this.Close();
        }
        private void chkKaydet_CheckedChanged(object sender, EventArgs e)
        {
            txtOBSPath.Enabled = chkKaydet.Checked;
            btnOBS.Enabled = chkKaydet.Checked;
            nudKayit.Enabled = chkKaydet.Checked;
        }
        private void btnEBA_Click(object sender, EventArgs e)
        {
            Utils.MainClass.OpenForm(new Secret());
        }
        private void chkOto_CheckedChanged(object sender, EventArgs e)
        {
            chkOtoMod.Enabled = chkOto.Checked;
            comboDelay.Enabled = chkOto.Checked;
            comboDelay_SelectedIndexChanged(null, null);
            chkKaydet.Enabled = chkOto.Checked;
            chkKaydet_CheckedChanged(null, null);
            nudDers.Enabled = chkOto.Checked;
            
            if (!chkOto.Checked)
            {
                nudDelay.Enabled = false;
                nudKayit.Enabled = false;
            }
                
        }
        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            if (advanced)
            {
                advanced = false;
                this.Size = new Size(450, 310);
                nudDers.Value = 1.5m;
                nudKayit.Value = 2;
                comboDelay.SelectedIndex = 0;
            }
            else
            {
                advanced = true;
                this.Size = new Size(450, 400);
            }
        }
        private void comboDelay_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboDelay.SelectedIndex;
            if (index < 0) return;
            if (index > delays.Length-1)
                nudDelay.Enabled = true;
            else
            {
                nudDelay.Enabled = false;
                nudDelay.Value = delays[index];
            }
        }
    }
}
