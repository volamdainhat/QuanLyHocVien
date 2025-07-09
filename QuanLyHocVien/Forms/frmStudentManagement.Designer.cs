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
            FullName = new Label();
            SuspendLayout();
            // 
            // FullName
            // 
            FullName.AutoSize = true;
            FullName.Location = new Point(12, 9);
            FullName.Name = "FullName";
            FullName.Size = new Size(89, 25);
            FullName.TabIndex = 0;
            FullName.Text = "Họ và tên";
            // 
            // frmStudentManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 854);
            Controls.Add(FullName);
            Name = "frmStudentManagement";
            Text = "frmStudentManagement";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label FullName;
    }
}