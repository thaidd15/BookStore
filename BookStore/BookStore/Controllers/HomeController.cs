﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using PagedList;
using PagedList.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(db.Saches.Where(n => n.Moi == 1).OrderBy(n => n.GiaBan).ToPagedList(pageNumber, pageSize));
        }
    }
}