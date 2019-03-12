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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Student where Std_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", Session["id"].ToString());
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lbl_name.Text = dr["Std_Name"].ToString();
            lbl_gender.Text = dr["Std_Gender"].ToString();
            lbl_email.Text = dr["Std_Email"].ToString();
            lbl_age.Text = dr["Std_Age"].ToString();
            img_profile.ImageUrl = dr["Std_img"].ToString();

        }

        protected void lb_cp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangePassword.aspx");
        }

        protected void lb_logout_Click(object sender, EventArgs e)
        {
            //Session["id"] = null;
            HttpCookie co1 = new HttpCookie("local");
            co1.Expires = DateTime.Now.AddDays(-10);
            Response.Cookies.Add(co1);
            Response.Redirect("~/Login.aspx");

        }

        protected void btn_saveedits_Click(object sender, EventArgs e)
        {
            string path = "~/Img/" + fu_imgedit.FileName;
            
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmr = new SqlCommand("select* from Student where Std_ID=@id ", con1);
            cmr.Parameters.AddWithValue("@id", Session["id"].ToString());
            con1.Open();
            SqlDataReader dr = cmr.ExecuteReader();
            dr.Read();
            if (txt_edname.Text == "") txt_edname.Text = dr["Std_Name"].ToString();
            if (txt_edage.Text == "") txt_edage.Text = dr["Std_Age"].ToString();
            if (txt_edmail.Text == "") txt_edmail.Text = dr["Std_Email"].ToString();
            if (rbl_edgender.SelectedIndex == -1) rbl_edgender.SelectedValue = dr["Std_Gender"].ToString();
            if (!fu_imgedit.HasFile) path=dr["Std_img"].ToString();
            con1.Close();
            fu_imgedit.SaveAs(Server.MapPath(path));
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("update Student set Std_Name =@name, Std_Age=@age, Std_Email=@email, Std_Gender=@gender, Std_img=@img where Std_ID=@id ", con);           
            
            cmd.Parameters.AddWithValue("@name", txt_edname.Text);
            cmd.Parameters.AddWithValue("@age", txt_edage.Text);
            cmd.Parameters.AddWithValue("@email",txt_edmail.Text );
            cmd.Parameters.AddWithValue("@gender",rbl_edgender.Text );
            cmd.Parameters.AddWithValue("@id", Session["id"].ToString());
            cmd.Parameters.AddWithValue("@img", path);        
            
            con.Open();
            cmd.ExecuteNonQuery();
            

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmdm = new SqlCommand("select * from Student where Std_ID=@id", con);
            cmdm.Parameters.AddWithValue("@id", Session["id"].ToString());
            conn.Open();
            SqlDataReader dr1 = cmdm.ExecuteReader();
            dr1.Read();
            lbl_name.Text = dr1["Std_Name"].ToString();
            lbl_gender.Text = dr1["Std_Gender"].ToString();
            lbl_email.Text = dr1["Std_Email"].ToString();
            lbl_age.Text = dr1["Std_Age"].ToString();
            conn.Close();
            con.Close();
            Page_Load(null, null);
        }

        protected void lb_edit_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;

        }
    }
}