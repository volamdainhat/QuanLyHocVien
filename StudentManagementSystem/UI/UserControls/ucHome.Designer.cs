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
            btnMisconduct = new Button();
            btnReports = new Button();
            lblTitle = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.9999962F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 210F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0000076F));
            tableLayoutPanel1.Controls.Add(btnTrainee, 1, 1);
            tableLayoutPanel1.Controls.Add(btnClass, 3, 1);
            tableLayoutPanel1.Controls.Add(btnTimetable, 5, 1);
            tableLayoutPanel1.Controls.Add(btnMisconduct, 1, 3);
            tableLayoutPanel1.Controls.Add(btnReports, 5, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 124);
            tableLayoutPanel1.Margin = new Padding(2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(896, 308);
            tableLayoutPanel1.TabIndex = 16;
            // 
            // btnTrainee
            // 
            btnTrainee.BackColor = Color.Tomato;
            btnTrainee.Dock = DockStyle.Fill;
            btnTrainee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnTrainee.Image = (Image)resources.GetObject("btnTrainee.Image");
            btnTrainee.Location = new Point(99, 62);
            btnTrainee.Margin = new Padding(2);
            btnTrainee.Name = "btnTrainee";
            btnTrainee.Size = new Size(206, 86);
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
            btnClass.Location = new Point(344, 62);
            btnClass.Margin = new Padding(2);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(206, 86);
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
            btnTimetable.Location = new Point(589, 62);
            btnTimetable.Margin = new Padding(2);
            btnTimetable.Name = "btnTimetable";
            btnTimetable.Size = new Size(206, 86);
            btnTimetable.TabIndex = 6;
            btnTimetable.Text = "Thời khóa biểu";
            btnTimetable.TextAlign = ContentAlignment.BottomCenter;
            btnTimetable.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTimetable.UseVisualStyleBackColor = false;
            btnTimetable.Click += btnTimetable_Click;
            btnTimetable.MouseLeave += btnTimetable_MouseLeave;
            btnTimetable.MouseHover += btnTimetable_MouseHover;
            // 
            // btnMisconduct
            // 
            btnMisconduct.BackColor = Color.OrangeRed;
            btnMisconduct.Dock = DockStyle.Fill;
            btnMisconduct.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnMisconduct.Location = new Point(99, 212);
            btnMisconduct.Margin = new Padding(2);
            btnMisconduct.Name = "btnMisconduct";
            btnMisconduct.Size = new Size(206, 86);
            btnMisconduct.TabIndex = 7;
            btnMisconduct.Text = "Chấp hành kỷ luật";
            btnMisconduct.TextAlign = ContentAlignment.BottomCenter;
            btnMisconduct.TextImageRelation = TextImageRelation.ImageAboveText;
            btnMisconduct.UseVisualStyleBackColor = false;
            btnMisconduct.Click += btnMisconduct_Click;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.OrangeRed;
            btnReports.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnReports.Location = new Point(589, 212);
            btnReports.Margin = new Padding(2);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(206, 86);
            btnReports.TabIndex = 8;
            btnReports.Text = "Báo cáo";
            btnReports.TextAlign = ContentAlignment.BottomCenter;
            btnReports.TextImageRelation = TextImageRelation.ImageAboveText;
            btnReports.UseVisualStyleBackColor = false;
            btnReports.Click += btnReports_Click;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Crimson;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 60, 0, 0);
            lblTitle.Size = new Size(896, 124);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "ỨNG DỤNG QUẢN LÝ HỌC VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblTitle);
            Margin = new Padding(2);
            Name = "ucHome";
            Size = new Size(896, 432);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnTrainee;
        private Button btnClass;
        private Button btnTimetable;
        private Label lblTitle;
        private Button btnMisconduct;
        private Button btnReports;
    }
}
