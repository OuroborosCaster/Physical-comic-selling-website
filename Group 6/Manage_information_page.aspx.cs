using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Manage_information_page : System.Web.UI.Page
{
    int id;
    String Name, UnitPrice, PublishCountry, Author, Translator, Description, CoverFile;
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
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

        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        else
        {

            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Comics where CId =" + id + "";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();

            conn.Close();
        }

    }
   

    protected void Bac1_Click(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from Comics where CId =" + id + "";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach(DataRow dr in dt.Rows)
        {
            Name = dr["Name"].ToString();
            UnitPrice = dr["UnitPrice"].ToString();
            CoverFile = dr["CoverFile"].ToString();
            PublishCountry = dr["PublishCountry"].ToString();
            Author = dr["Author"].ToString();
            Translator = dr["Translator"].ToString();
            Description = dr["Description"].ToString();
        }
        conn.Close();

        if (Request.Cookies["aa"] == null)
        {
            Response.Cookies["aa"].Value = Name.ToString() + "," + UnitPrice.ToString() + "," + CoverFile.ToString() + "," + PublishCountry.ToString() + "," + Author.ToString() + "," + Translator.ToString() + "," + Description.ToString();

            Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);


        }
        else
        {
            Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + Name.ToString() + "," + UnitPrice.ToString() + "," + CoverFile.ToString() + "," + PublishCountry.ToString() + "," + Author.ToString() + "," + Translator.ToString() + "," + Description.ToString();
        }



        
    }
}