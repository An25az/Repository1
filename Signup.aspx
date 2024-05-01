<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        .container input[type="password"],
        .container select {
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
            <h2>SIGNUP PAGE</h2>
            <label for="UserName">Name</label>
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>

            <label for="ID">ID</label>
            <asp:TextBox ID="ID" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>

            <label for="Email">Email</label>
            <asp:TextBox ID="Email" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>

            <label for="Password">Password</label>
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>

            <label for="Confirm_Password">Confirm Password</label>
            <asp:TextBox ID="Confirm_Password" runat="server" OnTextChanged="TextBox5_TextChanged"></asp:TextBox>

            <label for="Type">Type</label>
            <asp:DropDownList ID="Type" runat="server" OnSelectedIndexChanged="Type_SelectedIndexChanged">
                <asp:ListItem Value="Student">Student</asp:ListItem>
                <asp:ListItem Value="Admin">Admin</asp:ListItem>
                <asp:ListItem Value="Faculty Mentor">Faculty Mentor</asp:ListItem>
                <asp:ListItem Value="Sponsor">Sponsor</asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="Warning_msg" runat="server" CssClass="warning-msg"></asp:Label>

            <asp:Button ID="Signup" runat="server" OnClick="Button1_Click" Text="Signup" style="font-size: 16px; margin-top = 45px;" Height="34px" />
            
            <!-- Add the login button below -->
            <asp:HyperLink ID="LoginLink" runat="server" NavigateUrl="~/Login.aspx" Text="Login" />
        </div>
    </form>
</body>
</html>



