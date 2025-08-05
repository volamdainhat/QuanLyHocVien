using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.UserRepo
{
    public class UserRepository : Repository<UserInfo>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
