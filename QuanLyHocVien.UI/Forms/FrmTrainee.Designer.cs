namespace QuanLyHocVien.UI.Forms
{
    partial class FrmTrainee
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
            txtFullName = new TextBox();
            lblFullName = new Label();
            lblClassId = new Label();
            txtClassId = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            dtpDayOfBirth = new DateTimePicker();
            lblDayOfBirth = new Label();
            lblRanking = new Label();
            txtRanking = new TextBox();
            lblRole = new Label();
            txtRole = new TextBox();
            lblEnlistmentDate = new Label();
            dtpEnlistmentDate = new DateTimePicker();
            lblFatherFullName = new Label();
            txtFatherFullName = new TextBox();
            lblFatherPhoneNumber = new Label();
            txtFatherPhoneNumber = new TextBox();
            lblMotherPhoneNumber = new Label();
            txtMotherPhoneNumber = new TextBox();
            lblMotherFullName = new Label();
            txtMotherFullName = new TextBox();
            lblId = new Label();
            txtId = new TextBox();
            pictureBox1 = new PictureBox();
            grbDetailInfo = new GroupBox();
            btnSave = new Button();
            btnDelete = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            btnEdit = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            btnAdd = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnSearch = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnRefresh = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnNext = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            lblTotalPages = new ToolStripLabel();
            txtPageNumber = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            btnPrev = new ToolStripButton();
            tsBehavior = new ToolStrip();
            tpnDetails = new TableLayoutPanel();
            pnView = new Panel();
            dgvRead = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tsBehavior.SuspendLayout();
            tpnDetails.SuspendLayout();
            pnView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).BeginInit();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(4, 70);
            txtFullName.Margin = new Padding(2);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(176, 31);
            txtFullName.TabIndex = 0;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(4, 53);
            lblFullName.Margin = new Padding(2, 0, 2, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(58, 15);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Họ và tên";
            // 
            // lblClassId
            // 
            lblClassId.AutoSize = true;
            lblClassId.Location = new Point(4, 202);
            lblClassId.Margin = new Padding(2, 0, 2, 0);
            lblClassId.Name = "lblClassId";
            lblClassId.Size = new Size(44, 15);
            lblClassId.TabIndex = 2;
            lblClassId.Text = "Mã lớp";
            // 
            // txtClassId
            // 
            txtClassId.Location = new Point(4, 219);
            txtClassId.Margin = new Padding(2);
            txtClassId.Name = "txtClassId";
            txtClassId.Size = new Size(176, 31);
            txtClassId.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(4, 165);
            lblPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(76, 15);
            lblPhoneNumber.TabIndex = 5;
            lblPhoneNumber.Text = "Số điện thoại";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(4, 182);
            txtPhoneNumber.Margin = new Padding(2);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(176, 31);
            txtPhoneNumber.TabIndex = 4;
            // 
            // dtpDayOfBirth
            // 
            dtpDayOfBirth.Location = new Point(4, 107);
            dtpDayOfBirth.Margin = new Padding(2);
            dtpDayOfBirth.Name = "dtpDayOfBirth";
            dtpDayOfBirth.Size = new Size(176, 31);
            dtpDayOfBirth.TabIndex = 6;
            // 
            // lblDayOfBirth
            // 
            lblDayOfBirth.AutoSize = true;
            lblDayOfBirth.Location = new Point(4, 91);
            lblDayOfBirth.Margin = new Padding(2, 0, 2, 0);
            lblDayOfBirth.Name = "lblDayOfBirth";
            lblDayOfBirth.Size = new Size(60, 15);
            lblDayOfBirth.TabIndex = 7;
            lblDayOfBirth.Text = "Ngày sinh";
            // 
            // lblRanking
            // 
            lblRanking.AutoSize = true;
            lblRanking.Location = new Point(4, 239);
            lblRanking.Margin = new Padding(2, 0, 2, 0);
            lblRanking.Name = "lblRanking";
            lblRanking.Size = new Size(50, 15);
            lblRanking.TabIndex = 9;
            lblRanking.Text = "Cấp bậc";
            // 
            // txtRanking
            // 
            txtRanking.Location = new Point(4, 256);
            txtRanking.Margin = new Padding(2);
            txtRanking.Name = "txtRanking";
            txtRanking.Size = new Size(176, 31);
            txtRanking.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(195, 239);
            lblRole.Margin = new Padding(2, 0, 2, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(51, 15);
            lblRole.TabIndex = 11;
            lblRole.Text = "Chức vụ";
            // 
            // txtRole
            // 
            txtRole.Location = new Point(195, 256);
            txtRole.Margin = new Padding(2);
            txtRole.Name = "txtRole";
            txtRole.Size = new Size(176, 31);
            txtRole.TabIndex = 10;
            // 
            // lblEnlistmentDate
            // 
            lblEnlistmentDate.AutoSize = true;
            lblEnlistmentDate.Location = new Point(4, 128);
            lblEnlistmentDate.Margin = new Padding(2, 0, 2, 0);
            lblEnlistmentDate.Name = "lblEnlistmentDate";
            lblEnlistmentDate.Size = new Size(89, 15);
            lblEnlistmentDate.TabIndex = 13;
            lblEnlistmentDate.Text = "Ngày nhập ngũ";
            // 
            // dtpEnlistmentDate
            // 
            dtpEnlistmentDate.Location = new Point(4, 145);
            dtpEnlistmentDate.Margin = new Padding(2);
            dtpEnlistmentDate.Name = "dtpEnlistmentDate";
            dtpEnlistmentDate.Size = new Size(176, 31);
            dtpEnlistmentDate.TabIndex = 12;
            // 
            // lblFatherFullName
            // 
            lblFatherFullName.AutoSize = true;
            lblFatherFullName.Location = new Point(4, 277);
            lblFatherFullName.Margin = new Padding(2, 0, 2, 0);
            lblFatherFullName.Name = "lblFatherFullName";
            lblFatherFullName.Size = new Size(67, 15);
            lblFatherFullName.TabIndex = 15;
            lblFatherFullName.Text = "Họ tên Cha";
            // 
            // txtFatherFullName
            // 
            txtFatherFullName.Location = new Point(4, 293);
            txtFatherFullName.Margin = new Padding(2);
            txtFatherFullName.Name = "txtFatherFullName";
            txtFatherFullName.Size = new Size(176, 31);
            txtFatherFullName.TabIndex = 14;
            // 
            // lblFatherPhoneNumber
            // 
            lblFatherPhoneNumber.AutoSize = true;
            lblFatherPhoneNumber.Location = new Point(195, 277);
            lblFatherPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblFatherPhoneNumber.Name = "lblFatherPhoneNumber";
            lblFatherPhoneNumber.Size = new Size(100, 15);
            lblFatherPhoneNumber.TabIndex = 17;
            lblFatherPhoneNumber.Text = "Số điện thoại Cha";
            // 
            // txtFatherPhoneNumber
            // 
            txtFatherPhoneNumber.Location = new Point(195, 293);
            txtFatherPhoneNumber.Margin = new Padding(2);
            txtFatherPhoneNumber.Name = "txtFatherPhoneNumber";
            txtFatherPhoneNumber.Size = new Size(176, 31);
            txtFatherPhoneNumber.TabIndex = 16;
            // 
            // lblMotherPhoneNumber
            // 
            lblMotherPhoneNumber.AutoSize = true;
            lblMotherPhoneNumber.Location = new Point(195, 314);
            lblMotherPhoneNumber.Margin = new Padding(2, 0, 2, 0);
            lblMotherPhoneNumber.Name = "lblMotherPhoneNumber";
            lblMotherPhoneNumber.Size = new Size(96, 15);
            lblMotherPhoneNumber.TabIndex = 21;
            lblMotherPhoneNumber.Text = "Số điện thoại Mẹ";
            // 
            // txtMotherPhoneNumber
            // 
            txtMotherPhoneNumber.Location = new Point(195, 331);
            txtMotherPhoneNumber.Margin = new Padding(2);
            txtMotherPhoneNumber.Name = "txtMotherPhoneNumber";
            txtMotherPhoneNumber.Size = new Size(176, 31);
            txtMotherPhoneNumber.TabIndex = 20;
            // 
            // lblMotherFullName
            // 
            lblMotherFullName.AutoSize = true;
            lblMotherFullName.Location = new Point(4, 314);
            lblMotherFullName.Margin = new Padding(2, 0, 2, 0);
            lblMotherFullName.Name = "lblMotherFullName";
            lblMotherFullName.Size = new Size(63, 15);
            lblMotherFullName.TabIndex = 19;
            lblMotherFullName.Text = "Họ tên Mẹ";
            // 
            // txtMotherFullName
            // 
            txtMotherFullName.Location = new Point(4, 331);
            txtMotherFullName.Margin = new Padding(2);
            txtMotherFullName.Name = "txtMotherFullName";
            txtMotherFullName.Size = new Size(176, 31);
            txtMotherFullName.TabIndex = 18;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(4, 16);
            lblId.Margin = new Padding(2, 0, 2, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(81, 15);
            lblId.TabIndex = 23;
            lblId.Text = "Mã định danh";
            // 
            // txtId
            // 
            txtId.Location = new Point(4, 33);
            txtId.Margin = new Padding(2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(176, 31);
            txtId.TabIndex = 22;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(197, 16);
            pictureBox1.Margin = new Padding(2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 185);
            pictureBox1.TabIndex = 24;
            pictureBox1.TabStop = false;
            // 
            // grbDetailInfo
            // 
            grbDetailInfo.Dock = DockStyle.Fill;
            grbDetailInfo.Location = new Point(3, 3);
            grbDetailInfo.Name = "grbDetailInfo";
            grbDetailInfo.Size = new Size(538, 666);
            grbDetailInfo.TabIndex = 1;
            grbDetailInfo.TabStop = false;
            grbDetailInfo.Text = "Thông tin chi tiết";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SteelBlue;
            btnSave.Dock = DockStyle.Right;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Transparent;
            btnSave.Location = new Point(429, 675);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 2;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
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
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 33);
            toolStripSeparator7.Visible = false;
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
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 33);
            // 
            // btnAdd
            // 
            btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdd.Image = Properties.Resources.add;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(34, 28);
            btnAdd.Text = "toolStripButton5";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 33);
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
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 33);
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
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 33);
            // 
            // btnNext
            // 
            btnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNext.Image = Properties.Resources.arrow_circle_right;
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(34, 28);
            btnNext.Text = "toolStripButton3";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 33);
            // 
            // lblTotalPages
            // 
            lblTotalPages.Name = "lblTotalPages";
            lblTotalPages.Size = new Size(44, 28);
            lblTotalPages.Text = "of 0";
            // 
            // txtPageNumber
            // 
            txtPageNumber.Name = "txtPageNumber";
            txtPageNumber.Size = new Size(100, 33);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 33);
            // 
            // btnPrev
            // 
            btnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPrev.Image = Properties.Resources.arrow_circle_left;
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(34, 28);
            btnPrev.Text = "btnPrev";
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
            // tpnDetails
            // 
            tpnDetails.ColumnCount = 1;
            tpnDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tpnDetails.Controls.Add(grbDetailInfo, 0, 0);
            tpnDetails.Controls.Add(btnSave, 0, 1);
            tpnDetails.Dock = DockStyle.Fill;
            tpnDetails.Location = new Point(800, 0);
            tpnDetails.Name = "tpnDetails";
            tpnDetails.RowCount = 2;
            tpnDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tpnDetails.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tpnDetails.Size = new Size(544, 712);
            tpnDetails.TabIndex = 4;
            // 
            // pnView
            // 
            pnView.Controls.Add(dgvRead);
            pnView.Controls.Add(tsBehavior);
            pnView.Dock = DockStyle.Left;
            pnView.Location = new Point(0, 0);
            pnView.Name = "pnView";
            pnView.Size = new Size(800, 712);
            pnView.TabIndex = 3;
            // 
            // dgvRead
            // 
            dgvRead.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRead.Dock = DockStyle.Fill;
            dgvRead.Location = new Point(0, 33);
            dgvRead.Name = "dgvRead";
            dgvRead.RowHeadersWidth = 62;
            dgvRead.Size = new Size(800, 679);
            dgvRead.TabIndex = 1;
            // 
            // FrmTrainee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1344, 712);
            Controls.Add(tpnDetails);
            Controls.Add(pnView);
            Margin = new Padding(1, 2, 1, 2);
            Name = "FrmTrainee";
            Text = "FrmTrainee";
            Load += FrmTrainee_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tsBehavior.ResumeLayout(false);
            tsBehavior.PerformLayout();
            tpnDetails.ResumeLayout(false);
            pnView.ResumeLayout(false);
            pnView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRead).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblClassId;
        private TextBox txtClassId;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Label lblDayOfBirth;
        private DateTimePicker dtpDayOfBirth;
        private Label lblRanking;
        private TextBox txtRanking;
        private Label lblEnlistmentDate;
        private DateTimePicker dtpEnlistmentDate;
        private Label lblRole;
        private TextBox txtRole;
        private Label lblFatherFullName;
        private TextBox txtFatherFullName;
        private Label lblFatherPhoneNumber;
        private TextBox txtFatherPhoneNumber;
        private Label lblMotherPhoneNumber;
        private TextBox txtMotherPhoneNumber;
        private Label lblMotherFullName;
        private TextBox txtMotherFullName;
        private PictureBox pictureBox1;
        private Label lblId;
        private TextBox txtId;
        protected GroupBox grbDetailInfo;
        private Button btnSave;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton btnEdit;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton btnAdd;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnSearch;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnRefresh;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnNext;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel lblTotalPages;
        private ToolStripTextBox txtPageNumber;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnPrev;
        private ToolStrip tsBehavior;
        protected TableLayoutPanel tpnDetails;
        protected Panel pnView;
        protected DataGridView dgvRead;
    }
}