using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ChatAppSignalR.Models.Others;

namespace ChatAppSignalR.Service.features.IServices
{
    public interface INotificationManagementService
    {
        Task NotifyAllAsync(string message);
        Task NotifySpecificUserAsync(string reciverUserId, string message);
    }
}
