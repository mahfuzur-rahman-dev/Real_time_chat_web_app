using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Models.Others;
using ChatAppSignalR.Service.features.IServices;

namespace ChatAppSignalR.Service.features.Services
{
    public class UserConnectionManagementService : IUserConnectionManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserConnectionManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUserConnectionAsync(string userId, string connectedUserId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(connectedUserId))
                throw new ArgumentException("User ID and Connected User ID cannot be null or empty.");

            // Check if the connection already exists
            var existingConnection = await _unitOfWork.UserConnections
                .GetAllAsync(uc => uc.UserId == userId && uc.ConnectedUserId == connectedUserId);

            if (existingConnection.Any())
                throw new InvalidOperationException("Connection already exists.");

            var connectedUser = new UserConnection
            {
                UserId = userId,
                ConnectedUserId = connectedUserId,
                ConnectedOn = DateTime.UtcNow
            };
            await _unitOfWork.UserConnections.AddAsync(connectedUser);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<UserConnection>> GetAllConnectedUserAsync(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.");
            try
            {
                var connectedUsers = await _unitOfWork.UserConnections
                .GetAllAsync(uc => uc.UserId == userId);
            }
            catch(Exception ex)
            {

            }

            return null;

            
        }
    }
}
