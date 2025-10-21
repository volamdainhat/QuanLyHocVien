using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Models.Categories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.UI.Forms.CRUD
{
    public partial class ScheduleForm : BaseCrudForm
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IRepository<Subject> _subjectRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidationService _validationService;
        private Schedule _schedule;
        private ComboBox cmbClasses;
        private ComboBox cmbSubjects;
        private TextBox txtRoom;
        private DateTimePicker dtpDate;
        private ComboBox cmbPeriod;

        public ScheduleForm(
            IScheduleRepository scheduleRepository,
            IRepository<Class> classRepository,
            IRepository<Subject> subjectRepository,
            ICategoryRepository categoryRepository,
            IValidationService validationService,
            Schedule? schedule = null)
        {
            _scheduleRepository = scheduleRepository;
            _classRepository = classRepository;
            _subjectRepository = subjectRepository;
            _categoryRepository = categoryRepository;
            _validationService = validationService;
            _schedule = schedule ?? new Schedule() { ClassId = 0, SubjectId = 0, Room = "", Period = "", Date = DateTime.Now };
            InitializeComponent();
            InitializeScheduleForm();
            LoadScheduleData();
        }

        private void InitializeScheduleForm()
        {
            if (_schedule.Id == 0)
            {
                this.Text = "Thêm mới Lịch học";
                btnDelete.Visible = false;
            }
            else
            {
                this.Text = "Chỉnh sửa Lịch học";
            }

            // Positioning
            var x1 = 20;
            var x2 = 170;
            var y = 20;
            var labelWidth = 150;
            var textBoxWidth = 300;

            // ClassId
            formPanel.Controls.Add(new Label { Text = "Lớp học:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbClasses = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            LoadClasses();
            formPanel.Controls.Add(cmbClasses);
            y += 40;

            // SubjectId
            formPanel.Controls.Add(new Label { Text = "Môn học:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbSubjects = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            LoadSubjects();
            formPanel.Controls.Add(cmbSubjects);
            y += 40;

            // Name
            formPanel.Controls.Add(new Label { Text = "Phòng lớp:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            txtRoom = new TextBox { Location = new Point(x2, y), Width = textBoxWidth };
            formPanel.Controls.Add(txtRoom);
            y += 40;

            // Date
            formPanel.Controls.Add(new Label { Text = "Ngày học:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            dtpDate = new DateTimePicker { Location = new Point(170, y), Size = new Size(textBoxWidth, 20), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            formPanel.Controls.Add(dtpDate);
            y += 40;

            // Period
            formPanel.Controls.Add(new Label { Text = "Buổi học:", Location = new Point(x1, y), Width = labelWidth, Height = 30 });
            cmbPeriod = new ComboBox { Location = new Point(x2, y), Width = textBoxWidth };
            LoadSchedulePeriod();
            formPanel.Controls.Add(cmbPeriod);
            y += 40;

            // Thêm sự kiện validating
            txtRoom.Validating += TxtRoom_Validating;
        }

        private async void LoadClasses()
        {
            var classes = await _classRepository.GetAllAsync();
            classes = classes.Where(sy => sy.IsActive).ToList();

            cmbClasses.DataSource = classes;
            cmbClasses.DisplayMember = "Name";
            cmbClasses.ValueMember = "Id";
        }

        private async void LoadSubjects()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            subjects = subjects.Where(sy => sy.IsActive).ToList();

            cmbSubjects.DataSource = subjects;
            cmbSubjects.DisplayMember = "Name";
            cmbSubjects.ValueMember = "Id";
        }

        private async void LoadSchedulePeriod()
        {
            var schedulePeriod = await _categoryRepository.GetCategoriesWithTypeAsync("SchedulePeriod");
            schedulePeriod = schedulePeriod.Where(sy => sy.IsActive).ToList();

            cmbPeriod.DataSource = schedulePeriod;
            cmbPeriod.DisplayMember = "Name";
            cmbPeriod.ValueMember = "Code";
        }

        private void LoadScheduleData()
        {
            LoadClasses();
            LoadSubjects();
            LoadSchedulePeriod();

            if (_schedule.Id > 0)
            {
                if (_schedule.ClassId > 0)
                {
                    cmbClasses.SelectedValue = _schedule.ClassId;
                }

                if (_schedule.SubjectId > 0)
                {
                    cmbSubjects.SelectedValue = _schedule.SubjectId;
                }

                txtRoom.Text = _schedule.Room;
                dtpDate.Value = _schedule.Date;

                if (!string.IsNullOrEmpty(_schedule.Period))
                {
                    cmbPeriod.SelectedValue = _schedule.Period;
                }
            }
        }

        protected override async void Save()
        {
            if (ValidateForm())
            {
                try
                {
                    if (cmbClasses.SelectedItem is Class selectedClass)
                    {
                        _schedule.ClassId = selectedClass.Id;
                    }

                    if (cmbSubjects.SelectedItem is Subject selectedSubject)
                    {
                        _schedule.SubjectId = selectedSubject.Id;
                    }

                    _schedule.Room = txtRoom.Text;
                    _schedule.Date = dtpDate.Value;

                    if (cmbPeriod.SelectedItem is CategoryViewModel selectedPeriod)
                    {
                        _schedule.Period = selectedPeriod.Code;
                    }

                    // Validate entity
                    var validationResults = _validationService.ValidateWithDetails(_schedule);
                    var validationResultsList = validationResults.ToList();
                    if (validationResultsList.Count != 0)
                    {
                        string errorMessage = string.Join("\n", validationResultsList.Select(r => r.ErrorMessage));
                        MessageBox.Show(errorMessage, "Lỗi kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu có lỗi
                    }

                    if (_schedule.Id == 0)
                    {
                        _schedule.CreatedDate = DateTime.Now;
                        await _scheduleRepository.AddAsync(_schedule);
                    }
                    else
                    {
                        _schedule.ModifiedDate = DateTime.Now;
                        await _scheduleRepository.UpdateAsync(_schedule);
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
            if (_schedule.Id > 0 &&
                MessageBox.Show("Bạn có chắc chắn muốn xóa lịch học này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                await _scheduleRepository.DeleteAsync(_schedule);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            errorProvider.Clear();

            bool isValid = true;

            // Validate Name
            if (string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                errorProvider.SetError(txtRoom, "Phòng học là bắt buộc");
                isValid = false;
            }

            return isValid;
        }

        private void TxtRoom_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoom.Text))
            {
                errorProvider.SetError(txtRoom, "Tên lớp là bắt buộc");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtRoom, "");
            }
        }
    }
}
