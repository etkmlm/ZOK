
namespace ZoomAutoRecorder
{
    partial class SetProgram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetProgram));
            this.label1 = new System.Windows.Forms.Label();
            this.nudLessonNumber = new System.Windows.Forms.NumericUpDown();
            this.lbPeriods = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudLessonNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Günlük Ders Sayısı:";
            // 
            // nudLessonNumber
            // 
            this.nudLessonNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nudLessonNumber.Location = new System.Drawing.Point(258, 12);
            this.nudLessonNumber.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudLessonNumber.Name = "nudLessonNumber";
            this.nudLessonNumber.Size = new System.Drawing.Size(266, 36);
            this.nudLessonNumber.TabIndex = 1;
            this.nudLessonNumber.ValueChanged += new System.EventHandler(this.nudLessonNumber_ValueChanged);
            // 
            // lbPeriods
            // 
            this.lbPeriods.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbPeriods.FormattingEnabled = true;
            this.lbPeriods.ItemHeight = 26;
            this.lbPeriods.Location = new System.Drawing.Point(12, 54);
            this.lbPeriods.Name = "lbPeriods";
            this.lbPeriods.Size = new System.Drawing.Size(512, 134);
            this.lbPeriods.TabIndex = 4;
            this.lbPeriods.SelectedIndexChanged += new System.EventHandler(this.lbPeriods_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Location = new System.Drawing.Point(12, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(512, 44);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "KAYDET";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH.mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(395, 194);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 36);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // SetProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 292);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbPeriods);
            this.Controls.Add(this.nudLessonNumber);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetProgram";
            this.Text = "Ders Programı Ayarları";
            this.Load += new System.EventHandler(this.SetProgram_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudLessonNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudLessonNumber;
        private System.Windows.Forms.ListBox lbPeriods;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}