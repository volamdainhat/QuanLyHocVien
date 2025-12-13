using OfficeOpenXml;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.TraineeAverageScores;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.UI.Forms.CRUD.Trainees;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class TraineeAverageScoreListForm : Form
    {
        private readonly ITraineeAverageScoreRepository _traineeAverageScoreRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IRepository<Semester> _semesterRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;
        private DataGridView? dgvSummary;
        private List<TraineeAverageScoreViewModel> _traineeAverageScores;
        private List<Class> _classes;
        private ToolStripButton btnFilter;
        private ToolStripLabel lblFilterStatus;
        private Dictionary<string, object> _currentFilters = new Dictionary<string, object>();

        public TraineeAverageScoreListForm(
            ITraineeAverageScoreRepository traineeAverageScoreRepository,
            IRepository<Trainee> traineeRepository,
            IRepository<Semester> semesterRepository,
            IRepository<Class> classRepository,
            IValidationService validationService)
        {
            _traineeAverageScoreRepository = traineeAverageScoreRepository;
            _traineeRepository = traineeRepository;
            _semesterRepository = semesterRepository;
            _classRepository = classRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeTraineeAverageScoreList();
            LoadTraineeAverageScores();
        }

        private void InitializeTraineeAverageScoreList()
        {
            this.Text = "Quản lý Điểm trung bình khóa";
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
            imageList.Images.Add(Properties.Resources.export_excel_icon);
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

            var btnExport = new ToolStripButton("Xuất Excel");
            btnExport.ImageIndex = 3;
            btnExport.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnExport.ImageTransparentColor = Color.Magenta;

            btnFilter = new ToolStripButton("Lọc");
            btnFilter.ImageIndex = 4;
            btnFilter.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnFilter.ImageTransparentColor = Color.Magenta;

            lblFilterStatus = new ToolStripLabel("Đang hiển thị tất cả học viên");
            lblFilterStatus.ImageIndex = 5;
            lblFilterStatus.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            lblFilterStatus.ImageTransparentColor = Color.Magenta;

            toolStrip.Items.AddRange([btnRefresh, btnExport, btnFilter, lblFilterStatus]);
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

            dgvSummary = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Visible = false
            };

            this.Controls.Add(dataGridView);
            this.Controls.Add(dgvSummary);
            this.Controls.Add(toolStrip);

            //btnAdd.Click += (s, e) => Add();
            //btnEdit.Click += (s, e) => Edit();
            btnRefresh.Click += (s, e) => LoadTraineeAverageScores();
            btnExport.Click += (s, e) => btnExport_Click();
            btnFilter.Click += async (s, e) => await BtnFilter_Click(s, e);
        }

        private async Task BtnFilter_Click(object s, EventArgs e)
        {
            using (var filterForm = new TraineeAverageScoreFilterForm(_classes))
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
            var filtered = _traineeAverageScores.AsEnumerable();

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

        private async void btnExport_Click()
        {
            var scoreSummarys = await _traineeAverageScoreRepository.GetGradeTypeSummaryAsync();
            dgvSummary.DataSource = scoreSummarys;

            var dataGridViews = new Dictionary<string, DataGridView>
            {
                { "Tổng hợp", dgvSummary },
                { "Điểm trung bình khóa", dataGridView }
            };

            ExportMultipleWithProgress(dataGridViews);
        }

        private async void LoadTraineeAverageScores()
        {
            var classes = await _classRepository.GetAllAsync();
            _classes = classes.ToList();
             
            var data = await _traineeAverageScoreRepository.GetTraineeAverageScoreWithTraineeSemesterAsync();
            _traineeAverageScores = data.ToList();
            dataGridView.DataSource = _traineeAverageScores;

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        //private void Add()
        //{
        //    var form = new SemesterAverageForm(_SemesterAverageRepository, _SemesterRepository, _traineeRepository, _validationService);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        LoadSemesterAverages();
        //    }
        //}

        //private void Edit()
        //{
        //    if (dataGridView.CurrentRow?.DataBoundItem is SemesterAverageViewModel selectedSemesterAverage)
        //    {
        //        var SemesterAverage = _SemesterAverageRepository.GetByIdAsync(selectedSemesterAverage.Id).Result;
        //        var form = new SemesterAverageForm(_SemesterAverageRepository, _SemesterRepository, _traineeRepository, _validationService, SemesterAverage);
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            LoadSemesterAverages();
        //        }
        //    }
        //}

        private async void ExportMultipleWithProgress(Dictionary<string, DataGridView> dataGridViews)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Điểm trung bình khóa";
                saveFileDialog.FileName = "Điểm trung bình khóa.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị ProgressBar
                    ProgressForm progressForm = new ProgressForm();
                    progressForm.Show();

                    try
                    {
                        await Task.Run(() =>
                        {
                            ExcelPackage.License.SetNonCommercialPersonal("Võ Lâm Đại Nhất");

                            using (ExcelPackage excelPackage = new ExcelPackage())
                            {
                                int totalSheets = dataGridViews.Count;
                                int currentSheet = 0;

                                foreach (var item in dataGridViews)
                                {
                                    currentSheet++;
                                    string sheetName = item.Key;
                                    DataGridView dgv = item.Value;

                                    // Cập nhật tiến trình
                                    progressForm.UpdateProgress($"Đang xuất sheet: {sheetName}",
                                                               (currentSheet * 100) / totalSheets);

                                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(sheetName);

                                    // Xuất dữ liệu (giống code trên)
                                    ExportDataGridViewToWorksheet(dgv, worksheet);
                                }

                                // Lưu file
                                FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                                excelPackage.SaveAs(excelFile);
                            }
                        });

                        progressForm.Close();
                        MessageBox.Show("Xuất Excel thành công!");
                    }
                    catch (Exception ex)
                    {
                        progressForm.Close();
                        MessageBox.Show($"Lỗi: {ex.Message}");
                    }
                }
            }
        }

        // Hàm phụ trợ xuất DataGridView vào Worksheet
        private void ExportDataGridViewToWorksheet(DataGridView dgv, ExcelWorksheet worksheet)
        {
            // Xuất tiêu đề
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = dgv.Columns[i].HeaderText;
                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
            }

            // Xuất dữ liệu
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = dgv.Rows[i].Cells[j].Value?.ToString();
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        }
    }
}
