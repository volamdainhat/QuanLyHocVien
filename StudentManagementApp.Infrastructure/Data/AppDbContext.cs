using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TraineeAverageScore> TraineeAverageScores { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<SubjectAverage> SubjectAverages { get; set; }
        public DbSet<Misconduct> Misconducts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<SchoolYear> SchoolYears { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

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
                new Category { Id = 21, Type = "MilitaryRank", Code = "4//", Name = "Đại tá", SortOrder = 13, CreatedDate = seedDate, IsActive = true },

                // Provinces
                new Category { Id = 22, Type = "Provinces", Code = "ha_noi_01", Name = "Thành phố Hà Nội", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 23, Type = "Provinces", Code = "cao_bang_04", Name = "Tỉnh Cao Bằng", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 24, Type = "Provinces", Code = "tuyen_quang_08", Name = "Tỉnh Tuyên Quang", SortOrder = 3, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 25, Type = "Provinces", Code = "dien_bien_11", Name = "Tỉnh Điện Biên", SortOrder = 4, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 26, Type = "Provinces", Code = "lai_chau_12", Name = "Tỉnh Lai Châu", SortOrder = 5, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 27, Type = "Provinces", Code = "son_la_14", Name = "Tỉnh Sơn La", SortOrder = 6, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 28, Type = "Provinces", Code = "lao_cai_15", Name = "Tỉnh Lào Cai", SortOrder = 7, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 29, Type = "Provinces", Code = "thai_nguyen_19", Name = "Tỉnh Thái Nguyên", SortOrder = 8, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 30, Type = "Provinces", Code = "lang_son_20", Name = "Tỉnh Lạng Sơn", SortOrder = 9, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 31, Type = "Provinces", Code = "quang_ninh_22", Name = "Tỉnh Quảng Ninh", SortOrder = 10, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 32, Type = "Provinces", Code = "bac_ninh_24", Name = "Tỉnh Bắc Ninh", SortOrder = 11, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 33, Type = "Provinces", Code = "phu_tho_25", Name = "Tỉnh Phú Thọ", SortOrder = 12, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 34, Type = "Provinces", Code = "hai_phong_31", Name = "Thành phố Hải Phòng", SortOrder = 13, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 35, Type = "Provinces", Code = "hung_yen_33", Name = "Tỉnh Hưng Yên", SortOrder = 14, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 36, Type = "Provinces", Code = "ninh_binh_37", Name = "Tỉnh Ninh Bình", SortOrder = 15, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 37, Type = "Provinces", Code = "thanh_hoa_38", Name = "Tỉnh Thanh Hóa", SortOrder = 16, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 38, Type = "Provinces", Code = "nghe_an_40", Name = "Tỉnh Nghệ An", SortOrder = 17, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 39, Type = "Provinces", Code = "ha_tinh_42", Name = "Tỉnh Hà Tĩnh", SortOrder = 18, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 40, Type = "Provinces", Code = "quang_tri_44", Name = "Tỉnh Quảng Trị", SortOrder = 19, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 41, Type = "Provinces", Code = "hue_46", Name = "Thành phố Huế", SortOrder = 20, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 42, Type = "Provinces", Code = "da_nang_48", Name = "Thành phố Đà Nẵng", SortOrder = 21, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 43, Type = "Provinces", Code = "quang_ngai_51", Name = "Tỉnh Quảng Ngãi", SortOrder = 22, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 44, Type = "Provinces", Code = "gia_lai_52", Name = "Tỉnh Gia Lai", SortOrder = 23, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 45, Type = "Provinces", Code = "khanh_hoa_56", Name = "Tỉnh Khánh Hòa", SortOrder = 24, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 46, Type = "Provinces", Code = "dak_lak_66", Name = "Tỉnh Đắk Lắk", SortOrder = 25, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 47, Type = "Provinces", Code = "lam_dong_68", Name = "Tỉnh Lâm Đồng", SortOrder = 26, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 48, Type = "Provinces", Code = "dong_nai_75", Name = "Tỉnh Đồng Nai", SortOrder = 27, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 49, Type = "Provinces", Code = "ho_chi_minh_79", Name = "Thành phố Hồ Chí Minh", SortOrder = 28, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 51, Type = "Provinces", Code = "tay_ninh_80", Name = "Tỉnh Tây Ninh", SortOrder = 29, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 52, Type = "Provinces", Code = "dong_thap_82", Name = "Tỉnh Đồng Tháp", SortOrder = 30, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 53, Type = "Provinces", Code = "vinh_long_86", Name = "Tỉnh Vĩnh Long", SortOrder = 31, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 54, Type = "Provinces", Code = "an_giang_91", Name = "Tỉnh An Giang", SortOrder = 32, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 55, Type = "Provinces", Code = "can_tho_92", Name = "Thành phố Cần Thơ", SortOrder = 33, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 56, Type = "Provinces", Code = "ca_mau_96", Name = "Tỉnh Cà Mau", SortOrder = 34, CreatedDate = seedDate, IsActive = true },

                // Education Level
                new Category { Id = 57, Type = "EducationLevel", Code = "mam_non", Name = "Mầm non", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 58, Type = "EducationLevel", Code = "tieu_hoc", Name = "Tiểu học", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 59, Type = "EducationLevel", Code = "thcs", Name = "Trung học cơ sở", SortOrder = 3, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 60, Type = "EducationLevel", Code = "thpt", Name = "Trung học phổ thông", SortOrder = 4, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 61, Type = "EducationLevel", Code = "trung_cap", Name = "Trung cấp", SortOrder = 5, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 62, Type = "EducationLevel", Code = "cao_dang", Name = "Cao đẳng", SortOrder = 6, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 63, Type = "EducationLevel", Code = "dai_hoc", Name = "Đại học", SortOrder = 7, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 64, Type = "EducationLevel", Code = "thac_si", Name = "Thạc sĩ", SortOrder = 8, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 65, Type = "EducationLevel", Code = "tien_si", Name = "Tiến sĩ", SortOrder = 9, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 66, Type = "EducationLevel", Code = "pho_giao_su", Name = "Phó Giáo sư", SortOrder = 10, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 67, Type = "EducationLevel", Code = "giao_su", Name = "Giáo sư", SortOrder = 11, CreatedDate = seedDate, IsActive = true },

                // Schedule Period
                new Category { Id = 68, Type = "SchedulePeriod", Code = "sang", Name = "Buổi sáng", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 69, Type = "SchedulePeriod", Code = "chieu", Name = "Buổi chiều", SortOrder = 2, CreatedDate = seedDate, IsActive = true },

                // Misconduct Type
                new Category { Id = 70, Type = "MisconductType", Code = "vang", Name = "Vắng", SortOrder = 1, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 71, Type = "MisconductType", Code = "vi_pham_ky_luat", Name = "Vi phạm kỷ luật", SortOrder = 2, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 72, Type = "MisconductType", Code = "di_tre", Name = "Đi trễ", SortOrder = 3, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 73, Type = "MisconductType", Code = "gian_lan_kiem_tra", Name = "Gian lận kiểm tra", SortOrder = 4, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 74, Type = "MisconductType", Code = "mat_trat_tu", Name = "Mất trật tự", SortOrder = 5, CreatedDate = seedDate, IsActive = true },
                new Category { Id = 75, Type = "MisconductType", Code = "khac", Name = "Khác", SortOrder = 6, CreatedDate = seedDate, IsActive = true }
            );
        }

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
            if (!optionsBuilder.IsConfigured)
            {
                // Fallback connection string cho design-time
                optionsBuilder.UseSqlite("Data Source=StudentManagementDB.db");
            }

            //optionsBuilder.UseSqlite("Data Source=StudentManagementDB.db");
        }
    }
}
