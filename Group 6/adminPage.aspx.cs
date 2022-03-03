using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

public partial class adminPage : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Type"] == null|| Session["Type"].ToString() != "1")
        {
            Response.Write("<script>alert('Please log in with an administrator account')</script>");
            string strRedirectPage = "Login.aspx";
            string strRedirectTime = "0";
            string strRedirect = string.Format("{0};url={1}", strRedirectTime, strRedirectPage);
            Response.AddHeader("refresh", strRedirect);            
        }

        if (!this.IsPostBack)
        {
            this.BindGrind();
        }
    }

    public void Clear()
    {
        txtID.Text = txtBookName.Text = txtPrice.Text = "";
        lblStatus.Text = "";
    }

    private void BindGrind()
    {


        using (SqlConnection conn = new SqlConnection(cs))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM [Comics]"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = conn;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        gvComic.DataSource = dt;
                        gvComic.DataBind();
                    }
                }
            }


        }
    }



    protected void gvComic_RowEditing(object sender, GridViewEditEventArgs e)

    {
        gvComic.EditIndex = e.NewEditIndex;
        BindGrind();
    }

    protected void gvComic_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvComic.EditIndex = -1;
        BindGrind();
    }



    protected void gvComic_RowUpdating(object sender, GridViewUpdateEventArgs e)

    {
        int ID = Convert.ToInt32(gvComic.DataKeys[e.RowIndex].Value.ToString());
        string Name = ((TextBox)(gvComic.Rows[e.RowIndex].Cells[1].Controls[0])).Text;
        string UnitPrice = ((TextBox)(gvComic.Rows[e.RowIndex].Cells[2].Controls[0])).Text;
        string PublishCountry = ((TextBox)(gvComic.Rows[e.RowIndex].Cells[3].Controls[0])).Text;
        string Author = ((TextBox)(gvComic.Rows[e.RowIndex].Cells[4].Controls[0])).Text;
        string Description = ((TextBox)(gvComic.Rows[e.RowIndex].Cells[5].Controls[0])).Text;
        string Translator = ((TextBox)(gvComic.Rows[e.RowIndex].Cells[6].Controls[0])).Text;
        string CoverPage = ((TextBox)(gvComic.Rows[e.RowIndex].Cells[7].Controls[0])).Text;

        using (SqlConnection conn = new SqlConnection(cs))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Comics SET Name=@name, UnitPrice=@unit, PublishCountry=@pubcontry, Author=@author, Description=@desc, Translator=@trans,CoverFile=@cfile  WHERE CId=@id", conn);


            cmd.Parameters.AddWithValue("@id", ID);
            cmd.Parameters.AddWithValue("@cfile", CoverPage);
            cmd.Parameters.AddWithValue("@trans", Translator);
            cmd.Parameters.AddWithValue("@desc", Description);
            cmd.Parameters.AddWithValue("@author", Author);
            cmd.Parameters.AddWithValue("@pubcontry", PublishCountry);
            cmd.Parameters.AddWithValue("@unit", UnitPrice);
            cmd.Parameters.AddWithValue("@name", Name);

            cmd.ExecuteNonQuery();
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("<script>alert('Data has updated!')</script>");
                gvComic.EditIndex = -1;
                BindGrind();

            }


        }

    }
    protected void gvComic_RowDeleting(object sender, GridViewDeleteEventArgs e)

    {
        int ID = Convert.ToInt32(gvComic.DataKeys[e.RowIndex].Value.ToString());
        using (SqlConnection conn = new SqlConnection(cs))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Comics WHERE CId=@id", conn);
            cmd.Parameters.AddWithValue("@id", ID);
            int rows = cmd.ExecuteNonQuery();


            Response.Write("<script>alert('Data has deleted!')</script>");
                
            BindGrind();

            
        }


    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(cs))
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Comics(CId,Name,UnitPrice) values(@Id,@name,@Uprice)", conn);
                cmd.Parameters.AddWithValue("@Id", txtID.Text);
                cmd.Parameters.AddWithValue("@name", txtBookName.Text);
                cmd.Parameters.AddWithValue("@Uprice", txtPrice.Text);
                cmd.ExecuteNonQuery();
                
                
                Response.Write("<script>alert('New comic book added successfully!')</script>");
                BindGrind();
                Clear();

            }
        }
        
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        if (FileUploadCtrl.HasFile)
        {

            if (FileUploadCtrl.PostedFile.ContentType == "image/jpeg" || FileUploadCtrl.PostedFile.ContentType == "image/jpg")
            {
                if (FileUploadCtrl.PostedFile.ContentLength < 10240000)
                {
                    string filename = Path.GetFileName(FileUploadCtrl.FileName);
                    FileUploadCtrl.SaveAs(Server.MapPath("~/img/cover/") + filename);
                    lblStatus.Text = "File uploaded!";
                    lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
                }
                else
                    lblStatus.Text = "The file has to be less than 10mb!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
                lblStatus.Text = "Only jpg and jepg file";
                lblStatus.ForeColor = System.Drawing.Color.Red;
        }
        
    }
}
