using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuanLyHocVien.Domain.Entities;
using System.Configuration;
using System.Reflection;
using System.Xml.Linq;

namespace QuanLyHocVien.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trainee> Trainees { get; set; }
        //public DbSet<Class> Classes => Set<Class>();
        //public DbSet<Grades> Grades => Set<Grades>();
        //public DbSet<Misconduct> Misconducts => Set<Misconduct>();
        //public DbSet<Reports> Reports => Set<Reports>();
        //public DbSet<Schedule> Schedules => Set<Schedule>();
        //public DbSet<Attendances> Attendances => Set<Attendances>();

        public string DbPath { get; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity properties and relationships here if needed

            // Trainee
            modelBuilder.Entity<Trainee>().ToTable("Trainees");
            modelBuilder.Entity<Trainee>(option =>
            {
                option.HasKey(t => t.Id);
                option.Property(t => t.FullName).IsRequired();
                option.Property(t => t.ClassId).IsRequired();
                option.Property(t => t.Ranking).IsRequired();
                option.Property(t => t.EnlistmentDate).IsRequired();
                option.Property(t => t.Role).HasDefaultValue("Học viên");
            });

            //modelBuilder.Entity<Class>().ToTable("Classes");
            //modelBuilder.Entity<Grades>().ToTable("Grades");
            //modelBuilder.Entity<Misconduct>().ToTable("Misconducts");
            //modelBuilder.Entity<Reports>().ToTable("Reports");
            //modelBuilder.Entity<Schedule>().ToTable("Schedules");
            //modelBuilder.Entity<Attendances>().ToTable("Attendances");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trainee>().HasData(GenerateFakeTrainees());
        }

        private static IEnumerable<Trainee> GenerateFakeTrainees()
        {
            var list = new List<Trainee>();
            for (int i = 1; i <= 50; i++)
            {
                list.Add(new Trainee
                {
                    Id = i,
                    FullName = $"Học viên {i}",
                    ClassId = i % 5 + 1,
                    PhoneNumber = $"012345678{i:D2}",
                    DayOfBirth = new DateTime(2000, 1, 1).AddDays(i * 30),
                    EnlistmentDate = new DateTime(2022, 9, 1),
                    Ranking = i % 3 == 0 ? "Giỏi" : i % 2 == 0 ? "Khá" : "Trung bình",
                    Role = "Học viên",
                    FatherFullName = $"Ông A{i}",
                    FatherPhoneNumber = $"098765432{i:D2}",
                    MotherFullName = $"Bà B{i}",
                    MotherPhoneNumber = $"097812345{i:D2}",
                    AverageScore = 5 + (i % 5)
                });
            }
            return list;
        }

    }

}
