using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.GraduationExamScores;
using StudentManagementApp.Infrastructure.Data;
using StudentManagementApp.Infrastructure.Repositories.GraduationExamScores;

namespace StudentManagementApp.Infrastructure.Repositories.SubjectAverages
{
    public class GraduationExamScoreRepository : Repository<GraduationExamScore>, IGraduationExamScoreRepository
    {
        public GraduationExamScoreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GraduationExamScoreViewModel>> GetGraduationExamScoreWithTraineeAsync()
        {
            return await _context.GraduationExamScores
                .Include(c => c.Trainee)
                .Select(c => new GraduationExamScoreViewModel
                {
                    Id = c.Id,
                    TraineeName = c.Trainee != null ? c.Trainee.FullName : string.Empty,
                    Score = c.Score,
                    GradeType = c.GradeType,
                    GraduationExamType = c.GraduationExamType,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<GraduationExamScore> GetGraduationExamScoreWithDetailsAsync(int id)
        {
            return await _context.GraduationExamScores
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
