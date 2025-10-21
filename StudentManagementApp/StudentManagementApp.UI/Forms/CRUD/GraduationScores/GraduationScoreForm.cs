using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class GraduationScoreForm : BaseCrudForm
    {
        private readonly IGraduationScoreRepository _graduationScoreRepository;
        private readonly ITraineeRepository _traineeRepository;
        private readonly IValidationService _validationService;
        private GraduationScore _graduationScore;
        private ComboBox cmbTraineeId;
        private NumericUpDown nudScore;

        public GraduationScoreForm(
            IGraduationScoreRepository graduationScoreRepository,
            ITraineeRepository traineeRepository,
            IValidationService validationService,
            GraduationScore? graduationScore = null)
        {
            _graduationScoreRepository = graduationScoreRepository;
            _traineeRepository = traineeRepository;
            _validationService = validationService;
            _graduationScore = graduationScore ?? new GraduationScore() { TraineeId = 0, Score = 0 };
            InitializeComponent();
            InitializeGraduationScoreForm();
            LoadGraduationScoresData();
        }

        private void InitializeGraduationScoreForm()
        {
            if (_graduationScore.Id == 0)
            {
                this.Text = "Thêm mới Điểm xét tốt nghiệp";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Điểm xét tốt nghiệp";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;

            // Trainee
            formPanel.Controls.Add(new Label { Text = "Học viên:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbTraineeId = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            LoadTrainees();
            formPanel.Controls.Add(cmbTraineeId);
            y += 40;

            // Score
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth, DecimalPlaces = 2, Minimum = 0, Maximum = 10 };
            formPanel.Controls.Add(nudScore);
            y += 40;
        }

        private void LoadGraduationScoresData()
        {
            if (_graduationScore.Id > 0)
            {
                if (_graduationScore.TraineeId > 0)
                {
                    cmbTraineeId.SelectedValue = _graduationScore.TraineeId;
                }
                nudScore.Value = _graduationScore.Score;
            }
        }

        private async void LoadTrainees()
        {
            var trainees = await _traineeRepository.GetAllAsync();
            trainees = trainees.Where(sy => sy.IsActive).ToList();

            cmbTraineeId.DataSource = trainees;
            cmbTraineeId.DisplayMember = "FullName";
            cmbTraineeId.ValueMember = "Id";
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _graduationScore.TraineeId = (int)cmbTraineeId.SelectedValue;
                    _graduationScore.Score = nudScore.Value;
                    _graduationScore.GraduationType = CalculateGradeType(_graduationScore.Score);

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_graduationScore);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_graduationScore.Id == 0)
                    {
                        _graduationScore.CreatedDate = DateTime.Now;
                        await _graduationScoreRepository.AddAsync(_graduationScore);
                    }
                    else
                    {
                        _graduationScore.ModifiedDate = DateTime.Now;
                        await _graduationScoreRepository.UpdateAsync(_graduationScore);
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
            if (_graduationScore.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa điểm thi này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _graduationScoreRepository.DeleteAsync(_graduationScore);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            // Validate TraineeId
            if (cmbTraineeId.SelectedItem == null)
            {
                errorProvider.SetError(cmbTraineeId, "Chọn học viên là bắt buộc");
                isValid = false;
            }

            return isValid;
        }

        private static string CalculateGradeType(decimal score)
        {
            // Logic xếp loại dựa trên điểm số decimal
            if (score >= 9.0m) return "Xuất xắc";
            else if (score >= 8.0m) return "Giỏi";
            else if (score >= 7.0m) return "Khá";
            else if (score >= 5.0m) return "Trung bình";
            else return "Yếu";
        }
    }
}
