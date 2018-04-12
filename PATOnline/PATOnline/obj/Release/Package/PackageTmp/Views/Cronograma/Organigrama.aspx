<%@ Page Title="Cronograma" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Organigrama.aspx.cs" Inherits="PATOnline.Views.Cronograma.Cronograma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="form-horizontal">
    <div class="jumbheader">
      <h1 class="black">
        ORGANIGRAMA INSTITUCIONAL
        <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
        <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true) { %>
        <a href="#" data-toggle="modal" data-target="#Mostrar" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a>
        <% } %> 
      </h1>
    </div>
    <!--ShowModel Ver-->
    <div class="containere">
      <!-- Modal -->
      <div class="modal fade" id="Mostrar" role="dialog">
        <div class="modal-dialog">
          <!-- Modal content-->
          <div class="modal-content">
            <div class="modal-header gradiant">
              <h4 class="modal-title black">
                <asp:Label runat="server" ID="lblTitulo"></asp:Label></h4>
            </div>
            <div class="modal-body">
              <br />
              <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Height="110" />
              <asp:RegularExpressionValidator ID="REGEXFileUploadLogo" runat="server"
                ErrorMessage="Solo se permiten imagenes .png" ControlToValidate="FileUpload1"
                ValidationExpression="(.*).(.png)$" />
              <br />
            </div>
            <div class="modal-footer gradiant-inver">
              <asp:LinkButton runat="server" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
                                <span class="glyphicon glyphicon-floppy-disk"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ID="Cancel" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" OnClick="Cancel_Click">
                                <span class="glyphicon glyphicon-ban-circle"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
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
          <asp:GridView ID="gvOrganigrama" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvOrganigrama_PageIndexChanging"
            CssClass="footable" AllowCustomPaging="False" OnRowCommand="gvOrganigrama_RowCommand" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
            <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
            <Columns>
              <asp:BoundField HeaderStyle-HorizontalAlign="Center" DataField="numero" HeaderText="Correlativo" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="8"></asp:BoundField>
              <asp:TemplateField HeaderText="Organigrama">
                <ItemTemplate>
                  <asp:Image ID="image1" runat="server" ImageUrl='<%# Eval("organigrama") %>' Width="100" Height="100" />
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Opciones">
                <ItemTemplate>
                  <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
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
