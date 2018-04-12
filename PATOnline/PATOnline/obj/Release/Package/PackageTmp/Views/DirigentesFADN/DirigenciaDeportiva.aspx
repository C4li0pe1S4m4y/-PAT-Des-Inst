<%@ Page Title="DIRIGENCIA DEPORTIVA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DirigenciaDeportiva.aspx.cs" Inherits="PATOnline.Views.DirigentesFADN.DirigenciaDeportiva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="form-horizontal">
    <div class="jumbheader">
      <div class="row" style="text-align: center;">
        <h1 class="black"><%: Title %></h1>
      </div>
      <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
      <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
          { %>
      <br />
      <div class="row" style="text-align: center; align-content: center;">
        <div class="col-md-4">
          <h2>
            <asp:Label runat="server" ID="lblAsamblea"></asp:Label>
            <a href="CrearAsamblea.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h2>
        </div>
        <div class="col-md-4">
          <h2>
            <asp:Label runat="server" ID="lblOrgano"></asp:Label>
            <a href="CrearOrgano.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h2>
        </div>
        <div class="col-md-4">
          <h2>
            <asp:Label runat="server" ID="lblComision"></asp:Label>
            <a href="CrearComision.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h2>
        </div>
      </div>
      <br />
      <div class="row" style="text-align: center; align-content: center;">
        <div class="col-md-6">
          <h2>
            <asp:Label runat="server" ID="lblPersonal"></asp:Label>
            <a href="CrearPersonal.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h2>
        </div>
        <div class="col-md-6">
          <h2>
            <asp:Label runat="server" ID="lblDirigente"></asp:Label>
            <a href="CrearDirigente.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h2>
        </div>
      </div>
      <% } %>
    </div>
    <!--ShowModel Ver-->
    <div class="containere">
      <div class="row gradiant titulo">
        <div class="col-sm-8 gris">
          <h3>
            <asp:Label runat="server" ID="lblInfoComite"></asp:Label>
          </h3>
        </div>
        <div class="col-sm-4" style="text-align-last: right;">
          <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
        </div>
      </div>

      <div id="demo" class="row collapse in panel panel-default">
        <div class="row" style="text-align: center">
          <h5><b>
            <asp:Label runat="server" ID="lblSubComite"></asp:Label>
          </b></h5>
        </div>
        <div class="panel-body">
          <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="tipo" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
            CssClass="footable" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" OnRowCommand="gvListadoInfo_RowCommand" AllowSorting="True">
            <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
            <Columns>
              <asp:BoundField DataField="tipo" HeaderText="Cargo">
                <ItemStyle Width="6%" />
              </asp:BoundField>
              <asp:BoundField DataField="nombre" HeaderText="Nombre">
                <ItemStyle Width="10%" />
              </asp:BoundField>
              <asp:BoundField DataField="federacion" HeaderText="FADN">
                <ItemStyle Width="25%" />
              </asp:BoundField>
            </Columns>
          </asp:GridView>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
