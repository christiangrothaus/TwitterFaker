using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterFaker.Models;
using TwitterFaker.Services;

namespace TwitterFaker.Controllers
{
    public class ReplyController : Controller
    {
        private readonly ILogger<ReplyController> _logger;
        private readonly TwitterFakerContext _twitterFakerContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ReplyController(ILogger<ReplyController> logger, TwitterFakerContext twitterFakerContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _twitterFakerContext = twitterFakerContext;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<ReplyChain> replyChains;
            IdentityUser user = await _userManager.GetUserAsync(User);
            try 
            { 
                replyChains = await _twitterFakerContext.ReplyChains.Where(rc => rc.User.Id == user.Id).ToListAsync();
                foreach (ReplyChain replyChain in replyChains)
                {
                    List<Reply> replies = await _twitterFakerContext.Replys.Where(r => r.ReplyChain == replyChain).ToListAsync();
                    replyChain.Replies = replies;
                }
            }
            catch (Exception e)
            {
                replyChains = new List<ReplyChain>();
            }
            return View(replyChains);
        }

        public IActionResult Add()
        {
            List<Reply> replies = new List<Reply>() { new Reply { Verified = false }, new Reply { Verified = false } };
            ViewBag.Action = "Create";
            return View("Edit", new ReplyChain { Replies = replies});
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReplyChain replyChain, int themeRadios, int fontRadios, IFormCollection formCollection)
        {
            IdentityUser user = await _userManager.GetUserAsync(User);
            if (user == null) {
                ModelState.AddModelError("NoUser", "Sign in to save the reply chain.");
                return View(replyChain);
            }
            else
            {
                replyChain.Theme = themeRadios;
                replyChain.Font = fontRadios;
                replyChain.User = user;

                foreach (FormFile picture in formCollection.Files)
                {
                    string pictureName = picture.Name;
                    int index = int.Parse(pictureName[^1].ToString()) - 1;
                    replyChain.Replies[index].ProfilePicture = PictureConverter.IFormFileToBase64(picture);
                }

                if (replyChain.ReplyChainId == 0)
                {
                    try 
                    {

                    _twitterFakerContext.ReplyChains.Add(replyChain);
                    _twitterFakerContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        ViewBag.Action = "Create";
                        return View(replyChain);
                    }
                }
                else
                {
                    try { 
                    List<Reply> repliesToRemove = new List<Reply>();
                    foreach (Reply reply in replyChain.Replies)
                    {
                        if (reply.DisplayName == null) {
                            repliesToRemove.Add(reply);
                        }
                    }
                    foreach (Reply reply in repliesToRemove)
                    {
                        replyChain.Replies.Remove(reply);
                    }
                    List<Reply> repliesToDelete = _twitterFakerContext.Replys.Where(r => !replyChain.Replies.Contains(r) && r.ReplyChain.ReplyChainId == replyChain.ReplyChainId).ToList();
                    _twitterFakerContext.Replys.RemoveRange(repliesToDelete);
                    _twitterFakerContext.ReplyChains.Update(replyChain);
                    _twitterFakerContext.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        ViewBag.Action = "Update";
                        return View(replyChain);
                    }
                }
            }
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Action = "Update";
            ReplyChain replyChain = _twitterFakerContext.ReplyChains.Where(rc => rc.ReplyChainId == id).First();
            List<Reply> replies = await _twitterFakerContext.Replys.Where(r => r.ReplyChain == replyChain).ToListAsync();
            replyChain.Replies = replies;
            return View("Edit", replyChain);
        }

        public IActionResult Delete(int id)
        {
            ReplyChain replyChain = _twitterFakerContext.ReplyChains.Where(rc => rc.ReplyChainId == id).First();
            try
            {
                _twitterFakerContext.ReplyChains.Remove(replyChain);
                _twitterFakerContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
