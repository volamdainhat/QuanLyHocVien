using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.SubjectAverages;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SubjectAverageListForm : Form
    {
        private readonly ISubjectAverageRepository _subjectAverageRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public SubjectAverageListForm(
            ISubjectAverageRepository subjectAverageRepository,
            IRepository<Subject> subjectRepository,
            IRepository<Trainee> traineeRepository,
            IValidationService validationService)
        {
            _subjectAverageRepository = subjectAverageRepository;
            _subjectRepository = subjectRepository;
            _traineeRepository = traineeRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeClassList();
            LoadSubjectAverages();
        }

        private void InitializeClassList()
        {
            this.Text = "Quản lý Điểm trung bình môn";
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

            //btnAdd.Click += (s, e) => AddSubjectAverage();
            //btnEdit.Click += (s, e) => EditSubjectAverage();
            btnRefresh.Click += (s, e) => LoadSubjectAverages();
        }

        private async void LoadSubjectAverages()
        {
            var subjectAverages = await _subjectAverageRepository.GetSubjectAverageWithSubjectTraineeAsync();
            dataGridView.DataSource = subjectAverages.ToList();

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        //private void AddSubjectAverage()
        //{
        //    var form = new SubjectAverageForm(_subjectAverageRepository, _subjectRepository, _traineeRepository, _validationService);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadSubjectAverages();
        //    }
        //}

        //private void EditSubjectAverage()
        //{
        //    if (dataGridView.CurrentRow?.DataBoundItem is SubjectAverageViewModel selectedSubjectAverage)
        //    {
        //        var subjectAverage = _subjectAverageRepository.GetByIdAsync(selectedSubjectAverage.Id).Result;
        //        var form = new SubjectAverageForm(_subjectAverageRepository, _subjectRepository, _traineeRepository, _validationService, subjectAverage);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            LoadSubjectAverages();
        //        }
        //    }
        //}
    }
}
