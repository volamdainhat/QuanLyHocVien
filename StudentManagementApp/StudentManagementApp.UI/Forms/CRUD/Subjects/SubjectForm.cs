using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories.Subjects;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class SubjectForm : BaseCrudForm
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IValidationService _validationService;
        private Subject _subject;
        private TextBox txtName;
        private TextBox txtCode;
        private NumericUpDown nudCoefficient;

        public SubjectForm(
            ISubjectRepository subjectRepository,
            IValidationService validationService,
            Subject? subject = null)
        {
            _subjectRepository = subjectRepository;
            _validationService = validationService;
            _subject = subject ?? new Subject() { Code = string.Empty, Name = string.Empty, Coefficient = 0 };
            InitializeComponent();
            InitializeSubjectForm();
            LoadSubjectData();
        }

        private void InitializeSubjectForm()
        {
            if (_subject.Id == 0)
            {
                this.Text = "Thêm mới Môn học";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Môn học";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;

            // Name
            formPanel.Controls.Add(new Label { Text = "Tên môn:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtName = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtName);
            y += 40;

            // Code
            formPanel.Controls.Add(new Label { Text = "Mã môn:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtCode = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            txtCode.ReadOnly = _subject.Id != 0;
            formPanel.Controls.Add(txtCode);
            y += 40;

            // Coefficient
            formPanel.Controls.Add(new Label { Text = "Hệ số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudCoefficient = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth, Minimum = 1, Maximum = 5 };
            formPanel.Controls.Add(nudCoefficient);
            y += 40;

            // Thêm sự kiện validating
            txtName.Validating += TxtName_Validating;
            txtCode.Validating += TxtCode_Validating;
        }

        private async void LoadSubjectData()
        {
            if (_subject.Id > 0)
            {
                txtName.Text = _subject.Name;
                txtCode.Text = _subject.Code;
                nudCoefficient.Value = _subject.Coefficient;
            }
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _subject.Name = txtName.Text;
                    _subject.Code = txtCode.Text;
                    _subject.Coefficient = (int)nudCoefficient.Value;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_subject);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_subject.Id == 0)
                    {
                        if (await _subjectRepository.CheckCodeExistsAsync(_subject.Code))
                        {
                            MessageBox.Show("Mã môn học đã tồn tại. Vui lòng kiểm tra lại thông tin mã môn học.",
                                "Lỗi nhập liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return;
                        }

                        _subject.CreatedDate = DateTime.Now;
                        await _subjectRepository.AddAsync(_subject);
                    }
                    else
                    {
                        _subject.ModifiedDate = DateTime.Now;
                        await _subjectRepository.UpdateAsync(_subject);
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
            if (_subject.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _subjectRepository.DeleteAsync(_subject);
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
                errorProvider.SetError(txtName, "Tên môn học là bắt buộc");
                isValid = false;
            }
            else if (txtName.Text.Length > 255)
            {
                errorProvider.SetError(txtName, "Tên không được vượt quá 255 ký tự");
                isValid = false;
            }

            // Validate Name
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                errorProvider.SetError(txtName, "Mã môn học là bắt buộc");
                isValid = false;
            }
            else if (txtName.Text.Length > 20)
            {
                errorProvider.SetError(txtCode, "Mã không được vượt quá 20 ký tự");
                isValid = false;
            }

            return isValid;
        }

        private void TxtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "Tên môn học là bắt buộc");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, "");
            }
        }

        private void TxtCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                errorProvider.SetError(txtCode, "Mã môn học là bắt buộc");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtCode, "");
            }
        }
    }
}
