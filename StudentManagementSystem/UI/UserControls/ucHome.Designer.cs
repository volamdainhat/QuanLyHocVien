namespace StudentManagementSystem.UI.Forms
{
    partial class ucHome
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucHome));
            tableLayoutPanel1 = new TableLayoutPanel();
            btnTrainee = new Button();
            btnClass = new Button();
            btnTimetable = new Button();
            lblTitle = new Label();
            button1 = new Button();
            button2 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9999962F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            tableLayoutPanel1.Controls.Add(btnTrainee, 1, 1);
            tableLayoutPanel1.Controls.Add(btnClass, 3, 1);
            tableLayoutPanel1.Controls.Add(btnTimetable, 5, 1);
            tableLayoutPanel1.Controls.Add(button1, 1, 3);
            tableLayoutPanel1.Controls.Add(button2, 5, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 207);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1280, 513);
            tableLayoutPanel1.TabIndex = 16;
            // 
            // btnTrainee
            // 
            btnTrainee.BackColor = Color.Tomato;
            btnTrainee.Dock = DockStyle.Fill;
            btnTrainee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnTrainee.Image = (Image)resources.GetObject("btnTrainee.Image");
            btnTrainee.Location = new Point(142, 103);
            btnTrainee.Name = "btnTrainee";
            btnTrainee.Size = new Size(294, 144);
            btnTrainee.TabIndex = 4;
            btnTrainee.Text = "Hoc viên";
            btnTrainee.TextAlign = ContentAlignment.BottomCenter;
            btnTrainee.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTrainee.UseVisualStyleBackColor = false;
            btnTrainee.Click += btnTrainee_Click;
            btnTrainee.MouseLeave += btnTrainee_MouseLeave;
            btnTrainee.MouseHover += btnTrainee_MouseHover;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.Tomato;
            btnClass.Dock = DockStyle.Fill;
            btnClass.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClass.Image = (Image)resources.GetObject("btnClass.Image");
            btnClass.Location = new Point(492, 103);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(294, 144);
            btnClass.TabIndex = 5;
            btnClass.Text = "Lớp học";
            btnClass.TextAlign = ContentAlignment.BottomCenter;
            btnClass.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClass.UseVisualStyleBackColor = false;
            btnClass.Click += btnClass_Click;
            btnClass.MouseLeave += btnClass_MouseLeave;
            btnClass.MouseHover += btnClass_MouseHover;
            // 
            // btnTimetable
            // 
            btnTimetable.BackColor = Color.OrangeRed;
            btnTimetable.Dock = DockStyle.Fill;
            btnTimetable.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnTimetable.Image = (Image)resources.GetObject("btnTimetable.Image");
            btnTimetable.Location = new Point(842, 103);
            btnTimetable.Name = "btnTimetable";
            btnTimetable.Size = new Size(294, 144);
            btnTimetable.TabIndex = 6;
            btnTimetable.Text = "Thời khóa biểu";
            btnTimetable.TextAlign = ContentAlignment.BottomCenter;
            btnTimetable.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTimetable.UseVisualStyleBackColor = false;
            btnTimetable.Click += btnTimetable_Click;
            btnTimetable.MouseLeave += btnTimetable_MouseLeave;
            btnTimetable.MouseHover += btnTimetable_MouseHover;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Crimson;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 100, 0, 0);
            lblTitle.Size = new Size(1280, 207);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "ỨNG DỤNG QUẢN LÝ HỌC VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.OrangeRed;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(142, 353);
            button1.Name = "button1";
            button1.Size = new Size(294, 144);
            button1.TabIndex = 7;
            button1.Text = "Chấp hành kỷ luật";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.TextImageRelation = TextImageRelation.ImageAboveText;
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.OrangeRed;
            button2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(842, 353);
            button2.Name = "button2";
            button2.Size = new Size(294, 144);
            button2.TabIndex = 8;
            button2.Text = "Báo cáo";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.TextImageRelation = TextImageRelation.ImageAboveText;
            button2.UseVisualStyleBackColor = false;
            // 
            // ucHome
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblTitle);
            Name = "ucHome";
            Size = new Size(1280, 720);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnTrainee;
        private Button btnClass;
        private Button btnTimetable;
        private Label lblTitle;
        private Button button1;
        private Button button2;
    }
}
