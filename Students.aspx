<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Students.aspx.cs" Inherits="Students" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upcoming Events</title>
    <style>
        /* Basic styling for demonstration purposes */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }

        .container {
            max-width: 600px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .event-table {
            width: 100%;
            border-collapse: collapse;
        }

        .event-table th,
        .event-table td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: left;
        }

        .event-table th {
            background-color: #007bff;
            color: #fff;
        }

        .btn {
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            border: none;
            background-color: #007bff;
            color: #fff;
            cursor: pointer;
            margin-top: 20px;
            margin-bottom: 20px; /* Added margin bottom for spacing */
        }

        .btn:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Upcoming Events</h2>
            <!-- Define EventsContainer here -->
            <asp:Panel ID="EventsContainer" runat="server">
                <table id="EventsTable" class="event-table">
                 <tr>
                </tr>
                </table>

            </asp:Panel>
            <!-- Button to go back to UserDashboard -->
            <asp:Button ID="BackToUserDashboard" runat="server" Text="Back to Dashboard" CssClass="btn" OnClick="BackToDashboard_Click" />
            <!-- UpdateTeams button -->
            <asp:Button ID="UpdateTeams" runat="server" Text="Update Teams" CssClass="btn" OnClick="UpdateTeams_Click" />
        </div>
    </form>
</body>
</html>
