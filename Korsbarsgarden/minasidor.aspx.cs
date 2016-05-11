using Korsbarsgarden.classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Korsbarsgarden
{
    public partial class minasidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fyllmedlem(getMember(Convert.ToInt16(Session["id"])));
        }

        public void fyllmedlem(medlem nyMember)
        {
            txtbox_minasidor_id.Text = nyMember.id.ToString();
            txtbox_minasidor_fornamn.Text = nyMember.fnamn;
            txtbox_minasidor_efternamn.Text = nyMember.enamn;
            txtbox_minasidor_personnr.Text = nyMember.personnr;
            txtbox_minasidor_telefonnr.Text = nyMember.telefonnr;
            txtbox_minasidor_adress.Text = nyMember.adress;
            txtbox_minasidor_postnr.Text = nyMember.postnr;
            txtbox_minasidor_postort.Text = nyMember.postort;
            txtbox_minasidor_epost.Text = nyMember.epost;


        }
        public static medlem getMember(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            medlem nymedlem = new medlem();
            try
            {
                conn.Open();
                string sql;
                sql = "select * from medlem WHERE id = '" + id + "'";

                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    nymedlem.id = (int)(dr["id"]);
                    nymedlem.fnamn = (string)(dr["fnamn"]);
                    nymedlem.enamn = (string)(dr["enamn"]);
                    nymedlem.personnr = (string)(dr["personnr"]);
                    nymedlem.telefonnr = (string)(dr["telefonnr"]);
                    nymedlem.adress = (string)(dr["adress"]);
                    nymedlem.postnr = (string)(dr["postnr"]);
                    nymedlem.postort = (string)(dr["postort"]);
                    nymedlem.epost = (string)(dr["epost"]);
                    nymedlem.losenord = (string)(dr["losenord"]);
                    nymedlem.behorighet = (int)(dr["fk_behorighet"]);

                }
            }
            finally
            {
                conn.Close();
            }
            return nymedlem;
        }
    }
}