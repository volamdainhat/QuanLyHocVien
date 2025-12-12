using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.WeeklyCritiques;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class WeeklyCritiqueRepository : Repository<WeeklyCritique>, IWeeklyCritiqueRepository
    {
        public WeeklyCritiqueRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WeeklyCritiqueViewModel>> GetWeeklyCritiqueWithTraineeAsync()
        {
            return await _context.WeeklyCritiques
                .Include(c => c.Trainee).ThenInclude(c => c.Class)
                .Select(c => new WeeklyCritiqueViewModel
                {
                    Id = c.Id,
                    TraineeName = c.Trainee != null ? c.Trainee.FullName : "",
                    ClassName = c.Trainee.Class != null ? c.Trainee.Class.Name : "",
                    PoliticalAttitude = c.PoliticalAttitude,
                    PAScore = c.PAScore,
                    StudyMotivation = c.StudyMotivation,
                    SMScore = c.SMScore,
                    EthicsLifestyle = c.EthicsLifestyle,
                    ELScore = c.ELScore,
                    DisciplineAwareness = c.DisciplineAwareness,
                    DAScore = c.DAScore,
                    AcademicResult = c.AcademicResult,
                    ARScore = c.ARScore,
                    ResearchActivity = c.ResearchActivity,
                    RAScore = c.RAScore,
                    FinalScore = c.FinalScore,
                    WeekDate = c.WeekDate,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<WeeklyCritique> GetWeeklyCritiqueWithDetailsAsync(int id)
        {
            return await _context.WeeklyCritiques
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
