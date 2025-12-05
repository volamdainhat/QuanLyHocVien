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
using StudentManagementApp.UI.Forms.CRUD.Gradeses;
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
            // Ghi log khi ứng dụng bắt đầu
            // File.WriteAllText("startup_log.txt", $"{DateTime.Now}: Application starting...");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                var ex = (Exception)e.ExceptionObject;
                File.WriteAllText($"crash_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
                    $"UNHANDLED EXCEPTION:\n{ex}");
                MessageBox.Show($"Critical error: {ex.Message}");
            };

            try
            {
                // TestDatabaseConnection();

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
            catch (Exception ex)
            {
                File.WriteAllText($"startup_error_{DateTime.Now:yyyyMMdd_HHmmss}.txt",
                    $"STARTUP ERROR:\n{ex}");
                MessageBox.Show($"Startup failed: {ex.Message}\n\nCheck error log file.",
                    "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Hàm trích xuất tên database file từ connection string
        static string ExtractDatabaseFileName(string connectionString)
        {
            // Tìm "Data Source=" trong connection string
            var dataSourceKey = "Data Source=";
            var dataSourceIndex = connectionString.IndexOf(dataSourceKey, StringComparison.OrdinalIgnoreCase);

            if (dataSourceIndex >= 0)
            {
                // Lấy phần sau "Data Source="
                var dbPath = connectionString.Substring(dataSourceIndex + dataSourceKey.Length);

                // Loại bỏ các tham số phía sau (nếu có)
                var semicolonIndex = dbPath.IndexOf(';');
                if (semicolonIndex >= 0)
                {
                    dbPath = dbPath.Substring(0, semicolonIndex);
                }

                // Chỉ lấy tên file (loại bỏ đường dẫn nếu có)
                return Path.GetFileName(dbPath);
            }

            // Nếu không tìm thấy "Data Source=", coi toàn bộ connection string là tên file
            return Path.GetFileName(connectionString) ?? "StudentManagementDB.db";
        }

        static void ConfigureServices(ServiceCollection services)
        {
            // Lấy thư mục chứa ứng dụng (nơi chứa EXE/DLL)
            var basePath = Directory.GetCurrentDirectory();

            // Đọc connection string từ App.config
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            string databasePath;

            if (!string.IsNullOrEmpty(connectionString))
            {
                // Trích xuất tên file database từ connection string
                string dbName = ExtractDatabaseFileName(connectionString);
                databasePath = Path.Combine(basePath, dbName);
            }
            else
            {
                // Fallback nếu không có connection string
                databasePath = Path.Combine(basePath, "StudentManagementDB.db");
            }

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={databasePath}"));

            //var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            //// Read connection string from App.config
            //var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            //var databasePath = Path.Combine(basePath, connectionString);

            //if (string.IsNullOrEmpty(connectionString))
            //{
            //    // Fallback
            //    connectionString = "Data Source=StudentManagementDB.db";
            //}

            //services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));

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
            services.AddScoped<IPracticePointRepository, PracticePointRepository>();
            services.AddScoped<IRollCallRepository, RollCallRepository>();

            // Register validation services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<ExcelExportService>();
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
            services.AddTransient<PracticePointListForm>();
            services.AddTransient<ReportListForm>();
            services.AddTransient<BulkAddGradesForm>();
        }
    }
}