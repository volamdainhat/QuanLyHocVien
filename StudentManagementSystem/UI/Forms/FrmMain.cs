using StudentManagementSystem.Applications.Services;
using StudentManagementSystem.Infrastructure;
using StudentManagementSystem.UI.Forms;
using StudentManagementSystem.UI.UserControls;

namespace StudentManagementSystem.Forms
{
    public partial class FrmMain : Form
    {
        private AppDbContext? dbContext;

        public FrmMain()
        {
            InitializeComponent();
            NavigationService.Init(this);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            LoadUserControl(new ucHome());
        }

        private void Home_NavigateRequested(string target)
        {
            switch (target)
            {
                case "ucHome":
                    LoadUserControl(new ucHome());
                    break;
                case "ucTrainee":
                    LoadUserControl(new ucTrainee());
                    break;
                case "ucClass":
                    LoadUserControl(new ucClass());
                    break;
                case "ucSchedule":
                    LoadUserControl(new ucSchedule());
                    break;
                case "ucStudentMonitoring":
                    LoadUserControl(new ucStudentMonitoring());
                    break;
                case "ucReports":
                    LoadUserControl(new ucReports());
                    break;
                default:
                    // Optionally handle unknown targets
                    break;
            }
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home_NavigateRequested("ucHome");
        }

        private void họcViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home_NavigateRequested("ucTrainee");
        }

        private void lớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home_NavigateRequested("ucClass");
        }
        private void TkbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home_NavigateRequested("ucSchedule");
        }

        private void htchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home_NavigateRequested("ucStudentMonitoring");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext?.Dispose();
            this.dbContext = null;
        }

        public void LoadUserControl(UserControl uc)
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

            pnlMainContent.SuspendLayout();
            pnlMainContent.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            pnlMainContent.Controls.Add(uc);

            pnlMainContent.ResumeLayout();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home_NavigateRequested("ucReports");
        }
    }
}
