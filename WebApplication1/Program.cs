using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры с представлениями
builder.Services.AddControllersWithViews();

var connString = builder.Configuration.GetConnectionString("BaseConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (string.IsNullOrEmpty(connString))
    {
        throw new InvalidOperationException("Строка подключения 'BaseConnection' не найдена. Проверьте appsettings.json.");
    }
    options.UseSqlServer(connString);
});


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomePage}/{id?}");


app.Run();