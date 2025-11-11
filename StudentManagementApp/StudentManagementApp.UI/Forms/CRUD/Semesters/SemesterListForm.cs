using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Semesters;
using System.Windows.Forms;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SemesterListForm : Form
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IRepository<SchoolYear> _schoolYearRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public SemesterListForm(ISemesterRepository semesterRepository, IRepository<SchoolYear> schoolYearRepository, IValidationService validationService)
        {
            _semesterRepository = semesterRepository;
            _schoolYearRepository = schoolYearRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeSemesterList();
            LoadSemesters();
        }

        private void InitializeSemesterList()
        {
            this.Text = "Quản lý Học kỳ";
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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            this.Controls.Add(dataGridView);
            this.Controls.Add(toolStrip);

            btnAdd.Click += (s, e) => Add();
            btnEdit.Click += async (s, e) => await Edit();
            btnRefresh.Click += (s, e) => LoadSemesters();
        }

        private async void LoadSemesters()
        {
            var data = await _semesterRepository.GetSemestersWithSchoolYearAsync();
            dataGridView.DataSource = data.ToList();

            if (dataGridView.Columns["StartDate"] != null)
                dataGridView.Columns["StartDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dataGridView.Columns["EndDate"] != null)
                dataGridView.Columns["EndDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void Add()
        {
            var form = new SemesterForm(_semesterRepository, _schoolYearRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSemesters();
            }
        }

        private async Task Edit()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is SemesterViewModel selected)
            {
                var entity = await _semesterRepository.GetByIdAsync(selected.Id);
                var form = new SemesterForm(_semesterRepository, _schoolYearRepository, _validationService, entity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSemesters();
                }
            }
        }
    }
}
