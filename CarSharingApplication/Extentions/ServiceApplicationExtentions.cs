using AutoMapper;
using CarSharingApplication.ApplicationUser;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Commands.CreateCarSharing;
using CarSharingApplication.CarSharing.CarSharingProfileCommands.Queries.GetAllCarSharing;
using CarSharingApplication.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.Extentions
{
    public static class ServiceApplicationExtentions
    {
        public static void AddServiceApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();

            services.AddMediatR(typeof(GetAllCarSharingQuery));
            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new CarSharingMappingProfile(userContext));
            }).CreateMapper());

            services.AddValidatorsFromAssemblyContaining<CreateCarSharingCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
