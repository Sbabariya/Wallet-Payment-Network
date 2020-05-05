<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RequestMoney.aspx.cs" Inherits="Wallet.RequestMoney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblUserDetails" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" style="width: 57px; height: 26px;" />
        <br /><br /><br />
        <table id="table1">
            <tr>
                <td><asp:Button ID="requestButton" runat="server" Text="Request Money" OnClick="onRequestClick" /></td>
                <td><asp:Button ID="addRows" runat="server" Text="Add Recipents" OnClick="onAddRowClick" /></td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
