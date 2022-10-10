using Microsoft.AspNetCore.Mvc;
using TwitterFaker.Models;

namespace TwitterFaker.Controllers
{
    public class ReplyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            ViewBag.Action = "Create";
            return View("Edit", new ReplyChain());
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
            }
            else
            {
            }
            return View("Edit");
        }


        public IActionResult Update()
        {
            return View("Index");
        }
    }
}
