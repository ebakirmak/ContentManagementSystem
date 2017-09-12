using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminYonetim.Models.DataViewModel
{
    public class SliderViewModel
    {
        [Required(ErrorMessage = "Resim ID Giriniz.")]
        [Display(Name = "Resim ID:")]
        public int ID { get; set; }
        [Required(ErrorMessage = "Resim Adı Giriniz.")]
        [Display(Name = "Resim Adı:")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Resim Yazısı Giriniz.")]
        [Display(Name = "Resim Yazısı:")]
        public string Aciklama { get; set; }
        public string EskiAdi { get; set; }
    }
}