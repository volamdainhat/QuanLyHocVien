using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Data;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.Infrastructure.Repositories.Categories;
using StudentManagementApp.Infrastructure.Repositories.Classes;
using StudentManagementApp.Infrastructure.Repositories.Gradeses;
using StudentManagementApp.Infrastructure.Repositories.Schedules;
using StudentManagementApp.Infrastructure.Repositories.Trainees;
using StudentManagementApp.UI.Forms;
using StudentManagementApp.UI.Forms.CRUD;
using System.Configuration;

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
            var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));
            // Read connection string from App.config
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            var databasePath = Path.Combine(basePath, connectionString);
            if (string.IsNullOrEmpty(connectionString))
            {
                // Fallback
                connectionString = "Data Source=StudentManagementDB.db";
            }

            services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));

            // Register repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ITraineeRepository, TraineeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGradesRepository, GradesRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            // Register validation services
            services.AddScoped<IValidationService, ValidationService>();

            // Register forms
            services.AddTransient<MainForm>();
            services.AddTransient<DashboardForm>();
            services.AddTransient<ProductListForm>();
            services.AddTransient<SchoolYearListForm>();
            services.AddTransient<ClassListForm>();
            services.AddTransient<TraineeListForm>();
            services.AddTransient<SubjectListForm>();
            services.AddTransient<GradesListForm>();
            services.AddTransient<ScheduleListForm>();
        }
    }
}