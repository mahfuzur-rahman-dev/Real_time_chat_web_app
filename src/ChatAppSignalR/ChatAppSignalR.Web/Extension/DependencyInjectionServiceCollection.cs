using ChatAppSignalR.ApplicationIdentity.Context;
using ChatAppSignalR.ApplicationIdentity.Manager;
using ChatAppSignalR.DataAccess;
using ChatAppSignalR.DataAccess.Repositories;
using ChatAppSignalR.Models;
using ChatAppSignalR.Models.IRepositories;
using ChatAppSignalR.Service.features.IServices;
using ChatAppSignalR.Service.features.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChatAppSignalR.Web.Extension
{
    public static class DependencyInjectionServiceCollection
    {
       
        public static IServiceCollection AddServiceForDI(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserManagementService, UserManagementService>();
            services.AddScoped<INotificationManagementService,NotificationManagementService>();
            services.AddScoped<IUserConnectionManagementService, UserConnectionManagementService>();

            return services;
        }
    }
}
