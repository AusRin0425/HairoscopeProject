<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="HairoScope.Invoice" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Invoice</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        #invoice {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            border: 1px solid #ccc;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        #header {
            text-align: center;
            margin-bottom: 20px;
        }

        #logo {
            width: 150px;
            height: auto;
        }

        #bill-from, #bill-to {
            width: 49%;
            display: inline-block;
            vertical-align: top;
        }

        #bill-from {
            margin-right: 2%;
        }

        #invoice-details {
            margin-top: 20px;
        }

        #items {
            margin-top: 20px;
            width: 100%;
            border-collapse: collapse;
        }

        #items th, #items td {
            border: 1px solid #ccc;
            padding: 10px;
            text-align: left;
        }

        #items th {
            background-color: #f2f2f2;
        }

        #total {
            margin-top: 20px;
            text-align: right;
        }

        /* Add this CSS to style the table */
       .invoice-table {
         width: 100%; /* Adjust the width as needed */
         border-collapse: collapse;
        }

        .invoice-table th, .invoice-table td {
           border: 1px solid #000;  Add border to cells 
           padding: 8px; /* Add padding for better spacing */
         }
    </style>
</head>
<body>
    <div id="invoice">
        <div id="header">
            <h1>Invoice</h1>
        </div>
        <div id="bill-to">
            <h2>Client Details:</h2>
            <p id="clientNAME" runat="server">Client Name</p>
            <p id="clientADDRESS" runat="server">Client Address</p>
            <p id="clientCITY" runat="server">Client City, State, ZIP</p>
            <p id="clientEMAIL" runat="server">Client Contact</p>
        </div>
        <div id="invoice-details">
            <p id="INV_ID" runat="server"><strong>Invoice Number:</strong>INV-001</p>
            <p id="INV_DATE"  runat="server"><strong>Invoice Date:</strong> September 25, 2023</p>
        </div> 
        <asp:Table id="itemm" runat="server">

        </asp:Table>
        <div id="total">
            <p><strong id="totalprice" runat="server">Total:R0</strong></p>
        </div>
    </div>
</body>
</html>
