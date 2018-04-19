<%@ Page Title="ROL Y PERMISO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolPermiso.aspx.cs" Inherits="PATOnline.Views.RolPermiso.RolPermiso" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <div class="container">
    <div class="jumbheader">
      <h1 class="white">
        <%: Title %>
        <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
        <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
            { %>
        <a href="CreateRolPermiso.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a>
        <% } %> 
      </h1>
    </div>
    <div class="row gradiant titulo">
      <div class="col-sm-8">
        <h3>
          <asp:Label runat="server" ID="lblSubTitulo" ForeColor="White"></asp:Label></h3>
      </div>
      <div class="col-sm-4" style="text-align-last: right;">
        <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
      </div>
    </div>

    <div id="demo" class="row collapse in panel panel-default">
      <div class="panel-body">
        <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
          CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" OnRowCommand="gvListadoInfo_RowCommand1" GridLines="None" AllowSorting="True">
          <Columns>
            <asp:BoundField DataField="rol" HeaderText="NOMBRE DEL ROL">
              <ItemStyle Width="30%"/>
            </asp:BoundField>
            <asp:BoundField DataField="pantalla" HeaderText="NOMBRE DE LA PANTALLA">
              <ItemStyle Width="30%"/>
            </asp:BoundField>
            <asp:BoundField DataField="boton" HeaderText="NOMBRE DEL BOTÓN">
              <ItemStyle Width="30%"/>
            </asp:BoundField>
            <asp:TemplateField HeaderText="OPCIONES">
              <ItemTemplate>
                <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
                <% if (boton.BotonEditar(this.Session["Usuario"].ToString()) == true)
                    { %>
                <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-edit" data-toggle="tooltip" data-placement="bottom" title="¡Editar!" CausesValidation="false"
                  CommandName="Editar" CommandArgument="numero" Text="Editar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-pencil"></span>
                </asp:LinkButton>
                <% } %>
                <% if (boton.BotonVer(this.Session["Usuario"].ToString()) == true)
                    { %>
                <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-view" data-toggle="modal" data-placement="bottom" title="¡Ver!" CausesValidation="false"
                  CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Mostrar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-eye-open"></span>
                </asp:LinkButton>
                <% } %>
                <% if (boton.BotonEliminar(this.Session["Usuario"].ToString()) == true)
                    { %>
                <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-delete" data-toggle="tooltip" data-placement="bottom" title="¡Eliminar!" CausesValidation="false"
                  OnClientClick="¿Está seguro que desea Eliminar el registro?" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-trash"></span></span>
                </asp:LinkButton>
                <% } %>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>
    </div>
  </div>
</asp:Content>
