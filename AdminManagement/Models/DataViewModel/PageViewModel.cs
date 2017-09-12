using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminYonetim.Models.DataViewModel
{
    public class PageViewModel
    {
    
        [Display(Name = "Sayfa ID:")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Sayfa Başlık zorunludur.")]
        [Display(Name = "Sayfa Başlığı:")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Sayfa İçeriği zorunludur.")]
        [Display(Name = "Sayfa İçeriği:")]
        public string Icerik { get; set; }

        [Required(ErrorMessage = "Sayfa BannerID zorunludur.")]
        [Display(Name = "Sayfa BannerID:")]
        public int BannerID { get; set; }

        [Required(ErrorMessage = "Sayfanın Menüsü olmalıdır.")]
        [Display(Name = "Sayfa Menüsü:")]
        public int MenuID { get; set; }

       
        [Display(Name = "Sayfa Meta Açıklama:")]
        public string MetaDescription { get; set; }
     
        [Display(Name = "Sayfa Meta Kelime:")]
        public string MetaKeyword { get; set; }
    }
}