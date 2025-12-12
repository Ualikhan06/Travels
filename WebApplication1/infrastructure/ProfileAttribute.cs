using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
namespace WebApplication1.Infrastructure
{
    public class ProfileAttribute : ActionFilterAttribute
    {
        private Stopwatch timer;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Создаём и запускаем таймер
            timer = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Останавливаем таймер
            timer.Stop();

            string message = $"На выполнение метода {context.ActionDescriptor.DisplayName} затрачено {timer.Elapsed}";

            // Записываем в файл
            string logFolder = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            string logPath = Path.Combine(logFolder, "log.txt");
            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
