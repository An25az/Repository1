<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateReport.aspx.cs" Inherits="Reports" %>


<!DOCTYPE html>

<html xmlns="(link unavailable)">
<head runat="server">
    <title>Generate Reports</title>
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
        h1 {
            color: #007bff;
            text-align: center;
        }
        .btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 12px 24px;
            cursor: pointer;
            border-radius: 5px;
            font-size: 16px;
            font-weight: bold;
        }
        .btn:hover {
            background-color: #0056b3;
        }
        .button-container {
            text-align: center;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Generate Reports</h1>
            <asp:Literal ID="ltReportResults" runat="server"></asp:Literal>
            <div class="button-container">
                <asp:Button ID="btnGenerateReports" runat="server" Text="Generate Reports" OnClick="btnGenerateReports_Click" CssClass="btn" />
                <!-- Add Go to AdminDashboard button -->
                <asp:Button ID="btnGoToAdminDashboard" runat="server" Text="Go to AdminDashboard" OnClick="btnGoToAdminDashboard_Click" CssClass="btn" />
            </div>
        </div>
    </form>
</body>
</html>