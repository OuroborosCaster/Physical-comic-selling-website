using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Home : System.Web.UI.Page
{

    #region Members
    const int PAGESIZE = 5;
    int PagesCount, RecordsCount;
    int CurrentPage, Pages, JumpPage;
    const string COUNT_SQL = "select count(*)  from Comics";
    #endregion
    public static int GetRecordsCount(string sqlRecordsCount)
    {
        string sqlQuery;
        if (sqlRecordsCount == "default")
        {
            sqlQuery = COUNT_SQL;
        }
        else
        {
            sqlQuery = sqlRecordsCount;
        }
        int RecordCount = 0;
        SqlCommand cmd = new SqlCommand(sqlQuery, Conn());
        RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return RecordCount;
    }
    public int OverPage()
    {
        int pages = 0;
        if (RecordsCount % PAGESIZE != 0)
            pages = 1;
        else
            pages = 0;
        return pages;
    }
    public int ModPage()
    {
        int pages = 0;
        if (RecordsCount % PAGESIZE == 0 && RecordsCount != 0)
            pages = 1;
        else
            pages = 0;
        return pages;
    }
    public static SqlConnection Conn()
    {
        string constr = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        return conn;
    }
    private void GridViewDataBind(string sqlSearch)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        
        Pages = (int)ViewState["PagesCount"];
        
        if (CurrentPage + 1 > 1)
        {
            Fistpage.Enabled = true;
            Prevpage.Enabled = true;
        }
        else
        {
            Fistpage.Enabled = false;
            Prevpage.Enabled = false;
        }
        if (CurrentPage == Pages)
        {
            Nextpage.Enabled = false;
            Lastpage.Enabled = false;
        }
        else
        {
            Nextpage.Enabled = true;
            Lastpage.Enabled = true;
        }
        DataSet ds = new DataSet();
        string sqlResult;

        if (sqlSearch == "default")
        {
            sqlResult = "Select Top " + PAGESIZE + "CId,Name,Author,CoverFile,UnitPrice from Comics where CId not in(select top " + PAGESIZE * CurrentPage + " CId from Comics order by CId asc) order by CId asc";
        }
        else
        {
            sqlResult = sqlSearch;
        }
        SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlResult, Conn());
        sqlAdapter.Fill(ds, "Result");
        ComicGridView.DataSource = ds.Tables["Result"].DefaultView;
        ComicGridView.DataBind();

        lbCurrentPage.Text = (CurrentPage + 1).ToString();
        GotoPage.Text = (CurrentPage + 1).ToString();
        sqlAdapter.Dispose();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RecordsCount = GetRecordsCount("default");
            PagesCount = RecordsCount / PAGESIZE + OverPage();
            ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();
            ViewState["PageIndex"] = 0;
            ViewState["JumpPages"] = PagesCount;                      
            lbPageCount.Text = PagesCount.ToString();
            lbRecordCount.Text = RecordsCount.ToString();
            
            if (RecordsCount <= 10)
            {
                GotoPage.Enabled = false;
            }
            GridViewDataBind("default");
        }
    }
    protected void PagerBtnCommand_OnClick(object sender, EventArgs e)
    {
        CurrentPage = (int)ViewState["PageIndex"];
        
        Pages = (int)ViewState["PagesCount"];
        Button btn = sender as Button;
        string sqlResult = "default";
        if (btn != null)
        {
            string cmd = btn.CommandName;
            switch (cmd)
            {
                case "next":
                    CurrentPage++;
                    break;
                case "prev":
                    CurrentPage--;
                    break;
                case "last":
                    CurrentPage = Pages;
                    break;
                case "search":
                    if (!string.IsNullOrEmpty(SearchName.Text))
                    {
                        RecordsCount = GetRecordsCount("select count(*) from Comics where Name like '%" + SearchName.Text + "%'");
                        PagesCount = RecordsCount / PAGESIZE + OverPage();
                        ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();
                        ViewState["PageIndex"] = 0;
                        ViewState["JumpPages"] = PagesCount;
                        
                        lbPageCount.Text = PagesCount.ToString();
                        lbRecordCount.Text = RecordsCount.ToString();
                        
                        if (RecordsCount <= 10)
                            GotoPage.Enabled = false;
                        sqlResult = "Select Top " + PAGESIZE + "CId,Name,Author,CoverFile,UnitPrice from Comics where CId not in(select top " + PAGESIZE * CurrentPage + " CId from Comics order by CId asc) and Name like '%" + SearchName.Text + "%' order by CId asc";
                    }
                    else
                    {
                        Response.Write("<script>alert('Pls enter keyword!')</script>");
                    }
                    break;
                case "jump":
                    JumpPage = (int)ViewState["JumpPages"];
                    
                    if (Int32.Parse(GotoPage.Text) > JumpPage || Int32.Parse(GotoPage.Text) <= 0)
                        Response.Write("<script>alert('Invalid page number!')</script>");
                    else
                    {
                        int InputPage = Int32.Parse(GotoPage.Text.ToString()) - 1;
                        
                        ViewState["PageIndex"] = InputPage;
                        CurrentPage = InputPage;
                        
                        sqlResult = "Select Top " + PAGESIZE + "CId,Name,Author,CoverFile,UnitPrice from Comics where CId not in(select top " + PAGESIZE * CurrentPage + " CId from Comics order by CId asc) and Name like '%" + SearchName.Text + "%' order by CId asc";
                    }
                    break;
                default:
                    CurrentPage = 0;
                    break;
            }
            ViewState["PageIndex"] = CurrentPage;
         
            GridViewDataBind(sqlResult);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

        RecordsCount = GetRecordsCount("default");
        PagesCount = RecordsCount / PAGESIZE + OverPage();
        ViewState["PagesCount"] = RecordsCount / PAGESIZE - ModPage();
        ViewState["PageIndex"] = 0;
        ViewState["JumpPages"] = PagesCount;
        lbPageCount.Text = PagesCount.ToString();
        lbRecordCount.Text = RecordsCount.ToString();
        
        if (RecordsCount <= 10)
        {
            GotoPage.Enabled = false;
        }
        GridViewDataBind("default");
    }

}