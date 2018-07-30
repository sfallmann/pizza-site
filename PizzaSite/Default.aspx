<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PizzaSite.Default" MaintainScrollPositionOnPostback="true" %>

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
    hr.styled-hr {
      height: 40px;
	    background: url(Content/hr-enjoy.jpg) no-repeat center;
      border-top-color: white;
    }
    td label {
      height: 15px;
      margin-left: 15px;
    }
    #total-label {
      padding: 5px;
      font-size: 16px;
      font-weight: 800;
      margin-bottom: 10px;
    }
  </style>
</head>
<body>
  <header class="container-fluid">
    <img class="img-responsive center-block" src="Content/little-petes-logo.PNG" alt="Little Pete's Pizzeria logo"/>
    <hr class="styled-hr"/>
  </header>
  <main class="container-fluid">
    <section class="row">
    <form id="orderForm" runat="server" >
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <div class="col-md-4 col-md-offset-4">
            <div class="form-group">
              <label for="sizeDropDownList">Size</label>
              <asp:DropDownList ID="sizeDropDownList" runat="server" CssClass="form-control" AutoPostBack="True">
              </asp:DropDownList>
            </div>
          </div>
          <div class="col-md-4 col-md-offset-4">
            <div class="form-group">
              <label for="crustDropDownList">Crust</label>
              <asp:DropDownList ID="crustDropDownList" runat="server" CssClass="form-control" AutoPostBack="True">
              </asp:DropDownList>
            </div>
          </div>
          <br />
          <div class="col-md-4 col-md-offset-4">
            <div class="form-group">
              <label for="toppingsCheckBoxList">Toppings</label>
              <asp:CheckBoxList ID="toppingsCheckBoxList" runat="server" AutoPostBack="True">
              </asp:CheckBoxList>
            </div>
          </div>
          <div class="col-md-4 col-md-offset-4">
            <hr />
          </div>
          <div class="col-md-4 col-md-offset-4">
            <div class="form-group">
              <label for="nameTextBox">Name <span class="glyphicon glyphicon-asterisk"></span></label>
              <asp:TextBox ID="nameTextBox" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            </div>
          </div>
          <div class="col-md-4 col-md-offset-4">
            <div class="form-group">
              <label for="addressTextBox">Address <span class="glyphicon glyphicon-asterisk"></span></label>
              <asp:TextBox ID="addressTextBox" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            </div>
          </div>
          <div class="col-md-4 col-md-offset-4">
            <div class="form-group">
              <label for="zipCodeTextBox">Zipcode <span class="glyphicon glyphicon-asterisk"></span></label>
              <asp:TextBox ID="zipCodeTextBox" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            </div>
          </div>
          <div class="col-md-4 col-md-offset-4">
            <div class="form-group">
              <label for="phoneTextBox">Phone <span class="glyphicon glyphicon-asterisk"></span></label>
              <asp:TextBox ID="phoneTextBox" runat="server" required="required" CssClass="form-control"></asp:TextBox>
            </div>
          </div>
          <div class ="col-md-4 col-md-offset-4">
            <div id="total-label">
              Total: <asp:Label ID="totalLabel" runat="server" Text="$0.00"></asp:Label>
            </div>
          </div>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="crustDropDownList" EventName="SelectedIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="sizeDropDownList" EventName="SelectedIndexChanged" />
          <asp:AsyncPostBackTrigger ControlID="toppingsCheckBoxList" EventName="SelectedIndexChanged" />
        </Triggers>
      </asp:UpdatePanel>
      <div class="col-md-4 col-md-offset-4">
        <asp:Button ID="orderButton" runat="server" Text="Order!" class="btn btn-lg btn-primary" OnClick="OrderButton_Click"/>
      </div>
    </form>
    </section>
  </main>
  <script>
  </script>
</body>
</html>
