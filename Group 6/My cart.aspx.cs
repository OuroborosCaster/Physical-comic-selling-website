using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class My_cart : System.Web.UI.Page
{
    string s;
    string t;
    string[] a = new string[8];

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

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[8]
        {
            new DataColumn("Name"),new DataColumn("UnitPrice"),new DataColumn("CoverFile"),new DataColumn("PublishCountry"),new DataColumn("Author"),new DataColumn("Description"),new DataColumn("Translator"),new DataColumn("id")
        });
        if (Request.Cookies["aa"] != null)
        {
            s = Convert.ToString(Request.Cookies["aa"].Value);
            string[] strArr = s.Split('|');
            for (int i = 0; i < strArr.Length; i++)
            {
                t = Convert.ToString(strArr[i].ToString());
                string[] strArr1 = t.Split(',');

                for (int j = 0; j < 8; j++)
                {
                    a[j] = strArr1[j].ToString();
                }


                dt.Rows.Add
                    (a[0].ToString(),
                    a[1].ToString(),
                    a[2].ToString(),
                    a[3].ToString(),
                    a[4].ToString(),
                    a[5].ToString(),
                    a[6].ToString(),
                    i.ToString());


            }

            d1.DataSource = dt;
            d1.DataBind();
        }
    }


}