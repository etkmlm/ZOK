
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkOto = new System.Windows.Forms.CheckBox();
            this.btnEBA = new System.Windows.Forms.Button();
            this.chkKaydet = new System.Windows.Forms.CheckBox();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.chkOtoMod = new System.Windows.Forms.CheckBox();
            this.lblD = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.comboDelay = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKayit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
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
            this.label2.ForeColor = System.Drawing.Color.Tomato;
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
            this.lblDZA.ForeColor = System.Drawing.Color.Tomato;
            this.lblDZA.Location = new System.Drawing.Point(12, 341);
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
            this.nudDers.Location = new System.Drawing.Point(109, 339);
            this.nudDers.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudDers.Name = "nudDers";
            this.nudDers.Size = new System.Drawing.Size(145, 36);
            this.nudDers.TabIndex = 7;
            // 
            // lblKZA
            // 
            this.lblKZA.AutoSize = true;
            this.lblKZA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKZA.ForeColor = System.Drawing.Color.Tomato;
            this.lblKZA.Location = new System.Drawing.Point(13, 383);
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
            this.nudKayit.Location = new System.Drawing.Point(109, 381);
            this.nudKayit.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudKayit.Name = "nudKayit";
            this.nudKayit.Size = new System.Drawing.Size(145, 36);
            this.nudKayit.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnSave.Location = new System.Drawing.Point(16, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(182, 52);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDefault.ForeColor = System.Drawing.Color.Turquoise;
            this.btnDefault.Location = new System.Drawing.Point(16, 150);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(182, 52);
            this.btnDefault.TabIndex = 11;
            this.btnDefault.Text = "Varsayılan";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
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
            this.chkOto.Location = new System.Drawing.Point(278, 160);
            this.chkOto.Name = "chkOto";
            this.chkOto.Size = new System.Drawing.Size(266, 33);
            this.chkOto.TabIndex = 15;
            this.chkOto.Text = "Dersi Otomatik Başlat";
            this.chkOto.UseVisualStyleBackColor = true;
            this.chkOto.CheckedChanged += new System.EventHandler(this.chkOto_CheckedChanged);
            // 
            // btnEBA
            // 
            this.btnEBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEBA.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnEBA.Location = new System.Drawing.Point(16, 113);
            this.btnEBA.Name = "btnEBA";
            this.btnEBA.Size = new System.Drawing.Size(182, 32);
            this.btnEBA.TabIndex = 17;
            this.btnEBA.Text = "EBA";
            this.btnEBA.UseVisualStyleBackColor = true;
            this.btnEBA.Click += new System.EventHandler(this.btnEBA_Click);
            // 
            // chkKaydet
            // 
            this.chkKaydet.AutoSize = true;
            this.chkKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkKaydet.Location = new System.Drawing.Point(278, 238);
            this.chkKaydet.Name = "chkKaydet";
            this.chkKaydet.Size = new System.Drawing.Size(172, 33);
            this.chkKaydet.TabIndex = 18;
            this.chkKaydet.Text = "Dersi Kaydet";
            this.chkKaydet.UseVisualStyleBackColor = true;
            this.chkKaydet.CheckedChanged += new System.EventHandler(this.chkKaydet_CheckedChanged);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdvanced.ForeColor = System.Drawing.Color.Teal;
            this.btnAdvanced.Location = new System.Drawing.Point(16, 208);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(182, 52);
            this.btnAdvanced.TabIndex = 19;
            this.btnAdvanced.Text = "Gelişmiş";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // chkOtoMod
            // 
            this.chkOtoMod.AutoSize = true;
            this.chkOtoMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkOtoMod.Location = new System.Drawing.Point(278, 199);
            this.chkOtoMod.Name = "chkOtoMod";
            this.chkOtoMod.Size = new System.Drawing.Size(128, 33);
            this.chkOtoMod.TabIndex = 20;
            this.chkOtoMod.Text = "Oto Mod";
            this.chkOtoMod.UseVisualStyleBackColor = true;
            // 
            // lblD
            // 
            this.lblD.AutoSize = true;
            this.lblD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblD.ForeColor = System.Drawing.Color.Tomato;
            this.lblD.Location = new System.Drawing.Point(265, 341);
            this.lblD.Name = "lblD";
            this.lblD.Size = new System.Drawing.Size(38, 29);
            this.lblD.TabIndex = 21;
            this.lblD.Text = "D:";
            // 
            // nudDelay
            // 
            this.nudDelay.Enabled = false;
            this.nudDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudDelay.Location = new System.Drawing.Point(401, 380);
            this.nudDelay.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(159, 36);
            this.nudDelay.TabIndex = 22;
            // 
            // comboDelay
            // 
            this.comboDelay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboDelay.FormattingEnabled = true;
            this.comboDelay.Items.AddRange(new object[] {
            "Normal (50 saniye)",
            "Hızlı (25 saniye)",
            "Çok Hızlı (10 saniye)",
            "Eş Zamanlı (0 saniye)",
            "Gelişmiş"});
            this.comboDelay.Location = new System.Drawing.Point(309, 339);
            this.comboDelay.Name = "comboDelay";
            this.comboDelay.Size = new System.Drawing.Size(251, 34);
            this.comboDelay.TabIndex = 23;
            this.comboDelay.SelectedIndexChanged += new System.EventHandler(this.comboDelay_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 428);
            this.Controls.Add(this.comboDelay);
            this.Controls.Add(this.nudDelay);
            this.Controls.Add(this.lblD);
            this.Controls.Add(this.chkOtoMod);
            this.Controls.Add(this.btnAdvanced);
            this.Controls.Add(this.chkKaydet);
            this.Controls.Add(this.btnEBA);
            this.Controls.Add(this.chkOto);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnSave);
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
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkOto;
        private System.Windows.Forms.Button btnEBA;
        private System.Windows.Forms.CheckBox chkKaydet;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.CheckBox chkOtoMod;
        private System.Windows.Forms.Label lblD;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.ComboBox comboDelay;
    }
}