<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageTeams.aspx.cs" Inherits="ManageTeams" EnableEventValidation="false" %>

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
            </div>
            <br />
            <div>
                <asp:Button ID="AddTeamButton" runat="server" Text="Add Team" OnClick="AddTeamButton_Click" />
                <asp:Button ID="DeleteTeamButton" runat="server" Text="Delete Team" OnClick="DeleteTeamButton_Click" />
                <br />
                <br />
                <asp:Label ID="Errors" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageTeams.aspx.cs" Inherits="ManageTeams" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Team</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f7fc;
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        .container {
            width: 80%;
            margin: 50px auto;
            background-color: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #007bff;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            font-weight: bold;
        }

        input[type="text"],
        input[type="button"] {
            width: calc(100% - 10px);
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        input[type="button"] {
            margin-top: 10px;
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
        }

        input[type="button"]:hover {
            background-color: #0056b3;
        }

        .error-message {
            color: #dc3545;
            font-size: 14px;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Manage Team<asp:Button ID="Back" runat="server" OnClick="Back_Click" Text="Back" /></h1>
            <div class="form-group">
                <asp:ListBox ID="TeamListBox" runat="server" Width="728px" Height="100px"></asp:ListBox>
            </div>
            <div class="form-group">
                <asp:Button ID="AddTeamButton" runat="server" Text="Add Team" OnClick="AddTeamButton_Click" CssClass="btn btn-primary" />
                <asp:Button ID="DeleteTeamButton" runat="server" Text="Delete Team" OnClick="DeleteTeamButton_Click" CssClass="btn btn-danger" />
            </div>
            <asp:Label ID="Errors" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>

