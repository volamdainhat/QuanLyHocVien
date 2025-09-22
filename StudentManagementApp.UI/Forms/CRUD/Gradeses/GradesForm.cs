using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.Categories;
using StudentManagementApp.Infrastructure.Repositories.Gradeses;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class GradesForm : BaseCrudForm
    {
        private readonly IGradesRepository _gradesRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IValidationService _validationService;
        private Grades _grades;
        private ComboBox cmbTraineeId;
        private ComboBox cmbSubjectId;
        private ComboBox cmbExamType;
        private NumericUpDown nudGrade;

        public GradesForm(
            IGradesRepository gradesRepository,
            ICategoryRepository categoryRepository,
            IRepository<Trainee> traineeRepository,
            IRepository<Subject> subjectRepository,
            IValidationService validationService,
            Grades? grades = null)
        {
            _gradesRepository = gradesRepository;
            _categoryRepository = categoryRepository;
            _traineeRepository = traineeRepository;
            _subjectRepository = subjectRepository;
            _validationService = validationService;
            _grades = grades ?? new Grades() { TraineeId = 0, SubjectId = 0, ExamType = "" };
            InitializeComponent();
            InitializeGradesForm();
            LoadGradesData();
        }

        private void InitializeGradesForm()
        {
            if (_grades.Id == 0)
            {
                this.Text = "Thêm mới Điểm thi";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Điểm thi";
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

            // Subject
            formPanel.Controls.Add(new Label { Text = "Môn học:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbSubjectId = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            LoadSubjects();
            formPanel.Controls.Add(cmbSubjectId);
            y += 40;

            // ExamType
            formPanel.Controls.Add(new Label { Text = "Loại thi:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbExamType = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            LoadExamTypes();
            formPanel.Controls.Add(cmbExamType);
            y += 40;

            // ExamType
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudGrade = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudGrade);
            y += 40;
        }

        private async void LoadGradesData()
        {
            LoadTrainees();
            LoadSubjects();
            LoadExamTypes();

            if (_grades.Id > 0)
            {
                try
                {
                    if (_grades.TraineeId > 0)
                    {
                        cmbTraineeId.SelectedValue = _grades.TraineeId;
                    }

                    if (_grades.SubjectId > 0)
                    {
                        cmbSubjectId.SelectedValue = _grades.SubjectId;
                    }

                    if (!string.IsNullOrEmpty(_grades.ExamType))
                    {
                        cmbExamType.SelectedValue = _grades.ExamType;
                    }

                    nudGrade.Value = (decimal)_grades.Grade;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải dữ liệu điểm thi: {ex.Message}");
                }
            }
        }

        private async void LoadTrainees()
        {
            var trainees = await _traineeRepository.GetAllAsync();
            trainees = trainees.Where(sy => sy.IsActive).ToList();

            // Load Trainee into ComboBox
            cmbTraineeId.DataSource = trainees;
            cmbTraineeId.DisplayMember = "FullName";
            cmbTraineeId.ValueMember = "Id";
        }

        private async void LoadSubjects()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            subjects = subjects.Where(sy => sy.IsActive).ToList();

            // Load Subject into ComboBox
            cmbSubjectId.DataSource = subjects;
            cmbSubjectId.DisplayMember = "Name";
            cmbSubjectId.ValueMember = "Id";
        }

        private async void LoadExamTypes()
        {
            var examTypes = await _categoryRepository.GetCategoriesWithTypeAsync("ExamType");
            examTypes = examTypes.Where(sy => sy.IsActive).ToList();

            cmbExamType.DataSource = examTypes;
            cmbExamType.DisplayMember = "Name";
            cmbExamType.ValueMember = "Code";
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _grades.TraineeId = (int)cmbTraineeId.SelectedValue;
                    _grades.SubjectId = (int)cmbSubjectId.SelectedValue;
                    _grades.ExamType = (string)cmbExamType.SelectedValue;
                    _grades.Grade = (int)nudGrade.Value;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_grades);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_grades.Id == 0)
                    {
                        await _gradesRepository.AddAsync(_grades);
                    }
                    else
                    {
                        await _gradesRepository.UpdateAsync(_grades);
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
            if (_grades.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa điểm thi này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _gradesRepository.DeleteAsync(_grades);
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

            // Validate SubjectId
            if (cmbSubjectId.SelectedItem == null)
            {
                errorProvider.SetError(cmbSubjectId, "Chọn môn học là bắt buộc");
                isValid = false;
            }

            // Validate ExamType
            if (cmbExamType.SelectedItem == null)
            {
                errorProvider.SetError(cmbExamType, "Chọn loại thi là bắt buộc");
                isValid = false;
            }

            return isValid;
        }
    }
}
