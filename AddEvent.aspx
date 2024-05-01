<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEvent.aspx.cs" Inherits="AddEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Events</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f6fc;
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1, h3 {
            color: #007bff;
            text-align: center;
        }
        label {
            font-weight: bold;
        }
        input[type="text"] {
            width: 100%;
            padding: 8px;
            margin-bottom: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-sizing: border-box;
        }
        .button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 12px 24px;
            cursor: pointer;
            border-radius: 5px;
            font-size: 16px;
            font-weight: bold;
        }
        .button:hover {
            background-color: #0056b3;
        }
        .button:active {
            transform: translateY(2px);
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
        }
        .message {
            text-align: center;
            color: #007bff;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Add Event</h1>
            <label for="txtEventName">Event Name:</label>
            <asp:TextBox ID="txtEventName" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label for="txtPrice">Price:</label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label for="txtMinTeamCount">Minimum Team Count:</label>
            <asp:TextBox ID="txtMinTeamCount" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label for="txtMaxTeamCount">Maximum Team Count:</label>
            <asp:TextBox ID="txtMaxTeamCount" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label for="txtMembersPerTeam">Members Per Team:</label>
            <asp:TextBox ID="txtMembersPerTeam" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label for="txtTime">Time:</label>
            <asp:TextBox ID="txtTime" runat="server" CssClass="form-control"></asp:TextBox><br />
            <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" OnClick="btnAddEvent_Click" CssClass="button" /><br />
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Text=""></asp:Label><br />
            <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" OnClick="btnBackToDashboard_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
