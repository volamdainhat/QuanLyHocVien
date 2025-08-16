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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var baseDir = AppContext.BaseDirectory; // = bin\Debug\net...
            var dbPath = Path.Combine(baseDir, "StudentManagementSystem.db"); // tên file DB bạn muốn dùng ở output folder
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
            //optionsBuilder.UseSqlite("Data Source=StudentManagementSystem.db");
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
        }
    }
}
