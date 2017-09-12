using AdminYonetim.BL;
using AdminYonetim.Models.DataViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AdminYonetim.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Index()
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-desktop";
                ViewBag.Menu = "SLİDER YÖNETİMİ";
                ViewBag.Islem = "SLİDER LİSTELE";
                return View(SliderSettings.SliderList());
            }
            else
                return RedirectToAction("Index", "Admin");
            
        }

        public ActionResult SliderAdd()
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-desktop";
                ViewBag.Menu = "SLİDER YÖNETİMİ";
                ViewBag.Islem = "SLİDER EKLE";
                return View();
            }
            else
                return RedirectToAction("Index", "Admin");

           
        }

        [HttpPost]
        public ActionResult SliderAdd(SliderViewModel slider,HttpPostedFileBase image)
        {
            if (Session["Administrator"] != null)
            {

                string fileExt = System.IO.Path.GetExtension(image.FileName);
                if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".png")
                {
                    slider.Adi = slider.Adi + ".jpg";
                    //Dosya Adı
                    string imageAdi = slider.Adi;
                    //Dosyanın yükleneceği alanı belirtelim.
                    var yol = Path.Combine(Server.MapPath("/Image/"), imageAdi);
                    //Dosyayı Kaydet
                    image.SaveAs(yol);
                    //Resim Boyutlandır.
                    WebImage resim = new WebImage(yol);
                    resim.Resize(1500, 500, false, false);
                    resim.Save(yol, "jpg", false);

                    SliderSettings.SliderAdd(slider);
                    return RedirectToAction("Index", "Slider");
                }
                else
                {
                    ViewBag.Icon = "fa-desktop";
                    ViewBag.Menu = "SLİDER YÖNETİMİ";
                    ViewBag.Islem = "SLİDER EKLE";
                    ViewBag.Message = "İşlem Başarısız.";
                    return View();
                }
                   
                
               
               
            }
            else
                return RedirectToAction("Index", "Admin");
            
        }

        public ActionResult SliderDelete(int sliderID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-desktop";
                ViewBag.Menu = "SLİDER YÖNETİMİ";
                ViewBag.Islem = "SLİDER SİL";
                return View(SliderSettings.SliderGet(sliderID));
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        [HttpPost]
        public ActionResult SliderDelete(SliderViewModel slider)
        {
            if (Session["Administrator"] != null)
            {
                 //Dosya Adı
                var imageAdi = slider.Adi;
                //Dosyanın yükleneceği alanı belirtelim.
                var yol = Path.Combine(Server.MapPath("/Image/"), imageAdi+".jpg");
                if (System.IO.File.Exists(yol))
                {
                    System.IO.File.Delete(yol);
                }     
                SliderSettings.SliderDelete(slider.ID);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Icon = "fa-desktop";
                ViewBag.Menu = "SLİDER YÖNETİMİ";
                ViewBag.Islem = "SLİDER DETAYLAR";
                return RedirectToAction("Index", "Admin");
            }
                
           
        }

        public ActionResult SliderDetails(int sliderID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-desktop";
                ViewBag.Menu = "SLİDER YÖNETİMİ";
                ViewBag.Islem = "SLİDER DETAYLAR";
                return View(SliderSettings.SliderGet(sliderID));
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        public ActionResult SliderEdit(int sliderID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-desktop";
                ViewBag.Menu = "SLİDER YÖNETİMİ";
                ViewBag.Islem = "SLİDER DÜZENLE";
                return View(SliderSettings.SliderGet(sliderID));
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        [HttpPost]
        public ActionResult SliderEdit(SliderViewModel slider,FormCollection form)
        {
            if (Session["Administrator"] != null)
            {
               string eskiResim = form.Get("x");
            var imageAdi = slider.Adi;
            //Dosyanın yüklendiği alanı belirtelim.
            var yol = Path.Combine(Server.MapPath("/Image/"), slider.Adi);         
            if (System.IO.File.Exists(Server.MapPath("/Image/"+eskiResim)))
            {
                System.IO.File.Copy(Server.MapPath("/Image/"+eskiResim), yol);
                System.IO.File.Delete(Server.MapPath("/Image/"+eskiResim));
            }
            SliderSettings.SliderEdit(slider);
               
                return RedirectToAction("Index");
            }
            else
            {
               
                return RedirectToAction("Index", "Admin");
            }
               
           
        }

        public Bitmap ResimBoyutlandir(Bitmap resim,int boyut)
        {
            Bitmap sresim = resim;
            using (Bitmap OrjinalResim = resim)
            {
                double yukseklik = OrjinalResim.Height;
                double genislik = OrjinalResim.Width;
                double oran = 0;
                if(genislik>=boyut)
                {
                    oran = genislik / yukseklik;
                    genislik = boyut;
                    yukseklik = genislik / oran;
                    Size ydeger = new Size(Convert.ToInt32(genislik), Convert.ToInt32(yukseklik));
                    Bitmap yresim = new Bitmap(OrjinalResim, ydeger);
                    sresim = yresim;
                }
            }
            return sresim;
        }
    }
}