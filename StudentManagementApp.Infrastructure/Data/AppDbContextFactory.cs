using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace StudentManagementApp.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Đường dẫn đến thư mục gốc của project
            var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"));

            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;

            var databasePath = Path.Combine(basePath, connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite($"Data Source={databasePath}");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
