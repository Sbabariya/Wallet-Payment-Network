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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ReqID" DataSourceID="SqlDataSource1" GridLines="Vertical" Width="750px" AllowPaging="true">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="ReqID" HeaderText="Request ID" ReadOnly="True" SortExpression="ReqID" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="True" SortExpression="FirstName" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
                <asp:BoundField DataField="RequestDate" HeaderText="Request Date" SortExpression="RequestDate" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="Memo" HeaderText="Memo" SortExpression="Memo" />
                <asp:BoundField DataField="FromSSN" HeaderText="FromSSN" SortExpression="FromSSN" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="AcceptButton" Text="Accept" runat="server" CommandName="Accept" OnClick="onAcceptClick" />
                        <asp:Button ID="DeclineButton" Text="Decline" runat="server" CommandName="Decline" OnClick="onDeclineClick"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginDBConnectionString %>" 
            SelectCommand="Select B.ReqID, A.FirstName, A.LastName, B.FromSSN, B.Amount, B.Memo, B.RequestDate from UserAccount A,
	                            (select * from RequestTransaction 
	                            where [Status] = 'P' and (ToEmail IN (select Email from Email where SSN = @ssn)
		                            or ToPhoneNumber = (select PhoneNumber from UserAccount where SSN = @ssn))) B
                            Where A.SSN = B.FromSSN">
            <SelectParameters>
                <asp:SessionParameter Name="ssn" SessionField="ssn" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>