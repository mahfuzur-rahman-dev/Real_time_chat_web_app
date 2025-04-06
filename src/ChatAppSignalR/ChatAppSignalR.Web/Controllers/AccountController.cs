using System.ComponentModel.DataAnnotations;
using ChatAppSignalR.ApplicationIdentity.Manager;
using ChatAppSignalR.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppSignalR.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _sigInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> sigInManager, UserManager<ApplicationUser> userManager)
        {
            _sigInManager = sigInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Check if the identifier is an email or username
            var isEmail = new EmailAddressAttribute().IsValid(model.Email);

            // Find user based on identifier
            ApplicationUser user = null;
            if (isEmail)
            {
                user = await _userManager.FindByEmailAsync(model.Email);
            }
            else
            {
                user = await _userManager.FindByNameAsync(model.Email);
            }

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var result = await _sigInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    FullName = model.FirstName + model.LastName,
                    CreatedDate = DateTime.Now,
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    UserName = (model.FirstName + model.LastName).ToLower(),
                    NormalizedUserName = (model.FirstName + model.LastName).ToUpper(),
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }

            return View(model);
        }


        public IActionResult VerifyEmail()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
