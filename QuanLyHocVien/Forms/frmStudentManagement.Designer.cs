namespace QuanLyHocVien
{
    partial class frmStudentManagement
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
            lbListStudent = new Label();
            dataGridView1 = new DataGridView();
            lbTotalRows = new Label();
            lbTotalPage = new Label();
            btnMoveLast = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lbCurrentPage = new Label();
            label2 = new Label();
            btnAddStudent = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbListStudent
            // 
            lbListStudent.AutoSize = true;
            lbListStudent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbListStudent.Location = new Point(12, 9);
            lbListStudent.Name = "lbListStudent";
            lbListStudent.Size = new Size(277, 32);
            lbListStudent.TabIndex = 16;
            lbListStudent.Text = "DANH SÁCH HỌC VIÊN";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1234, 575);
            dataGridView1.TabIndex = 17;
            // 
            // lbTotalRows
            // 
            lbTotalRows.AutoSize = true;
            lbTotalRows.Location = new Point(12, 630);
            lbTotalRows.Name = "lbTotalRows";
            lbTotalRows.Size = new Size(55, 25);
            lbTotalRows.TabIndex = 18;
            lbTotalRows.Text = "Trang";
            // 
            // lbTotalPage
            // 
            lbTotalPage.AutoSize = true;
            lbTotalPage.Location = new Point(128, 630);
            lbTotalPage.Name = "lbTotalPage";
            lbTotalPage.Size = new Size(22, 25);
            lbTotalPage.TabIndex = 19;
            lbTotalPage.Text = "0";
            // 
            // btnMoveLast
            // 
            btnMoveLast.Location = new Point(1136, 625);
            btnMoveLast.Name = "btnMoveLast";
            btnMoveLast.Size = new Size(110, 34);
            btnMoveLast.TabIndex = 20;
            btnMoveLast.Text = ">>";
            btnMoveLast.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(1020, 625);
            button1.Name = "button1";
            button1.Size = new Size(110, 34);
            button1.TabIndex = 21;
            button1.Text = ">";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(904, 625);
            button2.Name = "button2";
            button2.Size = new Size(110, 34);
            button2.TabIndex = 22;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(788, 625);
            button3.Name = "button3";
            button3.Size = new Size(110, 34);
            button3.TabIndex = 23;
            button3.Text = "<<";
            button3.UseVisualStyleBackColor = true;
            // 
            // lbCurrentPage
            // 
            lbCurrentPage.AutoSize = true;
            lbCurrentPage.Location = new Point(75, 630);
            lbCurrentPage.Name = "lbCurrentPage";
            lbCurrentPage.Size = new Size(22, 25);
            lbCurrentPage.TabIndex = 24;
            lbCurrentPage.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(103, 630);
            label2.Name = "label2";
            label2.Size = new Size(19, 25);
            label2.TabIndex = 25;
            label2.Text = "/";
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(1020, 4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(226, 34);
            btnAddStudent.TabIndex = 26;
            btnAddStudent.Text = "Thêm học viên mới";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // frmStudentManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(btnAddStudent);
            Controls.Add(label2);
            Controls.Add(lbCurrentPage);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnMoveLast);
            Controls.Add(lbTotalPage);
            Controls.Add(lbTotalRows);
            Controls.Add(dataGridView1);
            Controls.Add(lbListStudent);
            Name = "frmStudentManagement";
            Text = "frmStudentManagement";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbListStudent;
        private DataGridView dataGridView1;
        private Label lbTotalRows;
        private Label lbTotalPage;
        private Button btnMoveLast;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label lbCurrentPage;
        private Label label2;
        private Button btnAddStudent;
    }
}