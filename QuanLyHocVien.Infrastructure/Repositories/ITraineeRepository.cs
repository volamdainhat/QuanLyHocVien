using QuanLyHocVien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Infrastructure.Repositories
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        Task<IEnumerable<Trainee>> SearchAsync(string keyword, int classId);
    }
}
