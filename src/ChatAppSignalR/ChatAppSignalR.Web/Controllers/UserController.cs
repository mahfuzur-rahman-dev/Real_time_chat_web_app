using System.Security.Claims;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Service.features.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppSignalR.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManagementService _userManagementService;
        private readonly IUserConnectionManagementService _userConnectionManagementService;

        public UserController(ILogger<UserController> logger, IUserManagementService userManagementService, IUserConnectionManagementService userConnectionManagementService)
        {
            _logger = logger;
            _userManagementService = userManagementService;
            _userConnectionManagementService = userConnectionManagementService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var currentUserId = await GetCurrentUserId();
                if (string.IsNullOrEmpty(currentUserId))
                    return RedirectToAction("Login", "Account");

                var users = await _userManagementService.GetAllUserAsync();
                var usersWithoutMe = users.Where(u => u.IdentityUserId != currentUserId).ToList();

                if (usersWithoutMe == null || !usersWithoutMe.Any())
                    return NotFound(new { message = "No users found" });

                var connectedUsers = await _userConnectionManagementService.GetAllConnectedUserAsync(currentUserId);
                var connectedUserIds = connectedUsers.Select(c => c.IdentityUserId).ToHashSet();

                var nonConnectedUsers = usersWithoutMe
                    .Where(u => !connectedUserIds.Contains(u.IdentityUserId))
                    .ToList();

                return Ok(nonConnectedUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users");
                return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
            }
        }



        [Authorize]
        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            try
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching user ID");
                return "Internal Server Error";
            }
        }

    }
}
