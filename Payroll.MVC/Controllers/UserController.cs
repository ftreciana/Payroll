using Payroll.DataModel;
using Payroll.Repository;
using Payroll.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Payroll.MVC.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserViewModel user)
        {
            bool status = false;
            string message = "";
            if (ModelState.IsValid)
            {
                var isExist = IsUserExist(user.Username);
                if (isExist)
                {
                    ModelState.AddModelError("UserExist", "User already existed");
                    return View(user);
                }

                user.Password = Crypto.Hash(user.Password);

                Responses responses = UserRepo.Update(user);
                if (responses.Success)
                {
                    return RedirectToAction("Login", "User");
                }
                else
                {
                    return Json(new { success = false, message = responses.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                message = "Invalid Request";
            }
            return View(user);
        }

        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "")
        {
            string message = "";
            using (var db = new PayrollContext())
            {
                var v = db.Users.Where(o => o.Username == login.Username).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.Password), v.Password)==0)
                    {
                        int timeout = login.RememberMe ? 52500 : 20;
                        var ticket = new FormsAuthenticationTicket(login.Username, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            ViewBag.Message = message;
            return View();
        }

        //LOGOUT
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [NonAction]
        public bool IsUserExist(string user)
        {
            return UserRepo.UserExist(user);
        }
    }
}