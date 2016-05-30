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
            Page.MaintainScrollPositionOnPostBack = true;
            if(!IsPostBack)
            {
                PanelResponse_skapakonto.Visible = false;
                btn_no.Visible = false;
                btn_yes.Visible = false;

                memberList = getMemberList();
                foreach (medlem m in memberList)
                {
                    ListItem Data = new ListItem();
                    Data.Text = m.fnamn;
                    Data.Value = m.id.ToString();
                    medlemlist.Items.Add(Data);

                    //medlemlist.Items.Add(m.fnamn.ToString() + " " + m.enamn.ToString());
                    //medlemlist.DataSource = getMemberList();
                    //medlemlist.DataBind();
                }           
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
            nymedlem.epost = txtBox_skapakonto_epost.Text.ToLower();
            nymedlem.losenord = SHA256.ComputeHash(txtBox_skapakonto_losenord.Text, Supported_HA.SHA256, null);
            nymedlem.behorighet = Convert.ToInt16(dropdown_skapakonto_behorighet.Text);
            läggtillmedlem(nymedlem);
                        
            medlemlist.Items.Clear();
            memberList = getMemberList();

            foreach (medlem m in memberList)
            {
                ListItem Data = new ListItem();
                Data.Text = m.fnamn;
                Data.Value = m.id.ToString();
                medlemlist.Items.Add(Data);

            }
        }

        protected void btn_tabortkonto_Click(object sender, EventArgs e)
        {
            //tabortmedlem(Convert.ToInt16(medlemlist.SelectedValue));
            //clearmedlem();
            //medlemlist.Items.Clear();

            //foreach (medlem m in getMemberList())
            //{
            //    ListItem Data = new ListItem();
            //    Data.Text = m.fnamn;
            //    Data.Value = m.id.ToString();
            //    medlemlist.Items.Add(Data);
            //}
            PanelResponse_skapakonto.Visible = true;
            btn_yes.Visible = true;
            btn_no.Visible = true;
            PanelResponse_skapakonto.CssClass = "alert-warning alert PanelResponse";
            LabelResponse_skapakonto.Text = "Är du säker? ";
        }
        protected void btn_uppdaterakonto_Click(object sender, EventArgs e)
        {
            nymedlem.id = Convert.ToInt16(txtBox_skapakonto_id.Text);
            nymedlem.fnamn = txtBox_skapakonto_fornamn.Text;
            nymedlem.enamn = txtBox_skapakonto_efternamn.Text;
            nymedlem.personnr = txtBox_skapakonto_personnr.Text;
            nymedlem.telefonnr = txtBox_skapakonto_telefonnr.Text;
            nymedlem.adress = txtBox_skapakonto_adress.Text;
            nymedlem.postnr = txtBox_skapakonto_postnr.Text;
            nymedlem.postort = txtBox_skapakonto_postort.Text;
            nymedlem.epost = txtBox_skapakonto_epost.Text.ToLower();
            nymedlem.behorighet = Convert.ToInt16(dropdown_skapakonto_behorighet.Text);
            uppdateramedlem(nymedlem);

            medlemlist.Items.Clear();
            memberList = getMemberList();

            foreach (medlem m in memberList)
            {
                ListItem Data = new ListItem();
                Data.Text = m.fnamn;
                Data.Value = m.id.ToString();
                medlemlist.Items.Add(Data);
            }   
        }
        protected void medlemlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            fyllmedlem(getMember(Convert.ToInt16(medlemlist.SelectedValue)));
        }

        #region metoder
        public void fyllmedlem(medlem nyMember)
        {
                txtBox_skapakonto_id.Text = nyMember.id.ToString();
                txtBox_skapakonto_fornamn.Text = nyMember.fnamn;
                txtBox_skapakonto_efternamn.Text = nyMember.enamn;
                txtBox_skapakonto_personnr.Text = nyMember.personnr;
                txtBox_skapakonto_telefonnr.Text = nyMember.telefonnr;
                txtBox_skapakonto_adress.Text = nyMember.adress;
                txtBox_skapakonto_postnr.Text = nyMember.postnr;
                txtBox_skapakonto_postort.Text = nyMember.postort;
                txtBox_skapakonto_epost.Text = nyMember.epost.ToLower();
                dropdown_skapakonto_behorighet.Text = Convert.ToInt16(nyMember.behorighet).ToString();
            
        }
        public void clearmedlem()
        {
            txtBox_skapakonto_id.Text = string.Empty;
            txtBox_skapakonto_fornamn.Text = string.Empty;
            txtBox_skapakonto_efternamn.Text = string.Empty;
            txtBox_skapakonto_personnr.Text = string.Empty;
            txtBox_skapakonto_telefonnr.Text = string.Empty;
            txtBox_skapakonto_adress.Text = string.Empty;
            txtBox_skapakonto_postnr.Text = string.Empty;
            txtBox_skapakonto_postort.Text = string.Empty;
            txtBox_skapakonto_epost.Text = string.Empty;
            txtBox_skapakonto_losenord.Text = string.Empty;
            dropdown_skapakonto_behorighet.Text = string.Empty;
            
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
                    memberList.Add(new medlem {id = (int)dr["id"], fnamn = dr["fnamn"].ToString() + " " + dr["enamn"].ToString()});
                    //medlem nymedlem = new medlem();
                    //nymedlem.fnamn = (string)(dr["fnamn"]);
                    //nymedlem.enamn = (string)(dr["enamn"]);
                    //nymedlem.personnr = (string)(dr["personnr"]);
                    //nymedlem.telefonnr = (string)(dr["telefonnr"]);
                    //nymedlem.adress = (string)(dr["adress"]);
                    //nymedlem.postnr = (string)(dr["postnr"]);
                    //nymedlem.postort = (string)(dr["postort"]);
                    //nymedlem.epost = (string)(dr["epost"]);
                    //nymedlem.behorighet = (int)(dr["fk_behorighet"]);
                    
                    //memberList.Add(nymedlem);
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

        public static medlem getMember(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            medlem nymedlem = new medlem();
            try
            {
                conn.Open();
                string sql;
                sql = "select * from medlem WHERE id = '"+id+"'";

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

        public void tabortmedlem(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            string sql;
            conn.Open();
            try
            {
                sql = "DELETE from medlem WHERE id='"+id+"'";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                PanelResponse_skapakonto.Visible = true;
                PanelResponse_skapakonto.CssClass = "alert-success alert PanelResponse";


                LabelResponse_skapakonto.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Användaren är nu borttagen.";
            }
            finally
            {
                conn.Close();
            }
        }

        public void uppdateramedlem(medlem nymedlem)
        {           
            string sql;
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            sql = "UPDATE medlem SET fnamn='"+ nymedlem.fnamn + "', enamn='" +nymedlem.enamn+"', personnr='"+nymedlem.personnr+"', telefonnr='"+nymedlem.telefonnr+"', adress='"+nymedlem.adress+"', postnr='"+nymedlem.postnr+"', postort='"+nymedlem.postort+"', epost='"+nymedlem.epost.ToLower()+"' WHERE id='" + nymedlem.id +"'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            conn.Open();

            try
            {
            cmd.ExecuteNonQuery();
            conn.Close();
            PanelResponse_skapakonto.Visible = true;
            PanelResponse_skapakonto.CssClass = "alert-success alert PanelResponse";


            LabelResponse_skapakonto.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Användaren är nu uppdaterad.";
            }         
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            

        }
        #endregion metoder

        protected void btn_yes_Click(object sender, EventArgs e)
        {
            tabortmedlem(Convert.ToInt16(medlemlist.SelectedValue));
            clearmedlem();
            medlemlist.Items.Clear();

            foreach (medlem m in getMemberList())
            {
                ListItem Data = new ListItem();
                Data.Text = m.fnamn;
                Data.Value = m.id.ToString();
                medlemlist.Items.Add(Data);
            }

            PanelResponse_skapakonto.Visible = true;
            //PanelResponse_skapakonto.CssClass = "alert-warning alert PanelResponse";
            btn_no.Visible = false;
            btn_yes.Visible = false;

            //LabelResponse_skapakonto.Text = "<span class='spacer-glyph glyphicon glyphicon-exclamation-sign'></span> Användaren är nu raderad.";
        }

        protected void btn_no_Click(object sender, EventArgs e)
        {
            PanelResponse_skapakonto.Visible = false;
            btn_no.Visible = false;
            btn_yes.Visible = false;
        }


  
    }
}