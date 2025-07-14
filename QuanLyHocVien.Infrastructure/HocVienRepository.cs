using QuanLyHocVien.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyHocVien.Infrastructure
{
    internal class HocVienRepository : IHocVienRepository
    {
        private readonly AppDbContext _context;

        public HocVienRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Trainee> GetAll()
        {
            return _context.HocVien.ToList();
        }

        public Trainee GetById(int studentId)
        {
            return _context.HocVien.FirstOrDefault(t => t.StudentID == studentId);
        }

        public void Add(Trainee trainee)
        {
            _context.HocVien.Add(trainee);
        }

        public void Update(Trainee trainee)
        {
            _context.HocVien.Update(trainee);
        }

        public void Delete(int studentId)
        {
            var trainee = GetById(studentId);
            if (trainee != null)
            {
                _context.HocVien.Remove(trainee);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
