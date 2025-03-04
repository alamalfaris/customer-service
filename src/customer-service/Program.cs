global using customer_service.Helpers;
global using customer_service.Models;
global using customer_service.Interfaces;

namespace customer_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            MiddlewareHelper.ConfigureServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseExceptionHandler();

            app.MapControllers();

            app.Run();
        }
    }
}
