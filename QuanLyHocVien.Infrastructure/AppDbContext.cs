using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure
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
        => optionsBuilder.UseSqlite("Data Source=QuanLyHocVien.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API nếu cần thêm
        }
    }
}
