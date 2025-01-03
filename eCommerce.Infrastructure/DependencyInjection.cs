using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Infrastructure;
public static class DependencyInjection
{
    /// <summary>
    ///  Extension method to add infrastructure services
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // TODO: Add infrastructure services to IOC container

        services.AddTransient<IUsersRepository, UserRepository>();
        services.AddTransient<DapperDbContext>();

        return services;
    }
}
