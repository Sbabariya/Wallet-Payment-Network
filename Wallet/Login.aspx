﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Wallet.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      
    <style>
        body{
            
            background-image: url('back1.jpg');
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-size: cover;

        }
            h1 {text-align: center;}
            h2 {text-align: center;}
    </style>
</head>
<body>
    <h1>Wallet Network Payment</h1>
    <h2>Stay home and bank safely</h2>
    <h3>Login/Register</h3>
    <form id="form1" runat="server">
        <div>
            <table style="border:2px solid black">
                <tr>
                    <td>
                        <asp:Label ID="userLabel" runat="server" Text="Username"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="userText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="passLabel" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="passText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="onBtnLoginClick" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="onBtnRgisterClick" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="errorMessageLabel" runat="server" Text="Incorrect User Credentials" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>