<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacultyMentorManagement.aspx.cs" Inherits="FacultyMentorManagement" %>

<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Faculty Mentor Management</title>
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
        h1, h2 {
            color: #007bff;
            text-align: center;
        }
        .form-control {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
            border-radius: 5px;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .gridview {
            border-collapse: collapse;
            width: 100%;
        }
        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }
        .gridview th {
            background-color: #007bff;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Faculty Mentor Management</h1>
            <!-- Add form controls for managing faculty mentors -->
            <asp:GridView ID="gvFacultyMentors" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                OnRowEditing="gvFacultyMentors_RowEditing" OnRowUpdating="gvFacultyMentors_RowUpdating"
                OnRowCancelingEdit="gvFacultyMentors_RowCancelingEdit" OnRowDeleting="gvFacultyMentors_RowDeleting"
                CssClass="gridview">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />
                    <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CssClass="btn" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("UserName") %>' CssClass="form-control" />
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#FFCC00" />
            </asp:GridView>
            <div>
                <h2>Add New Faculty Mentor</h2>
                <label for="txtNewUserName">User Name:</label>
                <asp:TextBox ID="txtNewUserName" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <label for="txtNewEmail">Email:</label>
                <asp:TextBox ID="txtNewEmail" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <label for="txtNewUserID">User ID:</label>
                <asp:TextBox ID="txtNewUserID" runat="server" CssClass="form-control"></asp:TextBox>
<br />
<label for="txtNewPassword">Password:</label>
<asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
<br />
<asp:Button ID="btnAdd" runat="server" Text="Add Faculty Mentor" OnClick="btnAdd_Click" CssClass="btn" Width="243px" />
<asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn" />
</div>
</div>
</form>
</body>
</html>