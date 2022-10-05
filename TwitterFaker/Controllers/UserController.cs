using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TwitterFaker.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;

namespace TwitterFaker.Controllers
{
    public class UserController : Controller
    {
        private readonly string homePath = "~/Views/Home/Index.cshtml";
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(homePath);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);
                return View(homePath);
            }
            else
            {
                ModelState.AddModelError("InvalidEntry", "Invalid Username or Password");
            }
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(string username, string password, string passwordConfirmation)
        {
            if (password == passwordConfirmation)
            { 
                var user = new IdentityUser { UserName = username };
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return View(homePath);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            else
            {
                ModelState.AddModelError("PasswordMatch", "Passwords did not match");
            }
            return View("Register");
        }

        public IActionResult Logout()
        {
            return View(homePath);        
        }
    }
}
