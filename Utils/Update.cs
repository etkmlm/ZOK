using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

using Application = System.Windows.Forms.Application;

namespace ZoomAutoRecorder.Utils
{
    public class Update
    {
        Main Main => (Main)Application.OpenForms["Main"];
        ProgressBar Bar => Main.Controls.Find("barDownload", true)[0] as ProgressBar;
        public WebClient web;
        GitHubClient client;
        string path;
        
        public Update()
        {
            client = new GitHubClient(new ProductHeaderValue("zok"));
            web = new WebClient();
            web.DownloadProgressChanged += Web_DownloadProgressChanged;
            web.DownloadFileCompleted += Web_DownloadFileCompleted;
        }

        private void Web_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            string pth = Path.Combine(Application.StartupPath, "ZOKUpdater.exe");
            if (!File.Exists(pth))
            {
                Main.ShowError("Güncelleme aracı bulunamadı.");
                File.Delete(pth);
            }
            System.Diagnostics.Process.Start(pth);
            web.Dispose();
            Application.Exit();
        }
        private void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Bar.Value = e.ProgressPercentage;
        }
        public void CheckUpdate()
        {
            try
            {
                var rel = client.Repository.Release.GetAll("etkmlm", "zok").Result[0];
                double newerver = double.Parse(rel.TagName.Replace('.', ','));
                double nowver = double.Parse(MainClass.version.Replace('.', ','));
                if (nowver < newerver)
                {
                    DialogResult result = Main.ShowAsk(
                        $"Yeni bir güncelleme mevcut!\nKullandığınız Sürüm: {MainClass.version}\nYeni Sürüm: {rel.TagName}" + (rel.Prerelease ? "\nNot: Bu sürüm kararsızdır, en yeni güncellemeleri yüklemek istiyorsanız işaretleyin fakat sorunlar olabilir." : "")
                        , "GÜNCELLEME");
                    if (result == DialogResult.Yes)
                    {
                        var asset = rel.Assets.FirstOrDefault(x => x.Name == $"v{rel.TagName}e.zip");
                        if (asset == null) return;

                        path = Path.Combine(Application.StartupPath, "New.zip");
                        Bar.Visible = true;
                        DownloadFile(asset.BrowserDownloadUrl);
                    }
                }
                else if (nowver > newerver)
                    Main.ShowInfo(
                        $"Şu anda süper yeni bir sürüm kullanıyorsunuz!\nKullandığınız Sürüm: {MainClass.version}\nYayınlanan En Yeni Sürüm: {rel.TagName}"
                        , "GÜNCELLEME");
            }
            catch (Exception)
            {
                Main.ShowError("Güncellemeler kontrol edilirken bir sorun oluştu, lütfen daha sonra tekrar deneyin.", "HATA");
            }
        }
        private void DownloadFile(string download)
        {
            Uri uri = new Uri(download);
            web.DownloadFileAsync(uri, path);
        }

    }
}
