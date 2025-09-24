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
                new Category { Id = 1, Type = "Role", Code = "hoc_vien", Name = "Học viên", SortOrder = 1, IsActive = true },
                new Category { Id = 2, Type = "Role", Code = "tieu_truong", Name = "Tiểu đội trưởng", SortOrder = 2, IsActive = true },
                new Category { Id = 3, Type = "Role", Code = "lop_truong", Name = "Lớp trưởng", SortOrder = 3, IsActive = true },
                new Category { Id = 4, Type = "Role", Code = "hoc_tap", Name = "Lớp phó học tập", SortOrder = 4, IsActive = true },
                new Category { Id = 5, Type = "Role", Code = "hau_can", Name = "Lớp phó hậu cần", SortOrder = 5, IsActive = true },

                // Exam Types
                new Category { Id = 6, Type = "ExamType", Code = "kt_15p", Name = "Kiểm tra 15 phút", SortOrder = 1, IsActive = true },
                new Category { Id = 7, Type = "ExamType", Code = "kt_1t", Name = "Kiểm tra 1 tiết", SortOrder = 2, IsActive = true },
                new Category { Id = 8, Type = "ExamType", Code = "thi", Name = "Thi cuối môn", SortOrder = 3, IsActive = true },

                // Military Ranks
                new Category { Id = 9, Type = "MilitaryRank", Code = "B2", Name = "Binh nhì", SortOrder = 1, IsActive = true },
                new Category { Id = 10, Type = "MilitaryRank", Code = "B1", Name = "Binh nhất", SortOrder = 2, IsActive = true },
                new Category { Id = 11, Type = "MilitaryRank", Code = "H1", Name = "Hạ sĩ", SortOrder = 3, IsActive = true },
                new Category { Id = 12, Type = "MilitaryRank", Code = "H2", Name = "Trung sĩ", SortOrder = 4, IsActive = true },
                new Category { Id = 13, Type = "MilitaryRank", Code = "H3", Name = "Thượng sĩ", SortOrder = 5, IsActive = true },
                new Category { Id = 14, Type = "MilitaryRank", Code = "1/", Name = "Thiếu úy", SortOrder = 6, IsActive = true },
                new Category { Id = 15, Type = "MilitaryRank", Code = "2/", Name = "Trung úy", SortOrder = 7, IsActive = true },
                new Category { Id = 16, Type = "MilitaryRank", Code = "3/", Name = "Thượng úy", SortOrder = 8, IsActive = true },
                new Category { Id = 17, Type = "MilitaryRank", Code = "4/", Name = "Đại úy", SortOrder = 9, IsActive = true },
                new Category { Id = 18, Type = "MilitaryRank", Code = "1//", Name = "Thiếu tá", SortOrder = 10, IsActive = true },
                new Category { Id = 19, Type = "MilitaryRank", Code = "2//", Name = "Trung tá", SortOrder = 11, IsActive = true },
                new Category { Id = 20, Type = "MilitaryRank", Code = "3//", Name = "Thượng tá", SortOrder = 12, IsActive = true },
                new Category { Id = 21, Type = "MilitaryRank", Code = "4//", Name = "Đại tá", SortOrder = 13, IsActive = true },

                // Provinces
                new Category { Id = 22, Type = "Provinces", Code = "ha_noi_01", Name = "Thành phố Hà Nội", SortOrder = 1, IsActive = true },
                new Category { Id = 23, Type = "Provinces", Code = "cao_bang_04", Name = "Tỉnh Cao Bằng", SortOrder = 2, IsActive = true },
                new Category { Id = 24, Type = "Provinces", Code = "tuyen_quang_08", Name = "Tỉnh Tuyên Quang", SortOrder = 3, IsActive = true },
                new Category { Id = 25, Type = "Provinces", Code = "dien_bien_11", Name = "Tỉnh Điện Biên", SortOrder = 4, IsActive = true },
                new Category { Id = 26, Type = "Provinces", Code = "lai_chau_12", Name = "Tỉnh Lai Châu", SortOrder = 5, IsActive = true },
                new Category { Id = 27, Type = "Provinces", Code = "son_la_14", Name = "Tỉnh Sơn La", SortOrder = 6, IsActive = true },
                new Category { Id = 28, Type = "Provinces", Code = "lao_cai_15", Name = "Tỉnh Lào Cai", SortOrder = 7, IsActive = true },
                new Category { Id = 29, Type = "Provinces", Code = "thai_nguyen_19", Name = "Tỉnh Thái Nguyên", SortOrder = 8, IsActive = true },
                new Category { Id = 30, Type = "Provinces", Code = "lang_son_20", Name = "Tỉnh Lạng Sơn", SortOrder = 9, IsActive = true },
                new Category { Id = 31, Type = "Provinces", Code = "quang_ninh_22", Name = "Tỉnh Quảng Ninh", SortOrder = 10, IsActive = true },
                new Category { Id = 32, Type = "Provinces", Code = "bac_ninh_24", Name = "Tỉnh Bắc Ninh", SortOrder = 11, IsActive = true },
                new Category { Id = 33, Type = "Provinces", Code = "phu_tho_25", Name = "Tỉnh Phú Thọ", SortOrder = 12, IsActive = true },
                new Category { Id = 34, Type = "Provinces", Code = "hai_phong_31", Name = "Thành phố Hải Phòng", SortOrder = 13, IsActive = true },
                new Category { Id = 35, Type = "Provinces", Code = "hung_yen_33", Name = "Tỉnh Hưng Yên", SortOrder = 14, IsActive = true },
                new Category { Id = 36, Type = "Provinces", Code = "ninh_binh_37", Name = "Tỉnh Ninh Bình", SortOrder = 15, IsActive = true },
                new Category { Id = 37, Type = "Provinces", Code = "thanh_hoa_38", Name = "Tỉnh Thanh Hóa", SortOrder = 16, IsActive = true },
                new Category { Id = 38, Type = "Provinces", Code = "nghe_an_40", Name = "Tỉnh Nghệ An", SortOrder = 17, IsActive = true },
                new Category { Id = 39, Type = "Provinces", Code = "ha_tinh_42", Name = "Tỉnh Hà Tĩnh", SortOrder = 18, IsActive = true },
                new Category { Id = 40, Type = "Provinces", Code = "quang_tri_44", Name = "Tỉnh Quảng Trị", SortOrder = 19, IsActive = true },
                new Category { Id = 41, Type = "Provinces", Code = "hue_46", Name = "Thành phố Huế", SortOrder = 20, IsActive = true },
                new Category { Id = 42, Type = "Provinces", Code = "da_nang_48", Name = "Thành phố Đà Nẵng", SortOrder = 21, IsActive = true },
                new Category { Id = 43, Type = "Provinces", Code = "quang_ngai_51", Name = "Tỉnh Quảng Ngãi", SortOrder = 22, IsActive = true },
                new Category { Id = 44, Type = "Provinces", Code = "gia_lai_52", Name = "Tỉnh Gia Lai", SortOrder = 23, IsActive = true },
                new Category { Id = 45, Type = "Provinces", Code = "khanh_hoa_56", Name = "Tỉnh Khánh Hòa", SortOrder = 24, IsActive = true },
                new Category { Id = 46, Type = "Provinces", Code = "dak_lak_66", Name = "Tỉnh Đắk Lắk", SortOrder = 25, IsActive = true },
                new Category { Id = 47, Type = "Provinces", Code = "lam_dong_68", Name = "Tỉnh Lâm Đồng", SortOrder = 26, IsActive = true },
                new Category { Id = 48, Type = "Provinces", Code = "dong_nai_75", Name = "Tỉnh Đồng Nai", SortOrder = 27, IsActive = true },
                new Category { Id = 49, Type = "Provinces", Code = "ho_chi_minh_79", Name = "Thành phố Hồ Chí Minh", SortOrder = 28, IsActive = true },
                new Category { Id = 51, Type = "Provinces", Code = "tay_ninh_80", Name = "Tỉnh Tây Ninh", SortOrder = 29, IsActive = true },
                new Category { Id = 52, Type = "Provinces", Code = "dong_thap_82", Name = "Tỉnh Đồng Tháp", SortOrder = 30, IsActive = true },
                new Category { Id = 53, Type = "Provinces", Code = "vinh_long_86", Name = "Tỉnh Vĩnh Long", SortOrder = 31, IsActive = true },
                new Category { Id = 54, Type = "Provinces", Code = "an_giang_91", Name = "Tỉnh An Giang", SortOrder = 32, IsActive = true },
                new Category { Id = 55, Type = "Provinces", Code = "can_tho_92", Name = "Thành phố Cần Thơ", SortOrder = 33, IsActive = true },
                new Category { Id = 56, Type = "Provinces", Code = "ca_mau_96", Name = "Tỉnh Cà Mau", SortOrder = 34, IsActive = true },

                // Education Level
                new Category { Id = 59, Type = "EducationLevel", Code = "thcs", Name = "9/12", SortOrder = 3, IsActive = true },
                new Category { Id = 60, Type = "EducationLevel", Code = "thpt", Name = "12/12", SortOrder = 4, IsActive = true },
                new Category { Id = 61, Type = "EducationLevel", Code = "trung_cap", Name = "Trung cấp", SortOrder = 5, IsActive = true },
                new Category { Id = 62, Type = "EducationLevel", Code = "cao_dang", Name = "Cao đẳng", SortOrder = 6, IsActive = true },
                new Category { Id = 63, Type = "EducationLevel", Code = "dai_hoc", Name = "Đại học", SortOrder = 7, IsActive = true },
                new Category { Id = 64, Type = "EducationLevel", Code = "thac_si", Name = "Thạc sĩ", SortOrder = 8, IsActive = true },
                new Category { Id = 65, Type = "EducationLevel", Code = "tien_si", Name = "Tiến sĩ", SortOrder = 9, IsActive = true },
                new Category { Id = 66, Type = "EducationLevel", Code = "pho_giao_su", Name = "Phó Giáo sư", SortOrder = 10, IsActive = true },
                new Category { Id = 67, Type = "EducationLevel", Code = "giao_su", Name = "Giáo sư", SortOrder = 11, IsActive = true },

                // Schedule Period
                new Category { Id = 68, Type = "SchedulePeriod", Code = "sang", Name = "Buổi sáng", SortOrder = 1, IsActive = true },
                new Category { Id = 69, Type = "SchedulePeriod", Code = "chieu", Name = "Buổi chiều", SortOrder = 2, IsActive = true },

                new Category { Id = 100, Type = "Gender", Code = "nam", Name = "Nam", SortOrder = 1, IsActive = true },
                new Category { Id = 101, Type = "Gender", Code = "nu", Name = "Nữ", SortOrder = 2, IsActive = true },
                new Category { Id = 102, Type = "Gender", Code = "khac", Name = "Khác", SortOrder = 3, IsActive = true },

                // Health Status
                new Category { Id = 110, Type = "HealthStatus", Code = "tot", Name = "Tốt", SortOrder = 1, IsActive = true },
                new Category { Id = 111, Type = "HealthStatus", Code = "kha", Name = "Khá", SortOrder = 2, IsActive = true },
                new Category { Id = 112, Type = "HealthStatus", Code = "trung_binh", Name = "Trung bình", SortOrder = 3, IsActive = true },
                new Category { Id = 113, Type = "HealthStatus", Code = "yeu", Name = "Yếu", SortOrder = 4, IsActive = true },

                // Ethnicities (major ones - you can add more as needed)
                new Category { Id = 130, Type = "Ethnicity", Code = "kinh", Name = "Kinh", SortOrder = 1, IsActive = true },
                new Category { Id = 131, Type = "Ethnicity", Code = "tay", Name = "Tày", SortOrder = 2, IsActive = true },
                new Category { Id = 132, Type = "Ethnicity", Code = "thai", Name = "Thái", SortOrder = 3, IsActive = true },
                new Category { Id = 133, Type = "Ethnicity", Code = "muong", Name = "Mường", SortOrder = 4, IsActive = true },
                new Category { Id = 134, Type = "Ethnicity", Code = "khmer", Name = "Khmer", SortOrder = 5, IsActive = true },
                new Category { Id = 135, Type = "Ethnicity", Code = "hoa", Name = "Hoa", SortOrder = 6, IsActive = true },
                new Category { Id = 136, Type = "Ethnicity", Code = "nung", Name = "Nùng", SortOrder = 7, IsActive = true },
                new Category { Id = 137, Type = "Ethnicity", Code = "hmong", Name = "HMông", SortOrder = 8, IsActive = true },
                new Category { Id = 138, Type = "Ethnicity", Code = "dao", Name = "Dao", SortOrder = 9, IsActive = true }
            );
        }
    }
}
