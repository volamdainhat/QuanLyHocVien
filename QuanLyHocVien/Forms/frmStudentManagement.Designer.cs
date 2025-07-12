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
            dtgListStudent = new DataGridView();
            lbTotalRows = new Label();
            lbTotalPage = new Label();
            btnMoveLast = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            lbCurrentPage = new Label();
            label2 = new Label();
            btnAddStudent = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgListStudent).BeginInit();
            SuspendLayout();
            // 
            // lbListStudent
            // 
            lbListStudent.AutoSize = true;
            lbListStudent.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbListStudent.Location = new Point(8, 5);
            lbListStudent.Margin = new Padding(2, 0, 2, 0);
            lbListStudent.Name = "lbListStudent";
            lbListStudent.Size = new Size(184, 21);
            lbListStudent.TabIndex = 16;
            lbListStudent.Text = "DANH SÁCH HỌC VIÊN";
            // 
            // dtgListStudent
            // 
            dtgListStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgListStudent.Location = new Point(8, 26);
            dtgListStudent.Margin = new Padding(2);
            dtgListStudent.Name = "dtgListStudent";
            dtgListStudent.RowHeadersWidth = 62;
            dtgListStudent.Size = new Size(864, 345);
            dtgListStudent.TabIndex = 17;
            dtgListStudent.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lbTotalRows
            // 
            lbTotalRows.AutoSize = true;
            lbTotalRows.Location = new Point(8, 378);
            lbTotalRows.Margin = new Padding(2, 0, 2, 0);
            lbTotalRows.Name = "lbTotalRows";
            lbTotalRows.Size = new Size(37, 15);
            lbTotalRows.TabIndex = 18;
            lbTotalRows.Text = "Trang";
            // 
            // lbTotalPage
            // 
            lbTotalPage.AutoSize = true;
            lbTotalPage.Location = new Point(90, 378);
            lbTotalPage.Margin = new Padding(2, 0, 2, 0);
            lbTotalPage.Name = "lbTotalPage";
            lbTotalPage.Size = new Size(13, 15);
            lbTotalPage.TabIndex = 19;
            lbTotalPage.Text = "0";
            // 
            // btnMoveLast
            // 
            btnMoveLast.Location = new Point(795, 375);
            btnMoveLast.Margin = new Padding(2);
            btnMoveLast.Name = "btnMoveLast";
            btnMoveLast.Size = new Size(77, 20);
            btnMoveLast.TabIndex = 20;
            btnMoveLast.Text = ">>";
            btnMoveLast.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(714, 375);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(77, 20);
            button1.TabIndex = 21;
            button1.Text = ">";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(633, 375);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(77, 20);
            button2.TabIndex = 22;
            button2.Text = "<";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(552, 375);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(77, 20);
            button3.TabIndex = 23;
            button3.Text = "<<";
            button3.UseVisualStyleBackColor = true;
            // 
            // lbCurrentPage
            // 
            lbCurrentPage.AutoSize = true;
            lbCurrentPage.Location = new Point(52, 378);
            lbCurrentPage.Margin = new Padding(2, 0, 2, 0);
            lbCurrentPage.Name = "lbCurrentPage";
            lbCurrentPage.Size = new Size(13, 15);
            lbCurrentPage.TabIndex = 24;
            lbCurrentPage.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 378);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(12, 15);
            label2.TabIndex = 25;
            label2.Text = "/";
            // 
            // btnAddStudent
            // 
            btnAddStudent.Location = new Point(714, 2);
            btnAddStudent.Margin = new Padding(2);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(158, 20);
            btnAddStudent.TabIndex = 26;
            btnAddStudent.Text = "Thêm học viên mới";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // frmStudentManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 398);
            Controls.Add(btnAddStudent);
            Controls.Add(label2);
            Controls.Add(lbCurrentPage);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnMoveLast);
            Controls.Add(lbTotalPage);
            Controls.Add(lbTotalRows);
            Controls.Add(dtgListStudent);
            Controls.Add(lbListStudent);
            Margin = new Padding(2);
            Name = "frmStudentManagement";
            Text = "frmStudentManagement";
            ((System.ComponentModel.ISupportInitialize)dtgListStudent).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lbListStudent;
        private DataGridView dtgListStudent;
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