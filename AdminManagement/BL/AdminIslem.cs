using AdminYonetim.Models.DataModel;
using AdminYonetim.Models.DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminYonetim.BL
{
    public class AdminIslem
    {
      
        public static byte Giris(AdminViewModel admin)
        {
             try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    var ad = (from a in db.TblAdmin
                              where a.Adi == admin.Adi && a.Sifre == admin.Sifre
                              select a).SingleOrDefault();
                    if (ad != null)
                        return 1;
                    else
                        return 0;

                }

            }
            catch (Exception ex)
            {
                return Convert.ToByte(-1);
            }
        }


    }
}