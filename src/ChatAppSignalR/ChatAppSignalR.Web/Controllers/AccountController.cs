using System.ComponentModel.DataAnnotations;
using ChatAppSignalR.ApplicationIdentity.Manager;
using ChatAppSignalR.Models.Entities;
using ChatAppSignalR.Service.features.IServices;
using ChatAppSignalR.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChatAppSignalR.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserManagementService _userManagementService;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserManagementService userManagementService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userManagementService = userManagementService;
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

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

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
                    FullName = model.FirstName+" " + model.LastName,
                    CreatedDate = DateTime.Now,
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    UserName = (model.FirstName + model.LastName).ToLower(),
                    NormalizedUserName = (model.FirstName + model.LastName).ToUpper(),
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    try
                    {
                        await _userManagementService.AddUserAsync(new User
                        {
                            IdentityUserId = user.Id,
                            FullName = user.FullName
                        });

                        return RedirectToAction("Login", "Account");
                    }
                    catch (Exception ex)
                    {
                        // Rollback Identity user creation if custom user add failed
                        await _userManager.DeleteAsync(user);

                        // Optional: log the error
                        ModelState.AddModelError("", "Account creation failed. Please try again.");
                        return View(model);
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
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


        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Something went wrong.");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { email = user.Email });
                }

            }
            return View(model);
        }

        public IActionResult ChangePassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordViewModel { Email = email });
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.RemovePasswordAsync(user);
                    if (result.Succeeded)
                    {
                        result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found!");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong. try again.");
                return View(model);
            }
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
