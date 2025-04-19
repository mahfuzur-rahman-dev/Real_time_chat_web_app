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

        public UserController(ILogger<UserController> logger, IUserManagementService userManagementService)
        {
            _logger = logger;
            _userManagementService = userManagementService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var users = await _userManagementService.GetAllUserAsync();
                var usersWithoutMe = users.Where(u => u.IdentityUserId != currentUserId).ToList();

                return Ok(usersWithoutMe); // 200 with JSON content
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users");
                return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddConnection(string newConnectionUserId,string currentUserId)
        {
            try
            {
              
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
