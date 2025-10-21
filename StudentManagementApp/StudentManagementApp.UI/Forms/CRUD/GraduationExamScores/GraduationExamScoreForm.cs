using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Categories;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class GraduationExamScoreForm : BaseCrudForm
    {
        private readonly IGraduationExamScoreRepository _graduationExamScoreRepository;
        private readonly IGraduationScoreRepository _graduationScoreRepository;
        private readonly ITraineeRepository _traineeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private GraduationExamScore _graduationExamScore;
        private ComboBox cmbTraineeId;
        private ComboBox cmbGraduationExamType;
        private NumericUpDown nudScore;

        public GraduationExamScoreForm(
            IGraduationExamScoreRepository graduationExamScoreRepository,
            IGraduationScoreRepository graduationScoreRepository,
            ITraineeRepository traineeRepository,
            ICategoryRepository categoryRepository,
            IValidationService validationService,
            GraduationExamScore? graduationExamScore = null)
        {
            _graduationExamScoreRepository = graduationExamScoreRepository;
            _graduationScoreRepository = graduationScoreRepository;
            _traineeRepository = traineeRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            _graduationExamScore = graduationExamScore ?? new GraduationExamScore() { TraineeId = 0, GraduationExamType = "", Score = 0 };
            InitializeComponent();
            InitializeGraduationExamScoreForm();
            LoadGraduationExamScoresData();
        }

        private void InitializeGraduationExamScoreForm()
        {
            if (_graduationExamScore.Id == 0)
            {
                this.Text = "Thêm mới Điểm thi tốt nghiệp";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Điểm thi tốt nghiệp";
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

            // GraduationExamType
            formPanel.Controls.Add(new Label { Text = "Môn thi:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbGraduationExamType = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbGraduationExamType);
            y += 40;

            // Grade
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth, DecimalPlaces = 2, Minimum = 0, Maximum = 10 };
            formPanel.Controls.Add(nudScore);
            y += 40;
        }

        private async void LoadGraduationExamScoresData()
        {
            var graduationExamTypes = await LoadGraduationExamTypes();

            if (_graduationExamScore.Id > 0)
            {
                if (_graduationExamScore.TraineeId > 0)
                {
                    cmbTraineeId.SelectedValue = _graduationExamScore.TraineeId;
                }

                if (!string.IsNullOrEmpty(_graduationExamScore.GraduationExamType))
                {
                    var selectedItem = graduationExamTypes.FirstOrDefault(x => x.Code == _graduationExamScore.GraduationExamType);
                    if (selectedItem != null)
                    {
                        cmbGraduationExamType.SelectedItem = selectedItem;
                    }
                }

                nudScore.Value = _graduationExamScore.Score;
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

        private async Task<List<CategoryViewModel>> LoadGraduationExamTypes()
        {
            var datas = await _categoryRepository.GetCategoriesWithTypeAsync("GraduationExamType");
            datas = datas.Where(sy => sy.IsActive).ToList();

            cmbGraduationExamType.DataSource = datas;
            cmbGraduationExamType.DisplayMember = "Name";
            cmbGraduationExamType.ValueMember = "Code";
            return datas.ToList();
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _graduationExamScore.TraineeId = (int)cmbTraineeId.SelectedValue;

                    if (cmbGraduationExamType.SelectedItem is CategoryViewModel selectedGraduationExamType)
                    {
                        _graduationExamScore.GraduationExamType = selectedGraduationExamType.Code ?? "";
                    }

                    _graduationExamScore.Score = nudScore.Value;
                    _graduationExamScore.GradeType = CalculateGradeType(_graduationExamScore.Score);

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_graduationExamScore);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_graduationExamScore.Id == 0)
                    {
                        _graduationExamScore.CreatedDate = DateTime.Now;
                        await _graduationExamScoreRepository.AddAsync(_graduationExamScore);
                    }
                    else
                    {
                        _graduationExamScore.ModifiedDate = DateTime.Now;
                        await _graduationExamScoreRepository.UpdateAsync(_graduationExamScore);
                    }

                    await UpdateTraineeGraduationScoreAsync();

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

        private async Task UpdateTraineeGraduationScoreAsync()
        {
            // Cập nhật điểm trung bình môn cho học viên
            await _graduationScoreRepository.UpdateTraineeGraduationScoreAsync(_graduationExamScore.TraineeId);
        }

        protected override async void Delete()
        {
            if (_graduationExamScore.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa điểm thi này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _graduationExamScoreRepository.DeleteAsync(_graduationExamScore);

                await UpdateTraineeGraduationScoreAsync();

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

            // Validate GraduationExamType
            if (cmbGraduationExamType.SelectedItem == null)
            {
                errorProvider.SetError(cmbGraduationExamType, "Chọn môn thi là bắt buộc");
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
