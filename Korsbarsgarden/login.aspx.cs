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
            PanelResponse.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LogIn();
        }
        #region metoder
        private void LogIn()
        {
            Encryption SHA256 = new Encryption();
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            string sql;
            string email = txtbox_emaillogin.Text.ToLower();
            string password = txtbox_password.Text;
            medlem mem = new medlem();
            try
            {
             
                //sql = "SELECT medlem.id, fnamn, enamn, personnr, behorighet.behorighetsgrad FROM medlem INNER JOIN behorighet ON medlem.fk_behorighet = behorighet.id WHERE epost ='" + email + "'";
                sql = "SELECT * from medlem  where epost ='" + email + "'";
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                
               
                if (dr.Read()) 
                {
                    
                    mem.id = Convert.ToInt16(dr["id"]);
                    mem.fnamn = dr["fnamn"].ToString();
                    mem.enamn = dr["enamn"].ToString();
                    mem.behorighet = Convert.ToInt16(dr["fk_behorighet"]);
                    mem.losenord = dr["losenord"].ToString();
                    Session.Add("id", mem.id);
                    Session.Add("fnamn", mem.fnamn);
                    Session.Add("enamn", mem.enamn);
                    Session.Add("behorighet", mem.behorighet);

                    //Check if password is correct and then redirect user to right page
                    if(SHA256.Confirm(password, mem.losenord, Supported_HA.SHA256))
                    {
                        if (mem.behorighet == 1)
                        {
                            Response.Redirect("~/index.aspx");
                        }
                        else if (mem.behorighet == 2)
                        {
                            Response.Redirect("~/personal.aspx");
                        }
                    }
                    else
                    {
                        PanelResponse.Visible = false;
                        PanelResponse.Visible = true;
                        LabelResponse.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Lösenordet stämmer inte.";
                    }
                   
                }
                else
                {
                    PanelResponse.Visible = false;
                    PanelResponse.Visible = true;
                    LabelResponse.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Ingen med den e-mailen registrerad.";
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