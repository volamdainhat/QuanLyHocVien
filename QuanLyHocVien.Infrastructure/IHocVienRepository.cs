using QuanLyHocVien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Infrastructure
{
    internal interface IHocVienRepository
    {
        IEnumerable<Trainee> GetAll();
        Trainee GetById(int studentId);
        void Add(Trainee trainee);
        void Update(Trainee trainee);
        void Delete(int studentId);
        void Save();  // lưu thay đổi xuống DB
    }
}
