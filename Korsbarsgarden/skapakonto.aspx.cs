using Korsbarsgarden.classes;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Korsbarsgarden
{
    public partial class skapakonto : System.Web.UI.Page
    {
        medlem nymedlem = new medlem();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btn_skapakonto_Click(object sender, EventArgs e)
        {
            Encryption SHA256 = new Encryption();
            nymedlem.fnamn = txtBox_skapakonto_fornamn.Text;
            nymedlem.enamn = txtBox_skapakonto_efternamn.Text;
            nymedlem.personnr = txtBox_skapakonto_personnr.Text;
            nymedlem.telefonnr = txtBox_skapakonto_telefonnr.Text;
            nymedlem.adress = txtBox_skapakonto_adress.Text;
            nymedlem.postnr = txtBox_skapakonto_postnr.Text;
            nymedlem.postort = txtBox_skapakonto_postort.Text;
            nymedlem.epost = txtBox_skapakonto_epost.Text;
            nymedlem.losenord = SHA256.ComputeHash(txtBox_skapakonto_losenord.Text, Supported_HA.SHA256, null);
            nymedlem.behorighet = Convert.ToInt16(dropdown_skapakonto_behorighet.Text);

            läggtillmedlem(nymedlem);
        }
        public void läggtillmedlem(medlem nymedlem)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            
            string sqlcheck = "SELECT id from medlem WHERE epost ='"+ nymedlem.epost +"'";
            NpgsqlCommand cmdcheck = new NpgsqlCommand(sqlcheck, conn);
            conn.Open();
            NpgsqlDataReader drcheck = cmdcheck.ExecuteReader();

            if(!drcheck.Read())
            {
                string sql;
                sql = "INSERT INTO medlem(fnamn, enamn, personnr, telefonnr, adress, postnr, postort, epost, losenord, fk_behorighet) VALUES (@fnamn, @enamn, @personnr, @telefonnr, @adress, @postnr, @postort, @epost, @losenord, @behorighet)";


                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@fnamn", nymedlem.fnamn);
                cmd.Parameters.AddWithValue("@enamn", nymedlem.enamn);
                cmd.Parameters.AddWithValue("@personnr", nymedlem.personnr);
                cmd.Parameters.AddWithValue("@telefonnr", nymedlem.telefonnr);
                cmd.Parameters.AddWithValue("@adress", nymedlem.adress);
                cmd.Parameters.AddWithValue("@postnr", nymedlem.postnr);
                cmd.Parameters.AddWithValue("@postort", nymedlem.postort);
                cmd.Parameters.AddWithValue("@epost", nymedlem.epost);
                cmd.Parameters.AddWithValue("@losenord", nymedlem.losenord);
                cmd.Parameters.AddWithValue("@behorighet", nymedlem.behorighet);

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('" + nymedlem.fnamn +" " +nymedlem.enamn+ " är nu registrerad" + "')</script>");
            }
            else
            {
                Response.Write("<script>alert('" + "Epost redan registrerad" + "')</script>");
            
            }


            
        }


    }
}