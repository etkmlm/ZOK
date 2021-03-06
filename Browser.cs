﻿using System.Drawing;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using CefSharp.Handler;
using System.Diagnostics;
using System.Collections;

namespace ZoomAutoRecorder
{
    public partial class Browser : Form
    {
        public ChromiumWebBrowser browser;
        public string TCKN, Pass;
        public bool isMax;
        public Browser(string tckn, string pass, bool isMax, bool isAuto = false)
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.SuspendLayout();
            this.ClientSize = new Size(250, 250);
            this.isMax = isMax;
            if (isMax) this.WindowState = FormWindowState.Maximized;
            this.Name = "Browser";
            this.Text = "Tarayıcı";
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.ResumeLayout(false);

            TCKN = tckn;
            Pass = pass;
            InitializeCEF(isAuto);
        }
        public void InitializeCEF(bool auto)
        {
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                Cef.Initialize(settings);
            }
            browser = new ChromiumWebBrowser("https://giris.eba.gov.tr/EBA_GIRIS/giris.jsp");
            browser.Dock = DockStyle.Fill;
            browser.FrameLoadEnd += FrameLoadEnd;
            browser.KeyDown += Browser_KeyDown;
            if (auto) browser.TitleChanged += Browser_TitleChanged;
            browser.RequestHandler = new CefHandler(this);
            this.Controls.Add(browser);
        }
        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            if (e.Title.Contains("EBA, Eğitim Bilişim Ağı, Ders, Haber"))
            {
                Utils.Lesson lesson = Main.Lessons.Find(x => x.ID == Utils.ZoomEntities.StartedLessonID);
                Utils.ZoomEntities.StartLesson(Properties.Settings.Default.RecordLesson, false, lesson).Wait();
                Main.BGWorker.isEBA = false;
                this.Close();
            }
        }
        private void Browser_KeyDown(object sender, KeyEventArgs e)
        {
            if (isMax && e.KeyData == Keys.F5)
                browser.Reload(true);
        }
        private void FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            browser.ExecuteScriptAsync("document.getElementById('tckn').value='" + TCKN + "'");
            browser.ExecuteScriptAsync("document.getElementById('password').value='" + Pass + "'");
            browser.ExecuteScriptAsync("document.getElementsByClassName('nl-form-send-btn')[0].click()");
            browser.ExecuteScriptAsync("if (document.getElementById('joinMeeting') != null) document.getElementById('joinMeeting').click()");
            browser.ExecuteScriptAsync("document.getElementById('join').click()");
        }
        public class CefHandler : RequestHandler
        {
            public Form Main { get; set; }
            public CefHandler(Form form) { Main = form; }
            protected override bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
            {
                if (request.Url.StartsWith("ebazoom") || request.Url.StartsWith("zoommtg"))
                {
                    Debug.WriteLine("EBA Linki: " + request.Url);
                    Utils.MainClass.EBALink = request.Url;
                    Process.Start(request.Url);
                    Main.Close();
                }
                return base.OnBeforeBrowse(chromiumWebBrowser, browser, frame, request, userGesture, isRedirect);
            }
        }
    }
}
