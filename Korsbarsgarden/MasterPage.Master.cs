using Korsbarsgarden.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Korsbarsgarden
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public medlem nymedlem = new medlem();
        int medlemid;
        protected void Page_Load(object sender, EventArgs e)
        {
            nymedlem.id = Convert.ToInt32(Session["id"]);
            medlemid = Convert.ToInt32(Session["id"]);

            if (medlemid > 0)
            {
                loginknapp.InnerText = "Logga ut";
            }
            else
            {
                loginknapp.InnerText = "Logga in";
            }
            
            
            //if (!IsPostBack)
            //{
            //    nymedlem.id = Convert.ToInt32(Session["id"]);
            //    nymedlem.behorighet = Session["behorighet"].ToString();

            //    //sidor som inte är tillgängliga för vanliga användare
            //    List<string> memberDenied = new List<string> 
            //    {
            //        "ASP.personal_
            //    };

            //    //sidor som besökare kommer åt (publika sidor)
            //    List<string> visitorAllowed = new List<string> 
            //    {
            //        "ASP.index_aspx",
            //        "ASP.login_aspx",
            //        "ASP.tavlingar_aspx",
            //        "ASP.tavlingsresultat_aspx"
            //    };

            //    if (g_idAccess == 1) //medlem
            //    {
            //        navAdmin.Visible = false;
            //        if (memberDenied.Contains(Page.ToString()))
            //        {
            //            Response.Redirect("index.aspx");
            //        }
            //    }
            //    else if (g_idAccess == 2 || g_idAccess == 3) //admin
            //    {

            //    }
            //    else //besökare
            //    {
            //        navBokning.Visible = false;
            //        navMedlemssida.Visible = false;
            //        navAdmin.Visible = false;
            //        if (!visitorAllowed.Contains(Page.ToString()))
            //        {
            //            Response.Redirect("login.aspx");
            //        }
            //    }
        }
    }
}