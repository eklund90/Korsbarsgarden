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
                sql = "SELECT * FROM nyheter;";
                NpgsqlCommand command = new NpgsqlCommand(@sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    nyhet nynyhet = new nyhet();
                    nynyhet.id = (int)(dr["id"]);
                    nynyhet.rubrik = (string)(dr["rubrik"]);
                    nynyhet.text = (dr["text"]).ToString().Substring(0, 50);
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
                sql = "SELECT * FROM nyheter " +
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
    }
}