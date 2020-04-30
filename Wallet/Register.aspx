<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Wallet.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Register</h2>
    <form id="form1" runat="server">
        <div>
            <table style="border:5px solid white">
                <tr>
                    <td><asp:Label ID="fNameLabel" runat="server" Text="FirstName"></asp:Label></td>
                    <td><asp:TextBox ID="fNameText" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lNameLabel" runat="server" Text="LastName"></asp:Label></td>
                    <td><asp:TextBox ID="lNameText" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="emailLabel" runat="server" Text="Email"></asp:Label></td>
                    <td><asp:TextBox ID="emailText" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="phoneLabel" runat="server" Text="Phone Number"></asp:Label></td>
                    <td><asp:TextBox ID="phoneText" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="bankIDLabel" runat="server" Text="BankID"></asp:Label></td>
                    <td><asp:TextBox ID="bankIDText" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="accountNumLabel" runat="server" Text="Account Number"></asp:Label></td>
                    <td><asp:TextBox ID="acountNumText" runat="server" TextMode="Number"></asp:TextBox></td>
                </tr
                <tr>
                    <td><asp:Label ID="SSNLabel" runat="server" Text="SSN"></asp:Label></td>
                    <td><asp:TextBox ID="SSNText" runat="server"  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="balanceLabel" runat="server" Text="Balance"></asp:Label></td>
                    <td><asp:TextBox ID="balanceText" runat="server" TextMode="Number" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="usernameLabel" runat="server" Text="Usermame"></asp:Label></td>
                    <td><asp:TextBox ID="usernameText" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="passwordLabel" runat="server" Text="Password"></asp:Label></td>
                    <td><asp:TextBox ID="passwordText" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td></td></tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="onBtnRegisterClick" /></td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
