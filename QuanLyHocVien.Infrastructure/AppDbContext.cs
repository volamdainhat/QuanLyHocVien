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
        public DbSet<Trainee> Trainees => Set<Trainee>();
        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Grades> Grades => Set<Grades>();
        public DbSet<Misconduct> Misconducts => Set<Misconduct>();
        public DbSet<Reports> Reports => Set<Reports>();
        public DbSet<Schedule> Schedules => Set<Schedule>();
        public DbSet<Attendances> Attendances => Set<Attendances>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=QuanLyHocVien.db", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

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
        }
    }

}
