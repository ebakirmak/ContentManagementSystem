using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminYonetim.Models.DataViewModel;
using AdminYonetim.BL;
using AdminYonetim.Models.DataModel;

namespace AdminYonetim.Controllers
{
    public class MenuController : Controller
    {
        //Create a Session
       

        // Tüm menuler bu sayfada gösteriliyor.
        public ActionResult Index()
        {
     

            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-sitemap";
                ViewBag.Menu = "MENÜ YÖNETİMİ";
                ViewBag.Islem = "MENÜ LİSTELE";
               return View(MenuSettings.MenuList());
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }
        //Menu Ekleme Controller
        public ActionResult MenuAdd()
        {
            ViewBag.Icon = "fa-sitemap";
            ViewBag.Menu = "MENÜ YÖNETİMİ";
            ViewBag.Islem = "MENÜ EKLE";
            if (Session["Administrator"] != null)
            {
            return View();
            }
            else
                return RedirectToAction("Index", "Admin");

            
        }

        [HttpPost]
        public ActionResult MenuAdd(MenuViewModel menu)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-sitemap";
                ViewBag.Menu = "MENÜ YÖNETİMİ";
                ViewBag.Islem = "MENÜ EKLE";
                MenuSettings.MenuAdd(menu);
            return RedirectToAction("Index", "Menu");
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        //Menu Duzenle
        public ActionResult MenuEdit(int menuID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-sitemap";
                ViewBag.Menu = "MENÜ YÖNETİMİ";
                ViewBag.Islem = "MENÜ DÜZENLE";
                return View(MenuSettings.MenuGet(menuID));
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }
        [HttpPost]
        public ActionResult MenuEdit(MenuViewModel menu)
        {
            if (Session["Administrator"] != null)
            {
             if(MenuSettings.MenuEdit(menu)=="0")
                {
                    ViewBag.Icon = "fa-sitemap";
                    ViewBag.Menu = "MENÜ YÖNETİMİ";
                    ViewBag.Islem = "MENÜ DÜZENLE";
                    ViewBag.Message = "Menu Duzenlenemedi. Lütfen Alt Menulerinin olup olmadığını kontrol ediniz.";
                    return View();
                }
             else
                {
                    return RedirectToAction("Index", "Menu");
                }
           
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        //Menu Detaylar
        public ActionResult MenuDetail(int menuID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-sitemap";
                ViewBag.Menu = "MENÜ YÖNETİMİ";
                ViewBag.Islem = "MENÜ DETAYLAR";
                return View(MenuSettings.MenuGet(menuID));
            }
            else
                return RedirectToAction("Index", "Admin");
            
        }

        //Menu Sil
        public ActionResult MenuDelete(int menuID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Icon = "fa-sitemap";
                ViewBag.Menu = "MENÜ YÖNETİMİ";
                ViewBag.Islem = "MENÜ SİL";
                return View(MenuSettings.MenuGet(menuID));
            }
            else
                return RedirectToAction("Index", "Admin");
           
           
        }
        [HttpPost]
        public ActionResult MenuDelete(MenuViewModel menu)
        {
            if (Session["Administrator"] != null)
            {
                string sonuc = MenuSettings.MenuDelete(menu.ID);
                if (sonuc!="0")
                {
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    ViewBag.Icon = "fa-sitemap";
                    ViewBag.Menu = "MENÜ YÖNETİMİ";
                    ViewBag.Islem = "MENÜ SİL";
                    ViewBag.Message = "Menu Silinemedi. Lütfen Alt menulerinin olup olmadığını kontrol ediniz";
                    return View();
                }
            
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        //Menu.js dosyasındaki post metodu ile çağırdıyım JsonResult       
        public JsonResult Konum(string deger)
        {            
            return Json(MenuSettings.MenuListGet(deger));
        }
     
    }
}