using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.Entities;

namespace ChatAppSignalR.Service.features.IServices
{
    public interface IUserManagementService
    {
        Task<User> GetUserAsync(string id);
        Task<IList<User>> GetAllUserAsync();
        Task AddUserAsync(User user);
    }
}
