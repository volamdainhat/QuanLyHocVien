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
using QuanLyHocVien.Ultilities; // Assuming this is the correct namespace for DB_Connector

namespace QuanLyHocVien
{
    public partial class frmStudentManagement : Form
    {
        private frmStudentInformation? frmStudentInformation;
        private DB_Connector dbConnector;


        // Properties

        public frmStudentManagement()
        {
            InitializeComponent();
            dbConnector = new DB_Connector();
            dbConnector.TestConnection();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            d
        }
    }
}
