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
    public async Task<IActionResult> Index(string userId)
    {
        if(string.IsNullOrEmpty(userId))
            return RedirectToAction("Logout", "Account");

        var user = await _userManagementService.GetUserAsync(userId);
        if(user is null)
            return RedirectToAction("Logout", "Account");
            
        return View(user);
    }



    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
