<%@ Page Title="C3.1 SISTEMA COMPETITIVO NACIONAL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexC3_1.aspx.cs" Inherits="PATOnline.Views.C3.IndexC3_1" %>

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
            <li class="breadcrumb-item active">C3.1</li>
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

  <section class="content" runat="server" id="crearC31New">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">CREAR</span>
              <span class="info-box-number">C3.1</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoC31" CausesValidation="false" OnClick="nuevoC31_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearC31">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO C3.1</span></h3>
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
                <div class="col-md-8">
                  <asp:Label runat="server" AssociatedControlID="txtCrearCompetencia" CssClass="control-label"><span style="color:red">*</span> NOMBRE DE LA COMPETENCIA</asp:Label>
                  <input runat="server" id="txtCrearCompetencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la competencia" maxlength="100" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="txtCrearCompetencia"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar el nombre de la competencia" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPresupuesto" CssClass="control-label"><span style="color:red">*</span> PRESUPUESTO</asp:Label>
                  <input runat="server" id="txtCrearPresupuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="txtCrearPresupuesto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un presupuesto" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="dropCrearClasificacion" CssClass="control-label"><span style="color:red">*</span> CLASIFICACIÓN</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearClasificacion" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearClasificacion"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una clasificacion" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="dropCrearNivel" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearNivel" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearNivel"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un nivel" />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="dropCrearCategoria" CssClass="control-label"><span style="color:red">*</span> CATEGORÍA</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearCategoria" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearCategoria"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una categoria" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtCrearFases" CssClass="control-label"><span style="color:red">*</span> FASE QUE CUBRE EL EVENTO</asp:Label>
                  <input runat="server" id="txtCrearFases" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir las fases" maxlength="200" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="txtCrearFases"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar las fases" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-5">
                  <asp:Label runat="server" AssociatedControlID="txtCrearResultado" CssClass="control-label"><span style="color:red">*</span> RESULTADOS ESPERADOS</asp:Label>
                  <textarea runat="server" id="txtCrearResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un resultado" maxlength="400" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="txtCrearResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un resultado" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="txtCrearEdades" CssClass="control-label"><span style="color:red">*</span> EDADES</asp:Label>
                  <input runat="server" id="txtCrearEdades" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir las fases" maxlength="75" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="txtCrearEdades"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar las edades" />
                </div>
                <div class="col-md-5">
                  <asp:Label runat="server" AssociatedControlID="txtCrearRegistro" CssClass="control-label"><span style="color:red">*</span> REGISTROS</asp:Label>
                  <textarea runat="server" id="txtCrearRegistro" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un registro" maxlength="125" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="txtCrearRegistro"
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
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearDiaInicio"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearMesInicio" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearMesInicio" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearMesInicio"
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
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearDiaFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearMesFin" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearMesFin" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearMesFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
                    </div>
                  </div>
                </div>
              </div>

              <div class="row">
                <div class="col-md-12">
                  <div class="row" style="text-align: center;">
                    <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                      <h5>
                        <asp:Label runat="server" ForeColor="Black" Text="UBICACION"></asp:Label></h5>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-5">
                      <asp:Label runat="server" AssociatedControlID="dropCrearDepartamento" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearDepartamento" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="dropCrearDepartamento"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
                    </div>
                    <div class="col-md-7">
                      <asp:Label runat="server" AssociatedControlID="txtCrearLugar" CssClass="control-label"><span style="color:red">*</span> LUGAR</asp:Label>
                      <input runat="server" id="txtCrearLugar" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un lugar" maxlength="125" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC31" runat="server" ControlToValidate="txtCrearLugar"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un lugar" />
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearC31" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearC31_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearC31" ID="crearC31" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearC31_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditC31">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR C3.1</span></h3>
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
                <div class="col-md-8">
                  <asp:Label runat="server" AssociatedControlID="txtEditCompetencia" CssClass="control-label"><span style="color:red">*</span> NOMBRE DE LA COMPETENCIA</asp:Label>
                  <input runat="server" id="txtEditCompetencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la competencia" maxlength="100" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="txtEditCompetencia"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar el nombre de la competencia" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="txtEditPresupuesto" CssClass="control-label"><span style="color:red">*</span> PRESUPUESTO</asp:Label>
                  <input runat="server" id="txtEditPresupuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="txtEditPresupuesto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un presupuesto" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="dropEditClasificacion" CssClass="control-label"><span style="color:red">*</span> CLASIFICACIÓN</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditClasificacion" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditClasificacion"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una clasificacion" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="dropEditNivel" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditNivel" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditNivel"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un nivel" />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="dropEditCategoria" CssClass="control-label"><span style="color:red">*</span> CATEGORÍA</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditCategoria" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditCategoria"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una categoria" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtEditFases" CssClass="control-label"><span style="color:red">*</span> FASE QUE CUBRE EL EVENTO</asp:Label>
                  <input runat="server" id="txtEditFases" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir las fases" maxlength="200" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="txtEditFases"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar las fases" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-5">
                  <asp:Label runat="server" AssociatedControlID="txtEditResultado" CssClass="control-label"><span style="color:red">*</span> RESULTADOS ESPERADOS</asp:Label>
                  <textarea runat="server" id="txtEditResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un resultado" maxlength="400" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="txtEditResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un resultado" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="txtEditEdades" CssClass="control-label"><span style="color:red">*</span> EDADES</asp:Label>
                  <input runat="server" id="txtEditEdades" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir las fases" maxlength="75" autofocus />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="txtEditEdades"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar las edades" />
                </div>
                <div class="col-md-5">
                  <asp:Label runat="server" AssociatedControlID="txtEditRegistro" CssClass="control-label"><span style="color:red">*</span> REGISTROS</asp:Label>
                  <textarea runat="server" id="txtEditRegistro" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un registro" maxlength="125" autofocus required></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="txtEditRegistro"
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
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditDiaInicio"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropEditMesInicio" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditMesInicio" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditMesInicio"
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
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditDiaFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropEditMesFin" CssClass="control-label"><span style="color:red">*</span> MES</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditMesFin" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditMesFin"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
                    </div>
                  </div>
                </div>
              </div>

              <div class="row">
                <div class="col-md-12">
                  <div class="row" style="text-align: center;">
                    <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                      <h5>
                        <asp:Label runat="server" ForeColor="Black" Text="UBICACION"></asp:Label></h5>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-5">
                      <asp:Label runat="server" AssociatedControlID="dropEditDepartamento" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditDepartamento" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="dropEditDepartamento"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
                    </div>
                    <div class="col-md-7">
                      <asp:Label runat="server" AssociatedControlID="txtEditLugar" CssClass="control-label"><span style="color:red">*</span> LUGAR</asp:Label>
                      <input runat="server" id="txtEditLugar" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir un lugar" maxlength="125" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC31" runat="server" ControlToValidate="txtEditLugar"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un lugar" />
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditC31" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditC31_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditC31" ID="editC31" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editC31_Click">
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
                          <th style="width: 83px; text-align: center; font-size: 10px;" rowspan="3"><b>NOMBRE DE LA COMPETENCIA</b></th>
                          <th style="width: 88px; text-align: center; font-size: 10px;" rowspan="3"><b>CLASIFICACIÓN</b></th>
                          <th style="width: 85px; text-align: center; font-size: 10px;" rowspan="3"><b>NIVEL</b></th>
                          <th style="width: 70px; text-align: center; font-size: 10px;" rowspan="3"><b>CATEGORÍA</b></th>
                          <th style="width: 60px; text-align: center; font-size: 10px;" rowspan="3"><b>EDADES</b></th>
                          <th style="width: 64px; text-align: center; font-size: 10px;" rowspan="3"><b>FASES QUE CUBRE EL EVENTO</b></th>
                          <th style="width: 139px; text-align: center; font-size: 10px;" rowspan="3"><b>RESULTADOS ESPERADOS</b></th>
                          <th style="width: 70px; text-align: center; font-size: 10px;" rowspan="3"><b>REGISTRO</b></th>
                          <th style="text-align: center; font-size: 10px;" colspan="4"><b>FECHA</b></th>
                          <th style="text-align: center; font-size: 10px;" rowspan="2" colspan="3"><b>UBICACIÓN</b></th>
                          <th style="width: 110px; text-align: center; font-size: 10px;" rowspan="3"><b>PRESUPUESTO</b></th>
                        </tr>
                        <tr>
                          <td style="text-align: center; font-size: 10px;" colspan="2"><b>INICIA</b></td>
                          <td style="text-align: center; font-size: 10px;" colspan="2"><b>FINALIZA</b></td>
                        </tr>
                        <tr>
                          <td style="width: 36px; text-align: center; font-size: 10px;"><b>DÍA</b></td>
                          <td style="width: 37px; text-align: center; font-size: 10px;"><b>MES</b></td>
                          <td style="width: 36px; text-align: center; font-size: 10px;"><b>DÍA</b></td>
                          <td style="width: 37px; text-align: center; font-size: 10px;"><b>MES</b></td>
                          <td style="width: 85px; text-align: center; font-size: 10px;"><b>DEPARTAMENTO</b></td>
                          <td style="width: 79px; text-align: center; font-size: 10px;"><b>LUGAR</b></td>
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
                          <asp:BoundField DataField="codigo" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="competencia" ItemStyle-Width="84px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="clasificacion" ItemStyle-Width="88px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="nivel" ItemStyle-Width="84px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="categoria" ItemStyle-Width="70px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="edades" ItemStyle-Width="60px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="fase" ItemStyle-Width="65px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="resultado" ItemStyle-Width="140px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="registro" ItemStyle-Width="70px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="inicio_dia" ItemStyle-Width="36px" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="inicio_mes" ItemStyle-Width="36px" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="fin_dia" ItemStyle-Width="36px" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="fin_mes" ItemStyle-Width="36px" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="departamento" ItemStyle-Width="86px" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="lugar" ItemStyle-Width="80px" ItemStyle-Font-Size="X-Small" />
                          <asp:BoundField DataField="presupuesto" ItemStyle-Width="110px" ItemStyle-HorizontalAlign="Center" SortExpression="presupuesto" DataFormatString="{0:c}" ItemStyle-Font-Size="Small" />
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
                            <ItemTemplate>
                              <asp:Label runat="server" Text="TOTALES" ForeColor="Black" CssClass="text-center"></asp:Label></b>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="110px" />
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

