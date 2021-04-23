using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomAutoRecorder
{
    public partial class Secret : Form
    {
        public Secret()
        {
            InitializeComponent();
        }

        private void Secret_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu kısım EBA için gereklidir. Eğer EBA moduna ihtiyaç duymuyorsanız bu kutucukları boş bırakın.\n\nÖnemli: Kesinlikle ama kesinlikle TC ve şifrenizi kullanmıyoruz, burayı doldurmak size bağlıdır. Bilgileriniz şifrelenerek kaydedilecektir.", "UYARI", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Cancel) (sender as Secret).Close();
            try
            {
                txtTC.Text = Encryption.Decrypt(Properties.Settings.Default.TCKNPASS.Split('#')[0]);
                txtPass.Text = Encryption.Decrypt(Properties.Settings.Default.TCKNPASS.Split('#')[1]);
            }
            catch (Exception)
            {
                txtTC.Clear();
                txtPass.Clear();
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTC.Text) && !string.IsNullOrWhiteSpace(txtPass.Text))
            {
                try
                {
                    Convert.ToInt64(txtTC.Text);
                }
                catch (Exception)
                {
                    Main.ShowError("Lütfen TC'nizi düzgün formatta girin.");
                    return;
                }
                string tckn = Encryption.Encrypt(txtTC.Text);
                string pass = Encryption.Encrypt(txtPass.Text).Replace(" ", "");
                Properties.Settings.Default.TCKNPASS = tckn + "#" + pass;
                Properties.Settings.Default.Save();
                this.Close();
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TCKNPASS = null;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
