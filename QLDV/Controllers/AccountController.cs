using QLDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QLDV.Controllers
{
    public class AccountController : Controller
    {
        public ViewResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        //nhan giu lieun tu client
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (acc.Username == "admin" && acc.Password == "123456789")
                {
                    FormsAuthentication.SetAuthCookie(acc.Username, true);
                    return RedirectToLocal(returnUrl);
                }
            }
            return View(acc);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        //kiem tra returnUrn co thuoc he thong hay k
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}