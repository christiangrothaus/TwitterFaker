using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TwitterFaker.Models;

namespace TwitterFaker.Controllers
{
    public class UserController : Controller
    {
        private HttpContext _httpContext;

        public void setContext(HttpContext httpContext)
        {
            this._httpContext = httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public string GetCookie(string key)
        {
          return _httpContext.Request.Cookies[key];
        }

        public void SetCookie(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            option.IsEssential = true;

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddYears(1);

            _httpContext.Response.Cookies.Append(key, value, option);
        }

        public void RemoveCookie(string key)
        {
            _httpContext.Response.Cookies.Delete(key);
        }
    }
}
