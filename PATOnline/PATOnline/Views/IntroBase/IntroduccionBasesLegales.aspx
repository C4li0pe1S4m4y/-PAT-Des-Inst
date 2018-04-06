<%@ Page Title="INTRODUCCIÓN - BASE LEGAL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IntroduccionBasesLegales.aspx.cs" Inherits="PATOnline.Views.IntroBase.IntroduccionBasesLegales" %>

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
        <a href="CreateInfo.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a>
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
          CssClass="footable" AllowCustomPaging="True" PageSize="6" BorderStyle="Groove" OnRowCommand="gvListadoInfo_RowCommand">
          <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
          <Columns>
            <asp:BoundField DataField="numero" HeaderText="Codigo">
              <ItemStyle Width="1%" />
            </asp:BoundField>
            <asp:BoundField DataField="introduccion" HeaderText="Introduccion" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="26%" />
            </asp:BoundField>
            <asp:BoundField DataField="marco" HeaderText="Marco Juridico" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="27%" />
            </asp:BoundField>
            <asp:BoundField DataField="afiliacion" HeaderText="Afiliacion Organizacional" ItemStyle-HorizontalAlign="Center">
              <ItemStyle Width="27%" />
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
  </div>
</asp:Content>
