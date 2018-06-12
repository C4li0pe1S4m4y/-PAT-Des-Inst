<%@ Page Title="P1:INGRESOS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP1.aspx.cs" Inherits="PATOnline.Views.P1.IndexP1" %>

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
            <li class="breadcrumb-item active">P1 Ingresos</li>
          </ol>
        </div>
      </div>
    </div>
  </div>

  <div class="content-header">
    <div class="container-fluid">
      <div class="row col-md-offset-2">
        <div class="col-md-2" style="border: solid; border-color: #99CCCC">
          <h4>
            <asp:Label runat="server" ForeColor="Black" Text="FADN:"></asp:Label></h4>
        </div>
        <div class="col-md-7" style="border: solid; border-color: #99CCCC">
          <h4>
            <asp:Label runat="server" ForeColor="Black" ID="fadn"></asp:Label></h4>
        </div>
      </div>
      <div class="row col-md-offset-2">
        <div class="col-md-2" style="border: solid; border-color: #99CCCC">
          <h4>
            <asp:Label runat="server" ForeColor="Black" Text="AÑO:"></asp:Label></h4>
        </div>
        <div class="col-md-7" style="border: solid; border-color: #99CCCC">
          <h4>
            <asp:Label runat="server" ForeColor="Black" ID="anio"></asp:Label></h4>
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

  <section class="content" runat="server" id="crearP1IngresoNew">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">P1 Ingreso</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoP1Ingreso" CausesValidation="false" OnClick="nuevoP1Ingreso_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearP1Ingreso">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO P1 INGRESO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <asp:UpdatePanel runat="server" ID="updateCrearP1Ingreso">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                      <h3>
                        <asp:Label runat="server" ID="lblTipoIngresoSelectCrear"></asp:Label></h3>
                    </div>
                  </div>
                  <br />
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropCrearTipoIngreso" CssClass="control-label"><span style="color:red">*</span> TIPO DE INGRESOS:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearTipoIngreso" CssClass="form-control" OnSelectedIndexChanged="dropCrearTipoIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP1Ingreso" runat="server" ControlToValidate="dropCrearTipoIngreso"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Ingreso" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropCrearIngreso" CssClass="control-label"><span style="color:red">*</span> INGRESOS:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearIngreso" CssClass="form-control" OnSelectedIndexChanged="dropCrearIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP1Ingreso" runat="server" ControlToValidate="dropCrearIngreso"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Ingreso" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropCrearCodigoIngreso" CssClass="control-label"><span style="color:red">*</span> CÓDIGO DE INGRESO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearCodigoIngreso" CssClass="form-control" OnSelectedIndexChanged="dropCrearCodigoIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP1Ingreso" runat="server" ControlToValidate="dropCrearCodigoIngreso"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Codigo de Ingreso" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="txtCrearMonto1" CssClass="control-label"><span style="color:red">*</span> MONTO COLUMNA NO. 1</asp:Label>
                      <input runat="server" id="txtCrearMonto1" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP1Ingreso" runat="server" ControlToValidate="txtCrearMonto1"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 1 es obligatorio" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="txtCrearMonto2" CssClass="control-label"><span style="color:red">*</span> MONTO COLUMNA NO. 2</asp:Label>
                      <input runat="server" id="txtCrearMonto2" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP1Ingreso" runat="server" ControlToValidate="txtCrearMonto2"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 2 es obligatorio" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="txtCrearMonto3" CssClass="control-label"><span style="color:red">*</span> MONTO COLUMNA NO. 3</asp:Label>
                      <input runat="server" id="txtCrearMonto3" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP1Ingreso" runat="server" ControlToValidate="txtCrearMonto3"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 3 es obligatorio" />
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>

          <div class="card-footer">
            <asp:LinkButton runat="server" ID="cancelCrearP1Ingreso" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearP1Ingreso_Click">
                <span class="fa fa-close"></span>
            </asp:LinkButton>
            <asp:LinkButton runat="server" ValidationGroup="validarCrearP1Ingreso" ID="crearP1Ingreso" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearP1Ingreso_Click">
                <span class="fa fa-save"></span>
            </asp:LinkButton>
            <asp:LinkButton runat="server" CausesValidation="false" ID="agregarCodigo" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="agregarCodigo_Click">
                AGREGAR CÓDIGO
            </asp:LinkButton>
          </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditP1Ingreso">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR P1 INGRESO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <asp:UpdatePanel runat="server" ID="updateEditP1Ingreso">
              <ContentTemplate>

                <div class="card-body pad" style="display: block;">
                  <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                      <h3>
                        <asp:Label runat="server" ID="lblTipoIngresoSelectEdit"></asp:Label></h3>
                    </div>
                  </div>
                  <br />
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" ID="idEditP1Ingreso"></asp:Label>
                      <asp:Label runat="server" AssociatedControlID="dropEditTipoIngreso" CssClass="control-label"><span style="color:red">*</span> TIPO DE INGRESOS:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditTipoIngreso" CssClass="form-control" OnSelectedIndexChanged="dropEditTipoIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP1Ingreso" runat="server" ControlToValidate="dropEditTipoIngreso"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Ingreso" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropEditIngreso" CssClass="control-label"><span style="color:red">*</span> INGRESOS:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditIngreso" CssClass="form-control" OnSelectedIndexChanged="dropEditIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP1Ingreso" runat="server" ControlToValidate="dropEditIngreso"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Ingreso" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropEditCodigoIngreso" CssClass="control-label"><span style="color:red">*</span> CÓDIGO DE INGRESO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditCodigoIngreso" CssClass="form-control" OnSelectedIndexChanged="dropEditCodigoIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP1Ingreso" runat="server" ControlToValidate="dropEditCodigoIngreso"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Codigo de Ingreso" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="txtEditMonto1" CssClass="control-label"><span style="color:red">*</span> MONTO COLUMNA NO. 1</asp:Label>
                      <input runat="server" id="txtEditMonto1" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP1Ingreso" runat="server" ControlToValidate="txtEditMonto1"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 1 es obligatorio" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="txtEditMonto2" CssClass="control-label"><span style="color:red">*</span> MONTO COLUMNA NO. 2</asp:Label>
                      <input runat="server" id="txtEditMonto2" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP1Ingreso" runat="server" ControlToValidate="txtEditMonto2"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 2 es obligatorio" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="txtEditMonto3" CssClass="control-label"><span style="color:red">*</span> MONTO COLUMNA NO. 3</asp:Label>
                      <input runat="server" id="txtEditMonto3" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP1Ingreso" runat="server" ControlToValidate="txtEditMonto3"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 3 es obligatorio" />
                    </div>
                  </div>
                </div>

              </ContentTemplate>
            </asp:UpdatePanel>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditP1Ingreso" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditP1Ingreso_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditP1Ingreso" ID="editP1Ingreso" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editP1Ingreso_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content" runat="server" id="mostrarCrearCodigo">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-danger">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR CÓDIGO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <asp:UpdatePanel runat="server" ID="updateCreaCodigo">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearTipoCodigo" CssClass="control-label"><span style="color:red">*</span> TIPO DE INGRESOS:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearTipoCodigo" CssClass="form-control" OnSelectedIndexChanged="dropCrearTipoCodigo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearCodigo" runat="server" ControlToValidate="dropCrearTipoCodigo"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Ingreso" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="dropCrearListCodigo" CssClass="control-label"><span style="color:red">*</span> INGRESOS:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearListCodigo" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearCodigo" runat="server" ControlToValidate="dropCrearListCodigo"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Ingreso" />
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNumeroCodigo" CssClass="control-label"><span style="color:red">*</span> CÓDIGO</asp:Label>
                  <input runat="server" id="txtCrearNumeroCodigo" class="form-control" type="text" onkeypress="return numerosypuntomenos(event)" placeholder="00.0" maxlength="12" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearCodigo" runat="server" ControlToValidate="txtCrearNumeroCodigo"
                    CssClass="text-danger" ErrorMessage="* El codigo es obligatorio" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNombreCodigo" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearNombreCodigo" class="form-control" type="text" onkeypress="return letras(event)" placeholder="nombre del codigo" maxlength="40" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearCodigo" runat="server" ControlToValidate="txtCrearNombreCodigo"
                    CssClass="text-danger" ErrorMessage="* El nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearCodigo" type="button" class="btn btn-info btn-outline-danger btn-lg" OnClick="cancelCrearCodigo_Click" CausesValidation="false">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarObservacion" ID="crearCodigo" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearCodigo_Click">
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
              <div class="col-md-12">
                <asp:GridView ID="gridFADN" runat="server" AutoGenerateColumns="False" DataKeyNames="idnumero1" OnRowDataBound="gridFADN_RowDataBound" Width="1000%"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                  <Columns>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:GridView ID="gridFADN2" runat="server" AutoGenerateColumns="False" DataKeyNames="idnumero2" Width="1000%"
                          CssClass="table table-bordered dataTable" GridLines="None" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridFADN2_RowCommand" ShowHeader="false">
                          <HeaderStyle CssClass="gradiant" />
                          <Columns>
                            <asp:BoundField DataField="idnumero2" />
                            <asp:BoundField DataField="codigo">
                              <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre">
                              <ItemStyle Width="500px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="monto1" SortExpression="monto1" DataFormatString="{0:c}">
                              <ItemStyle Width="126px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="monto2" SortExpression="monto2" DataFormatString="{0:c}">
                              <ItemStyle Width="125px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="monto3" SortExpression="monto3" DataFormatString="{0:c}">
                              <ItemStyle Width="146px" />
                            </asp:BoundField>
                            <asp:TemplateField>
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
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </div>
              <div class="col-md-12">
                <asp:GridView ID="gridFADN3" runat="server" AutoGenerateColumns="False" DataKeyNames="idnumero2" Width="1000%"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" GridLines="None" ShowHeader="false">
                  <Columns>
                    <asp:TemplateField>
                      <ItemStyle HorizontalAlign="Center" />
                      <ItemTemplate>
                        <h5>
                          <asp:Label runat="server" Text="TOTAL Q"></asp:Label></h5>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="total1" SortExpression="total1" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Center">
                      <ItemStyle Width="154px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="total2" SortExpression="total2" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Center">
                      <ItemStyle Width="152px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="total3" SortExpression="total3" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Center">
                      <ItemStyle Width="195px" />
                    </asp:BoundField>
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
