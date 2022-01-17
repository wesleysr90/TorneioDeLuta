using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioDeLuta.Application.Mappings;

namespace TorneioDeLuta.WebApplication.MappingConfig
{
    public static class AutoMapperConfig
    {
        public  static void AutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
            
        }
    }
}
