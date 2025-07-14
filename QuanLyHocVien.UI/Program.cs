using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuanLyHocVien.Infrastructure;

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
                services.AddScoped<IHocVienRepository, HocVienRepository>();
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