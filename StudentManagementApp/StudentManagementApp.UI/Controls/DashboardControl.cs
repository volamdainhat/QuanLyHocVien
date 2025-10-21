using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Schedules;
using StudentManagementApp.Core.Models.Trainees;

namespace StudentManagementApp.UI.Controls
{
    public partial class DashboardControl : UserControl
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private int _totalTrainees;
        private List<TraineeByClassModel> _traineesByClass;
        private List<ScheduleForTodayModel> _scheduleViews;

        public DashboardControl(
            ITraineeRepository traineeRepository,
            IScheduleRepository scheduleRepository)
        {
            _traineeRepository = traineeRepository;
            _scheduleRepository = scheduleRepository;
            InitializeComponent();
            LoadDataAsync();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            int x = 40;
            // int y = 100;

            var titleLabel = new Label
            {
                Text = "DASHBOARD",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Location = new Point(20, 20)
            };

            var totalTraineeCard = LoadCard(40, 100, "Tổng học viên Đại đội", _totalTrainees);
            this.Controls.Add(totalTraineeCard);
            x += 420;

            var dgvTraineeByClass = new DataGridView
            {
                Size = new Size(400, 300),
                Location = new Point(40, 280),
                AutoGenerateColumns = true,
                ReadOnly = true,
                DataSource = _traineesByClass,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false
            };
            dgvTraineeByClass.ReadOnly = true;

            var subtitleScheduleLabel = new Label
            {
                Text = "Lịch học trong ngày",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Location = new Point(460, 220)
            };

            var dgvScheduleForToday = new DataGridView
            {
                Size = new Size(1000, 300),
                Location = new Point(460, 280),
                AutoGenerateColumns = true,
                ReadOnly = true,
                DataSource = _scheduleViews,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false
            };
            dgvScheduleForToday.ReadOnly = true;

            this.Controls.Add(titleLabel);
            this.Controls.Add(dgvTraineeByClass);
            this.Controls.Add(subtitleScheduleLabel);
            this.Controls.Add(dgvScheduleForToday);
        }

        private Panel LoadCard(int x, int y, string title, int count)
        {
            // Tạo Panel chứa các Label
            Panel containerPanel = new Panel();
            containerPanel.Size = new Size(400, 160);
            containerPanel.Location = new Point(x, y);
            containerPanel.BorderStyle = BorderStyle.FixedSingle;
            containerPanel.BackColor = Color.LightYellow; // Thêm màu nền để dễ nhìn

            // Label 1: Số lượng học viên
            Label lbCount = new Label();
            lbCount.Text = count.ToString();
            lbCount.Font = new Font("Arial", 24, FontStyle.Bold);
            lbCount.ForeColor = Color.Blue;
            lbCount.Size = new Size(360, 60);
            lbCount.Location = new Point(20, 30);
            lbCount.TextAlign = ContentAlignment.MiddleCenter;

            // Label 2: Tổng học viên
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Arial", 14, FontStyle.Regular);
            lblTitle.Size = new Size(360, 40);
            lblTitle.Location = new Point(20, 100);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Thêm các Label vào Panel
            containerPanel.Controls.Add(lbCount);
            containerPanel.Controls.Add(lblTitle);

            return containerPanel;
        }

        private async void LoadDataAsync()
        {
            _totalTrainees = await _traineeRepository.GetTotalTraineeAsync();
            _traineesByClass = await _traineeRepository.GetTotalTraineeByClassAsync();
            _scheduleViews = await _scheduleRepository.GetScheduleForTodayAsync();
        }
    }
}
