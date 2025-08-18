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
            họcViênToolStripMenuItem = new ToolStripMenuItem();
            lớpHọcToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            pnlMainContent = new SmoothPanel();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { trangChủToolStripMenuItem, họcViênToolStripMenuItem, lớpHọcToolStripMenuItem, toolStripMenuItem1 });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(4, 1, 0, 1);
            menuStrip.Size = new Size(881, 24);
            menuStrip.TabIndex = 9;
            menuStrip.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            trangChủToolStripMenuItem.Size = new Size(74, 22);
            trangChủToolStripMenuItem.Text = "Trang chủ";
            trangChủToolStripMenuItem.Click += trangChủToolStripMenuItem_Click;
            // 
            // họcViênToolStripMenuItem
            // 
            họcViênToolStripMenuItem.Name = "họcViênToolStripMenuItem";
            họcViênToolStripMenuItem.Size = new Size(79, 22);
            họcViênToolStripMenuItem.Text = "1. Học viên";
            họcViênToolStripMenuItem.Click += họcViênToolStripMenuItem_Click;
            // 
            // lớpHọcToolStripMenuItem
            // 
            lớpHọcToolStripMenuItem.Name = "lớpHọcToolStripMenuItem";
            lớpHọcToolStripMenuItem.Size = new Size(77, 22);
            lớpHọcToolStripMenuItem.Text = "2. Lớp học";
            lớpHọcToolStripMenuItem.Click += lớpHọcToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(84, 22);
            toolStripMenuItem1.Text = "3. Khóa học";
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 24);
            pnlMainContent.Margin = new Padding(2, 2, 2, 2);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(881, 374);
            pnlMainContent.TabIndex = 10;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 398);
            Controls.Add(pnlMainContent);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(2, 2, 2, 2);
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
        private ToolStripMenuItem toolStripMenuItem1;
        private SmoothPanel pnlMainContent;
        private ToolStripMenuItem trangChủToolStripMenuItem;
    }
}