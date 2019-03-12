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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (Request.Cookies["local"] != null)
            {
                Session.Add("name", Request.Cookies["local"].Values["name"]);
                Session.Add("pass", Request.Cookies["local"].Values["pass"]);
                Session.Add("id", Request.Cookies["local"].Values["id"]);
                Response.Redirect("~/Profile.aspx");
                

            }
            //lbl_status.Text = Session.SessionID;
            if (Session["name"] != null)
            {
                Response.Redirect("~/Profile.aspx");
            }

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select Std_ID from Student where Std_Name=@name and Std_Passwoer=@pass", con);
            cmd.Parameters.AddWithValue("@name",txt_lgname.Text );
            cmd.Parameters.AddWithValue("@pass",txt_lgpass.Text );

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                if (cb_remember.Checked == true)
                {
                    HttpCookie co = new HttpCookie("local");
                    co.Values.Add("name", txt_lgname.Text); // co.Values.Add("name", dr["Std_Name"].ToString());
                    co.Values.Add("pass", txt_lgpass.Text); // co.Values.Add("pass", dr["Std_Password"].ToString());
                    co.Values.Add("id", dr["Std_ID"].ToString());

                    co.Expires = DateTime.Now.AddDays(10);
                    Response.Cookies.Add(co);

                }
                Session.Add("id", dr["Std_ID"].ToString());
                Response.Redirect("~/Profile.aspx");
            }
            else
            {
                lbl_status.Text = "invalid username or password";

            }
            con.Close();
        }
    }
}