<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateTeam.aspx.cs" Inherits="UpdateTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Team</title>
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
            <h1>Update Team</h1>
            <div class="form-group">
                <label for="EventDropDown">Select Event:</label>
                <asp:DropDownList ID="EventDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="EventDropDown_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="TeamDropDown">Select Team:</label>
                <asp:DropDownList ID="TeamDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TeamDropDown_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="LeaderNameTextBox">Leader's Name:</label>
                <asp:TextBox ID="LeaderNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="MembersTextBox">Members:</label>
                <asp:TextBox ID="MembersTextBox" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="UpdateTeamButton" runat="server" Text="Update Team" OnClick="UpdateTeamButton_Click" CssClass="btn btn-primary" />
            <asp:Button ID="BackButton" runat="server" Text="Back to Dashboard" OnClick="Back_Click" CssClass="btn btn-secondary" />
            <asp:Label ID="Errors" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>
