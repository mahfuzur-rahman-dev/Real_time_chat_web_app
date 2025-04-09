using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.ApplicationIdentity.Manager;
using ChatAppSignalR.ApplicationIdentity.Others;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatAppSignalR.ApplicationIdentity.Context
{
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserConnection>()
                .HasKey(uc => uc.Id);

            builder.Entity<UserConnection>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.Connections)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserConnection>()
                .HasOne(uc => uc.ConnectedUser)
                .WithMany(u => u.ConnectedToMe)
                .HasForeignKey(uc => uc.ConnectedUserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
