using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.GraduationScores;
using StudentManagementApp.Core.Models.WeeklyCritiques;
using StudentManagementApp.UI.Forms.CRUD.Trainees;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class WeeklyCritiqueListForm : Form
    {
        private readonly IWeeklyCritiqueRepository _weeklyCritiqueRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;
        private List<WeeklyCritiqueViewModel> _weeklyCritiques;
        private List<Class> _classes;
        private ToolStripButton btnFilter;
        private ToolStripLabel lblFilterStatus;
        private Dictionary<string, object> _currentFilters = new Dictionary<string, object>();

        public WeeklyCritiqueListForm(
            IWeeklyCritiqueRepository weeklyCritiqueRepository,
            ICategoryRepository categoryRepository,
            IRepository<Trainee> traineeRepository,
            IRepository<Class> classRepository,
        IValidationService validationService)
        {
            _weeklyCritiqueRepository = weeklyCritiqueRepository;
            _categoryRepository = categoryRepository;
            _traineeRepository = traineeRepository;
            _classRepository = classRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadWeeklyCritiques();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Điểm rèn luyện";
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
            imageList.Images.Add(Properties.Resources.filter_icon);

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

            btnFilter = new ToolStripButton("Lọc");
            btnFilter.ImageIndex = 3;
            btnFilter.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnFilter.ImageTransparentColor = Color.Magenta;

            lblFilterStatus = new ToolStripLabel("Đang hiển thị tất cả học viên");
            lblFilterStatus.ImageIndex = 4;
            lblFilterStatus.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            lblFilterStatus.ImageTransparentColor = Color.Magenta;

            toolStrip.Items.AddRange([btnAdd, btnEdit, btnRefresh, btnFilter, lblFilterStatus]);
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
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);

            this.Controls.Add(dataGridView);
            this.Controls.Add(toolStrip);

            btnAdd.Click += (s, e) => AddClass();
            btnEdit.Click += async (s, e) => await EditClass();
            btnRefresh.Click += (s, e) => LoadWeeklyCritiques();
            btnFilter.Click += async (s, e) => await BtnFilter_Click(s, e);
        }

        private async Task BtnFilter_Click(object s, EventArgs e)
        {
            using (var filterForm = new WeeklyCritiqueFilterForm(_classes))
            {
                filterForm.FilterApplied += (s, args) =>
                {
                    _currentFilters = args.FilterValues;
                    ApplyFilter();
                    UpdateFilterStatus();
                };

                filterForm.FilterCleared += (s, args) =>
                {
                    _currentFilters.Clear();
                    ApplyFilter();
                    UpdateFilterStatus();
                };

                filterForm.ShowDialog();
            }
        }

        private void ApplyFilter()
        {
            var filtered = _weeklyCritiques.AsEnumerable();

            // Lọc theo lớp
            if (_currentFilters.ContainsKey("ClassId"))
            {
                var classId = (int)_currentFilters["ClassId"];
                filtered = filtered.Where(t => t.ClassId == classId);
            }

            dataGridView.DataSource = filtered.ToList();
        }

        private void UpdateFilterStatus()
        {
            if (!_currentFilters.Any())
            {
                lblFilterStatus.Text = "Đang hiển thị tất cả học viên";
                lblFilterStatus.ForeColor = Color.Blue;
            }
            else
            {
                var filterDetails = new List<string>();

                if (_currentFilters.ContainsKey("ClassId"))
                {
                    var classId = (int)_currentFilters["ClassId"];
                    var className = _classes.First(c => c.Id == classId).Name;
                    filterDetails.Add($"Lớp: {className}");
                }

                lblFilterStatus.Text = $"Đang lọc: {string.Join(", ", filterDetails)}";
                lblFilterStatus.ForeColor = Color.Green;
            }
        }

        private async void LoadWeeklyCritiques()
        {
            var classes = await _classRepository.GetAllAsync();
            _classes = classes.ToList();

            var datas = await _weeklyCritiqueRepository.GetWeeklyCritiqueWithTraineeAsync();
            _weeklyCritiques = datas.ToList();
            dataGridView.DataSource = _weeklyCritiques;

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void AddClass()
        {
            var form = new WeeklyCritiqueForm(_weeklyCritiqueRepository, _categoryRepository, _traineeRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadWeeklyCritiques();
            }
        }

        private async Task EditClass()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is WeeklyCritiqueViewModel selected)
            {
                var weeklyCritique = await _weeklyCritiqueRepository.GetByIdAsync(selected.Id);
                var form = new WeeklyCritiqueForm(_weeklyCritiqueRepository, _categoryRepository, _traineeRepository, _validationService, weeklyCritique);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadWeeklyCritiques();
                }
            }
        }
    }
}
