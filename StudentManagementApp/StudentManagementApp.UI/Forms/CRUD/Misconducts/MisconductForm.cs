using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Categories;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class MisconductForm : BaseCrudForm
    {
        private readonly IMisconductRepository _misconductRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private Misconduct _misconduct;
        private ComboBox cmbTrainee;
        private ComboBox cmbType;
        private DateTimePicker dtpTime;
        private NumericUpDown nudHour;
        private NumericUpDown nudMinute;
        private TextBox txtDescription;

        public MisconductForm(
            IMisconductRepository misconductRepository,
            IRepository<Trainee> traineeRepository,
            ICategoryRepository categoryRepository,
            IValidationService validationService,
            Misconduct? misconduct = null)
        {
            _misconductRepository = misconductRepository;
            _traineeRepository = traineeRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            _misconduct = misconduct ?? new Misconduct() { TraineeId = 0, Type = "", Time = DateTime.Now };
            InitializeComponent();
            InitializeMisconductForm();
            LoadMisconductData();
        }

        private void InitializeMisconductForm()
        {
            if (_misconduct.Id == 0)
            {
                this.Text = "Thêm mới Ví phạm kỷ luật";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Vi phạm kỷ luật";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;

            // TraineeId
            formPanel.Controls.Add(new Label { Text = "Học viên:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbTrainee = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbTrainee);
            y += 40;

            // Misconduct Type
            formPanel.Controls.Add(new Label { Text = "Vi phạm kỷ luật:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbType = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbType);
            y += 40;

            // Time
            formPanel.Controls.Add(new Label { Text = "Thời gian:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpTime = new DateTimePicker { Location = new Point(x2, y), Size = new Size(textBoxWidth, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            formPanel.Controls.Add(dtpTime);
            y += 40;

            // Hour
            formPanel.Controls.Add(new Label { Text = "Giờ (nếu có):", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudHour = new NumericUpDown { Location = new Point(x2, y), Size = new Size(textBoxWidth, 20), Minimum = 0, Maximum = 23 };
            formPanel.Controls.Add(nudHour);
            y += 40;

            // Minute
            formPanel.Controls.Add(new Label { Text = "Phút (nếu có):", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudMinute = new NumericUpDown { Location = new Point(x2, y), Size = new Size(textBoxWidth, 20), Minimum = 0, Maximum = 59 };
            formPanel.Controls.Add(nudMinute);
            y += 40;

            formPanel.Controls.Add(new Label { Text = "Mô tả chi tiết:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtDescription = new TextBox { Location = new Point(x2, y), Width = textBoxWidth, Multiline = true, Height = 60 };
            formPanel.Controls.Add(txtDescription);
            y += 80;
        }

        private void LoadMisconductData()
        {
            LoadTrainees();
            LoadSchedulePeriod();

            if (_misconduct.Id > 0)
            {
                if (_misconduct.TraineeId > 0)
                {
                    cmbTrainee.SelectedValue = _misconduct.TraineeId;
                }

                if (!string.IsNullOrEmpty(_misconduct.Type))
                {
                    cmbType.SelectedValue = _misconduct.Type;
                }

                dtpTime.Value = _misconduct.Time.Date;
                nudHour.Value = _misconduct.Time.Hour;
                nudMinute.Value = _misconduct.Time.Minute;
                txtDescription.Text = _misconduct.Description ?? "";
            }
        }

        private async void LoadTrainees()
        {
            var trainees = await _traineeRepository.GetAllAsync();
            trainees = trainees.Where(sy => sy.IsActive).ToList();

            cmbTrainee.DataSource = trainees;
            cmbTrainee.DisplayMember = "FullName";
            cmbTrainee.ValueMember = "Id";
        }

        private async void LoadSchedulePeriod()
        {
            var misconductType = await _categoryRepository.GetCategoriesWithTypeAsync("MisconductType");
            misconductType = misconductType.Where(sy => sy.IsActive).ToList();

            cmbType.DataSource = misconductType;
            cmbType.DisplayMember = "Name";
            cmbType.ValueMember = "Code";
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    if (cmbTrainee.SelectedItem is Trainee selectedTrainee)
                    {
                        _misconduct.TraineeId = selectedTrainee.Id;
                    }

                    if (cmbType.SelectedItem is CategoryViewModel selectedMisconductType)
                    {
                        _misconduct.Type = selectedMisconductType.Code;
                    }

                    _misconduct.Time = dtpTime.Value;

                    if (nudHour.Value > 0)
                    {
                        _misconduct.Time = _misconduct.Time.AddHours((double)nudHour.Value);
                    }

                    if (nudMinute.Value > 0)
                    {
                        _misconduct.Time = _misconduct.Time.AddMinutes((double)nudMinute.Value);
                    }

                    _misconduct.Description = txtDescription.Text ?? "";

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_misconduct);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_misconduct.Id == 0)
                    {
                        _misconduct.CreatedDate = DateTime.Now;
                        await _misconductRepository.AddAsync(_misconduct);
                    }
                    else
                    {
                        _misconduct.ModifiedDate = DateTime.Now;
                        await _misconductRepository.UpdateAsync(_misconduct);
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
            if (_misconduct.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa vi phạm kỷ luật này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _misconductRepository.DeleteAsync(_misconduct);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            return isValid;
        }
    }
}
