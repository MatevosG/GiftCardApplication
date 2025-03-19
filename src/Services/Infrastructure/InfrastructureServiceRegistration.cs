using GiftCardSystem.Application.Contracts;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GiftCardDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GiftCardConnection")));


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IGiftCardRepository, GiftCardRepository>();
            services.AddScoped<IGiftCardPurchaseRepository, GiftCardPurchaseRepository>();

            return services;
        }
    }
}
