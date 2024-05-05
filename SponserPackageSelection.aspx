<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SponserPackageSelection.aspx.cs" Inherits="SponsorshipPackageSelection" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sponsorship Packages Selection</title>
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
        .select-btn {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 8px 16px;
            cursor: pointer;
            border-radius: 5px;
        }
        .select-btn:hover {
            background-color: #0056b3;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        th, td {
            padding: 10px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Sponsorship Packages Selection</h1>
            <%--<div>
                <label for="txtSponsorName">Sponsor Name:</label>
                <asp:TextBox ID="txtSponsorName" runat="server"></asp:TextBox>
            </div>--%>
            <br />
            <div>
                <h2>Select a Package:</h2>
                <asp:Button ID="btnBronze" runat="server" Text="Bronze Package" OnClick="SelectPackage" CommandArgument="Bronze" CssClass="select-btn" />
                <asp:Button ID="btnSilver" runat="server" Text="Silver Package" OnClick="SelectPackage" CommandArgument="Silver" CssClass="select-btn" />
                <asp:Button ID="btnGold" runat="server" Text="Gold Package" OnClick="SelectPackage" CommandArgument="Gold" CssClass="select-btn" />
            </div>
            <br />
            <asp:Label ID="lblSuccessMessage" runat="server" Visible="false" Text="Success message will appear here"></asp:Label>
            
            <!-- Grid to display package information -->
            <table id="packageGrid" runat="server">
                <tr>
                    <th>Package</th>
                    <th>Description</th>
                    <th>Benefits</th>
                </tr>
                <tr>
                    <td>Bronze</td>
                    <td>Basic package</td>
                    <td>Logo on event website</td>
                </tr>
                <tr>
                    <td>Silver</td>
                    <td>Standard package</td>
                    <td>Logo on event website, social media mentions</td>
                </tr>
                <tr>
                    <td>Gold</td>
                    <td>Premium package</td>
                    <td>Logo on event website, social media mentions, booth at event</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>