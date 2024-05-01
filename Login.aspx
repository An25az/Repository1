<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        form {
            margin: 20px;
        }

        .container {
            width: 300px;
            margin: auto;
        }

        .container input[type="text"],
        .container input[type="password"] {
            width: 100%;
            padding: 8px;
            margin: 5px 0;
            box-sizing: border-box;
        }

        .container label {
            margin-top: 10px;
            display: block;
        }

        .container button {
            width: 100%;
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
        }

        .container button:hover {
            opacity: 0.8;
        }

        .warning-msg {
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Login</h2>
            <label for="UserName">Username</label>
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>

            <label for="Password">Password</label>
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Label ID="Warning_msg" runat="server" CssClass="warning-msg"></asp:Label>

            <asp:Button ID="Log_in" runat="server" OnClick="Login_Click" Text="Login" style="font-size: 16px;" Height="34px" />
            
            <!-- Add the Signup button below -->
            <asp:HyperLink ID="SignUpLink" runat="server" NavigateUrl="~/Signup.aspx" Text="Signup" />
        </div>
    </form>
</body>
</html>
