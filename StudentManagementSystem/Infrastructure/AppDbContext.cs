using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Misconduct> Misconducts { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Attendances> Attendances { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=StudentManagementSystem.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var classes = new List<Class>
            {
                new Class
                {
                    Id = 1,
                    Name = "Alpha Squad",
                    StartDate = new DateTime(2025, 1, 10),
                    EndDate = new DateTime(2025, 6, 30),
                    TotalStudents = 2
                },
                new Class
                {
                    Id = 2,
                    Name = "Bravo Team",
                    StartDate = new DateTime(2025, 2, 15),
                    EndDate = new DateTime(2025, 8, 15),
                    TotalStudents = 1
                }
            };

            Image image = Properties.Resources.avatar;
            string base64String = "";
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Hoặc .Jpeg nếu muốn
                byte[] imageBytes = ms.ToArray();
                base64String = Convert.ToBase64String(imageBytes);
            }


            var trainees = new List<Trainee>
            {
                new Trainee
                {
                    Id = 1,
                    FullName = "Nguyen Van A",
                    ClassId = 1,
                    Class = classes.First(c => c.Id == 1),
                    PhoneNumber = "0909123456",
                    DayOfBirth = new DateTime(2003, 5, 20),
                    Ranking = "Giỏi",
                    EnlistmentDate = new DateTime(2025, 1, 12),
                    AverageScore = 8.5f,
                    Role = "Trưởng nhóm",
                    FatherFullName = "Nguyen Van B",
                    FatherPhoneNumber = "0909988776",
                    MotherFullName = "Le Thi C",
                    MotherPhoneNumber = "0909777888",
                    AvatarBase64String = base64String // nếu dùng ảnh thật
                },
                new Trainee
                {
                    Id = 2,
                    FullName = "Tran Thi D",
                    ClassId = 1,
                    Class = classes.First(c => c.Id == 1),
                    PhoneNumber = "0912345678",
                    DayOfBirth = new DateTime(2004, 3, 10),
                    Ranking = "Khá",
                    EnlistmentDate = new DateTime(2025, 1, 15),
                    AverageScore = 7.8f,
                    Role = "Thành viên",
                    FatherFullName = "Tran Van E",
                    FatherPhoneNumber = "0911001122",
                    MotherFullName = "Pham Thi F",
                    MotherPhoneNumber = "0911223344",
                    AvatarBase64String = base64String
                },
                new Trainee
                {
                    Id = 3,
                    FullName = "Le Van G",
                    ClassId = 2,
                    Class = classes.First(c => c.Id == 2),
                    PhoneNumber = "0922334455",
                    DayOfBirth = new DateTime(2002, 12, 5),
                    Ranking = "Trung bình",
                    EnlistmentDate = new DateTime(2025, 2, 20),
                    AverageScore = 6.2f,
                    Role = "Thành viên",
                    FatherFullName = "Le Van H",
                    FatherPhoneNumber = "0933445566",
                    MotherFullName = "Nguyen Thi I",
                    MotherPhoneNumber = "0933556677",
                    AvatarBase64String = base64String
                }
            };


            modelBuilder.Entity<Class>().HasData(classes);
            modelBuilder.Entity<Trainee>().HasData(trainees.Select(t => new {
                t.Id,
                t.FullName,
                t.ClassId,
                t.PhoneNumber,
                t.DayOfBirth,
                t.Ranking,
                t.EnlistmentDate,
                t.AverageScore,
                t.Role,
                t.FatherFullName,
                t.FatherPhoneNumber,
                t.MotherFullName,
                t.MotherPhoneNumber,
                t.AvatarBase64String
            }));


            base.OnModelCreating(modelBuilder);
            // Fluent API nếu cần thêm
        }
    }
}
