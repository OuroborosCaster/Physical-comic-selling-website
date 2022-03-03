<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <p style="text-align: center; width: 100%">
        <asp:Label ID="lb" runat="server" Text="Enter keyword pls: "></asp:Label>
        <asp:TextBox ID="SearchName" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="PagerBtnCommand_OnClick" CommandName="search" />
        <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
    </p>
    <asp:GridView ID="ComicGridView" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Cover">
                <ItemTemplate>
                    <asp:Image ID="imgCover" Width="200px" ImageUrl='<%#Eval("CoverFile") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="Name" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Author">
                <ItemTemplate>
                    <asp:Label ID="Author" runat="server" Text='<%#Eval("Author") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price(RM)">
                <ItemTemplate>
                    <asp:Label ID="UnitPrice" runat="server" Text='<%#Eval("UnitPrice") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <a href="Manage_information_page.aspx?id=<%#Eval("CId") %>">See more</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table>
        <tr>
            <td>
                <asp:Label ID="lbcurrentpage1" runat="server" Text="Current page:"></asp:Label>
                <asp:Label ID="lbCurrentPage" runat="server" Text=""></asp:Label>
                <asp:Label ID="lbFenGe" runat="server" Text="/"></asp:Label>
                <asp:Label ID="lbPageCount" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Label ID="recordscount" runat="server" Text="Total:"></asp:Label>
                <asp:Label ID="lbRecordCount" runat="server" Text=""></asp:Label>
            </td>
            <td>
                <asp:Button ID="Fistpage" runat="server" CommandName="" Text="First" OnClick="PagerBtnCommand_OnClick" />
                <asp:Button ID="Prevpage" runat="server" CommandName="prev" Text="Precious"
                    OnClick="PagerBtnCommand_OnClick" />
                <asp:Button ID="Nextpage" runat="server" CommandName="next" Text="Next" OnClick="PagerBtnCommand_OnClick" />
                <asp:Button ID="Lastpage" runat="server" CommandName="last" Text="Last"
                    key="last" OnClick="PagerBtnCommand_OnClick" />
            </td>
            <td>
                <asp:Label ID="lbjumppage" runat="server" Text="Jump to "></asp:Label>
                <asp:Label ID="lbye" runat="server" Text="Page"></asp:Label>
                <asp:TextBox ID="GotoPage" runat="server" Width="25px"></asp:TextBox>
                <asp:Button ID="Jump" runat="server" Text="Jump" CommandName="jump" OnClick="PagerBtnCommand_OnClick" />
            </td>
        </tr>
    </table>
</asp:Content>

