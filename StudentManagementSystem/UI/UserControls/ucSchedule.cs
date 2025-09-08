using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucSchedule : UserControl
    {
        private readonly AppDbContext _context = new AppDbContext();

        public ucSchedule()
        {
            InitializeComponent();
            LoadClasses();
            LoadPeriods();
            LoadSubjects();
            LoadData();

            // Hook cell click for autofill
            dgvRead.CellClick += dgvRead_CellClick;
        }

        private void LoadClasses()
        {
            _context.Classes.Load();
            var classes = _context.Classes.Local.ToBindingList();

            cbClassName.DataSource = classes;
            cbClassName.DisplayMember = "Name";
            cbClassName.ValueMember = "Id";
        }

        private void LoadPeriods()
        {
            cbPeriod.Items.AddRange(new string[] { "Sáng", "Chiều" });
        }

        private void LoadData()
        {
            var schedules = _context.Schedules
                .Include(s => s.Class)
                .Include(s => s.Subject)
                .Select(s => new
                {
                    s.Id,
                    ClassName = s.Class.Name,
                    SubjectName = s.Subject.Name,
                    s.Room,
                    s.Period,
                    s.Date
                })
                .OrderBy(s => s.Id)
                .ToList();

            dgvRead.AutoGenerateColumns = true;
            dgvRead.DataSource = schedules;

            HideUnwantedColumns();
            RenameColumns();

            HighlightScheduleDates();
        }

        private void LoadSubjects()
        {
            _context.Subjects.Load();
            var subjects = _context.Subjects.Local.ToBindingList();

            cbSubject.DataSource = subjects;
            cbSubject.DisplayMember = "Name";
            cbSubject.ValueMember = "Id";
        }

        private void HideUnwantedColumns()
        {
            string[] unwanted = { "Class", "Subject", "ClassId", "SubjectId" };
            foreach (var col in unwanted)
            {
                if (dgvRead.Columns.Contains(col))
                    dgvRead.Columns[col].Visible = false;
            }
        }

        private void RenameColumns()
        {
            if (dgvRead.Columns.Contains("ClassName"))
                dgvRead.Columns["ClassName"].HeaderText = "Lớp";
            if (dgvRead.Columns.Contains("SubjectName"))
                dgvRead.Columns["SubjectName"].HeaderText = "Môn";
            if (dgvRead.Columns.Contains("Date"))
                dgvRead.Columns["Date"].HeaderText = "Ngày học";
        }

        private void HighlightScheduleDates()
        {
            mcTimetable.RemoveAllBoldedDates();

            var datesWithSubjects = _context.Schedules
                .Select(s => s.Date.Date)
                .Distinct()
                .ToList();

            foreach (var date in datesWithSubjects)
            {
                mcTimetable.AddBoldedDate(date);
            }

            mcTimetable.UpdateBoldedDates();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            if (cbClassName.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                return;
            }
            if (cbSubject.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn môn học.");
                return;
            }

            var selectedClass = (Class)cbClassName.SelectedItem;
            var selectedSubject = (Subject)cbSubject.SelectedItem;

            var start = dtpStartDate.Value.Date;
            var end = dtpEndDate.Value.Date;
            var daysOfWeek = chlbDaysofWeek.CheckedItems;

            foreach (var day in daysOfWeek)
            {
                DayOfWeek targetDay = day.ToString() switch
                {
                    "Thứ 2" => DayOfWeek.Monday,
                    "Thứ 3" => DayOfWeek.Tuesday,
                    "Thứ 4" => DayOfWeek.Wednesday,
                    "Thứ 5" => DayOfWeek.Thursday,
                    "Thứ 6" => DayOfWeek.Friday,
                    _ => throw new Exception("Ngày không hợp lệ")
                };

                for (var date = start; date <= end; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == targetDay)
                    {
                        var schedule = new Schedule
                        {
                            ClassId = selectedClass.Id,
                            SubjectId = selectedSubject.Id,
                            Room = txtRoom.Text,
                            Period = cbPeriod.SelectedItem?.ToString(),
                            Date = date
                        };
                        _context.Schedules.Add(schedule);
                    }
                }
            }

            _context.SaveChanges();
            LoadData();
        }


        private void mcTimetable_DateChanged(object sender, DateRangeEventArgs e)
        {
            var selectedDate = e.Start.Date;

            var schedules = _context.Schedules
                .Where(s => s.Date == selectedDate)
                .Select(s => new
                {
                    s.Id,
                    ClassName = s.Class.Name,
                    SubjectName = s.Subject.Name,
                    s.Room,
                    s.Period,
                    s.Date
                })
                .OrderBy(s => s.Id)
                .ToList();

            dgvRead.AutoGenerateColumns = true;
            dgvRead.DataSource = schedules;

            HideUnwantedColumns();
            RenameColumns();
        }

        private void Reload()
        {
            LoadData();
            HideUnwantedColumns();
            RenameColumns();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void dgvRead_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvRead.Rows[e.RowIndex];

            txtRoom.Text = row.Cells[3].Value?.ToString();
            cbPeriod.SelectedItem = row.Cells[4].Value?.ToString();
            dtpStartDate.Value = Convert.ToDateTime(row.Cells[5].Value);

            // Class autofill
            var className = row.Cells[1].Value?.ToString();
            if (!string.IsNullOrEmpty(className))
            {
                var classItem = ((BindingList<Class>)cbClassName.DataSource)
                    .FirstOrDefault(c => c.Name == className);
                if (classItem != null)
                    cbClassName.SelectedItem = classItem;
            }

            // Subject autofill
            var subjectName = row.Cells[2].Value?.ToString();
            if (!string.IsNullOrEmpty(subjectName))
            {
                var subjectItem = ((BindingList<Subject>)cbSubject.DataSource)
                    .FirstOrDefault(s => s.Name == subjectName);
                if (subjectItem != null)
                    cbSubject.SelectedItem = subjectItem;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRead.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một lịch để cập nhật.");
                return;
            }

            int scheduleId = Convert.ToInt32(dgvRead.CurrentRow.Cells[0].Value);

            var schedule = _context.Schedules
                .Include(s => s.Subject)
                .FirstOrDefault(s => s.Id == scheduleId);

            if (schedule == null)
            {
                MessageBox.Show("Không tìm thấy lịch trong cơ sở dữ liệu.");
                return;
            }

            schedule.Room = txtRoom.Text;
            schedule.Period = cbPeriod.SelectedItem?.ToString();
            schedule.Date = dtpStartDate.Value.Date;

            if (cbClassName.SelectedItem is Class selectedClass)
                schedule.ClassId = selectedClass.Id;

            if (cbSubject.SelectedItem is Subject selectedSubject)
                schedule.SubjectId = selectedSubject.Id;

            _context.SaveChanges();
            ClearForm();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRead.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một lịch để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa lịch đã chọn?",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            foreach (DataGridViewRow row in dgvRead.SelectedRows)
            {
                int scheduleId = Convert.ToInt32(row.Cells[0].Value);
                var schedule = _context.Schedules.FirstOrDefault(s => s.Id == scheduleId);
                if (schedule != null)
                {
                    _context.Schedules.Remove(schedule);
                }
            }

            _context.SaveChanges();
            LoadData(); // reload & refresh highlights
        }

        // Helpers
        private void ClearForm()
        {
            txtRoom.Clear();
            cbSubject.SelectedItem = 0;
            cbPeriod.SelectedIndex = -1;
            cbClassName.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            for (int i = 0; i < chlbDaysofWeek.Items.Count; i++)
                chlbDaysofWeek.SetItemChecked(i, false);
        }

        // BtnAddNewSubject should open a new form to add subjects
        private void btnAddNewSubject_Click(object sender, EventArgs e)
        {
            // Inline form
            using (var form = new Form())
            {
                form.Text = "Thêm môn học";
                form.Size = new Size(300, 150);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MaximizeBox = false;
                form.MinimizeBox = false;

                var lbl = new Label { Text = "Tên môn học:", Left = 10, Top = 20, AutoSize = true };
                var txt = new TextBox { Left = 100, Top = 18, Width = 150 };
                var btnSave = new Button { Text = "Lưu", Left = 100, Top = 60, Width = 70, DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Hủy", Left = 180, Top = 60, Width = 70, DialogResult = DialogResult.Cancel };

                form.Controls.Add(lbl);
                form.Controls.Add(txt);
                form.Controls.Add(btnSave);
                form.Controls.Add(btnCancel);

                form.AcceptButton = btnSave;
                form.CancelButton = btnCancel;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    string subjectName = txt.Text.Trim();
                    if (string.IsNullOrEmpty(subjectName))
                    {
                        MessageBox.Show("Tên môn học không được để trống.");
                        return;
                    }

                    // Prevent duplicates
                    if (_context.Subjects.Any(s => s.Name.ToLower() == subjectName.ToLower()))
                    {
                        MessageBox.Show("Môn học đã tồn tại.");
                        return;
                    }

                    var newSubject = new Subject { Name = subjectName };
                    _context.Subjects.Add(newSubject);
                    _context.SaveChanges();

                    // Refresh combo
                    LoadSubjects();
                    cbSubject.SelectedItem = _context.Subjects.Local.FirstOrDefault(s => s.Id == newSubject.Id);
                }
            }
        }

    }
}
