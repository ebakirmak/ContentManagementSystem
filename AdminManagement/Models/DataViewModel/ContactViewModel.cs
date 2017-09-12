using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminYonetim.Models.DataViewModel
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Adınızı Giriniz.")]
        [Display(Name = "Adı:")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Soyadınızı Giriniz.")]
        [Display(Name = "Soyadı:")]
        public string Soyadi { get; set; }
        [Required(ErrorMessage = "Mail Adresinizi Giriniz.")]
        [Display(Name = "E-Mail:")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Mesajınızı Giriniz.")]
        [Display(Name = "Mesaj:")]
        public string Mesaj { get; set; }
    }
}