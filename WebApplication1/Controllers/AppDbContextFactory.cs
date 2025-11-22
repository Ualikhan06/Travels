using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApplication1.Models;

// Фабрика должна находиться в проекте, где определен AppDbContext
namespace WebApplication1
{
    // Класс должен реализовывать IDesignTimeDbContextFactory
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1. Считываем файл appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 2. Получаем строку подключения
            var connectionString = configuration.GetConnectionString("BaseConnection");

            // 3. Создаем OptionsBuilder и используем строку подключения SQL Server
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer(connectionString);

            // 4. Возвращаем новый экземпляр контекста
            return new AppDbContext(builder.Options);
        }
    }
}