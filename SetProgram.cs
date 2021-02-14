using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomAutoRecorder
{
    public partial class SetProgram : Form
    {
        public SetProgram()
        {
            InitializeComponent();
        }
        List<string> periods = new List<string>();

        private void nudLessonNumber_ValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(nudLessonNumber.Value);
            if (periods.Count > value)
            {
                for (int i = periods.Count-1; i >= value; i--) periods.RemoveAt(i);
            }
            else if (periods.Count < value)
            {
                int f = value - periods.Count;
                for (int i = 0; i < f; i++) periods.Add("");
            }
            lbPeriods.Items.Clear();
            periods.Select((x, y) => y).ToList().ForEach(x => lbPeriods.Items.Add(x + 1 + ". Ders"));
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (lbPeriods.SelectedItems.Count > 0)
            {
                int index = lbPeriods.SelectedIndex;
                periods[index] = dateTimePicker1.Value.ToString();
            }
        }
        private void lbPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPeriods.SelectedItems.Count > 0)
            {
                int index = lbPeriods.SelectedIndex;
                string date = periods[index];
                if (!string.IsNullOrEmpty(date))
                {
                    dateTimePicker1.Value = DateTime.Parse(date);
                }
                else
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
            }
        }
        private void RefreshProgram()
        {
            string[] spl = Properties.Settings.Default.LessonTime.Split('|');
            if (spl != null)
            {
                nudLessonNumber.Value = spl.Count();
                spl.Select((x, y) => new { Item = x, Index = y }).ToList().ForEach(x => periods[x.Index] = x.Item);
            }
            else
            {
                nudLessonNumber.Value = 0;
                periods.Clear();
                lbPeriods.Items.Clear();
            }
        }
        private void SetProgram_Load(object sender, EventArgs e)
        {
            RefreshProgram();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (nudLessonNumber.Value != 0)
            {
                string prop = "";
                for (int i = 0; i < periods.Count; i++)
                {
                    if (i == 0) prop = periods[i];
                    else prop += "|" + periods[i];
                }
                Properties.Settings.Default.LessonTime = prop;
                Properties.Settings.Default.Save();
                (Application.OpenForms["Main"] as Main).RefProgram();
                MessageBox.Show("Ders programı ayarları güncellendi!", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lütfen değerleri düzgün girin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
