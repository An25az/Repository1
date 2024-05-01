<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="ManageTeams" runat="server" OnClick="ManageTeams_Click" Text="Manage Teams" />
        </div>
        <p>
            <asp:Button ID="ViewTeams" runat="server" OnClick="ViewTeams_Click" Text="View Teams" />
        </p>
        <p>
            <asp:ListBox ID="TeamListBox" runat="server"></asp:ListBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="Logout" runat="server" OnClick="Logout_Click" Text="Logout" />
        </p>
    </form>
</body>
</html>
