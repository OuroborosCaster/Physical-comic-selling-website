using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Delete_cart : System.Web.UI.Page
{
    string s;
    string t;
    string[] a = new string[8];
    int id;
    String Name, UnitPrice, PublishCountry, Author, Translator, Description, CoverFile;
    int count = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32(Request.QueryString["id"].ToString());
        DataTable dt = new DataTable();
        dt.Rows.Clear();
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
        }

        dt.Rows.RemoveAt(id);
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
        foreach (DataRow dr in dt.Rows)
        {
            Name = dr["Name"].ToString();
            UnitPrice = dr["UnitPrice"].ToString();
            CoverFile = dr["CoverFile"].ToString();
            PublishCountry = dr["PublishCountry"].ToString();
            Author = dr["Author"].ToString();
            Translator = dr["Translator"].ToString();
            Description = dr["Description"].ToString();

            count += 1;

            if (count == 1)
            {
                Response.Cookies["aa"].Value = Name.ToString() + "," + UnitPrice.ToString() + "," + CoverFile.ToString() + "," + PublishCountry.ToString() + "," + Author.ToString() + "," + Translator.ToString() + "," + Description.ToString();


                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);


            }
            else
            {
                Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + Name.ToString() + "," + UnitPrice.ToString() + "," + CoverFile.ToString() + "," + PublishCountry.ToString() + "," + Author.ToString() + "," + Translator.ToString() + "," + Description.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
            }


        }



        Response.Redirect("My cart.aspx");
    }
}