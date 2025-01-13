<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Prog4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 277px;
        }
        .auto-style2 {
            width: 140px;
        }
        .auto-style3 {
            width: 270px;
        }
         table {
            border-collapse: collapse;
            width: 50%;
            margin: 20px auto;
        }
        th, td {
            border: 1px solid black;
            padding: 8px;
            text-align: center;
        }
        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body style="width: 533px; height: 184px">
    <form id="form1" runat="server">
        <div>
            <table style="width:120%;" border="2" height="250%">
                <tr>
                    <td class="auto-style2">ID</td>
                    <td class="auto-style1">Name</td>
                    <td class="auto-style3">Salary</td>
                </tr>
                <tr>
                    <td class="auto-style2">100</td>
                    <td class="auto-style1">Rishab</td>
                    <td class="auto-style3">7000</td>
                </tr>
                <tr>
                    <td class="auto-style2">101</td>
                    <td class="auto-style1">Dharani</td>
                    <td class="auto-style3">7800</td>
                </tr>
                <tr>
                    <td class="auto-style2">102</td>
                    <td class="auto-style1">Joseph</td>
                    <td class="auto-style3">8500</td>
                </tr>
                <tr>
                    <td class="auto-style2">103</td>
                    <td class="auto-style1">Yamuna</td>
                    <td class="auto-style3">9500</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
