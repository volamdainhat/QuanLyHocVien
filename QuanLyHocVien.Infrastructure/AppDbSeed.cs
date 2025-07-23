using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure
{
    public static class AppDbSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee
                {
                    Id = 1,
                    FullName = "Nguyễn Văn A",
                    ClassId = 1,
                    Ranking = "Giỏi",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 2,
                    FullName = "Trần Thị B",
                    ClassId = 1,
                    Ranking = "Khá",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                }
            );

            // Bạn có thể thêm seed cho các entity khác tại đây...
        }
    }
}
