using OfficeOpenXml;
using OfficeOpenXml.Style;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.Categories;
using StudentManagementApp.Infrastructure.Repositories.Trainees;
using System.Globalization;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class TraineeListForm : Form
    {
        private readonly ITraineeRepository _traineeRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private DataGridView? dataGridView;

        public TraineeListForm(ITraineeRepository traineeRepository, IRepository<Class> classRepository, ICategoryRepository categoryRepository, IValidationService validationService)
        {
            _traineeRepository = traineeRepository;
            _classRepository = classRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            InitializeComponent();
            InitializeTraineeList();
            LoadTrainees();
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

            toolStrip.Items.AddRange([btnAdd, btnEdit, btnRefresh, btnImport, btnTemplate]);
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

            btnAdd.Click += (s, e) => AddTrainee();
            btnEdit.Click += (s, e) => EditTrainee();
            btnRefresh.Click += (s, e) => LoadTrainees();
            btnImport.Click += (s, e) => BtnImport_Click(s, e);
            btnTemplate.Click += (s, e) => BtnGenerateTemplate_Click(s, e);
        }

        private async void LoadTrainees()
        {
            var Classs = await _traineeRepository.GetTraineesWithClassAsync();
            dataGridView.DataSource = Classs.ToList();

            if (dataGridView.Columns["DayOfBirth"] != null)
                dataGridView.Columns["DayOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (dataGridView.Columns["CreatedDate"] != null)
                dataGridView.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            if (dataGridView.Columns["ModifiedDate"] != null)
                dataGridView.Columns["ModifiedDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
        }

        private void AddTrainee()
        {
            var form = new TraineeForm(_traineeRepository, _classRepository, _categoryRepository, _validationService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadTrainees();
            }
        }

        private void EditTrainee()
        {
            if (dataGridView.CurrentRow?.DataBoundItem is TraineeViewModel selectedTrainee)
            {
                var traineeEntity = _traineeRepository.GetByIdAsync(selectedTrainee.Id).Result;
                var form = new TraineeForm(_traineeRepository, _classRepository, _categoryRepository, _validationService, traineeEntity);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadTrainees();
                }
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
                openFileDialog.Title = "Chọn file Excel để import";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImportTraineesFromExcel(openFileDialog.FileName);
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
            ExcelPackage.License.SetNonCommercialPersonal("Dain");
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Trainees");

                // Thêm headers
                worksheet.Cells[1, 1].Value = "Họ và tên";
                worksheet.Cells[1, 2].Value = "Ngày sinh (dd/MM/yyyy)";
                worksheet.Cells[1, 3].Value = "Giới tính (Nam/Nữ)";
                worksheet.Cells[1, 4].Value = "Số CMND/CCCD";
                worksheet.Cells[1, 5].Value = "Dân tộc";
                worksheet.Cells[1, 6].Value = "Nguyên quán";
                worksheet.Cells[1, 7].Value = "Nơi thường trú";
                worksheet.Cells[1, 8].Value = "Số điện thoại";
                worksheet.Cells[1, 9].Value = "Tỉnh nhập ngũ";
                worksheet.Cells[1, 10].Value = "Trình độ học vấn";
                worksheet.Cells[1, 11].Value = "Địa chỉ liên hệ";
                worksheet.Cells[1, 12].Value = "Ngày nhập ngũ (dd/MM/yyyy)";
                worksheet.Cells[1, 13].Value = "Quân hàm";
                worksheet.Cells[1, 14].Value = "Tình trạng sức khỏe";
                worksheet.Cells[1, 15].Value = "Vai trò";
                worksheet.Cells[1, 16].Value = "Điểm trung bình";
                worksheet.Cells[1, 17].Value = "Họ tên bố";
                worksheet.Cells[1, 18].Value = "SĐT bố";
                worksheet.Cells[1, 19].Value = "Họ tên mẹ";
                worksheet.Cells[1, 20].Value = "SĐT mẹ";

                // Định dạng header
                using (var range = worksheet.Cells[1, 1, 1, 20])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                }

                // Thêm dữ liệu mẫu
                worksheet.Cells[2, 1].Value = "Nguyễn Văn A";
                worksheet.Cells[2, 2].Value = "15/01/2000"; // Giữ nguyên định dạng chuỗi
                worksheet.Cells[2, 3].Value = "Nam";
                worksheet.Cells[2, 4].Value = "001200000001";
                worksheet.Cells[2, 5].Value = "Kinh";
                worksheet.Cells[2, 6].Value = "Hà Nội";
                worksheet.Cells[2, 7].Value = "Hà Nội";
                worksheet.Cells[2, 8].Value = "0912345678";
                worksheet.Cells[2, 9].Value = "Hà Nội";
                worksheet.Cells[2, 10].Value = "Đại học";
                worksheet.Cells[2, 11].Value = "Hà Nội";
                worksheet.Cells[2, 12].Value = "01/03/2023";
                worksheet.Cells[2, 13].Value = "Binh nhất";
                worksheet.Cells[2, 14].Value = "Tốt";
                worksheet.Cells[2, 15].Value = "Học viên";
                worksheet.Cells[2, 16].Value = 8.5;
                worksheet.Cells[2, 17].Value = "Nguyễn Văn Bố";
                worksheet.Cells[2, 18].Value = "0912345679";
                worksheet.Cells[2, 19].Value = "Nguyễn Thị Mẹ";
                worksheet.Cells[2, 20].Value = "0912345680";

                // Định dạng cột ngày tháng
                worksheet.Column(2).Style.Numberformat.Format = "dd/MM/yyyy";
                worksheet.Column(12).Style.Numberformat.Format = "dd/MM/yyyy";

                // Tự động điều chỉnh độ rộng cột
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Lưu file
                package.SaveAs(new FileInfo(filePath));
            }
        }

        private async Task ImportTraineesFromExcel(string filePath)
        {
            ExcelPackage.License.SetNonCommercialPersonal("Dain");
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                var trainees = new List<Trainee>();

                for (int row = 2; row <= rowCount; row++)
                {
                    try
                    {
                        var trainee = new Trainee
                        {
                            FullName = GetString(worksheet.Cells[row, 1]),
                            DayOfBirth = ParseDate(worksheet.Cells[row, 2]),
                            Gender = GetString(worksheet.Cells[row, 3]).Equals("Nam", StringComparison.OrdinalIgnoreCase),
                            IdentityCard = GetString(worksheet.Cells[row, 4]),
                            Ethnicity = GetString(worksheet.Cells[row, 5]),
                            PlaceOfOrigin = GetString(worksheet.Cells[row, 6]),
                            PlaceOfPermanentResidence = GetString(worksheet.Cells[row, 7]),
                            PhoneNumber = GetString(worksheet.Cells[row, 8]),
                            ProvinceOfEnlistment = GetString(worksheet.Cells[row, 9]),
                            EducationalLevel = GetString(worksheet.Cells[row, 10]),
                            AddressForCorrespondence = GetString(worksheet.Cells[row, 11]),
                            EnlistmentDate = ParseDate(worksheet.Cells[row, 12]),
                            MilitaryRank = GetString(worksheet.Cells[row, 13]),
                            HealthStatus = GetString(worksheet.Cells[row, 14]),
                            Role = GetString(worksheet.Cells[row, 15]),
                            FatherFullName = GetString(worksheet.Cells[row, 17]),
                            FatherPhoneNumber = GetString(worksheet.Cells[row, 18]),
                            MotherFullName = GetString(worksheet.Cells[row, 19]),
                            MotherPhoneNumber = GetString(worksheet.Cells[row, 20]),
                        };

                        trainees.Add(trainee);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Lỗi tại dòng {row}: {ex.Message}");
                    }
                }

                await _traineeRepository.AddRangeAsync(trainees);
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
                throw new Exception("Ngày tháng không được để trống");

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
