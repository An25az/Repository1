<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminDashboard.aspx.cs" Inherits="AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
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
        .button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 12px 24px;
            cursor: pointer;
            border-radius: 5px;
            font-size: 16px;
            font-weight: bold;
            display: block;
            margin: 0 auto;
            margin-bottom: 10px;
        }
        .button:hover {
            background-color: #0056b3;
        }
        .button:active {
            transform: translateY(2px);
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
        }
        .info-container {
            text-align: center;
        }
        /* New CSS for the user table */
        .user-table {
            display: none; /* Initially hidden */
            border-collapse: collapse;
            width: 100%;
        }
        .user-table th, .user-table td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .user-table th {
            background-color: #f2f2f2;
            color: #333;
        }
    </style>
    <script>
        // JavaScript function to toggle visibility of the users table
        function toggleUserTable() {
            var table = document.getElementById("userTable");
            if (table.style.display === "none") {
                table.style.display = "table";
            } else {
                table.style.display = "none";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Admin Dashboard</h1>
            <asp:Button ID="btnUpdateTeam" runat="server" Text="Update Team" OnClick="btnUpdateTeam_Click" CssClass="button" /><br />
            <asp:Button ID="btnManageTeams" runat="server" Text="Manage Teams" OnClick="btnManageTeams_Click" CssClass="button" /><br />
            <asp:Button ID="btnFacultyMentorManagement" runat="server" Text="Faculty Mentor Management" OnClick="btnFacultyMentorManagement_Click" CssClass="button" /><br />
            <asp:Button ID="btnGenerateReportsPage" runat="server" Text="Generate Reports Page" OnClick="btnGenerateReportsPage_Click" CssClass="button" /><br />
            <asp:Button ID="btnAddEvent" runat="server" Text="Add Event" OnClick="btnAddEvent_Click" CssClass="button" PostBackUrl="~/AddEvent.aspx" /><br />
            <asp:Button ID="btnDeleteEvent" runat="server" Text="Delete Event" OnClick="btnDeleteEvent_Click" CssClass="button" PostBackUrl="~/DeleteEvent.aspx" /><br />
            <asp:Button ID="btnViewUsers" runat="server" Text="View Users" OnClientClick="toggleUserTable(); return false;" CssClass="button" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="button"  PostBackUrl="~/Login.aspx"/><br />
            <div class="info-container">
                <asp:Label ID="lblUsers" runat="server" Text=""></asp:Label><br />
            </div>
            <!-- Users table -->
          <asp:GridView ID="userTable" runat="server" CssClass="user-table">

          </asp:GridView>

        </div>
    </form>
</body>
</html>
