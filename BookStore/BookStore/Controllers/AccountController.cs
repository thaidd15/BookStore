using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Concrete;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        FormAuthen f = new FormAuthen();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login l, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (f.Authen(l.Username, l.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu chưa đúng");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}