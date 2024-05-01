<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageTeams.aspx.cs" Inherits="ManageTeams" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Manage Team<asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" />
            </h1>
            <div>
                <asp:ListBox ID="TeamListBox" runat="server" Width="728px" Height="100px"></asp:ListBox>
            </div>
            <br />
            <div>
                <asp:TextBox ID="MemberTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="AddMemberButton" runat="server" Text="Add Member" OnClick="AddMemberButton_Click" />
            </div>
            <br />
            <div>
                <asp:TextBox ID="MemberToDeleteTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="DeleteMemberButton" runat="server" Text="Delete Member" OnClick="DeleteMemberButton_Click" />
                <br />
                <br />
                <asp:Label ID="Errors" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
