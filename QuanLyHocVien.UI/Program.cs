using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuanLyHocVien.Applications.Mapping;
using QuanLyHocVien.Infrastructure;
using QuanLyHocVien.Infrastructure.Configurations;
using QuanLyHocVien.UI.Forms;

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
            var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(config =>
            {
                config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("sqlite");

                // Gắn DbContext
                services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

                // Các service khác (UnitOfWork, Repositories...)
                services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddAutoMapper(typeof(MappingProfile));
                // ...

                // Đăng ký các Form để có thể resolve qua DI
                services.AddScoped<FrmTrainee>();
                services.AddScoped<frmMain>();
            })
            .Build();

            // Resolve và chạy Form khởi đầu
            var form = host.Services.GetRequiredService<frmMain>();
            Application.Run(form);
        }
    }
}