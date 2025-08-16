using System.ComponentModel;

namespace StudentManagementSystem.UI.UserControls
{
    partial class ucTrainee
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
            components = new Container();
            pnInformation = new Panel();
            gbDetail = new GroupBox();
            lblRanking = new Label();
            lblClassId = new Label();
            lblId = new Label();
            dtpEnlistmentDate = new DateTimePicker();
            btnUpload = new Button();
            txtRole = new TextBox();
            txtMotherPhoneNumber = new MaskedTextBox();
            lblMotherPhoneNumber = new Label();
            txtMotherFullName = new TextBox();
            lblMotherFullName = new Label();
            txtFatherPhoneNumber = new MaskedTextBox();
            lblFatherPhoneNumber = new Label();
            txtFatherFullName = new TextBox();
            lblFatherFullName = new Label();
            lblRole = new Label();
            lblEnlistmentDate = new Label();
            txtRanking = new TextBox();
            dtpDayOfBirth = new DateTimePicker();
            lblDayOfBirth = new Label();
            txtPhoneNumber = new MaskedTextBox();
            lblPhoneNumber = new Label();
            txtClassId = new TextBox();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtId = new TextBox();
            pbAvatar = new PictureBox();
            tableLayoutPanel = new TableLayoutPanel();
            tabControl = new TabControl();
            tabTrainees = new TabPage();
            dgvRead = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dayOfBirthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rankingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enlistmentDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            averageScoreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fatherFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fatherPhoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            motherFullNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            motherPhoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            avatarUrlDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            traineeBindingSource = new BindingSource(components);
            pnAction = new Panel();
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            errorProvider1 = new ErrorProvider(components);
            pnInformation.SuspendLayout();
            gbDetail.SuspendLayout();
            ((ISupportInitialize)pbAvatar).BeginInit();
            tableLayoutPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabTrainees.SuspendLayout();
            ((ISupportInitialize)dgvRead).BeginInit();
            ((ISupportInitialize)traineeBindingSource).BeginInit();
            pnAction.SuspendLayout();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnInformation
            // 
            pnInformation.Controls.Add(gbDetail);
            pnInformation.Dock = DockStyle.Fill;
            pnInformation.Location = new Point(3, 3);
            pnInformation.Name = "pnInformation";
            pnInformation.Size = new Size(1274, 334);
            pnInformation.TabIndex = 0;
            // 
            // gbDetail
            // 
            gbDetail.Controls.Add(lblRanking);
            gbDetail.Controls.Add(lblClassId);
            gbDetail.Controls.Add(lblId);
            gbDetail.Controls.Add(dtpEnlistmentDate);
            gbDetail.Controls.Add(btnUpload);
            gbDetail.Controls.Add(txtRole);
            gbDetail.Controls.Add(txtMotherPhoneNumber);
            gbDetail.Controls.Add(lblMotherPhoneNumber);
            gbDetail.Controls.Add(txtMotherFullName);
            gbDetail.Controls.Add(lblMotherFullName);
            gbDetail.Controls.Add(txtFatherPhoneNumber);
            gbDetail.Controls.Add(lblFatherPhoneNumber);
            gbDetail.Controls.Add(txtFatherFullName);
            gbDetail.Controls.Add(lblFatherFullName);
            gbDetail.Controls.Add(lblRole);
            gbDetail.Controls.Add(lblEnlistmentDate);
            gbDetail.Controls.Add(txtRanking);
            gbDetail.Controls.Add(dtpDayOfBirth);
            gbDetail.Controls.Add(lblDayOfBirth);
            gbDetail.Controls.Add(txtPhoneNumber);
            gbDetail.Controls.Add(lblPhoneNumber);
            gbDetail.Controls.Add(txtClassId);
            gbDetail.Controls.Add(txtFullName);
            gbDetail.Controls.Add(lblFullName);
            gbDetail.Controls.Add(txtId);
            gbDetail.Controls.Add(pbAvatar);
            gbDetail.Dock = DockStyle.Fill;
            gbDetail.Location = new Point(0, 0);
            gbDetail.Name = "gbDetail";
            gbDetail.Size = new Size(1274, 334);
            gbDetail.TabIndex = 0;
            gbDetail.TabStop = false;
            gbDetail.Text = "Thông tin học viên";
            // 
            // lblRanking
            // 
            lblRanking.AutoSize = true;
            lblRanking.Location = new Point(162, 171);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(76, 25);
            lblRanking.TabIndex = 27;
            lblRanking.Text = "Cấp bậc";
            // 
            // lblClassId
            // 
            lblClassId.AutoSize = true;
            lblClassId.Location = new Point(162, 99);
            lblClassId.Name = "lblClassId";
            lblClassId.Size = new Size(42, 25);
            lblClassId.TabIndex = 26;
            lblClassId.Text = "Lớp";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(162, 23);
            lblId.Name = "lblId";
            lblId.Size = new Size(108, 25);
            lblId.TabIndex = 25;
            lblId.Text = "Mã học viên";
            // 
            // dtpEnlistmentDate
            // 
            dtpEnlistmentDate.CustomFormat = "dd/MM/yyyy";
            dtpEnlistmentDate.Format = DateTimePickerFormat.Custom;
            dtpEnlistmentDate.Location = new Point(493, 131);
            dtpEnlistmentDate.Name = "dtpEnlistmentDate";
            dtpEnlistmentDate.Size = new Size(300, 31);
            dtpEnlistmentDate.TabIndex = 24;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(26, 236);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(112, 34);
            btnUpload.TabIndex = 23;
            btnUpload.Text = "Cập nhật";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += BtnUpload_ClickAsync;
            // 
            // txtRole
            // 
            txtRole.Location = new Point(493, 168);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(300, 31);
            txtRole.TabIndex = 22;
            // 
            // txtMotherPhoneNumber
            // 
            txtMotherPhoneNumber.Location = new Point(945, 131);
            txtMotherPhoneNumber.Mask = "0000 000 000";
            txtMotherPhoneNumber.Name = "txtMotherPhoneNumber";
            txtMotherPhoneNumber.ResetOnSpace = false;
            txtMotherPhoneNumber.Size = new Size(300, 31);
            txtMotherPhoneNumber.TabIndex = 21;
            txtMotherPhoneNumber.Click += txtMotherPhoneNumber_Click;
            txtMotherPhoneNumber.Enter += txtMotherPhoneNumber_Enter;
            txtMotherPhoneNumber.KeyDown += txtMotherPhoneNumber_KeyDown;
            txtMotherPhoneNumber.Validating += txtMotherPhoneNumber_Validating;
            // 
            // lblMotherPhoneNumber
            // 
            lblMotherPhoneNumber.AutoSize = true;
            lblMotherPhoneNumber.Location = new Point(850, 134);
            lblMotherPhoneNumber.Name = "lblMotherPhoneNumber";
            lblMotherPhoneNumber.Size = new Size(74, 25);
            lblMotherPhoneNumber.TabIndex = 20;
            lblMotherPhoneNumber.Text = "SĐT mẹ";
            // 
            // txtMotherFullName
            // 
            txtMotherFullName.Location = new Point(945, 94);
            txtMotherFullName.Name = "txtMotherFullName";
            txtMotherFullName.Size = new Size(300, 31);
            txtMotherFullName.TabIndex = 19;
            // 
            // lblMotherFullName
            // 
            lblMotherFullName.AutoSize = true;
            lblMotherFullName.Location = new Point(850, 97);
            lblMotherFullName.Name = "lblMotherFullName";
            lblMotherFullName.Size = new Size(68, 25);
            lblMotherFullName.TabIndex = 18;
            lblMotherFullName.Text = "Tên mẹ";
            // 
            // txtFatherPhoneNumber
            // 
            txtFatherPhoneNumber.Location = new Point(945, 57);
            txtFatherPhoneNumber.Mask = "0000 000 000";
            txtFatherPhoneNumber.Name = "txtFatherPhoneNumber";
            txtFatherPhoneNumber.ResetOnSpace = false;
            txtFatherPhoneNumber.Size = new Size(300, 31);
            txtFatherPhoneNumber.TabIndex = 17;
            txtFatherPhoneNumber.Click += txtFatherPhoneNumber_Click;
            txtFatherPhoneNumber.Enter += txtFatherPhoneNumber_Enter;
            txtFatherPhoneNumber.KeyDown += txtFatherPhoneNumber_KeyDown;
            txtFatherPhoneNumber.Validating += txtFatherPhoneNumber_Validating;
            // 
            // lblFatherPhoneNumber
            // 
            lblFatherPhoneNumber.AutoSize = true;
            lblFatherPhoneNumber.Location = new Point(850, 60);
            lblFatherPhoneNumber.Name = "lblFatherPhoneNumber";
            lblFatherPhoneNumber.Size = new Size(76, 25);
            lblFatherPhoneNumber.TabIndex = 16;
            lblFatherPhoneNumber.Text = "SĐT cha";
            // 
            // txtFatherFullName
            // 
            txtFatherFullName.Location = new Point(945, 20);
            txtFatherFullName.Name = "txtFatherFullName";
            txtFatherFullName.Size = new Size(300, 31);
            txtFatherFullName.TabIndex = 15;
            // 
            // lblFatherFullName
            // 
            lblFatherFullName.AutoSize = true;
            lblFatherFullName.Location = new Point(850, 23);
            lblFatherFullName.Name = "lblFatherFullName";
            lblFatherFullName.Size = new Size(70, 25);
            lblFatherFullName.TabIndex = 14;
            lblFatherFullName.Text = "Tên cha";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(398, 171);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(76, 25);
            lblRole.TabIndex = 12;
            lblRole.Text = "Chức vụ";
            // 
            // lblEnlistmentDate
            // 
            lblEnlistmentDate.AutoSize = true;
            lblEnlistmentDate.Location = new Point(398, 134);
            lblEnlistmentDate.Name = "lblEnlistmentDate";
            lblEnlistmentDate.Size = new Size(91, 25);
            lblEnlistmentDate.TabIndex = 10;
            lblEnlistmentDate.Text = "Nhập ngũ";
            // 
            // txtRanking
            // 
            txtRanking.Location = new Point(161, 205);
            txtRanking.Name = "txtRanking";
            txtRanking.Size = new Size(150, 31);
            txtRanking.TabIndex = 9;
            // 
            // dtpDayOfBirth
            // 
            dtpDayOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDayOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDayOfBirth.Location = new Point(493, 94);
            dtpDayOfBirth.Name = "dtpDayOfBirth";
            dtpDayOfBirth.Size = new Size(300, 31);
            dtpDayOfBirth.TabIndex = 8;
            // 
            // lblDayOfBirth
            // 
            lblDayOfBirth.AutoSize = true;
            lblDayOfBirth.Location = new Point(398, 97);
            lblDayOfBirth.Name = "lblDayOfBirth";
            lblDayOfBirth.Size = new Size(91, 25);
            lblDayOfBirth.TabIndex = 7;
            lblDayOfBirth.Text = "Ngày sinh";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(493, 57);
            txtPhoneNumber.Mask = "0000 000 000";
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ResetOnSpace = false;
            txtPhoneNumber.Size = new Size(300, 31);
            txtPhoneNumber.TabIndex = 6;
            txtPhoneNumber.Click += txtPhoneNumber_Click;
            txtPhoneNumber.Enter += txtPhoneNumber_Enter;
            txtPhoneNumber.KeyDown += txtPhoneNumber_KeyDown;
            txtPhoneNumber.Validating += txtPhoneNumber_Validating;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(443, 60);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(44, 25);
            lblPhoneNumber.TabIndex = 5;
            lblPhoneNumber.Text = "SĐT";
            // 
            // txtClassId
            // 
            txtClassId.Location = new Point(162, 131);
            txtClassId.Name = "txtClassId";
            txtClassId.Size = new Size(149, 31);
            txtClassId.TabIndex = 4;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(493, 20);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(300, 31);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(398, 23);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(89, 25);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(162, 57);
            txtId.Name = "txtId";
            txtId.Size = new Size(149, 31);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            // 
            // pbAvatar
            // 
            pbAvatar.BorderStyle = BorderStyle.Fixed3D;
            pbAvatar.Image = Properties.Resources.avatar;
            pbAvatar.Location = new Point(6, 30);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(150, 200);
            pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            pbAvatar.TabIndex = 0;
            pbAvatar.TabStop = false;
            pbAvatar.WaitOnLoad = true;
            pbAvatar.DragDrop += pbAvatar_DragDrop;
            pbAvatar.DragEnter += pbAvatar_DragEnter;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(pnInformation, 0, 0);
            tableLayoutPanel.Controls.Add(tabControl, 0, 1);
            tableLayoutPanel.Controls.Add(pnAction, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1280, 720);
            tableLayoutPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTrainees);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(3, 343);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1274, 334);
            tabControl.TabIndex = 1;
            // 
            // tabTrainees
            // 
            tabTrainees.Controls.Add(dgvRead);
            tabTrainees.Location = new Point(4, 34);
            tabTrainees.Name = "tabTrainees";
            tabTrainees.Padding = new Padding(3);
            tabTrainees.Size = new Size(1266, 296);
            tabTrainees.TabIndex = 0;
            tabTrainees.Text = "Danh sách";
            tabTrainees.UseVisualStyleBackColor = true;
            // 
            // dgvRead
            // 
            dgvRead.AutoGenerateColumns = false;
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, classIdDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn, dayOfBirthDataGridViewTextBoxColumn, rankingDataGridViewTextBoxColumn, enlistmentDateDataGridViewTextBoxColumn, averageScoreDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, fatherFullNameDataGridViewTextBoxColumn, fatherPhoneNumberDataGridViewTextBoxColumn, motherFullNameDataGridViewTextBoxColumn, motherPhoneNumberDataGridViewTextBoxColumn, avatarUrlDataGridViewTextBoxColumn });
            dgvRead.DataSource = traineeBindingSource;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(3, 3);
            dgvRead.Name = "dgvRead";
            dgvRead.RowHeadersWidth = 62;
            dgvRead.Size = new Size(1260, 290);
            dgvRead.TabIndex = 0;
            dgvRead.SelectionChanged += dgvRead_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 8;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 150;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // classIdDataGridViewTextBoxColumn
            // 
            classIdDataGridViewTextBoxColumn.DataPropertyName = "ClassId";
            classIdDataGridViewTextBoxColumn.HeaderText = "ClassId";
            classIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            classIdDataGridViewTextBoxColumn.Name = "classIdDataGridViewTextBoxColumn";
            classIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // dayOfBirthDataGridViewTextBoxColumn
            // 
            dayOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DayOfBirth";
            dayOfBirthDataGridViewTextBoxColumn.HeaderText = "DayOfBirth";
            dayOfBirthDataGridViewTextBoxColumn.MinimumWidth = 8;
            dayOfBirthDataGridViewTextBoxColumn.Name = "dayOfBirthDataGridViewTextBoxColumn";
            dayOfBirthDataGridViewTextBoxColumn.Width = 150;
            // 
            // rankingDataGridViewTextBoxColumn
            // 
            rankingDataGridViewTextBoxColumn.DataPropertyName = "Ranking";
            rankingDataGridViewTextBoxColumn.HeaderText = "Ranking";
            rankingDataGridViewTextBoxColumn.MinimumWidth = 8;
            rankingDataGridViewTextBoxColumn.Name = "rankingDataGridViewTextBoxColumn";
            rankingDataGridViewTextBoxColumn.Width = 150;
            // 
            // enlistmentDateDataGridViewTextBoxColumn
            // 
            enlistmentDateDataGridViewTextBoxColumn.DataPropertyName = "EnlistmentDate";
            enlistmentDateDataGridViewTextBoxColumn.HeaderText = "EnlistmentDate";
            enlistmentDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            enlistmentDateDataGridViewTextBoxColumn.Name = "enlistmentDateDataGridViewTextBoxColumn";
            enlistmentDateDataGridViewTextBoxColumn.Width = 150;
            // 
            // averageScoreDataGridViewTextBoxColumn
            // 
            averageScoreDataGridViewTextBoxColumn.DataPropertyName = "AverageScore";
            averageScoreDataGridViewTextBoxColumn.HeaderText = "AverageScore";
            averageScoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            averageScoreDataGridViewTextBoxColumn.Name = "averageScoreDataGridViewTextBoxColumn";
            averageScoreDataGridViewTextBoxColumn.Width = 150;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Role";
            roleDataGridViewTextBoxColumn.MinimumWidth = 8;
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.Width = 150;
            // 
            // fatherFullNameDataGridViewTextBoxColumn
            // 
            fatherFullNameDataGridViewTextBoxColumn.DataPropertyName = "FatherFullName";
            fatherFullNameDataGridViewTextBoxColumn.HeaderText = "FatherFullName";
            fatherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherFullNameDataGridViewTextBoxColumn.Name = "fatherFullNameDataGridViewTextBoxColumn";
            fatherFullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // fatherPhoneNumberDataGridViewTextBoxColumn
            // 
            fatherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "FatherPhoneNumber";
            fatherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "FatherPhoneNumber";
            fatherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherPhoneNumberDataGridViewTextBoxColumn.Name = "fatherPhoneNumberDataGridViewTextBoxColumn";
            fatherPhoneNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // motherFullNameDataGridViewTextBoxColumn
            // 
            motherFullNameDataGridViewTextBoxColumn.DataPropertyName = "MotherFullName";
            motherFullNameDataGridViewTextBoxColumn.HeaderText = "MotherFullName";
            motherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherFullNameDataGridViewTextBoxColumn.Name = "motherFullNameDataGridViewTextBoxColumn";
            motherFullNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // motherPhoneNumberDataGridViewTextBoxColumn
            // 
            motherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "MotherPhoneNumber";
            motherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "MotherPhoneNumber";
            motherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherPhoneNumberDataGridViewTextBoxColumn.Name = "motherPhoneNumberDataGridViewTextBoxColumn";
            motherPhoneNumberDataGridViewTextBoxColumn.Width = 150;
            // 
            // avatarUrlDataGridViewTextBoxColumn
            // 
            avatarUrlDataGridViewTextBoxColumn.DataPropertyName = "AvatarUrl";
            avatarUrlDataGridViewTextBoxColumn.HeaderText = "AvatarUrl";
            avatarUrlDataGridViewTextBoxColumn.MinimumWidth = 8;
            avatarUrlDataGridViewTextBoxColumn.Name = "avatarUrlDataGridViewTextBoxColumn";
            avatarUrlDataGridViewTextBoxColumn.Width = 150;
            // 
            // traineeBindingSource
            // 
            traineeBindingSource.DataSource = typeof(Domain.Entities.Trainee);
            // 
            // pnAction
            // 
            pnAction.Controls.Add(btnDelete);
            pnAction.Controls.Add(btnSave);
            pnAction.Controls.Add(btnAdd);
            pnAction.Controls.Add(btnRefresh);
            pnAction.Dock = DockStyle.Fill;
            pnAction.Location = new Point(3, 683);
            pnAction.Name = "pnAction";
            pnAction.Size = new Size(1274, 34);
            pnAction.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.Location = new Point(336, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.Location = new Point(224, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.Location = new Point(112, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Left;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(112, 34);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ucTrainee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "ucTrainee";
            Size = new Size(1280, 720);
            Load += ucTrainee_Load;
            pnInformation.ResumeLayout(false);
            gbDetail.ResumeLayout(false);
            gbDetail.PerformLayout();
            ((ISupportInitialize)pbAvatar).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabTrainees.ResumeLayout(false);
            ((ISupportInitialize)dgvRead).EndInit();
            ((ISupportInitialize)traineeBindingSource).EndInit();
            pnAction.ResumeLayout(false);
            ((ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnInformation;
        private TableLayoutPanel tableLayoutPanel;
        private TabControl tabControl;
        private TabPage tabTrainees;
        private DataGridView dgvRead;
        private BindingSource traineeBindingSource;
        private GroupBox gbDetail;
        private PictureBox pbAvatar;
        private TextBox txtId;
        private TextBox txtFullName;
        private Label lblFullName;
        private TextBox txtClassId;
        private MaskedTextBox txtPhoneNumber;
        private Label lblPhoneNumber;
        private DateTimePicker dtpDayOfBirth;
        private Label lblDayOfBirth;
        private TextBox txtRanking;
        private Label lblEnlistmentDate;
        private Label lblRole;
        private TextBox txtFatherFullName;
        private Label lblFatherFullName;
        private MaskedTextBox txtFatherPhoneNumber;
        private Label lblFatherPhoneNumber;
        private MaskedTextBox txtMotherPhoneNumber;
        private Label lblMotherPhoneNumber;
        private TextBox txtMotherFullName;
        private Label lblMotherFullName;
        private Button btnRefresh;
        private Panel pnAction;
        private Button btnAdd;
        private TextBox txtRole;
        private Button btnSave;
        private Button btnDelete;
        private Button btnUpload;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dayOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rankingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enlistmentDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn averageScoreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fatherFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fatherPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn motherFullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn motherPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn avatarUrlDataGridViewTextBoxColumn;
        private DateTimePicker dtpEnlistmentDate;
        private Label lblId;
        private Label lblRanking;
        private Label lblClassId;
        private ContextMenuStrip contextMenuStrip1;
        private ErrorProvider errorProvider1;
    }
}
