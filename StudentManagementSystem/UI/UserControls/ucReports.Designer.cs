namespace StudentManagementSystem.UI.UserControls
{
    partial class ucReports
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
            comboBoxClass = new ComboBox();
            label1 = new Label();
            dgvReports = new DataGridView();
            panel1 = new Panel();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnGenerate = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(splitContainer1);
            groupBox1.Controls.Add(panel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(886, 542);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Báo cáo - Thống kê ";
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
            splitContainer1.Panel1.Controls.Add(comboBoxClass);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvReports);
            splitContainer1.Size = new Size(880, 495);
            splitContainer1.SplitterDistance = 69;
            splitContainer1.TabIndex = 1;
            // 
            // comboBoxClass
            // 
            comboBoxClass.FormattingEnabled = true;
            comboBoxClass.Location = new Point(182, 24);
            comboBoxClass.Name = "comboBoxClass";
            comboBoxClass.Size = new Size(180, 23);
            comboBoxClass.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 25);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 0;
            label1.Text = "Chọn lớp để tạo báo cáo";
            // 
            // dgvReports
            // 
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Dock = DockStyle.Fill;
            dgvReports.Location = new Point(0, 0);
            dgvReports.Name = "dgvReports";
            dgvReports.Size = new Size(880, 422);
            dgvReports.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnGenerate);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 512);
            panel1.Name = "panel1";
            panel1.Size = new Size(880, 27);
            panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.AutoSize = true;
            btnDelete.Location = new Point(198, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(85, 25);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa báo cáo";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.AutoSize = true;
            btnRefresh.Location = new Point(94, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(98, 25);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Làm mới trang";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            btnGenerate.AutoSize = true;
            btnGenerate.Location = new Point(3, 3);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(85, 25);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Tạo báo cáo";
            btnGenerate.UseVisualStyleBackColor = true;
            // 
            // ucReports
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "ucReports";
            Size = new Size(886, 542);
            groupBox1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Panel panel1;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnGenerate;
        private SplitContainer splitContainer1;
        private ComboBox comboBoxClass;
        private Label label1;
        private DataGridView dgvReports;
    }
}
