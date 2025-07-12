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
            lbFullName = new Label();
            textBox1 = new TextBox();
            grbGender = new GroupBox();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            lbBirthday = new Label();
            dtpBirthday = new DateTimePicker();
            lbBirthplace = new Label();
            textBox2 = new TextBox();
            lbPosition = new Label();
            txtPosition = new TextBox();
            grbGender.SuspendLayout();
            SuspendLayout();
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.Location = new Point(12, 18);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(89, 25);
            lbFullName.TabIndex = 0;
            lbFullName.Text = "Họ và tên";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 31);
            textBox1.TabIndex = 1;
            // 
            // grbGender
            // 
            grbGender.Controls.Add(rbFemale);
            grbGender.Controls.Add(rbMale);
            grbGender.Location = new Point(318, 18);
            grbGender.Name = "grbGender";
            grbGender.Size = new Size(300, 71);
            grbGender.TabIndex = 3;
            grbGender.TabStop = false;
            grbGender.Text = "Giới tính";
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(6, 30);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(75, 29);
            rbMale.TabIndex = 0;
            rbMale.TabStop = true;
            rbMale.Text = "Nam";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(99, 30);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(61, 29);
            rbFemale.TabIndex = 1;
            rbFemale.TabStop = true;
            rbFemale.Text = "Nữ";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.Location = new Point(12, 80);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(91, 25);
            lbBirthday.TabIndex = 4;
            lbBirthday.Text = "Ngày sinh";
            // 
            // dtpBirthday
            // 
            dtpBirthday.Location = new Point(12, 108);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(300, 31);
            dtpBirthday.TabIndex = 5;
            // 
            // lbBirthplace
            // 
            lbBirthplace.AutoSize = true;
            lbBirthplace.Location = new Point(12, 142);
            lbBirthplace.Name = "lbBirthplace";
            lbBirthplace.Size = new Size(77, 25);
            lbBirthplace.TabIndex = 6;
            lbBirthplace.Text = "Nơi sinh";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 170);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 31);
            textBox2.TabIndex = 7;
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Location = new Point(12, 204);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(76, 25);
            lbPosition.TabIndex = 8;
            lbPosition.Text = "Chức vụ";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(12, 232);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(300, 31);
            txtPosition.TabIndex = 9;
            // 
            // frmStudentInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(txtPosition);
            Controls.Add(lbPosition);
            Controls.Add(textBox2);
            Controls.Add(lbBirthplace);
            Controls.Add(dtpBirthday);
            Controls.Add(lbBirthday);
            Controls.Add(grbGender);
            Controls.Add(textBox1);
            Controls.Add(lbFullName);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmStudentInformation";
            Text = "frmStudentInformation";
            grbGender.ResumeLayout(false);
            grbGender.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbFullName;
        private TextBox textBox1;
        private GroupBox grbGender;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private Label lbBirthday;
        private DateTimePicker dtpBirthday;
        private Label lbBirthplace;
        private TextBox textBox2;
        private Label lbPosition;
        private TextBox txtPosition;
    }
}