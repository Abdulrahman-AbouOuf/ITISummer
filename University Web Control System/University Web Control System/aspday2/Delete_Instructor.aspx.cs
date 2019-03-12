using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspday2
{
    public partial class Delete_Instructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);                
                SqlCommand cmd1 = new SqlCommand("select Dept_ID ,Dept_Name from Department");
                DataTable dt=DbLayer.sel(cmd1);
                //con1.Open();               
                          
                ddl_deptdel.DataSource = dt;
                ddl_deptdel.DataTextField = "Dept_Name";
                ddl_deptdel.DataValueField = "Dept_ID";
                ddl_deptdel.DataBind();
                //con1.Close();

                SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
                SqlCommand cmd2 = new SqlCommand("select Dept_ID ,Dept_Name from Department", con2);
                con2.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                ddl_inst.DataSource = dr2;
                ddl_inst.DataTextField = "Dept_Name";
                ddl_inst.DataValueField = "Dept_ID";
                ddl_inst.DataBind();
                con2.Close();

                SqlConnection con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
                SqlCommand cmd3 = new SqlCommand("select Dept_ID ,Dept_Name from Department", con3);
                con3.Open();
                SqlDataReader dr3 = cmd3.ExecuteReader();
                ddl_deptadd.DataSource = dr3;
                ddl_deptadd.DataTextField = "Dept_Name";
                ddl_deptadd.DataValueField = "Dept_ID";
                ddl_deptadd.DataBind();
                con3.Close();

                ddl_inst_SelectedIndexChanged(null, null);
                ddl_deptdel_SelectedIndexChanged(null, null);

            }
            

        }

        protected void ddl_inst_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select i.Inst_ID, i.Inst_Name, i.Inst_Age, i.Inst_email, i.Inst_Gender, d.Dept_Name from Instructor i ,Department d where i.Inst_Dept_ID=d.Dept_ID and i.Inst_Dept_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", ddl_inst.SelectedValue);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            gv_inst.DataSource = dr;
            gv_inst.DataBind();
            con.Close();
        }

        protected void ddl_deptdel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("select Inst_ID ,Inst_Name from Instructor where Inst_dept_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", ddl_deptdel.SelectedValue);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            ddl_instdel.DataSource = dr;
            ddl_instdel.DataTextField = "Inst_Name";
            ddl_instdel.DataValueField = "Inst_ID";
            ddl_instdel.DataBind();
            con.Close();
        }

        protected void btn_del_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from Instructor where Inst_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", ddl_instdel.SelectedValue);
            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            ddl_deptdel_SelectedIndexChanged(null, null);
            ddl_inst_SelectedIndexChanged(null, null);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmm = new SqlCommand("insert into Instructor values(@Inst_Name,@Inst_Age,@Inst_email,@Inst_Gender,@did)", con);
            cmm.Parameters.AddWithValue("@Inst_name", txt_nameadd.Text);
            cmm.Parameters.AddWithValue("@Inst_age", txt_ageadd.Text);            
            cmm.Parameters.AddWithValue("@Inst_email", txt_emailadd.Text);
            cmm.Parameters.AddWithValue("@Inst_gender", rbl_genderadd.SelectedValue);
            cmm.Parameters.AddWithValue("@did", ddl_deptadd.SelectedValue);           

            con.Open();
            cmm.ExecuteNonQuery();
            con.Close();
            txt_nameadd.Text = txt_emailadd.Text = txt_ageadd.Text = "";
            rbl_genderadd.SelectedIndex = -1;
            ddl_inst_SelectedIndexChanged(null, null);
            ddl_deptdel_SelectedIndexChanged(null, null);

        }

        protected void gv_inst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gv_inst_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["iticon"].ConnectionString);
            SqlCommand cmd = new SqlCommand("delete from Instructor where Inst_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", gv_inst.DataKeys[e.RowIndex].Value);
            //ddl_instdel.SelectedValue = e.RowIndex.ToString();
            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            ddl_inst_SelectedIndexChanged(null, null);
            ddl_deptdel_SelectedIndexChanged(null, null);

        }
    }
}