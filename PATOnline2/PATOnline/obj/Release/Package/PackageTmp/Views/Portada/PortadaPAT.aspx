<%@ Page Title="PORTADA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PortadaPAT.aspx.cs" Inherits="PATOnline.Views.Portada.PortadaPAT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row" style="align-items:center; align-content:center; text-align:center">
    <div class="row">
      <asp:Image runat="server" ID="Imagelogo" CssClass="logo" Width="200" Height="200" />
    </div>
    <div class="row">
      <div class="well">
        <h1> <b> <asp:Label runat="server" ID="lblFederacion"></asp:Label> </b> </h1>
      </div>
    </div>
    <div class="row">
      <div class="well">
        <div class="row">
        <h1> <b>PLAN ANUAL DE TRABAJO</b> </h1>
        </div>
        <div class="row">
        <h1> <b> <asp:Label runat="server" ID="lblAnio"></asp:Label> </b> </h1>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
