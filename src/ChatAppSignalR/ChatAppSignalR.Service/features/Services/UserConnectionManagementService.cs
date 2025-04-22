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
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                ConnectedUserId = connectedUserId,
                ConnectedOn = DateTime.UtcNow
            };

            try
            {
                await _unitOfWork.UserConnections.AddAsync(connectedUser);
            }
            catch(Exception ex)
            {
                var x = ex;
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task<IList<User>> GetAllConnectedUserAsync(string userId)
        {
            var connectedUsers = new List<User>();

            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.");
            try
            {
                var connectedUserConnections = await _unitOfWork.UserConnections
                .GetAllAsync(uc => uc.UserId == userId);


                if (connectedUserConnections.Any())
                {
                    foreach (var connection in connectedUserConnections)
                    {
                        var connectedUser = await _unitOfWork.Users
                            .GetAllAsync(u => u.IdentityUserId == connection.ConnectedUserId);
                        if (connectedUser != null)
                        {
                            connectedUsers.AddRange(connectedUser);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return connectedUsers;

            
        }
    }
}
