namespace QuanLyHocVien
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            btnTrainee = new Button();
            btnClass = new Button();
            btnCourse = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // btnTrainee
            // 
            btnTrainee.BackColor = Color.Gold;
            btnTrainee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnTrainee.Image = (Image)resources.GetObject("btnTrainee.Image");
            btnTrainee.Location = new Point(177, 328);
            btnTrainee.Name = "btnTrainee";
            btnTrainee.Size = new Size(207, 151);
            btnTrainee.TabIndex = 0;
            btnTrainee.Text = "Hoc viên";
            btnTrainee.TextAlign = ContentAlignment.BottomCenter;
            btnTrainee.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTrainee.UseVisualStyleBackColor = false;
            btnTrainee.Click += this.btnTrainee_Click;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.Tomato;
            btnClass.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClass.Image = (Image)resources.GetObject("btnClass.Image");
            btnClass.Location = new Point(525, 328);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(207, 151);
            btnClass.TabIndex = 1;
            btnClass.Text = "Lớp";
            btnClass.TextAlign = ContentAlignment.BottomCenter;
            btnClass.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClass.UseVisualStyleBackColor = false;
            // 
            // btnCourse
            // 
            btnCourse.BackColor = Color.OrangeRed;
            btnCourse.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCourse.Image = (Image)resources.GetObject("btnCourse.Image");
            btnCourse.Location = new Point(873, 328);
            btnCourse.Name = "btnCourse";
            btnCourse.Size = new Size(207, 151);
            btnCourse.TabIndex = 2;
            btnCourse.Text = "Khóa học";
            btnCourse.TextAlign = ContentAlignment.BottomCenter;
            btnCourse.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCourse.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Crimson;
            lblTitle.Location = new Point(56, 148);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1130, 96);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "ỨNG DỤNG QUẢN LÝ HỌC VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1258, 664);
            Controls.Add(btnTrainee);
            Controls.Add(btnCourse);
            Controls.Add(lblTitle);
            Controls.Add(btnClass);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý học viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTrainee;
        private Button btnClass;
        private Button btnCourse;
        private Label lblTitle;
    }
}