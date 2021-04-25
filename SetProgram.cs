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
        List<string> Periods = new List<string>();

        private void nudLessonNumber_ValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(nudLessonNumber.Value);
            if (Periods.Count > value)
                for (int i = Periods.Count - 1; i >= value; i--)
                    Periods.RemoveAt(i);
            else if (Periods.Count < value)
            {
                int f = value - Periods.Count;
                for (int i = 0; i < f; i++) 
                    Periods.Add("");
            }
            lbPeriods.Items.Clear();
            for (int i = 0; i < Periods.Count; i++)
                lbPeriods.Items.Add(i + 1 + ". Toplantı");
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (lbPeriods.SelectedItems.Count <= 0) return;
            int index = lbPeriods.SelectedIndex;
            Periods[index] = dateTimePicker1.Value.ToString();
        }
        private void lbPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPeriods.SelectedItems.Count <= 0) return;

            int index = lbPeriods.SelectedIndex;
            string date = Periods[index];
            if (!string.IsNullOrEmpty(date))
                dateTimePicker1.Value = DateTime.Parse(date);
            else
                dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }
        private void RefreshProgram()
        {
            string[] spl = Properties.Settings.Default.LessonTime.Split('|');
            if (spl != null)
            {
                nudLessonNumber.Value = spl.Count();
                spl.Select((x, y) => new { Item = x, Index = y }).ToList().ForEach(x => Periods[x.Index] = x.Item);
            }
            else
            {
                nudLessonNumber.Value = 0;
                Periods.Clear();
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
                for (int i = 0; i < Periods.Count; i++)
                {
                    if (i == 0) prop = Periods[i];
                    else prop += "|" + Periods[i];
                }
                Properties.Settings.Default.LessonTime = prop;
                Properties.Settings.Default.Save();
                (Application.OpenForms["Main"] as Main).RefProgram();
                Main.ShowInfo("Program ayarları güncellendi!", "BAŞARILI");
                this.Close();
            }
            else
                Main.ShowError("Lütfen değerleri düzgün girin.");
        }
    }
}
