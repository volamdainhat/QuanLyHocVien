using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ClassForm : BaseCrudForm
    {
        private readonly IClassRepository _classRepository;
        private readonly IRepository<SchoolYear> _schoolYearRepository;
        private readonly IValidationService _validationService;
        private Class _class;
        private TextBox txtName;
        private ComboBox cbSchoolYearId;
        private NumericUpDown nudTotalStudents;

        public ClassForm(
            IClassRepository classRepository,
            IRepository<SchoolYear> schoolYearRepository,
            IValidationService validationService,
            Class? Class = null)
        {
            _classRepository = classRepository;
            _schoolYearRepository = schoolYearRepository;
            _validationService = validationService;
            _class = Class ?? new Class() { Name = string.Empty, SchoolYearId = 0 };
            InitializeComponent();
            InitializeClassForm();
            LoadClassData();
        }

        private void InitializeClassForm()
        {
            if (_class.Id == 0)
            {
                this.Text = "Thêm mới Lớp học";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Lớp học";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;

            // Name
            formPanel.Controls.Add(new Label { Text = "Tên lớp:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtName = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtName);
            y += 40;

            // StartDate
            formPanel.Controls.Add(new Label { Text = "Niên khóa:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cbSchoolYearId = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cbSchoolYearId);
            y += 40;

            // EndDate
            formPanel.Controls.Add(new Label { Text = "Tổng học viên:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudTotalStudents = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudTotalStudents);
            y += 40;

            // Thêm sự kiện validating
            txtName.Validating += TxtName_Validating;
        }

        private async void LoadClassData()
        {
            IEnumerable<SchoolYear> schoolYears = await LoadSchoolYear();

            if (_class.Id > 0)
            {
                txtName.Text = _class.Name;

                // Set selected value
                if (schoolYears.Any(s => s.Id == _class.SchoolYearId))
                {
                    cbSchoolYearId.SelectedValue = _class.SchoolYearId;
                }

                nudTotalStudents.Value = _class.TotalStudents;
            }
        }

        private async Task<IEnumerable<SchoolYear>> LoadSchoolYear()
        {
            var schoolYears = await _schoolYearRepository.GetAllAsync();
            schoolYears = schoolYears.Where(sy => sy.IsActive).ToList();

            // Load SchoolYears into ComboBox
            cbSchoolYearId.DataSource = schoolYears;
            cbSchoolYearId.DisplayMember = "Name";
            cbSchoolYearId.ValueMember = "Id";
            return schoolYears;
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _class.Name = txtName.Text;
                    _class.SchoolYearId = (int)cbSchoolYearId.SelectedValue;
                    _class.TotalStudents = (int)nudTotalStudents.Value;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_class);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_class.Id == 0)
                    {
                        _class.CreatedDate = DateTime.Now;
                        await _classRepository.AddAsync(_class);
                    }
                    else
                    {
                        _class.ModifiedDate = DateTime.Now;
                        await _classRepository.UpdateAsync(_class);
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
            if (_class.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa lớp này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _classRepository.DeleteAsync(_class);
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
                errorProvider.SetError(txtName, "Tên lớp là bắt buộc");
                isValid = false;
            }
            else if (txtName.Text.Length > 255)
            {
                errorProvider.SetError(txtName, "Tên không được vượt quá 255 ký tự");
                isValid = false;
            }

            return isValid;
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Tên lớp là bắt buộc");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }
    }
}
