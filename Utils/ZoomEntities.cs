using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomAutoRecorder.Utils
{
    public struct Lesson
    {
        public int ID { get; set; }
        public string ZoomID { get; set; }
        public string ZoomPassword { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
    }
    public class ZoomEntities
    {
        public static int StartedLessonID = -1;
        public static async Task<bool> StartLesson(bool withOBS, bool ebaMode, Lesson lesson, bool isAuto = false)
        {
            try
            {
                StopLesson(true);
                await Task.Delay(Convert.ToInt32(Properties.Settings.Default.DZA * 1000)); //Ders Zaman Aşımı 
                if (ebaMode)
                {
                    string[] tpass = Properties.Settings.Default.TCKNPASS.Split('#');
                    if (tpass.Length != 2) return false;
                    new Browser(Encryption.Decrypt(tpass[0]), Encryption.Decrypt(tpass[1]), false, isAuto).ShowDialog();
                }
                else
                    Process.Start($"zoommtg://zoom.us/join?confno={lesson.ZoomID}&pwd={lesson.ZoomPassword}&zc=0");

                string path = Properties.Settings.Default.OBSPath;
                if (withOBS && File.Exists(Properties.Settings.Default.OBSPath))
                {
                    await Task.Delay(Convert.ToInt32(Properties.Settings.Default.KZA * 1000)); //OBS Zaman Aşımı 
                    var info = new ProcessStartInfo
                    {
                        WorkingDirectory = Path.GetDirectoryName(path),
                        FileName = Properties.Settings.Default.OBSPath,
                        Arguments = "--startrecording"
                    };
                    Process.Start(info);
                }
                StartedLessonID = lesson.ID;
                return true;
            }
            catch (Exception ex)
            {
                Main.ShowError("Hata İçeriği:\n" + ex.Message, "KRİTİK HATA");
                return false;
            }
        }
        public static void StopLesson(bool withOBS)
        {
            try
            {
                foreach (var i in Process.GetProcessesByName("Zoom")) i.Kill();

                if (withOBS)
                {
                    var obs = Process.GetProcessesByName("obs64").ToList();
                    var obs32 = Process.GetProcessesByName("obs32").ToList();
                    Task.Delay(Convert.ToInt32(Properties.Settings.Default.KZA * 1000)); //OBS Zaman Aşımı 
                    obs.ForEach(x => x.Kill());
                    obs32.ForEach(x => x.Kill());
                }
                StartedLessonID = -1;
            }
            catch (Exception)
            {
                StartedLessonID = -1;
            }
        }
    }
}
