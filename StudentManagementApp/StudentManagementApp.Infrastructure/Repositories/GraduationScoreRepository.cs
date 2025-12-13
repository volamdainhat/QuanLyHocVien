using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.GraduationScores;
using StudentManagementApp.Infrastructure.Data;
using System.Globalization;
using System.Linq.Expressions;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class GraduationScoreRepository : Repository<GraduationScore>, IGraduationScoreRepository
    {
        public GraduationScoreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GraduationScoreViewModel>> GetGraduationScoreWithTraineeAsync()
        {
            return await _context.GraduationScores
                .Include(c => c.Trainee).ThenInclude(c => c.Class)
                .Select(c => new GraduationScoreViewModel
                {
                    Id = c.Id,
                    TraineeName = c.Trainee != null ? c.Trainee.FullName : string.Empty,
                    ClassName = c.Trainee.Class != null ? c.Trainee.Class.Name : string.Empty,
                    Score = c.Score,
                    GraduationType = c.GraduationType,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<GraduationScore> GetGraduationScoreWithDetailsAsync(int id)
        {
            return await _context.GraduationScores
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateTraineeGraduationScoreAsync(int traineeId)
        {
            // Lấy điểm trung bình chung của học viên
            var traineeAverageScore = await _context.TraineeAverageScores
                .Where(sa => sa.TraineeId == traineeId)
                .FirstOrDefaultAsync();

            if (traineeAverageScore == null)
            {
                return; // Không có điểm trung bình, không cần cập nhật
            }

            // Lấy danh sách điểm thi tốt nghiệp của học viên
            var graduationExamScores = await _context.GraduationExamScores
                .Where(g => g.TraineeId == traineeId)
                .ToListAsync();

            if (graduationExamScores.Count == 0)
            {
                var graduationScoreExists = await _context.GraduationScores.FirstOrDefaultAsync(gs => gs.TraineeId == traineeId);

                if (graduationScoreExists != null)
                {
                    _context.GraduationScores.Remove(graduationScoreExists);
                    await _context.SaveChangesAsync();
                }

                return; // Không có điểm, không cần cập nhật
            }

            // Tính điểm trung bình theo trọng số của 1 học viên cho 1 môn học cụ thể
            decimal graduationScore = CalculateGraduationScore(traineeAverageScore.AverageScore, graduationExamScores);

            // Tính xếp loại học lực dựa trên điểm trung bình
            string graduationType = CalculateGraduationType(graduationScore);

            var traineeGraduationScore = await _context.GraduationScores.FirstOrDefaultAsync(gs => gs.TraineeId == traineeId);

            if (traineeGraduationScore != null)
            {
                traineeGraduationScore.Score = Math.Round(graduationScore, 2); // Làm tròn đến 2 chữ số thập phân
                traineeGraduationScore.GraduationType = graduationType;
                traineeGraduationScore.ModifiedDate = DateTime.Now;
                _context.GraduationScores.Update(traineeGraduationScore);
                _context.SaveChanges();
            }
            else
            {
                traineeGraduationScore = new GraduationScore
                {
                    TraineeId = traineeId,
                    Score = Math.Round(graduationScore, 2), // Làm tròn đến 2 chữ số thập phân
                    GraduationType = graduationType,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                };
                await _context.GraduationScores.AddAsync(traineeGraduationScore);
                await _context.SaveChangesAsync();
            }
        }

        public static decimal CalculateGraduationScore(decimal traineeAverageScore, List<GraduationExamScore> graduationExamScores)
        {
            if (graduationExamScores == null || !graduationExamScores.Any())
                return 0;

            // Lấy từng loại điểm thi
            decimal practice = graduationExamScores.Where(g => g.GraduationExamType == "thuc_hanh")
                                  .Select(g => g.Score)
                                  .DefaultIfEmpty(0)
                                  .Average();

            decimal theory = graduationExamScores.Where(g => g.GraduationExamType == "ly_thuyet")
                                 .Select(g => g.Score)
                                 .DefaultIfEmpty(0)
                                 .Average();

            decimal politics = graduationExamScores.Where(g => g.GraduationExamType == "chinh_tri")
                                  .Select(g => g.Score)
                                  .DefaultIfEmpty(0)
                                  .Average();

            decimal military = graduationExamScores.Where(g => g.GraduationExamType == "quan_su")
                                  .Select(g => g.Score)
                                  .DefaultIfEmpty(0)
                                  .Average();

            // Đtn = ( 3 x Đtb + 2 x Đtnth + Đtnlt + Đtnct + Đqsc) / 8
            decimal score = (traineeAverageScore * 3 + practice * 2 + theory + politics + military) / 8;

            return score;
        }

        private static string CalculateGraduationType(decimal score)
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
