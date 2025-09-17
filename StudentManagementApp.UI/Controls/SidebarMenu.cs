namespace StudentManagementApp.UI.Controls
{
    public partial class SidebarMenu : UserControl
    {
        // Sự kiện khi item menu được chọn
        public event EventHandler<string>? MenuItemClicked;

        private Button[]? menuButtons;
        private Color activeColor = Color.FromArgb(51, 51, 76);
        private Color normalColor = Color.FromArgb(39, 39, 58);
        private Color activeTextColor = Color.White;
        private Color normalTextColor = Color.Gainsboro;

        public SidebarMenu()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            this.BackColor = normalColor;
            this.Width = 220;
            this.Dock = DockStyle.Left;

            // Tạo panel chứa menu
            var menuPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                AutoScroll = true
            };

            // Tạo các nút menu
            var dashboardBtn = CreateMenuButton("Dashboard", "Dashboard", Properties.Resources.dashboard_icon);
            var traineesBtn = CreateMenuButton("Học viên", "Trainees", Properties.Resources.trainee_icon);
            var classesBtn = CreateMenuButton("Lớp học", "Classes", Properties.Resources.class_icon);
            var schoolYearsBtn = CreateMenuButton("Niên khóa", "SchoolYears", Properties.Resources.schoolyears_icon);
            var productsBtn = CreateMenuButton("Sản phẩm", "Products", Properties.Resources.products_icon);
            var reportsBtn = CreateMenuButton("Báo cáo", "Reports", Properties.Resources.reports_icon);
            var settingsBtn = CreateMenuButton("Cài đặt", "Settings", Properties.Resources.settings_icon);

            menuButtons = [dashboardBtn, traineesBtn, classesBtn, schoolYearsBtn, reportsBtn, settingsBtn];

            // Đặt vị trí các nút
            int yPos = 20;
            foreach (var btn in menuButtons)
            {
                btn.Location = new Point(10, yPos);
                yPos += btn.Height + 10;
                menuPanel.Controls.Add(btn);
            }

            // Thêm logo/header
            var logoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(29, 29, 43)
            };

            var logoLabel = new Label
            {
                Text = "QUẢN LÝ HỌC VIÊN",
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            logoPanel.Controls.Add(logoLabel);

            this.Controls.Add(menuPanel);
            this.Controls.Add(logoPanel);
        }

        private Button CreateMenuButton(string text, string tag, Image icon)
        {
            var btn = new Button
            {
                Text = "   " + text,
                Height = 45,
                Width = 200,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                ImageAlign = ContentAlignment.MiddleLeft,
                ForeColor = normalTextColor,
                BackColor = normalColor,
                Font = new Font("Arial", 10, FontStyle.Regular),
                Image = icon,
                Tag = tag,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = activeColor;
            btn.FlatAppearance.MouseDownBackColor = activeColor;

            btn.Click += MenuButton_Click;
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
                btn.ForeColor = normalTextColor;
            }

            clickedButton.BackColor = activeColor;
            clickedButton.ForeColor = activeTextColor;

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
