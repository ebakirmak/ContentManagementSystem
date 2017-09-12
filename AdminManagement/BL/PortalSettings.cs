using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using AdminYonetim.Models.DataViewModel;

namespace AdminYonetim.BL
{
    public class PortalSettings
    {
      public static bool MailGonder(ContactViewModel contact)
        {
            MailMessage ePosta = new MailMessage();
            //Sunucu maili yazılacak.
            ePosta.From = new MailAddress("nurcanakirmak@gmail.com");

            //Mail gönderilecek adres. müşterinin maili
            ePosta.To.Add("ebakirmak@gmail.com");          
            ePosta.Subject = "ilk";
            ePosta.Body = contact.Mesaj;
            SmtpClient smtp = new SmtpClient();
            //Sunucu Mail ve Şifre Yazılacak.
            smtp.Credentials = new System.Net.NetworkCredential("nurcanakirmak@gmail.com", "12991453"); // Mail Şifresi
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            object userState = ePosta;
            bool kontrol = true;
            try
            {
                smtp.SendAsync(ePosta, (object)ePosta);
            }
            catch(Exception ex)
            {
                ex.ToString();
                kontrol = false;
            }
            return kontrol;

        }
        
    }
}