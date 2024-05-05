<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterTeam.aspx.cs" Inherits="RegisterTeam" EnableViewState="true"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register Team</title>
    <style>
        /* Add your CSS styles here */
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 600px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0px 0px 10px 0px rgba(0,0,0,0.1);
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ddd;
            border-radius: 3px;
        }

        .btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 3px;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #0056b3;
        }

        .error-message {
            color: red;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Display events -->
            <asp:DropDownList ID="ddlEvents" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                OnSelectedIndexChanged="ddlEvents_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Text="Select Event" Value="" />
            </asp:DropDownList>
            
            <!-- Team details -->
            <asp:Panel ID="pnlTeamDetails" runat="server" Visible="false">
                <asp:TextBox ID="txtTeamName" runat="server" CssClass="form-control" placeholder="Enter Team Name"></asp:TextBox>
                <asp:TextBox ID="txtLeaderName" runat="server" CssClass="form-control" placeholder="Enter Team Leader's Name"></asp:TextBox> <!-- Add textbox for leader's name -->
                <!-- Leader name can be retrieved from the query string -->
                <asp:HiddenField ID="hdnLeaderName" runat="server" />
                
                <!-- Member entry -->
                <asp:Panel ID="pnlMemberEntry" runat="server">
                    <!-- This panel will be populated dynamically -->
                </asp:Panel>
                
                <!-- Buttons -->
                <asp:Button ID="btnConfirmRegistration" runat="server" Text="Confirm Registration" OnClick="btnConfirmRegistration_Click" CssClass="btn" />

            </asp:Panel>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn" />
            <!-- Error message -->
            <asp:Label ID="lblError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>