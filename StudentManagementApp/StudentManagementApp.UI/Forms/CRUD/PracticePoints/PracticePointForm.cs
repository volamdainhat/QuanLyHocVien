using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Categories;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class PracticePointForm : BaseCrudForm
    {
        private readonly IPracticePointRepository _practicePointRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IValidationService _validationService;
        private PracticePoint _practicePoint;
        private ComboBox cmbTrainee;
        private TextBox txtContent;
        private NumericUpDown nudPoint;
        private DateTimePicker dtpTime;
        private TextBox txtDescription;

        public PracticePointForm(
            IPracticePointRepository practicePointRepository,
            IRepository<Trainee> traineeRepository,
            IValidationService validationService,
            PracticePoint? practicePoint = null)
        {
            _practicePointRepository = practicePointRepository;
            _traineeRepository = traineeRepository;
            _validationService = validationService;
            _practicePoint = practicePoint ?? new PracticePoint() { TraineeId = 0, Content = "", Point = 0, Time = DateTime.Now };
            InitializeComponent();
            InitializePracticePointForm();
            LoadPracticePointData();
        }

        private void InitializePracticePointForm()
        {
            if (_practicePoint.Id == 0)
            {
                this.Text = "Thêm mới Điểm cộng";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Điểm cộng";
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

            // PracticePoint Type
            formPanel.Controls.Add(new Label { Text = "Nội dung:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtContent = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtContent);
            y += 40;

            // Hour
            formPanel.Controls.Add(new Label { Text = "Điểm cộng:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudPoint = new NumericUpDown { Location = new Point(x2, y), Size = new Size(textBoxWidth, 20), Minimum = 0, Maximum = 23 };
            formPanel.Controls.Add(nudPoint);
            y += 40;

            // Time
            formPanel.Controls.Add(new Label { Text = "Thời gian:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpTime = new DateTimePicker { Location = new Point(x2, y), Size = new Size(textBoxWidth, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            formPanel.Controls.Add(dtpTime);
            y += 40;

            formPanel.Controls.Add(new Label { Text = "Mô tả chi tiết:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtDescription = new TextBox { Location = new Point(x2, y), Width = textBoxWidth, Multiline = true, Height = 60 };
            formPanel.Controls.Add(txtDescription);
            y += 80;
        }

        private void LoadPracticePointData()
        {
            LoadTrainees();

            if (_practicePoint.Id > 0)
            {
                if (_practicePoint.TraineeId > 0)
                {
                    cmbTrainee.SelectedValue = _practicePoint.TraineeId;
                }

                txtContent.Text = _practicePoint.Content ?? "";
                dtpTime.Value = _practicePoint.Time;
                nudPoint.Value = _practicePoint.Point;
                txtDescription.Text = _practicePoint.Description ?? "";
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

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    if (cmbTrainee.SelectedItem is Trainee selectedTrainee)
                    {
                        _practicePoint.TraineeId = selectedTrainee.Id;
                    }

                    _practicePoint.Content = txtContent.Text ?? "";
                    _practicePoint.Time = dtpTime.Value;
                    _practicePoint.Point = nudPoint.Value;
                    _practicePoint.Description = txtDescription.Text ?? "";

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_practicePoint);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_practicePoint.Id == 0)
                    {
                        _practicePoint.CreatedDate = DateTime.Now;
                        await _practicePointRepository.AddAsync(_practicePoint);
                    }
                    else
                    {
                        _practicePoint.ModifiedDate = DateTime.Now;
                        await _practicePointRepository.UpdateAsync(_practicePoint);
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
            if (_practicePoint.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa điểm cộng này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _practicePointRepository.DeleteAsync(_practicePoint);
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
