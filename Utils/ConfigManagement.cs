using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomAutoRecorder.Utils
{
    public class ConfigManagement
    {
        const string ConfigName = "Backup{0}.zokcfg";
        string BackupsPath;
        public ConfigManagement()
        {
            BackupsPath = Path.Combine(Environment.CurrentDirectory, "Backups");
        }
        private void SetConfig(string key, string value)
        {
            try
            {
                switch (key)
                {
                    case "AutoStart":
                        Properties.Settings.Default.AutoStart = bool.Parse(value);
                        break;
                    case "DZA":
                        Properties.Settings.Default.DZA = double.Parse(value.Replace(",", "."));
                        break;
                    case "KZA":
                        Properties.Settings.Default.KZA = double.Parse(value.Replace(",", "."));
                        break;
                    case "LT":
                        Properties.Settings.Default.LessonTime = value;
                        break;
                    case "OBS":
                        Properties.Settings.Default.OBSPath = value;
                        break;
                    case "Zoom":
                        Properties.Settings.Default.ZoomPath = value;
                        break;
                    case "Record":
                        Properties.Settings.Default.RecordLesson = bool.Parse(value);
                        break;
                    case "WD":
                        int val = int.Parse(value);
                        if (val < 0) return;
                        Properties.Settings.Default.WorkerDelay = val;
                        break;
                    default:
                        return;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                return;
            }
        }
        public bool RestoreConfig(string path)
        {
            if (!File.Exists(path)) return false;
            string[] lines = File.ReadAllLines(path);
            if (lines[0] != "[ZOKCONFIG]") return false;

            try
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] split = lines[i].Split('=');
                    SetConfig(split[0], split[1]);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        
        public string[] GetRestoredConfigs()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Backups");
            Directory.CreateDirectory(path);
            return Directory.GetFiles(path);
        }
        private int GetLastFileIndex()
        {
            int index = 0;

            try
            {
                foreach (string x in Directory.GetFiles(BackupsPath))
                {
                    string name = Path.GetFileNameWithoutExtension(x);
                    int number = int.Parse(name.Replace("Backup", ""));
                    if (number > index) index = number;
                }
                index++;
            }
            catch (Exception)
            {

            }

            return index;
        }
        public bool BackupConfig()
        {
            Directory.CreateDirectory(BackupsPath);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("[ZOKCONFIG]");
            builder.AppendLine("AutoStart=" + Properties.Settings.Default.AutoStart);
            builder.AppendLine("DZA=" + Properties.Settings.Default.DZA);
            builder.AppendLine("KZA=" + Properties.Settings.Default.KZA);
            builder.AppendLine("LT=" + Properties.Settings.Default.LessonTime);
            builder.AppendLine("OBS=" + Properties.Settings.Default.OBSPath);
            builder.AppendLine("Zoom=" + Properties.Settings.Default.ZoomPath);
            builder.AppendLine("Record=" + Properties.Settings.Default.RecordLesson);
            builder.AppendLine("WD=" + Properties.Settings.Default.WorkerDelay);
            int index = GetLastFileIndex();
            if (index == 0) return false;
            string path = Path.Combine(Environment.CurrentDirectory, "Backups", String.Format(ConfigName, index));
            File.WriteAllText(path, builder.ToString());
            return true;
        }
    }
}
