using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SemesterForm : BaseCrudForm
    {
        private readonly ISemesterRepository _semesterRepository;
        private readonly IRepository<SchoolYear> _schoolYearRepository;
        private readonly IValidationService _validationService;
        private Semester _semester;
        private TextBox txtName;
        private ComboBox cmbSchoolYearId;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;

        public SemesterForm(
            ISemesterRepository semesterRepository,
            IRepository<SchoolYear> schoolYearRepository,
            IValidationService validationService,
            Semester? semester = null)
        {
            _semesterRepository = semesterRepository;
            _schoolYearRepository = schoolYearRepository;
            _validationService = validationService;
            _semester = semester ?? new Semester() { Name = string.Empty, SchoolYearId = 0, StartDate = DateTime.Now, EndDate = DateTime.Now };
            InitializeComponent();
            InitializeSemesterForm();
            LoadSemesterData();
        }

        private void InitializeSemesterForm()
        {
            if (_semester.Id == 0)
            {
                this.Text = "Thêm mới Học kỳ";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Học kỳ";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;
            int controlWidth = 250;

            // SchoolYearId
            formPanel.Controls.Add(new Label { Text = "Niên khóa:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbSchoolYearId = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            LoadSchoolYear();
            formPanel.Controls.Add(cmbSchoolYearId);
            y += 40;

            // Name
            formPanel.Controls.Add(new Label { Text = "Học kỳ:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtName = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtName);
            y += 40;

            // StartDate
            formPanel.Controls.Add(new Label { Text = "Bắt đầu:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpStartDate = new DateTimePicker { Location = new Point(170, y), Size = new Size(controlWidth, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            formPanel.Controls.Add(dtpStartDate);
            y += 40;

            // StartDate
            formPanel.Controls.Add(new Label { Text = "Kết thúc:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpEndDate = new DateTimePicker { Location = new Point(170, y), Size = new Size(controlWidth, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            formPanel.Controls.Add(dtpEndDate);
            y += 40;

            // Thêm sự kiện validating
            txtName.Validating += TxtName_Validating;
        }

        private void LoadSemesterData()
        {
            if (_semester.Id > 0)
            {
                if (_semester.SchoolYearId > 0)
                {
                    cmbSchoolYearId.SelectedValue = _semester.SchoolYearId;
                }

                txtName.Text = _semester.Name;
                dtpStartDate.Value = _semester.StartDate;
                dtpEndDate.Value = _semester.EndDate;
            }
        }

        private async void LoadSchoolYear()
        {
            var schoolYears = await _schoolYearRepository.GetAllAsync();
            schoolYears = schoolYears.Where(sy => sy.IsActive).ToList();

            // Load SchoolYears into ComboBox
            cmbSchoolYearId.DataSource = schoolYears;
            cmbSchoolYearId.DisplayMember = "Name";
            cmbSchoolYearId.ValueMember = "Id";
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _semester.SchoolYearId = (int)cmbSchoolYearId.SelectedValue;
                    _semester.Name = txtName.Text;
                    _semester.StartDate = dtpStartDate.Value;
                    _semester.EndDate = dtpEndDate.Value;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_semester);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_semester.Id == 0)
                    {
                        _semester.CreatedDate = DateTime.Now;
                        await _semesterRepository.AddAsync(_semester);
                    }
                    else
                    {
                        _semester.ModifiedDate = DateTime.Now;
                        await _semesterRepository.UpdateAsync(_semester);
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
            if (_semester.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa học kỳ này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _semesterRepository.DeleteAsync(_semester);
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
                errorProvider.SetError(txtName, "Học kỳ là bắt buộc");
                isValid = false;
            }
            else if (txtName.Text.Length > 255)
            {
                errorProvider.SetError(txtName, "Học kỳ không được vượt quá 255 ký tự");
                isValid = false;
            }

            return isValid;
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Học kỳ là bắt buộc");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }
    }
}
