
namespace ZoomAutoRecorder
{
    partial class AdditionalProgram
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
            this.lvLessons = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEBA = new System.Windows.Forms.CheckBox();
            this.cLessons = new System.Windows.Forms.ComboBox();
            this.chkRecord = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lvLessons
            // 
            this.lvLessons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2});
            this.lvLessons.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvLessons.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvLessons.FullRowSelect = true;
            this.lvLessons.HideSelection = false;
            this.lvLessons.Location = new System.Drawing.Point(0, 0);
            this.lvLessons.MultiSelect = false;
            this.lvLessons.Name = "lvLessons";
            this.lvLessons.Size = new System.Drawing.Size(614, 219);
            this.lvLessons.TabIndex = 0;
            this.lvLessons.UseCompatibleStateImageBehavior = false;
            this.lvLessons.View = System.Windows.Forms.View.Details;
            this.lvLessons.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvLessons_MouseClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "İsim";
            this.columnHeader1.Width = 307;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Zaman";
            this.columnHeader2.Width = 300;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Location = new System.Drawing.Point(170, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 47);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Teal;
            this.btnRefresh.Location = new System.Drawing.Point(462, 323);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 47);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.btnDelete.Location = new System.Drawing.Point(316, 323);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 47);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdd.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnAdd.Location = new System.Drawing.Point(12, 323);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(154, 47);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Toplantı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(27, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "Zaman:";
            // 
            // chkEBA
            // 
            this.chkEBA.AutoSize = true;
            this.chkEBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkEBA.Location = new System.Drawing.Point(488, 231);
            this.chkEBA.Name = "chkEBA";
            this.chkEBA.Size = new System.Drawing.Size(86, 33);
            this.chkEBA.TabIndex = 21;
            this.chkEBA.Text = "EBA";
            this.chkEBA.UseVisualStyleBackColor = true;
            // 
            // cLessons
            // 
            this.cLessons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cLessons.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cLessons.FormattingEnabled = true;
            this.cLessons.Location = new System.Drawing.Point(125, 231);
            this.cLessons.Name = "cLessons";
            this.cLessons.Size = new System.Drawing.Size(220, 37);
            this.cLessons.TabIndex = 22;
            // 
            // chkRecord
            // 
            this.chkRecord.AutoSize = true;
            this.chkRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkRecord.Location = new System.Drawing.Point(488, 275);
            this.chkRecord.Name = "chkRecord";
            this.chkRecord.Size = new System.Drawing.Size(114, 33);
            this.chkRecord.TabIndex = 23;
            this.chkRecord.Text = "Kaydet";
            this.chkRecord.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH.mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(125, 274);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(220, 36);
            this.dateTimePicker1.TabIndex = 24;
            // 
            // AdditionalProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 381);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.chkRecord);
            this.Controls.Add(this.cLessons);
            this.Controls.Add(this.chkEBA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvLessons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdditionalProgram";
            this.Text = "Ek Toplantılar";
            this.Load += new System.EventHandler(this.AdditionalProgram_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvLessons;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEBA;
        private System.Windows.Forms.ComboBox cLessons;
        private System.Windows.Forms.CheckBox chkRecord;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}