using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomAutoRecorder.Utils
{
    class MainClass
    {
        public const string conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb";
        public const string version = "0.91";
        
        public static string EBALink;
        public static List<int> OnceDontOpen = new List<int>();
        public static List<LessonPeriod> DailyMeetings = new List<LessonPeriod>();

        public static void OpenForm(Form frm)
        {
            if (frm != null && Application.OpenForms[frm.Name] == null)
                frm.Show();
        }
    }
}
