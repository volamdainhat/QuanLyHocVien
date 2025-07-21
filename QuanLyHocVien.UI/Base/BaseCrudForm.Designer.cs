namespace QuanLyHocVien.UI.Base
{
    partial class BaseCrudForm
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
            pnView = new Panel();
            dgvRead = new DataGridView();
            tsBehavior = new ToolStrip();
            btnPrev = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            txtPageNumber = new ToolStripTextBox();
            lblTotalPages = new ToolStripLabel();
            toolStripSeparator2 = new ToolStripSeparator();
            btnNext = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnRefresh = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnSearch = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnAdd = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            btnEdit = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            groupBox1 = new GroupBox();
            tpnDetails = new TableLayoutPanel();
            btnSave = new Button();
            pnView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            tsBehavior.SuspendLayout();
            tpnDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pnView
            // 
            pnView.Controls.Add(dgvRead);
            pnView.Controls.Add(tsBehavior);
            pnView.Dock = DockStyle.Left;
            pnView.Location = new Point(0, 0);
            pnView.Name = "pnView";
            pnView.Size = new Size(800, 664);
            pnView.TabIndex = 0;
            // 
            // dgvRead
            // 
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(0, 33);
            dgvRead.Name = "dgvRead";
            dgvRead.RowHeadersWidth = 62;
            dgvRead.Size = new Size(800, 631);
            dgvRead.TabIndex = 1;
            // 
            // tsBehavior
            // 
            tsBehavior.ImageScalingSize = new Size(24, 24);
            tsBehavior.Items.AddRange(new ToolStripItem[] { btnPrev, toolStripSeparator1, txtPageNumber, lblTotalPages, toolStripSeparator2, btnNext, toolStripSeparator3, btnRefresh, toolStripSeparator4, btnSearch, toolStripSeparator5, btnAdd, toolStripSeparator6, btnEdit, toolStripSeparator7, btnDelete });
            tsBehavior.Location = new Point(0, 0);
            tsBehavior.Name = "tsBehavior";
            tsBehavior.Size = new Size(800, 33);
            tsBehavior.TabIndex = 0;
            tsBehavior.Text = "toolStrip1";
            // 
            // btnPrev
            // 
            btnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrev.Image = Properties.Resources.arrow_circle_left;
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(34, 28);
            btnPrev.Text = "btnPrev";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 33);
            // 
            // txtPageNumber
            // 
            txtPageNumber.Name = "txtPageNumber";
            txtPageNumber.Size = new Size(100, 33);
            // 
            // lblTotalPages
            // 
            lblTotalPages.Name = "lblTotalPages";
            lblTotalPages.Size = new Size(44, 28);
            lblTotalPages.Text = "of 0";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 33);
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = Properties.Resources.arrow_circle_right;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(34, 28);
            btnNext.Text = "toolStripButton3";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 33);
            // 
            // btnRefresh
            // 
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRefresh.Image = Properties.Resources.refresh;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(34, 28);
            btnRefresh.Text = "toolStripButton7";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 33);
            // 
            // btnSearch
            // 
            btnSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSearch.Image = Properties.Resources.search;
            btnSearch.ImageTransparentColor = Color.Magenta;
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(34, 28);
            btnSearch.Text = "toolStripButton6";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 33);
            // 
            // btnAdd
            // 
            btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdd.Image = Properties.Resources.add;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(34, 28);
            btnAdd.Text = "toolStripButton5";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 33);
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEdit.Enabled = false;
            btnEdit.Image = Properties.Resources.pen_circle;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(34, 28);
            btnEdit.Text = "toolStripButton1";
            btnEdit.Visible = false;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 33);
            toolStripSeparator7.Visible = false;
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDelete.Image = Properties.Resources.cross_circle;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(34, 28);
            btnDelete.Text = "toolStripButton4";
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(452, 618);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin chi tiết";
            // 
            // tpnDetails
            // 
            tpnDetails.ColumnCount = 1;
            tpnDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tpnDetails.Controls.Add(groupBox1, 0, 0);
            tpnDetails.Controls.Add(btnSave, 0, 1);
            tpnDetails.Dock = DockStyle.Fill;
            tpnDetails.Location = new Point(800, 0);
            tpnDetails.Name = "tpnDetails";
            tpnDetails.RowCount = 2;
            tpnDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tpnDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tpnDetails.Size = new Size(458, 664);
            tpnDetails.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.Dock = DockStyle.Right;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Transparent;
            btnSave.Location = new Point(343, 627);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // BaseCrudForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(tpnDetails);
            Controls.Add(pnView);
            Name = "BaseCrudForm";
            Text = "Danh sách";
            Load += BaseCrudForm_Load;
            pnView.ResumeLayout(false);
            pnView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            tsBehavior.ResumeLayout(false);
            tsBehavior.PerformLayout();
            tpnDetails.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnView;
        private DataGridView dgvRead;
        private ToolStrip tsBehavior;
        private GroupBox groupBox1;
        private ToolStripButton btnPrev;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox txtPageNumber;
        private ToolStripLabel lblTotalPages;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnNext;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnAdd;
        private ToolStripButton btnEdit;
        private ToolStripButton btnDelete;
        private ToolStripButton btnSearch;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private TableLayoutPanel tpnDetails;
        private Button btnSave;
    }
}