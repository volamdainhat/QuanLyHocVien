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
            numAverageScore = new NumericUpDown();
            lblAverageScore = new Label();
            cbRole = new ComboBox();
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
            pnAction = new Panel();
            btnImportfromExcel = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            errorProvider1 = new ErrorProvider(components);
            pnInformation.SuspendLayout();
            gbDetail.SuspendLayout();
            ((ISupportInitialize)numAverageScore).BeginInit();
            ((ISupportInitialize)classBindingSource).BeginInit();
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
            pnInformation.Location = new Point(2, 2);
            pnInformation.Margin = new Padding(2);
            pnInformation.Name = "pnInformation";
            pnInformation.Size = new Size(892, 200);
            pnInformation.TabIndex = 0;
            // 
            // gbDetail
            // 
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
            gbDetail.Margin = new Padding(2);
            gbDetail.Name = "gbDetail";
            gbDetail.Padding = new Padding(2);
            gbDetail.Size = new Size(892, 200);
            gbDetail.TabIndex = 0;
            gbDetail.TabStop = false;
            gbDetail.Text = "Thông tin học viên";
            // 
            // numAverageScore
            // 
            numAverageScore.DecimalPlaces = 2;
            numAverageScore.Location = new Point(345, 124);
            numAverageScore.Margin = new Padding(2);
            numAverageScore.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numAverageScore.Name = "numAverageScore";
            numAverageScore.Size = new Size(210, 21);
            numAverageScore.TabIndex = 31;
            // 
            // lblAverageScore
            // 
            lblAverageScore.AutoSize = true;
            lblAverageScore.Location = new Point(244, 126);
            lblAverageScore.Margin = new Padding(2, 0, 2, 0);
            lblAverageScore.Name = "lblAverageScore";
            lblAverageScore.Size = new Size(95, 15);
            lblAverageScore.TabIndex = 30;
            lblAverageScore.Text = "Điểm trung bình";
            // 
            // cbRole
            // 
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRole.FormattingEnabled = true;
            cbRole.Location = new Point(345, 101);
            cbRole.Margin = new Padding(2);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(211, 23);
            cbRole.TabIndex = 29;
            // 
            // cbClassId
            // 
            cbClassId.DataSource = classBindingSource;
            cbClassId.DisplayMember = "Name";
            cbClassId.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClassId.FormattingEnabled = true;
            cbClassId.Location = new Point(113, 80);
            cbClassId.Margin = new Padding(2);
            cbClassId.Name = "cbClassId";
            cbClassId.Size = new Size(129, 23);
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
            lblRanking.Location = new Point(113, 103);
            lblRanking.Margin = new Padding(2, 0, 2, 0);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(53, 15);
            lblRanking.TabIndex = 27;
            lblRanking.Text = "Cấp bậc";
            // 
            // lblClassId
            // 
            lblClassId.AutoSize = true;
            lblClassId.Location = new Point(113, 59);
            lblClassId.Margin = new Padding(2, 0, 2, 0);
            lblClassId.Name = "lblClassId";
            lblClassId.Size = new Size(29, 15);
            lblClassId.TabIndex = 26;
            lblClassId.Text = "Lớp";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(113, 14);
            lblId.Margin = new Padding(2, 0, 2, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(71, 15);
            lblId.TabIndex = 25;
            lblId.Text = "Mã học viên";
            // 
            // dtpEnlistmentDate
            // 
            dtpEnlistmentDate.CustomFormat = "dd/MM/yyyy";
            dtpEnlistmentDate.Format = DateTimePickerFormat.Custom;
            dtpEnlistmentDate.Location = new Point(345, 79);
            dtpEnlistmentDate.Margin = new Padding(2);
            dtpEnlistmentDate.Name = "dtpEnlistmentDate";
            dtpEnlistmentDate.Size = new Size(211, 21);
            dtpEnlistmentDate.TabIndex = 24;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(18, 142);
            btnUpload.Margin = new Padding(2);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(78, 20);
            btnUpload.TabIndex = 23;
            btnUpload.Text = "Cập nhật";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += BtnUpload_ClickAsync;
            // 
            // txtMotherPhoneNumber
            // 
            txtMotherPhoneNumber.Location = new Point(662, 79);
            txtMotherPhoneNumber.Margin = new Padding(2);
            txtMotherPhoneNumber.Mask = "0000 000 000";
            txtMotherPhoneNumber.Name = "txtMotherPhoneNumber";
            txtMotherPhoneNumber.ResetOnSpace = false;
            txtMotherPhoneNumber.Size = new Size(211, 21);
            txtMotherPhoneNumber.TabIndex = 21;
            txtMotherPhoneNumber.Click += txtMotherPhoneNumber_Click;
            txtMotherPhoneNumber.Enter += txtMotherPhoneNumber_Enter;
            txtMotherPhoneNumber.KeyDown += txtMotherPhoneNumber_KeyDown;
            txtMotherPhoneNumber.Validating += txtMotherPhoneNumber_Validating;
            // 
            // lblMotherPhoneNumber
            // 
            lblMotherPhoneNumber.AutoSize = true;
            lblMotherPhoneNumber.Location = new Point(595, 80);
            lblMotherPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblMotherPhoneNumber.Name = "lblMotherPhoneNumber";
            lblMotherPhoneNumber.Size = new Size(52, 15);
            lblMotherPhoneNumber.TabIndex = 20;
            lblMotherPhoneNumber.Text = "SĐT mẹ";
            // 
            // txtMotherFullName
            // 
            txtMotherFullName.Location = new Point(662, 56);
            txtMotherFullName.Margin = new Padding(2);
            txtMotherFullName.Name = "txtMotherFullName";
            txtMotherFullName.Size = new Size(211, 21);
            txtMotherFullName.TabIndex = 19;
            // 
            // lblMotherFullName
            // 
            lblMotherFullName.AutoSize = true;
            lblMotherFullName.Location = new Point(595, 58);
            lblMotherFullName.Margin = new Padding(2, 0, 2, 0);
            lblMotherFullName.Name = "lblMotherFullName";
            lblMotherFullName.Size = new Size(49, 15);
            lblMotherFullName.TabIndex = 18;
            lblMotherFullName.Text = "Tên mẹ";
            // 
            // txtFatherPhoneNumber
            // 
            txtFatherPhoneNumber.Location = new Point(662, 34);
            txtFatherPhoneNumber.Margin = new Padding(2);
            txtFatherPhoneNumber.Mask = "0000 000 000";
            txtFatherPhoneNumber.Name = "txtFatherPhoneNumber";
            txtFatherPhoneNumber.ResetOnSpace = false;
            txtFatherPhoneNumber.Size = new Size(211, 21);
            txtFatherPhoneNumber.TabIndex = 17;
            txtFatherPhoneNumber.Click += txtFatherPhoneNumber_Click;
            txtFatherPhoneNumber.Enter += txtFatherPhoneNumber_Enter;
            txtFatherPhoneNumber.KeyDown += txtFatherPhoneNumber_KeyDown;
            txtFatherPhoneNumber.Validating += txtFatherPhoneNumber_Validating;
            // 
            // lblFatherPhoneNumber
            // 
            lblFatherPhoneNumber.AutoSize = true;
            lblFatherPhoneNumber.Location = new Point(595, 36);
            lblFatherPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblFatherPhoneNumber.Name = "lblFatherPhoneNumber";
            lblFatherPhoneNumber.Size = new Size(54, 15);
            lblFatherPhoneNumber.TabIndex = 16;
            lblFatherPhoneNumber.Text = "SĐT cha";
            // 
            // txtFatherFullName
            // 
            txtFatherFullName.Location = new Point(662, 12);
            txtFatherFullName.Margin = new Padding(2);
            txtFatherFullName.Name = "txtFatherFullName";
            txtFatherFullName.Size = new Size(211, 21);
            txtFatherFullName.TabIndex = 15;
            // 
            // lblFatherFullName
            // 
            lblFatherFullName.AutoSize = true;
            lblFatherFullName.Location = new Point(595, 14);
            lblFatherFullName.Margin = new Padding(2, 0, 2, 0);
            lblFatherFullName.Name = "lblFatherFullName";
            lblFatherFullName.Size = new Size(51, 15);
            lblFatherFullName.TabIndex = 14;
            lblFatherFullName.Text = "Tên cha";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(289, 103);
            lblRole.Margin = new Padding(2, 0, 2, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(52, 15);
            lblRole.TabIndex = 12;
            lblRole.Text = "Chức vụ";
            // 
            // lblEnlistmentDate
            // 
            lblEnlistmentDate.AutoSize = true;
            lblEnlistmentDate.Location = new Point(279, 80);
            lblEnlistmentDate.Margin = new Padding(2, 0, 2, 0);
            lblEnlistmentDate.Name = "lblEnlistmentDate";
            lblEnlistmentDate.Size = new Size(61, 15);
            lblEnlistmentDate.TabIndex = 10;
            lblEnlistmentDate.Text = "Nhập ngũ";
            // 
            // txtRanking
            // 
            txtRanking.Location = new Point(113, 123);
            txtRanking.Margin = new Padding(2);
            txtRanking.Name = "txtRanking";
            txtRanking.Size = new Size(129, 21);
            txtRanking.TabIndex = 9;
            txtRanking.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpDayOfBirth
            // 
            dtpDayOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDayOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDayOfBirth.Location = new Point(345, 56);
            dtpDayOfBirth.Margin = new Padding(2);
            dtpDayOfBirth.Name = "dtpDayOfBirth";
            dtpDayOfBirth.Size = new Size(211, 21);
            dtpDayOfBirth.TabIndex = 8;
            // 
            // lblDayOfBirth
            // 
            lblDayOfBirth.AutoSize = true;
            lblDayOfBirth.Location = new Point(279, 58);
            lblDayOfBirth.Margin = new Padding(2, 0, 2, 0);
            lblDayOfBirth.Name = "lblDayOfBirth";
            lblDayOfBirth.Size = new Size(62, 15);
            lblDayOfBirth.TabIndex = 7;
            lblDayOfBirth.Text = "Ngày sinh";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(345, 34);
            txtPhoneNumber.Margin = new Padding(2);
            txtPhoneNumber.Mask = "0000 000 000";
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ResetOnSpace = false;
            txtPhoneNumber.Size = new Size(211, 21);
            txtPhoneNumber.TabIndex = 6;
            txtPhoneNumber.Click += txtPhoneNumber_Click;
            txtPhoneNumber.Enter += txtPhoneNumber_Enter;
            txtPhoneNumber.KeyDown += txtPhoneNumber_KeyDown;
            txtPhoneNumber.Validating += txtPhoneNumber_Validating;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(310, 36);
            lblPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(31, 15);
            lblPhoneNumber.TabIndex = 5;
            lblPhoneNumber.Text = "SĐT";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(345, 12);
            txtFullName.Margin = new Padding(2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(211, 21);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(279, 14);
            lblFullName.Margin = new Padding(2, 0, 2, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(58, 15);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(113, 34);
            txtId.Margin = new Padding(2);
            txtId.Name = "txtId";
            txtId.Size = new Size(128, 21);
            txtId.TabIndex = 1;
            txtId.Text = "0";
            txtId.TextAlign = HorizontalAlignment.Center;
            // 
            // pbAvatar
            // 
            pbAvatar.BorderStyle = BorderStyle.Fixed3D;
            pbAvatar.Image = Properties.Resources.avatar;
            pbAvatar.Location = new Point(4, 18);
            pbAvatar.Margin = new Padding(2);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(106, 122);
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
            tableLayoutPanel.Margin = new Padding(2);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tableLayoutPanel.Size = new Size(896, 432);
            tableLayoutPanel.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTrainees);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(2, 206);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(892, 200);
            tabControl.TabIndex = 1;
            // 
            // tabTrainees
            // 
            tabTrainees.Controls.Add(dgvRead);
            tabTrainees.Location = new Point(4, 24);
            tabTrainees.Margin = new Padding(2);
            tabTrainees.Name = "tabTrainees";
            tabTrainees.Padding = new Padding(2);
            tabTrainees.Size = new Size(884, 172);
            tabTrainees.TabIndex = 0;
            tabTrainees.Text = "Danh sách";
            tabTrainees.UseVisualStyleBackColor = true;
            // 
            // dgvRead
            // 
            dgvRead.AllowUserToAddRows = false;
            dgvRead.AutoGenerateColumns = false;
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, fullNameDataGridViewTextBoxColumn, classIdDataGridViewTextBoxColumn, ClassName, phoneNumberDataGridViewTextBoxColumn, dayOfBirthDataGridViewTextBoxColumn, rankingDataGridViewTextBoxColumn, enlistmentDateDataGridViewTextBoxColumn, averageScoreDataGridViewTextBoxColumn, roleDataGridViewTextBoxColumn, fatherFullNameDataGridViewTextBoxColumn, fatherPhoneNumberDataGridViewTextBoxColumn, motherFullNameDataGridViewTextBoxColumn, motherPhoneNumberDataGridViewTextBoxColumn, avatarUrlDataGridViewTextBoxColumn });
            dgvRead.DataSource = traineeBindingSource;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(2, 2);
            dgvRead.Margin = new Padding(2);
            dgvRead.Name = "dgvRead";
            dgvRead.RowHeadersWidth = 62;
            dgvRead.Size = new Size(880, 168);
            dgvRead.TabIndex = 0;
            dgvRead.SelectionChanged += dgvRead_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Mã học viên";
            idDataGridViewTextBoxColumn.MinimumWidth = 8;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 88;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            fullNameDataGridViewTextBoxColumn.HeaderText = "Họ và tên";
            fullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            fullNameDataGridViewTextBoxColumn.Width = 77;
            // 
            // classIdDataGridViewTextBoxColumn
            // 
            classIdDataGridViewTextBoxColumn.DataPropertyName = "ClassId";
            classIdDataGridViewTextBoxColumn.HeaderText = "Mã lớp";
            classIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            classIdDataGridViewTextBoxColumn.Name = "classIdDataGridViewTextBoxColumn";
            classIdDataGridViewTextBoxColumn.Visible = false;
            classIdDataGridViewTextBoxColumn.Width = 104;
            // 
            // ClassName
            // 
            ClassName.DataPropertyName = "ClassName";
            ClassName.HeaderText = "Lớp";
            ClassName.MinimumWidth = 8;
            ClassName.Name = "ClassName";
            ClassName.Width = 54;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "SĐT";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.Width = 56;
            // 
            // dayOfBirthDataGridViewTextBoxColumn
            // 
            dayOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DayOfBirth";
            dayOfBirthDataGridViewTextBoxColumn.HeaderText = "Ngày sinh";
            dayOfBirthDataGridViewTextBoxColumn.MinimumWidth = 8;
            dayOfBirthDataGridViewTextBoxColumn.Name = "dayOfBirthDataGridViewTextBoxColumn";
            dayOfBirthDataGridViewTextBoxColumn.Width = 80;
            // 
            // rankingDataGridViewTextBoxColumn
            // 
            rankingDataGridViewTextBoxColumn.DataPropertyName = "Ranking";
            rankingDataGridViewTextBoxColumn.HeaderText = "Cấp bậc";
            rankingDataGridViewTextBoxColumn.MinimumWidth = 8;
            rankingDataGridViewTextBoxColumn.Name = "rankingDataGridViewTextBoxColumn";
            rankingDataGridViewTextBoxColumn.Width = 72;
            // 
            // enlistmentDateDataGridViewTextBoxColumn
            // 
            enlistmentDateDataGridViewTextBoxColumn.DataPropertyName = "EnlistmentDate";
            enlistmentDateDataGridViewTextBoxColumn.HeaderText = "Nhập ngũ";
            enlistmentDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            enlistmentDateDataGridViewTextBoxColumn.Name = "enlistmentDateDataGridViewTextBoxColumn";
            enlistmentDateDataGridViewTextBoxColumn.Width = 79;
            // 
            // averageScoreDataGridViewTextBoxColumn
            // 
            averageScoreDataGridViewTextBoxColumn.DataPropertyName = "AverageScore";
            averageScoreDataGridViewTextBoxColumn.HeaderText = "Điểm trung bình";
            averageScoreDataGridViewTextBoxColumn.MinimumWidth = 8;
            averageScoreDataGridViewTextBoxColumn.Name = "averageScoreDataGridViewTextBoxColumn";
            averageScoreDataGridViewTextBoxColumn.Width = 88;
            // 
            // roleDataGridViewTextBoxColumn
            // 
            roleDataGridViewTextBoxColumn.DataPropertyName = "Role";
            roleDataGridViewTextBoxColumn.HeaderText = "Chức vụ";
            roleDataGridViewTextBoxColumn.MinimumWidth = 8;
            roleDataGridViewTextBoxColumn.Name = "roleDataGridViewTextBoxColumn";
            roleDataGridViewTextBoxColumn.Width = 71;
            // 
            // fatherFullNameDataGridViewTextBoxColumn
            // 
            fatherFullNameDataGridViewTextBoxColumn.DataPropertyName = "FatherFullName";
            fatherFullNameDataGridViewTextBoxColumn.HeaderText = "Tên Cha";
            fatherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherFullNameDataGridViewTextBoxColumn.Name = "fatherFullNameDataGridViewTextBoxColumn";
            fatherFullNameDataGridViewTextBoxColumn.Width = 73;
            // 
            // fatherPhoneNumberDataGridViewTextBoxColumn
            // 
            fatherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "FatherPhoneNumber";
            fatherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "SĐT Cha";
            fatherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            fatherPhoneNumberDataGridViewTextBoxColumn.Name = "fatherPhoneNumberDataGridViewTextBoxColumn";
            fatherPhoneNumberDataGridViewTextBoxColumn.Width = 76;
            // 
            // motherFullNameDataGridViewTextBoxColumn
            // 
            motherFullNameDataGridViewTextBoxColumn.DataPropertyName = "MotherFullName";
            motherFullNameDataGridViewTextBoxColumn.HeaderText = "Tên Mẹ";
            motherFullNameDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherFullNameDataGridViewTextBoxColumn.Name = "motherFullNameDataGridViewTextBoxColumn";
            motherFullNameDataGridViewTextBoxColumn.Width = 67;
            // 
            // motherPhoneNumberDataGridViewTextBoxColumn
            // 
            motherPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "MotherPhoneNumber";
            motherPhoneNumberDataGridViewTextBoxColumn.HeaderText = "SĐT Mẹ";
            motherPhoneNumberDataGridViewTextBoxColumn.MinimumWidth = 8;
            motherPhoneNumberDataGridViewTextBoxColumn.Name = "motherPhoneNumberDataGridViewTextBoxColumn";
            motherPhoneNumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // avatarUrlDataGridViewTextBoxColumn
            // 
            avatarUrlDataGridViewTextBoxColumn.DataPropertyName = "AvatarUrl";
            avatarUrlDataGridViewTextBoxColumn.HeaderText = "AvatarUrl";
            avatarUrlDataGridViewTextBoxColumn.MinimumWidth = 8;
            avatarUrlDataGridViewTextBoxColumn.Name = "avatarUrlDataGridViewTextBoxColumn";
            avatarUrlDataGridViewTextBoxColumn.Visible = false;
            avatarUrlDataGridViewTextBoxColumn.Width = 121;
            // 
            // traineeBindingSource
            // 
            traineeBindingSource.DataSource = typeof(Domain.Entities.Trainee);
            // 
            // pnAction
            // 
            pnAction.Controls.Add(btnImportfromExcel);
            pnAction.Controls.Add(btnDelete);
            pnAction.Controls.Add(btnSave);
            pnAction.Controls.Add(btnAdd);
            pnAction.Controls.Add(btnRefresh);
            pnAction.Dock = DockStyle.Fill;
            pnAction.Location = new Point(2, 410);
            pnAction.Margin = new Padding(2);
            pnAction.Name = "pnAction";
            pnAction.Size = new Size(892, 20);
            pnAction.TabIndex = 2;
            // 
            // btnImportfromExcel
            // 
            btnImportfromExcel.Dock = DockStyle.Right;
            btnImportfromExcel.Location = new Point(758, 0);
            btnImportfromExcel.Margin = new Padding(2);
            btnImportfromExcel.Name = "btnImportfromExcel";
            btnImportfromExcel.Size = new Size(134, 20);
            btnImportfromExcel.TabIndex = 6;
            btnImportfromExcel.Text = "Thêm từ file Excel";
            btnImportfromExcel.UseVisualStyleBackColor = true;
            btnImportfromExcel.Click += btnImportfromExcel_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.Location = new Point(234, 0);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 20);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.Location = new Point(156, 0);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 20);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.Location = new Point(78, 0);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(78, 20);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Left;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(78, 20);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Margin = new Padding(2);
            Name = "ucTrainee";
            Size = new Size(896, 432);
            Load += ucTrainee_Load;
            pnInformation.ResumeLayout(false);
            gbDetail.ResumeLayout(false);
            gbDetail.PerformLayout();
            ((ISupportInitialize)numAverageScore).EndInit();
            ((ISupportInitialize)classBindingSource).EndInit();
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
    }
}
