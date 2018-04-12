<%@ Page Title="Rol y Permiso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolPermiso.aspx.cs" Inherits="PATOnline.Views.RolPermiso.RolPermiso" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <p class="text-danger">
    <asp:Literal runat="server" ID="ErrorMessage" />
  </p>


  <div class="jumbheader">
    <h1 class="black">
      <%: Title %>
      <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
      <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
          { %>
      <a href="CreateRolPermiso.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a>
      <% } %> 
    </h1>
  </div>
  <div class="row gradiant titulo">
    <div class="col-sm-8 gris">
      <h3>
        <asp:Label runat="server" ID="lblSubTitulo"></asp:Label>
      </h3>
    </div>
    <div class="col-sm-4" style="text-align-last: right;">
      <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
    </div>
  </div>

  <div id="demo" class="row collapse in panel panel-default">
    <div class="panel-body">
      <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
        CssClass="footable" AllowCustomPaging="False" BorderStyle="Groove" OnRowCommand="gvListadoInfo_RowCommand1" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
        <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
        <Columns>
          <asp:BoundField DataField="numero" HeaderText="Correlativo">
            <ItemStyle Width="5%" />
          </asp:BoundField>
          <asp:BoundField DataField="rol" HeaderText="Nombre Rol" ItemStyle-HorizontalAlign="Center">
            <ItemStyle Width="22%" />
          </asp:BoundField>
          <asp:BoundField DataField="pantalla" HeaderText="Nombre Pantalla" ItemStyle-HorizontalAlign="Center">
            <ItemStyle Width="22%" />
          </asp:BoundField>
          <asp:BoundField DataField="boton" HeaderText="Nombre Boton" ItemStyle-HorizontalAlign="Center">
            <ItemStyle Width="22%" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Opciones">
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

</asp:Content>
