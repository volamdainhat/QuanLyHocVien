namespace StudentManagement
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
            label1 = new Label();
            btnTrainee = new Button();
            button3 = new Button();
            btnClass = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(64, 160);
            label1.Name = "label1";
            label1.Size = new Size(874, 74);
            label1.TabIndex = 4;
            label1.Text = "ỨNG DỤNG QUẢN LÝ HỌC VIÊN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnTrainee
            // 
            btnTrainee.BackColor = Color.Gold;
            btnTrainee.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnTrainee.Image = (Image)resources.GetObject("btnTrainee.Image");
            btnTrainee.Location = new Point(50, 281);
            btnTrainee.Name = "btnTrainee";
            btnTrainee.Size = new Size(207, 151);
            btnTrainee.TabIndex = 5;
            btnTrainee.Text = "Hoc viên";
            btnTrainee.TextAlign = ContentAlignment.BottomCenter;
            btnTrainee.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTrainee.UseVisualStyleBackColor = false;
            btnTrainee.Click += btnTrainee_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.OrangeRed;
            button3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            button3.Location = new Point(746, 281);
            button3.Name = "button3";
            button3.Size = new Size(207, 151);
            button3.TabIndex = 7;
            button3.Text = "Khóa học";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.TextImageRelation = TextImageRelation.ImageAboveText;
            button3.UseVisualStyleBackColor = false;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.Tomato;
            btnClass.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnClass.Image = (Image)resources.GetObject("btnClass.Image");
            btnClass.Location = new Point(398, 281);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(207, 151);
            btnClass.TabIndex = 6;
            btnClass.Text = "Lớp";
            btnClass.TextAlign = ContentAlignment.BottomCenter;
            btnClass.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClass.UseVisualStyleBackColor = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 712);
            Controls.Add(btnTrainee);
            Controls.Add(button3);
            Controls.Add(btnClass);
            Controls.Add(label1);
            Name = "FrmMain";
            Text = "FrmMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnTrainee;
        private Button button3;
        private Button btnClass;
    }
}