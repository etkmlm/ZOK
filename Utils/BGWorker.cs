using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomAutoRecorder.Utils
{
    public class BGWorker
    {
        public bool isStarted, isEBA, isCancel = false;
        public int ix = -1;
        int delay;

        Main Main
        {
            get => (Main)Application.OpenForms["Main"];
        }
        public BGWorker(ref BackgroundWorker worker)
        {
            worker.RunWorkerCompleted += Worker_Completed;
            worker.DoWork += Worker_Work;
            delay = Properties.Settings.Default.WorkerDelay;
        }
        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Main.ShowBalloon("Uyarı", "Otomatik ders özelliği kapatıldı!");
        }
        private void Worker_Work(object sender, DoWorkEventArgs e)
        {
            while (!isCancel)
            {
                delay = Properties.Settings.Default.WorkerDelay;
                int day = (int)DateTime.Now.DayOfWeek;
                ListBox lb = Main.Controls.Find("lb" + Main.Days[day], true)[0] as ListBox;

                string hour = DateTime.Now.ToString("HH.mm");
                List<string> times = Properties.Settings.Default.LessonTime.Split('|').ToList();

                if (!isStarted)
                {
                    ix = times.FindIndex(x => DateTime.Parse(x).ToString("HH.mm") == hour);
                    if (ix >= 0 && lb.Items[ix].ToString() != "Boş" && !MainClass.OnceDontOpen.Any(x => x == ix))
                    {
                        Lesson lesson = Main.Lessons.FirstOrDefault(x => x.Name == lb.Items[ix].ToString());
                        Main.ShowBalloon(
                            $"{lesson.Name} Dersi Başladı!",
                            $"Otomatik ders başlatma özelliği açık olduğundan ders otomatik başlatılıyor." +
                            $"\nÖğretmen: {lesson.Teacher}");

                        isEBA = Main.Manager.GetEBAState(lesson.ID, day, ix);
                        ZoomEntities.StartLesson(true, isEBA, lesson, true).Wait();
                        ZoomEntities.StartedLessonID = lesson.ID;
                        isStarted = true;
                        delay = 5300;
                    }
                }
                else if (isStarted)
                {
                    void a()
                    {
                        ZoomEntities.StopLesson(true);
                        ZoomEntities.StartedLessonID = -1;
                        delay = Properties.Settings.Default.WorkerDelay;
                        isStarted = false;
                        isEBA = false;
                    }
                    if (isEBA)
                    {
                        string finish = DateTime.Parse(times[ix]).AddMinutes(30.5).ToString("HH.mm");
                        if (DateTime.Now.ToString("HH.mm") == finish)
                            a();
                    }
                    else
                    {
                        if (Process.GetProcessesByName("Zoom").All(x => x.MainWindowTitle == "Zoom" || string.IsNullOrWhiteSpace(x.MainWindowTitle)))
                        {
                            string time = DateTime.Now.ToString("HH.mm.ss");
                            System.Threading.Thread.Sleep(6000);
                            if (Process.GetProcessesByName("Zoom").All(x => x.MainWindowTitle == "Zoom" || string.IsNullOrWhiteSpace(x.MainWindowTitle)))
                                a();
                        }
                    }
                }
                System.Threading.Thread.Sleep(delay);
            }
            e.Cancel = isCancel;
        }
    }
}
