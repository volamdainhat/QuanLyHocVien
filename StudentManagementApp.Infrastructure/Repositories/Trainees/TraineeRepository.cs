using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories.Trainees
{
    public class TraineeRepository : Repository<Trainee>, ITraineeRepository
    {
        public TraineeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TraineeViewModel>> GetTraineesWithClassAsync()
        {
            return await _context.Trainees
                .Include(c => c.Class)
                .Select(c => new TraineeViewModel
                {
                    Id = c.Id,
                    PlaceOfOrigin = c.PlaceOfOrigin,
                    PlaceOfPermanentResidence = c.PlaceOfPermanentResidence,
                    AddressForCorrespondence = c.AddressForCorrespondence,
                    ClassName = c.Class != null ? c.Class.Name : "",
                    DayOfBirth = c.DayOfBirth,
                    EducationalLevel = c.EducationalLevel,
                    EnlistmentDate = c.EnlistmentDate,
                    Ethnicity = c.Ethnicity,
                    FatherFullName = c.FatherFullName,
                    FatherPhoneNumber = c.FatherPhoneNumber,
                    MotherFullName = c.MotherFullName,
                    MotherPhoneNumber = c.MotherPhoneNumber,
                    FullName = c.FullName,
                    Gender = c.Gender,
                    HealthStatus = c.HealthStatus,
                    MeritScore = c.MeritScore,
                    MilitaryRank = c.MilitaryRank,
                    PhoneNumber = c.PhoneNumber,
                    ProvinceOfEnlistment = c.ProvinceOfEnlistment,
                    Role = c.Role,
                    IdentityCard = c.IdentityCard,
                    IsActive = c.IsActive,
                    AverageScore = c.AverageScore,
                    AvatarUrl = c.AvatarUrl,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<Trainee> GetTraineeWithDetailsAsync(int id)
        {
            return await _context.Trainees
                .Include(c => c.Class)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
