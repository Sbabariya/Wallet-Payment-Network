<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Wallet.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblUserDetails" runat="server" Text=""></asp:Label>
            <asp:Button ID="btmLogout" runat="server" Text="Logout" OnClick="btmLogout_Click" style="width: 57px" />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Account" />
        <br /><br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Send Money" style="height: 26px" />
        <br /><br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Request And Split" />
        <br /><br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Statements and Search Transactions" />
        <br /><br />
        <br />
        <br />
        New Messages<br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>