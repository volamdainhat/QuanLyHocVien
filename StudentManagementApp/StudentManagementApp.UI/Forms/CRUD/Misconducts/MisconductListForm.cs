using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Misconducts;
using System.Threading.Tasks;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class MisconductListForm : Form
    {
        private readonly IMisconductRepository _misconductRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public MisconductListForm(
            IMisconductRepository misconductRepository,
            IRepository<Trainee> traineeRepository,
            ICategoryRepository categoryRepository,
            IValidationService validationService)
        {
            _misconductRepository = misconductRepository;
            _traineeRepository = traineeRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadMisconducts();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Ví phạm kỷ luật";
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

            btnAdd.Click += (s, e) => AddMisconduct();
            btnEdit.Click += async (s, e) => await EditMisconduct();
            btnRefresh.Click += (s, e) => LoadMisconducts();
        }

        private async void LoadMisconducts()
        {
            var misconducts = await _misconductRepository.GetMisconductsWithTraineeAsync();
            dataGridView.DataSource = misconducts.ToList();

            if (dataGridView.Columns["Time"] != null)
                dataGridView.Columns["Time"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void AddMisconduct()
        {
            var form = new MisconductForm(_misconductRepository, _traineeRepository, _categoryRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadMisconducts();
            }
        }

        private async Task EditMisconduct()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is MisconductViewModel selectedMisconduct)
            {
                var misconduct = await _misconductRepository.GetByIdAsync(selectedMisconduct.Id);
                var form = new MisconductForm(_misconductRepository, _traineeRepository, _categoryRepository, _validationService, misconduct);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadMisconducts();
                }
            }
        }
    }
}
