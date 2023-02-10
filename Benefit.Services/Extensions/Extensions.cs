using Benefit.DataAccessLayer;
using Benefit.Services.Interfaces;
using Benefit.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Benefit.Services.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection CreateBenefitService(this IServiceCollection services, IBenefitRepository repository)            
        {
            services.AddSingleton<IBenefitService>(serviceProvider =>
            {
                return new BenefitService(repository);
            });

            return services;
        }
    }
}
