using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TorneioDeLuta.Application.Interfaces;
using TorneioDeLuta.Application.Services;
using TorneioDeLuta.Domain.Interface;
using TorneioDeLuta.Infrastructure.Context;
using TorneioDeLuta.Infrastructure.Service;

namespace TorneioDeLuta.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<ITorneioService, TorneioService>();
            services.AddScoped<ITorneioAplicationService, TorneioAplicationService>();
            return services;
        }
    }
}
