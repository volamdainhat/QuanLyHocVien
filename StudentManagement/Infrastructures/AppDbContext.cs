using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace StudentManagement.Infrastructures
{
    public class AppDbContext : DbContext
    {
        public DbSet<Attendances> Attendances { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Misconduct> Misconduct { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=studentmanagement.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API nếu cần thêm
        }
    }

}
