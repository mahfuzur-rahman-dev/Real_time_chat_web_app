﻿using System.Security.Claims;
using ChatAppSignalR.Models.Others;
using ChatAppSignalR.Service.features.IServices;
using ChatAppSignalR.Service.SignalHub;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppSignalR.Service.features.Services
{
    public class NotificationManagementService : INotificationManagementService
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationManagementService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }


        public async Task NotifyAllAsync(string message)
        {

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task NotifySpecificUserAsync(string reciverUserId, string message)
        {
            await _hubContext.Clients.User(reciverUserId).SendAsync("SendIndividualMessage", message);
        }
    }
}
