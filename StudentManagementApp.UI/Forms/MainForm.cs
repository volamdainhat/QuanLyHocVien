using Microsoft.Extensions.DependencyInjection;
using StudentManagementApp.UI.Controls;
using StudentManagementApp.UI.Forms.CRUD;

namespace StudentManagementApp.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Form currentChildForm;
        private SidebarMenu sidebarMenu;
        private Panel contentPanel;

        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InitializeLayout();
        }

        private void InitializeLayout()
        {
            this.Text = "Ứng dụng Quản lý học viên";
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            // Tạo sidebar menu
            sidebarMenu = new SidebarMenu();
            sidebarMenu.MenuItemClicked += SidebarMenu_MenuItemClicked;
            this.Controls.Add(sidebarMenu);

            // Tạo panel chứa nội dung chính
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 0),
                BackColor = Color.White
            };
            this.Controls.Add(contentPanel);

            // Đưa contentPanel lên trên sidebar
            contentPanel.BringToFront();

            // Chọn mục menu mặc định
            sidebarMenu.SelectMenuItem("Dashboard");
        }

        private void SidebarMenu_MenuItemClicked(object sender, string menuItem)
        {
            switch (menuItem)
            {
                case "Dashboard":
                    OpenChildForm(new DashboardForm());
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

            // Thêm form vào contentPanel
            contentPanel.Controls.Add(childForm);
            contentPanel.Tag = childForm;

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
