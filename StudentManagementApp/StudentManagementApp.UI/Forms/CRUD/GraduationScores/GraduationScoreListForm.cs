using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.GraduationScores;
using System.Threading.Tasks;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class GraduationScoreListForm : Form
    {
        private readonly IGraduationScoreRepository _graduationScoreRepository;
        private readonly ITraineeRepository _traineeRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public GraduationScoreListForm(
            IGraduationScoreRepository graduationScoreRepository,
            ITraineeRepository traineeRepository,
            IValidationService validationService)
        {
            _graduationScoreRepository = graduationScoreRepository;
            _traineeRepository = traineeRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeGraduationScoresList();
            LoadGraduationScores();
        }

        private void InitializeGraduationScoresList()
        {
            this.Text = "Quản lý Điểm xét tốt nghiệp";
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

            btnAdd.Click += (s, e) => Add();
            btnEdit.Click += async (s, e) => await Edit();
            btnRefresh.Click += (s, e) => LoadGraduationScores();
        }

        private async void LoadGraduationScores()
        {
            var datas = await _graduationScoreRepository.GetGraduationScoreWithTraineeAsync();
            dataGridView.DataSource = datas.ToList();

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void Add()
        {
            var form = new GraduationScoreForm(_graduationScoreRepository, _traineeRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadGraduationScores();
            }
        }

        private async Task Edit()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is GraduationScoreViewModel selected)
            {
                var entity = await _graduationScoreRepository.GetByIdAsync(selected.Id);
                var form = new GraduationScoreForm(_graduationScoreRepository, _traineeRepository, _validationService, entity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadGraduationScores();
                }
            }
        }
    }
}
