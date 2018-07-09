<%@ Page Title="C1.1: DESARROLLO DEL CAPITAL HUMANO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexC1_1.aspx.cs" Inherits="PATOnline.Views.C1.IndexC1_1" %>

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
            <li class="breadcrumb-item active">C1.1</li>
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

  <section class="content" runat="server" id="crearC11New">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">CREAR</span>
              <span class="info-box-number">C1.1</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoC11" CausesValidation="false" OnClick="nuevoC11_Click">
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
        <div class="col-md-12">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearC11">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO C1.1</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="txtCrearCodigo" CssClass="control-label"><span style="color:red">*</span> CÓDIGO</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearCodigo" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="dropCrearCategoria" CssClass="control-label"><span style="color:red">*</span> CATEGORÍA</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearCategoria" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearCategoria"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una categoria" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="dropCrearActividad" CssClass="control-label"><span style="color:red">*</span> NOMBRE DE LA ACTIVIDAD</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearActividad" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearActividad"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una actividad" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPresupuesto" CssClass="control-label"><span style="color:red">*</span> PRESUPUESTO</asp:Label>
                  <input runat="server" id="txtCrearPresupuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="txtCrearPresupuesto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un presupuesto" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearResultado" CssClass="control-label"><span style="color:red">*</span> RESULTADOS ESPERADOS</asp:Label>
                  <textarea runat="server" id="txtCrearResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un resultado" maxlength="125" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="txtCrearResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un resultado" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearRegistro" CssClass="control-label"><span style="color:red">*</span> REGISTRO</asp:Label>
                  <textarea runat="server" id="txtCrearRegistro" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un registro" maxlength="125" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="txtCrearRegistro"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un registro" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <div class="row" style="text-align: center;">
                    <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                      <h5>
                        <asp:Label runat="server" ForeColor="Black" Text="FECHA INICIO"></asp:Label></h5>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearDiaInicio" CssClass="control-label"><span style="color:red">*</span> DÍA</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearDiaInicio" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearDiaInicio"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearMesInicio" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearMesInicio" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearMesInicio"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
                    </div>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="row" style="text-align: center;">
                    <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                      <h5>
                        <asp:Label runat="server" ForeColor="Black" Text="FECHA FINALIZA"></asp:Label></h5>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearDiaFin" CssClass="control-label"><span style="color:red">*</span> DÍA</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearDiaFin" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearDiaFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearMesFin" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearMesFin" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearMesFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
                    </div>
                  </div>
                </div>
              </div>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row" style="text-align: center;">
                        <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                          <h5>
                            <asp:Label runat="server" ForeColor="Black" Text="UBICACION"></asp:Label></h5>
                        </div>
                      </div>
                      <div class="row">
                        <div class="col-md-3">
                          <asp:Label runat="server" AssociatedControlID="dropCrearPais" CssClass="control-label"><span style="color:red">*</span> PAÍS</asp:Label>
                          <asp:DropDownList runat="server" ID="dropCrearPais" CssClass="form-control" OnSelectedIndexChanged="dropCrearPais_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearPais"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
                        </div>
                        <div class="col-md-4">
                          <asp:Label runat="server" AssociatedControlID="dropCrearDepartamento" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO</asp:Label>
                          <asp:DropDownList runat="server" ID="dropCrearDepartamento" CssClass="form-control"></asp:DropDownList>
                          <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="dropCrearDepartamento"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
                        </div>
                        <div class="col-md-5">
                          <asp:Label runat="server" AssociatedControlID="txtCrearLugar" CssClass="control-label"><span style="color:red">*</span> LUGAR</asp:Label>
                          <input runat="server" id="txtCrearLugar" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un lugar" maxlength="125" autofocus required />
                          <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="txtCrearLugar"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un lugar" />
                        </div>
                      </div>
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearDescripcion" CssClass="control-label"><span style="color:red">*</span> DESCRIPCIÓN</asp:Label>
                  <textarea runat="server" style="height: 125px;" id="txtCrearDescripcion" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="1500" autofocus></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC11" runat="server" ControlToValidate="txtCrearDescripcion"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un descripcion" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearC11" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearC11_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearC11" ID="crearC11" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearC11_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditC11">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR C1.1</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-2">
                  <asp:Label runat="server" ID="idEdit"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtEditCodigo" CssClass="control-label"><span style="color:red">*</span> CÓDIGO</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditCodigo" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="dropEditCategoria" CssClass="control-label"><span style="color:red">*</span> CATEGORÍA</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditCategoria" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditCategoria"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una categoria" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="dropEditActividad" CssClass="control-label"><span style="color:red">*</span> NOMBRE DE LA ACTIVIDAD</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditActividad" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditActividad"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una actividad" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="txtEditPresupuesto" CssClass="control-label"><span style="color:red">*</span> PRESUPUESTO</asp:Label>
                  <input runat="server" id="txtEditPresupuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="txtEditPresupuesto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un presupuesto" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditResultado" CssClass="control-label"><span style="color:red">*</span> RESULTADOS ESPERADOS</asp:Label>
                  <textarea runat="server" id="txtEditResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un resultado" maxlength="125" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="txtEditResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un resultado" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditRegistro" CssClass="control-label"><span style="color:red">*</span> REGISTRO</asp:Label>
                  <textarea runat="server" id="txtEditRegistro" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un registro" maxlength="125" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="txtEditRegistro"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un registro" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <div class="row" style="text-align: center;">
                    <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                      <h5>
                        <asp:Label runat="server" ForeColor="Black" Text="FECHA INICIO"></asp:Label></h5>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropEditDiaInicio" CssClass="control-label"><span style="color:red">*</span> DÍA</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditDiaInicio" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditDiaInicio"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropEditMesInicio" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditMesInicio" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditMesInicio"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
                    </div>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="row" style="text-align: center;">
                    <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                      <h5>
                        <asp:Label runat="server" ForeColor="Black" Text="FECHA FINALIZA"></asp:Label></h5>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropEditDiaFin" CssClass="control-label"><span style="color:red">*</span> DÍA</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditDiaFin" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditDiaFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropEditMesFin" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditMesFin" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditMesFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
                    </div>
                  </div>
                </div>
              </div>
              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12">
                      <div class="row" style="text-align: center;">
                        <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                          <h5>
                            <asp:Label runat="server" ForeColor="Black" Text="UBICACION"></asp:Label></h5>
                        </div>
                      </div>
                      <div class="row">
                        <div class="col-md-3">
                          <asp:Label runat="server" AssociatedControlID="dropEditPais" CssClass="control-label"><span style="color:red">*</span> PAÍS</asp:Label>
                          <asp:DropDownList runat="server" ID="dropEditPais" CssClass="form-control" OnSelectedIndexChanged="dropEditPais_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditPais"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
                        </div>
                        <div class="col-md-4">
                          <asp:Label runat="server" AssociatedControlID="dropEditDepartamento" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO</asp:Label>
                          <asp:DropDownList runat="server" ID="dropEditDepartamento" CssClass="form-control"></asp:DropDownList>
                          <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="dropEditDepartamento"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
                        </div>
                        <div class="col-md-5">
                          <asp:Label runat="server" AssociatedControlID="txtEditLugar" CssClass="control-label"><span style="color:red">*</span> LUGAR</asp:Label>
                          <input runat="server" id="txtEditLugar" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un lugar" maxlength="125" autofocus required />
                          <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="txtEditLugar"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un lugar" />
                        </div>
                      </div>
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditDescripcion" CssClass="control-label"><span style="color:red">*</span> DESCRIPCIÓN</asp:Label>
                  <textarea runat="server" style="height: 125px;" id="txtEditDescripcion" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="1500" autofocus></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC11" runat="server" ControlToValidate="txtEditDescripcion"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un descripcion" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditC11" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditC11_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditC11" ID="editC11" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editC11_Click">
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
              <asp:LinkButton ID="btObservacionSinRechazoUpdate" runat="server" type="button" class="btn btn-primary btn-outline-primary btn-lg float-right" OnClick="btObservacionSinRechazoUpdate_Click">
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
            <div class="card-body">
              <div class="row" style="overflow-x: auto;">
                <div class="col-md-12">
                  <div class="row">
                    <div class="col-md-12">
                      <table class="table table-bordered dataTable">
                        <tr>
                          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>CÓDIGO</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>CATEGORÍA</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>NOMBRE DE LA ACTIVIDAD</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>DESCRIPCIÓN</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>RESULTADOS ESPERADOS</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>REGISTRO</b></th>
                          <th style="text-align: center; font-size: 10px;" colspan="4"><b>FECHA</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="2" colspan="3"><b>UBICACIÓN</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>PRESUPUESTO</b></th>
                        </tr>
                        <tr>
                          <td style="text-align: center; font-size: 10px;" colspan="2"><b>INICIA</b></td>
                          <td style="text-align: center; font-size: 10px;" colspan="2"><b>FINALIZA</b></td>
                        </tr>
                        <tr>
                          <td style="text-align: center; font-size: 9px;"><b>DÍA</b></td>
                          <td style="text-align: center; font-size: 9px;"><b>MES</b></td>
                          <td style="text-align: center; font-size: 9px;"><b>DÍA</b></td>
                          <td style="text-align: center; font-size: 9px;"><b>MES</b></td>
                          <td style="text-align: center; font-size: 10px;"><b>DEPARTAMENTO</b></td>
                          <td style="text-align: center; font-size: 10px;"><b>PAÍS</b></td>
                          <td style="text-align: center; font-size: 10px;"><b>LUGAR</b></td>
                        </tr>
                      </table>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-md-12">
                      <asp:GridView ID="gridFADN" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridFADN_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridFADN_RowCommand" ShowHeader="false">
                        <Columns>
                          <asp:BoundField DataField="numero" />
                          <asp:BoundField DataField="codigo" ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="categoria" ItemStyle-Width="" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="actividad" ItemStyle-Width="" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="descripcion" ItemStyle-Width="" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="resultado" ItemStyle-Width="" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="registro" ItemStyle-Width="" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="inicio_dia" ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="inicio_mes" ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="fin_dia" ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="fin_mes" ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="departamento" ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="pais" ItemStyle-Width="" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="lugar" ItemStyle-Width="" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="presupuesto" ItemStyle-Width="15px" ItemStyle-HorizontalAlign="Center" SortExpression="presupuesto" DataFormatString="{0:c}" ItemStyle-Font-Size="Small" />
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
                      <asp:GridView ID="gridFADNTotal" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridFADNTotal_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                        <Columns>
                          <asp:TemplateField>
                            <ItemStyle Width="90%" />
                            <ItemTemplate>
                              <asp:Label runat="server" Text="TOTALES" ForeColor="Black" CssClass="text-center"></asp:Label></b>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="14%" />
                            <ItemTemplate>
                              <p style="text-align: center; color: black;"><b>Q<asp:Label ID="lblPresupuesto" runat="server" Text='<%# Eval("total") %>'></asp:Label></b></p>
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

