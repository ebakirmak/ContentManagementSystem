using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminYonetim.BL;
using AdminYonetim.Models.DataViewModel;

namespace AdminYonetim.Controllers
{
    public class PortalController : Controller
    {
        // GET: Portal
        public ActionResult Index()
        {
            return View(SliderSettings.SliderList());
        }
        
        [HttpGet]
       public ActionResult PageView(int pageID)
        {
            if (pageID == 0)
                return RedirectToAction("Index");
            else
            {
                 return View(PageSettings.PageGet(pageID));
            }
               
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contact)
        {
            if(ModelState.IsValid)
            {
                if (PortalSettings.MailGonder(contact) == true)
                    return RedirectToAction("Index", "Portal");
               
             }
           

            return View();
        }

    }
}