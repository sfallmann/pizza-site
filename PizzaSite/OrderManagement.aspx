<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderManagement.aspx.cs" Inherits="PizzaSite.OrderManagement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <meta name="description" content="Little Pete's Pizzeria website" />
  <meta name="keywords" content="fake fictional educational practice project" />
  <title>Little Pete's Pizzeria - Order Management</title>
  <link href="Content/bootstrap.min.css" rel="stylesheet" />
  <script src="Scripts/jquery-1.9.0.min.js"></script>
  <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="OrdersGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource" OnRowCommand="OrdersGridView_OnRowCommand">
          <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="OrderItems" HeaderText="OrderItems" ReadOnly="True" SortExpression="OrderItems" />
            <asp:BoundField DataField="Total" DataFormatString="{0:C}" HeaderText="Total" SortExpression="Total" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:ButtonField CommandName="CompleteOrder" Text="Complete" />
          </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [v_OrderDetailsConcat] WHERE v_OrderDetailsConcat.Status = 'InProgress'"></asp:SqlDataSource>
    </form>
</body>
</html>
