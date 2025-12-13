using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Helpers;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Categories;
using System.Data;

namespace StudentManagementApp.UI.Forms.CRUD.Gradeses
{
    public partial class BulkAddGraduationExamScoreForm : Form
    {
        private readonly IRepository<Class> _classRepository;
        private readonly IRepository<GraduationExamScore> _graduationExamScoreRepository;
        private readonly IGraduationScoreRepository _graduationScoreRepository;
        private readonly ITraineeRepository _traineeRepository;
        private readonly ICategoryRepository _categoryRepository;

        private List<Trainee> _trainees;
        private List<CategoryViewModel> _selectedSubjects;
        private DataTable _gradesData;

        private ComboBox cboClass;
        private CheckedListBox clbSubjects;
        private DataGridView dgvGrades;
        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        private Label label2;

        public BulkAddGraduationExamScoreForm(IRepository<Class> classRepository,
            IRepository<GraduationExamScore> graduationExamScoreRepository,
            IGraduationScoreRepository graduationScoreRepository,
            ITraineeRepository traineeRepository,
            ICategoryRepository categoryRepository)
        {
            _classRepository = classRepository;
            _graduationExamScoreRepository = graduationExamScoreRepository;
            _graduationScoreRepository = graduationScoreRepository;
            _traineeRepository = traineeRepository;
            _categoryRepository = categoryRepository;

            InitializeComponent();
            _selectedSubjects = new List<CategoryViewModel>();
            InitControls();
            InitializeForm();

            this.Shown += BulkAddGraduationExamScoreForm_Shown;
        }

        private void BulkAddGraduationExamScoreForm_Shown(object sender, EventArgs e)
        {
            // Tự động load dữ liệu khi form đã hiển thị xong
            if (cboClass.Items.Count > 0)
            {
                cboClass_SelectedIndexChanged(cboClass, EventArgs.Empty);
            }
        }

        private void InitControls()
        {
            this.cboClass = new ComboBox();
            this.clbSubjects = new CheckedListBox();
            this.dgvGrades = new DataGridView();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.label1 = new Label();
            this.label2 = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            this.SuspendLayout();

            // cboClass
            this.cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new Point(120, 20);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new Size(200, 21);
            this.cboClass.SelectedIndexChanged += new EventHandler(this.cboClass_SelectedIndexChanged);

            // clbSubjects
            this.clbSubjects.CheckOnClick = true;
            this.clbSubjects.FormattingEnabled = true;
            this.clbSubjects.Location = new Point(120, 60);
            this.clbSubjects.Name = "clbSubjects";
            this.clbSubjects.Size = new Size(200, 154);
            this.clbSubjects.ItemCheck += new ItemCheckEventHandler(this.clbSubjects_ItemCheck);

            // dgvGrades
            this.dgvGrades.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvGrades.Location = new Point(350, 60);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.Size = new Size(600, 400);
            this.dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.AllowUserToAddRows = false;

            // btnSave
            this.btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnSave.Location = new Point(770, 480);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(85, 30);
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.btnCancel.Location = new Point(865, 480);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(85, 30);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Labels
            this.label1.Text = "Lớp:";
            this.label1.Location = new Point(20, 23);
            this.label1.Size = new Size(80, 30);

            this.label2.Text = "Môn học:";
            this.label2.Location = new Point(20, 60);
            this.label2.Size = new Size(100, 30);

            // Form
            this.ClientSize = new Size(984, 531);
            this.Controls.AddRange(new Control[] {
                this.cboClass, this.clbSubjects, this.dgvGrades,
                this.btnSave, this.btnCancel, this.label1, this.label2
            });
            this.Text = "Thêm điểm hàng loạt";
            this.StartPosition = FormStartPosition.CenterParent;

            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            this.ResumeLayout(false);
        }

        private async Task InitializeForm()
        {
            // ComboBox cho lớp
            await LoadClasses();

            // CheckedListBox cho môn thi
            await LoadSubjects();

            InitializeDataGridView();
        }

        private async Task LoadClasses()
        {
            var classes = await _classRepository.GetAllAsync();
            cboClass.DataSource = classes;
            cboClass.DisplayMember = "Name";
            cboClass.ValueMember = "Id";
        }

        private async Task LoadSubjects()
        {
            var examTypes = await _categoryRepository.GetCategoriesWithTypeAsync("GraduationExamType");
            List<CategoryViewModel> listExamTypes = examTypes.Where(sy => sy.IsActive).ToList();

            clbSubjects.DataSource = listExamTypes;
            clbSubjects.DisplayMember = "Name";
            clbSubjects.ValueMember = "Code";
        }

        private void InitializeDataGridView()
        {
            _gradesData = new DataTable();
            _gradesData.Columns.Add("TraineeId", typeof(int));
            _gradesData.Columns.Add("Học viên", typeof(string));

            dgvGrades.DataSource = _gradesData;
            dgvGrades.AutoGenerateColumns = true;

            // Ẩn cột TraineeId
            dgvGrades.Columns["TraineeId"].Visible = false;

            // THÊM CÁC THIẾT LẬP MỚI
            dgvGrades.ScrollBars = ScrollBars.Both;
            dgvGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Tối ưu hiệu năng
            dgvGrades.AllowUserToOrderColumns = false;
            dgvGrades.AllowUserToResizeColumns = true;
            dgvGrades.AllowUserToResizeRows = false;
            dgvGrades.RowHeadersVisible = false;
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedValue != null)
            {
                int classId = (int)cboClass.SelectedValue;
                LoadTrainees(classId);
                UpdateDataGridViewColumns();
            }
        }

