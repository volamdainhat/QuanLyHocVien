using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Categories;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class WeeklyCritiqueForm : BaseCrudForm
    {
        private readonly IWeeklyCritiqueRepository _weeklyCritiqueRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRepository<Trainee> _traineeRepository;
        private readonly IValidationService _validationService;
        private WeeklyCritique _weeklyCritique;
        private ComboBox cmbTraineeId;
        private ComboBox cmbPoliticalAttitude;
        private NumericUpDown nudPAScore;
        private Label lbPAScore;
        private ComboBox cmbStudyMotivation;
        private NumericUpDown nudSMScore;
        private Label lbSMScore;
        private ComboBox cmbEthicsLifestyle;
        private NumericUpDown nudELScore;
        private Label lbELScore;
        private ComboBox cmbDisciplineAwareness;
        private NumericUpDown nudDAScore;
        private Label lbDAScore;
        private ComboBox cmbAcademicResult;
        private NumericUpDown nudARScore;
        private Label lbARScore;
        private ComboBox cmbResearchActivity;
        private NumericUpDown nudRAScore;
        private Label lbRAScore;

        public WeeklyCritiqueForm(
            IWeeklyCritiqueRepository weeklyCritiqueRepository,
            ICategoryRepository categoryRepository,
            IRepository<Trainee> traineeRepository,
            IValidationService validationService,
            WeeklyCritique? weeklyCritique = null)
        {
            _weeklyCritiqueRepository = weeklyCritiqueRepository;
            _categoryRepository = categoryRepository;
            _traineeRepository = traineeRepository;
            _validationService = validationService;
            _weeklyCritique = weeklyCritique ?? new WeeklyCritique() { TraineeId = 0, FinalScore = 0 };
            InitializeComponent();
            InitializeWeeklyCritiqueForm();
            LoadWeeklyCritiqueData();
        }

        private void InitializeWeeklyCritiqueForm()
        {
            if (_weeklyCritique.Id == 0)
            {
                this.Text = "Thêm mới Điểm rèn luyện";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Điểm rèn luyện";
            }

            this.Width = 900;
            this.Height = 800;

            // Positioning
            var x1 = 20;
            var x2 = 290;
            var x3 = 610;
            var y = 20;
            var labelWidth = 250;
            var textBoxWidth = 300;

            // Trainee
            formPanel.Controls.Add(new Label { Text = "Học viên:", Location = new Point(x1, y), Width = labelWidth, Height = 30, });
            cmbTraineeId = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbTraineeId);
            y += 40;

            formPanel.Controls.Add(new Label { Text = "Tiêu chí 1:", Location = new Point(x1, y), Width = labelWidth, Height = 30, Font = new Font(Label.DefaultFont, FontStyle.Bold) });
            y += 40;

            // PoliticalAttitude
            formPanel.Controls.Add(new Label { Text = "Thái độ chính trị, Tư tưởng:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbPoliticalAttitude = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbPoliticalAttitude);
            y += 40;

            // PAScore
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudPAScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudPAScore);
            lbPAScore = new Label { Text = "( 9 - 10 )", Location = new Point(x3, y), Width = labelWidth, Height = 30 };
            formPanel.Controls.Add(lbPAScore);
            y += 40;

            // StudyMotivation
            formPanel.Controls.Add(new Label { Text = "Động cơ, thái độ học tập:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbStudyMotivation = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbStudyMotivation);
            y += 40;

            // SMScore
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudSMScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudSMScore);
            lbSMScore = new Label { Text = "( 8 - 10 )", Location = new Point(x3, y), Width = labelWidth, Height = 30 };
            formPanel.Controls.Add(lbSMScore);
            y += 40;

            formPanel.Controls.Add(new Label { Text = "Tiêu chí 2:", Location = new Point(x1, y), Width = labelWidth, Height = 30, Font = new Font(Label.DefaultFont, FontStyle.Bold) });
            y += 40;

            // EthicsLifestyle
            formPanel.Controls.Add(new Label { Text = "Phẩm chất đạo đức, lối sống:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbEthicsLifestyle = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbEthicsLifestyle);
            y += 40;

            // ELScore
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudELScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudELScore);
            lbELScore = new Label { Text = "( 8 - 10 )", Location = new Point(x3, y), Width = labelWidth, Height = 30 };
            formPanel.Controls.Add(lbELScore);
            y += 40;

            // DisciplineAwareness
            formPanel.Controls.Add(new Label { Text = "Ý thức chấp hành KL, PL:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbDisciplineAwareness = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbDisciplineAwareness);
            y += 40;

            // DAScore
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudDAScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudDAScore);
            lbDAScore = new Label { Text = "( 8 - 10 )", Location = new Point(x3, y), Width = labelWidth, Height = 30 };
            formPanel.Controls.Add(lbDAScore);
            y += 40;

            formPanel.Controls.Add(new Label { Text = "Tiêu chí 3:", Location = new Point(x1, y), Width = labelWidth, Height = 30, Font = new Font(Label.DefaultFont, FontStyle.Bold) });
            y += 40;

            // AcademicResult
            formPanel.Controls.Add(new Label { Text = "Kết quả học tập:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbAcademicResult = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbAcademicResult);
            y += 40;

            // ARScore
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudARScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudARScore);
            lbARScore = new Label { Text = "( 8 - 10 )", Location = new Point(x3, y), Width = labelWidth, Height = 30 };
            formPanel.Controls.Add(lbARScore);
            y += 40;

            // ResearchActivity
            formPanel.Controls.Add(new Label { Text = "Nghiên cứu khoa học:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbResearchActivity = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(cmbResearchActivity);
            y += 40;

            // RAScore
            formPanel.Controls.Add(new Label { Text = "Điểm số:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            nudRAScore = new NumericUpDown { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(nudRAScore);
            lbRAScore = new Label { Text = "( 9 - 10 )", Location = new Point(x3, y), Width = labelWidth, Height = 30 };
            formPanel.Controls.Add(lbRAScore);
            y += 40;

            cmbPoliticalAttitude.SelectedIndexChanged += (s, e) =>
            {
                if (cmbPoliticalAttitude.SelectedItem is CategoryViewModel selectedPoliticalAttitude)
                {
                    string[] ranges = selectedPoliticalAttitude.Description.Split('-');
                    nudPAScore.Minimum = Decimal.Parse(ranges[0]);
                    nudPAScore.Maximum = Decimal.Parse(ranges[1]);
                    nudPAScore.Value = Decimal.Parse(ranges[1]);
                    lbPAScore.Text = $"Từ : {selectedPoliticalAttitude.Description} điểm";
                }
            };

            cmbStudyMotivation.SelectedIndexChanged += (s, e) =>
            {
                if (cmbStudyMotivation.SelectedItem is CategoryViewModel selectedStudyMotivation)
                {
                    string[] ranges = selectedStudyMotivation.Description.Split('-');
                    nudSMScore.Minimum = Decimal.Parse(ranges[0]);
                    nudSMScore.Maximum = Decimal.Parse(ranges[1]);
                    nudSMScore.Value = Decimal.Parse(ranges[1]);
                    lbSMScore.Text = $"Từ : {selectedStudyMotivation.Description} điểm";
                }
            };

            cmbEthicsLifestyle.SelectedIndexChanged += (s, e) =>
            {
                if (cmbEthicsLifestyle.SelectedItem is CategoryViewModel selectedEthicsLifestyle)
                {
                    string[] ranges = selectedEthicsLifestyle.Description.Split('-');
                    nudELScore.Minimum = Decimal.Parse(ranges[0]);
                    nudELScore.Maximum = Decimal.Parse(ranges[1]);
                    nudELScore.Value = Decimal.Parse(ranges[1]);
                    lbELScore.Text = $"Từ : {selectedEthicsLifestyle.Description} điểm";
                }
            };

            cmbDisciplineAwareness.SelectedIndexChanged += (s, e) =>
            {
                if (cmbDisciplineAwareness.SelectedItem is CategoryViewModel selectedDisciplineAwareness)
                {
                    string[] ranges = selectedDisciplineAwareness.Description.Split('-');
                    nudDAScore.Minimum = Decimal.Parse(ranges[0]);
                    nudDAScore.Maximum = Decimal.Parse(ranges[1]);
                    nudDAScore.Value = Decimal.Parse(ranges[1]);
                    lbDAScore.Text = $"Từ : {selectedDisciplineAwareness.Description} điểm";
                }
            };

            cmbAcademicResult.SelectedIndexChanged += (s, e) =>
            {
                if (cmbAcademicResult.SelectedItem is CategoryViewModel selectedAcademicResult)
                {
                    string[] ranges = selectedAcademicResult.Description.Split('-');
                    nudARScore.Minimum = Decimal.Parse(ranges[0]);
                    nudARScore.Maximum = Decimal.Parse(ranges[1]);
                    nudARScore.Value = Decimal.Parse(ranges[1]);
                    lbARScore.Text = $"Từ : {selectedAcademicResult.Description} điểm";
                }
            };

            cmbResearchActivity.SelectedIndexChanged += (s, e) =>
            {
                if (cmbResearchActivity.SelectedItem is CategoryViewModel selectedResearchActivity)
                {
                    string[] ranges = selectedResearchActivity.Description.Split('-');
                    nudRAScore.Minimum = Decimal.Parse(ranges[0]);
                    nudRAScore.Maximum = Decimal.Parse(ranges[1]);
                    nudRAScore.Value = Decimal.Parse(ranges[1]);
                    lbRAScore.Text = $"Từ : {selectedResearchActivity.Description} điểm";
                }
            };
        }

        private async void LoadWeeklyCritiqueData()
        {
            LoadTrainees();
            var politicalAttitudes = await LoadPoliticalAttitudes();
            var studyMotivations = await LoadStudyMotivations();
            var ethicsLifestyles = await LoadEthicsLifestyles();
            var disciplineAwarenesses = await LoadDisciplineAwareness();
            var academicResults = await LoadAcademicResults();
            var researchActivities = await LoadResearchActivities();

            if (_weeklyCritique.Id > 0)
            {
                if (_weeklyCritique.TraineeId > 0)
                {
                    cmbTraineeId.SelectedValue = _weeklyCritique.TraineeId;
                }

                if (!string.IsNullOrEmpty(_weeklyCritique.PoliticalAttitude))
                {
                    var selectedItem = politicalAttitudes.FirstOrDefault(x => x.Name == _weeklyCritique.PoliticalAttitude);
                    if (selectedItem != null)
                    {
                        cmbPoliticalAttitude.SelectedItem = selectedItem;
                    }
                }
                nudPAScore.Value = (decimal)_weeklyCritique.PAScore;

                if (!string.IsNullOrEmpty(_weeklyCritique.StudyMotivation))
                {
                    var selectedItem = studyMotivations.FirstOrDefault(x => x.Name == _weeklyCritique.StudyMotivation);
                    if (selectedItem != null)
                    {
                        cmbStudyMotivation.SelectedItem = selectedItem;
                    }
                }
                nudSMScore.Value = (decimal)_weeklyCritique.SMScore;

                if (!string.IsNullOrEmpty(_weeklyCritique.EthicsLifestyle))
                {
                    var selectedItem = ethicsLifestyles.FirstOrDefault(x => x.Name == _weeklyCritique.EthicsLifestyle);
                    if (selectedItem != null)
                    {
                        cmbEthicsLifestyle.SelectedItem = selectedItem;
                    }
                }
                nudELScore.Value = (decimal)_weeklyCritique.ELScore;

                if (!string.IsNullOrEmpty(_weeklyCritique.DisciplineAwareness))
                {
                    var selectedItem = disciplineAwarenesses.FirstOrDefault(x => x.Name == _weeklyCritique.DisciplineAwareness);
                    if (selectedItem != null)
                    {
                        cmbDisciplineAwareness.SelectedItem = selectedItem;
                    }
                }
                nudDAScore.Value = (decimal)_weeklyCritique.DAScore;

                if (!string.IsNullOrEmpty(_weeklyCritique.AcademicResult))
                {
                    var selectedItem = academicResults.FirstOrDefault(x => x.Name == _weeklyCritique.AcademicResult);
                    if (selectedItem != null)
                    {
                        cmbAcademicResult.SelectedItem = selectedItem;
                    }
                }
                nudARScore.Value = (decimal)_weeklyCritique.ARScore;

                if (!string.IsNullOrEmpty(_weeklyCritique.ResearchActivity))
                {
                    var selectedItem = researchActivities.FirstOrDefault(x => x.Name == _weeklyCritique.ResearchActivity);
                    if (selectedItem != null)
                    {
                        cmbResearchActivity.SelectedItem = selectedItem;
                    }
                }
                nudRAScore.Value = (decimal)_weeklyCritique.RAScore;
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

        private async Task<List<CategoryViewModel>> LoadPoliticalAttitudes()
        {
            var datas = await _categoryRepository.GetCategoriesWithTypeAsync("PoliticalAttitude");
            datas = datas.Where(sy => sy.IsActive).ToList();

            cmbPoliticalAttitude.DataSource = datas;
            cmbPoliticalAttitude.DisplayMember = "Name";
            cmbPoliticalAttitude.ValueMember = "Code";
            return datas.ToList();
        }
        private async Task<List<CategoryViewModel>> LoadStudyMotivations()
        {
            var datas = await _categoryRepository.GetCategoriesWithTypeAsync("StudyMotivation");
            datas = datas.Where(sy => sy.IsActive).ToList();

            cmbStudyMotivation.DataSource = datas;
            cmbStudyMotivation.DisplayMember = "Name";
            cmbStudyMotivation.ValueMember = "Code";
            return datas.ToList();
        }

        private async Task<List<CategoryViewModel>> LoadEthicsLifestyles()
        {
            var datas = await _categoryRepository.GetCategoriesWithTypeAsync("EthicsLifestyle");
            datas = datas.Where(sy => sy.IsActive).ToList();

            cmbEthicsLifestyle.DataSource = datas;
            cmbEthicsLifestyle.DisplayMember = "Name";
            cmbEthicsLifestyle.ValueMember = "Code";
            return datas.ToList();
        }

        private async Task<List<CategoryViewModel>> LoadDisciplineAwareness()
        {
            var datas = await _categoryRepository.GetCategoriesWithTypeAsync("DisciplineAwareness");
            datas = datas.Where(sy => sy.IsActive).ToList();

            cmbDisciplineAwareness.DataSource = datas;
            cmbDisciplineAwareness.DisplayMember = "Name";
            cmbDisciplineAwareness.ValueMember = "Code";
            return datas.ToList();
        }

        private async Task<List<CategoryViewModel>> LoadAcademicResults()
        {
            var datas = await _categoryRepository.GetCategoriesWithTypeAsync("AcademicResult");
            datas = datas.Where(sy => sy.IsActive).ToList();

            cmbAcademicResult.DataSource = datas;
            cmbAcademicResult.DisplayMember = "Name";
            cmbAcademicResult.ValueMember = "Code";
            return datas.ToList();
        }

        private async Task<List<CategoryViewModel>> LoadResearchActivities()
        {
            var datas = await _categoryRepository.GetCategoriesWithTypeAsync("ResearchActivity");
            datas = datas.Where(sy => sy.IsActive).ToList();

            cmbResearchActivity.DataSource = datas;
            cmbResearchActivity.DisplayMember = "Name";
            cmbResearchActivity.ValueMember = "Code";
            return datas.ToList();
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    _weeklyCritique.TraineeId = (int)cmbTraineeId.SelectedValue;

                    if (cmbPoliticalAttitude.SelectedItem is CategoryViewModel selectedPoliticalAttitude)
                    {
                        _weeklyCritique.PoliticalAttitude = selectedPoliticalAttitude.Name;
                    }
                    _weeklyCritique.PAScore = (int)nudPAScore.Value;

                    if (cmbStudyMotivation.SelectedItem is CategoryViewModel selectedStudyMotivation)
                    {
                        _weeklyCritique.StudyMotivation = selectedStudyMotivation.Name;
                    }
                    _weeklyCritique.SMScore = (int)nudSMScore.Value;

                    if (cmbEthicsLifestyle.SelectedItem is CategoryViewModel selectedEthicsLifestyle)
                    {
                        _weeklyCritique.EthicsLifestyle = selectedEthicsLifestyle.Name;
                    }
                    _weeklyCritique.ELScore = (int)nudELScore.Value;

                    if (cmbDisciplineAwareness.SelectedItem is CategoryViewModel selectedDisciplineAwareness)
                    {
                        _weeklyCritique.DisciplineAwareness = selectedDisciplineAwareness.Name;
                    }
                    _weeklyCritique.DAScore = (int)nudDAScore.Value;

                    if (cmbAcademicResult.SelectedItem is CategoryViewModel selectedAcademicResult)
                    {
                        _weeklyCritique.AcademicResult = selectedAcademicResult.Name;
                    }
                    _weeklyCritique.ARScore = (int)nudARScore.Value;

                    if (cmbResearchActivity.SelectedItem is CategoryViewModel selectedResearchActivity)
                    {
                        _weeklyCritique.ResearchActivity = selectedResearchActivity.Name;
                    }
                    _weeklyCritique.RAScore = (int)nudRAScore.Value;

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_weeklyCritique);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_weeklyCritique.Id == 0)
                    {
                        _weeklyCritique.CreatedDate = DateTime.Now;
                        await _weeklyCritiqueRepository.AddAsync(_weeklyCritique);
                    }
                    else
                    {
                        _weeklyCritique.ModifiedDate = DateTime.Now;
                        await _weeklyCritiqueRepository.UpdateAsync(_weeklyCritique);
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
            if (_weeklyCritique.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa điểm rèn luyện này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _weeklyCritiqueRepository.DeleteAsync(_weeklyCritique);

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
    }
}
