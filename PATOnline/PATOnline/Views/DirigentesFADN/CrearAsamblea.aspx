<%@ Page Title="DIRIGENCIA DEPORITVA - ASAMBLEA DE FADN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearAsamblea.aspx.cs" Inherits="PATOnline.Views.DirigentesFADN.CrearAsamblea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title">
            <asp:Label runat="server" ID="lbl"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="DropCargo" CssClass="control-label">CARGO</asp:Label>
              <asp:DropDownList runat="server" ID="DropCargo" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropCargo"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtNombre1" CssClass="control-label">PRIMER NOMBRE</asp:Label>
              <asp:TextBox runat="server" ID="TxtNombre1" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtNombre1"
                CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtNombre2" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
              <asp:TextBox runat="server" ID="TxtNombre2" CssClass="form-control" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtApellido1" CssClass="control-label">PRIMER APELLIDO</asp:Label>
              <asp:TextBox runat="server" ID="TxtApellido1" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtApellido1"
                CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtApellido2" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
              <asp:TextBox runat="server" ID="TxtApellido2" CssClass="form-control" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-10">
              <asp:Label runat="server" AssociatedControlID="TxtFecha" CssClass="control-label">FECHA DE INICIO</asp:Label>
              <asp:TextBox runat="server" ID="TxtFecha" CssClass="form-control" TextMode="Date" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtFecha"
                CssClass="text-danger" ErrorMessage="* La Fecha de Inicio es obligatorio" />
            </div>
            <div class="col-md-1">
              <asp:Label runat="server" AssociatedControlID="TxtPeriodo" CssClass="control-label">PERIODO</asp:Label>
              <asp:TextBox runat="server" ID="TxtPeriodo" CssClass="form-control" TextMode="Number" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtPeriodo"
                CssClass="text-danger" ErrorMessage="* Es Periodo es obligatorio" />
            </div>
          </div>
        </div>
        <div class="modal-footer gradiant-inver">
          <asp:LinkButton runat="server" ValidationGroup="validar" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
          </asp:LinkButton>
          <asp:LinkButton runat="server" CausesValidation="false" ID="Cancel" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" OnClick="Cancel_Click">
              <span class="glyphicon glyphicon-ban-circle"></span>
          </asp:LinkButton>
        </div>
      </div>
    </div>
    <br />
    <div class="row">
      <!--ShowModel Ver-->
      <div class="container">
        <div class="row gradiant titulo">
          <div class="col-md-8">
            <h3>
              <asp:Label runat="server" ID="lblInfo"></asp:Label>
            </h3>
          </div>
          <div class="col-sm-4" style="text-align-last: right;">
            <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
          </div>
        </div>

        <div id="demo" class="row collapse in panel panel-default">
          <div class="panel-body">
            <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
              CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" OnRowCommand="gvListadoInfo_RowCommand" AllowSorting="True">
              <Columns>
                <asp:BoundField DataField="numero" HeaderText="NO.">
                  <ItemStyle Width="1%" />
                </asp:BoundField>
                <asp:BoundField DataField="cargo" HeaderText="CARGO">
                  <ItemStyle Width="6%" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="NOMBRE">
                  <ItemStyle Width="25%" />
                </asp:BoundField>
                <asp:BoundField DataField="federacion" HeaderText="FADN">
                  <ItemStyle Width="50%" />
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
    </div>
</asp:Content>

