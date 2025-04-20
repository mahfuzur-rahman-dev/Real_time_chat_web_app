using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.IRepositories;

namespace ChatAppSignalR.Models
{
    public interface IUnitOfWork
    {
         IUserRepository Users { get; }
         IUserConnectionRepository UserConnections { get; }


        Task SaveAsync();
    }
}
