using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class RollCallListForm : Form
    {
        private readonly IRepository<RollCall> _rollCallRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public RollCallListForm(
            IRepository<RollCall> rollCallRepository,
            IValidationService validationService)
        {
            _rollCallRepository = rollCallRepository;
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
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            this.Controls.Add(dataGridView);
            this.Controls.Add(toolStrip);

            btnAdd.Click += (s, e) => Add();
            btnEdit.Click += (s, e) => Edit();
            btnRefresh.Click += (s, e) => LoadRollCall();
        }

        private async void LoadRollCall()
        {
            var datas = await _rollCallRepository.GetAllAsync();
            dataGridView.DataSource = datas.ToList();

            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["CreatedDate"].HeaderText = "Ngày tạo";
            dataGridView.Columns["ModifiedDate"].HeaderText = "Ngày cập nhật";
            dataGridView.Columns["IsActive"].HeaderText = "Đang hoạt động";

            if (dataGridView.Columns["Date"] != null)
                dataGridView.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void Add()
        {
            var form = new RollCallForm(_rollCallRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadRollCall();
            }
        }

        private void Edit()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is RollCall selectedRollCall)
            {
                var form = new RollCallForm(_rollCallRepository, _validationService, selectedRollCall);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadRollCall();
                }
            }
        }
    }
}
