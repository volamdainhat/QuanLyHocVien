using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.PracticePoints;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class PracticePointListForm : Form
    {
        private readonly IPracticePointRepository _practicePointRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public PracticePointListForm(
            IPracticePointRepository practicePointRepository,
            IRepository<Trainee> traineeRepository,
            IValidationService validationService)
        {
            _practicePointRepository = practicePointRepository;
            _traineeRepository = traineeRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializePracticePointList();
            LoadPracticePoints();
        }

        private void InitializePracticePointList()
        {
            this.Text = "Quản lý Điểm cộng";
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

            btnAdd.Click += (s, e) => AddPracticePoint();
            btnEdit.Click += async (s, e) => await EditPracticePoint();
            btnRefresh.Click += (s, e) => LoadPracticePoints();
        }

        private async void LoadPracticePoints()
        {
            var PracticePoints = await _practicePointRepository.GetPracticePointsWithTraineeAsync();
            dataGridView.DataSource = PracticePoints.ToList();

            if (dataGridView.Columns["Time"] != null)
                dataGridView.Columns["Time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void AddPracticePoint()
        {
            var form = new PracticePointForm(_practicePointRepository, _traineeRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPracticePoints();
            }
        }

        private async Task EditPracticePoint()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is PracticePointViewModel selectedPracticePoint)
            {
                var practicePoint = await _practicePointRepository.GetByIdAsync(selectedPracticePoint.Id);
                var form = new PracticePointForm(_practicePointRepository, _traineeRepository, _validationService, practicePoint);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadPracticePoints();
                }
            }
        }
    }
}
