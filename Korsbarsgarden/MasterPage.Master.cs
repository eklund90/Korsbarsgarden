using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace Korsbarsgarden
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Contents["behorighet"] == "Admin")
            {
                HyperLink1.Text = "INLOGGAD SOM ADMIN";
            }
        }
    }
}