using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public ViewResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View(db.Saches.ToList());
        }

        [HttpPost]
        public ActionResult Delete(int MS)
        {
            Sach s = db.Saches.Find(MS);
            if (s != null)
            {
                db.Saches.Remove(s);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} đã được xóa", s.TenSach);
            }
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int MaSach)
        {
            Sach s = db.Saches.FirstOrDefault(n => n.MaSach == MaSach);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Sach s)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(s);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} đã được sửa", s.TenSach);
                return RedirectToAction("Index");
            }
            else
            {
                return View(s);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Sach());
        }
    }
}