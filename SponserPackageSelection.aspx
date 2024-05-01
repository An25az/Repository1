<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SponserPackageSelection.aspx.cs" Inherits="SponsorshipPackageSelection" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
            background-color: #007bff;
            color: #fff;
        }
        tr:hover {
            background-color: #f2f2f2;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Sponsorship Packages Selection</h1>
            <asp:GridView ID="gvSponsorshipPackages" runat="server" AutoGenerateColumns="False" OnRowCommand="gvSponsorshipPackages_RowCommand">
                <Columns>
                    <asp:BoundField DataField="PackageID" HeaderText="Package ID" />
                    <asp:BoundField DataField="PackageName" HeaderText="Package Name" />
                    <asp:BoundField DataField="Benefits" HeaderText="Benefits" />
                    <asp:BoundField DataField="Cost" HeaderText="Cost" />
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:Button ID="btnSelectPackage" runat="server" Text="Select" CommandName="SelectPackage" CommandArgument='<%# Eval("PackageID") %>' CssClass="select-btn" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSelectedPackage" runat="server" Visible="false"></asp:Label>
            <p id="selected-package-info" style="display: none;"></p>
        </div>
    </form>
    <!-- Define the JavaScript function to display the message -->
    <script>
        function showMessage(message) {
            alert(message);
        }
    </script>
</body>
</html>