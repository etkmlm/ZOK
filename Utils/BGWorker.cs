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
        public int delay;

        Main Main
        {
            get => (Main)Application.OpenForms["Main"];
        }
        public BGWorker(ref BackgroundWorker worker)
        {
            worker.DoWork += Worker_Work;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            delay = Properties.Settings.Default.WorkerDelay;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Main.ShowBalloon("Uyarı", "Otomatik başlatma durduruldu!", 1000);
        }

        private void Worker_Work(object sender, DoWorkEventArgs e)
        {
            while (!isCancel)
            {
                
                int day = (int)DateTime.Now.DayOfWeek;
                ListBox lb = Main.Controls.Find("lb" + Main.Days[day], true)[0] as ListBox;

                string hour = DateTime.Now.ToString("HH.mm");
                if (string.IsNullOrEmpty(Properties.Settings.Default.LessonTime)) continue;
                List<string> times = Properties.Settings.Default.LessonTime.Split('|').ToList();
                
                if (!isStarted)
                {
                    delay = Properties.Settings.Default.WorkerDelay;
                    ix = times.FindIndex(x => DateTime.Parse(x).ToString("HH.mm") == hour);
                    bool condition, addi = false;
                    if (ix >= 0)
                    {
                        addi = false;
                        condition = lb.Items[ix].ToString() != "Boş" && !MainClass.OnceDontOpen.Any(x => x == ix);
                    }
                    else
                    {
                        ix = MainClass.DailyMeetings.FindIndex(x => x.Time == hour);
                        if (ix >= 0)
                            addi = condition = true;
                        else
                            condition = false;
                    }
                    
                    if (condition)
                    {
                        LessonPeriod period = MainClass.DailyMeetings[ix];
                        Lesson lesson = addi ? period.Lesson : Main.Lessons.FirstOrDefault(x => x.Name == lb.Items[ix].ToString());
                        Main.ShowBalloon(
                            $"{lesson.Name} Toplantısı Başladı!",
                            $"Otomatik başlatma özelliği açık olduğundan toplantı otomatik başlatılıyor." +
                            $"\nSunucu: {lesson.Teacher}");

                        isEBA = addi ? period.IsEBA : Main.Manager.GetEBAState(lesson.ID, day, ix);
                        bool record = addi ? period.AutoRecord : Properties.Settings.Default.RecordLesson;
                        ZoomEntities.StartLesson(record, isEBA, lesson, true).Wait();
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
