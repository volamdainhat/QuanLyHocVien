using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Classes;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.Categories;
using StudentManagementApp.Infrastructure.Repositories.Classes;
using StudentManagementApp.Infrastructure.Repositories.Trainees;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class TraineeListForm : Form
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public TraineeListForm(ITraineeRepository traineeRepository, IRepository<Class> classRepository, ICategoryRepository categoryRepository, IValidationService validationService)
        {
            _traineeRepository = traineeRepository;
            _classRepository = classRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeTraineeList();
            LoadTrainees();
        }

        private void InitializeTraineeList()
        {
            this.Text = "Quản lý Học viên";
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

            btnAdd.Click += (s, e) => AddTrainee();
            btnEdit.Click += (s, e) => EditTrainee();
            btnRefresh.Click += (s, e) => LoadTrainees();
        }

        private async void LoadTrainees()
        {
            var Classs = await _traineeRepository.GetTraineesWithClassAsync();
            dataGridView.DataSource = Classs.ToList();
        }

        private void AddTrainee()
        {
            var form = new TraineeForm(_traineeRepository, _classRepository, _categoryRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrainees();
            }
        }

        private void EditTrainee()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is TraineeViewModel selectedTrainee)
            {
                var traineeEntity = _traineeRepository.GetByIdAsync(selectedTrainee.Id).Result;
                var form = new TraineeForm(_traineeRepository, _classRepository, _categoryRepository, _validationService, traineeEntity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTrainees();
                }
            }
        }
    }
}
