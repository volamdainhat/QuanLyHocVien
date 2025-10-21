using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.GraduationExamScores;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class GraduationExamScoreRepository : Repository<GraduationExamScore>, IGraduationExamScoreRepository
    {
        public GraduationExamScoreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GraduationExamScoreViewModel>> GetGraduationExamScoreWithTraineeAsync()
        {
            return await (from score in _context.GraduationExamScores
                          join traineeEntity in _context.Trainees on score.TraineeId equals traineeEntity.Id into traineeJoin
                          from traineeObj in traineeJoin.DefaultIfEmpty()
                          join examType in _context.Categories on
                              new { Code = score.GraduationExamType, Type = "GraduationExamType" }
                              equals new { examType.Code, examType.Type } into examTypeJoin
                          from examTypeObj in examTypeJoin.DefaultIfEmpty()
                          select new GraduationExamScoreViewModel
                          {
                              Id = score.Id,
                              TraineeName = traineeObj != null ? traineeObj.FullName : string.Empty,
                              Score = score.Score,
                              GradeType = score.GradeType,
                              GraduationExamType = score.GraduationExamType,
                              GraduationExamTypeName = examTypeObj != null ? examTypeObj.Name : string.Empty,
                              IsActive = score.IsActive,
                              CreatedDate = score.CreatedDate,
                              ModifiedDate = score.ModifiedDate
                          }).ToListAsync();
        }

        public async Task<GraduationExamScore> GetGraduationExamScoreWithDetailsAsync(int id)
        {
            return await _context.GraduationExamScores
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
