using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ZoomAutoRecorder
{
    public partial class Lessons : Form
    {
        public Lessons()
        {
            InitializeComponent();
        }

        OleDbConnection bg = new OleDbConnection(MainClass.conn);

        private void Clear()
        {
            lvLessons.Items.Clear();
            txtLessonName.Clear();
            txtLink.Clear();
            txtTeacher.Clear();
            txtZoomID.Clear();
            txtZoomPass.Clear();
        }
        private void RefreshLessons()
        {
            Clear();
            bg.Open();
            OleDbCommand cmd = new OleDbCommand("Select *from Lessons", bg);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem();
                item.Text = reader["ID"].ToString();
                item.SubItems.Add(reader["Lesson_Name"].ToString());
                item.SubItems.Add(reader["Lesson_Zoom_ID"].ToString());
                item.SubItems.Add(reader["Lesson_Zoom_Pass"].ToString());
                item.SubItems.Add(reader["Lesson_Teacher"].ToString());
                lvLessons.Items.Add(item);
            }
            bg.Close();
        }
        private void Lessons_Load(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(txtZoomPass, "Link içinde bulunan saf parolanın şifrelenmiş halini girin.");
            RefreshLessons();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLessons();
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(btnSolve.Text))
            {
                string part = txtLink.Text.Split('/')[4];

                string id = part.Split('?')[0];
                string pass = part.Split('?')[1].Replace("pwd=", "");

                txtZoomID.Text = id;
                txtZoomPass.Text = pass;
                txtLink.Clear();
            }
        }
        private void lvLessons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvLessons.SelectedItems.Count > 0)
            {
                txtLessonName.Text = lvLessons.SelectedItems[0].SubItems[1].Text;
                txtZoomID.Text = lvLessons.SelectedItems[0].SubItems[2].Text;
                txtZoomPass.Text = lvLessons.SelectedItems[0].SubItems[3].Text;
                txtTeacher.Text = lvLessons.SelectedItems[0].SubItems[4].Text;
            }
        }
        private bool CheckDup(string lname)
        {
            bool ret = false;
            bg.Open();
            OleDbCommand check = new OleDbCommand("Select [ID] From Lessons where Lesson_Name='" + lname + "'", bg);
            OleDbDataReader reader = check.ExecuteReader();
            ret = reader.Read();
            bg.Close();
            return ret;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lesson_name = txtLessonName.Text;
            string zoomid = txtZoomID.Text.Replace(" ", "");
            string zoompass = txtZoomPass.Text;
            string teacher = txtTeacher.Text;
            if (!string.IsNullOrWhiteSpace(lesson_name) && !string.IsNullOrWhiteSpace(zoomid) && !string.IsNullOrWhiteSpace(zoompass) && !string.IsNullOrWhiteSpace(teacher))
            {
                
                if (CheckDup(lesson_name))
                {
                    MessageBox.Show("Bu isme sahip bir ders daha var!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bg.Open();
                    try
                    {
                        OleDbCommand cmd = new OleDbCommand("INSERT INTO Lessons (Lesson_Name,Lesson_Zoom_ID,Lesson_Zoom_Pass,Lesson_Teacher) values (?,?,?,?)", bg);
                        cmd.Parameters.AddWithValue("?", lesson_name);
                        cmd.Parameters.AddWithValue("?", zoomid);
                        cmd.Parameters.AddWithValue("?", zoompass);
                        cmd.Parameters.AddWithValue("?", teacher);
                        cmd.ExecuteNonQuery();   
                    }
                    catch (OleDbException)
                    {
                        MessageBox.Show("Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    bg.Close();
                    Clear();
                    RefreshLessons();
                    (Application.OpenForms["Main"] as Main).RefLessons();
                }
            }
            else
            {
                MessageBox.Show("Hiçbir alan boş bırakılamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvLessons.SelectedItems.Count > 0)
            {
                int id = int.Parse(lvLessons.SelectedItems[0].SubItems[0].Text);
                bg.Open();
                try
                {
                    new OleDbCommand("DELETE FROM Lessons where [ID]=" + id + "", bg).ExecuteNonQuery();   
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bg.Close();
                Clear();
                RefreshLessons();
                (Application.OpenForms["Main"] as Main).RefLessons();
                (Application.OpenForms["Main"] as Main).RefProgram();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string lesson_name = txtLessonName.Text;
            string zoomid = txtZoomID.Text.Replace(" ", "");
            string zoompass = txtZoomPass.Text;
            string teacher = txtTeacher.Text;
            if (lvLessons.SelectedItems.Count > 0 && !string.IsNullOrWhiteSpace(lesson_name) && !string.IsNullOrWhiteSpace(zoomid) && !string.IsNullOrWhiteSpace(zoompass) && !string.IsNullOrWhiteSpace(teacher))
            {
                int id = int.Parse(lvLessons.SelectedItems[0].SubItems[0].Text);
                bg.Open();
                try
                {
                    new OleDbCommand("UPDATE Lessons set Lesson_Name='" + lesson_name + "',Lesson_Zoom_ID='" + zoomid + "',Lesson_Zoom_Pass='" + zoompass + "',Lesson_Teacher='" + teacher + "' where [ID]=" + id + "", bg).ExecuteNonQuery();   
                }
                catch (OleDbException)
                {
                    MessageBox.Show("Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bg.Close();
                RefreshLessons();
                (Application.OpenForms["Main"] as Main).RefLessons();
                (Application.OpenForms["Main"] as Main).RefProgram();
            }
        }
        private void lvLessons_KeyDown(object sender, KeyEventArgs e)
        {
            btnDelete_Click(null, null);
        }
    }
}
