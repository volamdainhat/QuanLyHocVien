using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            ValidateEntities();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ValidateEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ValidateEntities()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .Select(e => e.Entity);

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    // Lấy đường dẫn đến thư mục project
            //    string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            //    // Kết hợp với tên file database của bạn
            //    string databasePath = Path.Combine(projectPath, "StudentManagementDB.db");

            //    // Thiết lập kết nối SQLite
            //    optionsBuilder.UseSqlite($"Data Source={databasePath}");
            //}

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
                new Category { Id = 1, Type = "Role", Code = "hoc_vien", Name = "Học viên", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 2, Type = "Role", Code = "tieu_truong", Name = "Tiểu đội trưởng", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 3, Type = "Role", Code = "lop_truong", Name = "Lớp trưởng", SortOrder = 3, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 4, Type = "Role", Code = "hoc_tap", Name = "Lớp phó học tập", SortOrder = 4, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 5, Type = "Role", Code = "hau_can", Name = "Lớp phó hậu cần", SortOrder = 5, CreatedDate = seedDate, IsActive = true },

                // Exam Types
                new Category { Id = 6, Type = "ExamType", Code = "kt_15p", Name = "Kiểm tra 15 phút", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 7, Type = "ExamType", Code = "kt_1t", Name = "Kiểm tra 1 tiết", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 8, Type = "ExamType", Code = "thi", Name = "Thi cuối môn", SortOrder = 3, CreatedDate = seedDate, IsActive = true },

                // Military Ranks
                new Category { Id = 9, Type = "MilitaryRank", Code = "B2", Name = "Binh nhì", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 10, Type = "MilitaryRank", Code = "B1", Name = "Binh nhất", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 11, Type = "MilitaryRank", Code = "H1", Name = "Hạ sĩ", SortOrder = 3, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 12, Type = "MilitaryRank", Code = "H2", Name = "Trung sĩ", SortOrder = 4, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 13, Type = "MilitaryRank", Code = "H3", Name = "Thượng sĩ", SortOrder = 5, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 14, Type = "MilitaryRank", Code = "1/", Name = "Thiếu úy", SortOrder = 6, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 15, Type = "MilitaryRank", Code = "2/", Name = "Trung úy", SortOrder = 7, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 16, Type = "MilitaryRank", Code = "3/", Name = "Thượng úy", SortOrder = 8, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 17, Type = "MilitaryRank", Code = "4/", Name = "Đại úy", SortOrder = 9, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 18, Type = "MilitaryRank", Code = "1//", Name = "Thiếu tá", SortOrder = 10, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 19, Type = "MilitaryRank", Code = "2//", Name = "Trung tá", SortOrder = 11, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 20, Type = "MilitaryRank", Code = "3//", Name = "Thượng tá", SortOrder = 12, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 21, Type = "MilitaryRank", Code = "4//", Name = "Đại tá", SortOrder = 13, CreatedDate = seedDate, IsActive = true }
            );
        }
    }
}
