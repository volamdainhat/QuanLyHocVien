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
            return await (from trainee in _context.Trainees
                          join classEntity in _context.Classes on trainee.ClassId equals classEntity.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          join province in _context.Categories on
                              new { Code = trainee.ProvinceOfEnlistment, Type = "Provinces" }
                              equals new { Code = province.Code, Type = province.Type } into provinceJoin
                          from provinceObj in provinceJoin.DefaultIfEmpty()
                          join education in _context.Categories on
                              new { Code = trainee.EducationalLevel, Type = "EducationLevel" }
                              equals new { Code = education.Code, Type = education.Type } into educationJoin
                          from educationObj in educationJoin.DefaultIfEmpty()
                          join militaryRank in _context.Categories on
                              new { Code = trainee.MilitaryRank, Type = "MilitaryRank" }
                              equals new { Code = militaryRank.Code, Type = militaryRank.Type } into rankJoin
                          from rankObj in rankJoin.DefaultIfEmpty()
                          join role in _context.Categories on
                              new { Code = trainee.Role, Type = "Role" }
                              equals new { Code = role.Code, Type = role.Type } into roleJoin
                          from roleObj in roleJoin.DefaultIfEmpty()
                          select new TraineeViewModel
                          {
                              Id = trainee.Id,
                              PlaceOfOrigin = trainee.PlaceOfOrigin,
                              PlaceOfPermanentResidence = trainee.PlaceOfPermanentResidence,
                              AddressForCorrespondence = trainee.AddressForCorrespondence,
                              ClassName = classObj != null ? classObj.Name : "", // Sửa thành classObj
                              DayOfBirth = trainee.DayOfBirth,
                              EducationalLevel = educationObj != null ? educationObj.Name : "",
                              EnlistmentDate = trainee.EnlistmentDate,
                              Ethnicity = trainee.Ethnicity,
                              FatherFullName = trainee.FatherFullName,
                              FatherPhoneNumber = trainee.FatherPhoneNumber,
                              MotherFullName = trainee.MotherFullName,
                              MotherPhoneNumber = trainee.MotherPhoneNumber,
                              FullName = trainee.FullName,
                              Gender = trainee.Gender,
                              HealthStatus = trainee.HealthStatus,
                              MeritScore = trainee.MeritScore,
                              MilitaryRank = rankObj != null ? rankObj.Name : "",
                              PhoneNumber = trainee.PhoneNumber,
                              ProvinceOfEnlistment = provinceObj != null ? provinceObj.Name : "", // Hiển thị tên thay vì code
                              Role = roleObj != null ? roleObj.Name : "",
                              IdentityCard = trainee.IdentityCard,
                              IsActive = trainee.IsActive,
                              AverageScore = trainee.AverageScore,
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
    }
}
