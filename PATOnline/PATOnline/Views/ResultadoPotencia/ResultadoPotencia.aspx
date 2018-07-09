<%@ Page Title="RESULTADOS DEPORTIVOS - ANÁLISIS DE PRINCIPALES POTENCIAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultadoPotencia.aspx.cs" Inherits="PATOnline.Views.ResultadoPotencia.ResultadoPotencia" %>

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
            <li class="breadcrumb-item active">Resultados y Potencias</li>
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

  <section class="content" runat="server" id="crearResultadoPotenciaNew">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Resultado Deportivo</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoResultado" CausesValidation="false" OnClick="nuevoResultado_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Principal Potencia</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaBrecha" CausesValidation="false" OnClick="nuevaBrecha_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearResultado">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO RESULTADO DEPORTIVO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearNivelResultado" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearNivelResultado" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearResultado" runat="server" ControlToValidate="dropCrearNivelResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearCompetenciaResultado" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearCompetenciaResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="nombre de la competencia" maxlength="75" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearResultado" runat="server" ControlToValidate="txtCrearCompetenciaResultado"
                    CssClass="text-danger" ErrorMessage="* La Competencia es obligatorio" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearSedeResultado" CssClass="control-label"><span style="color:red">*</span> SEDE</asp:Label>
                  <input runat="server" id="txtCrearSedeResultado" class="form-control" type="text" onkeypress="return letrasycomapunto(event)" placeholder="sede" maxlength="75" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearResultado" runat="server" ControlToValidate="txtCrearSedeResultado"
                    CssClass="text-danger" ErrorMessage="* La Sede es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearFechaResultado" CssClass="control-label"><span style="color:red">*</span> FECHA</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearFechaResultado" CssClass="form-control" TextMode="Number" onkeypress="return numeros(event)" MaxLength="4" />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearResultado" runat="server" ControlToValidate="txtCrearFechaResultado"
                    CssClass="text-danger" ErrorMessage="* La Fecha es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="dropCrearCategoriaResultado" CssClass="control-label"><span style="color:red">*</span> CATEGORIA</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearCategoriaResultado" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearResultado" runat="server" ControlToValidate="dropCrearCategoriaResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Categoria" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearResultadoResultado" CssClass="control-label">RESULTADO OBTENIDO</asp:Label>
                  <input runat="server" id="txtCrearResultadoResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="resultado" maxlength="75" autofocus />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacionResultado" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtCrearObservacionResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="500" autofocus></textarea>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearResultado" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearResultado_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearResultado" ID="crearResultado" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearResultado_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearPotencia">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVA PRINCIPAL POTENCIA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearNivelPotencia" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearNivelPotencia" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearPotencia" runat="server" ControlToValidate="dropCrearNivelPotencia"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPrimeraPotencia" CssClass="control-label"> PRIMERA POTENCIA</asp:Label>
                  <input runat="server" id="txtCrearPrimeraPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="primera potencia" maxlength="40" autofocus />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearSegundaPotencia" CssClass="control-label"> SEGUNDA POTENCIA</asp:Label>
                  <input runat="server" id="txtCrearSegundaPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="segunda potencia" maxlength="40" autofocus />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearTerceraPotencia" CssClass="control-label"> TERCERA POTENCIA</asp:Label>
                  <input runat="server" id="txtCrearTerceraPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="tercera potencia" maxlength="40" autofocus />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPosicionPotencia" CssClass="control-label"> POSICIÓN GUATEMALA</asp:Label>
                  <input runat="server" id="txtCrearPosicionPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="posición guatemala" maxlength="40" autofocus />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearPotencia" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearPotencia_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearPotencia" ID="crearPotencia" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearPotencia_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditResultado">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR RESULTADO DEPORTIVO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditResultado"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditNivelResultado" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditNivelResultado" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditResultado" runat="server" ControlToValidate="dropEditNivelResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditCompetenciaResultado" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtEditCompetenciaResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="nombre de la competencia" maxlength="75" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditResultado" runat="server" ControlToValidate="txtEditCompetenciaResultado"
                    CssClass="text-danger" ErrorMessage="* La Competencia es obligatorio" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditSedeResultado" CssClass="control-label"><span style="color:red">*</span> SEDE</asp:Label>
                  <input runat="server" id="txtEditSedeResultado" class="form-control" type="text" onkeypress="return letrasycomapunto(event)" placeholder="sede" maxlength="75" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditResultado" runat="server" ControlToValidate="txtEditSedeResultado"
                    CssClass="text-danger" ErrorMessage="* La Sede es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditFechaResultado" CssClass="control-label"><span style="color:red">*</span> FECHA</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditFechaResultado" CssClass="form-control" TextMode="Number" MaxLength="4" />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditResultado" runat="server" ControlToValidate="txtEditFechaResultado"
                    CssClass="text-danger" ErrorMessage="* La Fecha es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="dropEditCategoriaResultado" CssClass="control-label"><span style="color:red">*</span> CATEGORIA</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditCategoriaResultado" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditResultado" runat="server" ControlToValidate="dropEditCategoriaResultado"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Categoria" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditResultadoResultado" CssClass="control-label">RESULTADO OBTENIDO</asp:Label>
                  <input runat="server" id="txtEditResultadoResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="resultado" maxlength="75" autofocus />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditObservacionResultado" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtEditObservacionResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="500" autofocus></textarea>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditResultado" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditResultado_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditResultado" ID="editResultado" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editResultado_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditPotencia">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR PRINCIPAL POTENCIA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditPotencia"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditNivelPotencia" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditNivelPotencia" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditPotencia" runat="server" ControlToValidate="dropEditNivelPotencia"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditPrimeraPotencia" CssClass="control-label"> PRIMERA POTENCIA</asp:Label>
                  <input runat="server" id="txtEditPrimeraPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="primera potencia" maxlength="40" autofocus />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditSegundaPotencia" CssClass="control-label"> SEGUNDA POTENCIA</asp:Label>
                  <input runat="server" id="txtEditSegundaPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="segunda potencia" maxlength="40" autofocus />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditTerceraPotencia" CssClass="control-label"> TERCERA POTENCIA</asp:Label>
                  <input runat="server" id="txtEditTerceraPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="tercera potencia" maxlength="40" autofocus />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditPosicionPotencia" CssClass="control-label"> POSICIÓN GUATEMALA</asp:Label>
                  <input runat="server" id="txtEditPosicionPotencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="posición guatemala" maxlength="40" autofocus />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditPotencia" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditPotencia_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditPotencia" ID="editPotencia" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editPotencia_Click">
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
                  <asp:Label runat="server" ID="idIntroObservacionRechazoResultado"></asp:Label>
                  <asp:Label runat="server" ID="idIntroObservacionRechazoPotencia"></asp:Label>
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
                  <asp:Label runat="server" ID="idIntroObservacionSinRechazoResultado"></asp:Label>
                  <asp:Label runat="server" ID="idIntroObservacionSinRechazoPotencia"></asp:Label>
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
              <h3 class="card-title"><span class="info-box-number">RESULTADOS DEPORTIVOS INTERNACIONALES HISTÓRICOS</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <div class="col-md-12">
                <asp:GridView ID="gridResultado" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridResultado_RowDataBound"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridResultado_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="numero" ShowHeader="false" />
                    <asp:BoundField DataField="nivel" HeaderText="NIVEL" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="competencia" HeaderText="NOMBRE DE LA COMPETENCIA" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="sed" HeaderText="SEDE" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="fecha_resultado" HeaderText="FECHA" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="categoria" HeaderText="CATEGORIA" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="resultado_obtenido" HeaderText="RESULTADO OBTENIDO" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" ItemStyle-Width="45%" />
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

      <div class="row">
        <div class="col-md-12">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title"><span class="info-box-number">ANÁLISIS DE PRINCIPALES POTENCIAS POR AREA GEOGRÁFICA PARA LA OBTENCIÓN DE RESULTADOS DEPORTIVOS</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <div class="col-md-12">
                <asp:GridView ID="gridPotencia" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridPotencia_RowDataBound"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridPotencia_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="numero" ShowHeader="false" />
                    <asp:BoundField DataField="nivel" HeaderText="NIVEL" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="primera" HeaderText="PRIMERA POTENCIA" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="segunda" HeaderText="SEGUNDA POTENCIA" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="tercera" HeaderText="TERCERA POTENCIA" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="posicion" HeaderText="PSICIÓN GUATEMALA" ItemStyle-Width="20%" />
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
