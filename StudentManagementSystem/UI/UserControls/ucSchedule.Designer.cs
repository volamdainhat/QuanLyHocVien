namespace StudentManagementSystem.UI.UserControls
{
    partial class ucSchedule
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
            groupBox1 = new GroupBox();
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            button1 = new Button();
            btnRefresh = new Button();
            label7 = new Label();
            label6 = new Label();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            chlbDaysofWeek = new CheckedListBox();
            label5 = new Label();
            btnAddSubject = new Button();
            txtRoom = new TextBox();
            label4 = new Label();
            cbPeriod = new ComboBox();
            label3 = new Label();
            cbClassName = new ComboBox();
            label2 = new Label();
            txtSubjectName = new TextBox();
            label1 = new Label();
            splitContainer2 = new SplitContainer();
            mcTimetable = new MonthCalendar();
            dgvRead = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subjectIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            subjectDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roomDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            periodDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            scheduleBindingSource = new BindingSource(components);
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            ((System.ComponentModel.ISupportInitialize)scheduleBindingSource).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainer1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(1417, 932);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thời khóa biểu";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(4, 29);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(btnRefresh);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(dtpEndDate);
            splitContainer1.Panel1.Controls.Add(dtpStartDate);
            splitContainer1.Panel1.Controls.Add(chlbDaysofWeek);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(btnAddSubject);
            splitContainer1.Panel1.Controls.Add(txtRoom);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(cbPeriod);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(cbClassName);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(txtSubjectName);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1409, 898);
            splitContainer1.SplitterDistance = 524;
            splitContainer1.SplitterWidth = 7;
            splitContainer1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(1254, 482);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(126, 38);
            button2.TabIndex = 44;
            button2.Text = "Xóa lịch";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnDelete_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1119, 482);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(127, 38);
            button1.TabIndex = 43;
            button1.Text = "Sửa lịch";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnUpdate_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefresh.Location = new Point(886, 481);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(224, 38);
            btnRefresh.TabIndex = 42;
            btnRefresh.Text = "Làm mới danh sách";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(711, 322);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(122, 25);
            label7.TabIndex = 41;
            label7.Text = "Ngày kết thúc";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(711, 240);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(120, 25);
            label6.TabIndex = 40;
            label6.Text = "Ngày bắt đầu";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(886, 322);
            dtpEndDate.Margin = new Padding(4, 5, 4, 5);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(284, 31);
            dtpEndDate.TabIndex = 39;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(886, 235);
            dtpStartDate.Margin = new Padding(4, 5, 4, 5);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(284, 31);
            dtpStartDate.TabIndex = 38;
            // 
            // chlbDaysofWeek
            // 
            chlbDaysofWeek.FormattingEnabled = true;
            chlbDaysofWeek.Items.AddRange(new object[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6" });
            chlbDaysofWeek.Location = new Point(886, 53);
            chlbDaysofWeek.Margin = new Padding(4, 5, 4, 5);
            chlbDaysofWeek.Name = "chlbDaysofWeek";
            chlbDaysofWeek.Size = new Size(91, 116);
            chlbDaysofWeek.TabIndex = 37;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(711, 57);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(177, 25);
            label5.TabIndex = 36;
            label5.Text = "Ngày học trong tuần";
            // 
            // btnAddSubject
            // 
            btnAddSubject.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddSubject.Location = new Point(710, 481);
            btnAddSubject.Margin = new Padding(4, 5, 4, 5);
            btnAddSubject.Name = "btnAddSubject";
            btnAddSubject.Size = new Size(167, 38);
            btnAddSubject.TabIndex = 34;
            btnAddSubject.Text = "Thêm môn học";
            btnAddSubject.UseVisualStyleBackColor = true;
            btnAddSubject.Click += btnAddSubject_Click;
            // 
            // txtRoom
            // 
            txtRoom.Location = new Point(179, 230);
            txtRoom.Margin = new Padding(4, 5, 4, 5);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(53, 31);
            txtRoom.TabIndex = 33;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 235);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(126, 25);
            label4.TabIndex = 32;
            label4.Text = "Học tại phòng";
            // 
            // cbPeriod
            // 
            cbPeriod.DisplayMember = "Name";
            cbPeriod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPeriod.FormattingEnabled = true;
            cbPeriod.Location = new Point(179, 327);
            cbPeriod.Name = "cbPeriod";
            cbPeriod.Size = new Size(141, 33);
            cbPeriod.TabIndex = 31;
            cbPeriod.ValueMember = "Id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 332);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(81, 25);
            label3.TabIndex = 30;
            label3.Text = "Buổi học";
            // 
            // cbClassName
            // 
            cbClassName.DisplayMember = "Name";
            cbClassName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbClassName.FormattingEnabled = true;
            cbClassName.Location = new Point(179, 135);
            cbClassName.Name = "cbClassName";
            cbClassName.Size = new Size(141, 33);
            cbClassName.TabIndex = 29;
            cbClassName.ValueMember = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 148);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(42, 25);
            label2.TabIndex = 2;
            label2.Text = "Lớp";
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(179, 57);
            txtSubjectName.Margin = new Padding(4, 5, 4, 5);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(141, 31);
            txtSubjectName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 62);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 25);
            label1.TabIndex = 0;
            label1.Text = "Tên môn học";
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(4, 5, 4, 5);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackColor = SystemColors.Control;
            splitContainer2.Panel1.Controls.Add(mcTimetable);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(dgvRead);
            splitContainer2.Size = new Size(1409, 367);
            splitContainer2.SplitterDistance = 668;
            splitContainer2.SplitterWidth = 6;
            splitContainer2.TabIndex = 0;
            // 
            // mcTimetable
            // 
            mcTimetable.CalendarDimensions = new Size(2, 1);
            mcTimetable.Dock = DockStyle.Fill;
            mcTimetable.Location = new Point(0, 0);
            mcTimetable.Margin = new Padding(13, 15, 13, 15);
            mcTimetable.Name = "mcTimetable";
            mcTimetable.TabIndex = 0;
            mcTimetable.DateChanged += mcTimetable_DateChanged;
            // 
            // dgvRead
            // 
            dgvRead.AutoGenerateColumns = false;
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, classIdDataGridViewTextBoxColumn, subjectIdDataGridViewTextBoxColumn, classDataGridViewTextBoxColumn, subjectDataGridViewTextBoxColumn, roomDataGridViewTextBoxColumn, periodDataGridViewTextBoxColumn });
            dgvRead.DataSource = scheduleBindingSource;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(0, 0);
            dgvRead.Margin = new Padding(4, 5, 4, 5);
            dgvRead.Name = "dgvRead";
            dgvRead.RowHeadersWidth = 62;
            dgvRead.Size = new Size(735, 367);
            dgvRead.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 8;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Visible = false;
            // 
            // classIdDataGridViewTextBoxColumn
            // 
            classIdDataGridViewTextBoxColumn.DataPropertyName = "ClassId";
            classIdDataGridViewTextBoxColumn.HeaderText = "ClassId";
            classIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            classIdDataGridViewTextBoxColumn.Name = "classIdDataGridViewTextBoxColumn";
            // 
            // subjectIdDataGridViewTextBoxColumn
            // 
            subjectIdDataGridViewTextBoxColumn.DataPropertyName = "SubjectId";
            subjectIdDataGridViewTextBoxColumn.HeaderText = "SubjectId";
            subjectIdDataGridViewTextBoxColumn.MinimumWidth = 8;
            subjectIdDataGridViewTextBoxColumn.Name = "subjectIdDataGridViewTextBoxColumn";
            // 
            // classDataGridViewTextBoxColumn
            // 
            classDataGridViewTextBoxColumn.DataPropertyName = "Class";
            classDataGridViewTextBoxColumn.HeaderText = "Class";
            classDataGridViewTextBoxColumn.MinimumWidth = 8;
            classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            // 
            // subjectDataGridViewTextBoxColumn
            // 
            subjectDataGridViewTextBoxColumn.DataPropertyName = "Subject";
            subjectDataGridViewTextBoxColumn.HeaderText = "Subject";
            subjectDataGridViewTextBoxColumn.MinimumWidth = 8;
            subjectDataGridViewTextBoxColumn.Name = "subjectDataGridViewTextBoxColumn";
            // 
            // roomDataGridViewTextBoxColumn
            // 
            roomDataGridViewTextBoxColumn.DataPropertyName = "Room";
            roomDataGridViewTextBoxColumn.HeaderText = "Phòng học";
            roomDataGridViewTextBoxColumn.MinimumWidth = 8;
            roomDataGridViewTextBoxColumn.Name = "roomDataGridViewTextBoxColumn";
            // 
            // periodDataGridViewTextBoxColumn
            // 
            periodDataGridViewTextBoxColumn.DataPropertyName = "Period";
            periodDataGridViewTextBoxColumn.HeaderText = "Buổi";
            periodDataGridViewTextBoxColumn.MinimumWidth = 8;
            periodDataGridViewTextBoxColumn.Name = "periodDataGridViewTextBoxColumn";
            // 
            // scheduleBindingSource
            // 
            scheduleBindingSource.DataSource = typeof(Domain.Entities.Schedule);
            // 
            // sqliteCommand1
            // 
            sqliteCommand1.CommandTimeout = 30;
            sqliteCommand1.Connection = null;
            sqliteCommand1.Transaction = null;
            sqliteCommand1.UpdatedRowSource = System.Data.UpdateRowSource.None;
            // 
            // ucSchedule
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ucSchedule";
            Size = new Size(1417, 932);
            groupBox1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ((System.ComponentModel.ISupportInitialize)scheduleBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private BindingSource scheduleBindingSource;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private SplitContainer splitContainer1;
        private Label label1;
        private SplitContainer splitContainer2;
        private MonthCalendar mcTimetable;
        private DataGridView dgvRead;
        private DataGridViewTextBoxColumn dayDataGridViewTextBoxColumn;
        private Label label2;
        private TextBox txtSubjectName;
        private ComboBox cbPeriod;
        private Label label3;
        private ComboBox cbClassName;
        private TextBox txtRoom;
        private Label label4;
        private Button btnAddSubject;
        private Label label5;
        private CheckedListBox chlbDaysofWeek;
        private Label label7;
        private Label label6;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Button btnRefresh;
        private Button button2;
        private Button button1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subjectIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn roomDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn periodDataGridViewTextBoxColumn;
    }
}
