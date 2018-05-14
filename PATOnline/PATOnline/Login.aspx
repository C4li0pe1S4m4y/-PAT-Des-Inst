<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PATOnline.Views.Login.Login" %>

<!DOCTYPE html>
<html lang="en" class="no-js">

    <head>

        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <!-- CSS -->
        <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=PT+Sans:400,700'>
        <link rel="stylesheet" href="assets/css/reset.css">
        <link rel="stylesheet" href="assets/css/style.css">

        <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
        <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->

    </head>

    <body style="background-image:url(assets/img/backgrounds/FondoLogin.jpg)">
        <div class="page-container">            
            <form id="form1" runat="server">
              <div class="row">
                <a><img src="Content/logo-cdag.png" /></a>
              </div>
              <div class="row">
                <h1><asp:Label runat="server" ID="lblTitulo" CssClass="white"></asp:Label></h1>
                <asp:TextBox runat="server"  CssClass="form-control" ID="TxtUser" placeholder="Usuario"></asp:TextBox>
                <div class="row">
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtUser"
                  CssClass="text-danger" ErrorMessage="* El Usuario es obligatorio" />
                </div>
                <asp:TextBox runat="server" CssClass="form-control" ID="TxtPass" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:Button runat="server" CssClass="btn-primary" Text="INGRESAR" OnClick="Ingresar_Click"/>  
              </div>                                                                                                                       
            </form>
        </div>

        <!-- Javascript -->
        <script src="assets/js/jquery-1.8.2.min.js"></script>
        <script src="assets/js/scripts.js"></script>

    </body>

</html>
