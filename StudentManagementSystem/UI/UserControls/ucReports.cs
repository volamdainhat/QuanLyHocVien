using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem.UI.UserControls
{
    public partial class ucReports : UserControl
    {
        private readonly AppDbContext _context = new AppDbContext();

        public ucReports()
        {
            InitializeComponent();
            LoadReports();
            LoadClasses();
            RenameColumns();

            dgvReports.CellClick += dgvReports_CellClick;
            btnGenerate.Click += (s, e) => GenerateReport();
            btnDelete.Click += (s, e) => DeleteReport();
            btnRefresh.Click += (s, e) => LoadReports();
        }

        private void RenameColumns()
        {
            if (dgvReports.Columns.Contains("ClassName"))
                dgvReports.Columns["ClassName"].HeaderText = "Lớp";
            if (dgvReports.Columns.Contains("ReportDate"))
                dgvReports.Columns["ReportDate"].HeaderText = "Báo cáo ngày";
            if (dgvReports.Columns.Contains("MisconductCount"))
                dgvReports.Columns["MisconductCount"].HeaderText = "Tổng vi phạm";
            if (dgvReports.Columns.Contains("TotalStudents"))
                dgvReports.Columns["TotalStudents"].HeaderText = "Tổng số học viên";
            if (dgvReports.Columns.Contains("TotalAbsences"))
                dgvReports.Columns["TotalAbsences"].HeaderText = "Tổng số vắng";
            if (dgvReports.Columns.Contains("AverageScore"))
                dgvReports.Columns["AverageScore"].HeaderText = "Điểm trung bình lớp";
        }

        private void LoadClasses()
        {
            _context.Classes.Load();
            var classes = _context.Classes.Local.ToBindingList();

            comboBoxClass.DataSource = classes;
            comboBoxClass.DisplayMember = "Name";
            comboBoxClass.ValueMember = "Id";
        }

        private void LoadReports()
        {
            var reports = _context.Reports
                .Include(r => r.Class)
                .OrderByDescending(r => r.ReportDate)
                .Select(r => new
                {
                    r.Id,
                    ClassName = r.Class.Name,
                    r.MisconductCount,
                    r.TotalStudents,
                    r.TotalAbsences,
                    r.AverageScore,
                    r.ReportDate
                })
                .ToList();

            dgvReports.DataSource = reports;
        }

        private void GenerateReport()
        {
            if (comboBoxClass.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn lớp để tạo báo cáo.");
                return;
            }

            int classId = (int)comboBoxClass.SelectedValue;

            // 📅 Get range
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);
            // include the entire end day

            // 🧮 Misconducts only within range
            int misconductCount = _context.Misconducts
                .Count(m => m.Trainee.ClassId == classId
                         && m.Time >= startDate && m.Time <= endDate);

            // 👥 Students are all-time
            int totalStudents = _context.Trainees
                .Count(t => t.ClassId == classId);

            // 📌 Absences also bounded by range
            int totalAbsences = _context.Misconducts
                .Count(m => m.Trainee.ClassId == classId
                         && m.Type.ToLower() == "vắng"
                         && m.Time >= startDate && m.Time <= endDate);

            // 🎓 Average score is all-time
            float averageScore = 0;
            var grades = _context.Grades
                .Where(g => g.Trainee.ClassId == classId)
                .ToList();

            if (grades.Any())
                averageScore = grades.Average(g => g.Grade);

            // 📝 Save report
            var report = new Reports
            {
                ClassId = classId,
                MisconductCount = misconductCount,
                TotalStudents = totalStudents,
                TotalAbsences = totalAbsences,
                AverageScore = averageScore,
                ReportDate = DateTime.Now
            };

            _context.Reports.Add(report);
            _context.SaveChanges();

            LoadReports();
            MessageBox.Show("Báo cáo đã được tạo thành công!");
        }



        private void DeleteReport()
        {
            if (dgvReports.CurrentRow == null) return;

            int reportId = Convert.ToInt32(dgvReports.CurrentRow.Cells["Id"].Value);
            var report = _context.Reports.FirstOrDefault(r => r.Id == reportId);

            if (report == null) return;

            _context.Reports.Remove(report);
            _context.SaveChanges();

            LoadReports();
            MessageBox.Show("Đã xóa báo cáo.");
        }

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvReports.Rows[e.RowIndex];
            comboBoxClass.Text = row.Cells["ClassName"].Value?.ToString();
        }
    }
}
