using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.UserRepo
{
    public class UserRepository: Repository<UserInfo>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
