using StudentManagementSystem.Infrastructure;
using StudentManagementSystem.UI.UserControls;

namespace StudentManagementSystem.Forms
{
    public partial class FrmMain : Form
    {
        private AppDbContext? dbContext;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblTitle.AutoSize = false;
        }

        private void btnTrainee_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucTrainee());
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetMainForm();
        }

        private void LoadUserControl(UserControl uc)
        {
            // Kiểm tra nếu đã có control và cùng loại
            if (pnlMainContent.Controls.Count > 0)
            {
                var currentControl = pnlMainContent.Controls[0];

                if (currentControl.GetType() == uc.GetType())
                {
                    // Đang mở đúng UserControl rồi, không cần load lại
                    return;
                }
            }

            pnlMainContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(uc);
        }

        private void ResetMainForm()
        {
            FrmMain newForm = new();
            newForm.Show();
            this.Dispose(false);
        }

        private void họcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ucTrainee());
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext?.Dispose();
            this.dbContext = null;
        }
    }
}
