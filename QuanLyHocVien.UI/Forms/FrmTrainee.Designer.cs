namespace QuanLyHocVien.UI.Forms
{
    partial class FrmTrainee
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
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblClassId = new Label();
            txtClassId = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            dtpDayOfBirth = new DateTimePicker();
            lblDayOfBirth = new Label();
            lblRanking = new Label();
            txtRanking = new TextBox();
            lblRole = new Label();
            txtRole = new TextBox();
            lblEnlistmentDate = new Label();
            dtpEnlistmentDate = new DateTimePicker();
            lblFatherFullName = new Label();
            txtFatherFullName = new TextBox();
            lblFatherPhoneNumber = new Label();
            txtFatherPhoneNumber = new TextBox();
            lblMotherPhoneNumber = new Label();
            txtMotherPhoneNumber = new TextBox();
            lblMotherFullName = new Label();
            txtMotherFullName = new TextBox();
            lblId = new Label();
            txtId = new TextBox();
            pictureBox1 = new PictureBox();
            grbDetailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // grbDetailInfo
            // 
            grbDetailInfo.Controls.Add(pictureBox1);
            grbDetailInfo.Controls.Add(lblId);
            grbDetailInfo.Controls.Add(txtId);
            grbDetailInfo.Controls.Add(lblMotherPhoneNumber);
            grbDetailInfo.Controls.Add(txtMotherPhoneNumber);
            grbDetailInfo.Controls.Add(lblMotherFullName);
            grbDetailInfo.Controls.Add(txtMotherFullName);
            grbDetailInfo.Controls.Add(lblFatherPhoneNumber);
            grbDetailInfo.Controls.Add(txtFatherPhoneNumber);
            grbDetailInfo.Controls.Add(lblFatherFullName);
            grbDetailInfo.Controls.Add(txtFatherFullName);
            grbDetailInfo.Controls.Add(lblEnlistmentDate);
            grbDetailInfo.Controls.Add(dtpEnlistmentDate);
            grbDetailInfo.Controls.Add(lblRole);
            grbDetailInfo.Controls.Add(txtRole);
            grbDetailInfo.Controls.Add(lblRanking);
            grbDetailInfo.Controls.Add(txtRanking);
            grbDetailInfo.Controls.Add(lblDayOfBirth);
            grbDetailInfo.Controls.Add(dtpDayOfBirth);
            grbDetailInfo.Controls.Add(lblPhoneNumber);
            grbDetailInfo.Controls.Add(txtPhoneNumber);
            grbDetailInfo.Controls.Add(txtClassId);
            grbDetailInfo.Controls.Add(lblClassId);
            grbDetailInfo.Controls.Add(lblFullName);
            grbDetailInfo.Controls.Add(txtFullName);
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(6, 117);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(250, 31);
            txtFullName.TabIndex = 0;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(6, 89);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(89, 25);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ và tên";
            // 
            // lblClassId
            // 
            lblClassId.AutoSize = true;
            lblClassId.Location = new Point(6, 337);
            lblClassId.Name = "lblClassId";
            lblClassId.Size = new Size(68, 25);
            lblClassId.TabIndex = 2;
            lblClassId.Text = "Mã lớp";
            // 
            // txtClassId
            // 
            txtClassId.Location = new Point(6, 365);
            txtClassId.Name = "txtClassId";
            txtClassId.Size = new Size(250, 31);
            txtClassId.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(6, 275);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(117, 25);
            lblPhoneNumber.TabIndex = 5;
            lblPhoneNumber.Text = "Số điện thoại";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(6, 303);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(250, 31);
            txtPhoneNumber.TabIndex = 4;
            // 
            // dtpDayOfBirth
            // 
            dtpDayOfBirth.Location = new Point(6, 179);
            dtpDayOfBirth.Name = "dtpDayOfBirth";
            dtpDayOfBirth.Size = new Size(250, 31);
            dtpDayOfBirth.TabIndex = 6;
            // 
            // lblDayOfBirth
            // 
            lblDayOfBirth.AutoSize = true;
            lblDayOfBirth.Location = new Point(6, 151);
            lblDayOfBirth.Name = "lblDayOfBirth";
            lblDayOfBirth.Size = new Size(91, 25);
            lblDayOfBirth.TabIndex = 7;
            lblDayOfBirth.Text = "Ngày sinh";
            // 
            // lblRanking
            // 
            lblRanking.AutoSize = true;
            lblRanking.Location = new Point(6, 399);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(76, 25);
            lblRanking.TabIndex = 9;
            lblRanking.Text = "Cấp bậc";
            // 
            // txtRanking
            // 
            txtRanking.Location = new Point(6, 427);
            txtRanking.Name = "txtRanking";
            txtRanking.Size = new Size(250, 31);
            txtRanking.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(279, 399);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(76, 25);
            lblRole.TabIndex = 11;
            lblRole.Text = "Chức vụ";
            // 
            // txtRole
            // 
            txtRole.Location = new Point(279, 427);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(250, 31);
            txtRole.TabIndex = 10;
            // 
            // lblEnlistmentDate
            // 
            lblEnlistmentDate.AutoSize = true;
            lblEnlistmentDate.Location = new Point(6, 213);
            lblEnlistmentDate.Name = "lblEnlistmentDate";
            lblEnlistmentDate.Size = new Size(135, 25);
            lblEnlistmentDate.TabIndex = 13;
            lblEnlistmentDate.Text = "Ngày nhập ngũ";
            // 
            // dtpEnlistmentDate
            // 
            dtpEnlistmentDate.Location = new Point(6, 241);
            dtpEnlistmentDate.Name = "dtpEnlistmentDate";
            dtpEnlistmentDate.Size = new Size(250, 31);
            dtpEnlistmentDate.TabIndex = 12;
            // 
            // lblFatherFullName
            // 
            lblFatherFullName.AutoSize = true;
            lblFatherFullName.Location = new Point(6, 461);
            lblFatherFullName.Name = "lblFatherFullName";
            lblFatherFullName.Size = new Size(101, 25);
            lblFatherFullName.TabIndex = 15;
            lblFatherFullName.Text = "Họ tên Cha";
            // 
            // txtFatherFullName
            // 
            txtFatherFullName.Location = new Point(6, 489);
            txtFatherFullName.Name = "txtFatherFullName";
            txtFatherFullName.Size = new Size(250, 31);
            txtFatherFullName.TabIndex = 14;
            // 
            // lblFatherPhoneNumber
            // 
            lblFatherPhoneNumber.AutoSize = true;
            lblFatherPhoneNumber.Location = new Point(279, 461);
            lblFatherPhoneNumber.Name = "lblFatherPhoneNumber";
            lblFatherPhoneNumber.Size = new Size(152, 25);
            lblFatherPhoneNumber.TabIndex = 17;
            lblFatherPhoneNumber.Text = "Số điện thoại Cha";
            // 
            // txtFatherPhoneNumber
            // 
            txtFatherPhoneNumber.Location = new Point(279, 489);
            txtFatherPhoneNumber.Name = "txtFatherPhoneNumber";
            txtFatherPhoneNumber.Size = new Size(250, 31);
            txtFatherPhoneNumber.TabIndex = 16;
            // 
            // lblMotherPhoneNumber
            // 
            lblMotherPhoneNumber.AutoSize = true;
            lblMotherPhoneNumber.Location = new Point(279, 523);
            lblMotherPhoneNumber.Name = "lblMotherPhoneNumber";
            lblMotherPhoneNumber.Size = new Size(147, 25);
            lblMotherPhoneNumber.TabIndex = 21;
            lblMotherPhoneNumber.Text = "Số điện thoại Mẹ";
            // 
            // txtMotherPhoneNumber
            // 
            txtMotherPhoneNumber.Location = new Point(279, 551);
            txtMotherPhoneNumber.Name = "txtMotherPhoneNumber";
            txtMotherPhoneNumber.Size = new Size(250, 31);
            txtMotherPhoneNumber.TabIndex = 20;
            // 
            // lblMotherFullName
            // 
            lblMotherFullName.AutoSize = true;
            lblMotherFullName.Location = new Point(6, 523);
            lblMotherFullName.Name = "lblMotherFullName";
            lblMotherFullName.Size = new Size(96, 25);
            lblMotherFullName.TabIndex = 19;
            lblMotherFullName.Text = "Họ tên Mẹ";
            // 
            // txtMotherFullName
            // 
            txtMotherFullName.Location = new Point(6, 551);
            txtMotherFullName.Name = "txtMotherFullName";
            txtMotherFullName.Size = new Size(250, 31);
            txtMotherFullName.TabIndex = 18;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(6, 27);
            lblId.Name = "lblId";
            lblId.Size = new Size(122, 25);
            lblId.TabIndex = 23;
            lblId.Text = "Mã định danh";
            // 
            // txtId
            // 
            txtId.Location = new Point(6, 55);
            txtId.Name = "txtId";
            txtId.Size = new Size(250, 31);
            txtId.TabIndex = 22;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(281, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(248, 307);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // FrmTrainee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 712);
            Name = "FrmTrainee";
            Text = "FrmTrainee";
            grbDetailInfo.ResumeLayout(false);
            grbDetailInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblClassId;
        private TextBox txtClassId;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblDayOfBirth;
        private DateTimePicker dtpDayOfBirth;
        private Label lblRanking;
        private TextBox txtRanking;
        private Label lblEnlistmentDate;
        private DateTimePicker dtpEnlistmentDate;
        private Label lblRole;
        private TextBox txtRole;
        private Label lblFatherFullName;
        private TextBox txtFatherFullName;
        private Label lblFatherPhoneNumber;
        private TextBox txtFatherPhoneNumber;
        private Label lblMotherPhoneNumber;
        private TextBox txtMotherPhoneNumber;
        private Label lblMotherFullName;
        private TextBox txtMotherFullName;
        private PictureBox pictureBox1;
        private Label lblId;
        private TextBox txtId;
    }
}