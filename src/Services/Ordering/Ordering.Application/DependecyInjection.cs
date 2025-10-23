using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
