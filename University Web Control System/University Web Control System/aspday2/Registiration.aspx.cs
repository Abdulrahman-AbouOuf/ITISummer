using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace aspday2
{
    public partial class Registiration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                txt_age.Text = txt_conpass.Text = txt_mail.Text = txt_name.Text = txt_pass.Text = "";
                rbl_gender.SelectedIndex = -1;
                ddl_dept.SelectedIndex = -1;
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select dept_id ,dept_name from department", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                ddl_dept.DataSource = dr;
                ddl_dept.DataTextField = "dept_name";
                ddl_dept.DataValueField = "dept_id";
                ddl_dept.DataBind();
                con.Close();
            }

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //upload image
                string path = "~/Img/" + fu_img.FileName;
                fu_img.SaveAs(Server.MapPath(path));

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
                SqlCommand cmm = new SqlCommand("insert into Student values(@name,@age,@pass,@email,@gender,@did,@img)", con);
                cmm.Parameters.AddWithValue("@name", txt_name.Text);
                cmm.Parameters.AddWithValue("@age", txt_age.Text);
                cmm.Parameters.AddWithValue("@pass", txt_conpass.Text);
                cmm.Parameters.AddWithValue("@email", txt_mail.Text);
                cmm.Parameters.AddWithValue("@gender", rbl_gender.SelectedValue);
                cmm.Parameters.AddWithValue("@did", ddl_dept.SelectedValue);
                cmm.Parameters.AddWithValue("@img", path);
                con.Open();
                cmm.ExecuteNonQuery();
                con.Close();
                
                Response.Redirect("~/Registiration.aspx");
                //txt_age.Text = txt_conpass.Text = txt_mail.Text = txt_name.Text = txt_pass.Text = "";
                //rbl_gender.SelectedIndex = -1;
                //ddl_dept.SelectedIndex = -1;
            }
        }
    }
}