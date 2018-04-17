using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int BookID { get; set; }
        [Required(ErrorMessage = "Nhập vào tên sách")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập vào giá bán của sách")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Nhập vào một giá trị dương")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Nhập vào mô tả của sách")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Nhập vào tên bìa sách")]
        public string BookImage { get; set; }
        [Required(ErrorMessage = "Nhập vào số lượng")]
        public string Quantity { get; set; }
        [Required(ErrorMessage = "Nhập vào mã nhà xuất bản")]
        public int PublisherID { get; set; }
    }
}