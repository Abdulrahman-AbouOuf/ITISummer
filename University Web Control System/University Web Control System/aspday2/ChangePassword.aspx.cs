using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspday2
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btn_change_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update Student set Std_Passwoer=@pass where Std_ID=@id ", con);
            
            cmd.Parameters.AddWithValue("@pass", txt_newconpass.Text);
            cmd.Parameters.AddWithValue("@id", Session["id"].ToString());

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Profile.aspx");
        }
    }
}