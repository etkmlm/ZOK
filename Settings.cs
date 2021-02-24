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
        public Settings()
        {
            InitializeComponent();
        }

        private void Save()
        {
            string zoom = txtZoomPath.Text;
            string obs = txtOBSPath.Text;
            if (File.Exists(zoom))
            {
                if (chkKaydet.Checked && !File.Exists(obs))
                {
                    MessageBox.Show("Ders kaydetme modu aktifken OBS yolu boş bırakılamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Properties.Settings.Default.ZoomPath = txtZoomPath.Text;
                Properties.Settings.Default.OBSPath = txtOBSPath.Text;
                Properties.Settings.Default.AutoStart = chkOto.Checked;
                Properties.Settings.Default.RecordLesson = chkKaydet.Checked;
                Properties.Settings.Default.DZA = Convert.ToDouble(nudDers.Value);
                Properties.Settings.Default.KZA = Convert.ToDouble(nudKayit.Value);
                Properties.Settings.Default.Save();
                ((Main)Application.OpenForms["Main"]).RefBG();
            }
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
            ToolTip tip = new ToolTip();
            tip.SetToolTip(lblDZA, "Dersin başlaması için zaman aşımı.");
            tip.SetToolTip(lblKZA, "Ders kaydının başlaması için zaman aşımı.");

            txtZoomPath.Text = Properties.Settings.Default.ZoomPath;
            txtOBSPath.Text = Properties.Settings.Default.OBSPath;
            chkOto.Checked = Properties.Settings.Default.AutoStart;
            chkKaydet.Checked = Properties.Settings.Default.RecordLesson;
            txtOBSPath.Enabled = chkKaydet.Checked;
            btnOBS.Enabled = chkKaydet.Checked;
            nudKayit.Enabled = chkKaydet.Checked;
            nudDers.Value = Convert.ToDecimal(Properties.Settings.Default.DZA);
            nudKayit.Value = Convert.ToDecimal(Properties.Settings.Default.KZA);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtOBSPath.Clear();
            txtZoomPath.Clear();
            chkOto.Checked = false;
            chkKaydet.Checked = true;
            nudDers.Value = 1.5m;
            nudKayit.Value = 3;
            Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            MessageBox.Show("Ayarlarınız kaydedildi!", "Zoom Ders Kaydedici", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void chkKaydet_CheckedChanged(object sender, EventArgs e)
        {
            txtOBSPath.Enabled = chkKaydet.Checked;
            btnOBS.Enabled = chkKaydet.Checked;
            nudKayit.Enabled = chkKaydet.Checked;
        }
        private void btnSecret_Click(object sender, EventArgs e)
        {
            MainClass.OpenForm(new Secret());
        }
    }
}
