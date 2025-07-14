using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace QuanLyHocVien.Infrastructure
{
    public class AppDbContext : DbContext
    {
        //public DbSet<HocVien> HocViens => Set<HocVien>();
        //public DbSet<Lop> Lops => Set<Lop>();
        //public DbSet<NienKhoa> NienKhoas => Set<NienKhoa>();
        //public DbSet<MonHoc> MonHocs => Set<MonHoc>();
        //public DbSet<Diem> Diems => Set<Diem>();
        //public DbSet<LichHoc> LichHocs => Set<LichHoc>();
        //public DbSet<ViPham> ViPhams => Set<ViPham>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
