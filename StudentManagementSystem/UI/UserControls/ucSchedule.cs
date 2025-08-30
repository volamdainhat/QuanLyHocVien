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
            LoadData();

            // Hook cell click for autofill
            dgvRead.CellClick += dgvRead_CellClick;
        }

        private void LoadClasses()
        {
            Debug.WriteLine("Loading classes from database...");

            // Explicitly load from DB
            _context.Classes.Load();  // <-- EF Core will fill Local

            var classes = _context.Classes.Local.ToBindingList();

            cbClassName.DataSource = classes;
            cbClassName.DisplayMember = "Name";
            cbClassName.ValueMember = "Id";

            Debug.WriteLine($"Loaded {classes.Count} classes.");
        }

        private void LoadPeriods()
        {
            Debug.WriteLine("Loading predefined periods...");
            cbPeriod.Items.AddRange(new string[] { "Sáng", "Chiều" });
            Debug.WriteLine("Periods loaded: Sáng, Chiều");
        }

        private void LoadData()
        {
            Debug.WriteLine("Loading all schedules...");

            var schedules = _context.Schedules
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

            Debug.WriteLine($"Loaded {schedules.Count} schedules total.");
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

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("AddSubject button clicked.");

            if (cbClassName.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                Debug.WriteLine("No class selected! Aborting.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên môn học.");
                Debug.WriteLine("No subject name entered! Aborting.");
                return;
            }

            var selectedClass = (Class)cbClassName.SelectedItem;
            Debug.WriteLine($"Selected class: {selectedClass.Name} (Id={selectedClass.Id})");

            var subjectName = txtSubjectName.Text.Trim();
            var subject = _context.Subjects.FirstOrDefault(s => s.Name == subjectName);
            if (subject == null)
            {
                Debug.WriteLine($"Subject '{subjectName}' not found, creating new.");
                subject = new Subject { Name = subjectName };
                _context.Subjects.Add(subject);
                _context.SaveChanges();
                Debug.WriteLine($"Subject '{subjectName}' created with Id={subject.Id}.");
            }
            else
            {
                Debug.WriteLine($"Found existing subject '{subject.Name}' (Id={subject.Id}).");
            }

            var start = dtpStartDate.Value.Date;
            var end = dtpEndDate.Value.Date;
            Debug.WriteLine($"Generating schedules from {start:d} to {end:d}.");

            var daysOfWeek = chlbDaysofWeek.CheckedItems;
            Debug.WriteLine($"Days selected: {string.Join(", ", daysOfWeek.Cast<object>())}");

            int addedCount = 0;

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
                            SubjectId = subject.Id,
                            Room = txtRoom.Text,
                            Period = cbPeriod.SelectedItem?.ToString(),
                            Date = date
                        };
                        _context.Schedules.Add(schedule);
                        addedCount++;
                        Debug.WriteLine($"Prepared schedule -> {date:d} | {subject.Name} | {cbPeriod.SelectedItem} | {txtRoom.Text}");
                    }
                }
            }

            _context.SaveChanges();
            Debug.WriteLine($"Inserted {addedCount} schedules into DB.");
            LoadData();
        }

        private void mcTimetable_DateChanged(object sender, DateRangeEventArgs e)
        {
            var selectedDate = e.Start.Date;
            Debug.WriteLine($"Calendar date selected: {selectedDate:d}");

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

            Debug.WriteLine($"Found {schedules.Count} schedules for {selectedDate:d}");
        }

        private void Reload()
        {
            Debug.WriteLine("Refreshing DataGridView...");
            LoadData();
            HideUnwantedColumns();
            Debug.WriteLine("Refresh complete.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void dgvRead_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvRead.Rows[e.RowIndex];

            // Use column indices instead of names
            txtRoom.Text = row.Cells[3].Value?.ToString();                 // Room
            cbPeriod.SelectedItem = row.Cells[4].Value?.ToString();        // Period
            dtpStartDate.Value = Convert.ToDateTime(row.Cells[5].Value);   // Date
            txtSubjectName.Text = row.Cells[2].Value?.ToString();          // SubjectName

            // Match Class in ComboBox
            var className = row.Cells[1].Value?.ToString(); // ClassName
            if (!string.IsNullOrEmpty(className))
            {
                var classItem = ((BindingList<Class>)cbClassName.DataSource)
                    .FirstOrDefault(c => c.Name == className);
                if (classItem != null)
                    cbClassName.SelectedItem = classItem;
            }

            Debug.WriteLine($"Autofilled form with Schedule Id={row.Cells[0].Value}");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvRead.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một lịch để cập nhật.");
                return;
            }

            // Use column index for Id
            int scheduleId = Convert.ToInt32(dgvRead.CurrentRow.Cells[0].Value);
            Debug.WriteLine($"Attempting update for Schedule Id={scheduleId}");

            // Include the Subject entity
            var schedule = _context.Schedules
                .Include(s => s.Subject)
                .FirstOrDefault(s => s.Id == scheduleId);

            if (schedule == null)
            {
                MessageBox.Show("Không tìm thấy lịch trong cơ sở dữ liệu.");
                return;
            }

            // Update schedule fields
            schedule.Room = txtRoom.Text;
            schedule.Period = cbPeriod.SelectedItem?.ToString();
            schedule.Date = dtpStartDate.Value.Date;

            if (cbClassName.SelectedItem is Class selectedClass)
                schedule.ClassId = selectedClass.Id;

            var newSubjectName = txtSubjectName.Text.Trim();

            if (!string.IsNullOrEmpty(newSubjectName))
            {
                // Check if another subject with the new name already exists
                var existingSubject = _context.Subjects.FirstOrDefault(s => s.Name == newSubjectName);

                if (existingSubject != null)
                {
                    // Point to existing subject
                    schedule.SubjectId = existingSubject.Id;
                }
                else
                {
                    // Create a new subject and assign it
                    var newSubject = new Subject { Name = newSubjectName };
                    _context.Subjects.Add(newSubject);
                    _context.SaveChanges(); // Save to get the Id
                    schedule.SubjectId = newSubject.Id;
                }
            }

            _context.SaveChanges();
            ClearForm();
            Debug.WriteLine("Schedule updated successfully.");
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

            int deletedCount = 0;

            foreach (DataGridViewRow row in dgvRead.SelectedRows)
            {
                int scheduleId = Convert.ToInt32(row.Cells[0].Value); // use column index
                var schedule = _context.Schedules.FirstOrDefault(s => s.Id == scheduleId);
                if (schedule != null)
                {
                    _context.Schedules.Remove(schedule);
                    deletedCount++;
                    Debug.WriteLine($"Deleted Schedule Id={scheduleId}");
                }
            }

            _context.SaveChanges();
            Debug.WriteLine($"Deleted {deletedCount} schedules.");
            LoadData();
        }

        // Helpers
        private void ClearForm()
        {
            txtRoom.Clear();
            txtSubjectName.Clear();
            cbPeriod.SelectedIndex = -1;
            cbClassName.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            // Uncheck all days
            for (int i = 0; i < chlbDaysofWeek.Items.Count; i++)
                chlbDaysofWeek.SetItemChecked(i, false);
        }

        private void RenameColumns()
        {
            if (dgvRead.Columns.Contains("ClassName"))
                dgvRead.Columns["ClassName"].HeaderText = "Lớp";

            if (dgvRead.Columns.Contains("SubjectName"))
                dgvRead.Columns["SubjectName"].HeaderText = "Môn";

            if (dgvRead.Columns.Contains("Date"))
                dgvRead.Columns["Date"].HeaderText = "Ngày học";

            if (dgvRead.Columns.Contains("Room"))
                dgvRead.Columns["Room"].HeaderText = "Phòng";

            if (dgvRead.Columns.Contains("Period"))
                dgvRead.Columns["Period"].HeaderText = "Ca học";
        }


    }
}
