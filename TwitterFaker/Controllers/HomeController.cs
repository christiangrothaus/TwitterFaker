using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using TwitterFaker.Models;
using static TwitterFaker.Services.PictureConverter;

namespace TwitterFaker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TwitterFakerContext _twitterFakerContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, TwitterFakerContext twitterFakerContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _twitterFakerContext = twitterFakerContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tweets()
        {
            return View();
        }

        public IActionResult Replies()
        {
            return View();
        }

        public IActionResult Blocks()
        {
            return View();
        }

        public IActionResult Suspensions()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveTweet(Tweet tweet, IFormFile profilePicture, IFormFile picture, int themeRadios, int fontRadios)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError("NoUser", "Sign in to save the tweet.");
            }
            else
            {
                if (profilePicture != null)
                {
                    tweet.ProfilePicture = IFormFileToBase64(profilePicture);
                }
                if (picture != null)
                {
                    tweet.Picture = IFormFileToBase64(picture);
                }
                tweet.Font = fontRadios;
                tweet.Theme = themeRadios;
                tweet.User = user;
            _twitterFakerContext.Tweets.Add(tweet);
            _twitterFakerContext.SaveChanges();
            }
            return View("Tweets");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
