using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Grades;
using System.Threading.Tasks;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class GradesListForm : Form
    {
        private readonly IGradesRepository _gradesRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISemesterRepository _semesterRepository;
        private readonly ISubjectAverageRepository _subjectAverageRepository;
        private readonly ITraineeAverageScoreRepository _traineeAverageScoreRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public GradesListForm(
            IGradesRepository gradesRepository,
            ICategoryRepository categoryRepository,
            ISemesterRepository semesterRepository,
            ISubjectAverageRepository subjectAverageRepository,
            ITraineeAverageScoreRepository traineeAverageScoreRepository,
            IRepository<Trainee> traineeRepository,
            IRepository<Subject> subjectRepository,
            IValidationService validationService)
        {
            _gradesRepository = gradesRepository;
            _categoryRepository = categoryRepository;
            _semesterRepository = semesterRepository;
            _subjectAverageRepository = subjectAverageRepository;
            _traineeAverageScoreRepository = traineeAverageScoreRepository;
            _traineeRepository = traineeRepository;
            _subjectRepository = subjectRepository;
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

            btnAdd.Click += (s, e) => AddClass();
            btnEdit.Click += async (s, e) => await EditClass();
            btnRefresh.Click += (s, e) => LoadGrades();
        }

        private async void LoadGrades()
        {
            var grades = await _gradesRepository.GetGradesWithTraineeSubjectAsync();
            dataGridView.DataSource = grades.ToList();

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void AddClass()
        {
            var form = new GradesForm(_gradesRepository, _categoryRepository, _semesterRepository, _subjectAverageRepository, _traineeAverageScoreRepository, _traineeRepository, _subjectRepository, _validationService);
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
                var form = new GradesForm(_gradesRepository, _categoryRepository, _semesterRepository, _subjectAverageRepository, _traineeAverageScoreRepository, _traineeRepository, _subjectRepository, _validationService, grades);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGrades();
                }
            }
        }
    }
}
