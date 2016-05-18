using Korsbarsgarden.classes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace Korsbarsgarden
{
    public partial class blogg : System.Web.UI.Page
    {
        public medlem nymedlem = new medlem();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<nyhet> nyhetslista = new List<nyhet>();
            nyhetslista = getnews();

            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = getLatestNews();
                RepeaterNews.DataSource = dt;
                RepeaterNews.DataBind();
            }

            nymedlem.id = Convert.ToInt32(Session["id"]);
            nymedlem.behorighet = Convert.ToInt32(Session["behorighet"]);

            if (nymedlem.behorighet == 1)
            {

                foreach (RepeaterItem item in RepeaterNews.Items)
                {
                    Button btncontrol = item.FindControl("btn_tabort") as Button;
                    if (btncontrol != null)
                    {
                        btncontrol.Visible = true;
                    }

                }
            }
            else
            {

            }

        }

        public static List<nyhet> getnews()
        {
            List<nyhet> nyhetslista = new List<nyhet>();
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);

            try
            {
                conn.Open();
                string sql = string.Empty;
                sql = "SELECT id, rubrik, SUBSTRING(text, 0, 20) AS text, datum FROM nyheter;";
                NpgsqlCommand command = new NpgsqlCommand(@sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    nyhet nynyhet = new nyhet();
                    nynyhet.id = Convert.ToInt16(dr["id"]);
                    nynyhet.rubrik = dr["rubrik"].ToString();
                    nynyhet.text = dr["text"].ToString();


                    nynyhet.datum = (DateTime)(dr["datum"]);
                    nyhetslista.Add(nynyhet);

                }
            }
            finally
            {
                conn.Close();
            }
            return nyhetslista;
        }
        public static DataTable getLatestNews()
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            DataTable dt = new DataTable();
            string sql;

            try
            {
                sql = "SELECT id, rubrik, SUBSTRING(text, 0, 100) AS text, datum, bild, fil FROM nyheter " +
                      "ORDER BY datum DESC, id DESC " +
                      "LIMIT 10;";
                conn.Open();

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            catch (NpgsqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        protected void btn_readmore_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Response.Redirect("bloggpost.aspx?field1=" + e.CommandArgument.ToString());
        }

        protected void lb_blogg_Click(object sender, EventArgs e)
        {

        }

        protected void lb_blogg_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

            if (e.CommandName == "download")
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/pdf/") + e.CommandArgument);
                Response.End();
            }
            else
            {

            }
        }

        protected void btn_tabort_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            string nyhetsid = e.CommandArgument.ToString();
            tabortnyhet(nyhetsid);
            List<nyhet> nyhetslista = new List<nyhet>();
            nyhetslista = getnews();

                DataTable dt = new DataTable();
                dt = getLatestNews();
                RepeaterNews.DataSource = dt;
                RepeaterNews.DataBind();

        }

        public void tabortnyhet(string nyhetsid)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            string sqldel;
            try
            {
                conn.Open();
                sqldel = "Delete from nyhetskommentar Where fk_nyhet = '" + nyhetsid + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sqldel, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
            
            
            string sql;
            try
            {
                conn.Open();
                sql = "Delete from nyheter Where id = '" + nyhetsid + "'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
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
    }
}