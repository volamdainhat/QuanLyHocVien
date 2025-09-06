using StudentManagementSystem.UI;

namespace StudentManagementSystem.Forms
{
    partial class FrmMain
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
            menuStrip = new MenuStrip();
            trangChủToolStripMenuItem = new ToolStripMenuItem();
            dashboardToolStripMenuItem = new ToolStripMenuItem();
            họcViênToolStripMenuItem = new ToolStripMenuItem();
            lớpHọcToolStripMenuItem = new ToolStripMenuItem();
            TkbToolStripMenuItem = new ToolStripMenuItem();
            htchToolStripMenuItem = new ToolStripMenuItem();
            pnlMainContent = new SmoothPanel();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, dashboardToolStripMenuItem, họcViênToolStripMenuItem, lớpHọcToolStripMenuItem, TkbToolStripMenuItem, htchToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1259, 33);
            menuStrip.TabIndex = 9;
            menuStrip.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            trangChủToolStripMenuItem.Size = new Size(104, 29);
            trangChủToolStripMenuItem.Text = "Trang chủ";
            trangChủToolStripMenuItem.Click += trangChủToolStripMenuItem_Click;
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new Size(116, 29);
            dashboardToolStripMenuItem.Text = "Dashboard";
            dashboardToolStripMenuItem.Click += dashboardToolStripMenuItem_Click;
            // 
            // họcViênToolStripMenuItem
            // 
            họcViênToolStripMenuItem.Name = "họcViênToolStripMenuItem";
            họcViênToolStripMenuItem.Size = new Size(116, 29);
            họcViênToolStripMenuItem.Text = "1. Học viên";
            họcViênToolStripMenuItem.Click += họcViênToolStripMenuItem_Click;
            // 
            // lớpHọcToolStripMenuItem
            // 
            lớpHọcToolStripMenuItem.Name = "lớpHọcToolStripMenuItem";
            lớpHọcToolStripMenuItem.Size = new Size(111, 29);
            lớpHọcToolStripMenuItem.Text = "2. Lớp học";
            lớpHọcToolStripMenuItem.Click += lớpHọcToolStripMenuItem_Click;
            // 
            // TkbToolStripMenuItem
            // 
            TkbToolStripMenuItem.Name = "TkbToolStripMenuItem";
            TkbToolStripMenuItem.Size = new Size(164, 29);
            TkbToolStripMenuItem.Text = "3. Thời khóa biểu";
            TkbToolStripMenuItem.Click += TkbToolStripMenuItem_Click;
            // 
            // htchToolStripMenuItem
            // 
            htchToolStripMenuItem.Name = "htchToolStripMenuItem";
            htchToolStripMenuItem.Size = new Size(184, 29);
            htchToolStripMenuItem.Text = "4. Chấp hành kỉ luật";
            htchToolStripMenuItem.Click += htchToolStripMenuItem_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 33);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1259, 630);
            pnlMainContent.TabIndex = 10;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 663);
            Controls.Add(pnlMainContent);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng quản lý học viên";
            WindowState = FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
        private ToolStripMenuItem họcViênToolStripMenuItem;
        private ToolStripMenuItem lớpHọcToolStripMenuItem;
        private ToolStripMenuItem TkbToolStripMenuItem;
        private SmoothPanel pnlMainContent;
        private ToolStripMenuItem trangChủToolStripMenuItem;
        private ToolStripMenuItem htchToolStripMenuItem;
        private ToolStripMenuItem dashboardToolStripMenuItem;
    }
}