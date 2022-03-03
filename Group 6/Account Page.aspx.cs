using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Type"] == null)
        {
            Response.Write("<script>alert('Please log in！')</script>");
            string strRedirectPage = "Login.aspx";
            string strRedirectTime = "0";
            string strRedirect = string.Format("{0};url={1}", strRedirectTime, strRedirectPage);
            Response.AddHeader("refresh", strRedirect);
        }
    }

    protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}