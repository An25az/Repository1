<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Feedback</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f7fc;
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        .container {
            width: 80%;
            margin: 50px auto;
            background-color: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        h1 {
            color: #007bff;
            text-align: center;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            font-weight: bold;
        }

        input[type="range"],
        textarea {
            width: calc(100% - 10px);
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        textarea {
            height: 100px;
        }

        .rating-input {
            display: inline-block;
            margin-right: 10px;
        }

        input[type="radio"] {
            display: none;
        }

        input[type="radio"] + label {
            display: inline-block;
            width: 40px;
            height: 40px;
            line-height: 40px;
            text-align: center;
            border: 1px solid #ccc;
            border-radius: 50%;
            cursor: pointer;
        }

        input[type="radio"]:checked + label {
            background-color: #007bff;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Event Feedback</h1>
            <div class="form-group">
                <label for="EventDropdown">Event Name:</label>
                <asp:DropDownList ID="EventDropdown" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="Rating">Rating:</label>
                <div class="rating-input">
                    <input type="radio" id="rating1" name="rating" value="1" runat="server" />
                    <label for="rating1">1</label>
                </div>
                <div class="rating-input">
                    <input type="radio" id="rating2" name="rating" value="2" runat="server" />
                    <label for="rating2">2</label>
                </div>
                <div class="rating-input">
                    <input type="radio" id="rating3" name="rating" value="3" runat="server" />
                    <label for="rating3">3</label>
                </div>
                <div class="rating-input">
                    <input type="radio" id="rating4" name="rating" value="4" runat="server" />
                    <label for="rating4">4</label>
                </div>
                <div class="rating-input">
                    <input type="radio" id="rating5" name="rating" value="5" runat="server" />
                    <label for="rating5">5</label>
                </div>
            </div>
            <div class="form-group">
                <label for="Comment">Comment:</label>
                <textarea id="Comment" runat="server"></textarea>
            </div>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-primary" />
        </div>
    </form>

    <script>
        window.onload = function () {
            var radios = document.querySelectorAll('input[type="radio"]');
            for (var i = 0; i < radios.length; i++) {
                radios[i].addEventListener('click', function () {
                    var clickedIndex = parseInt(this.value);
                    for (var j = 0; j < clickedIndex; j++) {
                        radios[j].checked = true;
                    }
                });
            }
        };
    </script>
</body>
</html>
