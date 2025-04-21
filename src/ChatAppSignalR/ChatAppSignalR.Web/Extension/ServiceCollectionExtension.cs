using ChatAppSignalR.ApplicationIdentity.Context;
using ChatAppSignalR.ApplicationIdentity.Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChatAppSignalR.Web.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaeConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringTemplate = configuration.GetConnectionString("DataBaseConnection");

            // Replace placeholders with actual environment variables
            var connectionString = connectionStringTemplate
                .Replace("${DB_SERVER}", Environment.GetEnvironmentVariable("DB_SERVER"))
                .Replace("${DB_NAME}", Environment.GetEnvironmentVariable("DB_NAME"));

            services.AddDbContext<ApplicationIdentityDbContext>(dbContextOptions => dbContextOptions.UseSqlServer(connectionString));

            var x = connectionString;

            return services;
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 6;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedAccount = false;
                }
            )
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>().
                AddDefaultTokenProviders();

            return services;
        }
    }
}
