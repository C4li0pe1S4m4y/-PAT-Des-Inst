<%@ Page Title="USUARIO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="PATOnline.Views.Usuarios.Usuario" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="row">
    <h1>
      <%: Title %>
      <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
      <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
          { %>
      <a href="Create" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign"></span></a>
      <% } %> 
    </h1>
  </div>

  <div class="row gradiant titulo">
    <div class="col-sm-8">
      <h3>
        <asp:Label runat="server" ID="lblSubTitulo" ForeColor="White"></asp:Label>
      </h3>
    </div>
    <div class="col-sm-4" style="text-align-last: right;">
      <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
    </div>
  </div>

  <div id="demo" class="row collapse in panel panel-default">
    <div class="panel-body">
      <asp:GridView ID="gvListadoUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoUsuarios_PageIndexChanging"
        CssClass="footable" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" OnRowCommand="gvListadoUsuarios_RowCommand" GridLines="None" AllowSorting="True">
        <Columns>
          <asp:BoundField DataField="user" HeaderText="USUARIO">
            <ItemStyle Width="5%" />
          </asp:BoundField>
          <asp:BoundField DataField="nombre_completo" HeaderText="NOMBRE">
            <ItemStyle Width="20%" />
          </asp:BoundField>
          <asp:BoundField DataField="fadn" HeaderText="FEDERACIÓN / ASOCIACIÓN">
            <ItemStyle Width="25%" />
          </asp:BoundField>
          <asp:BoundField DataField="direccion" HeaderText="DOMICILIO">
            <ItemStyle Width="25%" />
          </asp:BoundField>
          <asp:BoundField DataField="correo" HeaderText="CORREO ELECTRÓNICO">
            <ItemStyle Width="10%" />
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

  <script type="text/javascript">
    $(function () {
      $('#gvListadoUsuarios').footable();
    });
  </script>
  <asp:Label runat="server" ID="lbl"></asp:Label>

  <!--ShowModel Ver-->
  <div class="containere">
    <!-- Modal -->
    <div class="modal fade" id="Mostrar" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
          <div class="modal-header gradiant">
            <button type="button" class="close" data-dismiss="modal">&times;</button>
            <h4 class="modal-title black">
              <asp:Label runat="server" ID="lblTitulo"></asp:Label></h4>
          </div>
          <div class="modal-body">
          </div>
          <div class="modal-footer gradiant-inver">
          </div>
        </div>
      </div>
    </div>
  </div>

</asp:Content>
