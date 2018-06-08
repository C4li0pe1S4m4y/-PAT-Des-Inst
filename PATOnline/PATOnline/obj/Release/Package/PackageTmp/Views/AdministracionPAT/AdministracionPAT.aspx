<%@ Page Title="ADMINISTRACIÓN DEL PAT" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministracionPAT.aspx.cs" Inherits="PATOnline.Views.AdministracionPAT.AdministracionPAT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item">Dashboard</li>
            <li class="breadcrumb-item active">Administración del PAT</li>
          </ol>
        </div>
      </div>
    </div>
  </div>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-2">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Brecha</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaBrecha" CausesValidation="false" OnClick="nuevaBrecha_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-2">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Cargo</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoCargo" CausesValidation="false" OnClick="nuevoCargo_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-3">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Categoría</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaCategoria" CausesValidation="false" OnClick="nuevaCategoria_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-2">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Nivel</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoNivel" CausesValidation="false" OnClick="nuevoNivel_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-3">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Tipo de Persona</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoTipoPersona" CausesValidation="false" OnClick="nuevoTipoPersona_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearBrecha">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVA BRECHA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearBrecha" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearBrecha" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de brecha" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearBrecha" runat="server" ControlToValidate="txtCrearBrecha"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearBrecha" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearBrecha_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearBrecha" ID="crearBrecha" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearBrecha_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearCargo">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO CARGO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearCargo" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearCargo" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de cargo" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearCargo" runat="server" ControlToValidate="txtCrearCargo"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearCargo" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearCargo_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearCargo" ID="crearCargo" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearCargo_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearCategoria">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVA CATEGORÍA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearCategoria" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearCategoria" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de categoría" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearCategoria" runat="server" ControlToValidate="txtCrearCategoria"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearCategoria" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearCategoria_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearCategoria" ID="crearCategoria" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearCategoria_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearNivel">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO NIVEL</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="DropNivel" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="DropNivel" CssClass="form-control" OnSelectedIndexChanged="DropNivel_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearNivel" runat="server" ControlToValidate="DropNivel"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNivel" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNivel" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre del nivel" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearNivel" runat="server" ControlToValidate="txtCrearNivel"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>

              <div class="card-footer">
                <asp:LinkButton runat="server" ID="cancelCrearNivel" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearNivel_Click">
                <span class="fa fa-close"></span>
                </asp:LinkButton>
                <asp:LinkButton runat="server" ValidationGroup="validarCrearNivel" ID="crearNivel" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearNivel_Click">
                <span class="fa fa-save"></span>
                </asp:LinkButton>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearTipoPersona">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO TIPO DE PERSONA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearTipoPersona" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearTipoPersona" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de tipo de persona" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearTipoPersona" runat="server" ControlToValidate="txtCrearTipoPersona"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearTipoPersona" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearTipoPersona_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearTipoPersona" ID="crearTipoPersona" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearTipoPersona_Click">
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
        <div class="col-md-4">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditarBrecha">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR BRECHA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idBrecha"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtEditBrecha" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtEditBrecha" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de brecha" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditBrecha" runat="server" ControlToValidate="txtEditBrecha"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditBrecha" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditBrecha_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditBrecha" ID="editBrecha" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editBrecha_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditarCargo">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR CARGO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idCargo"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtEditCargo" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtEditCargo" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de cargo" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditCargo" runat="server" ControlToValidate="txtEditCargo"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditCargo" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditCargo_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditCargo" ID="editCargo" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editCargo_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditarCategoria">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR CATEGORÍA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idCategoria"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtEditCategoria" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtEditCategoria" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de categoria" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditCategoria" runat="server" ControlToValidate="txtEditCategoria"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditCategoria" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditCategoria_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditCategoria" ID="editCategoria" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editCategoria_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditarNivel">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR NIVEL</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idNivel"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="DropNivelEdit" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="DropNivelEdit" CssClass="form-control" OnSelectedIndexChanged="DropNivelEdit_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearNivel" runat="server" ControlToValidate="DropNivelEdit"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditNivel" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNivel" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre del nivel" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearNivel" runat="server" ControlToValidate="txtEditNivel"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditNivel" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditNivel_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearNivel" ID="editNivel" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editNivel_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditTipoPersona">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR TIPO DE PERSONA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idTipoPersona"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtEditTipoPersona" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtEditTipoPersona" class="form-control" type="text" onkeypress="return letrasynumeros(event)" minlength="4" placeholder="nombre de tipo de persona" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditTipoPersona" runat="server" ControlToValidate="txtEditTipoPersona"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditTipoPersona" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditTipoPersona_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditTipoPersona" ID="editTipoPersona" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editTipoPersona_Click">
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
        <div class="col-md-6">
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
                <asp:GridView ID="gvListBrecha" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListBrecha_PageIndexChanging" PageSize="5"
                  CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gvListBrecha_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="brecha" HeaderText="NOMBRE DE LA BRECHA" ItemStyle-Width="100%" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                    <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                      <ItemTemplate>
                        <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                          CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                        </asp:LinkButton>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </div>
            </div>
          </div>
        </div>

        <div class="col-md-6">
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
                <asp:GridView ID="gvListCargo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListCargo_PageIndexChanging" PageSize="5"
                  CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gvListCargo_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="cargo" HeaderText="NOMBRE DEL CARGO" ItemStyle-Width="100%" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                    <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                      <ItemTemplate>
                        <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                          CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                        </asp:LinkButton>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
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
                <asp:GridView ID="gvListCategoria" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListCategoria_PageIndexChanging" PageSize="5"
                  CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gvListCategoria_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="categoria" HeaderText="NOMBRE DE LA CATEGORIA" ItemStyle-Width="100%" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                    <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                      <ItemTemplate>
                        <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                          CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                        </asp:LinkButton>
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </div>
            </div>
          </div>
        </div>
        <div class="col-md-6" runat="server" id="mostrarGridNivel">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title"><span class="info-box-number">MOSTRAR INFORMACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <asp:UpdatePanel runat="server" ID="nivelUpdatePanel">
              <ContentTemplate>
                <div class="card-body" style="overflow-x: auto;">
                  <div class="col-md-12">
                    <asp:GridView ID="gvListNivel" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListNivel_PageIndexChanging" PageSize="5"
                      CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gvListNivel_RowCommand">
                      <Columns>
                        <asp:BoundField DataField="nivel" HeaderText="NOMBRE DEL NIVEL" ItemStyle-Width="100%" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                        <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                          <ItemTemplate>
                            <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                              CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                            </asp:LinkButton>
                          </ItemTemplate>
                        </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
                  </div>
                </div>
              </ContentTemplate>
            </asp:UpdatePanel>
          </div>
        </div>

        <div class="col-md-6">
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
                <asp:GridView ID="gvListTipoPersonal" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListTipoPersonal_PageIndexChanging" PageSize="5"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gvListTipoPersonal_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="tipo_personal" HeaderText="NOMBRE DEL TIPO PERSONA" ItemStyle-Width="100%" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                    <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                      <ItemTemplate>
                        <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                          CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                        </asp:LinkButton>
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
