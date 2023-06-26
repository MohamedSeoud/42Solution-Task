using App.Domain.IUnitofWork;
using App.Persentation.ServicesManager;
using App.Persentation.UnitofWork;
using App.Services.Abstractions.IServicesManager;

namespace AKILA.Web.Host.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
            => services
               .AddScoped<IUnitofwork, UnitofWork>()
                .AddScoped<ISecurityServiceManager, SecurityServiceManager>()
         .AddScoped<IFinanceServiceManager, FinanceServiceManager>();
    }
}
