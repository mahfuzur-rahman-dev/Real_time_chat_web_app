using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChatAppSignalR.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using ChatAppSignalR.DataAccess.Others;
using ChatAppSignalR.Models.Others;

namespace ChatAppSignalR.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHubContext<NotificationHub> _hubContext;

    public HomeController(ILogger<HomeController> logger, IHubContext<NotificationHub> hubContext)
    {
        _logger = logger;
        _hubContext = hubContext;
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
