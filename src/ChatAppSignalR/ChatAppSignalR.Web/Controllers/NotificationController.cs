using ChatAppSignalR.Models.Others;
using ChatAppSignalR.Service.features.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppSignalR.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationManagementService _notificationManagementService;
        public NotificationController(ILogger<NotificationController> logger, INotificationManagementService notificationManagementService)
        {
            _logger = logger;
            _notificationManagementService = notificationManagementService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SendNotification(string title, string message, string userId)
        {
            var notification = new Notification { Title = title, UserId = userId, Message = message };

            await _notificationManagementService.NotifyAllAsync();


            return RedirectToAction(nameof(SendNotification));
        }

    }
}
