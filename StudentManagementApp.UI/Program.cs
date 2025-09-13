using Microsoft.Extensions.DependencyInjection;
using StudentManagementApp.Infrastructure.Data;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.UI.Forms;
using StudentManagementApp.UI.Forms.CRUD;

namespace StudentManagementApp.UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            // Create database
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
            }

            Application.Run(ServiceProvider.GetRequiredService<MainForm>());
        }

        static void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            // ??ng ký repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // ??ng ký forms
            services.AddTransient<MainForm>();
            services.AddTransient<DashboardForm>();
            services.AddTransient<ProductListForm>();
            services.AddTransient<ProductForm>();
        }
    }
}