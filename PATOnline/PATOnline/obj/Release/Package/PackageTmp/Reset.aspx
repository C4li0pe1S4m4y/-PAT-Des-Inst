<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="PATOnline.Reset" %>

<!DOCTYPE html>

<head runat="server">
  <title>ResetPassword</title>
  <!-- CSS -->
  <link rel='stylesheet' href='http://fonts.googleapis.com/css?family=PT+Sans:400,700'>
  <link rel="stylesheet" href="assets/css/reset.css">
  <link rel="stylesheet" href="assets/css/style.css">
  <style>
    .weak {
      background-color: #ff4800;
      color: black;
    }

    .average {
      background-color: #ff8300;
      color: black;
    }

    .good {
      background-color: #ffc700;
      color: black;
    }

    .excellent {
      background-color: #72ff00;
      color: black;
    }

    .barline {
      width: 100px;
      height: 5px;
    }
  </style>
</head>
<body style="background-image: url(assets/img/backgrounds/FondoLogin.jpg)">

  <div class="page-container">
    <form id="form1" runat="server">

      <asp:ScriptManager runat="server">
        <Scripts>
          <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
          <%--Framework Scripts--%>
          <asp:ScriptReference Name="MsAjaxBundle" />
          <asp:ScriptReference Name="jquery" />
          <asp:ScriptReference Name="bootstrap" />
          <asp:ScriptReference Name="respond" />
          <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
          <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
          <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
          <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
          <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
          <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
          <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
          <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
          <asp:ScriptReference Name="WebFormsBundle" />
          <%--Site Scripts--%>
          <asp:ScriptReference Path="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.5/angular.min.js" />
          <asp:ScriptReference Path="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" />
          <asp:ScriptReference Path="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js" />
        </Scripts>
      </asp:ScriptManager>

      <div class="row">
        <h1><b>CAMBIAR PASSWORD</b></h1>
      </div>
      <br />
      <div class="row">
        <div class="row">
          <h1>BIENVENIDO
            <asp:Label runat="server" ID="lblUser"></asp:Label>
          </h1>
        </div>
      </div>
      <br />
      <div class="row">
        <div class="row">
          <asp:Label runat="server" AssociatedControlID="TxtPassword" CssClass="control-label">Password</asp:Label>
          <asp:TextBox runat="server" ID="TxtPassword" CssClass="password" TextMode="Password"></asp:TextBox>
          <div class="row">
            <p>
              <asp:Label runat="server" ID="seguridad"></asp:Label></p>
          </div>
          <br />
          <div class="row">
            <asp:RegularExpressionValidator ValidationGroup="usuario" Display="Dynamic" ID="RegularExpressionValidator1"
              ErrorMessage="* El Password tiene que tener al menos 8 caracteres entre Mayúsculas, Minúsculas, Números y @ o #"
              ForeColor="White" ValidationExpression="(?=^.{8,15}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#])(?!.*\s).*$"
              ControlToValidate="TxtPassword" runat="server" />
          </div>
          <ajaxToolkit:PasswordStrength 
            TextStrengthDescriptionStyles="very;weak;average;good;excellent" 
            Enabled="true"
            BarBorderCssClass="barline" 
            BarIndicatorCssClass="barline"
            PreferredPasswordLength="8"
            TargetControlID="TxtPassword"
            ID="TextBox2_PasswordStrength"
            runat="server" 
            StrengthIndicatorType="BarIndicator"
            HelpStatusLabelID="seguridad"
            MinimumNumericCharacters="1"
            MinimumSymbolCharacters="1" 
            MinimumLowerCaseCharacters="1" 
            MinimumUpperCaseCharacters="1" 
            DisplayPosition="RightSide" 
            HelpHandlePosition="RightSide" 
            EnableViewState="true" 
            RequiresUpperAndLowerCaseCharacters="true" 
            ViewStateMode="Enabled"
            TextStrengthDescriptions="Muy Baja;Baja;Media;Buena;Excelente" />
        </div>
        <br />
        <div class="row">
          <asp:Label runat="server" AssociatedControlID="TxtConfirPassword" CssClass="control-label">Confirmar Password</asp:Label>
          <asp:TextBox runat="server" ID="TxtConfirPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
          <div class="row">
            <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtConfirPassword"
              CssClass="text-danger" Display="Dynamic" ErrorMessage="La Confirmación de Password es obligatoria" />
            <asp:CompareValidator ValidationGroup="usuario" runat="server" ControlToCompare="TxtPassword" ControlToValidate="TxtConfirPassword"
              CssClass="text-danger" Display="Dynamic" ErrorMessage="El Password y la Confirmación no coinciden" />
          </div>
        </div>
        <div class="row">
          <asp:Button runat="server" CssClass="btn-primary" Text="CAMBIAR" ID="Reset" OnClick="Reset_Click" />
        </div>
      </div>
    </form>
  </div>

  <!-- Javascript -->
  <script src="assets/js/jquery-1.8.2.min.js"></script>
  <script src="assets/js/scripts.js"></script>

</body>
</html>
