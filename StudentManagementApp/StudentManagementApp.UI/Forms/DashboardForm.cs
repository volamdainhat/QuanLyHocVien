using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.UI.Controls;

namespace StudentManagementApp.UI.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public DashboardForm(ITraineeRepository traineeRepository, IScheduleRepository scheduleRepository)
        {
            _traineeRepository = traineeRepository;
            _scheduleRepository = scheduleRepository;
            InitializeComponent();
            SetupDashboard();
        }

        private void SetupDashboard()
        {
            this.Text = "Dashboard";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            // Tạo và thêm DashboardControl vào form
            var dashboardControl = new DashboardControl(_traineeRepository, _scheduleRepository);
            dashboardControl.Dock = DockStyle.Fill;
            this.Controls.Add(dashboardControl);

            // Đảm bảo form có thể được thêm vào panel
            this.TopLevel = false;
        }
    }
}
