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
            PanelResponse_uppdaterakonto.Visible = false;
            if(!IsPostBack)
            {

                fyllmedlem(getMember(Convert.ToInt16(Session["id"])));
            }
            
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
        protected void btn_uppdatera_Click(object sender, EventArgs e)
        {
            medlem nyMember = new medlem();
            nyMember.fnamn = txtbox_minasidor_fornamn.Text;
            nyMember.enamn = txtbox_minasidor_efternamn.Text;
            nyMember.personnr = txtbox_minasidor_personnr.Text;
            nyMember.telefonnr = txtbox_minasidor_telefonnr.Text;
            nyMember.adress = txtbox_minasidor_adress.Text;
            nyMember.postnr = txtbox_minasidor_postnr.Text;
            nyMember.postort = txtbox_minasidor_postort.Text;
            nyMember.epost = txtbox_minasidor_epost.Text;

            uppdateramedlem(Convert.ToInt16(Session["id"]), nyMember);
           
            PanelResponse_uppdaterakonto.Visible = true;
            PanelResponse_uppdaterakonto.CssClass = "alert-success alert PanelResponse";
            LabelResponse_uppdaterakonto.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Användaren är nu uppdaterad.";
        }

        public static medlem uppdateramedlem(int id, medlem nymedlem)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            string sql;
            try
            {
                conn.Open();
                sql = "update medlem set fnamn='" + nymedlem.fnamn+ "', enamn='"+nymedlem.enamn+"', personnr='"+nymedlem.personnr+"', telefonnr='"+nymedlem.telefonnr+"', adress='"+ nymedlem.adress+"', postnr='"+nymedlem.postnr+"', postort='"+nymedlem.postort+"', epost='"+nymedlem.epost+"' where id='" + id + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            finally
            {
                conn.Close();
            }
            return nymedlem;
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