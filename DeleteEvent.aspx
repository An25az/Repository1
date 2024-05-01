<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteEvent.aspx.cs" Inherits="DeleteEventPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Event</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Delete Event</h1>
            <asp:CheckBoxList ID="chkEventsToDelete" runat="server"></asp:CheckBoxList><br />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="button" /><br />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
