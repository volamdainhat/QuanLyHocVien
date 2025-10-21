using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Interfaces.Services;
using StudentManagementApp.Core.Services;
using StudentManagementApp.Infrastructure.Data;
using StudentManagementApp.Infrastructure.Repositories;
using StudentManagementApp.UI.Forms;
using StudentManagementApp.UI.Forms.Auth;
using StudentManagementApp.UI.Forms.CRUD;
using System.Configuration;

namespace StudentManagementApp.UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static User CurrentUser { get; set; }

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

            RunApplication();
        }

        private static void RunApplication()
        {
            var sessionService = ServiceProvider.GetService<ISessionService>();

            while (true)
            {
                using (var loginForm = new LoginForm(ServiceProvider.GetService<IAuthService>(), sessionService))
                {
                    if (loginForm.ShowDialog() == DialogResult.OK && sessionService.IsLoggedIn)
                    {
                        using (var mainForm = new MainForm(ServiceProvider, sessionService))
                        {
                            // ??ng ký s? ki?n logout
                            sessionService.OnUserLoggedOut += (user) =>
                            {
                                // S? d?ng Invoke n?u c?n thi?t ?? ch?y trên UI thread
                                if (mainForm.InvokeRequired)
                                {
                                    mainForm.Invoke(new Action(() =>
                                    {
                                        mainForm.DialogResult = DialogResult.Abort;
                                        mainForm.Close();
                                    }));
                                }
                                else
                                {
                                    mainForm.DialogResult = DialogResult.Abort;
                                    mainForm.Close();
                                }
                            };

                            var result = mainForm.ShowDialog();

                            if (result == DialogResult.Abort)
                            {
                                // Ti?p t?c vòng l?p ?? hi?n th? login form
                                continue;
                            }
                        }
                    }
                }

                break;
            }
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ITraineeRepository, TraineeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGradesRepository, GradesRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IMisconductRepository, MisconductRepository>();
            services.AddScoped<ISubjectAverageRepository, SubjectAverageRepository>();
            services.AddScoped<ISemesterRepository, SemesterRepository>();
            services.AddScoped<ITraineeAverageScoreRepository, TraineeAverageScoreRepository>();
            services.AddScoped<IWeeklyCritiqueRepository, WeeklyCritiqueRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IGraduationExamScoreRepository, GraduationExamScoreRepository>();
            services.AddScoped<IGraduationScoreRepository, GraduationScoreRepository>();

            // Register validation services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddSingleton<ISessionService, SessionService>();

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
            services.AddTransient<MisconductListForm>();
            services.AddTransient<SubjectAverageListForm>();
            services.AddTransient<SemesterListForm>();
            services.AddTransient<TraineeAverageScoreListForm>();
            services.AddTransient<WeeklyCritiqueListForm>();
            services.AddTransient<GraduationExamScoreListForm>();
            services.AddTransient<GraduationScoreListForm>();
            services.AddTransient<RollCallListForm>();
        }
    }
}