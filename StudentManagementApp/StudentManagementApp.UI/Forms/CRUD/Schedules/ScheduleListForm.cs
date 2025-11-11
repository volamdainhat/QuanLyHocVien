using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Schedules;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ScheduleListForm : Form
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public ScheduleListForm(
            IScheduleRepository scheduleRepository,
            IRepository<Class> classRepository,
            IRepository<Subject> subjectRepository,
            ICategoryRepository categoryRepository,
            IValidationService validationService)
        {
            _scheduleRepository = scheduleRepository;
            _classRepository = classRepository;
            _subjectRepository = subjectRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadSchedules();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Lịch học";
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

            btnAdd.Click += (s, e) => AddSchedule();
            btnEdit.Click += async (s, e) => await EditSchedule();
            btnRefresh.Click += (s, e) => LoadSchedules();
        }

        private async void LoadSchedules()
        {
            var schedules = await _scheduleRepository.GetScheduleWithClassSubjectAsync();
            dataGridView.DataSource = schedules.OrderBy(s => s.Date).ThenBy(s => s.ClassName).ToList();

            if (dataGridView.Columns["Date"] != null)
                dataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void AddSchedule()
        {
            var form = new ScheduleForm(_scheduleRepository, _classRepository, _subjectRepository, _categoryRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSchedules();
            }
        }

        private async Task EditSchedule()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is ScheduleViewModel selectedSchedule)
            {
                var scheduleEntity = await _scheduleRepository.GetByIdAsync(selectedSchedule.Id);
                var form = new ScheduleForm(_scheduleRepository, _classRepository, _subjectRepository, _categoryRepository, _validationService, scheduleEntity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSchedules();
                }
            }
        }
    }
}
