using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Services
{
    public static class Bootstrapper
    {
        public static IServiceCollection UseServicesHandlers(this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(Bootstrapper).Assembly);
        }
    }
}