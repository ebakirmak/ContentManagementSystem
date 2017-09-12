using AdminYonetim.Models.DataModel;
using AdminYonetim.Models.DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AdminYonetim.BL
{
    public class SliderSettings
    {
        public static string SliderAdd(SliderViewModel slider)
        {
           
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    TblSlider yeni = new TblSlider();
                    yeni.Adi = slider.Adi;
                    yeni.Aciklama = slider.Aciklama;

                    db.TblSlider.Add(yeni);
                    db.SaveChanges();
                    return "Slider Kaydedildi.";
                }
            
            
        }

        public static List<SliderViewModel> SliderList()
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    List<SliderViewModel> liste = new List<SliderViewModel>();
                    foreach (var item in db.TblSlider)
                    {
                        liste.Add(new SliderViewModel()
                        {
                            ID=item.ID,
                            Adi=item.Adi,
                            Aciklama = item.Aciklama

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

        public static SliderViewModel SliderGet(int sliderID)
        {
            using (YonetimPanelEntities db = new YonetimPanelEntities())
            {
                var slider = (from s in db.TblSlider where s.ID == sliderID select s).SingleOrDefault();
                SliderViewModel sliderView = new SliderViewModel()
                {
                    ID = slider.ID,
                    Adi = slider.Adi,
                    Aciklama = slider.Aciklama

                };
                return sliderView;
            }
        }

        public static string SliderDelete(int sliderID)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    var slider = (from s in db.TblSlider where s.ID == sliderID select s).SingleOrDefault();
                    db.TblSlider.Remove(slider);
                    db.SaveChanges();
                    return "Slider Silindi..";
                }
            }
            catch (Exception ex)
            {

                return "Slider Silinemedi..." + ex.Message;
            }
        }

        public static string SliderEdit(SliderViewModel slider)
        {
            try
            {
                using (YonetimPanelEntities db = new YonetimPanelEntities())
                {
                    var EditSlider = (from s in db.TblSlider where s.ID == slider.ID select s).SingleOrDefault();
                    EditSlider.ID = slider.ID;
                    EditSlider.Adi = slider.Adi;
                    EditSlider.Aciklama = slider.Aciklama;
                  
                    db.SaveChanges();
                    return "Slider Düzenlendi";
                }
            }
            catch (Exception ex)
            {

                return "Slider Düzenlenemedi. Hata" + ex.Message;
            }
        }
    }
}