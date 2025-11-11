using Microsoft.Extensions.DependencyInjection;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.UI.Controls;
using StudentManagementApp.UI.Forms.CRUD;

namespace StudentManagementApp.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISessionService _sessionService;
        private Form currentChildForm;
        private SidebarMenuV2 sidebarMenu;
        private Panel mainPanel;
        private Label lblUserInfo;

        public MainForm(
            IServiceProvider serviceProvider,
            ISessionService sessionService)
        {
            _serviceProvider = serviceProvider;
            _sessionService = sessionService;
            InitializeComponent();
            InitializeLayout();
            InitializeUserInfo();
        }

        private void InitializeLayout()
        {
            this.Text = "Quản Lý Học Viên";
            this.IsMdiContainer = true;
            this.Size = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Main container
            var mainContainer = new TableLayoutPanel
            {
                BackColor = Color.FromArgb(240, 248, 255),
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 2,
            };
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Thông tin user
            var userPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 248, 255),
                Height = 70
            };

            // User info
            lblUserInfo = new Label
            {
                Text = $"Xin chào",
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(10, 0, 0, 0)
            };

            // Logout button
            var btnLogout = new Button
            {
                Text = " Đăng Xuất",
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true,
                Image = Properties.Resources.logout_icon,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.Click += BtnLogout_Click;

            userPanel.Controls.Add(btnLogout);
            userPanel.Controls.Add(lblUserInfo);

            // Tạo sidebar menu
            sidebarMenu = new SidebarMenuV2();
            sidebarMenu.MenuItemClicked += SidebarMenu_MenuItemClicked;

            // Main panel for displaying forms
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            mainContainer.Controls.Add(sidebarMenu, 0, 0);
            mainContainer.Controls.Add(userPanel, 0, 1);
            mainContainer.Controls.Add(mainPanel, 1, 0);
            mainContainer.SetRowSpan(mainPanel, 2);

            this.Controls.Add(mainContainer);

            // Chọn mục menu mặc định
            sidebarMenu.SelectMenuItem("Dashboard");
        }

        private void InitializeUserInfo()
        {
            if (_sessionService.IsLoggedIn)
            {
                // Hiển thị thông tin user trên form chính
                // Ví dụ: thêm label hiển thị tên user
                // lblUserInfo.Text = $"{_sessionService.CurrentUser.Role}\n{_sessionService.CurrentUser.FullName}";
                lblUserInfo.Text = $"{_sessionService.CurrentUser.FullName}";
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void Logout()
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var authService = _serviceProvider.GetService<IAuthService>();
                authService.Logout(); // Gọi logout thông qua AuthService
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void SidebarMenu_MenuItemClicked(object sender, string menuItem)
        {
            switch (menuItem)
            {
                case "Dashboard":
                    var dashboardForm = _serviceProvider.GetRequiredService<DashboardForm>();
                    OpenChildForm(dashboardForm);
                    break;
                case "Products":
                    var productsForm = _serviceProvider.GetRequiredService<ProductListForm>();
                    OpenChildForm(productsForm);
                    break;
                case "SchoolYears":
                    var schoolYearsForm = _serviceProvider.GetRequiredService<SchoolYearListForm>();
                    OpenChildForm(schoolYearsForm);
                    break;
                case "Classes":
                    var classesForm = _serviceProvider.GetRequiredService<ClassListForm>();
                    OpenChildForm(classesForm);
                    break;
                case "Trainees":
                    var traineesForm = _serviceProvider.GetRequiredService<TraineeListForm>();
                    OpenChildForm(traineesForm);
                    break;
                case "Subjects":
                    var subjectsForm = _serviceProvider.GetRequiredService<SubjectListForm>();
                    OpenChildForm(subjectsForm);
                    break;
                case "Grades":
                    var gradesForm = _serviceProvider.GetRequiredService<GradesListForm>();
                    OpenChildForm(gradesForm);
                    break;
                case "Schedules":
                    var schedulesForm = _serviceProvider.GetRequiredService<ScheduleListForm>();
                    OpenChildForm(schedulesForm);
                    break;
                case "Misconducts":
                    var misconductsForm = _serviceProvider.GetRequiredService<MisconductListForm>();
                    OpenChildForm(misconductsForm);
                    break;
                case "SubjectAverages":
                    var subjectAveragesForm = _serviceProvider.GetRequiredService<SubjectAverageListForm>();
                    OpenChildForm(subjectAveragesForm);
                    break;
                case "Semesters":
                    var semestersForm = _serviceProvider.GetRequiredService<SemesterListForm>();
                    OpenChildForm(semestersForm);
                    break;
                case "TraineeAverageScores":
                    var traineeAverageScoresForm = _serviceProvider.GetRequiredService<TraineeAverageScoreListForm>();
                    OpenChildForm(traineeAverageScoresForm);
                    break;
                case "WeeklyCritiques":
                    var weeklyCritiquesForm = _serviceProvider.GetRequiredService<WeeklyCritiqueListForm>();
                    OpenChildForm(weeklyCritiquesForm);
                    break;
                case "GraduationExamScores":
                    var graduationExamScoreListForm = _serviceProvider.GetRequiredService<GraduationExamScoreListForm>();
                    OpenChildForm(graduationExamScoreListForm);
                    break;
                case "GraduationScores":
                    var graduationScoreListForm = _serviceProvider.GetRequiredService<GraduationScoreListForm>();
                    OpenChildForm(graduationScoreListForm);
                    break;
                case "RollCalls":
                    var rollCallListForm = _serviceProvider.GetRequiredService<RollCallListForm>();
                    OpenChildForm(rollCallListForm);
                    break;
                case "PracticePoints":
                    var practicePointListForm = _serviceProvider.GetRequiredService<PracticePointListForm>();
                    OpenChildForm(practicePointListForm);
                    break;
                case "Reports":
                    // Mở form Reports
                    break;
                case "Settings":
                    // Mở form Settings
                    break;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Đóng form hiện tại nếu có
            currentChildForm?.Close();
            currentChildForm?.Dispose();

            // Thiết lập form mới
            currentChildForm = childForm;
            childForm.TopLevel = false; // Quan trọng: form không phải top-level
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form vào mainPanel
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;

            // Hiển thị form
            childForm.BringToFront();
            childForm.Show();
        }

        // Xử lý sự kiện đóng form
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            currentChildForm?.Close();
            currentChildForm?.Dispose();
        }
    }
}
