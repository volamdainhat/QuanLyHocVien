using Microsoft.Extensions.DependencyInjection;
using QuanLyHocVien.UI.Forms;

namespace QuanLyHocVien
{
    public partial class FrmMain : Form
    {
        private FrmTrainee frm;

        public FrmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnTrainee_Click(object sender, EventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                frm = new FrmTrainee();
                frm.ShowDialog();
            }
            else
            {
                frm.BringToFront();
            }
        }
    }
}
