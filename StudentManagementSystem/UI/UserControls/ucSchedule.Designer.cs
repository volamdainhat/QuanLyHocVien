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
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            dtpEndDate = new DateTimePicker();
            dtpStartDate = new DateTimePicker();
            chlbDaysofWeek = new CheckedListBox();
            label5 = new Label();
            txtRoom = new TextBox();
            cbPeriod = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            cbClassName = new ComboBox();
            label2 = new Label();
            cbSubject = new ComboBox();
            label1 = new Label();
            panel2 = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnRefresh = new Button();
            btnAddSubject = new Button();
            btnAddNewSubject = new Button();
            splitContainer1 = new SplitContainer();
            mcTimetable = new MonthCalendar();
            dgvRead = new DataGridView();
            sqliteCommand1 = new Microsoft.Data.Sqlite.SqliteCommand();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(869, 508);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thời khóa biểu";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 17);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.Size = new Size(863, 488);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(dtpEndDate);
            panel1.Controls.Add(dtpStartDate);
            panel1.Controls.Add(chlbDaysofWeek);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtRoom);
            panel1.Controls.Add(cbPeriod);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cbClassName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbSubject);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(857, 219);
            panel1.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(379, 169);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 13;
            label7.Text = "Ngày kết thúc";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(379, 130);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 12;
            label6.Text = "Ngày bắt đầu";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(505, 169);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(223, 21);
            dtpEndDate.TabIndex = 11;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(505, 130);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(223, 21);
            dtpStartDate.TabIndex = 10;
            // 
            // chlbDaysofWeek
            // 
            chlbDaysofWeek.FormattingEnabled = true;
            chlbDaysofWeek.Items.AddRange(new object[] { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6" });
            chlbDaysofWeek.Location = new Point(501, 13);
            chlbDaysofWeek.Name = "chlbDaysofWeek";
            chlbDaysofWeek.Size = new Size(120, 84);
            chlbDaysofWeek.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(379, 26);
            label5.Name = "label5";
            label5.Size = new Size(116, 15);
            label5.TabIndex = 8;
            label5.Text = "Ngày học trong tuần";
            // 
            // txtRoom
            // 
            txtRoom.Location = new Point(117, 123);
            txtRoom.Name = "txtRoom";
            txtRoom.Size = new Size(170, 21);
            txtRoom.TabIndex = 7;
            // 
            // cbPeriod
            // 
            cbPeriod.FormattingEnabled = true;
            cbPeriod.Location = new Point(117, 169);
            cbPeriod.Name = "cbPeriod";
            cbPeriod.Size = new Size(87, 23);
            cbPeriod.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 172);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 5;
            label4.Text = "Buổi học";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 126);
            label3.Name = "label3";
            label3.Size = new Size(83, 15);
            label3.TabIndex = 4;
            label3.Text = "Học tại phòng";
            // 
            // cbClassName
            // 
            cbClassName.FormattingEnabled = true;
            cbClassName.Location = new Point(117, 74);
            cbClassName.Name = "cbClassName";
            cbClassName.Size = new Size(170, 23);
            cbClassName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 77);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Lớp";
            // 
            // cbSubject
            // 
            cbSubject.FormattingEnabled = true;
            cbSubject.Location = new Point(117, 23);
            cbSubject.Name = "cbSubject";
            cbSubject.Size = new Size(170, 23);
            cbSubject.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 26);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên môn học";
            // 
            // panel2
            // 
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(btnUpdate);
            panel2.Controls.Add(btnRefresh);
            panel2.Controls.Add(btnAddSubject);
            panel2.Controls.Add(btnAddNewSubject);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 453);
            panel2.Name = "panel2";
            panel2.Size = new Size(857, 32);
            panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(548, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 25);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xóa lịch";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Location = new Point(430, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 25);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Cập nhật lịch học";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new Point(272, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(152, 25);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới thời khóa biểu";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAddSubject
            // 
            btnAddSubject.AutoSize = true;
            btnAddSubject.Location = new Point(114, 3);
            btnAddSubject.Name = "btnAddSubject";
            btnAddSubject.Size = new Size(152, 25);
            btnAddSubject.TabIndex = 1;
            btnAddSubject.Text = "Thêm vào thời khóa biểu";
            btnAddSubject.UseVisualStyleBackColor = true;
            btnAddSubject.Click += btnAddSubject_Click;
            // 
            // btnAddNewSubject
            // 
            btnAddNewSubject.AutoSize = true;
            btnAddNewSubject.Location = new Point(3, 3);
            btnAddNewSubject.Name = "btnAddNewSubject";
            btnAddNewSubject.Size = new Size(109, 25);
            btnAddNewSubject.TabIndex = 0;
            btnAddNewSubject.Text = "Quản lý môn học";
            btnAddNewSubject.UseVisualStyleBackColor = true;
            btnAddNewSubject.Click += btnAddNewSubject_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 228);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(mcTimetable);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvRead);
            splitContainer1.Size = new Size(857, 219);
            splitContainer1.SplitterDistance = 463;
            splitContainer1.TabIndex = 2;
            // 
            // mcTimetable
            // 
            mcTimetable.CalendarDimensions = new Size(2, 1);
            mcTimetable.Dock = DockStyle.Fill;
            mcTimetable.Location = new Point(0, 0);
            mcTimetable.Name = "mcTimetable";
            mcTimetable.TabIndex = 0;
            mcTimetable.DateChanged += mcTimetable_DateChanged;
            // 
            // dgvRead
            // 
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRead.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(0, 0);
            dgvRead.Name = "dgvRead";
            dgvRead.Size = new Size(390, 219);
            dgvRead.TabIndex = 0;
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ucSchedule";
            Size = new Size(869, 508);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TextBox txtRoom;
        private ComboBox cbPeriod;
        private Label label4;
        private Label label3;
        private ComboBox cbClassName;
        private Label label2;
        private ComboBox cbSubject;
        private Label label1;
        private Panel panel2;
        private SplitContainer splitContainer1;
        private MonthCalendar mcTimetable;
        private DataGridView dgvRead;
        private Microsoft.Data.Sqlite.SqliteCommand sqliteCommand1;
        private Label label7;
        private Label label6;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private CheckedListBox chlbDaysofWeek;
        private Label label5;
        private Button btnUpdate;
        private Button btnRefresh;
        private Button btnAddSubject;
        private Button btnAddNewSubject;
        private Button btnDelete;
    }
}
