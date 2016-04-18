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


            if (!IsPostBack)
            {
                nymedlem.id = Convert.ToInt32(Session["id"]);

                nymedlem.behorighet = Convert.ToInt32(Session["behorighet"]);

                //sidor som inte är tillgängliga för vanliga användare
                List<string> medlemDenied = new List<string> 
                {
                    "ASP.kontakt_aspx"
                };

                //sidor som besökare kommer åt (publika sidor)
                List<string> personalAllowed = new List<string> 
                {
                    "ASP.index_aspx",
                    "ASP.login_aspx",
                    "ASP.intagning_aspx",
                    "ASP.kooperativ_aspx",
                    "ASP.personal_aspx",
                    "ASP.kontakt_aspx"
                };

                if (nymedlem.id == 2) //medlem
                {
                    dropdown.Visible = false;
                    if (medlemDenied.Contains(Page.ToString()))
                    {
                        Response.Redirect("index.aspx");
                    }
                }
                else if (nymedlem.id == 1) //admin
                {
                    dropdown.Visible = true;
                    droprubrik.InnerHtml = "<i class='glyphicon glyphicon-user'></i> " + Session["fnamn"].ToString() + " " + Session["enamn"].ToString() +"<b class=caret></b>";
                    
                    minaSidor.InnerHtml = "MINA SIDOR";
                    minaSidor.Attributes["href"] = "kontakt.aspx";
                }
            }
        }
    }
}