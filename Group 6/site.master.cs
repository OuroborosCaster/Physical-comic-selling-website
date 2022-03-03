using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Retrieve Cookie
        HttpCookie cookie = Request.Cookies["LogInCookie"];

        if (Session["UserName"] != null)
        {
            lblHi.Visible = true;
            btnLogout.Visible = true;
            lblHi.Text ="Welcome,"+ Session["UserName"].ToString();
            notLog.Visible = false;
            if (Session["Type"].ToString() == "1")
            {
                btnAdmin.Visible = true;
            }
            else
            {
                btnAdmin.Visible = false;
            }
        }
        else
        {
            btnAccount.Visible = false;
            btnCart.Visible = false;
        }


    }

    protected void btnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Home.aspx");
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/adminPage.aspx");
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/registerPage.aspx");
    }

    protected void btnCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/My cart.aspx");
    }

    protected void btnLog_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Login.aspx");
    }

    protected void btnAccount_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account Page.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("~/Home.aspx");
    }
}
