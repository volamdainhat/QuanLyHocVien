using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucClass : UserControl
    {
        private AppDbContext? dbContext = null;

        public ucClass()
        {
            InitializeComponent();
        }

        private void ucClass_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            LoadDataAsync();
        }

        private void ConnectToDatabase()
        {
            dbContext = new AppDbContext();
            dbContext.Database.EnsureCreated();
        }

        private void LoadDataAsync()
        {
            dbContext?.Classes
                .Include(c => c.Trainees) // Important for TotalStudents
                .Load();

            classBindingSource.DataSource = dbContext?.Classes.Local.ToBindingList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            this.dgvRead.Refresh();
            this.dgvRead.Sort(dgvRead.Columns[0], ListSortDirection.Ascending);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrUpdate();
        }

        private void SaveOrUpdate()
        {
            var item = ReadFromForm();
            Save(item);
            Reload();
        }

        private void Save(Class entity)
        {
            if (entity.Id == 0)
            {
                dbContext?.Classes.Add(entity);
            }
            else
            {
                var tracked = dbContext.ChangeTracker
                    .Entries<Class>()
                    .FirstOrDefault(e => e.Entity.Id == entity.Id);

                if (tracked != null)
                {
                    dbContext.Entry(tracked.Entity).State = EntityState.Detached;
                }

                dbContext?.Classes.Update(entity);
            }

            dbContext?.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            var ids = GetSelectedIds();
            if (ids == null || ids.Count == 0) return;

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa {ids.Count} bản ghi?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirm != DialogResult.Yes) return;

            ids = ids.Distinct().ToList();
            var toDelete = dbContext?.Classes.Where(t => ids.Contains(t.Id)).ToList();
            dbContext?.Classes.RemoveRange(toDelete!);
            dbContext?.SaveChanges();
            Reload();
        }

        private List<int> GetSelectedIds()
        {
            return dgvRead.SelectedRows
                .Cast<DataGridViewRow>()
                .Select(row => (row.DataBoundItem as Class)?.Id ?? 0)
                .Where(id => id > 0)
                .ToList();
        }

        private void BindSelectedRowToForm()
        {
            if (dgvRead.SelectedRows.Count == 0) return;

            var item = dgvRead.SelectedRows[0].DataBoundItem!;
            BindToForm((Class)item);
        }

        private void BindToForm(Class entity)
        {
            if (entity == null) return;

            txtClassid.Text = entity.Id.ToString();
            txtClassname.Text = entity.Name;
            dtpStartdate.Value = entity.StartDate;
            dtpEnddate.Value = entity.EndDate;
            txtMaxStudents.Text = entity.MaxStudents.ToString();

            // TotalStudents is computed, just display it
            txtTotalStudents.Text = entity.TotalStudents.ToString();
        }

        private void ClearForm()
        {
            txtClassid.Clear();
            txtClassname.Clear();
            dtpStartdate.Value = DateTime.Now;
            dtpEnddate.Value = DateTime.Now;
            txtTotalStudents.Clear();
            txtMaxStudents.Clear();
        }

        private Class ReadFromForm()
        {
            return new Class
            {
                Id = int.TryParse(txtClassid.Text, out var id) ? id : 0,
                Name = txtClassname.Text,
                StartDate = dtpStartdate.Value,
                EndDate = dtpEnddate.Value,
                MaxStudents = int.TryParse(txtMaxStudents.Text, out var max) ? max : 0
            };
        }

        private void dgvRead_SelectionChanged(object sender, EventArgs e)
        {
            BindSelectedRowToForm();
        }

        private void dgvRead_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignore header row clicks

            var selectedClass = dgvRead.Rows[e.RowIndex].DataBoundItem as Class;
            if (selectedClass == null) return;

            ShowTraineesForClass(selectedClass.Id);
        }

        // ===============================
        //  Query and display trainees for a class
        // ===============================

        private void ShowTraineesForClass(int classId)
        {
            var cls = dbContext?.Classes.Include(c => c.Trainees).FirstOrDefault(c => c.Id == classId);
            if (cls == null) return;

            var traineeList = cls.Trainees.ToList();

            // Create popup form
            Form form = new Form
            {
                Text = $"Danh sách học viên - {cls.Name}",
                Size = new Size(1280, 720),
                StartPosition = FormStartPosition.CenterParent
            };

            // Controls
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            TextBox txtSearch = new TextBox { Width = 200, PlaceholderText = "Tìm kiếm..." };
            Button btnAdd = new Button { Text = "➕ Thêm", Width = 80 };
            Button btnEdit = new Button { Text = "✏️ Sửa", Width = 80 };
            Button btnDelete = new Button { Text = "🗑️ Xóa", Width = 80 };

            panel.Controls.AddRange(new Control[] { txtSearch, btnAdd, btnEdit, btnDelete});

            DataGridView grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                DataSource = new BindingList<Trainee>(traineeList)
            };
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            Label lblCount = new Label
            {
                Dock = DockStyle.Bottom,
                TextAlign = ContentAlignment.MiddleRight,
                Height = 30
            };
            void UpdateCount() => lblCount.Text = $"Tổng số học viên: {traineeList.Count}/{cls.MaxStudents}";
            UpdateCount();

            // 🔍 Search
            txtSearch.TextChanged += (s, e) =>
            {
                string term = txtSearch.Text.Trim().ToLower();
                var filtered = traineeList
                    .Where(t => t.FullName.ToLower().Contains(term)
                             || t.PhoneNumber.Contains(term)
                             || (!string.IsNullOrEmpty(t.Ranking) && t.Ranking.ToLower().Contains(term)))
                    .ToList();
                grid.DataSource = new BindingList<Trainee>(filtered);
            };

            // ➕ Add
            btnAdd.Click += (s, e) =>
            {
                var trainee = ShowTraineeForm(cls.Id);

                if (trainee != null)
                {
                    dbContext.Trainees.Add(trainee);
                    dbContext.SaveChanges();
                    traineeList.Add(trainee);
                }
                else
                {
                    traineeList = dbContext.Trainees.Where(t => t.ClassId == cls.Id).ToList();
                }

                grid.DataSource = new BindingList<Trainee>(traineeList);
                UpdateCount();
            };

            // ✏️ Edit
            btnEdit.Click += (s, e) =>
            {
                if (grid.CurrentRow?.DataBoundItem is not Trainee trainee) return;

                var updated = ShowTraineeForm(cls.Id, trainee);
                if (updated != null)
                {
                    dbContext.Trainees.Update(updated);
                    dbContext.SaveChanges();
                    grid.Refresh();
                }
            };

            // 🗑️ Delete (unassign only)
            btnDelete.Click += (s, e) =>
            {
                if (grid.SelectedRows.Count == 0) return;

                var confirm = MessageBox.Show("Bạn có chắc chắn muốn bỏ học viên khỏi lớp?", "Xác nhận",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;

                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    if (row.DataBoundItem is Trainee t)
                    {
                        t.ClassId = null; // just unassign
                        dbContext.Trainees.Update(t);
                        traineeList.Remove(t);
                    }
                }
                dbContext.SaveChanges();
                grid.DataSource = new BindingList<Trainee>(traineeList);
                UpdateCount();
            };


            form.Controls.Add(grid);
            form.Controls.Add(panel);
            form.Controls.Add(lblCount);

            ConfigureTraineeGrid(grid, traineeList);

            form.ShowDialog();
        }

        // ===============================
        // Reusable modal for adding/editing/assigning trainee
        // ===============================
        private Trainee? ShowTraineeForm(int classId, Trainee? trainee = null)
        {
            trainee ??= new Trainee();

            using var form = new Form
            {
                Text = trainee.Id == 0 ? "Thêm học viên" : "Cập nhật học viên",
                Size = new Size(600, 400),
                StartPosition = FormStartPosition.CenterParent
            };

            var tab = new TabControl { Dock = DockStyle.Fill };
            var tabNew = new TabPage("➕ Thêm mới");
            var tabExisting = new TabPage("📋 Gán có sẵn");
            tab.TabPages.AddRange(new[] { tabNew, tabExisting });

            // TAB 1: New trainee
            TextBox txtName = new TextBox { Left = 150, Top = 20, Width = 300, Text = trainee.FullName ?? "" };
            TextBox txtPhone = new TextBox { Left = 150, Top = 60, Width = 300, Text = trainee.PhoneNumber ?? "" };
            DateTimePicker dtpBirth = new DateTimePicker
            {
                Left = 150,
                Top = 100,
                Width = 300,
                Value = trainee.DayOfBirth ?? DateTime.Today
            };
            TextBox txtRank = new TextBox { Left = 150, Top = 140, Width = 300, Text = trainee.Ranking ?? "" };

            tabNew.Controls.AddRange(new Control[]
            {
                new Label { Left = 20, Top = 20, Text = "Họ tên:" }, txtName,
                new Label { Left = 20, Top = 60, Text = "SĐT:" }, txtPhone,
                new Label { Left = 20, Top = 100, Text = "Ngày sinh:" }, dtpBirth,
                new Label { Left = 20, Top = 140, Text = "Xếp loại:" }, txtRank
            });

            // TAB 2: Assign existing
            var checklist = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                CheckOnClick = true
            };

            using (var db = new AppDbContext())
            {
                var available = db.Trainees.Where(t => t.ClassId == null).ToList();
                foreach (var t in available)
                {
                    checklist.Items.Add(t.FullName, false); // show only name
                }
            }

            tabExisting.Controls.Add(checklist);

            // Buttons
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 40
            };

            var btnOk = new Button { Text = "Lưu", DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel };
            panel.Controls.AddRange(new Control[] { btnOk, btnCancel });

            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            form.Controls.Add(tab);
            form.Controls.Add(panel);

            // Logic
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (tab.SelectedTab == tabNew)
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        MessageBox.Show("Tên học viên không được để trống.");
                        return null;
                    }
                    if (!Regex.IsMatch(txtPhone.Text, @"^\\d{9,11}$"))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ.");
                        return null;
                    }

                    trainee.FullName = txtName.Text;
                    trainee.PhoneNumber = txtPhone.Text;
                    trainee.DayOfBirth = dtpBirth.Value;
                    trainee.Ranking = txtRank.Text;
                    trainee.ClassId = classId;
                    trainee.ClassName = dbContext?.Classes.Find(trainee.ClassId)?.Name;

                    return trainee;
                }
                else if (tab.SelectedTab == tabExisting)
                {
                    if (checklist.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Chọn ít nhất 1 học viên có sẵn.");
                        return null;
                    }

                    using (var db = new AppDbContext())
                    {
                        var available = db.Trainees.Where(t => t.ClassId == null).ToList();
                        foreach (string selectedName in checklist.CheckedItems)
                        {
                            var existing = available.FirstOrDefault(x => x.FullName == selectedName);
                            if (existing != null)
                            {
                                existing.ClassId = classId;
                                existing.ClassName = db.Classes.Find(classId)?.Name;
                                db.Trainees.Update(existing);
                            }
                        }
                        db.SaveChanges();
                    }

                    return null; // nothing new to add
                }
            }

            return null;
        }

        private void ConfigureTraineeGrid(DataGridView grid, List<Trainee> traineeList)
        {
            grid.DataSource = new BindingList<Trainee>(traineeList);

            if (grid.Columns.Contains("FullName"))
                grid.Columns["FullName"].HeaderText = "Họ và tên";
                grid.Columns["PhoneNumber"].HeaderText = "SĐT";
            if (grid.Columns.Contains("DayOfBirth"))
            {
                grid.Columns["DayOfBirth"].HeaderText = "Ngày sinh";
                grid.Columns["DayOfBirth"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (grid.Columns.Contains("Ranking"))
                grid.Columns["Ranking"].HeaderText = "Cấp bậc";
            if (grid.Columns.Contains("EnlistmentDate"))
            {
                grid.Columns["EnlistmentDate"].HeaderText = "Nhập ngũ";
                grid.Columns["EnlistmentDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (grid.Columns.Contains("AverageScore"))
                grid.Columns["AverageScore"].HeaderText = "ĐTB";
            if (grid.Columns.Contains("Role"))
                grid.Columns["Role"].HeaderText = "Chức vụ";
            if (grid.Columns.Contains("FatherFullName"))
                grid.Columns["FatherFullName"].HeaderText = "Họ tên cha";
            if (grid.Columns.Contains("FatherPhoneNumber"))
                grid.Columns["FatherPhoneNumber"].HeaderText = "SĐT cha";
            if (grid.Columns.Contains("MotherFullName"))
                grid.Columns["MotherFullName"].HeaderText = "Họ tên mẹ";
            if (grid.Columns.Contains("MotherPhoneNumber"))
                grid.Columns["MotherPhoneNumber"].HeaderText = "SĐT mẹ";

            if (grid.Columns.Contains("AvatarUrl"))
                grid.Columns["AvatarUrl"].Visible = false;
            if (grid.Columns.Contains("Misconducts"))
                grid.Columns["Misconducts"].Visible = false;
            if (grid.Columns.Contains("Grades"))
                grid.Columns["Grades"].Visible = false;
            if (grid.Columns.Contains("Id"))
                grid.Columns["Id"].Visible = false;
            if (grid.Columns.Contains("ClassId"))
                grid.Columns["ClassId"].Visible = false;
            if (grid.Columns.Contains("ClassName"))
                grid.Columns["ClassName"].Visible = false;

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
        }

        // Optional
        private void ExportGridToCsv(DataGridView grid, string filePath)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                var visibleColumns = grid.Columns
                    .Cast<DataGridViewColumn>()
                    .Where(c => c.Visible)
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                writer.WriteLine(string.Join(",", visibleColumns.Select(c => $"\"{c.HeaderText}\"")));

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.IsNewRow) continue;

                    var cells = visibleColumns.Select(c =>
                        row.Cells[c.Index].Value != null
                            ? $"\"{row.Cells[c.Index].Value.ToString().Replace("\"", "\"\"")}\""
                            : "\"\""
                    );

                    writer.WriteLine(string.Join(",", cells));
                }
            }

            MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

// ===============================
// Utility: Method to assign trainee safely
// ===============================
public class TraineeService
{
    private readonly AppDbContext _db;

    public TraineeService(AppDbContext db)
    {
        _db = db;
    }

    public bool TryAssignTrainee(int classId, Trainee trainee)
    {
        var cls = _db.Classes
            .Include(c => c.Trainees)
            .FirstOrDefault(c => c.Id == classId);

        if (cls == null) return false;
        if (cls.Trainees.Count >= cls.MaxStudents) return false;

        trainee.ClassId = classId;
        _db.Trainees.Update(trainee);
        _db.SaveChanges();
        return true;
    }
}
