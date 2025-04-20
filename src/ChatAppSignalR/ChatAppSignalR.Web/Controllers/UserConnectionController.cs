using System.Security.Claims;
using ChatAppSignalR.Service.features.IServices;
using ChatAppSignalR.Service.features.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppSignalR.Web.Controllers
{
    public class UserConnectionController : Controller
    {
        private readonly ILogger<UserConnectionController> _logger;
        private readonly IUserConnectionManagementService _userConnectionManagementService;
        private readonly IUserManagementService _userManagementService;
        public UserConnectionController(ILogger<UserConnectionController> logger, IUserConnectionManagementService userConnectionManagementService, IUserManagementService userManagementService)
        {
            _logger = logger;
            _userConnectionManagementService = userConnectionManagementService;
            _userManagementService = userManagementService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetConnectedUser()
        {
            try
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                if (string.IsNullOrEmpty(currentUserId))
                    return RedirectToAction("Login", "Account");

                var allConnectedUser = await _userConnectionManagementService.GetAllConnectedUserAsync(currentUserId);             
                return Ok(allConnectedUser); // 200 with JSON content
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users");
                return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddConnection(string newConnectionUserId, string currentUserId)
        {
            try
            {
                var newConnectionUser = await _userManagementService.GetUserAsync(newConnectionUserId);
                if(newConnectionUser == null)
                    return NotFound(new { message = "User not found" });


                await _userConnectionManagementService.AddUserConnectionAsync(currentUserId,newConnectionUserId);
                return Ok(); // 200 with JSON content
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users");
                return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
            }
        }
    }
}
