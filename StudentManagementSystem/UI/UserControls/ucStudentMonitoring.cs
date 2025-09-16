using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucStudentMonitoring : UserControl
    {
        private readonly AppDbContext _context = new AppDbContext();
        private int _editingId = 0; // >0 = editing entity
        private string _editingType = ""; // "Misconduct" or "WeeklyCritique"

        private record ComboRule(string[] Values, bool Enabled);
        private Dictionary<ComboBox, (ComboBox GradeBox, Dictionary<int, ComboRule> Rules)> _rules;
        private readonly Dictionary<ComboBox, HashSet<int>> _disabledItems = new();

        private readonly DayOfWeek CritiqueDay = DayOfWeek.Wednesday; // configurable if needed

        public ucStudentMonitoring()
        {
            InitializeComponent();

            dgvMisconduct.CellClick += dgvMisconduct_CellClick;
            dgvWeeklyCritique.CellClick += dgvWeeklyCritique_CellClick;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            cbClass.SelectedIndexChanged += CbClass_SelectedIndexChanged;

            btnAdd.Click += (s, e) => ClearForm();
            btnSave.Click += (s, e) => SaveOrUpdate();
            btnDelete.Click += (s, e) => DeleteSelected();
            btnRefresh.Click += (s, e) => Reload();

            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            InitRules();
            LoadClasses();
            LoadStudents();
            LoadMisconductTypes();
            LoadCriterias();
            LoadData();

            foreach (var cb in _rules.Keys)
                ApplyRule(cb);
        }

        // ===============================
        // Init Rules / Apply
        // ===============================
        private void InitRules()
        {
            _rules = new()
            {
                [cbPoliticalAttitude] = (cbPoliticalGrade, new Dictionary<int, ComboRule>
                {
                    { 0, new ComboRule(new[] { "10" }, false) },
                    { 1, new ComboRule(new[] { "7", "6" }, true) },
                    { 2, new ComboRule(new[] { "4" }, false) }
                }),
                [cbStudyMotivation] = (cbStudyMovGrade, new Dictionary<int, ComboRule>
                {
                    { 0, new ComboRule(new[] { "10" }, false) },
                    { 1, new ComboRule(new[] { "7", "6" }, true) },
                    { 2, new ComboRule(new[] { "4" }, false) }
                }),
                [cbEthicsLifestyle] = (cbLifestyleGrade, new Dictionary<int, ComboRule>
                {
                    { 0, new ComboRule(new[] { "10" }, false) },
                    { 1, new ComboRule(new[] { "7" }, false) },
                    { 2, new ComboRule(new[] { "6", "5" }, true) },
                    { 3, new ComboRule(new[] { "4" }, false) }
                }),
                [cbAcademicResult] = (cbStudyGrade, new Dictionary<int, ComboRule>
                {
                    { 0, new ComboRule(new[] { "10" }, false) },
                    { 1, new ComboRule(new[] { "7", "6" }, true) },
                    { 2, new ComboRule(new[] { "4" }, false) }
                }),
                [cbDisciplineAwareness] = (cbDisciplineGrade, new Dictionary<int, ComboRule>
                {
                    { 0, new ComboRule(new[] { "10" }, false) },
                    { 1, new ComboRule(new[] { "7", "6" }, true) },
                    { 2, new ComboRule(new[] { "4" }, true) }
                }),
                [cbResearchActivity] = (cbResearchGrade, new Dictionary<int, ComboRule>
                {
                    { 0, new ComboRule(new[] { "10" }, false) },
                    { 1, new ComboRule(new[] { "8" }, false) }
                })
            };

            foreach (var criteriaBox in _rules.Keys)
            {
                criteriaBox.SelectedIndexChanged += (s, e) =>
                {
                    var box = (ComboBox)s;
                    if (_disabledItems.TryGetValue(box, out var disabled) && disabled.Contains(box.SelectedIndex))
                    {
                        box.SelectedIndex = box.Items.Count > 0 ? 0 : -1;
                        return;
                    }
                    ApplyRule(box);
                };

                criteriaBox.DrawMode = DrawMode.OwnerDrawFixed;
                criteriaBox.DrawItem += (s, e) => ComboBox_DrawItem((ComboBox)s, e);
            }
        }

        private void ApplyRule(ComboBox criteriaBox)
        {
            if (!_rules.TryGetValue(criteriaBox, out var mapping)) return;
            var (gradeBox, rules) = mapping;
            if (!rules.TryGetValue(criteriaBox.SelectedIndex, out var rule)) return;

            gradeBox.Items.Clear();
            gradeBox.Items.AddRange(rule.Values);
            gradeBox.SelectedIndex = 0;
            gradeBox.Enabled = rule.Enabled;
        }

        private void ComboBox_DrawItem(ComboBox comboBox, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var text = comboBox.Items[e.Index].ToString();
            bool disabled = _disabledItems.TryGetValue(comboBox, out var set) && set.Contains(e.Index);
            e.DrawBackground();
            using var brush = new SolidBrush(disabled ? Color.Gray : e.ForeColor);
            e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }

        // ===============================
        // Load
        // ===============================
        private void LoadClasses()
        {
            // Load distinct class names from trainees
            var classes = _context.Trainees
                .Where(t => t.ClassName != null && t.ClassName != "")
                .Select(t => t.ClassName)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            cbClass.Items.Clear();
            cbClass.Items.Add("Tất cả lớp"); // Option to show all trainees
            cbClass.Items.AddRange(classes.ToArray());
            cbClass.SelectedIndex = 0;
        }

        private void LoadStudents()
        {
            _context.Trainees.Load();
            FilterStudentsByClass();
        }

        private void FilterStudentsByClass()
        {
            var selectedClass = cbClass.SelectedItem?.ToString();

            if (selectedClass == "Tất cả lớp" || string.IsNullOrEmpty(selectedClass))
            {
                comboBox1.DataSource = _context.Trainees.Local.ToBindingList();
            }
            else
            {
                var filteredStudents = _context.Trainees.Local
                    .Where(t => t.ClassName == selectedClass)
                    .ToList();

                comboBox1.DataSource = filteredStudents;
            }

            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "Id";
        }

        private void LoadMisconductTypes()
        {
            comboBox3.Items.Clear();
            comboBox3.Items.AddRange(new string[]
            {
                "Vắng", "Vi phạm kỷ luật", "Đi trễ", "Gian lận kiểm tra", "Mất trật tự", "Khác"
            });
        }

        private void LoadCriterias()
        {
            cbPoliticalAttitude.Items.Clear();
            cbPoliticalAttitude.Items.AddRange(new[] { "Vững vàng, kiên định", "Có khi còn hạn chế", "Một số còn hạn chế" });
            cbStudyMotivation.Items.Clear();
            cbStudyMotivation.Items.AddRange(new[] { "Học tập tốt, nghiêm túc", "Chưa cao", "Hạn chế" });
            cbEthicsLifestyle.Items.Clear();
            cbEthicsLifestyle.Items.AddRange(new[] { "Tích cực", "Ý thức kém", "Phẩm chất kém", "Thiếu chủ động" });
            cbDisciplineAwareness.Items.Clear();
            cbDisciplineAwareness.Items.AddRange(new[] { "Chấp hành nghiêm", "Chưa có ý thức", "Vi phạm kỷ luật" });
            cbAcademicResult.Items.Clear();
            cbAcademicResult.Items.AddRange(new[] { "Tốt", "Chưa tốt", "Yếu" });
            cbResearchActivity.Items.Clear();
            cbResearchActivity.Items.AddRange(new[] { "Có", "Không" });

            cbPoliticalAttitude.SelectedIndex = 0;
            cbStudyMotivation.SelectedIndex = 0;
            cbEthicsLifestyle.SelectedIndex = 0;
            cbDisciplineAwareness.SelectedIndex = 0;
            cbAcademicResult.SelectedIndex = 0;
            cbResearchActivity.SelectedIndex = 1;
        }

        private void LoadData()
        {
            // Pre-load the navigation data
            _context.Misconducts.Include(m => m.Trainee).Load();
            _context.WeeklyCritiques.Include(c => c.Trainee).Load();

            // Load misconducts
            var misconducts = _context.Misconducts.Local
                .Select(m => new
                {
                    m.Id,
                    StudentName = m.Trainee?.FullName ?? "",
                    ClassName = m.Trainee?.ClassName ?? "",
                    m.Type,
                    m.Time,
                    m.Description
                }).ToList();

            dgvMisconduct.DataSource = misconducts;

            // Load critiques
            var critiques = _context.WeeklyCritiques.Local
                .Select(c => new
                {
                    c.Id,
                    StudentName = c.Trainee?.FullName ?? "",
                    ClassName = c.Trainee?.ClassName ?? "",
                    c.WeekDate,
                    c.PoliticalAttitude,
                    c.StudyMotivation,
                    c.EthicsLifestyle,
                    c.DisciplineAwareness,
                    c.AcademicResult,
                    c.ResearchActivity,
                    c.FinalScore
                }).ToList();

            dgvWeeklyCritique.DataSource = critiques;

            RenameColumns();
            ClearSelection();
        }

        private void RenameColumns()
        {
            // Rename misconduct columns
            if (dgvMisconduct.Columns.Contains("StudentName")) dgvMisconduct.Columns["StudentName"].HeaderText = "Tên học viên";
            if (dgvMisconduct.Columns.Contains("ClassName")) dgvMisconduct.Columns["ClassName"].HeaderText = "Lớp";
            if (dgvMisconduct.Columns.Contains("Type")) dgvMisconduct.Columns["Type"].HeaderText = "Loại vi phạm";
            if (dgvMisconduct.Columns.Contains("Time")) dgvMisconduct.Columns["Time"].HeaderText = "Ngày";
            if (dgvMisconduct.Columns.Contains("Description")) dgvMisconduct.Columns["Description"].HeaderText = "Mô tả";

            // Rename critique columns
            if (dgvWeeklyCritique.Columns.Contains("StudentName")) dgvWeeklyCritique.Columns["StudentName"].HeaderText = "Tên học viên";
            if (dgvWeeklyCritique.Columns.Contains("ClassName")) dgvWeeklyCritique.Columns["ClassName"].HeaderText = "Lớp";
            if (dgvWeeklyCritique.Columns.Contains("WeekDate")) dgvWeeklyCritique.Columns["WeekDate"].HeaderText = "Tuần";
            if (dgvWeeklyCritique.Columns.Contains("FinalScore")) dgvWeeklyCritique.Columns["FinalScore"].HeaderText = "Điểm";
            if (dgvWeeklyCritique.Columns.Contains("PoliticalAttitude")) dgvWeeklyCritique.Columns["PoliticalAttitude"].HeaderText = "Thái độ chính trị";
            if (dgvWeeklyCritique.Columns.Contains("StudyMotivation")) dgvWeeklyCritique.Columns["StudyMotivation"].HeaderText = "Động cơ học tập";
            if (dgvWeeklyCritique.Columns.Contains("EthicsLifestyle")) dgvWeeklyCritique.Columns["EthicsLifestyle"].HeaderText = "Đạo đức lối sống";
            if (dgvWeeklyCritique.Columns.Contains("DisciplineAwareness")) dgvWeeklyCritique.Columns["DisciplineAwareness"].HeaderText = "Ý thức kỷ luật";
            if (dgvWeeklyCritique.Columns.Contains("AcademicResult")) dgvWeeklyCritique.Columns["AcademicResult"].HeaderText = "Kết quả học tập";
            if (dgvWeeklyCritique.Columns.Contains("ResearchActivity")) dgvWeeklyCritique.Columns["ResearchActivity"].HeaderText = "Hoạt động nghiên cứu";
        }

        // ===============================
        // Events
        // ===============================
        private void CbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStudentsByClass();
        }

        private void dgvMisconduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvMisconduct.Rows[e.RowIndex];
            _editingId = Convert.ToInt32(row.Cells["Id"].Value);
            _editingType = "Misconduct";

            // Set the class filter first
            var className = row.Cells["ClassName"].Value?.ToString();
            if (!string.IsNullOrEmpty(className))
            {
                cbClass.SelectedItem = className;
            }

            // Find and select the student
            var studentName = row.Cells["StudentName"].Value?.ToString();
            if (!string.IsNullOrEmpty(studentName))
            {
                foreach (Trainee item in comboBox1.Items)
                {
                    if (item.FullName == studentName)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
                }
            }

            comboBox3.Text = row.Cells["Type"].Value?.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Time"].Value);
            textBox1.Text = row.Cells["Description"].Value?.ToString();

            // Switch to misconduct tab
            tabControl1.SelectedTab = tpMisconduct;
        }

        private void dgvWeeklyCritique_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvWeeklyCritique.Rows[e.RowIndex];
            _editingId = Convert.ToInt32(row.Cells["Id"].Value);
            _editingType = "WeeklyCritique";

            // Set the class filter first
            var className = row.Cells["ClassName"].Value?.ToString();
            if (!string.IsNullOrEmpty(className))
            {
                cbClass.SelectedItem = className;
            }

            // Find and select the student
            var studentName = row.Cells["StudentName"].Value?.ToString();
            if (!string.IsNullOrEmpty(studentName))
            {
                foreach (Trainee item in comboBox1.Items)
                {
                    if (item.FullName == studentName)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
                }
            }

            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["WeekDate"].Value);

            // Switch to critique tab
            tabControl1.SelectedTab = tpWeeklyCritique;

            // TODO: Load critique data back into controls if needed
            // This would require parsing the stored values
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear selection when switching tabs
            ClearSelection();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No need to set class name anymore since we're using cbClass for filtering
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = comboBox3.SelectedIndex == 0;
        }

        // ===============================
        // Save / Update / Delete
        // ===============================
        private void SaveOrUpdate()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn học viên.");
                return;
            }

            if (tabControl1.SelectedTab == tpMisconduct)
            {
                if (comboBox3.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn loại vi phạm.");
                    return;
                }

                var misconduct = ReadFromFormMisconduct();
                SaveMisconduct(misconduct);
            }
            else if (tabControl1.SelectedTab == tpWeeklyCritique)
            {
                if (!ValidateCritiqueForm()) return;
                var critique = ReadFromFormCritique();
                SaveCritique(critique);
            }

            LoadData();
            ClearForm();
        }

        private bool ValidateCritiqueForm()
        {
            if (cbPoliticalAttitude.SelectedIndex < 0 ||
                cbStudyMotivation.SelectedIndex < 0 ||
                cbEthicsLifestyle.SelectedIndex < 0 ||
                cbDisciplineAwareness.SelectedIndex < 0 ||
                cbAcademicResult.SelectedIndex < 0 ||
                cbResearchActivity.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ các tiêu chí đánh giá.");
                return false;
            }
            return true;
        }

        private Misconduct ReadFromFormMisconduct() =>
            new()
            {
                Id = _editingId,
                TraineeId = (int)comboBox1.SelectedValue,
                Type = comboBox3.SelectedItem?.ToString() ?? "",
                Time = dateTimePicker1.Value,
                Description = textBox1.Text
            };

        private WeeklyCritique ReadFromFormCritique()
        {
            int score = 0;
            int.TryParse(cbPoliticalGrade.Text, out int g1);
            int.TryParse(cbStudyMovGrade.Text, out int g2);
            int.TryParse(cbLifestyleGrade.Text, out int g3);
            int.TryParse(cbDisciplineGrade.Text, out int g4);
            int.TryParse(cbStudyGrade.Text, out int g5);
            int.TryParse(cbResearchGrade.Text, out int g6);
            score = g1 + g2 + g3 + g4 + g5 + g6;

            return new WeeklyCritique
            {
                Id = _editingId,
                TraineeId = (int)comboBox1.SelectedValue,
                PoliticalAttitude = cbPoliticalAttitude.Text,
                StudyMotivation = cbStudyMotivation.Text,
                EthicsLifestyle = cbEthicsLifestyle.Text,
                DisciplineAwareness = cbDisciplineAwareness.Text,
                AcademicResult = cbAcademicResult.Text,
                ResearchActivity = cbResearchActivity.Text,
                FinalScore = score,
                WeekDate = dateTimePicker1.Value
            };
        }

        private void SaveMisconduct(Misconduct entity)
        {
            try
            {
                if (entity.Id == 0)
                    _context.Misconducts.Add(entity);
                else
                    _context.Misconducts.Update(entity);

                _context.SaveChanges();
                MessageBox.Show("Lưu vi phạm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu vi phạm: {ex.Message}");
            }
        }

        private void SaveCritique(WeeklyCritique entity)
        {
            if (entity.WeekDate.DayOfWeek != CritiqueDay)
            {
                MessageBox.Show($"Bình rèn chỉ có thể lưu vào {CritiqueDay}.");
                return;
            }

            try
            {
                if (entity.Id == 0)
                    _context.WeeklyCritiques.Add(entity);
                else
                    _context.WeeklyCritiques.Update(entity);

                _context.SaveChanges();

                // recalc MeritScore
                var trainee = _context.Trainees.Include(t => t.WeeklyCritiques)
                                .FirstOrDefault(t => t.Id == entity.TraineeId);
                if (trainee != null)
                {
                    trainee.MeritScore = trainee.WeeklyCritiques.Sum(c => c.FinalScore);
                    _context.SaveChanges();
                }

                MessageBox.Show("Lưu phê bình thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phê bình: {ex.Message}");
            }
        }

        private void DeleteSelected()
        {
            if (tabControl1.SelectedTab == tpMisconduct && dgvMisconduct.SelectedRows.Count == 0) return;
            if (tabControl1.SelectedTab == tpWeeklyCritique && dgvWeeklyCritique.SelectedRows.Count == 0) return;

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa mục này?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                if (tabControl1.SelectedTab == tpMisconduct)
                {
                    var row = dgvMisconduct.SelectedRows[0];
                    var id = Convert.ToInt32(row.Cells["Id"].Value);
                    var entity = _context.Misconducts.FirstOrDefault(m => m.Id == id);

                    if (entity != null)
                    {
                        _context.Misconducts.Remove(entity);
                        _context.SaveChanges();
                        MessageBox.Show("Xóa vi phạm thành công!");
                    }
                }
                else
                {
                    var row = dgvWeeklyCritique.SelectedRows[0];
                    var id = Convert.ToInt32(row.Cells["Id"].Value);
                    var entity = _context.WeeklyCritiques.FirstOrDefault(c => c.Id == id);

                    if (entity != null)
                    {
                        _context.WeeklyCritiques.Remove(entity);

                        // recalc MeritScore for the trainee
                        var trainee = _context.Trainees.Include(t => t.WeeklyCritiques)
                                        .FirstOrDefault(t => t.Id == entity.TraineeId);
                        if (trainee != null)
                        {
                            trainee.MeritScore = trainee.WeeklyCritiques.Sum(c => c.FinalScore);
                        }

                        _context.SaveChanges();
                        MessageBox.Show("Xóa phê bình thành công!");
                    }
                }

                LoadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}");
            }
        }

        // ===============================
        // Utility
        // ===============================
        private void ClearForm()
        {
            _editingId = 0;
            _editingType = "";
            ClearSelection();

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

            comboBox3.SelectedIndex = -1;
            textBox1.Clear();
            dateTimePicker1.Value = DateTime.Today;

            // Reset critique controls to defaults
            cbPoliticalAttitude.SelectedIndex = 0;
            cbStudyMotivation.SelectedIndex = 0;
            cbEthicsLifestyle.SelectedIndex = 0;
            cbDisciplineAwareness.SelectedIndex = 0;
            cbAcademicResult.SelectedIndex = 0;
            cbResearchActivity.SelectedIndex = 1;
        }

        private void ClearSelection()
        {
            dgvMisconduct.ClearSelection();
            dgvMisconduct.CurrentCell = null;
            dgvWeeklyCritique.ClearSelection();
            dgvWeeklyCritique.CurrentCell = null;
        }

        private void Reload() => LoadData();
    }
}