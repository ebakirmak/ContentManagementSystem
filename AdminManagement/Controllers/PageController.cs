using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminYonetim.BL;
using AdminYonetim.Models.DataViewModel;
using AdminYonetim.Models.DataModel;

namespace AdminYonetim.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            if (Session["Administrator"] != null)
            {
                try
                {
                    ViewBag.Menu = "SAYFA YÖNETİMİ";
                    ViewBag.Islem = "SAYFA LİSTELE";
                    return View(PageSettings.PageList());
                }
                catch (Exception)
                {

                    throw;
                }    
               
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        public ActionResult PageAdd()
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Menu = "SAYFA YÖNETİMİ";
                ViewBag.Islem = "SAYFA EKLE";
                return View();
            }
            else
                return RedirectToAction("Index", "Admin");
           
        }

        [HttpPost]
        public ActionResult PageAdd(PageViewModel page)
        {
            if (Session["Administrator"] != null)
            {
                if (PageSettings.PageAdd(page) == true)
                    return RedirectToAction("Index", "Page");
                else
                {
                    ViewBag.Menu = "SAYFA YÖNETİMİ";
                    ViewBag.Islem = "SAYFA EKLE";
                    ViewBag.Hata = "false";
                    return View();

                }
                   
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }
               

        }

        //Sayfa Duzenle
        public ActionResult PageEdit(int pageID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Menu = "SAYFA YÖNETİMİ";
                ViewBag.Islem = "SAYFA DÜZENLE";
                return View(PageSettings.PageGet(pageID));
            }
            else
                return RedirectToAction("Index", "Admin");
            
        }

        [HttpPost]
        public ActionResult PageEdit(PageViewModel page)
        {
            if (Session["Administrator"] != null)
            {
             if( PageSettings.PageEdit(page)==true)
                return RedirectToAction("Index", "Page");
             else
                {
                    ViewBag.Menu = "SAYFA YÖNETİMİ";
                    ViewBag.Islem = "SAYFA DÜZENLE ";
                    ViewBag.Hata = "false";
                    return View();
                }
            }
            else
                return RedirectToAction("Index", "Admin");

        }

        //Sayfa Detaylar
        public ActionResult PageDetail(int pageID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Menu = "SAYFA YÖNETİMİ";
                ViewBag.Islem = "SAYFA DETAYLAR";
                return View(PageSettings.PageGet(pageID));
            }
            else
                return RedirectToAction("Index", "Admin");
            
        }

        //Page Sil
        public ActionResult PageDelete (int pageID)
        {
            if (Session["Administrator"] != null)
            {
                ViewBag.Menu = "SAYFA YÖNETİMİ";
                ViewBag.Islem = "SAYFA SİL";
                return View(PageSettings.PageGet(pageID));
            }
            else
            {
              
                return RedirectToAction("Index", "Admin");
            
            }
                
        }
       
        
        
        [HttpPost]        
        public ActionResult PageDelete (PageViewModel model)
        {
            if (Session["Administrator"] != null)
            {
               PageSettings.PageDelete(model.ID);
            return RedirectToAction("Index", "Page");
            }
            else
            {
                ViewBag.Menu = "SAYFA YÖNETİMİ";
                ViewBag.Islem = "SAYFA SİL";
                return RedirectToAction("Index", "Admin");
            }
               

           
        }

      public JsonResult MenuList()
        {
           
            return Json(PageSettings.MenuListGet());
        }
       
    }
}