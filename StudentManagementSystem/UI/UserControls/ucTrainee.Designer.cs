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
            gbGrades = new GroupBox();
            btnSaveGrade = new Button();
            numGrade = new NumericUpDown();
            lblType = new Label();
            lblGrade = new Label();
            cbType = new ComboBox();
            examTypeBindingSource = new BindingSource(components);
            lblSubject = new Label();
            cbSubject = new ComboBox();
            subjectBindingSource = new BindingSource(components);
            numAverageScore = new NumericUpDown();
            lblAverageScore = new Label();
            cbRole = new ComboBox();
            roleBindingSource = new BindingSource(components);
            cbClassId = new ComboBox();
            classBindingSource = new BindingSource(components);
            lblRanking = new Label();
            lblClassId = new Label();
            lblId = new Label();
            dtpEnlistmentDate = new DateTimePicker();
            btnUpload = new Button();
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
            ClassName = new DataGridViewTextBoxColumn();
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
            tabGrades = new TabPage();
            dgvGrades = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            traineeIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subjectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subjectNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            typeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gradeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gradesBindingSource = new BindingSource(components);
            tabSubjectAverageScore = new TabPage();
            dgvSubjectAverageScore = new DataGridView();
            subjectAverageScoreBindingSource = new BindingSource(components);
            pnAction = new Panel();
            btnImportfromExcel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            errorProvider1 = new ErrorProvider(components);
            idDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            subjectNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            averageScoreDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            gradeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            semesterDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            schoolYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pnInformation.SuspendLayout();
            gbDetail.SuspendLayout();
            gbGrades.SuspendLayout();
            ((ISupportInitialize)numGrade).BeginInit();
            ((ISupportInitialize)examTypeBindingSource).BeginInit();
            ((ISupportInitialize)subjectBindingSource).BeginInit();
            ((ISupportInitialize)numAverageScore).BeginInit();
            ((ISupportInitialize)roleBindingSource).BeginInit();
            ((ISupportInitialize)classBindingSource).BeginInit();
            ((ISupportInitialize)pbAvatar).BeginInit();
            tableLayoutPanel.SuspendLayout();
            tabControl.SuspendLayout();
            tabTrainees.SuspendLayout();
            ((ISupportInitialize)dgvRead).BeginInit();
            ((ISupportInitialize)traineeBindingSource).BeginInit();
            tabGrades.SuspendLayout();
            ((ISupportInitialize)dgvGrades).BeginInit();
            ((ISupportInitialize)gradesBindingSource).BeginInit();
            tabSubjectAverageScore.SuspendLayout();
            ((ISupportInitialize)dgvSubjectAverageScore).BeginInit();
            ((ISupportInitialize)subjectAverageScoreBindingSource).BeginInit();
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
            pnInformation.Size = new Size(1306, 361);
            pnInformation.TabIndex = 0;
            // 
            // gbDetail
            // 
            gbDetail.Controls.Add(gbGrades);
            gbDetail.Controls.Add(numAverageScore);
            gbDetail.Controls.Add(lblAverageScore);
            gbDetail.Controls.Add(cbRole);
            gbDetail.Controls.Add(cbClassId);
            gbDetail.Controls.Add(lblRanking);
            gbDetail.Controls.Add(lblClassId);
            gbDetail.Controls.Add(lblId);
            gbDetail.Controls.Add(dtpEnlistmentDate);
            gbDetail.Controls.Add(btnUpload);
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
            gbDetail.Controls.Add(txtFullName);
            gbDetail.Controls.Add(lblFullName);
            gbDetail.Controls.Add(txtId);
            gbDetail.Controls.Add(pbAvatar);
            gbDetail.Dock = DockStyle.Fill;
            gbDetail.Location = new Point(0, 0);
            gbDetail.Name = "gbDetail";
            gbDetail.Size = new Size(1306, 361);
            gbDetail.TabIndex = 0;
            gbDetail.TabStop = false;
            gbDetail.Text = "Thông tin học viên";
            // 
            // gbGrades
            // 
            gbGrades.Controls.Add(btnSaveGrade);
            gbGrades.Controls.Add(numGrade);
            gbGrades.Controls.Add(lblType);
            gbGrades.Controls.Add(lblGrade);
            gbGrades.Controls.Add(cbType);
            gbGrades.Controls.Add(lblSubject);
            gbGrades.Controls.Add(cbSubject);
            gbGrades.Location = new Point(850, 172);
            gbGrades.Name = "gbGrades";
            gbGrades.Size = new Size(396, 186);
            gbGrades.TabIndex = 32;
            gbGrades.TabStop = false;
            gbGrades.Text = "Cập nhật điểm môn học";
            // 
            // btnSaveGrade
            // 
            btnSaveGrade.Location = new Point(278, 145);
            btnSaveGrade.Name = "btnSaveGrade";
            btnSaveGrade.Size = new Size(112, 34);
            btnSaveGrade.TabIndex = 35;
            btnSaveGrade.Text = "Lưu điểm";
            btnSaveGrade.UseVisualStyleBackColor = true;
            btnSaveGrade.Click += btnSaveGrade_Click;
            // 
            // numGrade
            // 
            numGrade.DecimalPlaces = 2;
            numGrade.Location = new Point(101, 108);
            numGrade.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numGrade.Name = "numGrade";
            numGrade.Size = new Size(289, 31);
            numGrade.TabIndex = 34;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(6, 73);
            lblType.Name = "lblType";
            lblType.Size = new Size(89, 25);
            lblType.TabIndex = 2;
            lblType.Text = "Loại điểm";
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(6, 110);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(54, 25);
            lblGrade.TabIndex = 33;
            lblGrade.Text = "Điểm";
            // 
            // cbType
            // 
            cbType.DataSource = examTypeBindingSource;
            cbType.DisplayMember = "Name";
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbType.FormattingEnabled = true;
            cbType.Location = new Point(101, 69);
            cbType.Name = "cbType";
            cbType.Size = new Size(289, 33);
            cbType.TabIndex = 3;
            cbType.ValueMember = "Code";
            // 
            // examTypeBindingSource
            // 
            examTypeBindingSource.DataSource = typeof(Domain.Entities.Category);
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(6, 34);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(83, 25);
            lblSubject.TabIndex = 0;
            lblSubject.Text = "Môn học";
            // 
            // cbSubject
            // 
            cbSubject.DataSource = subjectBindingSource;
            cbSubject.DisplayMember = "Name";
            cbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSubject.FormattingEnabled = true;
            cbSubject.Location = new Point(101, 30);
            cbSubject.Name = "cbSubject";
            cbSubject.Size = new Size(289, 33);
            cbSubject.TabIndex = 1;
            cbSubject.ValueMember = "Id";
            // 
            // subjectBindingSource
            // 
            subjectBindingSource.DataSource = typeof(Domain.Entities.Subject);
            // 
            // numAverageScore
            // 
            numAverageScore.DecimalPlaces = 2;
            numAverageScore.Location = new Point(493, 207);
            numAverageScore.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numAverageScore.Name = "numAverageScore";
            numAverageScore.ReadOnly = true;
            numAverageScore.Size = new Size(300, 31);
            numAverageScore.TabIndex = 31;
            // 
            // lblAverageScore
            // 
            lblAverageScore.AutoSize = true;
            lblAverageScore.Location = new Point(349, 210);
            lblAverageScore.Name = "lblAverageScore";
            lblAverageScore.Size = new Size(142, 25);
            lblAverageScore.TabIndex = 30;
            lblAverageScore.Text = "Điểm trung bình";
            // 
            // cbRole
            // 
            cbRole.DataSource = roleBindingSource;
            cbRole.DisplayMember = "Name";
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(493, 168);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(300, 33);
            cbRole.TabIndex = 29;
            cbRole.ValueMember = "Code";
            // 
            // roleBindingSource
            // 
            roleBindingSource.DataSource = typeof(Domain.Entities.Category);
            // 
            // cbClassId
            // 
            cbClassId.DataSource = classBindingSource;
            cbClassId.DisplayMember = "Name";
            cbClassId.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClassId.FormattingEnabled = true;
            cbClassId.Location = new Point(161, 133);
            cbClassId.Name = "cbClassId";
            cbClassId.Size = new Size(183, 33);
            cbClassId.TabIndex = 28;
            cbClassId.ValueMember = "Id";
            // 
            // classBindingSource
            // 
            classBindingSource.DataSource = typeof(Domain.Entities.Class);
            // 
            // lblRanking
            // 
            lblRanking.AutoSize = true;
            lblRanking.Location = new Point(161, 172);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(76, 25);
            lblRanking.TabIndex = 27;
            lblRanking.Text = "Cấp bậc";
            // 
            // lblClassId
            // 
            lblClassId.AutoSize = true;
            lblClassId.Location = new Point(161, 98);
            lblClassId.Name = "lblClassId";
            lblClassId.Size = new Size(42, 25);
            lblClassId.TabIndex = 26;
            lblClassId.Text = "Lớp";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(161, 23);
            lblId.Name = "lblId";
            lblId.Size = new Size(108, 25);
            lblId.TabIndex = 25;
            lblId.Text = "Mã học viên";
            // 
            // dtpEnlistmentDate
            // 
            dtpEnlistmentDate.CustomFormat = "dd/MM/yyyy";
            dtpEnlistmentDate.Format = DateTimePickerFormat.Custom;
            dtpEnlistmentDate.Location = new Point(493, 132);
            dtpEnlistmentDate.Name = "dtpEnlistmentDate";
            dtpEnlistmentDate.Size = new Size(300, 31);
            dtpEnlistmentDate.TabIndex = 24;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(26, 237);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(111, 33);
            btnUpload.TabIndex = 23;
            btnUpload.Text = "Cập nhật";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += BtnUpload_ClickAsync;
            // 
            // txtMotherPhoneNumber
            // 
            txtMotherPhoneNumber.Location = new Point(946, 132);
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
            lblMotherPhoneNumber.Location = new Point(850, 133);
            lblMotherPhoneNumber.Name = "lblMotherPhoneNumber";
            lblMotherPhoneNumber.Size = new Size(74, 25);
            lblMotherPhoneNumber.TabIndex = 20;
            lblMotherPhoneNumber.Text = "SĐT mẹ";
            // 
            // txtMotherFullName
            // 
            txtMotherFullName.Location = new Point(946, 93);
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
            txtFatherPhoneNumber.Location = new Point(946, 57);
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
            txtFatherFullName.Location = new Point(946, 20);
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
            lblRole.Location = new Point(413, 172);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(76, 25);
            lblRole.TabIndex = 12;
            lblRole.Text = "Chức vụ";
            // 
            // lblEnlistmentDate
            // 
            lblEnlistmentDate.AutoSize = true;
            lblEnlistmentDate.Location = new Point(399, 133);
            lblEnlistmentDate.Name = "lblEnlistmentDate";
            lblEnlistmentDate.Size = new Size(91, 25);
            lblEnlistmentDate.TabIndex = 10;
            lblEnlistmentDate.Text = "Nhập ngũ";
            // 
            // txtRanking
            // 
            txtRanking.Location = new Point(161, 205);
            txtRanking.Name = "txtRanking";
            txtRanking.Size = new Size(183, 31);
            txtRanking.TabIndex = 9;
            txtRanking.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpDayOfBirth
            // 
            dtpDayOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDayOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDayOfBirth.Location = new Point(493, 93);
            dtpDayOfBirth.Name = "dtpDayOfBirth";
            dtpDayOfBirth.Size = new Size(300, 31);
            dtpDayOfBirth.TabIndex = 8;
            // 
            // lblDayOfBirth
            // 
            lblDayOfBirth.AutoSize = true;
            lblDayOfBirth.Location = new Point(399, 97);
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
            lblFullName.Location = new Point(399, 23);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(89, 25);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(161, 57);
            txtId.Name = "txtId";
            txtId.Size = new Size(181, 31);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            txtId.TextAlign = HorizontalAlignment.Center;
            // 
            // pbAvatar
            // 
            pbAvatar.BorderStyle = BorderStyle.Fixed3D;
            pbAvatar.Image = Properties.Resources.avatar;
            pbAvatar.Location = new Point(6, 30);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(150, 201);
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
            tableLayoutPanel.Size = new Size(1312, 774);
            tableLayoutPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTrainees);
            tabControl.Controls.Add(tabGrades);
            tabControl.Controls.Add(tabSubjectAverageScore);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(3, 370);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1306, 361);
            tabControl.TabIndex = 1;
            // 
            // tabTrainees
            // 
            tabTrainees.Controls.Add(dgvRead);
            tabTrainees.Location = new Point(4, 34);
            tabTrainees.Name = "tabTrainees";
            tabTrainees.Padding = new Padding(3);
            tabTrainees.Size = new Size(1298, 323);
            tabTrainees.TabIndex = 0;
            tabTrainees.Text = "Danh sách";
            tabTrainees.UseVisualStyleBackColor = true;
            // 
            // dgvRead
            // 
            dgvRead.AllowUserToAddRows = false;
            dgvRead.AllowUserToOrderColumns = true;
            dgvRead.AutoGenerateColumns = false;
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, classIdDataGridViewTextBoxColumn, ClassName, phoneNumberDataGridViewTextBoxColumn, dayOfBirthDataGridViewTextBoxColumn, rankingDataGridViewTextBoxColumn, enlistmentDateDataGridViewTextBoxColumn, averageScoreDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, fatherFullNameDataGridViewTextBoxColumn, fatherPhoneNumberDataGridViewTextBoxColumn, motherFullNameDataGridViewTextBoxColumn, motherPhoneNumberDataGridViewTextBoxColumn, avatarUrlDataGridViewTextBoxColumn });
            dgvRead.DataSource = traineeBindingSource;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(3, 3);
            dgvRead.Name = "dgvRead";
            dgvRead.ReadOnly = true;
            dgvRead.RowHeadersWidth = 62;
            dgvRead.Size = new Size(1292, 317);
            dgvRead.TabIndex = 0;
            dgvRead.CellDoubleClick += dgvRead_CellDoubleClick;
            dgvRead.SelectionChanged += dgvRead_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Mã học viên";
            idDataGridViewTextBoxColumn.MinimumWidth = 8;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 144;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            fullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // classIdDataGridViewTextBoxColumn
            // 
            classIdDataGridViewTextBoxColumn.DataPropertyName = "ClassId";
            classIdDataGridViewTextBoxColumn.HeaderText = "Mã lớp";
            classIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            classIdDataGridViewTextBoxColumn.Name = "classIdDataGridViewTextBoxColumn";
            classIdDataGridViewTextBoxColumn.ReadOnly = true;
            classIdDataGridViewTextBoxColumn.Visible = false;
            classIdDataGridViewTextBoxColumn.Width = 104;
            // 
            // ClassName
            // 
            ClassName.DataPropertyName = "ClassName";
            ClassName.HeaderText = "Lớp";
            ClassName.MinimumWidth = 8;
            ClassName.Name = "ClassName";
            ClassName.ReadOnly = true;
            ClassName.Width = 78;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "SĐT";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            phoneNumberDataGridViewTextBoxColumn.Width = 80;
            // 
            // dayOfBirthDataGridViewTextBoxColumn
            // 
            dayOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DayOfBirth";
            dayOfBirthDataGridViewTextBoxColumn.HeaderText = "Ngày sinh";
            dayOfBirthDataGridViewTextBoxColumn.MinimumWidth = 8;
            dayOfBirthDataGridViewTextBoxColumn.Name = "dayOfBirthDataGridViewTextBoxColumn";
            dayOfBirthDataGridViewTextBoxColumn.ReadOnly = true;
            dayOfBirthDataGridViewTextBoxColumn.Width = 127;
            // 
            // rankingDataGridViewTextBoxColumn
            // 
            rankingDataGridViewTextBoxColumn.DataPropertyName = "Ranking";
            rankingDataGridViewTextBoxColumn.HeaderText = "Cấp bậc";
            rankingDataGridViewTextBoxColumn.MinimumWidth = 8;
            rankingDataGridViewTextBoxColumn.Name = "rankingDataGridViewTextBoxColumn";
            rankingDataGridViewTextBoxColumn.ReadOnly = true;
            rankingDataGridViewTextBoxColumn.Width = 112;
            // 
            // enlistmentDateDataGridViewTextBoxColumn
            // 
            enlistmentDateDataGridViewTextBoxColumn.DataPropertyName = "EnlistmentDate";
            enlistmentDateDataGridViewTextBoxColumn.HeaderText = "Nhập ngũ";
            enlistmentDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            enlistmentDateDataGridViewTextBoxColumn.Name = "enlistmentDateDataGridViewTextBoxColumn";
            enlistmentDateDataGridViewTextBoxColumn.ReadOnly = true;
            enlistmentDateDataGridViewTextBoxColumn.Width = 127;
            // 
            // averageScoreDataGridViewTextBoxColumn
            // 
            averageScoreDataGridViewTextBoxColumn.DataPropertyName = "AverageScore";
            averageScoreDataGridViewTextBoxColumn.HeaderText = "Điểm trung bình";
            averageScoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            averageScoreDataGridViewTextBoxColumn.Name = "averageScoreDataGridViewTextBoxColumn";
            averageScoreDataGridViewTextBoxColumn.ReadOnly = true;
            averageScoreDataGridViewTextBoxColumn.Width = 178;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Chức vụ";
            roleDataGridViewTextBoxColumn.MinimumWidth = 8;
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.ReadOnly = true;
            roleDataGridViewTextBoxColumn.Width = 112;
            // 
            // fatherFullNameDataGridViewTextBoxColumn
            // 
            fatherFullNameDataGridViewTextBoxColumn.DataPropertyName = "FatherFullName";
            fatherFullNameDataGridViewTextBoxColumn.HeaderText = "Tên Cha";
            fatherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherFullNameDataGridViewTextBoxColumn.Name = "fatherFullNameDataGridViewTextBoxColumn";
            fatherFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            fatherFullNameDataGridViewTextBoxColumn.Width = 109;
            // 
            // fatherPhoneNumberDataGridViewTextBoxColumn
            // 
            fatherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "FatherPhoneNumber";
            fatherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "SĐT Cha";
            fatherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherPhoneNumberDataGridViewTextBoxColumn.Name = "fatherPhoneNumberDataGridViewTextBoxColumn";
            fatherPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            fatherPhoneNumberDataGridViewTextBoxColumn.Width = 115;
            // 
            // motherFullNameDataGridViewTextBoxColumn
            // 
            motherFullNameDataGridViewTextBoxColumn.DataPropertyName = "MotherFullName";
            motherFullNameDataGridViewTextBoxColumn.HeaderText = "Tên Mẹ";
            motherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherFullNameDataGridViewTextBoxColumn.Name = "motherFullNameDataGridViewTextBoxColumn";
            motherFullNameDataGridViewTextBoxColumn.ReadOnly = true;
            motherFullNameDataGridViewTextBoxColumn.Width = 104;
            // 
            // motherPhoneNumberDataGridViewTextBoxColumn
            // 
            motherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "MotherPhoneNumber";
            motherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "SĐT Mẹ";
            motherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherPhoneNumberDataGridViewTextBoxColumn.Name = "motherPhoneNumberDataGridViewTextBoxColumn";
            motherPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            motherPhoneNumberDataGridViewTextBoxColumn.Width = 110;
            // 
            // avatarUrlDataGridViewTextBoxColumn
            // 
            avatarUrlDataGridViewTextBoxColumn.DataPropertyName = "AvatarUrl";
            avatarUrlDataGridViewTextBoxColumn.HeaderText = "AvatarUrl";
            avatarUrlDataGridViewTextBoxColumn.MinimumWidth = 8;
            avatarUrlDataGridViewTextBoxColumn.Name = "avatarUrlDataGridViewTextBoxColumn";
            avatarUrlDataGridViewTextBoxColumn.ReadOnly = true;
            avatarUrlDataGridViewTextBoxColumn.Visible = false;
            avatarUrlDataGridViewTextBoxColumn.Width = 121;
            // 
            // traineeBindingSource
            // 
            traineeBindingSource.DataSource = typeof(Domain.Entities.Trainee);
            // 
            // tabGrades
            // 
            tabGrades.Controls.Add(dgvGrades);
            tabGrades.Location = new Point(4, 34);
            tabGrades.Name = "tabGrades";
            tabGrades.Padding = new Padding(3);
            tabGrades.Size = new Size(1298, 323);
            tabGrades.TabIndex = 1;
            tabGrades.Text = "Điểm môn học";
            tabGrades.UseVisualStyleBackColor = true;
            // 
            // dgvGrades
            // 
            dgvGrades.AllowUserToAddRows = false;
            dgvGrades.AllowUserToOrderColumns = true;
            dgvGrades.AutoGenerateColumns = false;
            dgvGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrades.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, traineeIdDataGridViewTextBoxColumn, subjectIdDataGridViewTextBoxColumn, subjectNameDataGridViewTextBoxColumn, typeDataGridViewTextBoxColumn, gradeDataGridViewTextBoxColumn });
            dgvGrades.DataSource = gradesBindingSource;
            dgvGrades.Dock = DockStyle.Fill;
            dgvGrades.Location = new Point(3, 3);
            dgvGrades.Name = "dgvGrades";
            dgvGrades.ReadOnly = true;
            dgvGrades.RowHeadersWidth = 62;
            dgvGrades.Size = new Size(1292, 317);
            dgvGrades.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.MinimumWidth = 8;
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            idDataGridViewTextBoxColumn1.Visible = false;
            idDataGridViewTextBoxColumn1.Width = 150;
            // 
            // traineeIdDataGridViewTextBoxColumn
            // 
            traineeIdDataGridViewTextBoxColumn.DataPropertyName = "TraineeId";
            traineeIdDataGridViewTextBoxColumn.HeaderText = "TraineeId";
            traineeIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            traineeIdDataGridViewTextBoxColumn.Name = "traineeIdDataGridViewTextBoxColumn";
            traineeIdDataGridViewTextBoxColumn.ReadOnly = true;
            traineeIdDataGridViewTextBoxColumn.Visible = false;
            traineeIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // subjectIdDataGridViewTextBoxColumn
            // 
            subjectIdDataGridViewTextBoxColumn.DataPropertyName = "SubjectId";
            subjectIdDataGridViewTextBoxColumn.HeaderText = "SubjectId";
            subjectIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            subjectIdDataGridViewTextBoxColumn.Name = "subjectIdDataGridViewTextBoxColumn";
            subjectIdDataGridViewTextBoxColumn.ReadOnly = true;
            subjectIdDataGridViewTextBoxColumn.Visible = false;
            subjectIdDataGridViewTextBoxColumn.Width = 150;
            // 
            // subjectNameDataGridViewTextBoxColumn
            // 
            subjectNameDataGridViewTextBoxColumn.DataPropertyName = "SubjectName";
            subjectNameDataGridViewTextBoxColumn.HeaderText = "Môn học";
            subjectNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            subjectNameDataGridViewTextBoxColumn.Name = "subjectNameDataGridViewTextBoxColumn";
            subjectNameDataGridViewTextBoxColumn.ReadOnly = true;
            subjectNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            typeDataGridViewTextBoxColumn.HeaderText = "Loại";
            typeDataGridViewTextBoxColumn.MinimumWidth = 8;
            typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            typeDataGridViewTextBoxColumn.ReadOnly = true;
            typeDataGridViewTextBoxColumn.Width = 150;
            // 
            // gradeDataGridViewTextBoxColumn
            // 
            gradeDataGridViewTextBoxColumn.DataPropertyName = "Grade";
            gradeDataGridViewTextBoxColumn.HeaderText = "Điểm";
            gradeDataGridViewTextBoxColumn.MinimumWidth = 8;
            gradeDataGridViewTextBoxColumn.Name = "gradeDataGridViewTextBoxColumn";
            gradeDataGridViewTextBoxColumn.ReadOnly = true;
            gradeDataGridViewTextBoxColumn.Width = 150;
            // 
            // gradesBindingSource
            // 
            gradesBindingSource.DataSource = typeof(Domain.Entities.Grades);
            // 
            // tabSubjectAverageScore
            // 
            tabSubjectAverageScore.Controls.Add(dgvSubjectAverageScore);
            tabSubjectAverageScore.Location = new Point(4, 34);
            tabSubjectAverageScore.Name = "tabSubjectAverageScore";
            tabSubjectAverageScore.Padding = new Padding(3);
            tabSubjectAverageScore.Size = new Size(1298, 323);
            tabSubjectAverageScore.TabIndex = 2;
            tabSubjectAverageScore.Text = "Điểm trung bình môn học";
            tabSubjectAverageScore.UseVisualStyleBackColor = true;
            // 
            // dgvSubjectAverageScore
            // 
            dgvSubjectAverageScore.AllowUserToAddRows = false;
            dgvSubjectAverageScore.AllowUserToOrderColumns = true;
            dgvSubjectAverageScore.AutoGenerateColumns = false;
            dgvSubjectAverageScore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjectAverageScore.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn2, subjectNameDataGridViewTextBoxColumn1, averageScoreDataGridViewTextBoxColumn1, gradeDataGridViewTextBoxColumn1, semesterDataGridViewTextBoxColumn, schoolYearDataGridViewTextBoxColumn });
            dgvSubjectAverageScore.DataSource = subjectAverageScoreBindingSource;
            dgvSubjectAverageScore.Dock = DockStyle.Fill;
            dgvSubjectAverageScore.Location = new Point(3, 3);
            dgvSubjectAverageScore.Name = "dgvSubjectAverageScore";
            dgvSubjectAverageScore.ReadOnly = true;
            dgvSubjectAverageScore.RowHeadersWidth = 62;
            dgvSubjectAverageScore.Size = new Size(1292, 317);
            dgvSubjectAverageScore.TabIndex = 2;
            // 
            // subjectAverageScoreBindingSource
            // 
            subjectAverageScoreBindingSource.DataSource = typeof(Applications.DTOs.SubjectAverageScoreView);
            // 
            // pnAction
            // 
            pnAction.Controls.Add(btnImportfromExcel);
            pnAction.Controls.Add(btnDelete);
            pnAction.Controls.Add(btnSave);
            pnAction.Controls.Add(btnAdd);
            pnAction.Controls.Add(btnRefresh);
            pnAction.Dock = DockStyle.Fill;
            pnAction.Location = new Point(3, 737);
            pnAction.Name = "pnAction";
            pnAction.Size = new Size(1306, 34);
            pnAction.TabIndex = 2;
            // 
            // btnImportfromExcel
            // 
            btnImportfromExcel.Dock = DockStyle.Right;
            btnImportfromExcel.Location = new Point(1115, 0);
            btnImportfromExcel.Name = "btnImportfromExcel";
            btnImportfromExcel.Size = new Size(191, 34);
            btnImportfromExcel.TabIndex = 6;
            btnImportfromExcel.Text = "Thêm từ file Excel";
            btnImportfromExcel.UseVisualStyleBackColor = true;
            btnImportfromExcel.Click += btnImportfromExcel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.Location = new Point(333, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(111, 34);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.Location = new Point(222, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(111, 34);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.Location = new Point(111, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(111, 34);
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
            btnRefresh.Size = new Size(111, 34);
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
            // idDataGridViewTextBoxColumn2
            // 
            idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn2.HeaderText = "Id";
            idDataGridViewTextBoxColumn2.MinimumWidth = 8;
            idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            idDataGridViewTextBoxColumn2.ReadOnly = true;
            idDataGridViewTextBoxColumn2.Visible = false;
            idDataGridViewTextBoxColumn2.Width = 150;
            // 
            // subjectNameDataGridViewTextBoxColumn1
            // 
            subjectNameDataGridViewTextBoxColumn1.DataPropertyName = "SubjectName";
            subjectNameDataGridViewTextBoxColumn1.HeaderText = "Môn học";
            subjectNameDataGridViewTextBoxColumn1.MinimumWidth = 8;
            subjectNameDataGridViewTextBoxColumn1.Name = "subjectNameDataGridViewTextBoxColumn1";
            subjectNameDataGridViewTextBoxColumn1.ReadOnly = true;
            subjectNameDataGridViewTextBoxColumn1.Width = 150;
            // 
            // averageScoreDataGridViewTextBoxColumn1
            // 
            averageScoreDataGridViewTextBoxColumn1.DataPropertyName = "AverageScore";
            averageScoreDataGridViewTextBoxColumn1.HeaderText = "Điểm TB môn";
            averageScoreDataGridViewTextBoxColumn1.MinimumWidth = 8;
            averageScoreDataGridViewTextBoxColumn1.Name = "averageScoreDataGridViewTextBoxColumn1";
            averageScoreDataGridViewTextBoxColumn1.ReadOnly = true;
            averageScoreDataGridViewTextBoxColumn1.Width = 150;
            // 
            // gradeDataGridViewTextBoxColumn1
            // 
            gradeDataGridViewTextBoxColumn1.DataPropertyName = "Grade";
            gradeDataGridViewTextBoxColumn1.HeaderText = "Xếp loại";
            gradeDataGridViewTextBoxColumn1.MinimumWidth = 8;
            gradeDataGridViewTextBoxColumn1.Name = "gradeDataGridViewTextBoxColumn1";
            gradeDataGridViewTextBoxColumn1.ReadOnly = true;
            gradeDataGridViewTextBoxColumn1.Width = 150;
            // 
            // semesterDataGridViewTextBoxColumn
            // 
            semesterDataGridViewTextBoxColumn.DataPropertyName = "Semester";
            semesterDataGridViewTextBoxColumn.HeaderText = "Học kỳ";
            semesterDataGridViewTextBoxColumn.MinimumWidth = 8;
            semesterDataGridViewTextBoxColumn.Name = "semesterDataGridViewTextBoxColumn";
            semesterDataGridViewTextBoxColumn.ReadOnly = true;
            semesterDataGridViewTextBoxColumn.Visible = false;
            semesterDataGridViewTextBoxColumn.Width = 150;
            // 
            // schoolYearDataGridViewTextBoxColumn
            // 
            schoolYearDataGridViewTextBoxColumn.DataPropertyName = "SchoolYear";
            schoolYearDataGridViewTextBoxColumn.HeaderText = "Niên khóa";
            schoolYearDataGridViewTextBoxColumn.MinimumWidth = 8;
            schoolYearDataGridViewTextBoxColumn.Name = "schoolYearDataGridViewTextBoxColumn";
            schoolYearDataGridViewTextBoxColumn.ReadOnly = true;
            schoolYearDataGridViewTextBoxColumn.Visible = false;
            schoolYearDataGridViewTextBoxColumn.Width = 150;
            // 
            // ucTrainee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "ucTrainee";
            Size = new Size(1312, 774);
            Load += ucTrainee_Load;
            pnInformation.ResumeLayout(false);
            gbDetail.ResumeLayout(false);
            gbDetail.PerformLayout();
            gbGrades.ResumeLayout(false);
            gbGrades.PerformLayout();
            ((ISupportInitialize)numGrade).EndInit();
            ((ISupportInitialize)examTypeBindingSource).EndInit();
            ((ISupportInitialize)subjectBindingSource).EndInit();
            ((ISupportInitialize)numAverageScore).EndInit();
            ((ISupportInitialize)roleBindingSource).EndInit();
            ((ISupportInitialize)classBindingSource).EndInit();
            ((ISupportInitialize)pbAvatar).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabTrainees.ResumeLayout(false);
            ((ISupportInitialize)dgvRead).EndInit();
            ((ISupportInitialize)traineeBindingSource).EndInit();
            tabGrades.ResumeLayout(false);
            ((ISupportInitialize)dgvGrades).EndInit();
            ((ISupportInitialize)gradesBindingSource).EndInit();
            tabSubjectAverageScore.ResumeLayout(false);
            ((ISupportInitialize)dgvSubjectAverageScore).EndInit();
            ((ISupportInitialize)subjectAverageScoreBindingSource).EndInit();
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
        private Button btnSave;
        private Button btnDelete;
        private Button btnUpload;
        private DateTimePicker dtpEnlistmentDate;
        private Label lblId;
        private Label lblRanking;
        private Label lblClassId;
        private ContextMenuStrip contextMenuStrip1;
        private ErrorProvider errorProvider1;
        private ComboBox cbClassId;
        private BindingSource classBindingSource;
        private ComboBox cbRole;
        private Label lblAverageScore;
        private NumericUpDown numAverageScore;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ClassName;
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
        private Button btnImportfromExcel;
        private TabPage tabGrades;
        private ComboBox cbSubject;
        private Label lblSubject;
        private DataGridView dgvGrades;
        private BindingSource gradesBindingSource;
        private BindingSource subjectBindingSource;
        private GroupBox gbGrades;
        private NumericUpDown numGrade;
        private Label lblType;
        private Label lblGrade;
        private ComboBox cbType;
        private Button btnSaveGrade;
        private BindingSource roleBindingSource;
        private BindingSource examTypeBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn traineeIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subjectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subjectNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gradeDataGridViewTextBoxColumn;
        private TabPage tabSubjectAverageScore;
        private DataGridView dgvSubjectAverageScore;
        private BindingSource subjectAverageScoreBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn subjectNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn averageScoreDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn gradeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn semesterDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn schoolYearDataGridViewTextBoxColumn;
    }
}
