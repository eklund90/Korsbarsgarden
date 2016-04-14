using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;
using System.Configuration;
using System.Diagnostics;
using System.Data;
using System.Net.Mail;
using Korsbarsgarden.classes;

namespace Korsbarsgarden
{
    public class methods
    {
        public static string checkUserPasswordExist(string userPassword)
        {
            string sql;
            NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["korsbarsgarden"].ConnectionString);
            int amount = 0;
            List<medlem> memberList = new List<medlem>();
            try
            {
                conn.Open();
                sql = "select * from medlem";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    medlem newMember = new medlem();
                    newMember.fnamn = dr["fnamn"].ToString();
                    newMember.enamn = dr["enamn"].ToString();
                    memberList.Add(newMember);
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
            return memberList.ToString();
            //    conn.Open();
            //    string plsql = string.Empty;

            //    plsql = plsql + "SELECT 1 AS amount ";
            //    plsql = plsql + " FROM users ";
            //    plsql = plsql + " WHERE user_password = :newUserPassword;";
            //    NpgsqlCommand command = new NpgsqlCommand(@plsql, conn);


            //    command.Parameters.Add(new NpgsqlParameter("newUserpassword", NpgsqlDbType.Varchar));
            //    command.Parameters["newUserPassword"].Value = userPassword;

            //    NpgsqlDataReader dr = command.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        amount = (int)(dr["amount"]);
            //    }
            //}
            //finally
            //{
            //    conn.Close();
            //}
            //if (amount > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
    }
}