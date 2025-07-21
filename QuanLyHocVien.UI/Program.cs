using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuanLyHocVien.Infrastructure;
using QuanLyHocVien.Infrastructure.Configurations;

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
            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=QuanLyHocVien.db"));

            // Các service khác (UnitOfWork, Repositories...)
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // ...

            var serviceProvider = services.BuildServiceProvider();

            // Ví dụ: chạy form khởi đầu
            //Application.Run(new Form1(serviceProvider.GetRequiredService<IUnitOfWork>()));
            Application.Run(new Form1());
        }
    }
}