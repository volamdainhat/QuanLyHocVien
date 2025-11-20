using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.RollCalls;
using StudentManagementApp.Infrastructure.Repositories;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class RollCallListForm : Form
    {
        private readonly IRollCallRepository _rollCallRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public RollCallListForm(
            IRollCallRepository rollCallRepository,
            IRepository<Class> classRepository,
            IValidationService validationService)
        {
            _rollCallRepository = rollCallRepository;
            _classRepository = classRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeRollCallList();
            LoadRollCall();
        }

        private void InitializeRollCallList()
        {
            this.Text = "Quản lý Điểm danh";
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

            btnAdd.Click += (s, e) => Add();
            btnEdit.Click += (s, e) => Edit();
            btnRefresh.Click += (s, e) => LoadRollCall();
        }

        private async void LoadRollCall()
        {
            var datas = await _rollCallRepository.GetRollCallsWithClassAsync();
            dataGridView.DataSource = datas.OrderBy(s => s.Date).ToList();

            if (dataGridView.Columns["Id"] != null)
                dataGridView.Columns["Id"].Visible = false;

            if (dataGridView.Columns["IsActive"] != null)
                dataGridView.Columns["IsActive"].HeaderText = "Đang hoạt động";

            if (dataGridView.Columns["Date"] != null)
                dataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dataGridView.Columns["CreatedDate"] != null)
            {
                dataGridView.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }

            if (dataGridView.Columns["ModifiedDate"] != null)
            {
                dataGridView.Columns["ModifiedDate"].HeaderText = "Ngày cập nhật";
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
        }

        private void Add()
        {
            var form = new RollCallForm(_rollCallRepository, _classRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadRollCall();
            }
        }

        private async Task Edit()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is RollCallViewModel selectedRollCall)
            {
                var entity = await _rollCallRepository.GetByIdAsync(selectedRollCall.Id);
                var form = new RollCallForm(_rollCallRepository, _classRepository, _validationService, entity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadRollCall();
                }
            }
        }
    }
}
