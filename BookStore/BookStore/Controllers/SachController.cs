using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class SachController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public ViewResult XemChiTiet(int MaSach = 0)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            string tacgia = string.Empty;
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            TacGia[] author = db.TacGias.ToArray();
            ThamGia[] participant = db.ThamGias.ToArray();
            ViewBag.TenChuDe = db.ChuDes.Single(n => n.MaChuDe == sach.MaChuDe).TenChuDe;
            ViewBag.NhaXuatBan = db.NhaXuatBans.Single(n => n.MaNXB == sach.MaNXB).TenNXB;
            foreach (var p in participant)
            {
                if (p.MaSach == MaSach)
                {
                    foreach (var a in author)
                    {
                        if (p.MaTacGia == a.MaTacGia)
                        {
                            tacgia += a.TenTacGia;
                            tacgia += ", ";
                        }
                    }
                }
            }
            ViewBag.TacGia = tacgia.Remove(tacgia.Length - 2);
            return View(sach);
        }
    }
}