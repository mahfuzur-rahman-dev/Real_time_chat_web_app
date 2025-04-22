using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.ApplicationIdentity.Context;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Models.IRepositories;
using ChatAppSignalR.Models.Others;

namespace ChatAppSignalR.DataAccess.Repositories
{
    public class UserConnectionRepository : Repository<UserConnection, string>, IUserConnectionRepository
    {
        public UserConnectionRepository(ApplicationIdentityDbContext context) : base(context)
        {

        }

    }
}
