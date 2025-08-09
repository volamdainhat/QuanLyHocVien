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
            btnCourse = new Button();
            lblTitle = new Label();
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
            tableLayoutPanel1.Controls.Add(btnCourse, 5, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 206);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1280, 514);
            tableLayoutPanel1.TabIndex = 16;
            // 
            // btnTrainee
            // 
            btnTrainee.BackColor = Color.Gold;
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
            // 
            // btnCourse
            // 
            btnCourse.BackColor = Color.OrangeRed;
            btnCourse.Dock = DockStyle.Fill;
            btnCourse.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCourse.Image = (Image)resources.GetObject("btnCourse.Image");
            btnCourse.Location = new Point(842, 103);
            btnCourse.Name = "btnCourse";
            btnCourse.Size = new Size(294, 144);
            btnCourse.TabIndex = 6;
            btnCourse.Text = "Khóa học";
            btnCourse.TextAlign = ContentAlignment.BottomCenter;
            btnCourse.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCourse.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 40F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Crimson;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 100, 0, 0);
            lblTitle.Size = new Size(1255, 206);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "ỨNG DỤNG QUẢN LÝ HỌC VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnTrainee;
        private Button btnClass;
        private Button btnCourse;
        private Label lblTitle;
    }
}
