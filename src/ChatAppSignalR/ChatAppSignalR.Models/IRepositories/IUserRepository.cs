using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.Entities;

namespace ChatAppSignalR.Models.IRepositories
{
    public interface IUserRepository : IRepositoryBase<User,string>
    {
    }
}
