using Benefit.Cache;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benefit.DataAccessLayer.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection CreateSqlRepository(this IServiceCollection services, ICacheService cacheService, string connectionString)            
        {
            services.AddSingleton<IBenefitRepository>(serviceProvider =>
            {
                return new BenefitRepository(cacheService, connectionString);
            });

            return services;
        }
    }
}
