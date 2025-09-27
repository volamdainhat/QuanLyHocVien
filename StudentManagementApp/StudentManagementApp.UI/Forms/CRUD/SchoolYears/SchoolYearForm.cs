using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SchoolYearForm : BaseCrudForm
    {
        private readonly IRepository<SchoolYear> _schoolYearRepository;
        private readonly IValidationService _validationService;
        private SchoolYear _schoolYear;
        private TextBox txtName;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;

        public SchoolYearForm(
            IRepository<SchoolYear> schoolYearRepository,
            IValidationService validationService,
            SchoolYear? SchoolYear = null)
        {
            _schoolYearRepository = schoolYearRepository;
            _validationService = validationService;
            _schoolYear = SchoolYear ?? new SchoolYear() { Name = string.Empty, StartDate = DateTime.Now, EndDate = DateTime.Now };
            InitializeComponent();
            InitializeSchoolYearForm();
            LoadSchoolYearData();
        }

        private void InitializeSchoolYearForm()
        {
            if (_schoolYear.Id == 0)
            {
                this.Text = "Thêm mới Niên khóa";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Niên khóa";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;

            // Name
            formPanel.Controls.Add(new Label { Text = "Khóa học:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtName = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtName);
            y += 40;

            // StartDate
            formPanel.Controls.Add(new Label { Text = "Ngày khai giảng:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpStartDate = new DateTimePicker { Location = new Point(x2, y), Width = textBoxWidth };
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            formPanel.Controls.Add(dtpStartDate);
            y += 40;

            // EndDate
            formPanel.Controls.Add(new Label { Text = "Ngày tổng kết:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpEndDate = new DateTimePicker { Location = new Point(x2, y), Width = textBoxWidth };
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            formPanel.Controls.Add(dtpEndDate);
            y += 40;

            // Thêm sự kiện validating
            txtName.Validating += TxtName_Validating;
            dtpStartDate.Validating += DtpStartDate_Validating;
            dtpEndDate.Validating += DtpEndDate_Validating;
        }

        private void LoadSchoolYearData()
        {
            if (_schoolYear.Id > 0)
            {
                txtName.Text = _schoolYear.Name;
                dtpStartDate.Value = _schoolYear.StartDate;
                dtpEndDate.Value = _schoolYear.EndDate;
            }
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _schoolYear.Name = txtName.Text;
                    _schoolYear.StartDate = dtpStartDate.Value;
                    _schoolYear.EndDate = dtpEndDate.Value;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_schoolYear);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_schoolYear.Id == 0)
                    {
                        _schoolYear.CreatedDate = DateTime.Now;
                        await _schoolYearRepository.AddAsync(_schoolYear);
                    }
                    else
                    {
                        _schoolYear.ModifiedDate = DateTime.Now;
                        await _schoolYearRepository.UpdateAsync(_schoolYear);
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Hiển thị thông báo khi form validation không thành công
                MessageBox.Show("Vui lòng kiểm tra lại thông tin nhập vào. Có lỗi trong biểu mẫu.",
                                "Lỗi nhập liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        protected override async void Delete()
        {
            if (_schoolYear.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa niên khóa này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _schoolYearRepository.DeleteAsync(_schoolYear);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            // Validate Name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Tên niên khóa là bắt buộc");
                isValid = false;
            }
            else if (txtName.Text.Length > 255)
            {
                errorProvider.SetError(txtName, "Tên không được vượt quá 255 ký tự");
                isValid = false;
            }

            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            // Validate StartDate
            if (startDate >= endDate)
            {
                errorProvider.SetError(dtpStartDate, "Ngày khai giảng phải trước ngày tổng kết");
                isValid = false;
            }

            // Validate EndDate
            if (endDate <= startDate)
            {
                errorProvider.SetError(dtpEndDate, "Ngày tổng kết phải sau ngày khai giảng");
                isValid = false;
            }

            return isValid;
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Tên niên khóa là bắt buộc");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }

        private void DtpStartDate_Validating(object sender, CancelEventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            if (startDate >= endDate)
            {
                errorProvider.SetError(dtpStartDate, "Ngày khai giảng phải trước ngày tổng kết");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpStartDate, "");
            }
        }

        private void DtpEndDate_Validating(object sender, CancelEventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            if (endDate <= startDate)
            {
                errorProvider.SetError(dtpEndDate, "Ngày tổng kết phải sau ngày khai giảng");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(dtpEndDate, "");
            }
        }
    }
}
