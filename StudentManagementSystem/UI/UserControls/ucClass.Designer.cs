namespace StudentManagementSystem.UI.UserControls
{
    partial class ucClass
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
            components = new System.ComponentModel.Container();
            pnAction = new Panel();
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            errorProvider1 = new ErrorProvider(components);
            classBindingSource = new BindingSource(components);
            scheduleBindingSource = new BindingSource(components);
            tlpTimetable = new TableLayoutPanel();
            pnInformation = new Panel();
            gbDetail = new GroupBox();
            txtMaxStudents = new TextBox();
            label1 = new Label();
            txtClassname = new TextBox();
            dtpEnddate = new DateTimePicker();
            txtTotalStudents = new TextBox();
            lblRole = new Label();
            lblEnlistmentDate = new Label();
            dtpStartdate = new DateTimePicker();
            lblDayOfBirth = new Label();
            lblPhoneNumber = new Label();
            txtClassid = new TextBox();
            lblFullName = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tabTrainees = new TabPage();
            dgvRead = new DataGridView();
            totalStudentsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            traineesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            maxStudentsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            endDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tabControl = new TabControl();
            pnAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)classBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scheduleBindingSource).BeginInit();
            tlpTimetable.SuspendLayout();
            pnInformation.SuspendLayout();
            gbDetail.SuspendLayout();
            tabTrainees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // pnAction
            // 
            pnAction.Controls.Add(btnDelete);
            pnAction.Controls.Add(btnSave);
            pnAction.Controls.Add(btnAdd);
            pnAction.Controls.Add(btnRefresh);
            pnAction.Dock = DockStyle.Fill;
            pnAction.Location = new Point(2, 446);
            pnAction.Margin = new Padding(2);
            pnAction.Name = "pnAction";
            pnAction.Size = new Size(921, 21);
            pnAction.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.Location = new Point(234, 0);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 21);
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
            btnSave.Size = new Size(78, 21);
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
            btnAdd.Size = new Size(78, 21);
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
            btnRefresh.Size = new Size(78, 21);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // classBindingSource
            // 
            classBindingSource.DataSource = typeof(Domain.Entities.Class);
            // 
            // scheduleBindingSource
            // 
            scheduleBindingSource.DataSource = typeof(Domain.Entities.Schedule);
            // 
            // tlpTimetable
            // 
            tlpTimetable.ColumnCount = 1;
            tlpTimetable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTimetable.Controls.Add(pnInformation, 0, 0);
            tlpTimetable.Controls.Add(tabControl, 0, 1);
            tlpTimetable.Controls.Add(pnAction, 0, 2);
            tlpTimetable.Dock = DockStyle.Fill;
            tlpTimetable.Location = new Point(0, 0);
            tlpTimetable.Margin = new Padding(2);
            tlpTimetable.Name = "tlpTimetable";
            tlpTimetable.RowCount = 3;
            tlpTimetable.RowStyles.Add(new RowStyle(SizeType.Percent, 54.2792778F));
            tlpTimetable.RowStyles.Add(new RowStyle(SizeType.Percent, 45.7207222F));
            tlpTimetable.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpTimetable.RowStyles.Add(new RowStyle(SizeType.Absolute, 12F));
            tlpTimetable.Size = new Size(925, 469);
            tlpTimetable.TabIndex = 2;
            // 
            // pnInformation
            // 
            pnInformation.Controls.Add(gbDetail);
            pnInformation.Dock = DockStyle.Fill;
            pnInformation.Location = new Point(2, 2);
            pnInformation.Margin = new Padding(2);
            pnInformation.Name = "pnInformation";
            pnInformation.Size = new Size(921, 237);
            pnInformation.TabIndex = 0;
            // 
            // gbDetail
            // 
            gbDetail.Controls.Add(txtMaxStudents);
            gbDetail.Controls.Add(label1);
            gbDetail.Controls.Add(txtClassname);
            gbDetail.Controls.Add(dtpEnddate);
            gbDetail.Controls.Add(txtTotalStudents);
            gbDetail.Controls.Add(lblRole);
            gbDetail.Controls.Add(lblEnlistmentDate);
            gbDetail.Controls.Add(dtpStartdate);
            gbDetail.Controls.Add(lblDayOfBirth);
            gbDetail.Controls.Add(lblPhoneNumber);
            gbDetail.Controls.Add(txtClassid);
            gbDetail.Controls.Add(lblFullName);
            gbDetail.Dock = DockStyle.Fill;
            gbDetail.Location = new Point(0, 0);
            gbDetail.Margin = new Padding(2);
            gbDetail.Name = "gbDetail";
            gbDetail.Padding = new Padding(2);
            gbDetail.Size = new Size(921, 237);
            gbDetail.TabIndex = 0;
            gbDetail.TabStop = false;
            gbDetail.Text = "Thông tin lớp học";
            // 
            // txtMaxStudents
            // 
            txtMaxStudents.Location = new Point(125, 143);
            txtMaxStudents.Margin = new Padding(2);
            txtMaxStudents.Name = "txtMaxStudents";
            txtMaxStudents.Size = new Size(31, 21);
            txtMaxStudents.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 143);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 36;
            label1.Text = "Học viên tối đa";
            // 
            // txtClassname
            // 
            txtClassname.Location = new Point(124, 74);
            txtClassname.Margin = new Padding(2);
            txtClassname.Name = "txtClassname";
            txtClassname.Size = new Size(211, 21);
            txtClassname.TabIndex = 35;
            // 
            // dtpEnddate
            // 
            dtpEnddate.CustomFormat = "dd/MM/yyyy";
            dtpEnddate.Format = DateTimePickerFormat.Custom;
            dtpEnddate.Location = new Point(507, 77);
            dtpEnddate.Margin = new Padding(2);
            dtpEnddate.Name = "dtpEnddate";
            dtpEnddate.Size = new Size(211, 21);
            dtpEnddate.TabIndex = 34;
            // 
            // txtTotalStudents
            // 
            txtTotalStudents.Location = new Point(124, 108);
            txtTotalStudents.Margin = new Padding(2);
            txtTotalStudents.Name = "txtTotalStudents";
            txtTotalStudents.ReadOnly = true;
            txtTotalStudents.Size = new Size(31, 21);
            txtTotalStudents.TabIndex = 33;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(20, 111);
            lblRole.Margin = new Padding(2, 0, 2, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 15);
            lblRole.TabIndex = 32;
            lblRole.Text = "Tổng số học viên";
            // 
            // lblEnlistmentDate
            // 
            lblEnlistmentDate.AutoSize = true;
            lblEnlistmentDate.Location = new Point(408, 77);
            lblEnlistmentDate.Margin = new Padding(2, 0, 2, 0);
            lblEnlistmentDate.Name = "lblEnlistmentDate";
            lblEnlistmentDate.Size = new Size(81, 15);
            lblEnlistmentDate.TabIndex = 31;
            lblEnlistmentDate.Text = "Ngày tổng kết";
            // 
            // dtpStartdate
            // 
            dtpStartdate.CustomFormat = "dd/MM/yyyy";
            dtpStartdate.Format = DateTimePickerFormat.Custom;
            dtpStartdate.Location = new Point(507, 39);
            dtpStartdate.Margin = new Padding(2);
            dtpStartdate.Name = "dtpStartdate";
            dtpStartdate.Size = new Size(211, 21);
            dtpStartdate.TabIndex = 30;
            // 
            // lblDayOfBirth
            // 
            lblDayOfBirth.AutoSize = true;
            lblDayOfBirth.Location = new Point(408, 41);
            lblDayOfBirth.Margin = new Padding(2, 0, 2, 0);
            lblDayOfBirth.Name = "lblDayOfBirth";
            lblDayOfBirth.Size = new Size(95, 15);
            lblDayOfBirth.TabIndex = 29;
            lblDayOfBirth.Text = "Ngày khai giảng";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(20, 77);
            lblPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(49, 15);
            lblPhoneNumber.TabIndex = 27;
            lblPhoneNumber.Text = "Tên lớp";
            // 
            // txtClassid
            // 
            txtClassid.Location = new Point(124, 41);
            txtClassid.Margin = new Padding(2);
            txtClassid.Name = "txtClassid";
            txtClassid.ReadOnly = true;
            txtClassid.Size = new Size(211, 21);
            txtClassid.TabIndex = 26;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(21, 44);
            lblFullName.Margin = new Padding(2, 0, 2, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(44, 15);
            lblFullName.TabIndex = 25;
            lblFullName.Text = "Mã lớp";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // tabTrainees
            // 
            tabTrainees.Controls.Add(dgvRead);
            tabTrainees.Location = new Point(4, 24);
            tabTrainees.Margin = new Padding(2);
            tabTrainees.Name = "tabTrainees";
            tabTrainees.Padding = new Padding(2);
            tabTrainees.Size = new Size(913, 171);
            tabTrainees.TabIndex = 0;
            tabTrainees.Text = "Danh sách";
            tabTrainees.UseVisualStyleBackColor = true;
            // 
            // dgvRead
            // 
            dgvRead.AutoGenerateColumns = false;
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, startDateDataGridViewTextBoxColumn, endDateDataGridViewTextBoxColumn, maxStudentsDataGridViewTextBoxColumn, traineesDataGridViewTextBoxColumn, totalStudentsDataGridViewTextBoxColumn });
            dgvRead.DataSource = classBindingSource;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(2, 2);
            dgvRead.Margin = new Padding(2);
            dgvRead.Name = "dgvRead";
            dgvRead.RowHeadersWidth = 62;
            dgvRead.Size = new Size(909, 167);
            dgvRead.TabIndex = 0;
            dgvRead.CellDoubleClick += dgvRead_CellDoubleClick;
            // 
            // totalStudentsDataGridViewTextBoxColumn
            // 
            totalStudentsDataGridViewTextBoxColumn.DataPropertyName = "TotalStudents";
            totalStudentsDataGridViewTextBoxColumn.HeaderText = "Tổng học viên hiện có";
            totalStudentsDataGridViewTextBoxColumn.Name = "totalStudentsDataGridViewTextBoxColumn";
            totalStudentsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // traineesDataGridViewTextBoxColumn
            // 
            traineesDataGridViewTextBoxColumn.DataPropertyName = "Trainees";
            traineesDataGridViewTextBoxColumn.HeaderText = "Trainees";
            traineesDataGridViewTextBoxColumn.Name = "traineesDataGridViewTextBoxColumn";
            traineesDataGridViewTextBoxColumn.Visible = false;
            // 
            // maxStudentsDataGridViewTextBoxColumn
            // 
            maxStudentsDataGridViewTextBoxColumn.DataPropertyName = "MaxStudents";
            maxStudentsDataGridViewTextBoxColumn.HeaderText = "Học viên tối đa";
            maxStudentsDataGridViewTextBoxColumn.Name = "maxStudentsDataGridViewTextBoxColumn";
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            endDateDataGridViewTextBoxColumn.HeaderText = "Ngày tổng kết";
            endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            startDateDataGridViewTextBoxColumn.HeaderText = "Ngày khai giảng";
            startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Tên lớp";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Mã lớp";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTrainees);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(2, 243);
            tabControl.Margin = new Padding(2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(921, 199);
            tabControl.TabIndex = 1;
            // 
            // ucClass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpTimetable);
            Name = "ucClass";
            Size = new Size(925, 469);
            Load += ucClass_Load;
            pnAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)classBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)scheduleBindingSource).EndInit();
            tlpTimetable.ResumeLayout(false);
            pnInformation.ResumeLayout(false);
            gbDetail.ResumeLayout(false);
            gbDetail.PerformLayout();
            tabTrainees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn fatherPhoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn motherPhoneNumberDataGridViewTextBoxColumn;
        private Label lblRanking;
        private Label lblClassId;
        private Label lblId;
        private DateTimePicker dtpEnddate;
        private Button btnUpload;
        private TextBox txtTotalStudents;
        private DataGridViewTextBoxColumn avatarUrlDataGridViewTextBoxColumn;
        private MaskedTextBox txtMotherPhoneNumber;
        private Label lblMotherPhoneNumber;
        private Label lblMotherFullName;
        private DataGridViewTextBoxColumn motherFullNameDataGridViewTextBoxColumn;
        private Panel pnAction;
        private Button btnDelete;
        private Button btnSave;
        private Button btnAdd;
        private Button btnRefresh;
        private TextBox txtMotherFullName;
        private MaskedTextBox txtFatherPhoneNumber;
        private Label lblFatherPhoneNumber;
        private TextBox txtFatherFullName;
        private Label lblFatherFullName;
        private Label lblRole;
        private DataGridViewTextBoxColumn fatherFullNameDataGridViewTextBoxColumn;
        private Label lblEnlistmentDate;
        private DataGridViewTextBoxColumn averageScoreDataGridViewTextBoxColumn;
        private TextBox txtRanking;
        private DateTimePicker dtpStartdate;
        private Label lblDayOfBirth;
        private Label lblPhoneNumber;
        private TextBox txtClassId;
        private TextBox txtClassid;
        private Label lblFullName;
        private DataGridViewTextBoxColumn roleDataGridViewTextBoxColumn;
        private ErrorProvider errorProvider1;
        private TableLayoutPanel tlpTimetable;
        private Panel pnInformation;
        private GroupBox gbDetail;
        private TextBox txtId;
        private PictureBox pbAvatar;
        private DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dayOfBirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rankingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enlistmentDateDataGridViewTextBoxColumn;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtClassname;
        private BindingSource classBindingSource;
        private TextBox txtMaxStudents;
        private Label label1;
        private BindingSource scheduleBindingSource;
        private TabControl tabControl;
        private TabPage tabTrainees;
        private DataGridView dgvRead;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maxStudentsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn traineesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalStudentsDataGridViewTextBoxColumn;
    }
}
