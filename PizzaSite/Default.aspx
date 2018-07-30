<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaSite.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <meta name="description" content="Little Pete's Pizzeria website" />
  <meta name="keywords" content="fake fictional educational practice project" />
  <title>Little Pete's Pizzeria - Order Form</title>
  <link href="Content/bootstrap.min.css" rel="stylesheet" />
  <script src="Scripts/jquery-1.9.0.min.js"></script>
  <script src="Scripts/bootstrap.min.js"></script>
  <style>
    body {
      background-color: lightsalmon;
    }
    header {
      background-color: white;
    }
    main {
      padding-top: 15px;
      padding-bottom: 15px;
    }
  </style>
</head>
<body>
  <header class="container-fluid">
    <img class="img-responsive center-block" src="Content/little-petes-logo.PNG" alt="Little Pete's Pizzeria logo"/>
  </header>
  <main class="container-fluid">
    <section class="row">
    <form id="orderForm" runat="server" >
      <div class="col-md-4 col-md-offset-4">
        <div class="form-group">
          <label for="sizeDropDownList">Size</label>
          <asp:DropDownList ID="sizeDropDownList" runat="server" CssClass="form-control">
          </asp:DropDownList>
        </div>
      </div>
      <div class="col-md-4 col-md-offset-4">
        <div class="form-group">
          <label for="crustDropDownList">Crust</label>
          <asp:DropDownList ID="crustDropDownList" runat="server" CssClass="form-control">
          </asp:DropDownList>
        </div>
      </div>
      <div class="col-md-4 col-md-offset-4">
        <label for="toppingsCheckBoxList">Toppings</label>
        <asp:CheckBoxList ID="toppingsCheckBoxList" runat="server" OnSelectedIndexChanged="toppingsCheckBoxList_SelectedIndexChanged">
        </asp:CheckBoxList>
      </div>
    </form>
    </section>
  </main>
</body>
</html>
