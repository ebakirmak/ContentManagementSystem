using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdminYonetim.Models.DataModel;
using AdminYonetim.Models.DataViewModel;
namespace AdminYonetim.BL
{
    public class MenuSettings
    {
        public static bool MenuAdd(MenuViewModel menu)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    TblMenu yeni = new TblMenu()
                    { 
                        Adi=menu.Adi,
                        KonumID=menu.KonumID,
                        KonumTipi=menu.KonumTipi
                    };
                    db.TblMenu.Add(yeni);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<MenuViewModel> MenuList()
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
                            KonumID=item.KonumID,
                            KonumTipi=item.KonumTipi
                            
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

        public static MenuViewModel MenuGet(int menuID)
        {
            using (YonetimPanelEntities db = new YonetimPanelEntities())
            {
                var menu = (from m in db.TblMenu where m.ID == menuID select m).SingleOrDefault();
                MenuViewModel menuView = new MenuViewModel()
                {
                    ID = menu.ID,
                    Adi = menu.Adi,
                    KonumID=menu.KonumID,
                    KonumTipi=menu.KonumTipi
                    
                };
                return menuView;
            }
        }

        public static string MenuDelete(int menuID)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    var menu = (from m in db.TblMenu where m.ID == menuID select m).SingleOrDefault();
                    var Kontrol = (from k in db.TblMenu where k.KonumID == menu.ID select k).SingleOrDefault();
                    var PageKontrol = (from p in db.TblPage where p.MenuID == menu.ID select p).SingleOrDefault();

                    if(Kontrol==null)
                    {
                        //db.TblPage.Remove(PageKontrol);                      
                        db.TblMenu.Remove(menu);
                        db.SaveChanges();
                        return "Menü Silindi..";

                    }
                    else
                    {
                        return "0";
                    }
                   
                }
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        public static string MenuEdit(MenuViewModel menu)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    var EditMenu = (from m in db.TblMenu where m.ID == menu.ID select m).SingleOrDefault();
                    var Kontrol = (from k in db.TblMenu where k.KonumID == menu.ID select k).SingleOrDefault();
                    if(menu.KonumTipi==EditMenu.KonumTipi)
                    {
                        EditMenu.ID = menu.ID;
                        EditMenu.Adi = menu.Adi;
                        EditMenu.KonumID = menu.KonumID;
                        EditMenu.KonumTipi = menu.KonumTipi;
                        db.SaveChanges();
                        return "Menü Düzenlendi";
                    }
                    else
                    {
                        if (Kontrol == null)
                        {
                            EditMenu.ID = menu.ID;
                            EditMenu.Adi = menu.Adi;
                            EditMenu.KonumID = menu.KonumID;
                            EditMenu.KonumTipi = menu.KonumTipi;
                            db.SaveChanges();
                            return "Menü Düzenlendi";
                        }
                        else
                        {
                            return "0";
                        }
                    }
                   
                    
                }
            }
            catch (Exception ex)
            {

                return "Menü Düzenlenemedi. Hata" + ex.Message;
            }
        }

        public static List<TblMenu> Konum(string value)
        {
            using (YonetimPanelEntities db = new YonetimPanelEntities())
            {
                var konumAdlari = (from k in db.TblMenu where k.KonumTipi == value select k).ToList();

                return konumAdlari;
            }
        }

        public static List<MenuViewModel> MenuListGet(string KonumTipi)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    List<MenuViewModel> liste = new List<MenuViewModel>();
                    foreach (var eleman in db.TblMenu)
                    {
                        if (eleman.KonumTipi == KonumTipi)
                        {
                            liste.Add(new MenuViewModel()
                            {
                                ID = eleman.ID,
                               Adi=eleman.Adi,
                                KonumID=eleman.KonumID,
                                 KonumTipi=eleman.KonumTipi
                               
                            });
                        }
                    }
                    return liste;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}