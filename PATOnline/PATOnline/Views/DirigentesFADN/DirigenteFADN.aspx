<%@ Page Title="DIRIGENCIA DEPORTIVA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DirigenteFADN.aspx.cs" Inherits="PATOnline.Views.DirigentesFADN.DirigenteFADN" %>

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
            <li class="breadcrumb-item active">Dirigencia Deportiva</li>
          </ol>
        </div>
      </div>
    </div>
  </div>

  <section class="content" runat="server">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <asp:LinkButton runat="server" ID="btPDF" CausesValidation="false">
            <span class="btn btn-block btn-info btn-lg"><i class="fa  fa-file-pdf-o"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-6">
          <div class="info-box">
            <asp:LinkButton runat="server" ID="btExcel" CausesValidation="false">
            <span class="btn btn-block btn-info btn-lg"><i class="fa  fa-file-excel-o"></i></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content" runat="server" id="crearAsambleaNew">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Asamblea</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaAsamblea" CausesValidation="false" OnClick="nuevaAsamblea_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-4">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Órgano Disciplinario</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoOrgano" CausesValidation="false" OnClick="nuevoOrgano_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-4">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Técnico Deportivo</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoTecnico" CausesValidation="false" OnClick="nuevoTecnico_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Técnico Administrativo</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaAdministracion" CausesValidation="false" OnClick="nuevaAdministracion_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Dirigente Internacional</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoDirigente" CausesValidation="false" OnClick="nuevoDirigente_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearAsamblea">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVA ASAMBLEA DE FADN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearDepartamentoAsamblea" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearDepartamentoAsamblea" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearAsamblea" runat="server" ControlToValidate="dropCrearDepartamentoAsamblea"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Departamento" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre1Asamblea" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre1Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearAsamblea" runat="server" ControlToValidate="txtCrearNombre1Asamblea"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre2Asamblea" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre2Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido1Asamblea" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido1Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearAsamblea" runat="server" ControlToValidate="txtCrearApellido1Asamblea"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido2Asamblea" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido2Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearAsamblea" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearAsamblea_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearAsamblea" ID="crearAsamblea" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearAsamblea_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarCrearOrgano">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO ÓRGANO DISCIPLINARIO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearCargoOrgano" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearCargoOrgano" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearOrgano" runat="server" ControlToValidate="dropCrearCargoOrgano"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre1Organo" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre1Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearOrgano" runat="server" ControlToValidate="txtCrearNombre1Organo"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre2Organo" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre2Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido1Organo" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido1Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearOrgano" runat="server" ControlToValidate="txtCrearApellido1Organo"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido2Organo" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido2Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearOrgano" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearOrgano_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearOrgano" ID="crearOrgano" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearOrgano_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarCrearComision">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO TÉCNICO DEPORTIVA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearCargoComision" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearCargoComision" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearComision" runat="server" ControlToValidate="dropCrearCargoComision"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre1Comision" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre1Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearComision" runat="server" ControlToValidate="txtCrearNombre1Comision"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre2Comision" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre2Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido1Comision" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido1Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearComision" runat="server" ControlToValidate="txtCrearApellido1Comision"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido2Comision" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido2Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearComision" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearComision_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearComision" ID="crearComision" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearComision_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarCrearPersonal">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO TÉCNICO ADMINISTRATIVO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearCargoPersonal" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearCargoPersonal" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearPersonal" runat="server" ControlToValidate="dropCrearCargoPersonal"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre1Personal" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre1Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearPersonal" runat="server" ControlToValidate="txtCrearNombre1Personal"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre2Personal" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre2Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido1Personal" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido1Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearPersonal" runat="server" ControlToValidate="txtCrearApellido1Personal"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido2Personal" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido2Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearPersonal" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearPersonal_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearPersonal" ID="crearPersonal" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearPersonal_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarCrearDirigente">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO DIRIGENTE INTERNACIONAL</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearCargoDirigente" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearCargoDirigente" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearDirigente" runat="server" ControlToValidate="dropCrearCargoDirigente"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre1Dirigente" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre1Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearDirigente" runat="server" ControlToValidate="txtCrearNombre1Dirigente"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombre2Dirigente" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombre2Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido1Dirigente" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido1Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearDirigente" runat="server" ControlToValidate="txtCrearApellido1Dirigente"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearApellido2Dirigente" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearApellido2Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearDirigente" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearDirigente_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearDirigente" ID="crearDirigente" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearDirigente_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarEditAsamblea">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR ASAMBLEA DE FADN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditAsamblea"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditDepartamentoAsamblea" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditDepartamentoAsamblea" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditAsamblea" runat="server" ControlToValidate="dropEditDepartamentoAsamblea"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Departamento" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre1Asamblea" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre1Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditAsamblea" runat="server" ControlToValidate="txtEditNombre1Asamblea"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre2Asamblea" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre2Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido1Asamblea" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido1Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditAsamblea" runat="server" ControlToValidate="txtEditApellido1Asamblea"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido2Asamblea" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido2Asamblea" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditAsamblea" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditAsamblea_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditAsamblea" ID="editAsamblea" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editAsamblea_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarEditOrgano">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR ÓRGANO DISCIPLINARIO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditDisciplina"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditCargoOrgano" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditCargoOrgano" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditOrgano" runat="server" ControlToValidate="dropEditCargoOrgano"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre1Organo" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre1Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditOrgano" runat="server" ControlToValidate="txtEditNombre1Organo"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre2Organo" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre2Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido1Organo" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido1Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditOrgano" runat="server" ControlToValidate="txtEditApellido1Organo"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido2Organo" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido2Organo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditOrgano" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditOrgano_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditOrgano" ID="editOrgano" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editOrgano_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarEditComision">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR TÉCNICO DEPORTIVA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditComision"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditCargoComision" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditCargoComision" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditComision" runat="server" ControlToValidate="dropEditCargoComision"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre1Comision" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre1Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditComision" runat="server" ControlToValidate="txtEditNombre1Comision"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre2Comision" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre2Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido1Comision" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido1Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditComision" runat="server" ControlToValidate="txtEditApellido1Comision"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido2Comision" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido2Comision" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditComision" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditComision_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditComision" ID="editComision" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editComision_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarEditPersonal">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR TÉCNICO ADMINISTRATIVO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditPersonal"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditCargoPersonal" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditCargoPersonal" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditPersonal" runat="server" ControlToValidate="dropEditCargoPersonal"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre1Personal" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre1Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditPersonal" runat="server" ControlToValidate="txtEditNombre1Personal"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre2Personal" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre2Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido1Personal" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido1Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditPersonal" runat="server" ControlToValidate="txtEditApellido1Personal"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido2Personal" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido2Personal" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditPersonal" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditPersonal_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditPersonal" ID="editPersonal" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editPersonal_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>

          <div class="card card-outline card-info" runat="server" id="mostrarEditDirigente">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR DIRIGENTE INTERNACIONAL</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditDirigente"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditCargoDirigente" CssClass="control-label"><span style="color:red">*</span> CARGO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditCargoDirigente" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditDirigente" runat="server" ControlToValidate="dropEditCargoDirigente"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Cargo" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre1Dirigente" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre1Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditDirigente" runat="server" ControlToValidate="txtEditNombre1Dirigente"
                    CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditNombre2Dirigente" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtEditNombre2Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="25" autofocus required />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido1Dirigente" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido1Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="25" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditDirigente" runat="server" ControlToValidate="txtEditApellido1Dirigente"
                    CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditApellido2Dirigente" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtEditApellido2Dirigente" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="25" autofocus required />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditDirigente" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditDirigente_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditDirigente" ID="editDirigente" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editDirigente_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content" runat="server" id="crearObservacionRechazo">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">OBSERVACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idIntroObservacionRechazo"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacion" CssClass="control-label"><span style="color:red">*</span> OBSERVACIÓN</asp:Label>
                  <textarea runat="server" id="txtCrearObservacion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="observación" maxlength="1000" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validarObservacion" ControlToValidate="txtCrearObservacion"
                    CssClass="text-danger" ErrorMessage="* La observación es obligatoria" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelarObservacionRechazo" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelarObservacionRechazo_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarObservacion" ID="guardarObservacionRechazo" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="guardarObservacionRechazo_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
              <asp:LinkButton ID="btcrearObservacionRechazo" runat="server" type="button" class="btn btn-danger btn-outline-danger btn-lg float-right" OnClick="btcrearObservacionRechazo_Click"
                ValidationGroup="validarObservacion">
                <span class="fa fa-thumbs-down"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content" runat="server" id="crearObservacionSinRechazo">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">OBSERVACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idIntroObservacionSinRechazo"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacionSinRechazo" CssClass="control-label"><span style="color:red">*</span> OBSERVACIÓN</asp:Label>
                  <textarea runat="server" id="txtCrearObservacionSinRechazo" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="observación" maxlength="1000" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validarObservacionS" ControlToValidate="txtCrearObservacionSinRechazo"
                    CssClass="text-danger" ErrorMessage="* La observación es obligatoria" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelObservacionSinRechazo" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelObservacionSinRechazo_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton ID="btObservacionSinRechazo" runat="server" type="button" class="btn btn-primary btn-outline-primary btn-lg float-right" OnClick="btObservacionSinRechazo_Click"
                ValidationGroup="validarObservacionS">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
              <asp:LinkButton ID="btObservacionSinRechazoUpdate" runat="server" type="button" class="btn btn-primary btn-outline-primary btn-lg float-right" OnClick="btObservacionSinRechazoUpdate_Click"
                ValidationGroup="validarObservacionS">
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
        <div class="col-md-12">
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
              <div class="row">
                <div class="col-md-6">
                  <h4>ASAMBLEA DE FADN</h4>
                  <asp:GridView ID="gridAsamblea" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridAsamblea_RowDataBound"
                    CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridAsamblea_RowCommand">
                    <Columns>
                      <asp:BoundField DataField="numero" ShowHeader="false" />
                      <asp:BoundField DataField="departamento" HeaderText="REPRESENTANTE DE:" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                      <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Center" />
                      <asp:TemplateField HeaderText="OPCIONES">
                        <ItemTemplate>
                          <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                            CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                          </asp:LinkButton>
                          <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                            CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-eye"></span>
                          </asp:LinkButton>
                          <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-block btn-danger btn-sm"
                            CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                              <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-trash-o"></span>
                          </asp:LinkButton>
                          <asp:LinkButton ID="btObservacion" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                            CommandName="Observacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-comment"></span>
                          </asp:LinkButton>
                          <asp:LinkButton ID="btAprobar" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                            CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-thumbs-up"></span>
                          </asp:LinkButton>
                          <asp:LinkButton ID="btEnviar" runat="server" type="button" class="btn btn-block btn-info btn-sm" CausesValidation="false"
                            CommandName="Enviar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-send"></span>
                          </asp:LinkButton>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </div>

                <div class="col-md-6">
                  <div class="row">
                    <div class="col-md-12">
                      <h4>COMITÉ EJECUTIVO DE FADN</h4>
                      <asp:GridView ID="gridCE" runat="server" AutoGenerateColumns="False" DataKeyNames="tipo" OnRowDataBound="gridCE_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridCE_RowCommand">
                        <Columns>
                          <asp:BoundField DataField="tipo" ShowHeader="false" />
                          <asp:BoundField DataField="tipo" HeaderText="CARGO" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                      </asp:GridView>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <h4>ÓRGANO DISCIPLINARIO</h4>
                      <asp:GridView ID="gridDisciplina" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridDisciplina_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridDisciplina_RowCommand">
                        <Columns>
                          <asp:BoundField DataField="numero" ShowHeader="false" />
                          <asp:BoundField DataField="cargo" HeaderText="CARGO" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Center" />
                          <asp:TemplateField HeaderText="OPCIONES">
                            <ItemTemplate>
                              <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-eye"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-block btn-danger btn-sm"
                                CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                  <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-trash-o"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btObservacion" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Observacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-comment"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btAprobar" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-thumbs-up"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEnviar" runat="server" type="button" class="btn btn-block btn-info btn-sm" CausesValidation="false"
                                CommandName="Enviar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-send"></span>
                              </asp:LinkButton>
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <h4>COMISIÓN TECNICO DEPORTIVA</h4>
                      <asp:GridView ID="gridComision" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridComision_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridComision_RowCommand">
                        <Columns>
                          <asp:BoundField DataField="numero" ShowHeader="false" />
                          <asp:BoundField DataField="cargo" HeaderText="CARGO" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Center" />
                          <asp:TemplateField HeaderText="OPCIONES">
                            <ItemTemplate>
                              <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-eye"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-block btn-danger btn-sm"
                                CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                  <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-trash-o"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btObservacion" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Observacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-comment"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btAprobar" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-thumbs-up"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEnviar" runat="server" type="button" class="btn btn-block btn-info btn-sm" CausesValidation="false"
                                CommandName="Enviar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-send"></span>
                              </asp:LinkButton>
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <h4>PERSONAL TENICO ADMINISTRATIVO</h4>
                      <asp:GridView ID="gridPersonal" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridPersonal_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridPersonal_RowCommand">
                        <Columns>
                          <asp:BoundField DataField="numero" ShowHeader="false" />
                          <asp:BoundField DataField="cargo" HeaderText="CARGO" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Center" />
                          <asp:TemplateField HeaderText="OPCIONES">
                            <ItemTemplate>
                              <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-eye"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-block btn-danger btn-sm"
                                CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                  <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-trash-o"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btObservacion" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Observacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-comment"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btAprobar" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-thumbs-up"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEnviar" runat="server" type="button" class="btn btn-block btn-info btn-sm" CausesValidation="false"
                                CommandName="Enviar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-send"></span>
                              </asp:LinkButton>
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <h4>DIRIGENTES INTERNACIONALES</h4>
                      <asp:GridView ID="gridDirigente" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridDirigente_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridDirigente_RowCommand">
                        <Columns>
                          <asp:BoundField DataField="numero" ShowHeader="false" />
                          <asp:BoundField DataField="cargo" HeaderText="CARGO" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="nombre" HeaderText="NOMBRE" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Center" />
                          <asp:TemplateField HeaderText="OPCIONES">
                            <ItemTemplate>
                              <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-eye"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-block btn-danger btn-sm"
                                CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                  <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-trash-o"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btObservacion" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Observacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-comment"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btAprobar" runat="server" type="button" class="btn btn-block btn-success btn-sm" CausesValidation="false"
                                CommandName="Aprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-thumbs-up"></span>
                              </asp:LinkButton>
                              <asp:LinkButton ID="btEnviar" runat="server" type="button" class="btn btn-block btn-info btn-sm" CausesValidation="false"
                                CommandName="Enviar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                        <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-send"></span>
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
        </div>
      </div>
    </div>
  </section>

  <section class="content" runat="server" id="mostrarObservacion">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">OBSERVACIONES REALIZADAS</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <h3 class="card-title" style="text-align: right;"><span class="info-box-number">Federación / Asociación</span></h3>
                  <asp:GridView ID="listObservacionesFADN" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    CssClass="table" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                    <Columns>
                      <asp:TemplateField ItemStyle-Width="8%" ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Fecha:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("fecha") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField ItemStyle-Width="25%" ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Observación realizada por:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Descripción:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("observacion") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>

              <div class="row">
                <div class="col-md-12">
                  <h3 class="card-title" style="text-align: right;"><span class="info-box-number">Acompañamiento</span></h3>
                  <asp:GridView ID="listObservacionesAcompaniamiento" runat="server" AutoGenerateColumns="False"
                    CssClass="table" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                    <Columns>
                      <asp:TemplateField ItemStyle-Width="8%" ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Fecha:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("fecha") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField ItemStyle-Width="25%" ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Observación realizada por:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Descripción:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("observacion") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>

              <div class="row">
                <div class="col-md-12" style="overflow-x: auto;">
                  <h3 class="card-title" style="text-align: right;"><span class="info-box-number">Evaluador</span></h3>
                  <asp:GridView ID="listObservacionesEvaluacion" runat="server" AutoGenerateColumns="False"
                    CssClass="table" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                    <Columns>
                      <asp:TemplateField ItemStyle-Width="8%" ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Fecha:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("fecha") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField ItemStyle-Width="25%" ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Observación realizada por:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField ItemStyle-BorderColor="White">
                        <ItemTemplate>
                          <span class="info-box-number">Descripción:</span><p>
                            <asp:Label runat="server" Text='<%# Eval("observacion") %>'></asp:Label>
                          </p>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelMostrarObservacion" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelMostrarObservacion_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
