using MVC_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Application.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        static List<Login> employee = new List<Login>();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (IsValid(login))
            {
                FormsAuthentication.SetAuthCookie(login.EmailId, false);
                return RedirectToAction("index","Home");
            }
            else
            {
            return View();
            }
        }
        private bool IsValid(Login login)
        {
            return (login.EmailId == "Test" && login.Password == "12345");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}