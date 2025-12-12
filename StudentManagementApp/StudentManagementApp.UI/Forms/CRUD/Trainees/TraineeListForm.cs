using OfficeOpenXml;
using OfficeOpenXml.Style;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Categories;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.UI.Forms.CRUD.Trainees;
using System.Globalization;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class TraineeListForm : Form
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IClassRepository _classRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private readonly IReportService _reportService;

        private DataGridView? dataGridView;

        private List<TraineeViewModel> _trainees;
        private List<Class> _classes;
        private ToolStripButton btnFilter;
        private ToolStripLabel lblFilterStatus;
        private Dictionary<string, object> _currentFilters = new Dictionary<string, object>();

        public TraineeListForm(ITraineeRepository traineeRepository,
            IClassRepository classRepository,
            ICategoryRepository categoryRepository,
            IValidationService validationService,
            IReportService reportService)
        {
            _traineeRepository = traineeRepository;
            _classRepository = classRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            _reportService = reportService;
            InitializeComponent();
            InitializeTraineeList();

            LoadTrainees();
            _reportService = reportService;
        }

        private void InitializeTraineeList()
        {
            this.Text = "Quản lý Học viên";
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
            imageList.Images.Add(Properties.Resources.import_icon);
            imageList.Images.Add(Properties.Resources.template_icon);
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

            var btnImport = new ToolStripButton("Import");
            btnImport.ImageIndex = 3;
            btnImport.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnImport.ImageTransparentColor = Color.Magenta;

            var btnTemplate = new ToolStripButton("Template");
            btnTemplate.ImageIndex = 4;
            btnTemplate.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnTemplate.ImageTransparentColor = Color.Magenta;

            btnFilter = new ToolStripButton("Lọc");
            btnFilter.ImageIndex = 5;
            btnFilter.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btnFilter.ImageTransparentColor = Color.Magenta;

            lblFilterStatus = new ToolStripLabel("Đang hiển thị tất cả học viên");
            lblFilterStatus.ImageIndex = 6;
            lblFilterStatus.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            lblFilterStatus.ImageTransparentColor = Color.Magenta;

            toolStrip.Items.AddRange([btnAdd, btnEdit, btnRefresh, btnImport, btnTemplate, btnFilter, lblFilterStatus]);
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

            btnAdd.Click += (s, e) => AddTrainee();
            btnEdit.Click += async (s, e) => await EditTrainee();
            btnRefresh.Click += (s, e) => LoadTrainees();
            btnFilter.Click += async (s, e) => await BtnFilter_Click(s, e);
            btnImport.Click += async (s, e) => await BtnImport_Click(s, e);
            btnTemplate.Click += (s, e) => BtnGenerateTemplate_Click(s, e);
        }

        private async Task BtnFilter_Click(object sender, EventArgs e)
        {
            var educationLevels = await LoadEducationLevels();

            using (var filterForm = new TraineeFilterForm(_classes, educationLevels))
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
            var filtered = _trainees.AsEnumerable();

            // Lọc theo lớp
            if (_currentFilters.ContainsKey("ClassId"))
            {
                var classId = (int)_currentFilters["ClassId"];
                filtered = filtered.Where(t => t.ClassId == classId);
            }

            // Lọc theo tên
            if (_currentFilters.ContainsKey("SearchText"))
            {
                var searchText = (string)_currentFilters["SearchText"];
                filtered = filtered.Where(t =>
                    t.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            // Lọc theo giới tính
            if (_currentFilters.ContainsKey("Gender"))
            {
                var gender = (bool)_currentFilters["Gender"];
                filtered = filtered.Where(t => t.Gender == gender);
            }

            // Lọc theo trình độ
            if (_currentFilters.ContainsKey("EducationLevel"))
            {
                var educationLevel = (string)_currentFilters["EducationLevel"];
                filtered = filtered.Where(t => t.EducationalLevel == educationLevel);
            }

            // Lọc học viên có lớp
            if (_currentFilters.ContainsKey("HasClass"))
            {
                filtered = filtered.Where(t => t.ClassId.HasValue);
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

                if (_currentFilters.ContainsKey("SearchText"))
                    filterDetails.Add($"Tên: {_currentFilters["SearchText"]}");

                if (_currentFilters.ContainsKey("Gender"))
                    filterDetails.Add($"Giới tính: {((bool)_currentFilters["Gender"] ? "Nam" : "Nữ")}");

                if (_currentFilters.ContainsKey("EducationLevel"))
                    filterDetails.Add($"Trình độ: {_currentFilters["EducationLevel"]}");

                if (_currentFilters.ContainsKey("HasClass"))
                    filterDetails.Add("Đã có lớp");

                lblFilterStatus.Text = $"Đang lọc: {string.Join(", ", filterDetails)}";
                lblFilterStatus.ForeColor = Color.Green;
            }
        }

        private async void LoadTrainees()
        {
            var classes = await _classRepository.GetAllAsync();
            var trainees = await _traineeRepository.GetTraineesWithClassAsync();

            _classes = classes.ToList();
            _trainees = trainees.ToList();

            dataGridView.DataSource = _trainees;

            if (dataGridView.Columns["DayOfBirth"] != null)
                dataGridView.Columns["DayOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            ApplyFilter();
        }

        private async Task<List<CategoryViewModel>> LoadEducationLevels()
        {
            var educationalLevels = await _categoryRepository.GetCategoriesWithTypeAsync("EducationLevel");
            educationalLevels = educationalLevels.Where(sy => sy.IsActive).ToList();
            return educationalLevels.ToList();
        }
        private void AddTrainee()
        {
            var form = new TraineeForm(_traineeRepository, _classRepository, _categoryRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrainees();
            }
        }

        private async Task EditTrainee()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is TraineeViewModel selectedTrainee)
            {
                var traineeEntity = await _traineeRepository.GetByIdAsync(selectedTrainee.Id);
                var form = new TraineeForm(_traineeRepository, _classRepository, _categoryRepository, _validationService, traineeEntity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTrainees();
                }
            }
        }

        private async Task BtnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Chọn file Excel để import";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await ImportTraineesFromExcel(openFileDialog.FileName);

                        await _classRepository.UpdateTotalStudentsForAllClassAsync();

                        MessageBox.Show("Import dữ liệu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi import dữ liệu: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LoadTrainees();
        }

        private void BtnGenerateTemplate_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Lưu file template Excel";
                saveFileDialog.FileName = "Trainee_Import_Template.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CreateExcelTemplate(saveFileDialog.FileName);
                        MessageBox.Show("Đã tạo file template thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tạo template: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CreateExcelTemplate(string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Võ Lâm Đại Nhất");
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Trainees");

                // Thêm headers
                worksheet.Cells[1, 1].Value = "Họ và tên";
                worksheet.Cells[1, 2].Value = "Ngày sinh (dd/MM/yyyy)";
                worksheet.Cells[1, 3].Value = "Giới tính (Nam/Nữ)";
                worksheet.Cells[1, 4].Value = "Tên lớp";
                worksheet.Cells[1, 5].Value = "Quân hàm";
                worksheet.Cells[1, 6].Value = "Tỉnh nhập ngũ";
                worksheet.Cells[1, 7].Value = "Ngày nhập ngũ (dd/MM/yyyy)";
                worksheet.Cells[1, 8].Value = "Số CMND/CCCD";
                worksheet.Cells[1, 9].Value = "Dân tộc";
                worksheet.Cells[1, 10].Value = "Quê quán";
                worksheet.Cells[1, 11].Value = "Nơi thường trú";
                worksheet.Cells[1, 12].Value = "Số điện thoại";
                worksheet.Cells[1, 13].Value = "Trình độ học vấn";
                worksheet.Cells[1, 14].Value = "Địa chỉ liên hệ";
                worksheet.Cells[1, 15].Value = "Tình trạng sức khỏe";
                worksheet.Cells[1, 16].Value = "Họ tên bố";
                worksheet.Cells[1, 17].Value = "SĐT bố";
                worksheet.Cells[1, 18].Value = "Họ tên mẹ";
                worksheet.Cells[1, 19].Value = "SĐT mẹ";

                // Định dạng header
                using (var range = worksheet.Cells[1, 1, 1, 19])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                }

                // Thêm dữ liệu mẫu
                worksheet.Cells[2, 1].Value = "Nguyễn Văn A";
                worksheet.Cells[2, 2].Value = "15/01/2000"; // Giữ nguyên định dạng chuỗi
                worksheet.Cells[2, 3].Value = "Nam";
                worksheet.Cells[2, 4].Value = "NVQYcK42A1";
                worksheet.Cells[2, 5].Value = "Binh nhất";
                worksheet.Cells[2, 6].Value = "Hà Nội";
                worksheet.Cells[2, 7].Value = "01/03/2023";
                worksheet.Cells[2, 8].Value = "001200000001";
                worksheet.Cells[2, 9].Value = "Kinh";
                worksheet.Cells[2, 10].Value = "Hà Nội";
                worksheet.Cells[2, 11].Value = "Hà Nội";
                worksheet.Cells[2, 12].Value = "0912345678";
                worksheet.Cells[2, 13].Value = "Đại học";
                worksheet.Cells[2, 14].Value = "Hà Nội";
                worksheet.Cells[2, 15].Value = "Tốt";
                worksheet.Cells[2, 16].Value = "Nguyễn Văn Bố";
                worksheet.Cells[2, 17].Value = "0912345679";
                worksheet.Cells[2, 18].Value = "Nguyễn Thị Mẹ";
                worksheet.Cells[2, 19].Value = "0912345680";

                // Định dạng cột ngày tháng
                worksheet.Column(2).Style.Numberformat.Format = "dd/MM/yyyy";
                worksheet.Column(7).Style.Numberformat.Format = "dd/MM/yyyy";

                // Tự động điều chỉnh độ rộng cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Lưu file
                package.SaveAs(new FileInfo(filePath));
            }
        }

        private async Task ImportTraineesFromExcel(string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Võ Lâm Đại Nhất");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                var trainees = new List<Trainee>();

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        var className = GetString(worksheet.Cells[row, 4]);
                        var classEntity = await _classRepository.FindAsync(c => c.Name.ToLower() == className.ToLower());
                        var existingClass = classEntity.FirstOrDefault(); // Lấy đối tượng đầu tiên

                        int? classId = null;

                        if (existingClass != null)
                        {
                            classId = existingClass.Id; // Lấy ID nếu tìm thấy
                        }
                        else
                        {
                            // Tạo mới nếu không tìm thấy
                            var newClass = new Class()
                            {
                                Name = className,
                                TotalStudents = 0,
                            };

                            classId = await _classRepository.AddAsync(newClass);
                        }

                        var trainee = new Trainee
                        {
                            FullName = GetString(worksheet.Cells[row, 1]),
                            DayOfBirth = ParseDate(worksheet.Cells[row, 2]),
                            Gender = GetString(worksheet.Cells[row, 3]).Equals("Nam", StringComparison.OrdinalIgnoreCase),
                            ClassId = classId,
                            MilitaryRank = GetString(worksheet.Cells[row, 5]),
                            ProvinceOfEnlistment = GetString(worksheet.Cells[row, 6]),
                            EnlistmentDate = ParseDate(worksheet.Cells[row, 7]),
                            IdentityCard = GetString(worksheet.Cells[row, 8]),
                            Ethnicity = GetString(worksheet.Cells[row, 9]),
                            PlaceOfOrigin = GetString(worksheet.Cells[row, 10]),
                            PlaceOfPermanentResidence = GetString(worksheet.Cells[row, 11]),
                            PhoneNumber = GetString(worksheet.Cells[row, 12]),
                            EducationalLevel = GetString(worksheet.Cells[row, 13]),
                            AddressForCorrespondence = GetString(worksheet.Cells[row, 14]),
                            HealthStatus = GetString(worksheet.Cells[row, 15]),
                            Role = "Học viên",
                            FatherFullName = GetString(worksheet.Cells[row, 16]),
                            FatherPhoneNumber = GetString(worksheet.Cells[row, 17]),
                            MotherFullName = GetString(worksheet.Cells[row, 18]),
                            MotherPhoneNumber = GetString(worksheet.Cells[row, 19]),
                        };

                        trainees.Add(trainee);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi tại dòng {row}: {ex.Message}");
                    }
                }

                await _traineeRepository.AddRangeAsync(trainees);
                await _classRepository.UpdateTotalStudentsForAllClassAsync();
            }
        }

        // Các hàm helper để xử lý dữ liệu
        private string GetString(ExcelRange cell)
        {
            return cell.Text?.Trim() ?? string.Empty;
        }

        private DateTime ParseDate(ExcelRange cell)
        {
            var dateString = cell.Text?.Trim();

            if (string.IsNullOrWhiteSpace(dateString))
                return DateTime.MinValue;

            // Kiểm tra nếu ô Excel đã được định dạng là DateTime
            if (cell.Value is DateTime dateValue)
                return dateValue;

            // Thử parse theo định dạng dd/MM/yyyy
            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;

            // Thử parse theo các định dạng khác
            if (DateTime.TryParse(dateString, CultureInfo.CurrentCulture, DateTimeStyles.None, out result))
                return result;

            throw new Exception($"Định dạng ngày tháng không hợp lệ: {dateString}");
        }

        private int GetInt(ExcelRange cell)
        {
            if (int.TryParse(cell.Text, out int result))
                return result;

            throw new Exception($"Giá trị số nguyên không hợp lệ: {cell.Text}");
        }

        private decimal GetDecimal(ExcelRange cell)
        {
            if (decimal.TryParse(cell.Text, out decimal result))
                return result;

            throw new Exception($"Giá trị số thập phân không hợp lệ: {cell.Text}");
        }
    }
}
