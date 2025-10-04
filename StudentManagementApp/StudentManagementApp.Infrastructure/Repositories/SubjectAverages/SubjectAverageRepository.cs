using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories.SubjectAverages
{
    public class SubjectAverageRepository : Repository<SubjectAverage>, ISubjectAverageRepository
    {
        public SubjectAverageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SubjectAverageViewModel>> GetSubjectAverageWithSubjectTraineeAsync()
        {
            return await _context.SubjectAverages
                .Include(c => c.Subject)
                .Include(c => c.Trainee)
                .Select(c => new SubjectAverageViewModel
                {
                    Id = c.Id,
                    SubjectName = c.Subject != null ? c.Subject.Name : string.Empty,
                    TraineeName = c.Trainee != null ? c.Trainee.FullName : string.Empty,
                    Score = c.Score,
                    GradeType = c.GradeType,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<SubjectAverage> GetSubjectAverageWithDetailsAsync(int id)
        {
            return await _context.SubjectAverages
                .Include(c => c.Subject)
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateTraineeSubjectAverageAsync(int subjectId, int traineeId)
        {
            // Lấy danh sách điểm thi của 1 học viên cho 1 môn học cụ thể
            var grades = await _context.Grades
                .Where(g => g.SubjectId == subjectId && g.TraineeId == traineeId)
                .ToListAsync();

            if (grades.Count == 0)
            {
                var subjectAverageExists = await _context.SubjectAverages.FirstOrDefaultAsync(sa => sa.SubjectId == subjectId && sa.TraineeId == traineeId);

                if (subjectAverageExists != null)
                {
                    _context.SubjectAverages.Remove(subjectAverageExists);
                    await _context.SaveChangesAsync();
                }

                return; // Không có điểm, không cần cập nhật
            }

            // Tính điểm trung bình theo trọng số của 1 học viên cho 1 môn học cụ thể
            decimal averageScore = CalculateAverageScore(grades);

            // Tính xếp loại học lực dựa trên điểm trung bình
            string gradeType = CalculateGradeType(averageScore);

            var subjectAverage = await _context.SubjectAverages.FirstOrDefaultAsync(sa => sa.SubjectId == subjectId && sa.TraineeId == traineeId);

            if (subjectAverage != null)
            {
                subjectAverage.Score = Math.Round(averageScore, 2); // Làm tròn đến 2 chữ số thập phân
                subjectAverage.GradeType = gradeType;
                _context.SubjectAverages.Update(subjectAverage);
                _context.SaveChanges();
            }
            else
            {
                subjectAverage = new SubjectAverage
                {
                    SubjectId = subjectId,
                    TraineeId = traineeId,
                    Score = Math.Round(averageScore, 2), // Làm tròn đến 2 chữ số thập phân
                    GradeType = gradeType,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                await _context.SubjectAverages.AddAsync(subjectAverage);
                await _context.SaveChangesAsync();
            }
        }

        // ((Kt_15p x 1 + kt_1t x 2) / 3 * 0.4) + ((Thi x 1) * 0.6)
        public static decimal CalculateAverageScore(List<Grades> grades)
        {
            if (grades == null || !grades.Any())
                return 0;

            // Tính điểm trung bình cho từng loại
            decimal avg15p = grades.Where(g => g.ExamType == "kt_15p")
                                  .Select(g => g.Grade)
                                  .DefaultIfEmpty(0)
                                  .Average();

            decimal avg1t = grades.Where(g => g.ExamType == "kt_1t")
                                 .Select(g => g.Grade)
                                 .DefaultIfEmpty(0)
                                 .Average();

            decimal avgThi = grades.Where(g => g.ExamType == "thi")
                                  .Select(g => g.Grade)
                                  .DefaultIfEmpty(0)
                                  .Average();

            decimal diemTB = ((avg15p * 1 + avg1t * 2) / 3 * 0.4m) + (avgThi * 0.6m);

            return diemTB;
        }

        private static string CalculateGradeType(decimal score)
        {
            // Logic xếp loại dựa trên điểm số decimal
            if (score >= 9.0m) return "Xuất xắc";
            else if (score >= 8.0m) return "Giỏi";
            else if (score >= 7.0m) return "Khá";
            else if (score >= 5.0m) return "Trung bình";
            else return "Yếu";
        }
    }
}
