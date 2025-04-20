using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Models.Others;

namespace ChatAppSignalR.Models.IRepositories
{
    public interface IUserConnectionRepository : IRepositoryBase<UserConnection,string>
    {
    }
}
