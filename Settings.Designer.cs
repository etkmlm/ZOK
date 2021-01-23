
namespace ZoomAutoRecorder
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.txtZoomPath = new System.Windows.Forms.TextBox();
            this.btnZoom = new System.Windows.Forms.Button();
            this.btnOBS = new System.Windows.Forms.Button();
            this.txtOBSPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDZA = new System.Windows.Forms.Label();
            this.nudDers = new System.Windows.Forms.NumericUpDown();
            this.lblKZA = new System.Windows.Forms.Label();
            this.nudKayit = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkOto = new System.Windows.Forms.CheckBox();
            this.btnSecret = new System.Windows.Forms.Button();
            this.chkKaydet = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKayit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoom Yolu:";
            // 
            // txtZoomPath
            // 
            this.txtZoomPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtZoomPath.Location = new System.Drawing.Point(159, 12);
            this.txtZoomPath.Name = "txtZoomPath";
            this.txtZoomPath.Size = new System.Drawing.Size(333, 36);
            this.txtZoomPath.TabIndex = 1;
            // 
            // btnZoom
            // 
            this.btnZoom.Location = new System.Drawing.Point(498, 12);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(62, 36);
            this.btnZoom.TabIndex = 2;
            this.btnZoom.Text = "...";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // btnOBS
            // 
            this.btnOBS.Location = new System.Drawing.Point(498, 54);
            this.btnOBS.Name = "btnOBS";
            this.btnOBS.Size = new System.Drawing.Size(62, 36);
            this.btnOBS.TabIndex = 5;
            this.btnOBS.Text = "...";
            this.btnOBS.UseVisualStyleBackColor = true;
            this.btnOBS.Click += new System.EventHandler(this.btnOBS_Click);
            // 
            // txtOBSPath
            // 
            this.txtOBSPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOBSPath.Location = new System.Drawing.Point(159, 54);
            this.txtOBSPath.Name = "txtOBSPath";
            this.txtOBSPath.Size = new System.Drawing.Size(333, 36);
            this.txtOBSPath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(23, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "OBS Yolu:";
            // 
            // lblDZA
            // 
            this.lblDZA.AutoSize = true;
            this.lblDZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDZA.Location = new System.Drawing.Point(62, 98);
            this.lblDZA.Name = "lblDZA";
            this.lblDZA.Size = new System.Drawing.Size(91, 29);
            this.lblDZA.TabIndex = 6;
            this.lblDZA.Text = "D.Z.A.:";
            // 
            // nudDers
            // 
            this.nudDers.DecimalPlaces = 1;
            this.nudDers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudDers.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDers.Location = new System.Drawing.Point(159, 96);
            this.nudDers.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudDers.Name = "nudDers";
            this.nudDers.Size = new System.Drawing.Size(333, 36);
            this.nudDers.TabIndex = 7;
            // 
            // lblKZA
            // 
            this.lblKZA.AutoSize = true;
            this.lblKZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKZA.Location = new System.Drawing.Point(63, 140);
            this.lblKZA.Name = "lblKZA";
            this.lblKZA.Size = new System.Drawing.Size(90, 29);
            this.lblKZA.TabIndex = 8;
            this.lblKZA.Text = "K.Z.A.:";
            // 
            // nudKayit
            // 
            this.nudKayit.DecimalPlaces = 1;
            this.nudKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudKayit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudKayit.Location = new System.Drawing.Point(159, 138);
            this.nudKayit.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudKayit.Name = "nudKayit";
            this.nudKayit.Size = new System.Drawing.Size(333, 36);
            this.nudKayit.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(408, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 52);
            this.button1.TabIndex = 10;
            this.button1.Text = "KAYDET";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(12, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 52);
            this.button2.TabIndex = 11;
            this.button2.Text = "VARSAYILAN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Programlar|*.exe";
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Title = "Bir Yol Seçin";
            // 
            // chkOto
            // 
            this.chkOto.AutoSize = true;
            this.chkOto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkOto.Location = new System.Drawing.Point(294, 196);
            this.chkOto.Name = "chkOto";
            this.chkOto.Size = new System.Drawing.Size(266, 33);
            this.chkOto.TabIndex = 15;
            this.chkOto.Text = "Dersi Otomatik Başlat";
            this.chkOto.UseVisualStyleBackColor = true;
            // 
            // btnSecret
            // 
            this.btnSecret.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSecret.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSecret.Location = new System.Drawing.Point(12, 241);
            this.btnSecret.Name = "btnSecret";
            this.btnSecret.Size = new System.Drawing.Size(182, 32);
            this.btnSecret.TabIndex = 17;
            this.btnSecret.Text = "GİZLİ";
            this.btnSecret.UseVisualStyleBackColor = true;
            this.btnSecret.Click += new System.EventHandler(this.btnSecret_Click);
            // 
            // chkKaydet
            // 
            this.chkKaydet.AutoSize = true;
            this.chkKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkKaydet.Location = new System.Drawing.Point(388, 235);
            this.chkKaydet.Name = "chkKaydet";
            this.chkKaydet.Size = new System.Drawing.Size(172, 33);
            this.chkKaydet.TabIndex = 18;
            this.chkKaydet.Text = "Dersi Kaydet";
            this.chkKaydet.UseVisualStyleBackColor = true;
            this.chkKaydet.CheckedChanged += new System.EventHandler(this.chkKaydet_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 344);
            this.Controls.Add(this.chkKaydet);
            this.Controls.Add(this.btnSecret);
            this.Controls.Add(this.chkOto);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nudKayit);
            this.Controls.Add(this.lblKZA);
            this.Controls.Add(this.nudDers);
            this.Controls.Add(this.lblDZA);
            this.Controls.Add(this.btnOBS);
            this.Controls.Add(this.txtOBSPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnZoom);
            this.Controls.Add(this.txtZoomPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKayit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZoomPath;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.Button btnOBS;
        private System.Windows.Forms.TextBox txtOBSPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDZA;
        private System.Windows.Forms.NumericUpDown nudDers;
        private System.Windows.Forms.Label lblKZA;
        private System.Windows.Forms.NumericUpDown nudKayit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkOto;
        private System.Windows.Forms.Button btnSecret;
        private System.Windows.Forms.CheckBox chkKaydet;
    }
}