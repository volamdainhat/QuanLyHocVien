using QuanLyHocVien.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocVien
{
    public partial class frmStudentManagement : Form
    {
        private frmStudentInformation? frmStudentInformation;

        public frmStudentManagement()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (frmStudentInformation == null || frmStudentInformation.IsDisposed)
            {
                frmStudentInformation = new frmStudentInformation();
                frmStudentInformation.Show();
            }
            else
            {
                frmStudentInformation.BringToFront();
            }
        }
    }
}
