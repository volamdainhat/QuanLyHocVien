namespace StudentManagementApp.UI.Controls
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
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

            var summaryPanel = new Panel
            {
                Size = new Size(800, 200),
                Location = new Point(20, 80),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray
            };

            // Thêm các control thống kê vào summaryPanel
            // ...

            this.Controls.Add(titleLabel);
            this.Controls.Add(summaryPanel);
        }
    }
}
