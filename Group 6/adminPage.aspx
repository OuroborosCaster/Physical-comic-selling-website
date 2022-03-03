<%@ Page Title="Administrator Pge" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="adminPage.aspx.cs" Inherits="adminPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
         
     </div>
           <h2 style="text-align:center">Administrator Page</h2>
    <div>

        <table>
            <tr>
                <td>
                    ID:</td>
                <td>
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>Comic Book Name: </td>
                <td>
                    <asp:TextBox ID="txtBookName" runat="server"></asp:TextBox>
                </td>
                <td>UnitPrice:</td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Text="reset" OnClick="btnClear_Click" />
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
    </div>
    <br />
       <div>

           <table>
               <tr>
                   <td>Upload cover page</td>
                   <td><asp:FileUpload ID="FileUploadCtrl" runat="server" /></td>
                   <td>
                       <asp:Button ID="btnSumbit" runat="server" Text="Upload" OnClick="btnSumbit_Click" />
                   </td>
                   <td>
                       <asp:Label ID="lblStatus" runat="server"></asp:Label>
                   </td>
               </tr>
           </table>

       </div>

     <br />
     <asp:GridView ID="gvComic" runat="server" AutoGenerateColumns="False"  
        
        onrowdeleting="gvComic_RowDeleting"
 
        onrowediting="gvComic_RowEditing" 
         
        onrowupdating="gvComic_RowUpdating"
 
        onrowcancelingedit="gvComic_RowCancelingEdit" DataKeyNames="CId" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" >
         <Columns>
             <asp:BoundField DataField="CId" HeaderText="ID" ReadOnly="True" SortExpression="CId" />
             <asp:BoundField DataField="Name" HeaderText="Comic Book Name" SortExpression="Name" />
             <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
             <asp:BoundField DataField="PublishCountry" HeaderText="PublishCountry" SortExpression="PublishCountry" />
             <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
             <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
             <asp:BoundField DataField="Translator" HeaderText="Translator" SortExpression="Translator" />
             <asp:ImageField DataImageUrlField="CoverFile" HeaderText="CoverPage" ControlStyle-Width="200px">
             </asp:ImageField>
             <asp:CommandField ButtonType="Button" HeaderText="Option" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" >
             <ControlStyle BackColor="#3399FF" ForeColor="#FFFFCC" />
             </asp:CommandField>
         </Columns>
         <FooterStyle BackColor="White" ForeColor="#000066" />
         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
         <RowStyle ForeColor="#000066" />
         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
         <SortedAscendingCellStyle BackColor="#F1F1F1" />
         <SortedAscendingHeaderStyle BackColor="#007DBB" />
         <SortedDescendingCellStyle BackColor="#CAC9C9" />
         <SortedDescendingHeaderStyle BackColor="#00547E" />
     </asp:GridView>
     <br />
    </asp:Content>
    
