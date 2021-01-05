using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProductManagement.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new ProductDatabaseEntities())
            {
                bool isvalid = context.users.Any(x => x.username == model.username && x.password == model.password);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.username, false);
                    return RedirectToAction("Index", "ProductListDatas");
                }
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }
        public ActionResult Signup()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult Signup(user model)
        {
            using (var context = new ProductDatabaseEntities())
            {
                context.users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}