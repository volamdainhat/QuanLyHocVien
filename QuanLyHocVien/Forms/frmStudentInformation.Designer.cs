namespace QuanLyHocVien.Forms
{
    partial class frmStudentInformation
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
            picAvatar = new PictureBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            label2 = new Label();
            cbGender = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // picAvatar
            // 
            picAvatar.Location = new Point(6, 41);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(160, 240);
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(178, 12);
            label1.Name = "label1";
            label1.Size = new Size(0, 38);
            label1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbGender);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(picAvatar);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1234, 384);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÔNG TIN HỌC VIÊN";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(267, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 31);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(172, 41);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 3;
            label2.Text = "Họ và tên";
            // 
            // cbGender
            // 
            cbGender.AutoSize = true;
            cbGender.Location = new Point(573, 41);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(76, 29);
            cbGender.TabIndex = 5;
            cbGender.Text = "Nam";
            cbGender.UseVisualStyleBackColor = true;
            // 
            // frmStudentInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "frmStudentInformation";
            Text = "frmStudentInformation";
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picAvatar;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private Label label2;
        private CheckBox cbGender;
    }
}