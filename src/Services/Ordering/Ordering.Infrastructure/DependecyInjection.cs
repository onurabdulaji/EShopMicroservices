﻿namespace Ordering.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.AddInterceptors(new AuditableEntityInterceptor());
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
