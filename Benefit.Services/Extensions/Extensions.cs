using Benefit.DataAccessLayer;
using Benefit.Services.Interfaces;
using Benefit.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
