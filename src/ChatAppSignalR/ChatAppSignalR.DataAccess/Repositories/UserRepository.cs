using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.ApplicationIdentity.Context;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Models.IRepositories;

namespace ChatAppSignalR.DataAccess.Repositories
{
    public class UserRepository : Repository<User, string>, IUserRepository
    {
        public UserRepository(ApplicationIdentityDbContext context) : base(context)
        {

        }

    }
}
