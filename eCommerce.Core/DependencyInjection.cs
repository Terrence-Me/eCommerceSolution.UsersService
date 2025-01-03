using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Core;
public static class DependencyInjection
{
    /// <summary>
    ///  Extension method to add core services
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>

    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // TODO: Add infrastructure services to IOC container

        services.AddTransient<IUsersService, UsersService>(); // Add the service here
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();

        return services;
    }
}
