namespace QuanLyHocVien
{
    partial class frmStudentManagement
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
            txtFullName = new TextBox();
            txtPhoneNumber = new TextBox();
            lbPhoneNumber = new Label();
            lbClass = new Label();
            cbClass = new ComboBox();
            lbBirthday = new Label();
            dtpBirthday = new DateTimePicker();
            cbRank = new ComboBox();
            lbRank = new Label();
            comboBox1 = new ComboBox();
            lbPosition = new Label();
            dtpNhapNgu = new DateTimePicker();
            lbNhapNgu = new Label();
            SuspendLayout();
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.Location = new Point(12, 9);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(89, 25);
            lbFullName.TabIndex = 0;
            lbFullName.Text = "Họ và tên";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(12, 37);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(300, 31);
            txtFullName.TabIndex = 1;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(12, 99);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(300, 31);
            txtPhoneNumber.TabIndex = 3;
            txtPhoneNumber.TextChanged += txtPhoneNumber_TextChanged;
            // 
            // lbPhoneNumber
            // 
            lbPhoneNumber.AutoSize = true;
            lbPhoneNumber.Location = new Point(12, 71);
            lbPhoneNumber.Name = "lbPhoneNumber";
            lbPhoneNumber.Size = new Size(134, 25);
            lbPhoneNumber.TabIndex = 2;
            lbPhoneNumber.Text = "SĐT phụ huynh";
            // 
            // lbClass
            // 
            lbClass.AutoSize = true;
            lbClass.Location = new Point(318, 9);
            lbClass.Name = "lbClass";
            lbClass.Size = new Size(42, 25);
            lbClass.TabIndex = 4;
            lbClass.Text = "Lớp";
            // 
            // cbClass
            // 
            cbClass.FormattingEnabled = true;
            cbClass.Location = new Point(318, 35);
            cbClass.Name = "cbClass";
            cbClass.Size = new Size(300, 33);
            cbClass.TabIndex = 5;
            cbClass.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.Location = new Point(624, 9);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(91, 25);
            lbBirthday.TabIndex = 6;
            lbBirthday.Text = "Ngày sinh";
            // 
            // dtpBirthday
            // 
            dtpBirthday.Location = new Point(624, 37);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(300, 31);
            dtpBirthday.TabIndex = 7;
            // 
            // cbRank
            // 
            cbRank.FormattingEnabled = true;
            cbRank.Location = new Point(318, 97);
            cbRank.Name = "cbRank";
            cbRank.Size = new Size(300, 33);
            cbRank.TabIndex = 9;
            // 
            // lbRank
            // 
            lbRank.AutoSize = true;
            lbRank.Location = new Point(318, 71);
            lbRank.Name = "lbRank";
            lbRank.Size = new Size(76, 25);
            lbRank.TabIndex = 8;
            lbRank.Text = "Cấp bậc";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(624, 97);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(300, 33);
            comboBox1.TabIndex = 11;
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Location = new Point(624, 71);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(76, 25);
            lbPosition.TabIndex = 10;
            lbPosition.Text = "Chức vụ";
            // 
            // dtpNhapNgu
            // 
            dtpNhapNgu.Location = new Point(12, 161);
            dtpNhapNgu.Name = "dtpNhapNgu";
            dtpNhapNgu.Size = new Size(300, 31);
            dtpNhapNgu.TabIndex = 13;
            // 
            // lbNhapNgu
            // 
            lbNhapNgu.AutoSize = true;
            lbNhapNgu.Location = new Point(12, 133);
            lbNhapNgu.Name = "lbNhapNgu";
            lbNhapNgu.Size = new Size(17, 25);
            lbNhapNgu.TabIndex = 12;
            lbNhapNgu.Text = " ";
            // 
            // frmStudentManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(dtpNhapNgu);
            Controls.Add(lbNhapNgu);
            Controls.Add(comboBox1);
            Controls.Add(lbPosition);
            Controls.Add(cbRank);
            Controls.Add(lbRank);
            Controls.Add(dtpBirthday);
            Controls.Add(lbBirthday);
            Controls.Add(cbClass);
            Controls.Add(lbClass);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lbPhoneNumber);
            Controls.Add(txtFullName);
            Controls.Add(lbFullName);
            Name = "frmStudentManagement";
            Text = "frmStudentManagement";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbFullName;
        private TextBox txtFullName;
        private TextBox txtPhoneNumber;
        private Label lbPhoneNumber;
        private Label lbClass;
        private ComboBox cbClass;
        private Label lbBirthday;
        private DateTimePicker dtpBirthday;
        private ComboBox cbRank;
        private Label lbRank;
        private ComboBox comboBox1;
        private Label lbPosition;
        private DateTimePicker dtpNhapNgu;
        private Label lbNhapNgu;
    }
}