﻿using Microsoft.Extensions.DependencyInjection;
using QuanLyHocVien.UI.Forms;

namespace QuanLyHocVien
{
    public partial class frmMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private FrmTrainee frm;

        public frmMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                var traineeForm = _serviceProvider.GetRequiredService<FrmTrainee>();
                traineeForm.ShowDialog();
            }
            else
            {
                frm.BringToFront();
            }
        }
    }
}
