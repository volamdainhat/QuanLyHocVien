using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.TraineeAverageScores;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class TraineeAverageScoreListForm : Form
    {
        private readonly ITraineeAverageScoreRepository _traineeAverageScoreRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IRepository<Semester> _semesterRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public TraineeAverageScoreListForm(
            ITraineeAverageScoreRepository traineeAverageScoreRepository,
            IRepository<Trainee> traineeRepository,
            IRepository<Semester> semesterRepository,
            IValidationService validationService)
        {
            _traineeAverageScoreRepository = traineeAverageScoreRepository;
            _traineeRepository = traineeRepository;
            _semesterRepository = semesterRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeTraineeAverageScoreList();
            LoadTraineeAverageScores();
        }

        private void InitializeTraineeAverageScoreList()
        {
            this.Text = "Quản lý Điểm trung bình học viên";
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

            toolStrip.Items.AddRange([btnRefresh]);
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

            //btnAdd.Click += (s, e) => Add();
            //btnEdit.Click += (s, e) => Edit();
            btnRefresh.Click += (s, e) => LoadTraineeAverageScores();
        }

        private async void LoadTraineeAverageScores()
        {
            var data = await _traineeAverageScoreRepository.GetTraineeAverageScoreWithTraineeSemesterAsync();
            dataGridView.DataSource = data.ToList();

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        //private void Add()
        //{
        //    var form = new SemesterAverageForm(_SemesterAverageRepository, _SemesterRepository, _traineeRepository, _validationService);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadSemesterAverages();
        //    }
        //}

        //private void Edit()
        //{
        //    if (dataGridView.CurrentRow?.DataBoundItem is SemesterAverageViewModel selectedSemesterAverage)
        //    {
        //        var SemesterAverage = _SemesterAverageRepository.GetByIdAsync(selectedSemesterAverage.Id).Result;
        //        var form = new SemesterAverageForm(_SemesterAverageRepository, _SemesterRepository, _traineeRepository, _validationService, SemesterAverage);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            LoadSemesterAverages();
        //        }
        //    }
        //}
    }
}
