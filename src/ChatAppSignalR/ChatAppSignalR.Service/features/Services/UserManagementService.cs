using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Service.features.IServices;

namespace ChatAppSignalR.Service.features.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUserAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<User>> GetAllUserAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }
    }
}
