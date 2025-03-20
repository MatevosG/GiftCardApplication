using GiftCardSystem.Application.Authorization;
using GiftCardSystem.Application.Security;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GiftCard.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IEncrypter, Encrypter>();
            services.AddScoped<IAuthentication, Authentication>();
            return services;
        }
    }
}