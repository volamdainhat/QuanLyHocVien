using StudentManagementApp.Infrastructure.Repositories.Trainees;
using StudentManagementApp.UI.Controls;

namespace StudentManagementApp.UI.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly ITraineeRepository _traineeRepository;

        public DashboardForm(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
            InitializeComponent();
            SetupDashboard();
        }

        private void SetupDashboard()
        {
            this.Text = "Dashboard";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // Tạo và thêm DashboardControl vào form
            var dashboardControl = new DashboardControl(_traineeRepository);
            dashboardControl.Dock = DockStyle.Fill;
            this.Controls.Add(dashboardControl);

            // Đảm bảo form có thể được thêm vào panel
            this.TopLevel = false;
        }
    }
}
