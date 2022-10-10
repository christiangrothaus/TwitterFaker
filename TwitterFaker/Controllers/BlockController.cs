using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterFaker.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace TwitterFaker.Controllers
{
    public class BlockController : Controller
    {
        private TwitterFakerContext context { get; }
        private readonly UserManager<IdentityUser> userManager;

        public BlockController(TwitterFakerContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        // GET: BlocksController
        public async Task<ActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            //userManager.GetUserId(user.)
            var blocks = context.Blocks.Where(z=>z.User.Id==user.Id).ToList();
            return View(blocks);
        }

        // GET: BlocksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlocksController/Create
        public ActionResult Create()
        {
            return View();
        }

      /*  // POST: BlocksController/Create
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
        }*/

        [HttpPost]
        public async Task<IActionResult> Update(Block block)
        {
            if (ModelState.IsValid)
            {
                block.User = await userManager.GetUserAsync(User);
                if (block.BlockId == 0)
                {
                    //block.BlockId = 0;
                    context.Blocks.Add(block);
                }
                else
                {
                    Console.WriteLine("IS BLOCK:" + block.IsBlock);
                    context.Blocks.Update(block);
                }
                context.SaveChanges();
                //return RedirectToAction("Index", "Block");
            }
            return RedirectToAction("Index", "Block");
        }

        // GET: BlocksController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Console.WriteLine(id);
            ViewBag.Action = "Update";
            if (id == 0)
            {
                //throw new NotImplementedException();
                return View("Edit", new Block() { });

            }
            
            ModelState.Clear();
            
            var block = context.Blocks.First(z => z.BlockId == id);
            Console.WriteLine("edit isblock: " + block.IsBlock);
            return View("Edit",block);
        }

        // POST: BlocksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            throw new NotImplementedException();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlocksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit",new Block());
        }

        // POST: BlocksController/Delete/5
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
