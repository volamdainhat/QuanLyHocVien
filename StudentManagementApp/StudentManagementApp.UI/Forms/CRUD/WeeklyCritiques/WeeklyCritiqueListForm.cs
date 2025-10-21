using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.WeeklyCritiques;
using System.Threading.Tasks;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class WeeklyCritiqueListForm : Form
    {
        private readonly IWeeklyCritiqueRepository _weeklyCritiqueRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public WeeklyCritiqueListForm(
            IWeeklyCritiqueRepository weeklyCritiqueRepository,
            ICategoryRepository categoryRepository,
            IRepository<Trainee> traineeRepository,
            IValidationService validationService)
        {
            _weeklyCritiqueRepository = weeklyCritiqueRepository;
            _categoryRepository = categoryRepository;
            _traineeRepository = traineeRepository;
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
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);

            this.Controls.Add(dataGridView);
            this.Controls.Add(toolStrip);

            btnAdd.Click += (s, e) => AddClass();
            btnEdit.Click += async (s, e) => await EditClass();
            btnRefresh.Click += (s, e) => LoadWeeklyCritiques();
        }

        private async void LoadWeeklyCritiques()
        {
            var datas = await _weeklyCritiqueRepository.GetWeeklyCritiqueWithTraineeAsync();
            dataGridView.DataSource = datas.ToList();

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
