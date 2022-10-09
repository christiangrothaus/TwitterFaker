using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterFaker.Models;
using System.Linq;
using System;

namespace TwitterFaker.Controllers
{
    public class BlockController : Controller
    {
        private TwitterFakerContext context { get; }

        public BlockController(Models.TwitterFakerContext context)
        {
            this.context = context;
        }
        // GET: BlocksController
        public ActionResult Index()
        {
            var blocks = context.Blocks.ToList();
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
        public IActionResult Update(Block block)
        {
            
            if (ModelState.IsValid)
            {
                if (block.BlockId == 0)
                {
                    //block.BlockId = 0;
                    context.Blocks.Add(block);
                }
                else
                    context.Blocks.Update(block);
                context.SaveChanges();
                //return RedirectToAction("Index", "Block");
            }
            return RedirectToAction("Index", "Block");
        }

        // GET: BlocksController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Update";
            if (id == 0)
                return View("Edit",null);
            Console.WriteLine(id);
            return View("Edit",context.Blocks.First(z=>z.BlockId==id));
        }

        // POST: BlocksController/Edit/5
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
