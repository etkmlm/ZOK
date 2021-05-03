
namespace ZoomAutoRecorder
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lbDersler = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLessons = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbPaz = new System.Windows.Forms.ListBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEBA = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProgDel = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOnce = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLessonInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartProgramLesson = new System.Windows.Forms.ToolStripMenuItem();
            this.lbCumt = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbPzt = new System.Windows.Forms.ListBox();
            this.lbCuma = new System.Windows.Forms.ListBox();
            this.lbPers = new System.Windows.Forms.ListBox();
            this.lbCars = new System.Windows.Forms.ListBox();
            this.lbSali = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProgramSettings = new System.Windows.Forms.Button();
            this.contextIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAppHS = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAppClose = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.barDownload = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAdditional = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.contextIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDersler
            // 
            this.lbDersler.AllowDrop = true;
            this.lbDersler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbDersler.FormattingEnabled = true;
            this.lbDersler.ItemHeight = 29;
            this.lbDersler.Location = new System.Drawing.Point(12, 49);
            this.lbDersler.Name = "lbDersler";
            this.lbDersler.Size = new System.Drawing.Size(218, 468);
            this.lbDersler.TabIndex = 0;
            this.lbDersler.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbDersler_MouseClick);
            this.lbDersler.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbDersler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbDersler_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Sienna;
            this.label1.Location = new System.Drawing.Point(33, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zoom Linkleri";
            // 
            // btnLessons
            // 
            this.btnLessons.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLessons.Location = new System.Drawing.Point(12, 527);
            this.btnLessons.Name = "btnLessons";
            this.btnLessons.Size = new System.Drawing.Size(218, 39);
            this.btnLessons.TabIndex = 2;
            this.btnLessons.Text = "Düzenle";
            this.btnLessons.UseVisualStyleBackColor = true;
            this.btnLessons.Click += new System.EventHandler(this.btnLessons_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSettings.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSettings.Location = new System.Drawing.Point(1126, 527);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(179, 39);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "Ayarlar";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Controls.Add(this.lbPaz, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCumt, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPzt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCuma, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbPers, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCars, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbSali, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(246, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.571428F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.42857F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1059, 468);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // lbPaz
            // 
            this.lbPaz.AllowDrop = true;
            this.lbPaz.BackColor = System.Drawing.SystemColors.Control;
            this.lbPaz.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPaz.ContextMenuStrip = this.contextMenu;
            this.lbPaz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbPaz.FormattingEnabled = true;
            this.lbPaz.ItemHeight = 25;
            this.lbPaz.Location = new System.Drawing.Point(910, 44);
            this.lbPaz.Name = "lbPaz";
            this.lbPaz.Size = new System.Drawing.Size(145, 420);
            this.lbPaz.TabIndex = 14;
            this.lbPaz.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.lbPaz.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbPaz.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbPaz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.lbPaz.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.lbPaz.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickLB);
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEBA,
            this.btnProgDel,
            this.btnOnce,
            this.btnLessonInfo,
            this.btnStartProgramLesson});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(210, 124);
            // 
            // btnEBA
            // 
            this.btnEBA.Name = "btnEBA";
            this.btnEBA.Size = new System.Drawing.Size(209, 24);
            this.btnEBA.Text = "EBA";
            this.btnEBA.Click += new System.EventHandler(this.btnEBA_Click);
            // 
            // btnProgDel
            // 
            this.btnProgDel.Name = "btnProgDel";
            this.btnProgDel.Size = new System.Drawing.Size(209, 24);
            this.btnProgDel.Text = "Sil";
            this.btnProgDel.Click += new System.EventHandler(this.btnProgDel_Click);
            // 
            // btnOnce
            // 
            this.btnOnce.Name = "btnOnce";
            this.btnOnce.Size = new System.Drawing.Size(209, 24);
            this.btnOnce.Text = "Bir Kereliğine Açma";
            this.btnOnce.Click += new System.EventHandler(this.btnOnce_Click);
            // 
            // btnLessonInfo
            // 
            this.btnLessonInfo.Name = "btnLessonInfo";
            this.btnLessonInfo.Size = new System.Drawing.Size(209, 24);
            this.btnLessonInfo.Text = "Bilgi";
            this.btnLessonInfo.Click += new System.EventHandler(this.btnLessonInfo_Click);
            // 
            // btnStartProgramLesson
            // 
            this.btnStartProgramLesson.Name = "btnStartProgramLesson";
            this.btnStartProgramLesson.Size = new System.Drawing.Size(209, 24);
            this.btnStartProgramLesson.Text = "Başlat";
            this.btnStartProgramLesson.Click += new System.EventHandler(this.btnStartProgramLesson_Click);
            // 
            // lbCumt
            // 
            this.lbCumt.AllowDrop = true;
            this.lbCumt.BackColor = System.Drawing.SystemColors.Control;
            this.lbCumt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCumt.ContextMenuStrip = this.contextMenu;
            this.lbCumt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCumt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbCumt.FormattingEnabled = true;
            this.lbCumt.ItemHeight = 25;
            this.lbCumt.Location = new System.Drawing.Point(759, 44);
            this.lbCumt.Name = "lbCumt";
            this.lbCumt.Size = new System.Drawing.Size(144, 420);
            this.lbCumt.TabIndex = 13;
            this.lbCumt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.lbCumt.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbCumt.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbCumt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.lbCumt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.lbCumt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickLB);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(910, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 39);
            this.label8.TabIndex = 12;
            this.label8.Text = "Pazar";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(759, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 39);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cumartesi";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPzt
            // 
            this.lbPzt.AllowDrop = true;
            this.lbPzt.BackColor = System.Drawing.SystemColors.Control;
            this.lbPzt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPzt.ContextMenuStrip = this.contextMenu;
            this.lbPzt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPzt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbPzt.FormattingEnabled = true;
            this.lbPzt.ItemHeight = 25;
            this.lbPzt.Location = new System.Drawing.Point(4, 44);
            this.lbPzt.Name = "lbPzt";
            this.lbPzt.Size = new System.Drawing.Size(144, 420);
            this.lbPzt.TabIndex = 10;
            this.lbPzt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.lbPzt.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbPzt.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbPzt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.lbPzt.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.lbPzt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickLB);
            // 
            // lbCuma
            // 
            this.lbCuma.AllowDrop = true;
            this.lbCuma.BackColor = System.Drawing.SystemColors.Control;
            this.lbCuma.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCuma.ContextMenuStrip = this.contextMenu;
            this.lbCuma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbCuma.FormattingEnabled = true;
            this.lbCuma.ItemHeight = 25;
            this.lbCuma.Location = new System.Drawing.Point(608, 44);
            this.lbCuma.Name = "lbCuma";
            this.lbCuma.Size = new System.Drawing.Size(144, 420);
            this.lbCuma.TabIndex = 9;
            this.lbCuma.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.lbCuma.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbCuma.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbCuma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.lbCuma.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.lbCuma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickLB);
            // 
            // lbPers
            // 
            this.lbPers.AllowDrop = true;
            this.lbPers.BackColor = System.Drawing.SystemColors.Control;
            this.lbPers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPers.ContextMenuStrip = this.contextMenu;
            this.lbPers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbPers.FormattingEnabled = true;
            this.lbPers.ItemHeight = 25;
            this.lbPers.Location = new System.Drawing.Point(457, 44);
            this.lbPers.Name = "lbPers";
            this.lbPers.Size = new System.Drawing.Size(144, 420);
            this.lbPers.TabIndex = 8;
            this.lbPers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.lbPers.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbPers.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbPers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.lbPers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.lbPers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickLB);
            // 
            // lbCars
            // 
            this.lbCars.AllowDrop = true;
            this.lbCars.BackColor = System.Drawing.SystemColors.Control;
            this.lbCars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCars.ContextMenuStrip = this.contextMenu;
            this.lbCars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbCars.FormattingEnabled = true;
            this.lbCars.ItemHeight = 25;
            this.lbCars.Location = new System.Drawing.Point(306, 44);
            this.lbCars.Name = "lbCars";
            this.lbCars.Size = new System.Drawing.Size(144, 420);
            this.lbCars.TabIndex = 7;
            this.lbCars.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.lbCars.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbCars.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbCars.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.lbCars.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.lbCars.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickLB);
            // 
            // lbSali
            // 
            this.lbSali.AllowDrop = true;
            this.lbSali.BackColor = System.Drawing.SystemColors.Control;
            this.lbSali.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSali.ContextMenuStrip = this.contextMenu;
            this.lbSali.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSali.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSali.FormattingEnabled = true;
            this.lbSali.ItemHeight = 25;
            this.lbSali.Location = new System.Drawing.Point(155, 44);
            this.lbSali.Name = "lbSali";
            this.lbSali.Size = new System.Drawing.Size(144, 420);
            this.lbSali.TabIndex = 6;
            this.lbSali.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick);
            this.lbSali.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.lbSali.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.lbSali.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.lbSali.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnDoubleClick);
            this.lbSali.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnClickLB);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(608, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 39);
            this.label6.TabIndex = 4;
            this.label6.Text = "Cuma";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(457, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 39);
            this.label5.TabIndex = 3;
            this.label5.Text = "Perşembe";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(306, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 39);
            this.label4.TabIndex = 2;
            this.label4.Text = "Çarşamba";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(155, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "Salı";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(4, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pazartesi";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnProgramSettings
            // 
            this.btnProgramSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProgramSettings.Location = new System.Drawing.Point(1222, 4);
            this.btnProgramSettings.Name = "btnProgramSettings";
            this.btnProgramSettings.Size = new System.Drawing.Size(83, 39);
            this.btnProgramSettings.TabIndex = 5;
            this.btnProgramSettings.Text = "P.A.";
            this.btnProgramSettings.UseVisualStyleBackColor = true;
            this.btnProgramSettings.Click += new System.EventHandler(this.btnProgramSettings_Click);
            // 
            // contextIcon
            // 
            this.contextIcon.BackColor = System.Drawing.Color.Teal;
            this.contextIcon.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAppHS,
            this.btnAutoZoom,
            this.toolStripSeparator1,
            this.btnAppClose});
            this.contextIcon.Name = "contextIcon";
            this.contextIcon.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextIcon.Size = new System.Drawing.Size(229, 82);
            // 
            // btnAppHS
            // 
            this.btnAppHS.ForeColor = System.Drawing.Color.White;
            this.btnAppHS.Name = "btnAppHS";
            this.btnAppHS.Size = new System.Drawing.Size(228, 24);
            this.btnAppHS.Text = "Programı Gizle";
            this.btnAppHS.Click += new System.EventHandler(this.btnAppHS_Click);
            // 
            // btnAutoZoom
            // 
            this.btnAutoZoom.ForeColor = System.Drawing.Color.White;
            this.btnAutoZoom.Name = "btnAutoZoom";
            this.btnAutoZoom.Size = new System.Drawing.Size(228, 24);
            this.btnAutoZoom.Text = "Otomatik Dersi Durdur";
            this.btnAutoZoom.Click += new System.EventHandler(this.btnAutoZoom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // btnAppClose
            // 
            this.btnAppClose.ForeColor = System.Drawing.Color.White;
            this.btnAppClose.Name = "btnAppClose";
            this.btnAppClose.Size = new System.Drawing.Size(228, 24);
            this.btnAppClose.Text = "Kapat";
            this.btnAppClose.Click += new System.EventHandler(this.btnAppClose_Click);
            // 
            // notify
            // 
            this.notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notify.ContextMenuStrip = this.contextIcon;
            this.notify.Icon = ((System.Drawing.Icon)(resources.GetObject("notify.Icon")));
            this.notify.Text = "Oto Zoom";
            this.notify.Visible = true;
            this.notify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseClick);
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAbout.Location = new System.Drawing.Point(941, 527);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(179, 39);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "Hakkında";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReset.Location = new System.Drawing.Point(1092, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(47, 39);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Y";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBrowser.Location = new System.Drawing.Point(990, 4);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(96, 39);
            this.btnBrowser.TabIndex = 8;
            this.btnBrowser.Text = "EBA";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // barDownload
            // 
            this.barDownload.Location = new System.Drawing.Point(826, 4);
            this.barDownload.Name = "barDownload";
            this.barDownload.Size = new System.Drawing.Size(158, 39);
            this.barDownload.TabIndex = 9;
            this.barDownload.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "ZOK Konfigürasyon Dosyası|*.zokcfg";
            // 
            // btnAdditional
            // 
            this.btnAdditional.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdditional.Location = new System.Drawing.Point(1145, 4);
            this.btnAdditional.Name = "btnAdditional";
            this.btnAdditional.Size = new System.Drawing.Size(71, 39);
            this.btnAdditional.TabIndex = 10;
            this.btnAdditional.Text = "EK";
            this.btnAdditional.UseVisualStyleBackColor = true;
            this.btnAdditional.Click += new System.EventHandler(this.btnAdditional_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 574);
            this.Controls.Add(this.btnAdditional);
            this.Controls.Add(this.barDownload);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnProgramSettings);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnLessons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDersler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Ana Sayfa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.contextIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDersler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLessons;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbCuma;
        private System.Windows.Forms.ListBox lbPers;
        private System.Windows.Forms.ListBox lbCars;
        private System.Windows.Forms.ListBox lbSali;
        private System.Windows.Forms.Button btnProgramSettings;
        private System.Windows.Forms.ListBox lbPzt;
        private System.Windows.Forms.ContextMenuStrip contextIcon;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ToolStripMenuItem btnAppHS;
        private System.Windows.Forms.ToolStripMenuItem btnAutoZoom;
        private System.Windows.Forms.ToolStripMenuItem btnAppClose;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem btnEBA;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.ListBox lbPaz;
        private System.Windows.Forms.ListBox lbCumt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem btnProgDel;
        private System.Windows.Forms.ToolStripMenuItem btnOnce;
        private System.Windows.Forms.ToolStripMenuItem btnLessonInfo;
        private System.Windows.Forms.ToolStripMenuItem btnStartProgramLesson;
        private System.Windows.Forms.ProgressBar barDownload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAdditional;
    }
}

