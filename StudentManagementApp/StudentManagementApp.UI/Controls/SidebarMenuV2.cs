namespace StudentManagementApp.UI.Controls
{
    public partial class SidebarMenuV2 : UserControl
    {
        // Sự kiện khi item menu được chọn
        public event EventHandler<string>? MenuItemClicked;

        private List<Button> menuButtons = new List<Button>();
        private Color activeColor = Color.FromArgb(70, 130, 180);    // Steel Blue
        private Color normalColor = Color.FromArgb(240, 248, 255);   // Alice Blue
        private Color hoverColor = Color.FromArgb(224, 240, 255);    // Light Blue hover
        private Color activeTextColor = Color.White;
        private Color normalTextColor = Color.FromArgb(50, 50, 50);  // Dark gray for text
        private Color headerColor = Color.FromArgb(100, 149, 237);   // Cornflower Blue
        private Color headerTextColor = Color.White;

        // Common controls settings
        int width = 300;

        public SidebarMenuV2()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            this.BackColor = normalColor;
            this.Width = width;
            this.Dock = DockStyle.Left;

            // Tạo panel chứa menu
            var menuPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                AutoScroll = true
            };

            int yPos = 20;

            // === NHÓM 1: TỔNG QUAN, BÁO CÁO ===
            yPos = CreateMenuHeader("TỔNG QUAN, BÁO CÁO", menuPanel, yPos);
            var dashboardBtn = CreateMenuButton("Dashboard", "Dashboard", Properties.Resources.dashboard_icon, ref yPos);
            var reportsBtn = CreateMenuButton("Báo cáo", "Reports", Properties.Resources.reports_icon, ref yPos);
            menuPanel.Controls.Add(dashboardBtn);
            menuPanel.Controls.Add(reportsBtn);

            // === NHÓM 2: QUẢN LÝ THỜI GIAN, HỆ THỐNG ===
            yPos += 10;
            yPos = CreateMenuHeader("QUẢN LÝ THỜI GIAN", menuPanel, yPos);
            var schoolYearsBtn = CreateMenuButton("Niên khóa", "SchoolYears", Properties.Resources.schoolyears_icon, ref yPos);
            var semestersBtn = CreateMenuButton("Học kỳ", "Semesters", Properties.Resources.semester_icon, ref yPos);
            menuPanel.Controls.Add(schoolYearsBtn);
            menuPanel.Controls.Add(semestersBtn);

            // === NHÓM 3: QUẢN LÝ ĐỐI TƯỢNG ===
            yPos += 10;
            yPos = CreateMenuHeader("QUẢN LÝ ĐỐI TƯỢNG", menuPanel, yPos);
            var traineesBtn = CreateMenuButton("Học viên", "Trainees", Properties.Resources.trainee_icon, ref yPos);
            var classesBtn = CreateMenuButton("Lớp học", "Classes", Properties.Resources.class_icon, ref yPos);
            menuPanel.Controls.Add(traineesBtn);
            menuPanel.Controls.Add(classesBtn);

            // === NHÓM 4: QUẢN LÝ HỌC TẬP ===
            yPos += 10;
            yPos = CreateMenuHeader("QUẢN LÝ HỌC TẬP", menuPanel, yPos);
            var subjectsBtn = CreateMenuButton("Môn học", "Subjects", Properties.Resources.subjects_icon, ref yPos);
            var schedulesBtn = CreateMenuButton("Lịch học", "Schedules", Properties.Resources.schedule_icon, ref yPos);
            menuPanel.Controls.Add(subjectsBtn);
            menuPanel.Controls.Add(schedulesBtn);

            // === NHÓM 5: QUẢN LÝ ĐIỂM, KẾT QUẢ ===
            yPos += 10;
            yPos = CreateMenuHeader("QUẢN LÝ ĐIỂM, KẾT QUẢ", menuPanel, yPos);
            var gradesBtn = CreateMenuButton("Điểm thi", "Grades", Properties.Resources.grades_icon, ref yPos);
            var subjectAveragesBtn = CreateMenuButton("Điểm trung bình môn", "SubjectAverages", Properties.Resources.subjectAverage_icon, ref yPos);
            var traineeAverageScoresBtn = CreateMenuButton("Điểm trung bình khóa", "TraineeAverageScores", Properties.Resources.traineeAverageScore_icon, ref yPos);
            var graduationExamScoresBtn = CreateMenuButton("Điểm thi tốt nghiệp", "GraduationExamScores", Properties.Resources.graduationExamScore_icon, ref yPos);
            var graduationScoresBtn = CreateMenuButton("Điểm xét tốt nghiệp", "GraduationScores", Properties.Resources.graduationScore_icon, ref yPos);
            menuPanel.Controls.Add(gradesBtn);
            menuPanel.Controls.Add(subjectAveragesBtn);
            menuPanel.Controls.Add(traineeAverageScoresBtn);
            menuPanel.Controls.Add(graduationExamScoresBtn);
            menuPanel.Controls.Add(graduationScoresBtn);

            // === NHÓM 6: QUẢN LÝ RÈN LUYỆN ===
            yPos += 10;
            yPos = CreateMenuHeader("QUẢN LÝ RÈN LUYỆN", menuPanel, yPos);
            var rollCallsBtn = CreateMenuButton("Điểm danh", "RollCalls", Properties.Resources.rollCall_icon, ref yPos);
            var misconductsBtn = CreateMenuButton("Kỷ luật", "Misconducts", Properties.Resources.misconduct_icon, ref yPos);
            var practicePointsBtn = CreateMenuButton("Điểm cộng", "PracticePoints", Properties.Resources.practicePoint_icon, ref yPos);
            var weeklyCritiquesBtn = CreateMenuButton("Bình rèn", "WeeklyCritiques", Properties.Resources.weeklyCritique_icon, ref yPos);
            menuPanel.Controls.Add(rollCallsBtn);
            menuPanel.Controls.Add(misconductsBtn);
            menuPanel.Controls.Add(practicePointsBtn);
            menuPanel.Controls.Add(weeklyCritiquesBtn);

            // Thêm logo/header với màu sắc mới
            var logoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70, // Giảm chiều cao logo panel
                BackColor = Color.FromArgb(70, 130, 180) // Steel Blue
            };

            var logoLabel = new Label
            {
                Text = "QUẢN LÝ HỌC VIÊN",
                ForeColor = Color.White,
                Font = new Font("Arial", 13, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(10)
            };

            logoPanel.Controls.Add(logoLabel);
            this.Controls.Add(menuPanel);
            this.Controls.Add(logoPanel);
        }

        private int CreateMenuHeader(string text, Panel parentPanel, int yPos)
        {
            // Tính toán chiều cao cần thiết cho header
            Size textSize = TextRenderer.MeasureText(text,
                new Font("Arial", 10, FontStyle.Bold),
                new Size(width - 30, 0),
                TextFormatFlags.WordBreak);

            int headerHeight = Math.Max(45, textSize.Height + 15);

            var headerLabel = new Label
            {
                Text = text,
                Height = headerHeight,
                Width = width - 20,
                ForeColor = headerTextColor,
                BackColor = headerColor,
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 10, 10, 10), // Tăng padding để cân đối
                Location = new Point(10, yPos),
                AutoSize = false
            };

            parentPanel.Controls.Add(headerLabel);

            return yPos + headerLabel.Height + 5;
        }

        private Button CreateMenuButton(string text, string tag, Image icon, ref int yPos)
        {
            // Tính toán chiều cao cần thiết cho button
            Size textSize = TextRenderer.MeasureText(text,
                new Font("Arial", 10, FontStyle.Regular),
                new Size(width - 70, 0), // Trừ padding và icon
                TextFormatFlags.WordBreak);

            int buttonHeight = Math.Max(50, textSize.Height + 20);

            var btn = new Button
            {
                Text = "", // Để trống vì chúng ta sẽ vẽ thủ công
                Height = buttonHeight,
                Width = width - 20,
                FlatStyle = FlatStyle.Flat,
                BackColor = normalColor,
                Tag = tag,
                Location = new Point(10, yPos),
                UseCompatibleTextRendering = true
            };

            // Cấu hình FlatStyle
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.FlatAppearance.MouseDownBackColor = activeColor;

            // Custom painting để kiểm soát hoàn toàn việc hiển thị
            btn.Paint += (sender, e) =>
            {
                Button button = (Button)sender;
                Graphics g = e.Graphics;
                g.Clear(button.BackColor);

                // Tính toán kích thước icon
                int iconWidth = icon?.Width ?? 0;
                int iconHeight = icon?.Height ?? 0;

                // Vẽ icon - căn giữa theo chiều dọc
                int iconX = 15; // Padding trái
                int iconY = (button.Height - iconHeight) / 2;

                if (icon != null)
                {
                    g.DrawImage(icon, iconX, iconY, iconWidth, iconHeight);
                }

                // Vẽ text - với khoảng cách 3 pixel từ icon
                int textX = iconX + iconWidth + 3; // 3 pixel spacing
                int textY = 0;
                int textWidth = button.Width - textX - 15; // Padding phải
                int textHeight = button.Height;

                // Sử dụng cùng màu chữ với header khi active
                Color textColor = button.BackColor == activeColor ? activeTextColor : normalTextColor;

                // Vẽ text với căn giữa theo chiều dọc
                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
                TextRenderer.DrawText(g, text, button.Font,
                    new Rectangle(textX, textY, textWidth, textHeight),
                    textColor, flags);
            };

            btn.Click += MenuButton_Click;
            btn.MouseEnter += (s, e) =>
            {
                if (((Button)s).BackColor != activeColor)
                    ((Button)s).BackColor = hoverColor;
                ((Button)s).Refresh();
            };
            btn.MouseLeave += (s, e) =>
            {
                if (((Button)s).BackColor != activeColor)
                    ((Button)s).BackColor = normalColor;
                ((Button)s).Refresh();
            };

            menuButtons.Add(btn);
            yPos += btn.Height + 5;

            return btn;
        }

        private void MenuButton_Click(object? sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            string menuItem = clickedButton.Tag.ToString();

            // Đổi màu nút được chọn
            foreach (var btn in menuButtons)
            {
                btn.BackColor = normalColor;
            }

            clickedButton.BackColor = activeColor;

            // Refresh để cập nhật màu chữ
            foreach (var btn in menuButtons)
            {
                btn.Refresh();
            }

            // Kích hoạt sự kiện
            MenuItemClicked?.Invoke(this, menuItem);
        }

        // Phương thức để chọn menu item theo chương trình
        public void SelectMenuItem(string menuItem)
        {
            foreach (var btn in menuButtons)
            {
                if (btn.Tag.ToString() == menuItem)
                {
                    MenuButton_Click(btn, EventArgs.Empty);
                    break;
                }
            }
        }
    }
}