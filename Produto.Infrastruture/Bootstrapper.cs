using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Estoque.Infrastruture
{
    public static class Bootstrapper
    {
        public static IServiceCollection UseEstoquelDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContext<EstoqueDbContext>(config => config.UseSqlServer(configuration.GetConnectionString("EstoqueDbContext")));
        }
    }
}