        private async void LoadTrainees(int classId)
        {
            var trainees = await _traineeRepository.GetTraineesByClassIdAsync(classId);
            _trainees = trainees.Where(sy => sy.IsActive).OrderBy(t => t.FullName).ToList();
        }

        private void clbSubjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Sử dụng BeginInvoke để đợi đến khi check state được cập nhật
            this.BeginInvoke((MethodInvoker)delegate
            {
                UpdateSelectedSubjects();
                UpdateDataGridViewColumns();
            });
        }

        private void UpdateSelectedSubjects()
        {
            _selectedSubjects.Clear();
            foreach (var item in clbSubjects.CheckedItems)
            {
                _selectedSubjects.Add((CategoryViewModel)item);
            }
        }

        private void UpdateDataGridViewColumns()
        {
            // Tạm thời ngắt binding để tối ưu hiệu năng
            dgvGrades.DataSource = null;

            // Xóa các cột điểm cũ (giữ lại 2 cột đầu)
            while (_gradesData.Columns.Count > 2)
            {
                _gradesData.Columns.RemoveAt(_gradesData.Columns.Count - 1);
            }

            // Thêm cột cho mỗi môn học được chọn
            foreach (var subject in _selectedSubjects)
            {
                _gradesData.Columns.Add($"Subject_{subject.Id}", typeof(decimal));
            }
            _gradesData.Rows.Add(_gradesData.NewRow());

            // Khôi phục binding
            dgvGrades.DataSource = _gradesData;

            // Thiết lập các cột
            if (dgvGrades.Columns.Count > 0)
            {
                dgvGrades.Columns["TraineeId"].Visible = false;
                dgvGrades.Columns["Học viên"].ReadOnly = true;
                dgvGrades.Columns["Học viên"].Width = 200;
            }

            // Đặt tên header cho các cột điểm
            for (int i = 2; i < dgvGrades.Columns.Count; i++)
            {
                var subject = _selectedSubjects[i - 2];
                dgvGrades.Columns[i].HeaderText = $"{subject.Name}";
                dgvGrades.Columns[i].Width = 150;
                dgvGrades.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Đảm bảo thanh cuộn được kích hoạt
            dgvGrades.ScrollBars = ScrollBars.Both;

            // Thêm dữ liệu học viên
            LoadTraineesData();

            CheckScrollNeeded();
        }

        private void CheckScrollNeeded()
        {
            int totalWidth = 0;
            foreach (DataGridViewColumn column in dgvGrades.Columns)
            {
                if (column.Visible)
                    totalWidth += column.Width;
            }

            // Nếu tổng chiều rộng lớn hơn chiều rộng hiển thị, kích hoạt cuộn ngang
            if (totalWidth > dgvGrades.ClientSize.Width)
            {
                dgvGrades.ScrollBars = ScrollBars.Both;
            }
            else
            {
                dgvGrades.ScrollBars = ScrollBars.Vertical;
            }
        }

        private void LoadTraineesData()
        {
            _gradesData.Rows.Clear();

            if (_trainees == null) return;

            foreach (var trainee in _trainees)
            {
                var row = _gradesData.NewRow();
                row["TraineeId"] = trainee.Id;
                row["Học viên"] = trainee.FullName;
                _gradesData.Rows.Add(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                SaveGrades();
                MessageBox.Show("Thêm điểm thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm điểm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (_selectedSubjects.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một môn học", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate điểm số
            foreach (DataRow row in _gradesData.Rows)
            {
                for (int i = 2; i < _gradesData.Columns.Count; i++)
                {
                    if (row[i] != DBNull.Value && row[i] != null)
                    {
                        if (decimal.TryParse(row[i].ToString(), out decimal grade))
                        {
                            if (grade < 0 || grade > 10)
                            {
                                MessageBox.Show($"Điểm phải nằm trong khoảng 0-10. Lỗi tại học viên: {row["Học viên"]}",
                                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Điểm không hợp lệ. Lỗi tại học viên: {row["Học viên"]}",
                                "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private async Task SaveGrades()
        {
            var newGrades = new List<GraduationExamScore>();

            foreach (DataRow row in _gradesData.Rows)
            {
                int traineeId = (int)row["TraineeId"];

                for (int i = 0; i < _selectedSubjects.Count; i++)
                {
                    var subject = _selectedSubjects[i];
                    var gradeValue = row[$"Subject_{subject.Id}"];

                    if (gradeValue != DBNull.Value && gradeValue != null &&
                        decimal.TryParse(gradeValue.ToString(), out decimal gradeDecimal))
                    {
                        var grade = new GraduationExamScore
                        {
                            TraineeId = traineeId,
                            GraduationExamType = subject.Code,
                            Score = gradeDecimal,
                            GradeType = GradeHelpers.CalculateGradeType(gradeDecimal),
                            CreatedDate = DateTime.Now
                        };

                        newGrades.Add(grade);
                    }
                }
            }

            await _graduationExamScoreRepository.AddRangeAsync(newGrades);

            var gradesToUpdate = newGrades.GroupBy(g => new { g.TraineeId })
                .Select(g => new
                {
                    g.Key.TraineeId
                }).ToList();

            foreach (var item in gradesToUpdate)
            {
                await UpdateTraineeGraduationScoreAsync(item.TraineeId);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async Task UpdateTraineeGraduationScoreAsync(int traineeId)
        {
            // Cập nhật điểm trung bình môn cho học viên
            await _graduationScoreRepository.UpdateTraineeGraduationScoreAsync(traineeId);
        }
    }
}
