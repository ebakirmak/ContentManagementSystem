using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminYonetim.Models.DataModel;
using AdminYonetim.Models.DataViewModel;
using AdminYonetim.BL;
namespace AdminYonetim.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(AdminViewModel admin)
        {
            Session["Administrator"] = admin.Adi;
            if (AdminIslem.Giris(admin) == 1)
            {

                return RedirectToAction("Main");
            }
               
            else
                return View();
        }

        public ActionResult Main()
        {
            if(Session["Administrator"]!=null)
                return View();
            else            
                return RedirectToAction("Index");
            
        }
       
       
        public ActionResult PageSettings()
        {
            return View();
        }
    }
}