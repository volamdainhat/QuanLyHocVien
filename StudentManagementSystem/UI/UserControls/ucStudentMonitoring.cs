using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucStudentMonitoring : UserControl
    {
        public ucStudentMonitoring()
        {
            InitializeComponent();
        }
    }


//    public partial class ucStudentMonitoring : UserControl
//    {
//        private readonly AppDbContext _context;

//        public ucStudentMonitoring()
//        {
//            InitializeComponent();
//            _context = new AppDbContext();
//            LoadMonitoringData();
//            LoadSubjects();
//        }

//        private void LoadMonitoringData()
//        {
//            var trainees = _context.Trainees
//                .Include(t => t.Grades)
//                .Include(t => t.Misconducts)
//                .ToList();

//            var summaries = trainees.Select(t => new TraineeMonitoringSummary
//            {
//                TraineeId = t.Id,
//                FullName = t.FullName ?? "Không rõ",
//                ClassName = t.ClassName,
//                AverageGrade = t.Grades.Any() ? Math.Round(t.Grades.Average(g => g.Grade), 2) : 0,
//                MisconductCount = t.Misconducts.Count,
//                Status = GetTraineeStatus(
//                    t.Grades.Any() ? t.Grades.Average(g => g.Grade) : 0,
//                    t.Misconducts.Count
//                )
//            }).ToList();

//            dgvRead.DataSource = summaries;
//        }

//        private void LoadSubjects()
//        {
//            cbSubject.DataSource = _context.Subjects.ToList();
//            cbSubject.DisplayMember = "Name";
//            cbSubject.ValueMember = "Id";

//            cbGradeType.Items.Clear();
//            cbGradeType.Items.AddRange(new[] { "Thi", "Kiểm tra", "Bài tập" });
//        }

//        private string GetTraineeStatus(double avgGrade, int misconducts)
//        {
//            if (misconducts == 0 && avgGrade >= 8.5) return "Xuất sắc";
//            if (misconducts <= 2 && avgGrade >= 6.5) return "Đạt";
//            if (avgGrade < 5 || misconducts > 3) return "Cảnh cáo";
//            return "Cần cải thiện";
//        }

//        // -------------------------------
//        // ADD MISCONDUCT
//        // -------------------------------
//        private void btnAddMisconduct_Click(object sender, EventArgs e)
//        {
//            if (dgvRead.CurrentRow == null) return;
//            int traineeId = (int)dgvRead.CurrentRow.Cells["TraineeId"].Value;

//            var misconduct = new Misconduct
//            {
//                TraineeId = traineeId,
//                Type = txtMisconductType.Text,
//                Time = dtpMisconductTime.Value,
//                Description = txtMisconductDesc.Text
//            };

//            _context.Misconducts.Add(misconduct);
//            _context.SaveChanges();
//            LoadMonitoringData();

//            MessageBox.Show("Đã thêm vi phạm.");
//        }

//        // -------------------------------
//        // ADD GRADE
//        // -------------------------------
//        private void btnAddGrade_Click(object sender, EventArgs e)
//        {
//            if (dgvRead.CurrentRow == null) return;
//            int traineeId = (int)dgvRead.CurrentRow.Cells["TraineeId"].Value;

//            var grade = new Grades
//            {
//                TraineeId = traineeId,
//                SubjectId = (int)cbSubject.SelectedValue,
//                SubjectName = cbSubject.Text,
//                Type = cbGradeType.Text,
//                Grade = (float)numGrade.Value
//            };

//            _context.Grades.Add(grade);
//            _context.SaveChanges();
//            LoadMonitoringData();

//            MessageBox.Show("Đã thêm điểm.");
//        }

//        // -------------------------------
//        // EDIT TRAINEE
//        // -------------------------------
//        private void btnUpdateTrainee_Click(object sender, EventArgs e)
//        {
//            if (dgvRead.CurrentRow == null) return;
//            int traineeId = (int)dgvRead.CurrentRow.Cells["TraineeId"].Value;

//            var trainee = _context.Trainees.Find(traineeId);
//            if (trainee == null) return;

//            trainee.FullName = txtTraineeName.Text;
//            trainee.PhoneNumber = txtTraineePhone.Text;
//            trainee.Role = txtTraineeRole.Text;

//            _context.SaveChanges();
//            LoadMonitoringData();

//            MessageBox.Show("Cập nhật học viên thành công.");
//        }

//        // -------------------------------
//        // AUTOFILL WHEN ROW SELECTED
//        // -------------------------------
//        private void dgvRead_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (e.RowIndex < 0) return;

//            var row = dgvRead.Rows[e.RowIndex];
//            txtTraineeName.Text = row.Cells["FullName"].Value?.ToString();
//            txtTraineePhone.Text = ""; // Optional: pull actual phone if needed
//            txtTraineeRole.Text = "";
//        }
//    }

//    // =======================
//    // Summary DTO
//    // =======================
//    public class TraineeMonitoringSummary
//    {
//        public int TraineeId { get; set; }
//        public string FullName { get; set; } = string.Empty;
//        public string? ClassName { get; set; }
//        public double AverageGrade { get; set; }
//        public int MisconductCount { get; set; }
//        public string Status { get; set; } = "Chưa xác định";
//    }
}
