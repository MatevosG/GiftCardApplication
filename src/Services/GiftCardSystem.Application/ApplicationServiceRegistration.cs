using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GiftCard.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           
           // services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            //services.;
            //services.AddScoped(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            //services.AddScoped<IEncrypter, Encrypter>();
            //services.AddScoped<IAwsActions, AwsActions>();


            return services;
        }
    }
}