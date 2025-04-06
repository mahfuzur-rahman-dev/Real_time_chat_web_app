using ChatAppSignalR.ApplicationIdentity.Context;
using Microsoft.EntityFrameworkCore;

namespace ChatAppSignalR.Web.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaeConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(dbContextOptions => dbContextOptions.UseSqlServer(configuration.GetConnectionString("DataBaseConnection")));

            return services;
        }
    }
}
