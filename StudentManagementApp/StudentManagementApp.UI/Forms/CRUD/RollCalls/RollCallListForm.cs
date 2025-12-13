using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.RollCalls;
using StudentManagementApp.UI.Forms.CRUD.Trainees;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class RollCallListForm : Form
    {
        private readonly IRollCallRepository _rollCallRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;
        private List<RollCallViewModel> _rollCalls;
        private List<Class> _classes;
        private ToolStripButton btnFilter;
        private ToolStripLabel lblFilterStatus;
        private Dictionary<string, object> _currentFilters = new Dictionary<string, object>();

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
            imageList.Images.Add(Properties.Resources.filter_icon);

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

            btnFilter = new ToolStripButton("Lọc");
            btnFilter.ImageIndex = 3;
            btnFilter.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnFilter.ImageTransparentColor = Color.Magenta;

            lblFilterStatus = new ToolStripLabel("Đang hiển thị tất cả học viên");
            lblFilterStatus.ImageIndex = 4;
            lblFilterStatus.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            lblFilterStatus.ImageTransparentColor = Color.Magenta;

            toolStrip.Items.AddRange([btnAdd, btnEdit, btnRefresh, btnFilter, lblFilterStatus]);
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
            btnFilter.Click += async (s, e) => await BtnFilter_Click(s, e);
        }

        private async Task BtnFilter_Click(object s, EventArgs e)
        {
            using (var filterForm = new RollCallFilterForm(_classes))
            {
                filterForm.FilterApplied += (s, args) =>
                {
                    _currentFilters = args.FilterValues;
                    ApplyFilter();
                    UpdateFilterStatus();
                };

                filterForm.FilterCleared += (s, args) =>
                {
                    _currentFilters.Clear();
                    ApplyFilter();
                    UpdateFilterStatus();
                };

                filterForm.ShowDialog();
            }
        }

        private void ApplyFilter()
        {
            var filtered = _rollCalls.AsEnumerable();

            // Lọc theo lớp
            if (_currentFilters.ContainsKey("ClassId"))
            {
                var classId = (int)_currentFilters["ClassId"];
                filtered = filtered.Where(t => t.ClassId == classId);
            }

            dataGridView.DataSource = filtered.ToList();
        }

        private void UpdateFilterStatus()
        {
            if (!_currentFilters.Any())
            {
                lblFilterStatus.Text = "Đang hiển thị tất cả học viên";
                lblFilterStatus.ForeColor = Color.Blue;
            }
            else
            {
                var filterDetails = new List<string>();

                if (_currentFilters.ContainsKey("ClassId"))
                {
                    var classId = (int)_currentFilters["ClassId"];
                    var className = _classes.First(c => c.Id == classId).Name;
                    filterDetails.Add($"Lớp: {className}");
                }

                lblFilterStatus.Text = $"Đang lọc: {string.Join(", ", filterDetails)}";
                lblFilterStatus.ForeColor = Color.Green;
            }
        }

        private async void LoadRollCall()
        {
            var classes = await _classRepository.GetAllAsync();
            _classes = classes.ToList();

            var datas = await _rollCallRepository.GetRollCallsWithClassAsync();
            _rollCalls = datas.OrderBy(s => s.Date).ToList();
            dataGridView.DataSource = _rollCalls;

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
