using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;

namespace StudentManagementApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StudentManagementDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a fixed date for all seed data
            var seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Data seed
            modelBuilder.Entity<Category>().HasData(
                // Roles
                new Category { Id = 1, Type = "Role", Code = "STUDENT", Name = "Học viên", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 2, Type = "Role", Code = "SQUAD_LEADER", Name = "Tiểu đội trưởng", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 3, Type = "Role", Code = "CLASS_MONITOR", Name = "Lớp trưởng", SortOrder = 3, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 4, Type = "Role", Code = "STUDY_ASSISTANT", Name = "Lớp phó học tập", SortOrder = 4, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 5, Type = "Role", Code = "LOGISTICS_ASSISTANT", Name = "Lớp phó hậu cần", SortOrder = 5, CreatedDate = seedDate, IsActive = true },

                // Exam Types
                new Category { Id = 6, Type = "ExamType", Code = "TEST_15M", Name = "Kiểm tra 15 phút", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 7, Type = "ExamType", Code = "TEST_1H", Name = "Kiểm tra 1 tiết", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 8, Type = "ExamType", Code = "FINAL", Name = "Thi cuối môn", SortOrder = 3, CreatedDate = seedDate, IsActive = true }
            );
        }
    }
}
