using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminYonetim.Models.DataViewModel
{
    public class AdminViewModel
    {
        

        public int ID { get; set; }
        [Required(ErrorMessage = "Admin Adı Boş Hırakılamaz")]
        [Display(Name = "Giriş Adı Alanı")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez...")]
        [Display(Name = "Şifre Alanı")]
        public string Sifre { get; set; }
        public string Yetki { get; set; }
        [Required(ErrorMessage = "Mail Alanı Boş Geçilmez")]
        [Display(Name = "Mail Alanı")]
        public string Email { get; set; }
    }
}