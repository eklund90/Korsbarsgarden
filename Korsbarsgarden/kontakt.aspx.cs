using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Korsbarsgarden
{
    public partial class kontakt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_skickamed_Click(object sender, EventArgs e)
        {
            string namn = txtBox_name.Text;
            string epost = txtBox_epost.Text;
            string telenr = txtBox_telenr.Text;
            string text = txtBox_text.Text;

            SkickaMail(namn, epost, telenr, text);
 
        }
        public static bool SkickaMail(string namn, string epost, string telenr, string text)
        {
            bool successfull = false;

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add("halslaget@gmail.com");
            mail.From = new MailAddress("halslaget@gmail.com", "Från: " + namn + ", " + epost + ", " + telenr, System.Text.Encoding.UTF8);
            mail.Subject = "Kontakt";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = text;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("halslaget@gmail.com", "halslagetg5");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            successfull = true;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                
                    Debug.WriteLine(ex.Message);
                
            }
            return successfull;
        }
    }
}