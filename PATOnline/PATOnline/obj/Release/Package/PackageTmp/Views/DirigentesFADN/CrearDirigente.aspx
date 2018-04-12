<%@ Page Title="DIRIGENTES INTERNACIONALES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearDirigente.aspx.cs" Inherits="PATOnline.Views.DirigentesFADN.CrearDirigente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title black">
            <asp:Label runat="server" ID="lbl"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="DropCargo" CssClass="control-label">Cargo</asp:Label>
              <asp:DropDownList runat="server" ID="DropCargo" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropCargo"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtNombre1" CssClass="control-label">Primera Nombre</asp:Label>
              <asp:TextBox runat="server" ID="TxtNombre1" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtNombre1"
                CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtNombre2" CssClass="control-label">Segundo Nombre</asp:Label>
              <asp:TextBox runat="server" ID="TxtNombre2" CssClass="form-control" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtApellido1" CssClass="control-label">Primera Apellido</asp:Label>
              <asp:TextBox runat="server" ID="TxtApellido1" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtApellido1"
                CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtApellido2" CssClass="control-label">Segundo Apellido</asp:Label>
              <asp:TextBox runat="server" ID="TxtApellido2" CssClass="form-control" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtFecha" CssClass="control-label">Fecha de Inicio</asp:Label>
              <asp:TextBox runat="server" ID="TxtFecha" CssClass="form-control" TextMode="Date" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtFecha"
                CssClass="text-danger" ErrorMessage="* La Fecha de Inicio es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="TxtPeriodo" CssClass="control-label">Periodo</asp:Label>
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
  <div class="row">
    <!--ShowModel Ver-->
    <div class="containere">
      <div class="row gradiant titulo">
        <div class="col-sm-8 gris">
          <h3>
            <asp:Label runat="server" ID="lblInfo"></asp:Label>
          </h3>
        </div>
        <div class="col-sm-4" style="text-align-last: right;">
          <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
        </div>
      </div>

      <div id="demo" class="row collapse in panel panel-default">
        <div class="row" style="text-align: center">
          <h5><b>
            <asp:Label runat="server" ID="lblSub"></asp:Label>
          </b></h5>
        </div>
        <div class="panel-body">
          <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
            CssClass="footable" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" OnRowCommand="gvListadoInfo_RowCommand" AllowSorting="True">
            <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
            <Columns>
              <asp:BoundField DataField="numero" HeaderText="No.">
                <ItemStyle Width="1%" />
              </asp:BoundField>
              <asp:BoundField DataField="cargo" HeaderText="Cargo">
                <ItemStyle Width="6%" />
              </asp:BoundField>
              <asp:BoundField DataField="nombre" HeaderText="Nombre">
                <ItemStyle Width="10%" />
              </asp:BoundField>
              <asp:BoundField DataField="federacion" HeaderText="FADN">
                <ItemStyle Width="25%" />
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

