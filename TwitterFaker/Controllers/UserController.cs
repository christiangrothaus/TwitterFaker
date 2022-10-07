using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TwitterFaker.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("InvalidEntry", "Invalid username or password.");
            }
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(string username, string password, string passwordConfirmation)
        {
            if (password == passwordConfirmation)
            {
                IdentityUser newUser = new IdentityUser { UserName = username, Email = username };
                var result = await _userManager.CreateAsync(newUser, password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.PasswordSignInAsync(username, password, true, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            else
            {
                ModelState.AddModelError("PasswordMatch", "Passwords did not match.");
            }
            return View("Register");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string username)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            if (username == user.UserName)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            else
            {
                ModelState.AddModelError("UsernameMatch", "Username did not match current user.");
                return View("Settings");
            }
            return View("Settings");
        }
    }
}
