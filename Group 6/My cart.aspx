<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="My cart.aspx.cs" Inherits="My_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:DataList ID="d1" runat="server">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><img src='<%#Eval("CoverFile") %>' width="200" height="300" /></td>
                <td><%#Eval("Name") %></td>
                <td><%#Eval("UnitPrice") %></td>
                <td><%#Eval("PublishCountry") %></td>
                <td><%#Eval("Author") %></td>
                <td><%#Eval("Translator") %></td>
                <td>
                    <a href="Delete_cart.aspx?id=<%#Eval("id") %>">Delete</a>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>



    </asp:DataList>


</asp:Content>

