using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;
using System.Collections.Generic;

namespace QuanLyHocVien.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Trainee> HocVien => Set<Trainee>();
        public DbSet<Class> Lop => Set<Class>();
        public DbSet<Grades> NienKhoa => Set<Grades>();
        public DbSet<Misconduct> AttendanceDetails => Set<Misconduct>();
        public DbSet<Reports> Reports => Set<Reports>();
        public DbSet<Timetable> Timetables => Set<Timetable>();
        public DbSet<AttendanceDetails> AttendanceDetailss => Set<AttendanceDetails>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
