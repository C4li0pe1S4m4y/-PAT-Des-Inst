<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmarUsuario.aspx.cs" Inherits="PATOnline.ConfirmarUsuario" %>

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
    </head>

    <body style="background-image:url(assets/img/backgrounds/FondoLogin.jpg)">
        <div class="page-container">            
            <form id="form1" runat="server">
              <div class="row">
                <h1><b>CONFIRMAR CORREO ELECTRONICO</b></h1>
              </div>
              <div class="row">
                <asp:TextBox runat="server" CssClass="username" ID="TxtEmail" placeholder="E-mail" TextMode="Email"></asp:TextBox>
                <div class="row">
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtEmail"
                  CssClass="text-danger" ErrorMessage="* El Correo Electrónico es obligatorio" />
                </div>
                <br />
                <asp:TextBox runat="server" CssClass="username" ID="TxtToken" placeholder="Código"></asp:TextBox>
                <div class="row">
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtToken"
                  CssClass="text-danger" ErrorMessage="* El Código es obligatorio" />
                </div>
                <div class="row">
                  <asp:Button runat="server" ID="Confirmar" CssClass="btn-primary" Text="CONFIRMAR" OnClick="Confirmar_Click" />  
                </div>
              </div>                                                                                                                       
            </form>
        </div>

        <!-- Javascript -->
        <script src="assets/js/jquery-1.8.2.min.js"></script>
        <script src="assets/js/scripts.js"></script>

    </body>

</html>

