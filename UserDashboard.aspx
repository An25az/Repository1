<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserDashboard.aspx.cs" Inherits="UserDashboard" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>User Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f6fc;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
        }

        h1 {
            text-align: center;
            color: #007bff;
        }

        h2 {
            margin-top: 20px;
            margin-bottom: 10px;
            color: #555;
        }

        ul {
            list-style: none;
            padding: 0;
            margin: 0;
        }

        li {
            margin-bottom: 10px;
        }

        a {
            display: block;
            padding: 10px 20px;
            background-color: #007bff;
            color: #fff;
            text-decoration: none;
            border-radius: 4px;
            transition: background-color 0.3s;
        }

        a:hover {
            background-color: #0056b3;
        }

        .back-to-login-button {
            margin-top: 20px;
            padding: 10px 20px;
            background-color: #dc3545;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .back-to-login-button:hover {
            background-color: #c82333;
        }

        .logged-in-user {
            font-size: 18px;
            font-weight: bold;
            color: #007bff;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>User Dashboard</h1>
            <h2>Welcome to Your Dashboard</h2>
            <div class="logged-in-user">Logged in as: <asp:Label ID="lblLoggedInUser" runat="server" Text=""></asp:Label></div>
            <ul>
                <li><a href="Students.aspx?username=<%= Server.UrlEncode(lblLoggedInUser.Text) %>">Events</a></li>
                <li><a href="RegisterTeam.aspx">Register Team </a></li>
                <li><a href="EditProfile.aspx">Edit Profile</a></li>
                <li><a href="Feedback.aspx?username=<%= Server.UrlEncode(lblLoggedInUser.Text) %>">Give Event Feedback</a></li>
                <!-- Add more links as needed -->
            </ul>
            
            <asp:Button ID="BackToLoginButton" runat="server" Text="Back to Login" OnClick="BackToLoginButton_Click" CssClass="back-to-login-button" />
        </div>
    </form>
</body>
</html>
