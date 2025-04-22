using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Models.Others;

namespace ChatAppSignalR.Service.features.IServices
{
    public interface IUserConnectionManagementService
    {        
        Task AddUserConnectionAsync(string userId, string connectedUserId);
        Task<IList<User>> GetAllConnectedUserAsync(string userId);
    }
}
