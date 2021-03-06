﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Configuration;

namespace Korsbarsgarden
{
    public partial class skapablogg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelResponse_skapakonto.Visible = false;
        }

        protected void btn_skapainlägg_Click(object sender, EventArgs e)
        {
            nyhet nyhet = new nyhet();
            nyhet.rubrik = txtBox_rubrik.Text;
            nyhet.text = txtBox_text.Text;
            nyhet.datum = DateTime.Today;

            if (fileupload_blogg.HasFile)
            {
                fileupload_blogg.SaveAs(Server.MapPath("images\\" + fileupload_blogg.FileName));

            }

            if (fileupload_fil.HasFile)
            {
                fileupload_fil.SaveAs(Server.MapPath("pdf\\" + fileupload_fil.FileName));

            }

            //jag har en bananan som heter banane tihi
            if (!string.IsNullOrEmpty(Session["fnamn"] as string) && !string.IsNullOrEmpty(Session["enamn"] as string))
            {
                nyhet.skrivenav = Session["fnamn"].ToString() + " " + Session["enamn"].ToString();
            }
            else
            {
                nyhet.skrivenav = "Admin";
            }

            string sql = "INSERT INTO nyheter (rubrik, text, datum, publicerare, bild, fil) VALUES (@rubrik, @text, @datum, @publicerare, @bild, @fil)";
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);

            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@rubrik", nyhet.rubrik);
            cmd.Parameters.AddWithValue("@text", nyhet.text);
            cmd.Parameters.AddWithValue("@datum", nyhet.datum);
            cmd.Parameters.AddWithValue("@publicerare", nyhet.skrivenav);
            if (fileupload_blogg.HasFile)
            {
                cmd.Parameters.AddWithValue("@bild", "images/" +fileupload_blogg.FileName.ToString());

            }
            else
            {
                cmd.Parameters.AddWithValue("@bild", "images/korsbarsgarden_logo.png" );
            }
            cmd.Parameters.AddWithValue("@fil", fileupload_fil.FileName.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();

            PanelResponse_skapakonto.Visible = true;
            PanelResponse_skapakonto.CssClass = "alert-success alert PanelResponse";
            LabelResponse_skapakonto.Text = "Inlägget är sparat!";

            txtBox_rubrik.Text = "";
            txtBox_text.Text = "";
            
        }
    }
}