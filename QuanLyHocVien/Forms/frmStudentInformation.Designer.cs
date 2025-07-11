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
            cbGender = new CheckBox();
            textBox1 = new TextBox();
            lbFullName = new Label();
            lbBirthday = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            label8 = new Label();
            groupBox2 = new GroupBox();
            label9 = new Label();
            textBox8 = new TextBox();
            label10 = new Label();
            textBox9 = new TextBox();
            label11 = new Label();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            label12 = new Label();
            textBox12 = new TextBox();
            label13 = new Label();
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
            groupBox1.Controls.Add(textBox12);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(textBox11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(textBox10);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(textBox9);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(textBox8);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(lbBirthday);
            groupBox1.Controls.Add(cbGender);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(lbFullName);
            groupBox1.Controls.Add(picAvatar);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1234, 409);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÔNG TIN HỌC VIÊN";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // cbGender
            // 
            cbGender.AutoSize = true;
            cbGender.Location = new Point(814, 43);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(76, 29);
            cbGender.TabIndex = 5;
            cbGender.Text = "Nam";
            cbGender.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(368, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 31);
            textBox1.TabIndex = 4;
            // 
            // lbFullName
            // 
            lbFullName.AutoSize = true;
            lbFullName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbFullName.Location = new Point(172, 41);
            lbFullName.Name = "lbFullName";
            lbFullName.Size = new Size(89, 25);
            lbFullName.TabIndex = 3;
            lbFullName.Text = "Họ và tên";
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbBirthday.Location = new Point(172, 80);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(91, 25);
            lbBirthday.TabIndex = 6;
            lbBirthday.Text = "Ngày sinh";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(368, 75);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(814, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 31);
            textBox2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Enabled = false;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(674, 81);
            label2.Name = "label2";
            label2.Size = new Size(77, 25);
            label2.TabIndex = 9;
            label2.Text = "Nơi sinh";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(368, 149);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(300, 31);
            textBox3.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(172, 155);
            label3.Name = "label3";
            label3.Size = new Size(170, 25);
            label3.TabIndex = 11;
            label3.Text = "Hộ khẩu thường trú";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(172, 189);
            label4.Name = "label4";
            label4.Size = new Size(74, 25);
            label4.TabIndex = 12;
            label4.Text = "Dân tộc";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(368, 186);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(300, 31);
            textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(368, 223);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(300, 31);
            textBox5.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Enabled = false;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(172, 226);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 14;
            label5.Text = "Trình độ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(674, 44);
            label6.Name = "label6";
            label6.Size = new Size(78, 25);
            label6.TabIndex = 16;
            label6.Text = "Giới tính";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(368, 260);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(300, 31);
            textBox6.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Enabled = false;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(172, 263);
            label7.Name = "label7";
            label7.Size = new Size(181, 25);
            label7.TabIndex = 17;
            label7.Text = "Khi cần báo tin cho ai";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(814, 260);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(300, 31);
            textBox7.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Enabled = false;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(674, 263);
            label8.Name = "label8";
            label8.Size = new Size(134, 25);
            label8.TabIndex = 19;
            label8.Text = "SĐT phụ huynh";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(12, 427);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1234, 225);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "THÔNG TIN BỔ SUNG";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Enabled = false;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(172, 118);
            label9.Name = "label9";
            label9.Size = new Size(76, 25);
            label9.TabIndex = 22;
            label9.Text = "Chức vụ";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(368, 112);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(300, 31);
            textBox8.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Enabled = false;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(674, 118);
            label10.Name = "label10";
            label10.Size = new Size(75, 25);
            label10.TabIndex = 24;
            label10.Text = "Tiểu đội";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(814, 111);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(300, 31);
            textBox9.TabIndex = 23;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Enabled = false;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(674, 190);
            label11.Name = "label11";
            label11.Size = new Size(80, 25);
            label11.TabIndex = 26;
            label11.Text = "Tôn giáo";
            // 
            // textBox10
            // 
            textBox10.Location = new Point(814, 183);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(300, 31);
            textBox10.TabIndex = 25;
            // 
            // textBox11
            // 
            textBox11.Location = new Point(368, 297);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(300, 31);
            textBox11.TabIndex = 28;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Enabled = false;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(172, 300);
            label12.Name = "label12";
            label12.Size = new Size(190, 25);
            label12.TabIndex = 27;
            label12.Text = "Ngày, tháng nhập ngũ";
            // 
            // textBox12
            // 
            textBox12.Location = new Point(814, 300);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(300, 31);
            textBox12.TabIndex = 30;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Enabled = false;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(674, 303);
            label13.Name = "label13";
            label13.Size = new Size(87, 25);
            label13.TabIndex = 29;
            label13.Text = "Đơn vị cũ";
            // 
            // frmStudentInformation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(groupBox2);
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
        private Label lbFullName;
        private CheckBox cbGender;
        private Label lbBirthday;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox5;
        private Label label5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox7;
        private Label label8;
        private TextBox textBox6;
        private Label label7;
        private Label label6;
        private GroupBox groupBox2;
        private Label label10;
        private TextBox textBox9;
        private Label label9;
        private TextBox textBox8;
        private TextBox textBox12;
        private Label label13;
        private TextBox textBox11;
        private Label label12;
        private Label label11;
        private TextBox textBox10;
    }
}