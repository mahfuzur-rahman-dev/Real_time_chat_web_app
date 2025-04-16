using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChatAppSignalR.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using ChatAppSignalR.Models.Others;
using ChatAppSignalR.Service.features.IServices;
using ChatAppSignalR.Models.Entities;
using System.Threading.Tasks;

namespace ChatAppSignalR.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserManagementService _userManagementService;
    private readonly INotificationManagementService _notificationManagementService;


    public HomeController(ILogger<HomeController> logger, IUserManagementService userManagementService, INotificationManagementService notificationManagementService)
    {
        _logger = logger;
        _userManagementService = userManagementService;
        _notificationManagementService = notificationManagementService;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> Privacy()
    {
        return View();
    }


    [Authorize]
    public IActionResult SendNotification()
    {
        return View();
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllUser()  // Changed return type to JsonResult
    {
        try
        {
            var users = await _userManagementService.GetAllUserAsync();
            return Json(users);  // Explicitly return as JSON
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching users");
            return Json(new List<User>());  // Return empty list in case of error
        }
    }


    [Authorize]
    [HttpPost]
    public async Task<IActionResult> SendNotification(string title, string message, string userId)
    {
        var notification = new Notification { Title = title, UserId= userId, Message = message };

        await _notificationManagementService.NotifyAllAsync();


        return RedirectToAction(nameof(SendNotification));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
