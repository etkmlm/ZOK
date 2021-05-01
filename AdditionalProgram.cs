using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZoomAutoRecorder.Utils;

namespace ZoomAutoRecorder
{
    public partial class AdditionalProgram : Form
    {
        public AddiOps ops;
        public AdditionalProgram()
        {
            InitializeComponent();
            ops = new AddiOps();
        }
        private void ClearControls()
        {
            cLessons.SelectedIndex = -1;
            chkEBA.Checked = chkRecord.Checked = false;
        }
        private void AdditionalProgram_Load(object sender, EventArgs e)
        {
            ops.RefreshLessons();
            ops.RefreshList();
        }
        private LessonPeriod GetPeriod()
        {
            Lesson lesson = Main.Lessons.FirstOrDefault(x => x.Name == cLessons.SelectedItem.ToString());
            return new LessonPeriod()
            {
                Lesson = lesson,
                IsEBA = chkEBA.Checked,
                AutoRecord = chkRecord.Checked,
                Time = dateTimePicker1.Value.ToString("HH.mm")
            };
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cLessons.SelectedIndex == -1)
            {
                Main.ShowError("Lütfen bir link adı seçin.");
                return;
            }
            ops.ChangeLesson(GetPeriod());
            ops.RefreshList();
            ClearControls();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lvLessons.SelectedItems.Count == 0) return;

            int index = int.Parse(lvLessons.SelectedItems[0].SubItems[0].Text);
            ops.ChangeLesson(GetPeriod(), index);
            ops.RefreshList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvLessons.SelectedItems.Count == 0) return;

            int index = int.Parse(lvLessons.SelectedItems[0].SubItems[0].Text);
            ops.RemoveLesson(index);
            ops.RefreshList();
            ClearControls();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ops.RefreshLessons();
            ops.RefreshList();
            ClearControls();
        }

        private void lvLessons_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvLessons.SelectedItems.Count == 0) return;
            int index = int.Parse(lvLessons.SelectedItems[0].SubItems[0].Text);
            var period = MainClass.DailyMeetings[index];
            cLessons.SelectedItem = period.Lesson.Name;
            dateTimePicker1.Value = DateTime.ParseExact(period.Time, "HH.mm", System.Globalization.CultureInfo.CurrentCulture);
            chkEBA.Checked = period.IsEBA;
            chkRecord.Checked = period.AutoRecord;
        }
    }

    public class AddiOps
    {
        AdditionalProgram Frm => Application.OpenForms["AdditionalProgram"] as AdditionalProgram;
        ComboBox cLessons => Frm.Controls.Find("cLessons", true)[0] as ComboBox;
        ListView lvLessons => Frm.Controls.Find("lvLessons", true)[0] as ListView;
        public void RefreshList()
        {
            lvLessons.Items.Clear();
            for (int i = 0; i < MainClass.DailyMeetings.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = i.ToString();
                var x = MainClass.DailyMeetings[i];
                item.SubItems.Add(x.Lesson.Name);
                item.SubItems.Add(x.Time);
                lvLessons.Items.Add(item);
            }
        }
        public void RefreshLessons()
        {
            cLessons.Items.Clear();
            cLessons.Items.AddRange(Main.Lessons.Select(x => x.Name).ToArray());
        }
        public void ChangeLesson(LessonPeriod period, int index = -1)
        {
            if (index == -1)
            {
                if (MainClass.DailyMeetings.Any(x => x.Time == period.Time))
                    Main.ShowError("Lütfen farklı bir saat girin.");
                else
                    MainClass.DailyMeetings.Add(period);
            }
            else
            {
                if (MainClass.DailyMeetings.Count - 1 < index)
                    Main.ShowError("İndis geçersiz.");
                else
                    MainClass.DailyMeetings[index] = period;
            }
        }
        public void RemoveLesson(int index)
        {
            if (MainClass.DailyMeetings.Count - 1 < index)
                Main.ShowError("İndis geçersiz.");
            else
                MainClass.DailyMeetings.RemoveAt(index);
        }
    }
}
