using MVCAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCAuthentication.Controllers
{
    public class AccountController : Controller
    {
        MvcAuthenticationDbEntities sc=new MvcAuthenticationDbEntities();
        // GET: Account
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user user)
        {
            user.IsActive = true;
            user.CreatedDate = DateTime.Now;

            sc.users.Add(user);
            sc.SaveChanges();
            UserRole s = new UserRole()
            {
                UserID = user.ID,
                RoleID = 3
        };

            return RedirectToAction("Index", "Products");
        }
        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Login(LoginModel loginModel) 

        {
            if (ModelState.IsValid)
            {
                user user = sc.users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, loginModel.RememberMe);
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ViewBag.Message = "Email or Password is Incorrect";
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
           FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}