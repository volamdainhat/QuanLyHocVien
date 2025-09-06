namespace StudentManagementSystem.UI.UserControls
{
    partial class ucStudentMonitoring
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
            splitContainer1 = new SplitContainer();
            txtClassName = new TextBox();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            comboBox3 = new ComboBox();
            label4 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            btnDelete = new Button();
            btnSave = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            dgvRead = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainer1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(972, 554);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Theo dõi tình trang học tập - Vi phạm kỉ luật";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 17);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(txtClassName);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(comboBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Panel2.Controls.Add(dgvRead);
            splitContainer1.Size = new Size(966, 534);
            splitContainer1.SplitterDistance = 253;
            splitContainer1.TabIndex = 0;
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(100, 66);
            txtClassName.Name = "txtClassName";
            txtClassName.ReadOnly = true;
            txtClassName.Size = new Size(198, 21);
            txtClassName.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(comboBox3);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(336, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(627, 248);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Vi phạm ki luật";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(117, 124);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(298, 90);
            textBox1.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 127);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 9;
            label5.Text = "Mô tả vi phạm";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(117, 86);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(228, 21);
            dateTimePicker1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 86);
            label3.Name = "label3";
            label3.Size = new Size(81, 15);
            label3.TabIndex = 7;
            label3.Text = "Ngày vi phạm";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(117, 34);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 6;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 37);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 5;
            label4.Text = "Loại vi phạm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 66);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Lớp";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(100, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(198, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedValueChanged += ComboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 24);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Học viên";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(btnRefresh);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 248);
            panel1.Name = "panel1";
            panel1.Size = new Size(966, 29);
            panel1.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Left;
            btnDelete.Location = new Point(234, 0);
            btnDelete.Margin = new Padding(2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Left;
            btnSave.Location = new Point(156, 0);
            btnSave.Margin = new Padding(2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(78, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Dock = DockStyle.Left;
            btnAdd.Location = new Point(78, 0);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(78, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Left;
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(78, 29);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvRead
            // 
            dgvRead.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(0, 0);
            dgvRead.Name = "dgvRead";
            dgvRead.Size = new Size(966, 277);
            dgvRead.TabIndex = 0;
            // 
            // ucStudentMonitoring
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ucStudentMonitoring";
            Size = new Size(972, 554);
            groupBox1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private DataGridView dgvRead;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private ComboBox comboBox1;
        private ComboBox comboBox3;
        private Label label4;
        private GroupBox groupBox2;
        private TextBox textBox1;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private TextBox txtClassName;
        private Button btnDelete;
        private Button btnSave;
        private Button btnAdd;
        private Button btnRefresh;
    }
}
