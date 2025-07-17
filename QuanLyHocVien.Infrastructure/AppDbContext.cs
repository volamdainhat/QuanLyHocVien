using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;
using System.Collections.Generic;

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
    }

}
