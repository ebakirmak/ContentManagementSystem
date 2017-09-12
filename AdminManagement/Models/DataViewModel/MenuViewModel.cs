using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminYonetim.Models.DataViewModel
{
    public class MenuViewModel
    {


        [Required(ErrorMessage = "Menü ID Zorunludur.")]
        [Display(Name = "Menü ID:")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Menü Adı Zorunludur.")]
        [Display(Name = "Menü Adı:")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Menü Konum  Zorunludur.")]
        [Display(Name = "Menü Konum:")]  
        public int KonumID { get; set; }

        [Required(ErrorMessage = "Menü Konum Tipi Zorunludur.")]
        [Display(Name = "Menü Konum Tipi:")]
        public string KonumTipi { get; set; }
    }
}