using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TwitterFaker.Models;

namespace TwitterFaker.Controllers
{
    public class TweetController : Controller
    {
        private TwitterFakerContext context { get; }
        private readonly UserManager<IdentityUser> userManager;

        public TweetController(TwitterFakerContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        // GET: TweetController
        public async Task<ActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var tweets = context.Tweets.Where(z => z.User.Id == user.Id).ToList();
            return View(tweets);
        }

        // GET: TweetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TweetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TweetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TweetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TweetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TweetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TweetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
