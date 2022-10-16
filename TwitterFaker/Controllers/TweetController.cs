using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Tweet() { Likes = 0,Retweets=0,QuoteTweets=0 }) ;
        }

        [HttpPost]
        public async Task<IActionResult> Update(Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                tweet.User = await userManager.GetUserAsync(User);
                if (tweet.TweetId == 0)
                {
                    context.Tweets.Add(tweet);
                }
                else
                {
                    Console.WriteLine("Tweet Picture: "+tweet.Picture);
                    context.Tweets.Update(tweet);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Tweet");
            }
            else
            {
                ViewBag.Action = (tweet.TweetId == 0) ? "Add" : "Update";
                return View("Edit", tweet);
            }

        }
        // GET: BlocksController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            ViewBag.Action = "Update";
            if (id == 0)
            {
                //throw new NotImplementedException();
                return View("Edit", new Tweet());

            }

            //ModelState.Clear();

            var block = GetTweetByID(id);
            //Console.WriteLine("edit isblock: " + block.IsBlock);
            return View("Edit", block);
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
        
        public Tweet GetTweetByID(int id)
        {
            return context.Tweets.FirstOrDefault(e => e.TweetId == id);
        }
    }
}
