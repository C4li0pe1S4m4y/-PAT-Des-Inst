<%@ Page Title="FEDERACIÓN / ASOSIACIÓN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FADN.aspx.cs" Inherits="PATOnline.Views.FADN.FADN" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="tab-content faq-cat-content">
    <div class="panel-group">
      <div class="jumbheader">
        <h1 class="black">
          <%: Title %>
          <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
          <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
              { %>
          <a href="CreateFADN.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a>
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
          <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id_fand" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
            CssClass="footable" AllowCustomPaging="False" BorderStyle="Groove" OnRowCommand="gvListadoInfo_RowCommand1" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
            <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
            <Columns>
              <asp:BoundField DataField="id_fand" HeaderText="Correlativo">
                <ItemStyle Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="nombre" HeaderText="Nombre FADN" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Width="20%" />
              </asp:BoundField>
              <asp:BoundField DataField="Direccion" HeaderText="Ubicacion" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Width="27%" />
              </asp:BoundField>
              <asp:BoundField DataField="telefono" HeaderText="Telefono" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="correo_electronico" HeaderText="Correo Electronico" ItemStyle-HorizontalAlign="Center">
                <ItemStyle Width="5%" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Logotipo">
                <ItemTemplate>
                  <asp:Image ID="image1" runat="server" ImageUrl='<%# Eval("logo") %>' Width="100" Height="100" />
                </ItemTemplate>
              </asp:TemplateField>
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
    </div>
  </div>
</asp:Content>
