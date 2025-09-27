using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.TraineeAverageScores;
using StudentManagementApp.Infrastructure.Data;
using StudentManagementApp.Infrastructure.Repositories.TraineeAverageScores;

namespace StudentManagementApp.Infrastructure.Repositories.SubjectAverages
{
    public class TraineeAverageScoreRepository : Repository<TraineeAverageScore>, ITraineeAverageScoreRepository
    {
        public TraineeAverageScoreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TraineeAverageScoreViewModel>> GetTraineeAverageScoreWithTraineeSemesterAsync()
        {
            return await _context.TraineeAverageScores
                .Include(c => c.Trainee)
                .Include(c => c.Semester)
                .Select(c => new TraineeAverageScoreViewModel
                {
                    Id = c.Id,
                    TraineeName = c.Trainee != null ? c.Trainee.FullName : string.Empty,
                    SemesterName = c.Semester != null ? c.Semester.Name : string.Empty,
                    AverageScore = c.AverageScore,
                    GradeType = c.GradeType,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<TraineeAverageScore> GetTraineeAverageScoreWithDetailsAsync(int id)
        {
            return await _context.TraineeAverageScores
                .Include(c => c.Trainee)
                .Include(c => c.Semester)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateTraineeAverageScoreAsync(int traineeId, int semesterId)
        {
            // Lấy danh sách SubjectId từ grades của học kỳ cụ thể
            var gradeSubjectIds = await _context.Grades
                .Where(g => g.SemesterId == semesterId && g.TraineeId == traineeId)
                .Select(g => g.SubjectId)
                .Distinct()
                .ToListAsync();

            // Lấy SubjectAverages chỉ cho những môn có trong grades
            var subjectAverages = await _context.SubjectAverages
                .Where(sa => sa.TraineeId == traineeId && gradeSubjectIds.Contains(sa.SubjectId))
                .ToListAsync();

            if (subjectAverages.Count == 0)
            {
                var traineeAverageScoreExists = await _context.TraineeAverageScores.FirstOrDefaultAsync(sa => sa.SemesterId == semesterId && sa.TraineeId == traineeId);

                if (traineeAverageScoreExists != null)
                {
                    _context.TraineeAverageScores.Remove(traineeAverageScoreExists);
                    await _context.SaveChangesAsync();
                }

                return; // Không có điểm, không cần cập nhật
            }

            // Tính điểm trung bình từ SubjectAverages
            decimal averageScore = subjectAverages.Average(sa => sa.Score);

            // Tính xếp loại
            string gradeType = CalculateGradeType(averageScore);

            var traineeAverageScore = await _context.TraineeAverageScores.FirstOrDefaultAsync(sa => sa.SemesterId == semesterId && sa.TraineeId == traineeId);

            if (traineeAverageScore != null)
            {
                traineeAverageScore.AverageScore = Math.Round(averageScore, 2); // Làm tròn đến 2 chữ số thập phân
                traineeAverageScore.GradeType = gradeType;
                _context.TraineeAverageScores.Update(traineeAverageScore);
                _context.SaveChanges();
            }
            else
            {
                traineeAverageScore = new TraineeAverageScore
                {
                    TraineeId = traineeId,
                    SemesterId = semesterId,
                    AverageScore = Math.Round(averageScore, 2), // Làm tròn đến 2 chữ số thập phân
                    GradeType = gradeType,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                await _context.TraineeAverageScores.AddAsync(traineeAverageScore);
                await _context.SaveChangesAsync();
            }
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
