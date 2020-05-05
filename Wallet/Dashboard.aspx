<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Wallet.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblUserDetails" runat="server" Text=""></asp:Label><br />
        <asp:Button ID="btmLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" style="width: 57px"  />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="accountButton" runat="server" OnClick="onAccontClick" Text="Account" />
        <br /><br />
        <asp:Button ID="sendButton" runat="server" OnClick="onSendClick" Text="Send Money" style="height: 26px" />
        <br /><br />
        <asp:Button ID="requestButton" runat="server" OnClick="onRequestClick" Text="Request Money" />
        <br /><br />
        <asp:Button ID="statementButton" runat="server" OnClick="onStatementClick" Text="Statements and Search Transactions" />
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