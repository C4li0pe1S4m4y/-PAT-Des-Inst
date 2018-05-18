<%@ Page Title="ROL Y PERMISO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolPermiso.aspx.cs" Inherits="PATOnline.Views.RolPermiso.RolPermiso" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-12">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
      </div>
    </div>
  </div>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-6 col-sm-6 col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Nuevo Rol</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoRol" CausesValidation="false" OnClick="nuevoRol_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-3 col-sm-3 col-md-3">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Permisos al Rol</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoPermiso" CausesValidation="false" OnClick="nuevoPermiso_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-3 col-sm-3 col-md-3">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Editar</span>
              <span class="info-box-number">Permisos al Rol</span>
            </div>
            <asp:LinkButton ID="btEditar" runat="server" type="button" CausesValidation="false" OnClick="btEditar_Click">
              <span class="info-box-icon bg-warning elevation-1"><i class="fa fa-edit"></i></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content">
    <div class="container-fluid">

      <div class="row">
        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearRol">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO ROL</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <asp:LinkButton runat="server" ID="cerrarRol" type="button" class="btn btn-tool btn-sm" data-widget="remove"
                  data-toggle="tooltip" title="Remove" OnClick="cerrarRol_Click">
                  <i class="fa fa-times"></i>
                </asp:LinkButton>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" CssClass="control-label">ROL</asp:Label>
                  <input runat="server" id="TxtRol" class="form-control" type="text" onkeypress="return letras(event)" minlength="4" placeholder="nombre del rol" maxlength="25" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validar_rol" runat="server" ControlToValidate="TxtRol"
                    CssClass="text-danger" ErrorMessage="* El nombre del Rol es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ValidationGroup="validar_rol" ID="Save" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="Save_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditarRol">
            <div class="card-header">
              <h3 class="card-title">MODIFICAR INFORMACIÓN</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove"
                  data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="TxtmodificarRol" CssClass="control-label">ROL</asp:Label>
                  <input runat="server" id="TxtmodificarRol" class="form-control" type="text" onkeypress="return letras(event)" minlength="4" placeholder="nombre del rol" maxlength="25" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validar_mrol" runat="server" ControlToValidate="TxtmodificarRol"
                    CssClass="text-danger" ErrorMessage="* El nombre del Rol es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ValidationGroup="validar_mrol" ID="editRol" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editRol_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearPermiso">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO PERMISO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <asp:LinkButton runat="server" ID="cerrarPermiso" type="button" class="btn btn-tool btn-sm" data-widget="remove"
                  data-toggle="tooltip" title="Remove" OnClick="cerrarPermiso_Click">
                  <i class="fa fa-times"></i>
                </asp:LinkButton>
              </div>
            </div>
            <div class="card-body">
              <asp:UpdatePanel runat="server" ID="selectMenu">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="DropRol" CssClass="control-label">ROL</asp:Label>
                      <asp:DropDownList runat="server" ID="DropRol" CssClass="form-control" OnSelectedIndexChanged="DropRol_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator runat="server" ControlToValidate="DropRol" ValidationGroup="validarPermiso"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Rol" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="checkboxOneInput" CssClass="control-label">PANTALLA</asp:Label>
                      <div class="checkbox checkbox-primary" style="border: groove;">
                        <asp:CheckBoxList runat="server" CssClass="styled" ID="checkboxOneInput" DataTextField="menu" TextAlign="Right" CellPadding="16" CellSpacing="4"
                          DataValueField="numero" CausesValidation="false" RepeatDirection="Horizontal" RepeatColumns="5" Font-Size="Small">
                        </asp:CheckBoxList>
                      </div>
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="checkboxTwoInput" CssClass="control-label">BOTÓN</asp:Label>
                  <div class="checkbox checkbox-primary" style="border: groove;">
                    <asp:CheckBoxList runat="server" CssClass="styled" ID="checkboxTwoInput" DataTextField="boton" TextAlign="Right" CellPadding="20" CellSpacing="4"
                      DataValueField="numero" CausesValidation="false" RepeatDirection="Horizontal" RepeatColumns="10" Font-Size="Small">
                    </asp:CheckBoxList>
                  </div>
                </div>
              </div>
            </div>
            <div class="card-footer">
              <asp:LinkButton runat="server" ValidationGroup="validarPermiso" ID="savePermiso" type="button"
                class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="savePermiso_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
        <div class="col-md-12">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditarPermiso">
            <div class="card-header">
              <h3 class="card-title">MODIFICAR INFORMACIÓN</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove"
                  data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="DropEditarPermisoRol" CssClass="control-label">ROL</asp:Label>
                  <asp:DropDownList runat="server" ID="DropEditarPermisoRol" CssClass="form-control" OnSelectedIndexChanged="DropEditarPermisoRol_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="DropEditarPermisoRol" ValidationGroup="validarEditarPermiso"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Rol" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="DropEditarPermisoMenu" CssClass="control-label">MENÚ</asp:Label>
                  <asp:DropDownList runat="server" ID="DropEditarPermisoMenu" CssClass="form-control" OnSelectedIndexChanged="DropEditarPermisoMenu_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator runat="server" ControlToValidate="DropEditarPermisoMenu" ValidationGroup="validarEditarPermiso"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Menu" />
                </div>
              </div>
              <asp:UpdatePanel runat="server" ID="pintarCheckBoxBton">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="checkboxEditarPermisoBoton" CssClass="control-label">BOTÓN</asp:Label>
                      <div class="checkbox checkbox-primary" style="border: groove;">
                        <asp:CheckBoxList runat="server" CssClass="styled" ID="checkboxEditarPermisoBoton" DataTextField="boton" TextAlign="Right" CellPadding="20" CellSpacing="4"
                          DataValueField="numero" CausesValidation="false" RepeatDirection="Horizontal" RepeatColumns="10" Font-Size="Small">
                        </asp:CheckBoxList>
                      </div>
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ValidationGroup="validarEditarPermiso" ID="editarPermiso" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editarPermiso_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12" runat="server">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title"><span class="info-box-number">MOSTRAR INFORMACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <div class="col-md-12">
                <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging" PageSize="1"
                  CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowDataBound="gvListadoInfo_RowDataBound">
                  <Columns>
                    <asp:BoundField DataField="rol" HeaderText="NOMBRE DEL ROL" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                    <asp:TemplateField HeaderText="PANTALLA DEL ROL" HeaderStyle-Font-Size="Medium">
                      <ItemTemplate>
                        <asp:GridView ID="gvListSub" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gvListSub_RowDataBound"
                          ShowHeader="false" BorderStyle="None">
                          <Columns>
                            <asp:BoundField DataField="pantalla" HeaderText="PANTALLA" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                            <asp:TemplateField>
                              <ItemTemplate>
                                <asp:GridView ID="gvListSubSub" runat="server" AutoGenerateColumns="False" DataKeyNames="numero"
                                  BorderStyle="None">
                                  <Columns>
                                    <asp:BoundField DataField="boton" HeaderText="ACCIÓN" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                                  </Columns>
                                </asp:GridView>
                              </ItemTemplate>
                            </asp:TemplateField>
                          </Columns>
                        </asp:GridView>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
