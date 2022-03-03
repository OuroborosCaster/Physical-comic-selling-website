using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class registerPage : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool CheckUser()
    {                    
        string sql = "select * from Users where NickName=  '" + txtUsername.Text + "'";        
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
        da.Fill(dt);
        
        if (dt.Rows.Count > 0)
        {
            lblMsg.Text = " <h2>User already exists</h2>";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return false;
        }
        else
        {
            return true;
        }
        
    }

    protected void btnSign_Click(object sender, EventArgs e)
    {

        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();

            if (Page.IsValid)
            {

                lblMsg.Text = "<h1>You passed validation! 3 seconds later jump to login page automatically.</h1>"; 
                string strRedirectPage = "Login.aspx";
                string strRedirectTime = "3";
                string strRedirect = string.Format("{0};url={1}", strRedirectTime, strRedirectPage);
                Response.AddHeader("refresh", strRedirect);

            }

            if (CheckUser() == false)
            {
                return;
            }

        string insertQuery = "INSERT INTO Users(NickName,Password,Email) values(@nickname,@password,@email)";
        SqlCommand com = new SqlCommand(insertQuery, conn);
        com.Parameters.AddWithValue("@nickname", txtUsername.Text);
        com.Parameters.AddWithValue("@password", txtPassword.Text);
        com.Parameters.AddWithValue("@email", txtEmail.Text);
        com.ExecuteNonQuery();

        conn.Close();

        }           
    }
}