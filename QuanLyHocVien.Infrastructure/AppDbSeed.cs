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
                    Id = 3,
                    FullName = "Lê Văn C",
                    ClassId = 1,
                    Ranking = "Khá",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 4,
                    FullName = "Phạm Thị D",
                    ClassId = 1,
                    Ranking = "Trung bình",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 5,
                    FullName = "Ngô Văn E",
                    ClassId = 2,
                    Ranking = "Giỏi",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 6,
                    FullName = "Đinh Thị F",
                    ClassId = 2,
                    Ranking = "Khá",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 7,
                    FullName = "Hoàng Văn G",
                    ClassId = 2,
                    Ranking = "Giỏi",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 8,
                    FullName = "Trịnh Thị H",
                    ClassId = 3,
                    Ranking = "Trung bình",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 9,
                    FullName = "Lý Văn I",
                    ClassId = 3,
                    Ranking = "Khá",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 10,
                    FullName = "Bùi Thị K",
                    ClassId = 3,
                    Ranking = "Giỏi",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 11,
                    FullName = "Vũ Văn L",
                    ClassId = 4,
                    Ranking = "Yếu",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                },
                new Trainee
                {
                    Id = 12,
                    FullName = "Nguyễn Thị M",
                    ClassId = 4,
                    Ranking = "Trung bình",
                    EnlistmentDate = new DateTime(2023, 9, 1),
                    Role = "Học viên"
                }
            );

            // Bạn có thể thêm seed cho các entity khác tại đây...
        }
    }
}
