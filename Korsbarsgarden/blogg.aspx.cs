using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;

namespace Korsbarsgarden
{
    public partial class blogg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<nyhet> nyhetslista = new List<nyhet>();
            nyhetslista = getnews();
            
            if (!IsPostBack)
            {
                //Hämta de senaste nyheterna
               
                DataTable dt = new DataTable();
                dt = getLatestNews();
                RepeaterNews.DataSource = dt;
                RepeaterNews.DataBind();
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
                sql = "SELECT id, rubrik, SUBSTRING(text, 0, 100) AS text, datum FROM nyheter " +
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
    }
}