using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.GraduationExamScores;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.UI.Forms.CRUD.Gradeses;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class GraduationExamScoreListForm : Form
    {
        private readonly IGraduationExamScoreRepository _graduationExamScoreRepository;
        private readonly IGraduationScoreRepository _graduationScoreRepository;
        private readonly ITraineeRepository _traineeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public GraduationExamScoreListForm(
            IGraduationExamScoreRepository graduationExamScoreRepository,
            IGraduationScoreRepository graduationScoreRepository,
            ITraineeRepository traineeRepository,
            ICategoryRepository categoryRepository,
            IRepository<Class> classRepository,
            IValidationService validationService)
        {
            _graduationExamScoreRepository = graduationExamScoreRepository;
            _graduationScoreRepository = graduationScoreRepository;
            _traineeRepository = traineeRepository;
            _categoryRepository = categoryRepository;
            _classRepository = classRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeGraduationExamScoresList();
            LoadGraduationExamScores();
        }

        private void InitializeGraduationExamScoresList()
        {
            this.Text = "Quản lý Điểm thi tốt nghiệp";
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

            toolStrip.Items.AddRange([btnAdd, btnAddRange, btnEdit, btnRefresh]);
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
            btnAddRange.Click += (s, e) => btnBulkAdd_Click();
            btnEdit.Click += async (s, e) => await Edit();
            btnRefresh.Click += (s, e) => LoadGraduationExamScores();
        }

        private void btnBulkAdd_Click()
        {
            using (var form = new BulkAddGraduationExamScoreForm(_classRepository, _graduationExamScoreRepository, _graduationScoreRepository, _traineeRepository, _categoryRepository))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGraduationExamScores();
                }
            }
        }

        private async void LoadGraduationExamScores()
        {
            var datas = await _graduationExamScoreRepository.GetGraduationExamScoreWithTraineeAsync();
            dataGridView.DataSource = datas.ToList();

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void Add()
        {
            var form = new GraduationExamScoreForm(_graduationExamScoreRepository, _graduationScoreRepository, _traineeRepository, _categoryRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadGraduationExamScores();
            }
        }

        private async Task Edit()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is GraduationExamScoreViewModel selected)
            {
                var entity = await _graduationExamScoreRepository.GetByIdAsync(selected.Id);
                var form = new GraduationExamScoreForm(_graduationExamScoreRepository, _graduationScoreRepository, _traineeRepository, _categoryRepository, _validationService, entity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGraduationExamScores();
                }
            }
        }
    }
}
