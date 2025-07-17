using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuanLyHocVien.Infrastructure;
using QuanLyHocVien.Infrastructure.Repositories.AttendancesRepo;
using QuanLyHocVien.Infrastructure.Repositories.ClassRepo;
using QuanLyHocVien.Infrastructure.Repositories.GradesRepo;
using QuanLyHocVien.Infrastructure.Repositories.MisconductRepo;
using QuanLyHocVien.Infrastructure.Repositories.ReportRepo;
using QuanLyHocVien.Infrastructure.Repositories.ScheduleRepo;
using QuanLyHocVien.Infrastructure.Repositories.SubjectRepo;
using QuanLyHocVien.Infrastructure.Repositories.TraineeRepo;

namespace QuanLyHocVien.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Đăng ký DbContext dùng SQLite
                services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=quanly.db"));

                // Đăng ký Repository
                services.AddScoped<ITraineeRepository, TraineeRepository>();
                services.AddScoped<IClassRepository, ClassRepository>();
                services.AddScoped<ISubjectRepository, SubjectRepository>();
                services.AddScoped<IScheduleRepository, ScheduleRepository>();
                services.AddScoped<IGradesRepository, GradesRepository>();
                services.AddScoped<IMisconductRepository, MisconductRepository>();
                services.AddScoped<IReportRepository, ReportRepository>();
                services.AddScoped<IAttendanceRepository, AttendanceRepository>();
                // Đăng ký các dịch vụ khác nếu cần

                //services.AddScoped<IUnitOfWork, UnitOfWork>(); // nếu có

                // Đăng ký AutoMapper (nếu có dùng)
                services.AddAutoMapper(typeof(Program));

                // Đăng ký Form chính
                services.AddScoped<Form1>(); // bạn sẽ tạo MainForm.cs riêng
            });

            var host = builder.Build();

            // Lấy form từ DI container
            var form = host.Services.GetRequiredService<Form1>();
            Application.Run(form);
        }
    }
}