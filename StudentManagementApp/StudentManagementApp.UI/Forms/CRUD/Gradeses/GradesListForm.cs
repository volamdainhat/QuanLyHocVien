using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Grades;
using StudentManagementApp.UI.Forms.CRUD.Gradeses;
using StudentManagementApp.UI.Forms.CRUD.Trainees;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class GradesListForm : Form
    {
        private readonly IGradesRepository _gradesRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISemesterRepository _semesterRepository;
        private readonly ISubjectAverageRepository _subjectAverageRepository;
        private readonly ITraineeAverageScoreRepository _traineeAverageScoreRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly ITraineeRepository _traineeRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;
        private List<GradesViewModel> _gradesViews;
        private List<Class> _classes;
        private List<Subject> _subjects;
        private ToolStripButton btnFilter;
        private ToolStripLabel lblFilterStatus;
        private Dictionary<string, object> _currentFilters = new Dictionary<string, object>();

        public GradesListForm(
            IGradesRepository gradesRepository,
            ICategoryRepository categoryRepository,
            ISemesterRepository semesterRepository,
            ISubjectAverageRepository subjectAverageRepository,
            ITraineeAverageScoreRepository traineeAverageScoreRepository,
            ITraineeRepository traineeRepository,
            IRepository<Subject> subjectRepository,
            IRepository<Class> classRepository,
            IValidationService validationService)
        {
            _gradesRepository = gradesRepository;
            _categoryRepository = categoryRepository;
            _semesterRepository = semesterRepository;
            _subjectAverageRepository = subjectAverageRepository;
            _traineeAverageScoreRepository = traineeAverageScoreRepository;
            _traineeRepository = traineeRepository;
            _subjectRepository = subjectRepository;
            _classRepository = classRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadGrades();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Điểm thi";
            this.Size = new Size(800, 600);

            // Toolbar
            var toolStrip = new ToolStrip();

            // Tạo ImageList
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(32, 32);
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            // Thêm ảnh vào ImageList
            imageList.Images.Add(Properties.Resources.add_icon);
            imageList.Images.Add(Properties.Resources.addrange_icon);
            imageList.Images.Add(Properties.Resources.edit_icon);
            imageList.Images.Add(Properties.Resources.refresh_icon);
            imageList.Images.Add(Properties.Resources.filter_icon);

            // Gán ImageList cho ToolStrip
            toolStrip.ImageList = imageList;

            var btnAdd = new ToolStripButton("Thêm");
            btnAdd.ImageIndex = 0;
            btnAdd.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnAdd.ImageTransparentColor = Color.Magenta;

            var btnAddRange = new ToolStripButton("Thêm nhiều");
            btnAddRange.ImageIndex = 1;
            btnAddRange.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnAddRange.ImageTransparentColor = Color.Magenta;

            var btnEdit = new ToolStripButton("Sửa");
            btnEdit.ImageIndex = 2;
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnEdit.ImageTransparentColor = Color.Magenta;

            var btnRefresh = new ToolStripButton("Làm mới");
            btnRefresh.ImageIndex = 3;
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnRefresh.ImageTransparentColor = Color.Magenta;

            btnFilter = new ToolStripButton("Lọc");
            btnFilter.ImageIndex = 4;
            btnFilter.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnFilter.ImageTransparentColor = Color.Magenta;

            lblFilterStatus = new ToolStripLabel("Đang hiển thị tất cả học viên");
            lblFilterStatus.ImageIndex = 5;
            lblFilterStatus.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            lblFilterStatus.ImageTransparentColor = Color.Magenta;

            toolStrip.Items.AddRange([btnAdd, btnAddRange, btnEdit, btnRefresh, btnFilter, lblFilterStatus]);
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

            btnAdd.Click += (s, e) => AddClass();
            btnAddRange.Click += (s, e) => btnBulkAddGrades_Click();
            btnEdit.Click += async (s, e) => await EditClass();
            btnRefresh.Click += (s, e) => LoadGrades();
            btnFilter.Click += async (s, e) => await BtnFilter_Click(s, e);
        }

        private async Task BtnFilter_Click(object s, EventArgs e)
        {
            using (var filterForm = new GradesFilterForm(_classes, _subjects))
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
            var filtered = _gradesViews.AsEnumerable();

            // Lọc theo lớp
            if (_currentFilters.ContainsKey("ClassId"))
            {
                var classId = (int)_currentFilters["ClassId"];
                filtered = filtered.Where(t => t.ClassId == classId);
            }

            // Lọc theo môn
            if (_currentFilters.ContainsKey("SubjectId"))
            {
                var subjectId = (int)_currentFilters["SubjectId"];
                filtered = filtered.Where(t => t.SubjectId == subjectId);
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

                if (_currentFilters.ContainsKey("SubjectId"))
                {
                    var subjectId = (int)_currentFilters["SubjectId"];
                    var subjectName = _subjects.First(c => c.Id == subjectId).Name;
                    filterDetails.Add($"Môn: {subjectName}");
                }

                lblFilterStatus.Text = $"Đang lọc: {string.Join(", ", filterDetails)}";
                lblFilterStatus.ForeColor = Color.Green;
            }
        }

        private async void LoadGrades()
        {
            var classes = await _classRepository.GetAllAsync();
            _classes = classes.ToList();

            var subjects = await _subjectRepository.GetAllAsync();
            _subjects = subjects.ToList();

            var grades = await _gradesRepository.GetGradesWithTraineeSubjectAsync();
            _gradesViews = grades.ToList();
            dataGridView.DataSource = _gradesViews;

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void AddClass()
        {
            var form = new GradesForm(_gradesRepository, _categoryRepository, _semesterRepository, _subjectAverageRepository, _traineeAverageScoreRepository, _traineeRepository, _subjectRepository, _classRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadGrades();
            }
        }

        private async Task EditClass()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is GradesViewModel selectedGrades)
            {
                var grades = await _gradesRepository.GetByIdAsync(selectedGrades.Id);
                var form = new GradesForm(_gradesRepository, _categoryRepository, _semesterRepository, _subjectAverageRepository, _traineeAverageScoreRepository, _traineeRepository, _subjectRepository, _classRepository, _validationService, grades);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGrades();
                }
            }
        }

        private void btnBulkAddGrades_Click()
        {
            using (var form = new BulkAddGradesForm(_classRepository, _subjectRepository, _semesterRepository, _gradesRepository, _traineeRepository, _categoryRepository, _subjectAverageRepository, _traineeAverageScoreRepository))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGrades();
                }
            }
        }
    }
}
