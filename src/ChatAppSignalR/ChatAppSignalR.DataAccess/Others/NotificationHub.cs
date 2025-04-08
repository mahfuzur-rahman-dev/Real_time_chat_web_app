using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.Others;
using Microsoft.AspNetCore.SignalR;

namespace ChatAppSignalR.DataAccess.Others
{
    public class NotificationHub : Hub
    {
        public async Task NotifyAll(Notification notification)
        {
            await Clients.All.SendAsync("SendNotification",notification);
        }
    }
}
