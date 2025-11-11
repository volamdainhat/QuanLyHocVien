using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Trainees;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class TraineeRepository : Repository<Trainee>, ITraineeRepository
    {
        public TraineeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TraineeViewModel>> GetTraineesWithClassAsync()
        {
            return await (from trainee in _context.Trainees
                          join classEntity in _context.Classes on trainee.ClassId equals classEntity.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          select new TraineeViewModel
                          {
                              Id = trainee.Id,
                              PlaceOfOrigin = trainee.PlaceOfOrigin,
                              PlaceOfPermanentResidence = trainee.PlaceOfPermanentResidence,
                              AddressForCorrespondence = trainee.AddressForCorrespondence,
                              ClassId = trainee.ClassId,
                              ClassName = classObj != null ? classObj.Name : "",
                              DayOfBirth = trainee.DayOfBirth,
                              EducationalLevel = trainee.EducationalLevel,
                              EnlistmentDate = trainee.EnlistmentDate,
                              Ethnicity = trainee.Ethnicity,
                              FatherFullName = trainee.FatherFullName,
                              FatherPhoneNumber = trainee.FatherPhoneNumber,
                              MotherFullName = trainee.MotherFullName,
                              MotherPhoneNumber = trainee.MotherPhoneNumber,
                              FullName = trainee.FullName,
                              Gender = trainee.Gender,
                              HealthStatus = trainee.HealthStatus,
                              MilitaryRank = trainee.MilitaryRank,
                              PhoneNumber = trainee.PhoneNumber,
                              ProvinceOfEnlistment = trainee.ProvinceOfEnlistment,
                              Role = trainee.Role,
                              IdentityCard = trainee.IdentityCard,
                              IsActive = trainee.IsActive,
                              AvatarUrl = trainee.AvatarUrl,
                              CreatedDate = trainee.CreatedDate,
                              ModifiedDate = trainee.ModifiedDate
                          })
            .ToListAsync();
        }

        public async Task<Trainee> GetTraineeWithDetailsAsync(int id)
        {
            return await _context.Trainees
                .Include(c => c.Class)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<int> GetTotalTraineeAsync()
        {
            return await _context.Trainees.CountAsync();
        }

        public async Task<List<TraineeByClassModel>> GetTotalTraineeByClassAsync()
        {
            return await _context.Trainees
                .Include(c => c.Class)
                .GroupBy(t => new { t.ClassId, ClassName = t.Class != null ? t.Class.Name : "Chưa cập nhật" })
                .Select(g => new TraineeByClassModel
                {
                    ClassName = g.Key.ClassName,
                    CountTrainee = g.Count()
                })
                .ToListAsync();
        }

        public async Task<List<Trainee>> GetTraineesActiveAsync()
        {
            return await _context.Trainees.Where(r => r.IsActive == true).ToListAsync();
        }
    }
}
