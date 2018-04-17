using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class NhaXuatBanController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public PartialViewResult NhaXuatBanPartial()
        {
            return PartialView(db.NhaXuatBans.Take(10).OrderBy(x => x.TenNXB).ToList());
        }
        public ViewResult SachTheoNXB(int MaNXB = 0)
        {
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> lstSach = db.Saches.Where(n => n.MaNXB == MaNXB).OrderBy(n => n.GiaBan).ToList();
            if (lstSach.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            ViewBag.lstNXB = db.NhaXuatBans.ToList();
            return View(lstSach);
        }
        public ViewResult DanhMucNXB()
        {
            int MaNXB = int.Parse(db.NhaXuatBans.ToList().ElementAt(0).MaNXB.ToString());
            ViewBag.SachTheoNXB = db.Saches.Where(n => n.MaNXB == MaNXB).ToList();
            return View(db.NhaXuatBans.ToList());
        }
    }
}