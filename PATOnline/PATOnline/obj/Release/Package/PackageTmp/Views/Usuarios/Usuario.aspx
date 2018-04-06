<%@ Page Title="USUARIO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="PATOnline.Views.Usuarios.Usuario" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <p class="text-danger">
    <asp:Literal runat="server" ID="ErrorMessage" />
  </p>

  <div class="form-horizontal">
    <div class="jumbheader">
      <h1 class="black">
        <%: Title %>
        <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
        <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true) { %>
        <a href="Create" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a>
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
        <asp:GridView ID="gvListadoUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoUsuarios_PageIndexChanging"
          CssClass="footable" AllowCustomPaging="False" OnRowCommand="gvListadoUsuarios_RowCommand" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
          <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
          <Columns>
            <asp:BoundField DataField="numero" HeaderText="No." >
              <ItemStyle Width="1%" />
            </asp:BoundField>
            <asp:BoundField DataField="user" HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="1%" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre_completo" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="18%" />
            </asp:BoundField>
            <asp:BoundField DataField="fadn" HeaderText="Federacion / Asociacion" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="direccion" HeaderText="Domicilio" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="15%" />
            </asp:BoundField>
            <asp:BoundField DataField="correo" HeaderText="Correo Electronico" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="4%" />
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
  </div>
</asp:Content>
