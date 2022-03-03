<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registerPage.aspx.cs" Inherits="registerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>registration page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to our website!</h1>
            <h2>Please register your information first!</h2>
          <asp:ValidationSummary 
                ID="ValidationSummaryRegistration" 
                runat="server" EnableClientScript="true"
                ForeColor="Red"
                HeaderText="You must correct the following errors:"
                ShowMessageBox="true"
                ShowSummary="false"/>
          </div>
          <div>
        <table>
            <tr>
                <td style="text-align: right">Username:</td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                </td>
                <td>
                   <asp:RequiredFieldValidator 
                        ID="rfvUsername" 
                        runat="server" 
                        ControlToValidate="txtUsername"
                        ForeColor="Red"
                        ErrorMessage="Your userID is required!" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                   <asp:RequiredFieldValidator 
                        ID="rfvEmail" 
                        runat="server" 
                        ControlToValidate="txtEmail"
                        ForeColor="Red"
                        ErrorMessage="Your Email is required!" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator 
                        ID="RegExEmail" 
                        runat="server" 
                        ErrorMessage="Must be valid email."
                        Display="Dynamic"
                        ForeColor="Red"
                        ControlToValidate="txtEmail" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                      </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Password:</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                   <asp:RequiredFieldValidator 
                          ID="rfvPassword" 
                          runat="server"
                          ControlToValidate="txtPassword"
                          ForeColor="Red"
                          ErrorMessage="Please provide password!" Display="Dynamic">
                   </asp:RequiredFieldValidator>

                   <asp:CompareValidator
                       ID="cvPassword"
                       runat="server"
                       ControlToValidate="txtPassword"                  
                       Operator="NotEqual"
                       CompareToValidate=" "
                       ForeColor="Red"
                       Display="Dynamic"
                       ErrorMessage="Password and Username cannot be the same!"
                       ControlToCompare="txtUsername">
                   </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">Confirm Password:</td>
                <td>
                    <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                      <asp:RequiredFieldValidator 
                         ID="rfvConfirm" 
                         runat="server"
                         ControlToValidate="txtConfirm"
                         ForeColor="Red"
                         ErrorMessage="Please confirm your password!" Display="Dynamic">
                       </asp:RequiredFieldValidator>
               
                       <asp:CompareValidator
                           ID="cvConfirm"
                           runat="server"
                           ControlToValidate="txtConfirm"                  
                           Operator="Equal"
                           CompareToValidate=" "
                           ForeColor="Red"
                           Display="Dynamic"
                           ErrorMessage="Password are not the same!"
                           ControlToCompare="txtPassword">
                       </asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btnSign" runat="server" Text="Sign Up" OnClick="btnSign_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            </table>
              <asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>
       </div>
        
    </form>
</body>
</html>
