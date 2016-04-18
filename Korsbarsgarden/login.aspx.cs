using Korsbarsgarden.classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
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
        #region metoder
        private void LogIn()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString.ToString());
            string sql;
            string email = txtbox_emaillogin.Text;
            string password = txtbox_password.Text;
            medlem mem = new medlem();
            try
            {
             
                //sql = "SELECT medlem.id, fnamn, enamn, personnr, behorighet.behorighetsgrad FROM medlem INNER JOIN behorighet ON medlem.fk_behorighet = behorighet.id WHERE epost ='" + email + "'";
                sql = "SELECT * from medlem where epost ='" + email + "'";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.Read()) 
                {
                    //if (DBNull.Value.Equals(dr["id"]))
                    //{
                    //Skapa object medlem


                    mem.id = Convert.ToInt16(dr["id"]);
                    mem.fnamn = dr["fnamn"].ToString();
                    mem.behorighet = Convert.ToInt16(dr["fk_behorighet"]);
                    Session.Add("id", mem.id);
                    Session.Add("fnamn", mem.fnamn);
                    Session.Add("behorighet", mem.behorighet);

                    if (mem.behorighet == 1)
                    {
                        Response.Redirect("~/index.aspx");
                    }
                    else if (mem.behorighet == 2)
                    {
                        Response.Redirect("~/personal.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            finally
            {
                conn.Close();
            }



        }

        #endregion metoder
    }
}