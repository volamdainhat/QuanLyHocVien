using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class RollCallRepository : Repository<RollCall>, IRollCallRepository
    {
        public RollCallRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<RollCall>> GetRollCallFromDateToDateAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.RollCalls.Where(r => r.Date >= fromDate && r.Date <= toDate && r.IsActive).ToListAsync();
        }
    }
}
