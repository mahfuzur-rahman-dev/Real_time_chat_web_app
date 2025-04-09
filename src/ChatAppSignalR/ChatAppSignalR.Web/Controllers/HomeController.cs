using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChatAppSignalR.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using ChatAppSignalR.DataAccess.Others;
using ChatAppSignalR.Models.Others;
using ChatAppSignalR.Service.features.IServices;
using ChatAppSignalR.Models.Entities;

namespace ChatAppSignalR.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly IUserManagementService _userManagementService;

    public HomeController(ILogger<HomeController> logger, IHubContext<NotificationHub> hubContext, IUserManagementService userManagementService)
    {
        _logger = logger;
        _hubContext = hubContext;
        _userManagementService = userManagementService;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }


    [Authorize]
    public IActionResult SendNotification()
    {
        return View();
    }


    public IActionResult GetAllUserAsync()  // Changed return type to JsonResult
    {
        //try
        //{
        //    var users = await _userManagementService.GetAllUserAsync();
        //    return Json(users);  // Explicitly return as JSON
        //}
        //catch (Exception ex)
        //{
        //    _logger.LogError(ex, "Error fetching users");
        //    return Json(new List<User>());  // Return empty list in case of error
        //}

        return Json("");
    }


    [Authorize]
    [HttpPost]
    public async Task<IActionResult> SendNotification(string title, string message, string userId)
    {
        var notification = new Notification { Title = title, UserId= userId, Message = message };
        await _hubContext.Clients.All.SendAsync("SendNotification", notification);
        return RedirectToAction(nameof(SendNotification));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
