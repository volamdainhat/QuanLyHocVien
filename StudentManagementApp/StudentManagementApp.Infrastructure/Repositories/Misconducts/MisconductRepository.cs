using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Misconducts;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories.Misconducts
{
    public class MisconductRepository : Repository<Misconduct>, IMisconductRepository
    {
        public MisconductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MisconductViewModel>> GetMisconductsWithTraineeAsync()
        {
            return await (from misconduct in _context.Misconducts
                          join trainee in _context.Trainees on misconduct.TraineeId equals trainee.Id into traineeJoin
                          from traineeObj in traineeJoin.DefaultIfEmpty()
                          join category in _context.Categories on
                              new { Code = misconduct.Type, Type = "MisconductType" }
                              equals new { Code = category.Code, Type = category.Type } into categoryJoin
                          from misconductTypeObj in categoryJoin.DefaultIfEmpty()
                          select new MisconductViewModel
                          {
                              Id = misconduct.Id,
                              TraineeName = traineeObj != null ? traineeObj.FullName : "",
                              Type = misconductTypeObj != null ? misconductTypeObj.Name : "",
                              Time = misconduct.Time,
                              Description = misconduct.Description,
                              IsActive = misconduct.IsActive,
                              CreatedDate = misconduct.CreatedDate,
                              ModifiedDate = misconduct.ModifiedDate
                          }).ToListAsync();
        }

        public async Task<Misconduct> GetMisconductWithDetailsAsync(int id)
        {
            return await _context.Misconducts
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
