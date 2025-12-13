using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.UI.Forms.CRUD.Trainees;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SubjectAverageListForm : Form
    {
        private readonly ISubjectAverageRepository _subjectAverageRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;
        private List<SubjectAverageViewModel> _subjectAverages;
        private List<Class> _classes;
        private List<Subject> _subjects;
        private ToolStripButton btnFilter;
        private ToolStripLabel lblFilterStatus;
        private Dictionary<string, object> _currentFilters = new Dictionary<string, object>();

        public SubjectAverageListForm(
            ISubjectAverageRepository subjectAverageRepository,
            IRepository<Subject> subjectRepository,
            IRepository<Class> classRepository,
            IRepository<Trainee> traineeRepository,
            IValidationService validationService)
        {
            _subjectAverageRepository = subjectAverageRepository;
            _subjectRepository = subjectRepository;
            _classRepository = classRepository;
            _traineeRepository = traineeRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadSubjectAverages();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Điểm trung bình môn";
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

            toolStrip.Items.AddRange([btnRefresh, btnFilter, lblFilterStatus]);
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

            //btnAdd.Click += (s, e) => AddSubjectAverage();
            //btnEdit.Click += (s, e) => EditSubjectAverage();
            btnRefresh.Click += (s, e) => LoadSubjectAverages();
            btnFilter.Click += async (s, e) => await BtnFilter_Click(s, e);
        }

        private async Task BtnFilter_Click(object s, EventArgs e)
        {
            using (var filterForm = new SubjectAverageFilterForm(_classes, _subjects))
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
            var filtered = _subjectAverages.AsEnumerable();

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

        private async void LoadSubjectAverages()
        {
            var classes = await _classRepository.GetAllAsync();
            _classes = classes.ToList();

            var subjects = await _subjectRepository.GetAllAsync();
            _subjects = subjects.ToList();

            var subjectAverages = await _subjectAverageRepository.GetSubjectAverageWithSubjectTraineeAsync();
            _subjectAverages = subjectAverages.ToList();
            dataGridView.DataSource = _subjectAverages;

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        //private void AddSubjectAverage()
        //{
        //    var form = new SubjectAverageForm(_subjectAverageRepository, _subjectRepository, _traineeRepository, _validationService);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadSubjectAverages();
        //    }
        //}

        //private void EditSubjectAverage()
        //{
        //    if (dataGridView.CurrentRow?.DataBoundItem is SubjectAverageViewModel selectedSubjectAverage)
        //    {
        //        var subjectAverage = _subjectAverageRepository.GetByIdAsync(selectedSubjectAverage.Id).Result;
        //        var form = new SubjectAverageForm(_subjectAverageRepository, _subjectRepository, _traineeRepository, _validationService, subjectAverage);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            LoadSubjectAverages();
        //        }
        //    }
        //}
    }
}
