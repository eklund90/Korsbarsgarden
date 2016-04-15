using Korsbarsgarden.classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Korsbarsgarden
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }

        private void LogIn()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);

            string email = txtbox_emaillogin.Text;
            string password = txtbox_password.Text;
            string sql = "SELECT medlem.id, fnamn, enamn, personnr, behorighet.behorighetsgrad FROM medlem INNER JOIN behorighet ON medlem.fk_behorighet = behorighet.id WHERE epost ='" + email + "'";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            conn.Open();

            NpgsqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //if (DBNull.Value.Equals(dr["id"]))
                //{
                //Skapa object medlem
                medlem mem = new medlem();

                mem.id = Convert.ToInt16(dr["id"]);
                mem.fnamn = dr["fnamn"].ToString();
                mem.behorighet = dr["behorighetsgrad"].ToString();
                Session.Add("id", mem.id);
                Session.Add("fnamn", mem.fnamn);
                Session.Add("behorighet", mem.behorighet);

                if (mem.behorighet == "Admin")
                {
                    Response.Redirect("~/index.aspx");
                }
                else if (mem.behorighet == "Foralder")
                {

                }

                //}
            }
        }
    }
}