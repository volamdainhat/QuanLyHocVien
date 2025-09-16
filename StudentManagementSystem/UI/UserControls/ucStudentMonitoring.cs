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

        private readonly DayOfWeek CritiqueDay = DayOfWeek.Tuesday; // configurable if needed

        public ucStudentMonitoring()
        {
            InitializeComponent();

            dgvMisconduct.CellClick += dgvMisconduct_CellClick;
            dgvWeeklyCritique.CellClick += dgvWeeklyCritique_CellClick;
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
                        // Find the first allowed index
                        for (int i = 0; i < box.Items.Count; i++)
                        {
                            if (!disabled.Contains(i))
                            {
                                box.SelectedIndex = i;
                                break;
                            }
                        }
                        return;
                    }
                    ApplyRule(box);

                    criteriaBox.DrawMode = DrawMode.OwnerDrawFixed;
                    criteriaBox.DrawItem += (s, e) => ComboBox_DrawItem((ComboBox)s, e);
                };
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // index 0 → read-only
            // index 1 or last → required, so editable
            // everything else → optional but still editable
            if (comboBox3.SelectedIndex == 0)
            {
                textBox1.ReadOnly = true;
                textBox1.BackColor = Color.LightGray;
                textBox1.Clear();
            }
            else
            {
                textBox1.ReadOnly = false;
                textBox1.BackColor = Color.White;

                // highlight if required but empty
                if ((comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == 2 || comboBox3.SelectedIndex == comboBox3.Items.Count - 1)
                    && string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.BackColor = Color.MistyRose; // visual cue
                }
            }

            // keep your cbPoliticalAttitude logic
            if (comboBox3.SelectedIndex == 1) // lock index 0 for political attitude
            {
                if (!_disabledItems.ContainsKey(cbPoliticalAttitude))
                    _disabledItems[cbPoliticalAttitude] = new HashSet<int>();

                _disabledItems[cbPoliticalAttitude].Add(0);
                if (cbPoliticalAttitude.SelectedIndex == 0 && cbPoliticalAttitude.Items.Count > 1)
                    cbPoliticalAttitude.SelectedIndex = 1;
            }
            else
            {
                if (_disabledItems.ContainsKey(cbPoliticalAttitude))
                {
                    _disabledItems[cbPoliticalAttitude].Remove(0);
                    if (_disabledItems[cbPoliticalAttitude].Count == 0)
                        _disabledItems.Remove(cbPoliticalAttitude);
                }
            }

            cbPoliticalAttitude.Invalidate();
            UpdateSaveButtonState();
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

            if (DateTime.Today.DayOfWeek == CritiqueDay)
            {
                // Weekly critique mode
                if (!ValidateCritiqueForm()) return;
                var critique = ReadFromFormCritique();
                SaveCritique(critique);

                // Misconduct mode
                if (comboBox3.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn loại vi phạm.");
                    return;
                }

                // 🔹 New validation: if index 1 or last, textbox1 must not be empty
                if ((comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == comboBox3.Items.Count - 1)
                    && string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Vui lòng nhập mô tả cho loại vi phạm này.");
                    return;
                }

                var misconduct = ReadFromFormMisconduct();
                SaveMisconduct(misconduct);
            }
            else
            {
                // Misconduct mode
                if (comboBox3.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn loại vi phạm.");
                    return;
                }

                // 🔹 Same validation here too
                if ((comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == comboBox3.Items.Count - 1)
                    && string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Vui lòng nhập mô tả cho loại vi phạm này.");
                    return;
                }

                var misconduct = ReadFromFormMisconduct();
                SaveMisconduct(misconduct);
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
            try
            {
                if (entity.Id != 0)
                {
                    MessageBox.Show("Không thể chỉnh sửa bình rèn đã có. Hãy xóa hoặc nhập mới.");
                    return;
                }

                _context.WeeklyCritiques.Add(entity);
                _context.SaveChanges();

                // recalc MeritScore
                var trainee = _context.Trainees.Include(t => t.WeeklyCritiques)
                                .FirstOrDefault(t => t.Id == entity.TraineeId);
                if (trainee != null)
                {
                    trainee.MeritScore = trainee.WeeklyCritiques.Sum(c => c.FinalScore);
                    _context.SaveChanges();
                }

                MessageBox.Show("Thêm phê bình thành công!");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((comboBox3.SelectedIndex == 1 || comboBox3.SelectedIndex == comboBox3.Items.Count - 1)
                && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.BackColor = Color.MistyRose; // still required and empty
            }
            else
            {
                textBox1.BackColor = Color.White;
            }

            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            bool requireDescription = (comboBox3.SelectedIndex == 1 ||
                                       comboBox3.SelectedIndex == comboBox3.Items.Count - 1);

            if (comboBox3.SelectedIndex == 0)
            {
                textBox1.ReadOnly = true;
                textBox1.BackColor = Color.LightGray;
                textBox1.Clear();
            }
            else
            {
                textBox1.ReadOnly = false;
                if (requireDescription && string.IsNullOrWhiteSpace(textBox1.Text))
                    textBox1.BackColor = Color.MistyRose;
                else
                    textBox1.BackColor = Color.White;
            }

            // disable Save if required field is empty
            btnSave.Enabled = !(requireDescription && string.IsNullOrWhiteSpace(textBox1.Text));
        }
    }
}