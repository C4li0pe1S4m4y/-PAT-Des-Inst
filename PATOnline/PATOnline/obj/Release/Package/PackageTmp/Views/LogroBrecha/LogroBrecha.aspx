<%@ Page Title="ANALISIS SOBRE PUESTOS - ANALISIS DE BRECHAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogroBrecha.aspx.cs" Inherits="PATOnline.Views.LogroBrecha.LogroBrecha" %>

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
            <li class="breadcrumb-item active">Logros y Brechas</li>
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

  <section class="content" runat="server" id="crearLogroBrechaNew">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Puesto Logrado</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoPuesto" CausesValidation="false" OnClick="nuevoPuesto_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Análisis de Brecha</span>
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearPuesto">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO PUESTO LOGRADO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearAnioPuesto" CssClass="control-label"><span style="color:red">*</span> AÑO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearAnioPuesto" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearPuesto" runat="server" ControlToValidate="dropCrearAnioPuesto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Año" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPuestoObtenidoPuesto" CssClass="control-label"><span style="color:red">*</span> PUESTO OBTENIDO</asp:Label>
                  <input runat="server" id="txtCrearPuestoObtenidoPuesto" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearPuesto" runat="server" ControlToValidate="txtCrearPuestoObtenidoPuesto"
                    CssClass="text-danger" ErrorMessage="* El Puesto Obtenido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPuntosPuesto" CssClass="control-label"><span style="color:red">*</span> PUNTOS</asp:Label>
                  <input runat="server" id="txtCrearPuntosPuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0.00" maxlength="8" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearPuesto" runat="server" ControlToValidate="txtCrearPuntosPuesto"
                    CssClass="text-danger" ErrorMessage="* El Punteo es obligatorio" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacionPuesto" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtCrearObservacionPuesto" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="500" autofocus></textarea>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearPuesto" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearPuesto_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearPuesto" ID="crearPuesto" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearPuesto_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarCrearBrecha">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO ANÁLISIS DE BRECHA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="dropCrearAnalisisBrechaBrecha" CssClass="control-label"><span style="color:red">*</span> BRECHA RESPECTO A:</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearAnalisisBrechaBrecha" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearBrecha" runat="server" ControlToValidate="dropCrearAnalisisBrechaBrecha"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Brecha" />
                </div>
              </div>

              <div class="row">
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPuntosBrecha" CssClass="control-label"><span style="color:red">*</span> PUNTOS</asp:Label>
                  <input runat="server" id="txtCrearPuntosBrecha" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0000.00" maxlength="8" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearBrecha" runat="server" ControlToValidate="txtCrearPuntosBrecha"
                    CssClass="text-danger" ErrorMessage="* El Punteo es obligatorio" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPuntosObtenidosBrecha" CssClass="control-label"><span style="color:red">*</span> PUNTOS OBTENIDOS POR FADN</asp:Label>
                  <input runat="server" id="txtCrearPuntosObtenidosBrecha" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0000.00" maxlength="8" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearBrecha" runat="server" ControlToValidate="txtCrearPuntosObtenidosBrecha"
                    CssClass="text-danger" ErrorMessage="* El Punteo Obtenido por FADN es obligatorio" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtCrearComparacionBrecha" CssClass="control-label"><span style="color:red">*</span> COMPRACIÓN</asp:Label>
                  <input runat="server" id="txtCrearComparacionBrecha" class="form-control" type="text" onkeypress="return numerosypuntomenos(event)" placeholder="ingresar numero" maxlength="12" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearBrecha" runat="server" ControlToValidate="txtCrearComparacionBrecha"
                    CssClass="text-danger" ErrorMessage="* La Comparacion es obligatoria" />
                </div>
              </div>
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacionBrecha" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtCrearObservacionBrecha" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="500" autofocus></textarea>
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
      </div>

      <div class="row">
        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditPuesto">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR PUESTO LOGRADO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditPuesto"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditAnioPuesto" CssClass="control-label"><span style="color:red">*</span> AÑO</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditAnioPuesto" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditPuesto" runat="server" ControlToValidate="dropEditAnioPuesto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Año" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditPuestoObtenidoPuesto" CssClass="control-label"><span style="color:red">*</span> PUESTO OBTENIDO</asp:Label>
                  <input runat="server" id="txtEditPuestoObtenidoPuesto" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditPuesto" runat="server" ControlToValidate="txtEditPuestoObtenidoPuesto"
                    CssClass="text-danger" ErrorMessage="* El Puesto Obtenido es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditPuntosPuesto" CssClass="control-label"><span style="color:red">*</span> PUNTOS</asp:Label>
                  <input runat="server" id="txtEditPuntosPuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0000.00" maxlength="8" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditPuesto" runat="server" ControlToValidate="txtEditPuntosPuesto"
                    CssClass="text-danger" ErrorMessage="* El Punteo es obligatorio" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditObservacionPuesto" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtEditObservacionPuesto" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="500" autofocus></textarea>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditPuesto" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditPuesto_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditPuesto" ID="editPuesto" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editPuesto_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-info" runat="server" id="mostrarEditBrecha">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR ANÁLISIS DE BRECHA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idEditBrecha"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="dropEditAnalisisBrechaBrecha" CssClass="control-label"><span style="color:red">*</span> BRECHA RESPECTO A:</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditAnalisisBrechaBrecha" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditBrecha" runat="server" ControlToValidate="dropEditAnalisisBrechaBrecha"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Brecha" />
                </div>
              </div>

              <div class="row">
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtEditPuntosBrecha" CssClass="control-label"><span style="color:red">*</span> PUNTOS</asp:Label>
                  <input runat="server" id="txtEditPuntosBrecha" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0000.00" maxlength="8" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditBrecha" runat="server" ControlToValidate="txtEditPuntosBrecha"
                    CssClass="text-danger" ErrorMessage="* El Punteo es obligatorio" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtEditPuntosObtenidosBrecha" CssClass="control-label"><span style="color:red">*</span> PUNTOS OBTENIDOS POR FADN</asp:Label>
                  <input runat="server" id="txtEditPuntosObtenidosBrecha" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0000.00" maxlength="8" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditBrecha" runat="server" ControlToValidate="txtEditPuntosObtenidosBrecha"
                    CssClass="text-danger" ErrorMessage="* El Punteo Obtenido por FADN es obligatorio" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtEditComparacionBrecha" CssClass="control-label"><span style="color:red">*</span> COMPRACIÓN</asp:Label>
                  <input runat="server" id="txtEditComparacionBrecha" class="form-control" type="text" onkeypress="return numerosypuntomenos(event)" placeholder="ingresar numero" maxlength="12" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEditBrecha" runat="server" ControlToValidate="txtEditComparacionBrecha"
                    CssClass="text-danger" ErrorMessage="* La Comparacion es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditObservacionBrecha" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtEditObservacionBrecha" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="500" autofocus></textarea>
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
                  <asp:Label runat="server" ID="idIntroObservacionRechazoPuesto"></asp:Label>
                  <asp:Label runat="server" ID="idIntroObservacionRechazoBrecha"></asp:Label>
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
                  <asp:Label runat="server" ID="idIntroObservacionSinRechazoPuesto"></asp:Label>
                  <asp:Label runat="server" ID="idIntroObservacionSinRechazoBrecha"></asp:Label>
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
              <h3 class="card-title"><span class="info-box-number">ANALISIS SOBRE PUESTOS LOGRADOS EN EL MODELO DE EXCELENCIA EN GESTIÓN DEPORTIVA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <div class="col-md-12">
                <asp:GridView ID="gridPuestoLogrado" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridPuestoLogrado_RowDataBound"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridPuestoLogrado_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="numero" ShowHeader="false" />
                    <asp:BoundField DataField="anio" HeaderText="AÑO" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="puesto" HeaderText="PUESTO OBTENIDO" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="punteo" HeaderText="PUNTOS" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" ItemStyle-Width="60%" />
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
              <h3 class="card-title"><span class="info-box-number">ANALISIS DE BRECHAS CON RESPECTO A LAS CATEGORIAS DEL MEGD <asp:Label runat="server" ID="anio"></asp:Label></span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <div class="col-md-12">
                <asp:GridView ID="gridAnalisisBrecha" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridAnalisisBrecha_RowDataBound"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridAnalisisBrecha_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="numero" ShowHeader="false" />
                    <asp:BoundField DataField="brecha" HeaderText="BRECHA CON RESPECTO A:" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="punteo" HeaderText="PUNTOS" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="punteo_obtenido" HeaderText="PUNTOS OBTENIDOS POR FADN" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="comparacion" HeaderText="COMPARACIONES" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" ItemStyle-Width="50%" />
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
