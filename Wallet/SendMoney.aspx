<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMoney.aspx.cs" Inherits="asp.netloginpage.SendMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btmLogout" runat="server" Text="Logout" OnClick="btmLogout_Click" style="width: 57px" />            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Enter Recipient"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Recipient" runat="server" placeholder="SSN"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Enter Amount"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Enter Memo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="Memo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="CancellationReason"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="CancellationReason" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Confirm Payment" OnClick="Button1_Click" />
                    </td>
                       <td>
                        <asp:Button ID="Button3" runat="server" Text="Cancel Payment" OnClick="Button3_Click" />
                    </td>

                </tr>
                <tr>
            <td></td>
            <td>
                <asp:Label ID="lblErrorMessage" runat="server" Text="User does not have an account with wallet" ForeColor="red"></asp:Label></td>
            <td>
                <asp:Label ID="lblSuccessMessage" runat="server" Text="Payment Successful" ForeColor="Blue"></asp:Label></td>
            <td>
                <asp:Button ID="send_email" runat="server" Text="Email to register" OnClick="send_email_click" />
            </td>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="Email Sent" ForeColor="Blue"></asp:Label></td>
            
            <td>
                <asp:Label ID="lblErrorMessage1" runat="server" Text="Cancellation Time exceeded" ForeColor="red"></asp:Label></td>
            <td>
                <asp:Label ID="lblSuccessMessage1" runat="server" Text="Cancellation Successful" ForeColor="Blue"></asp:Label></td>
            <td>
        </tr>
            </table>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Go to Main Menu" />
    </form>
</body>
</html>
