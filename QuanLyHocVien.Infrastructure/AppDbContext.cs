using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trainee> Trainees { get; set; }
        //public DbSet<Class> Classes { get; set; }
        //public DbSet<Grades> Grades { get; set; }
        //public DbSet<Misconduct> Misconducts { get; set; }
        //public DbSet<Reports> Reports { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<Attendances> Attendances { get; set; }

        public string DbPath { get; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "QuanLyHocVien.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Configure entity properties and relationships here if needed

        //    // Trainee
        //    modelBuilder.Entity<Trainee>().ToTable("Trainees");
        //    modelBuilder.Entity<Trainee>(option =>
        //    {
        //        option.HasKey(t => t.Id);
        //        option.Property(t => t.FullName).IsRequired();
        //        option.Property(t => t.ClassId).IsRequired();
        //        option.Property(t => t.Ranking).IsRequired();
        //        option.Property(t => t.EnlistmentDate).IsRequired();
        //        option.Property(t => t.Role).HasDefaultValue("Học viên");
        //    });

        //    //modelBuilder.Entity<Class>().ToTable("Classes");
        //    //modelBuilder.Entity<Grades>().ToTable("Grades");
        //    //modelBuilder.Entity<Misconduct>().ToTable("Misconducts");
        //    //modelBuilder.Entity<Reports>().ToTable("Reports");
        //    //modelBuilder.Entity<Schedule>().ToTable("Schedules");
        //    //modelBuilder.Entity<Attendances>().ToTable("Attendances");

        //    base.OnModelCreating(modelBuilder);

        //    AppDbSeed.Seed(modelBuilder); // Gọi file seed
        //}
    }
}
