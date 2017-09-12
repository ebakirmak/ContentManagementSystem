using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminYonetim.Models.DataModel;
using AdminYonetim.Models.DataViewModel;
namespace AdminYonetim.BL
{
    public class PageSettings
    {
        //Sayfa Ekleme İşlemleri yapılır.
        public static bool PageAdd(PageViewModel page)
        {
            try
            {
               
              
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                    {
                    var Kontrol = (from p in db.TblPage where p.MenuID == page.MenuID select p);
                    if (Kontrol.Count() ==0)               
                    {
                        TblPage yeni = new TblPage()
                        {
                            Baslik = page.Baslik,
                            Icerik = page.Icerik,
                            MenuID = page.MenuID,
                            MetaKeyword = page.MetaKeyword,
                            MetaDescription = page.MetaDescription

                        };
                        db.TblPage.Add(yeni);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<PageViewModel> PageList()
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    List<PageViewModel> liste = new List<PageViewModel>();
                    foreach (var item in db.TblPage)
                    {
                        liste.Add(new PageViewModel()
                        {
                           ID=item.ID,
                             Baslik=item.Baslik,
                             Icerik=item.Icerik,
                             MenuID= Convert.ToInt32( item.MenuID),
                              MetaKeyword=item.MetaKeyword,
                              MetaDescription=item.MetaDescription   
                            
                        });
                    }
                    return liste;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static PageViewModel  PageGet(int pageID)
        {
            using (YonetimPanelEntities db = new YonetimPanelEntities())
            {
                try
                {
                    var page = (from p in db.TblPage where p.ID == pageID select p).SingleOrDefault();
                    PageViewModel pageView = new PageViewModel()
                    {
                        ID = page.ID,
                        Baslik = page.Baslik,
                        Icerik = page.Icerik,
                        MenuID = Convert.ToInt32(page.MenuID),
                         MetaKeyword=page.MetaKeyword,
                         MetaDescription=page.MetaDescription
                        
                    };
                    return pageView;
                }
                catch (Exception ex)
                {
                    PageViewModel pageView = new PageViewModel()
                    {
                        ID = 0,
                        Icerik = ex.Message
                       
                    };
                    return pageView;
                }
                
            }
        }

        public static string PageDelete(int pageID)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    var page = (from p in db.TblPage where p.ID == pageID select p).SingleOrDefault();
                    db.TblPage.Remove(page);
                    db.SaveChanges();
                    return "Sayfa Silindi..";
                }
            }
            catch (Exception ex)
            {

                return "Sayfa Silinemedi..." + ex.Message;
            }
        }

        public static bool PageEdit(PageViewModel page)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    var EditPage = (from p in db.TblPage where p.ID== page.ID select p).SingleOrDefault();
                    EditPage.Baslik = page.Baslik;
                    EditPage.Icerik = page.Icerik;
                    EditPage.MenuID = page.MenuID;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static List<MenuViewModel> MenuListGet()
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    List<MenuViewModel> liste = new List<MenuViewModel>();                  
                    foreach (var item in db.TblMenu)
                    {
                        
                            liste.Add(new MenuViewModel()
                            {
                                Adi = item.Adi,
                                ID = item.ID,
                                KonumID = item.KonumID,
                                KonumTipi = item.KonumTipi

                            });
                        
                       
                    }

                    return liste;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        /*
        public static string MenuAdiBul()
        {
            using (YonetimPanelEntities db = new YonetimPanelEntities())
            {
                List<PageViewModel> liste = new List<PageViewModel>();
                //string[] menuAdi = "";
                liste = PageList().ToList();
                foreach (var eleman in db.TblMenu )
                {
                    if(liste.First(x => x.MenuID == eleman.ID)!=null)
                    {
                       // menuAdi = eleman.Adi;
                      
                    }

                }
                return menuAdi;
            }
            
        }
        */
    }
}