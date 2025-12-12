using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Classes;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClassViewModel>> GetClassesWithSchoolYearAsync()
        {
            return await _context.Classes
                .Select(c => new ClassViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    TotalStudents = c.TotalStudents,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<Class> GetClassWithDetailsAsync(int id)
        {
            return await _context.Classes
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateTotalStudentsAsync(int id)
        {
            var totalStudents = await _context.Trainees.CountAsync(s => s.ClassId == id);
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity != null)
            {
                classEntity.TotalStudents = totalStudents;
                _context.Classes.Update(classEntity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTotalStudentsForAllClassAsync()
        {
            var classes = await _context.Classes.ToListAsync();
            foreach (var classEntity in classes)
            {
                var totalStudents = await _context.Trainees.CountAsync(s => s.ClassId == classEntity.Id);
                classEntity.TotalStudents = totalStudents;
            }
            _context.Classes.UpdateRange(classes);
            await _context.SaveChangesAsync();
        }
    }
}
