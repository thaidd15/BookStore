using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password không được để trống")]
        public string Password { get; set; }
    }
}