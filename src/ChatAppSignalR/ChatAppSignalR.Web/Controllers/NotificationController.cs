using ChatAppSignalR.Models.Others;
using ChatAppSignalR.Service.features.IServices;
using ChatAppSignalR.Service.features.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<IActionResult> SendNotificationToAll(string message  /*string senderUserId, string reciverUserId*/)
        {
            
            if(message is null || message.IsNullOrEmpty())
                return BadRequest(new { message = "Message cannot be null or empty" });

            try
            {
                var notification = new Notification { Title = "title", UserId = Guid.NewGuid().ToString(), Message = message };
                await _notificationManagementService.NotifyAllAsync(message);
                return Ok(new { message = "Success" }); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending message");
                return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
            }
        }

    }
}
