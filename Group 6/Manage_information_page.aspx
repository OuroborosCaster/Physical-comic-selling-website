<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Manage_information_page.aspx.cs" Inherits="Manage_information_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Repeater ID="d1" runat="server">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <table style="text-align: left">
                <tr>
                    <td rowspan="4" style="width: 200px">
                        <asp:Image ID="imgCover" Width="200px" ImageUrl='<%#Eval("CoverFile") %>' runat="server" />
                    </td>
                    <td style="width: 200px"><h4>Comic Price: </h4></td>
                    <td><%#Eval("UnitPrice") %></td>
                </tr>
                <tr>
                    <td style="width: 200px"><h4>Comic Publish country: </h4></td>
                    <td><%#Eval("PublishCountry") %></td>
                </tr>
                <tr>
                    <td style="width: 200px"><h4>Comic Author: </h4></td>
                    <td><%#Eval("Author") %></td>
                </tr>
                <tr>
                    <td style="width: 200px"><h4>Comic Translator: </h4></td>
                    <td><%#Eval("Translator") %></td>
                </tr>
                <tr>
                    <td colspan="3"><h3>Comic Description:</h3><p><%#Eval("Description") %></p></td>
                </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Button ID="Bac1" runat="server" Text="Add to cart" OnClick="Bac1_Click" />
</asp:Content>

