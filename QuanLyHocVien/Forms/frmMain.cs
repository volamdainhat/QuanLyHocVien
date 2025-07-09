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
    public partial class frmMain : Form
    {
        private frmStudentManagement? frm;  

        public frmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new frmStudentManagement();
                frm.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }
    }
}
