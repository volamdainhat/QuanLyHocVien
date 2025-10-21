using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await _context.Subjects.AnyAsync(s => s.Code == code);
        }
    }
}
