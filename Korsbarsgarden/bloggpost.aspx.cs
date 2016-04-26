using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Configuration;

namespace Korsbarsgarden
{
    public partial class bloggpost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            nyhet nyhet = new nyhet();
            nyhet = nyhetspost(Request.QueryString["field1"]);

            lbl_head.Text = nyhet.rubrik;
            lbl_date.Text = "<i class='fa fa-clock-o'></i> " + nyhet.datum.ToShortDateString();
            lbl_blogtext.Text = nyhet.text;
        }

        private nyhet nyhetspost(string vilkenblogg)
        {
            string sql = "SELECT * FROM nyheter where rubrik = '" + vilkenblogg + "'";
            nyhet aktuellnyhet = new nyhet();
            
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                aktuellnyhet.datum = Convert.ToDateTime(dr["datum"]);
                aktuellnyhet.rubrik = dr["rubrik"].ToString();
                aktuellnyhet.text = dr["text"].ToString();
                aktuellnyhet.skrivenav = dr["publicerare"].ToString();
            }
            conn.Close();
            return aktuellnyhet;
        }
    }
}