using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using System.Windows.Forms;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SchoolYearListForm : Form
    {
        private readonly IRepository<SchoolYear> _schoolYearRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public SchoolYearListForm(IRepository<SchoolYear> schoolYearRepository, IValidationService validationService)
        {
            _schoolYearRepository = schoolYearRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeSchoolYearList();
            LoadSchoolYears();
        }

        private void InitializeSchoolYearList()
        {
            this.Text = "Quản lý Niên khóa";
            this.Size = new Size(800, 600);

            // Toolbar
            var toolStrip = new ToolStrip();

            // Tạo ImageList
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(32, 32);
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            // Thêm ảnh vào ImageList
            imageList.Images.Add(Properties.Resources.add_icon);
            imageList.Images.Add(Properties.Resources.edit_icon);
            imageList.Images.Add(Properties.Resources.refresh_icon);

            // Gán ImageList cho ToolStrip
            toolStrip.ImageList = imageList;

            var btnAdd = new ToolStripButton("Thêm");
            btnAdd.ImageIndex = 0;
            btnAdd.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnAdd.ImageTransparentColor = Color.Magenta;

            var btnEdit = new ToolStripButton("Sửa");
            btnEdit.ImageIndex = 1;
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnEdit.ImageTransparentColor = Color.Magenta;

            var btnRefresh = new ToolStripButton("Làm mới");
            btnRefresh.ImageIndex = 2;
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnRefresh.ImageTransparentColor = Color.Magenta;

            toolStrip.Items.AddRange([btnAdd, btnEdit, btnRefresh]);
            toolStrip.Dock = DockStyle.Top;

            // DataGridView
            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            this.Controls.Add(dataGridView);
            this.Controls.Add(toolStrip);

            btnAdd.Click += (s, e) => AddSchoolYear();
            btnEdit.Click += (s, e) => EditSchoolYear();
            btnRefresh.Click += (s, e) => LoadSchoolYears();
        }

        private async void LoadSchoolYears()
        {
            var schoolYears = await _schoolYearRepository.GetAllAsync();
            dataGridView.DataSource = schoolYears.ToList();

            // Đổi tên cột
            dataGridView.Columns["Name"].HeaderText = "Khóa";
            dataGridView.Columns["StartDate"].HeaderText = "Ngày khai giảng";
            dataGridView.Columns["EndDate"].HeaderText = "Ngày tổng kết";

            // Sắp xếp lại thứ tự cột
            dataGridView.Columns["Id"].DisplayIndex = 0;
        }

        private void AddSchoolYear()
        {
            var form = new SchoolYearForm(_schoolYearRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSchoolYears();
            }
        }

        private void EditSchoolYear()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is SchoolYear selectedSchoolYear)
            {
                var form = new SchoolYearForm(_schoolYearRepository, _validationService, selectedSchoolYear);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSchoolYears();
                }
            }
        }
    }
}
