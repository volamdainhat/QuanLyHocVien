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
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubjectAverageScore> SubjectAverageScores { get; set; }
        public DbSet<WeeklyCritique> WeeklyCritiques { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // = bin\Debug\net...
            var baseDir = AppContext.BaseDirectory;
            // tên file DB bạn muốn dùng ở output folder
            var dbPath = Path.Combine(baseDir, "StudentManagementSystem.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trainee>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Class>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Grades>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Misconduct>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Reports>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Schedule>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Attendances>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Subject>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<UserInfo>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<ImageGallery>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
                b.HasIndex(c => new { c.Type, c.Code }).IsUnique();
            });

            modelBuilder.Entity<SubjectAverageScore>(b =>
            {
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
                b.HasIndex(c => new { c.TraineeId, c.SubjectId, c.Semester, c.SchoolYear }).IsUnique();
            });

            modelBuilder.Entity<WeeklyCritique>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd().HasAnnotation("Sqlite:Autoincrement", true);
            });

            // Seed dữ liệu mẫu
            modelBuilder.Entity<Category>().HasData(
                // Roles
                new Category { Id = 1, Type = "Role", Code = "STUDENT", Name = "Học viên", SortOrder = 1 },
                new Category { Id = 2, Type = "Role", Code = "SQUAD_LEADER", Name = "Tiểu đội trưởng", SortOrder = 2 },
                new Category { Id = 3, Type = "Role", Code = "CLASS_MONITOR", Name = "Lớp trưởng", SortOrder = 3 },
                new Category { Id = 4, Type = "Role", Code = "STUDY_ASSISTANT", Name = "Lớp phó học tập", SortOrder = 4 },
                new Category { Id = 5, Type = "Role", Code = "LOGISTICS_ASSISTANT", Name = "Lớp phó hậu cần", SortOrder = 5 },

                // Exam Types
                new Category { Id = 6, Type = "ExamType", Code = "TEST_15M", Name = "Kiểm tra 15 phút", SortOrder = 1 },
                new Category { Id = 7, Type = "ExamType", Code = "TEST_1H", Name = "Kiểm tra 1 tiết", SortOrder = 2 },
                new Category { Id = 8, Type = "ExamType", Code = "FINAL", Name = "Thi cuối môn", SortOrder = 3 }
            );
        }
    }
}
