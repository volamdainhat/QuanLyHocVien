using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Classes;
using System.Threading.Tasks;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ClassListForm : Form
    {
        private readonly IClassRepository _classRepository;
        private readonly IRepository<SchoolYear> _schoolYearRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public ClassListForm(IClassRepository classRepository, IRepository<SchoolYear> schoolYearRepository, IValidationService validationService)
        {
            _classRepository = classRepository;
            _schoolYearRepository = schoolYearRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadClasses();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Lớp học";
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
            btnRefresh.Click += (s, e) => LoadClasses();
        }

        private async void LoadClasses()
        {
            var Classs = await _classRepository.GetClassesWithSchoolYearAsync();
            dataGridView.DataSource = Classs.ToList();

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void Add()
        {
            var form = new ClassForm(_classRepository, _schoolYearRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadClasses();
            }
        }

        private async Task Edit()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is ClassViewModel selectedClass)
            {
                var classEntity = await _classRepository.GetByIdAsync(selectedClass.Id);
                var form = new ClassForm(_classRepository, _schoolYearRepository, _validationService, classEntity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadClasses();
                }
            }
        }
    }
}
