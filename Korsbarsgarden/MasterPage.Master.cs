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

                loginknapp.InnerHtml = "<i class='glyphicon glyphicon-lock'></i> Logga ut";
                
            }
            else
            {
                
                loginknapp.InnerHtml = "<i class='glyphicon glyphicon-lock'></i> Logga in";
            }


            if (!IsPostBack)
            {
                nymedlem.id = Convert.ToInt32(Session["id"]);

                nymedlem.behorighet = Convert.ToInt32(Session["behorighet"]);
                //sidor som inte är tillgängliga för vanliga besökare
                List<string> persondenied = new List<string>
                {
                    "ASP.skapakonto_aspx",
                    "ASP.skapablogg_aspx",
                    "ASP.blogg_aspx",
                    "ASP.bloggpost_aspx",
                    "ASP.minasidor_aspx"
                };
                //sidor som inte är tillgängliga för vanliga användare
                List<string> medlemDenied = new List<string> 
                {
                    "ASP.skapakonto_aspx",
                    "ASP.skapablogg_aspx"
                };


                if (nymedlem.behorighet == 2) //medlem
                {
                    dropdown.Visible = true;
                    if (medlemDenied.Contains(Page.ToString()))
                    {
                        Response.Redirect("404.aspx");
                    }
                    else
                    {
                        droprubrik.InnerHtml = "<i class='glyphicon glyphicon-user'></i> " + Session["fnamn"].ToString() + " " + Session["enamn"].ToString() + "<b class=caret></b>";
                        skapakonto.InnerHtml = "";
                        skapablogg.InnerHtml = "";
                    }
                }
                else if (nymedlem.behorighet == 1) //admin
                {
                    dropdown.Visible = true;
                    droprubrik.InnerHtml = "<i class='glyphicon glyphicon-user'></i> " + Session["fnamn"].ToString() + " " + Session["enamn"].ToString() +"<b class=caret></b>";

                }

                else if (nymedlem.behorighet == 0)
                {
                    if (persondenied.Contains(Page.ToString()))
                    {
                        Response.Redirect("404.aspx");
                    }
                }

            }
        }
    }
}