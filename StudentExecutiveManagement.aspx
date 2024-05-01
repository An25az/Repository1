<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentExecutiveManagement.aspx.cs" Inherits="StudentExecutiveManagement" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Student Executive Management</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #ffffff; /* White background */
            color: #333333; /* Dark text color */
            margin: 0;
            padding: 0;
        }
        .container {
            max-width: 800px;
            margin: 50px auto;
            padding: 20px;
            background-color: #f0f6fc; /* Light blue background */
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #007bff; /* Blue header */
            text-align: center;
        }
        input[type="text"], input[type="submit"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #cccccc; /* Light gray border */
            border-radius: 5px;
            box-sizing: border-box;
        }
        input[type="submit"] {
            background-color: #007bff; /* Blue submit button */
            color: #ffffff; /* White text color */
            cursor: pointer;
        }
        input[type="submit"]:hover {
            background-color: #0056b3; /* Darker blue hover color */
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        th, td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #dddddd; /* Light gray border */
        }
        th {
            background-color: #007bff; /* Blue header */
            color: #ffffff; /* White text color */
        }
        tr:hover {
            background-color: #f2f2f2; /* Light gray hover color */
        }
        .edit-btn, .delete-btn {
            background-color: #007bff;
            color: #ffffff;
            border: none;
            padding: 8px 16px;
            cursor: pointer;
            border-radius: 5px;
            margin-right: 5px;
        }
        .delete-btn {
            background-color: #dc3545; /* Red delete button */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Student Executive Management</h1>
            <asp:Label ID="lblFullName" runat="server" Text="Full Name:" />
            <asp:TextBox ID="txtFullName" runat="server" />
            <br />
            <asp:Label ID="lblCategory" runat="server" Text="Category:" />
            <asp:TextBox ID="txtCategory" runat="server" />
            <br />
            <asp:Label ID="lblPosition" runat="server" Text="Position:" />
            <asp:TextBox ID="txtPosition" runat="server" />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add New Student Executive" OnClick="btnAdd_Click" />
            <asp:GridView ID="gvStudentExecutives" runat="server" AutoGenerateColumns="False" DataKeyNames="StudentID" OnRowEditing="gvStudentExecutives_RowEditing" OnRowUpdating="gvStudentExecutives_RowUpdating" OnRowCancelingEdit="gvStudentExecutives_RowCancelingEdit" OnRowDeleting="gvStudentExecutives_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                    <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Position" HeaderText="Position" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>