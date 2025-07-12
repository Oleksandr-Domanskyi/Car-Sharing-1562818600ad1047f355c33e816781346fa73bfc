using CarSharingDomain.Interfaces;
using CarSharingInfrastructure.Database;
using CarSharingInfrastructure.Repositories;
using CarSharingInfrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingInfrastructure.Extentions
{
    public static class ServiceCollectionsExtentions
    {
        public static void AddInfrastrucure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CarSharingDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarSharingConnectionString")));


            service.AddScoped<ICarSharingRepositories, CarSharingRepositories>();

            service.AddScoped<CarSharingSeeder>();

            service.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CarSharingDbContext>();
        }
    }
}
