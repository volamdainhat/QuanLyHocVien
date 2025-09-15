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

            // Dictionary ánh xạ tên cột với cấu hình
            var columnConfigurations = new Dictionary<string, Action<DataGridViewColumn>>
            {
                { "Id", col => col.Visible = false },
                { "Classes", col => col.Visible = false },
                { "Name", col => col.HeaderText = "Khóa học" },
                { "StartDate", col => {
                    col.HeaderText = "Ngày khai giảng";
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
                }},
                { "EndDate", col => {
                    col.HeaderText = "Ngày tổng kết";
                    col.DefaultCellStyle.Format = "dd/MM/yyyy";
                }},
                { "CreatedDate", col => col.HeaderText = "Ngày tạo" },
                { "ModifiedDate", col => col.HeaderText = "Ngày cập nhật" },
                { "IsActive", col => col.HeaderText = "Đang hoạt động" }
            };

            // Áp dụng cấu hình
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (columnConfigurations.ContainsKey(column.DataPropertyName))
                {
                    columnConfigurations[column.DataPropertyName].Invoke(column);
                }
            }
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
