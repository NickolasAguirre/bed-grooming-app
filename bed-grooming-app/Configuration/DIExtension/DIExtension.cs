using bed_grooming_app.application.UseCases.Service;
using bed_grooming_app.domain.Repositories;
using bed_grooming_app.infrastructure.Repositories.Service.SQLServer;

namespace bed_grooming_app.Configuration.DIExtension
{
    public static class DIExtension
    {
        public static IServiceCollection AddDIExtension(this IServiceCollection services, IConfiguration configuration)
        {
            // Register services here
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IServiceUseCase, ServiceUseCase>();
            return services;
        }
    }
}
