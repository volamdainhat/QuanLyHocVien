using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.Infrastructure.Repositories.Trainees;

namespace StudentManagementApp.UI.Controls
{
    public partial class DashboardControl : UserControl
    {
        private readonly ITraineeRepository _traineeRepository;
        private int _totalTrainees;
        private List<TraineeByClassModel> _traineesByClass;

        public DashboardControl(ITraineeRepository traineeRepository)
        {
            _traineeRepository = traineeRepository;
            InitializeComponent();
            LoadDataAsync();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            var titleLabel = new Label
            {
                Text = "DASHBOARD",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Location = new Point(20, 20)
            };

            //var summaryPanel = new Panel
            //{
            //    Size = new Size(800, 200),
            //    Location = new Point(20, 80),
            //    BorderStyle = BorderStyle.FixedSingle,
            //    BackColor = Color.LightGray
            //};

            // Thêm các control thống kê vào summaryPanel
            int xOffset = 40;
            int yOffset = 100;

            var totalTraineeCard = LoadCard(xOffset, yOffset, "Tổng học viên Đại đội", _totalTrainees);
            this.Controls.Add(totalTraineeCard);
            //yOffset += 180;
            xOffset += 420;

            foreach (var traineeClass in _traineesByClass)
            {
                // 40, 280
                var classCard = LoadCard(xOffset, yOffset, $"Học viên lớp {traineeClass.ClassName}", traineeClass.CountTrainee);
                this.Controls.Add(classCard);
                xOffset += 420;
            }

            this.Controls.Add(titleLabel);
            //this.Controls.Add(summaryPanel);
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
        }
    }
}
