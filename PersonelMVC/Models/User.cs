using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kullanıcı Adı alanı zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Şifre alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}