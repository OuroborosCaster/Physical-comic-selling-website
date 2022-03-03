using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
      

        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Users] WHERE NickName=@nickname AND Password=@password", conn);
            cmd.Parameters.AddWithValue("@nickname", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPwd.Text);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["UserName"] = dr["NickName"].ToString();
                    Session["Type"] = dr["Admin"].ToString();
                    Response.Redirect("~/Home.aspx");
                    /*int userRole = Convert.ToInt16(dr["Admin"].ToString());
                    switch (userRole)
                    {
                        case 0:
                            Response.Redirect("~/Account Page.aspx");
                            break;
                        case 1:
                            Response.Redirect("~/Home.aspx");
                            break;
                        case 2:
                            Response.Redirect("~/adMinPage.aspx");
                            break;
                        case 3:
                            Response.Redirect("Manage_information_page.aspx");
                            break;
                        


                    }*/
                }
            }
            else
            {
                lblMessage.Text = "Username and password is not valid!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            //lblMessage.Text = ex.ToString();
            Response.Write(ex.ToString());
        }
    }

    
}