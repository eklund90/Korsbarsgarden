using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Configuration;
using System.Data;

namespace Korsbarsgarden
{
    public partial class bloggpost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            nyhet nyhet = new nyhet();
            nyhet = nyhetspost(Convert.ToInt16(Request.QueryString["field1"]));

            lbl_head.Text = nyhet.rubrik + " Av " + nyhet.skrivenav;
            //lbl_date.Text = "<i class='fa fa-clock-o'></i> " + nyhet.datum.ToShortDateString();
            lbl_blogtext.Text = nyhet.text;
            paragraph.InnerText = nyhet.rubrik;
            PanelResponse_bloggpost.Visible = false;

            if (!IsPostBack)
            {
                Repeater_kommentar.DataSource = hämtaKommentarer(Convert.ToInt16(Request.QueryString["field1"]));
                Repeater_kommentar.DataBind();
            }
        }

        private nyhet nyhetspost(int id)
        {
            string sql = "SELECT * FROM nyheter where id = '" + id + "'";
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

        private void sparaKommentar()
        {
            string sql = "INSERT INTO nyhetskommentar (datum, text, publicerare, fk_nyhet) VALUES (@datum, @text, @publicerare, @fknyhet)";

            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@datum", DateTime.Now);
            cmd.Parameters.AddWithValue("@text", txtBox_kommentar.Text);
            cmd.Parameters.AddWithValue("@publicerare", Session["fnamn"] + " " + Session["enamn"]);
            cmd.Parameters.AddWithValue("@fknyhet", Request.QueryString["field1"]);

            cmd.ExecuteNonQuery();
            conn.Close();

            PanelResponse_bloggpost.Visible = true;
            PanelResponse_bloggpost.CssClass = "alert-success alert PanelResponse";
            LabelResponse_bloggpost.Text = "Kommentaren är sparad!";

            txtBox_kommentar.Text = "";

        }

        private DataTable hämtaKommentarer(int fk)
        {
            string sql = "SELECT * FROM nyhetskommentar WHERE fk_nyhet = '" + fk + "'";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            conn.Open();
            DataTable dt = new DataTable();

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);

            da.Fill(dt);
            conn.Close();
            return dt;
        }

        protected void btn_sparakommentar_Click(object sender, EventArgs e)
        {
            sparaKommentar();
            Repeater_kommentar.DataSource = hämtaKommentarer(Convert.ToInt16(Request.QueryString["field1"]));
            Repeater_kommentar.DataBind();
        }
    }
}