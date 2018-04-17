using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using PagedList;
using PagedList.Mvc;
using System.Text;
using System.Text.RegularExpressions;

namespace BookStore.Controllers
{
    public class SearchController : Controller
    {
        string Temp_BookName, Temp_BookDescription, Temp_Book;
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();

        public string VNtoEnglish(string input)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = input.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        [HttpPost]
        public ActionResult SearchResult(FormCollection f, int? page)
        {
            string stringSearch = f["txtTimKiem"];
            ViewBag.KeyWord = stringSearch;
            int pagenumber = (page ?? 1);
            int pagesize = 12;
            List<Sach> Result = new List<Sach>();
            List<Sach> s = db.Saches.ToList();
            foreach (var item in s)
            {
                Temp_BookName = VNtoEnglish(item.TenSach).ToLower();
                Temp_BookDescription = VNtoEnglish(item.MoTa).ToLower();
                if ((Temp_BookName.Contains(stringSearch) || Temp_BookDescription.Contains(stringSearch)) == true)
                {
                    Result.Add(item);
                }
            }
            if (Result.Count == 0)
            {
                ViewBag.Notification = "Không có kết quả phù hợp với " + "'" + stringSearch + "'";
                return View(Result.ToPagedList(pagenumber, pagesize));
            }
            else
            {
                ViewBag.Notification = string.Format("Tìm thấy {0} kết quả phù hợp với " + "'" + stringSearch + "'", Result.Count);
                return View(Result.ToPagedList(pagenumber, pagesize));
            }
        }

        [HttpGet]
        public ActionResult SearchResult(int? page, string stringSearch)
        {
            ViewBag.KeyWord = stringSearch;
            int pagenumber = (page ?? 1);
            int pagesize = 12;
            List<Sach> Result = new List<Sach>();
            List<Sach> s = db.Saches.ToList();
            foreach (var item in s)
            {
                Temp_BookName = VNtoEnglish(item.TenSach).ToLower();
                Temp_BookDescription = VNtoEnglish(item.MoTa).ToLower();
                if ((Temp_BookName.Contains(stringSearch) || Temp_BookDescription.Contains(stringSearch)) == true)
                {
                    Result.Add(item);
                }
            }
            if (Result.Count == 0)
            {
                ViewBag.Notification = "Không có kết quả phù hợp";
                return View(Result.ToPagedList(pagenumber, pagesize));
            }
            else
            {
                ViewBag.Notification = string.Format("Tìm thấy {0} kết quả phù hợp", Result.Count);
                return View(Result.ToPagedList(pagenumber, pagesize));
            }
        }
    }
}