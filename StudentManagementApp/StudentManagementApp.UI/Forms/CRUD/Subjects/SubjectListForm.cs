using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SubjectListForm : Form
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public SubjectListForm(ISubjectRepository subjectRepository, IValidationService validationService)
        {
            _subjectRepository = subjectRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadSubjects();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Môn học";
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

            btnAdd.Click += (s, e) => AddSubject();
            btnEdit.Click += (s, e) => EditSubject();
            btnRefresh.Click += (s, e) => LoadSubjects();
        }

        private async void LoadSubjects()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            dataGridView.DataSource = subjects.ToList();

            // Dictionary ánh xạ tên cột với cấu hình
            var columnConfigurations = new Dictionary<string, Action<DataGridViewColumn>>
            {
                { "Id", col => col.Visible = false },
                { "Code", col => col.HeaderText = "Mã môn học" },
                { "Name", col => col.HeaderText = "Môn học" },
                { "Coefficient", col => col.HeaderText = "Hệ số" },
                { "CreatedDate", col => {
                    col.HeaderText = "Ngày tạo";
                    col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                } },
                { "ModifiedDate", col => {
                    col.HeaderText = "Ngày cập nhật";
                    col.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                } },
                { "IsActive", col => col.HeaderText = "Đang hoạt động" }
            };

            // Áp dụng cấu hình
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (columnConfigurations.ContainsKey(column.DataPropertyName))
                {
                    columnConfigurations[column.DataPropertyName].Invoke(column);
                }
            }
        }

        private void AddSubject()
        {
            var form = new SubjectForm(_subjectRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadSubjects();
            }
        }

        private void EditSubject()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is Subject subject)
            {
                var form = new SubjectForm(_subjectRepository, _validationService, subject);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSubjects();
                }
            }
        }
    }
}
