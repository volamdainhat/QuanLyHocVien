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
            // Lấy điểm của 1 học viên cho 1 môn học cụ thể
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

            // Lấy điểm của 1 học viên cho 1 môn học cụ thể
            decimal averageScore = CalculateAverageScore(grades);

            // Tính xếp loại
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

        public static decimal CalculateAverageScore(List<Grades> grades)
        {
            // Trọng số cho từng loại điểm
            // (Kt_15p: x 1 + kt_1t x 2) / 3 * 0.4 + (Thi x 1) * 0.6
            var weights = new Dictionary<string, decimal>
            {
                { "kt_15p", 0.2m }, // Kiểm tra 15 phút: 20% - Hệ số 1
                { "kt_1t", 0.3m },  // Kiểm tra 1 tiết: 30% - Hệ số 2
                { "thi", 0.5m }     // Thi cuối kỳ: 50% - 
            };

            // Kiểm tra nếu không có điểm
            if (grades == null || !grades.Any())
                return 0;

            decimal total = 0;
            decimal totalWeight = 0;

            // Gom nhóm theo loại điểm
            var byType = grades.GroupBy(g => g.ExamType);
            foreach (var typeGroup in byType)
            {
                var type = typeGroup.Key;
                // Tính điểm trung bình cho loại điểm này
                var avg = typeGroup.Average(g => (decimal)g.Grade);

                if (weights.ContainsKey(type))
                {
                    total += avg * weights[type];
                    totalWeight += weights[type];
                }
            }

            // Nếu thiếu loại điểm thì scale theo trọng số thực có
            return totalWeight > 0 ? total / totalWeight : 0;
        }

        private static string CalculateGradeType(decimal score)
        {
            // Logic xếp loại dựa trên điểm số decimal
            if (score >= 8.5m) return "Giỏi";
            else if (score >= 7.0m) return "Khá";
            else if (score >= 5.5m) return "Trung bình";
            else if (score >= 4.0m) return "Yếu";
            else return "Kém";
        }
    }
}
