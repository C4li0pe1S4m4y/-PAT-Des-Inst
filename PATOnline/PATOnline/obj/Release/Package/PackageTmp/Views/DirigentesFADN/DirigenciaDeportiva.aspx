<%@ Page Title="DIRIGENCIA DEPORTIVA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DirigenciaDeportiva.aspx.cs" Inherits="PATOnline.Views.DirigentesFADN.DirigenciaDeportiva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="container">

    <div class="row" style="text-align: center;">
      <h1 class="white"><%: Title %></h1>
    </div>
    <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
    <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
        { %>
    <br />
    <div class="modal-content">
      <div class="modal-header gradiant">
        <div class="row" style="text-align: center; align-content: center;">
          <div class="col-md-4">
            <h4>
              <asp:Label runat="server" ID="lblAsamblea" ForeColor="White"></asp:Label>
              <a href="CrearAsamblea.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h4>
          </div>
          <div class="col-md-4">
            <h4>
              <asp:Label runat="server" ID="lblOrgano" ForeColor="White"></asp:Label>
              <a href="CrearOrgano.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h4>
          </div>
          <div class="col-md-4">
            <h4>
              <asp:Label runat="server" ID="lblComision" ForeColor="White"></asp:Label>
              <a href="CrearComision.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h4>
          </div>
        </div>
        <br />
        <div class="row" style="text-align: center; align-content: center;">
          <div class="col-md-6">
            <h4>
              <asp:Label runat="server" ID="lblPersonal" ForeColor="White"></asp:Label>
              <a href="CrearPersonal.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h4>
          </div>
          <div class="col-md-6">
            <h4>
              <asp:Label runat="server" ID="lblDirigente" ForeColor="White"></asp:Label>
              <a href="CrearDirigente.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h4>
          </div>
        </div>
      </div>
    </div>
    <% } %>
    <br />
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
        <div class="panel-body">
          <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="tipo" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
            CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" OnRowCommand="gvListadoInfo_RowCommand" AllowSorting="True">
            <Columns>
              <asp:BoundField DataField="tipo" HeaderText="CARGO">
                <ItemStyle Width="4%" />
              </asp:BoundField>
              <asp:BoundField DataField="nombre" HeaderText="NOMBRE">
                <ItemStyle Width="25%" />
              </asp:BoundField>
              <asp:BoundField DataField="federacion" HeaderText="FADN"></asp:BoundField>
            </Columns>
          </asp:GridView>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
