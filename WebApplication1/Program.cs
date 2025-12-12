using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication1.Context;
using WebApplication1.Crypt;
using WebApplication1.Infrastructure;
using WebApplication1.Models;


var builder = WebApplication.CreateBuilder(args);

// Добавляем контроллеры с представлениями
builder.Services.AddControllersWithViews();

var baseConnString = builder.Configuration.GetConnectionString("BaseConnection");


builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/RegistrationUser/Login"; // Куда перенаправлять при попытке доступа без входа
        options.AccessDeniedPath = "/RegistrationUser/AccessDenied"; // Куда перенаправлять при недостатке прав
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Время жизни куки
    });
// 2. Регистрация AppDbContext (Использует BaseConnection)
builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseSqlServer(baseConnString);
});

builder.Services.AddScoped<ProfileAttribute>(); // Регистрируем фильтр в DI

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<ProfileAttribute>(); // Глобально
});


builder.Services.AddScoped<CryptPass>();

builder.Services.AddDbContext<DbUser>(options =>
{
    if (string.IsNullOrEmpty(baseConnString))
    {

        throw new InvalidOperationException("Строка подключения 'BaseConnection' не найдена. Проверьте appsettings.json.");
    }
    options.UseSqlServer(baseConnString);
});



var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();

// middleware логирования запросов 
app.Use(async (context, next) =>
{
    // время начала выполнения запроса
    var timer = new Stopwatch();
    timer.Start();


    await next();

    // останавливаем таймер
    timer.Stop();

    // затраченное время
    Debug.WriteLine($"Запрос: {context.Request.Method} {context.Request.Path} | Статус: {context.Response.StatusCode} | Время: {timer.ElapsedMilliseconds} мс");
});





app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomePage}/{id?}");


app.Run();