using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace aspday2
{
    public class DbLayer
    {
        public static DataTable sel(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmm = cmd;
            cmm.Connection = con;
            SqlDataAdapter adpt = new SqlDataAdapter(cmm);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
        }
        public static int dml(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmm = cmd;
            cmm.Connection = con;
            con.Open();
            int roweffect = cmm.ExecuteNonQuery();
            con.Close();
            return roweffect;

        }
    }
}