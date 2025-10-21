using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class RollCallForm : BaseCrudForm
    {
        private readonly IRepository<RollCall> _rollCallRepository;
        private readonly IValidationService _validationService;
        private RollCall _rollCall;
        private DateTimePicker dtpDate;
        private TextBox txtRollCaller;
        private NumericUpDown nudTotalStudents;
        private NumericUpDown nudPresent;
        private NumericUpDown nudAbsent;
        private TextBox txtNotes;

        public RollCallForm(
            IRepository<RollCall> rollCallRepository,
            IValidationService validationService,
            RollCall? rollCall = null)
        {
            _rollCallRepository = rollCallRepository;
            _validationService = validationService;
            _rollCall = rollCall ?? new RollCall() { Date = DateTime.Now };
            InitializeComponent();
            InitializeRollCallForm();
            LoadRollCallData();
        }

        private void InitializeRollCallForm()
        {
            if (_rollCall.Id == 0)
            {
                this.Text = "Thêm mới Điểm danh";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Điểm danh";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;

            // Date
            formPanel.Controls.Add(new Label { Text = "Ngày:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpDate = new DateTimePicker { Location = new Point(x2, y), Size = new Size(textBoxWidth, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            formPanel.Controls.Add(dtpDate);
            y += 40;

            // RollCaller
            formPanel.Controls.Add(new Label { Text = "Người điểm danh:", Location = new Point(x1, y), Width = labelWidth });
            txtRollCaller = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtRollCaller);
            y += 40;

            // Total Students
            formPanel.Controls.Add(new Label { Text = "Tổng học viên:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudTotalStudents = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudTotalStudents);
            y += 40;

            // Present
            formPanel.Controls.Add(new Label { Text = "Có mặt:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudPresent = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudPresent);
            y += 40;

            // Absent
            formPanel.Controls.Add(new Label { Text = "Vắng mặt:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudAbsent = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudAbsent);
            y += 40;

            // Notes
            formPanel.Controls.Add(new Label { Text = "Ghi chú:", Location = new Point(x1, y), Width = labelWidth });
            txtNotes = new TextBox { Location = new Point(x2, y), Width = textBoxWidth, Multiline = true, Height = 60 };
            formPanel.Controls.Add(txtNotes);
            //y += 80;
        }

        private async void LoadRollCallData()
        {
            if (_rollCall.Id > 0)
            {
                dtpDate.Value = _rollCall.Date;
                txtRollCaller.Text = _rollCall.RollCaller;
                nudTotalStudents.Value = _rollCall.TotalStudents;
                nudPresent.Value = _rollCall.Present;
                nudAbsent.Value = _rollCall.Absent;
                txtNotes.Text = _rollCall.Notes;
            }
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _rollCall.Date = dtpDate.Value;
                    _rollCall.RollCaller = txtRollCaller.Text;
                    _rollCall.TotalStudents = (int)nudTotalStudents.Value;
                    _rollCall.Present = (int)nudPresent.Value;
                    _rollCall.Absent = (int)nudAbsent.Value;
                    _rollCall.Notes = txtNotes.Text;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_rollCall);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_rollCall.Id == 0)
                    {
                        _rollCall.CreatedDate = DateTime.Now;
                        await _rollCallRepository.AddAsync(_rollCall);
                    }
                    else
                    {
                        _rollCall.ModifiedDate = DateTime.Now;
                        await _rollCallRepository.UpdateAsync(_rollCall);
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
            if (_rollCall.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa điểm danh này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _rollCallRepository.DeleteAsync(_rollCall);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            // Validate TotalStudents
            if (nudTotalStudents.Value == 0)
            {
                errorProvider.SetError(nudTotalStudents, "Số lượng học viên điểm danh phải lớn hơn 0");
                isValid = false;
            }

            return isValid;
        }
    }
}
