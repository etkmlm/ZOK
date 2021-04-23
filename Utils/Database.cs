using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

using Lssn = ZoomAutoRecorder.Utils.Lesson;

namespace ZoomAutoRecorder.Utils
{
    public class Database
    {
        const string ACCESS_ERROR = "Program veri tabanına erişemedi. Lütfen veri tabanının (program dizinindeki Database.mdb dosyası) salt okunur olmadığından emin olun, gerekirse programı başka bir yere kurmayı deneyin.";

        public static object GetInfo(string q)
        {
            object ret;
            bg.Open();
            OleDbCommand cmd = new OleDbCommand(q, bg);
            ret = cmd.ExecuteScalar();
            bg.Close();
            return ret;
        }

        static OleDbConnection bg;

        public class General
        {
            public Update Update;

            public General()
            {
                bg = new OleDbConnection(MainClass.conn);
                Update = new Update();
            }
            Main Main => (Main)Application.OpenForms["Main"];
            ListBox lbLessons => Main.Controls.Find("lbDersler", true)[0] as ListBox;
            public void RefLessons()
            {
                Main.Lessons.Clear();
                lbLessons.Items.Clear();
                bg.Open();
                OleDbCommand cmd = new OleDbCommand("Select *from Lessons", bg);
                OleDbDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    int id = Convert.ToInt32(read["ID"]);
                    string name = read["Lesson_Name"].ToString();
                    string zoomid = read["Lesson_Zoom_ID"].ToString();
                    string zoompass = read["Lesson_Zoom_Pass"].ToString();
                    string teacher = read["Lesson_Teacher"].ToString();
                    Lssn lesson = new Lssn()
                    {
                        ID = id,
                        Name = name,
                        ZoomID = zoomid,
                        ZoomPassword = zoompass,
                        Teacher = teacher
                    };
                    Main.Lessons.Add(lesson);
                    lbLessons.Items.Add(name);
                }
                bg.Close();
            }
            public bool GetEBAState(int lid, int day, int order)
            {
                var o = GetInfo($"Select EBAMode From LessonProgram where [Lesson_ID]={lid} AND [Day]={day} AND [Order]={order}");
                return Convert.ToBoolean(o);
            }
            public void RefreshProgram()
            {
                bg.Open();
                OleDbCommand cmd = new OleDbCommand("Select *From LessonProgram", bg);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    int lesson_id = Convert.ToInt32(reader["Lesson_ID"]);
                    int day = Convert.ToInt32(reader["Day"]);
                    int order = Convert.ToInt32(reader["Order"]);
                    string lesson_name = Main.Lessons.FirstOrDefault(x => x.ID == lesson_id).Name;

                    ListBox lb = Main.Controls.Find("lb" + Main.Days[day], true)[0] as ListBox;
                    if (lb.Items.Count - 1 < order)
                    {
                        try
                        {
                            new OleDbCommand("DELETE FROM LessonProgram where [ID]=" + id + "", bg).ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            Main.ShowError(ACCESS_ERROR);
                        }
                        if (day == (int)DateTime.Now.DayOfWeek)
                            MainClass.OnceDontOpen.Remove(id);
                    }
                    else
                        lb.Items[order] = lesson_name;
                }
                bg.Close();
            }
            public void DeleteLessonFromProgram(int order, int day)
            {
                bg.Open();
                try
                {
                    new OleDbCommand($"DELETE FROM LessonProgram where [Order]={order} AND [Day]={day}", bg).ExecuteNonQuery();
                }
                catch (OleDbException)
                {
                    Main.ShowError(ACCESS_ERROR, "HATA");
                }
                bg.Close();
            }
            public void AddLessonToProgram(Lssn lesson, int index, int day)
            {
                bg.Open();
                OleDbCommand ole = new OleDbCommand($"Select [ID] From LessonProgram where [Day]={day} AND [Order]={index}", bg);
                OleDbDataReader reader = ole.ExecuteReader();

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = reader.Read()
                    ? $"UPDATE LessonProgram set Lesson_ID=? where [ID]={reader["ID"]}"
                    : "INSERT INTO LessonProgram (Lesson_ID,[Day],[Order]) values (?,?,?)";
                cmd.Connection = bg;
                cmd.Parameters.AddWithValue("?", lesson.ID);
                cmd.Parameters.AddWithValue("?", day);
                cmd.Parameters.AddWithValue("?", index);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Main.ShowError(ACCESS_ERROR);
                }
                bg.Close();
            }
            public void EBASwitch(int lessonid, int day, bool eba, int order)
            {
                bg.Open();
                try
                {
                    new OleDbCommand($"UPDATE LessonProgram set EBAMode={eba} where [Lesson_ID]={lessonid} AND [Order]={order} AND [Day]={day}", bg).ExecuteNonQuery();
                }
                catch (OleDbException)
                {
                    Main.ShowError(ACCESS_ERROR);
                }
                bg.Close();
            }
        }
        public class Lesson
        {
            Lessons Lessons => (Lessons)Application.OpenForms["Lessons"];
            ListView lvLessons => Lessons.Controls.Find("lvLessons", true)[0] as ListView;
            public void RefreshLessons()
            {
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
            public bool CheckDup(string lname)
            {
                bg.Open();
                OleDbCommand check = new OleDbCommand("Select [ID] From Lessons where Lesson_Name='" + lname + "'", bg);
                OleDbDataReader reader = check.ExecuteReader();
                bool ret = reader.Read();
                bg.Close();
                return ret;
            }
            public void AddLesson(string name, string zoomid, string pass, string teacher)
            {
                bg.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO Lessons (Lesson_Name,Lesson_Zoom_ID,Lesson_Zoom_Pass,Lesson_Teacher) values (?,?,?,?)", bg);
                cmd.Parameters.AddWithValue("?", name);
                cmd.Parameters.AddWithValue("?", zoomid);
                cmd.Parameters.AddWithValue("?", pass);
                cmd.Parameters.AddWithValue("?", teacher);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OleDbException)
                {
                    Main.ShowError(ACCESS_ERROR);
                }
                bg.Close();
            }
            public void DeleteLesson(int id)
            {
                bg.Open();
                try
                {
                    new OleDbCommand("DELETE FROM Lessons where [ID]=" + id + "", bg).ExecuteNonQuery();
                }
                catch (OleDbException)
                {
                    Main.ShowError(ACCESS_ERROR);
                }
                bg.Close();
            }
            public void UpdateLesson(int id, string name, string zoomid, string pass, string teacher)
            {
                bg.Open();
                try
                {
                    new OleDbCommand("UPDATE Lessons set Lesson_Name='" + name + "',Lesson_Zoom_ID='" + zoomid + "',Lesson_Zoom_Pass='" + pass + "',Lesson_Teacher='" + teacher + "' where [ID]=" + id + "", bg).ExecuteNonQuery();
                }
                catch (OleDbException)
                {
                    Main.ShowError(ACCESS_ERROR);
                }
                bg.Close();
            }
        }
    }
}
