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
        List<medlem> memberList = new List<medlem>();
        protected void Page_Load(object sender, EventArgs e)
        {
            PanelResponse_skapakonto.Visible = false;        
            memberList = getMemberList();
            foreach(medlem m in memberList)
            {
                medlemlist.Items.Add(m.fnamn.ToString() + " " + m.enamn.ToString());
            }
            
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

        protected void btn_tabortkonto_Click(object sender, EventArgs e)
        {

        }

        #region metoder
        public void fyllmedlem(int id_member)
        {
            //medlem nyMember = new medlem();
            //nyMember = methods.getMember(id_member);
            //if (nyMember.memberId > 0)
            //{

            //    txtBox_skapakonto_fornamn.Text = nyMember.firstName;
            //    txtBox_skapakonto_efternamn.Text = newMember.lastName;
            //    txtBox_skapakonto_personnr.Text = newMember.address;
            //    txtBox_skapakonto_telefonnr.Text = newMember.postalCode;
            //    txtBox_skapakonto_adress.Text = newMember.city;
            //    txtBox_skapakonto_postnr.Text = newMember.mail;
            //    txtBox_skapakonto_postort.Text = newMember.gender;
            //    txtBox_skapakonto_epost.Text =
            //    dropdown_skapakonto_behorighet.Text = newMember.hcp.ToString();
            //    tbMail.Text = newMember.mail;
            //    tbGolfId.Text = newMember.golfId;
            }
        }
        public void läggtillmedlem(medlem nymedlem)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);

            string sqlcheck = "SELECT id from medlem WHERE epost ='" + nymedlem.epost + "'";
            NpgsqlCommand cmdcheck = new NpgsqlCommand(sqlcheck, conn);
            conn.Open();
            NpgsqlDataReader drcheck = cmdcheck.ExecuteReader();

            if (!drcheck.Read())
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

                PanelResponse_skapakonto.Visible = true;
                PanelResponse_skapakonto.CssClass = "alert-success alert PanelResponse";


                LabelResponse_skapakonto.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Användaren är nu registrerad.";
            }
            else
            {
                PanelResponse_skapakonto.Visible = true;
                PanelResponse_skapakonto.CssClass = "alert-warning alert PanelResponse";
                LabelResponse_skapakonto.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Det finns redan en användare med den eposten.";
            }
        }
        public static List<medlem> getMemberList()
        {
            List<medlem> memberList = new List<medlem>();
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            string sql;

            try
            {
                conn.Open();
                sql = "select * from medlem";
                NpgsqlCommand command = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    medlem nymedlem = new medlem();
                    nymedlem.fnamn = (string)(dr["fnamn"]);
                    nymedlem.enamn = (string)(dr["enamn"]);
                    nymedlem.personnr = (string)(dr["personnr"]);
                    nymedlem.telefonnr = (string)(dr["telefonnr"]);
                    nymedlem.adress = (string)(dr["adress"]);
                    nymedlem.postnr = (string)(dr["postnr"]);
                    nymedlem.postort = (string)(dr["postort"]);
                    nymedlem.epost = (string)(dr["epost"]);
                    nymedlem.behorighet = (int)(dr["fk_behorighet"]);
                    memberList.Add(nymedlem);
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
            return memberList;
            }

        
        #endregion metoder
    }
}