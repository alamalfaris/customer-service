using customer_service.Repositories;

namespace customer_service.Helpers
{
    public static class MiddlewareHelper
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<DapperContext>();
            
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IRepository, RepositoryWrapper>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();
        }
    }
}
