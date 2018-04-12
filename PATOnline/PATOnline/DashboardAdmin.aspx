<%@ Page Title="Dashboar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardAdmin.aspx.cs" Inherits="PATOnline.DashboardAdmin" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <div class="col-md-4" style="text-align: center; align-content: center; color: black;">
        <h3><b><asp:Label runat="server" Text="Usuarios Resgistrados"></asp:Label></b></h3>
        <div class="well" style="color: black">
          <h1><b>
            <asp:Label runat="server" ID="lblContUsuario"></asp:Label></b></h1>
        </div>
      </div>
      <div class="col-md-4" style="text-align: center; align-content: center; color: black;">
        <h3><b><asp:Label runat="server" Text="Usuarios Activos"></asp:Label></b></h3>
        <div class="well" style="color: black">
          <h1><b>
            <asp:Label runat="server" ID="lblUsuarioActivo"></asp:Label></b></h1>
        </div>
      </div>
      <div class="col-md-4" style="text-align: center; align-content: center; color: black;">
        <h3><b><asp:Label runat="server" Text="Usuarios Inactivos"></asp:Label></b></h3>
        <div class="well" style="color: black">
          <h1><b>
            <asp:Label runat="server" ID="lblUsuarioInactivo"></asp:Label></b></h1>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
