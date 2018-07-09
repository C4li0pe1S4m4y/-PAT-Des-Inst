<%@ Page Title="P2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP2.aspx.cs" Inherits="PATOnline.Views.P2.IndexP2" %>

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
            <li class="breadcrumb-item active">P2 Egresos por Renglón</li>
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
        <div class="col-md-10" style="border: solid; border-color: #99CCCC">
          <h4>
            <asp:Label runat="server" ForeColor="Black" ID="fadn"></asp:Label></h4>
        </div>
      </div>
      <div class="row col-md-offset-2">
        <div class="col-md-2" style="border: solid; border-color: #99CCCC">
          <h4>
            <asp:Label runat="server" ForeColor="Black" Text="AÑO:"></asp:Label></h4>
        </div>
        <div class="col-md-10" style="border: solid; border-color: #99CCCC">
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

  <section class="content" runat="server" id="crearP2New">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">P2 Egresos por Renglón</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoP2" CausesValidation="false" OnClick="nuevoP2_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearP2">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO P2 EGRESOS POR RENGLÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <asp:UpdatePanel runat="server" ID="updateCrearP2">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                      <h3>
                        <asp:Label runat="server" ID="lblEgresoCrear"></asp:Label></h3>
                    </div>
                  </div>
                  <br />
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropCrearTipoProyecto" CssClass="control-label"><span style="color:red">*</span> TIPO DE PROYECTO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearTipoProyecto" CssClass="form-control" OnSelectedIndexChanged="dropCrearTipoProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP2" runat="server" ControlToValidate="dropCrearTipoProyecto"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Proyecto" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropCrearProyecto" CssClass="control-label"><span style="color:red">*</span> PROYECTO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearProyecto" CssClass="form-control" OnSelectedIndexChanged="dropCrearProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP2" runat="server" ControlToValidate="dropCrearProyecto"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Proyecto" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropCrearRenglon" CssClass="control-label"><span style="color:red">*</span> RENGLÓN DEL PROYECTO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearRenglon" CssClass="form-control" OnSelectedIndexChanged="dropCrearRenglon_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP2" runat="server" ControlToValidate="dropCrearRenglon"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Renglon del Proyecto" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtCrearUno" CssClass="control-label"><span style="color:red">*</span> MONTO 50%</asp:Label>
                      <input runat="server" id="txtCrearUno" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP2" runat="server" ControlToValidate="txtCrearUno"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 1 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtCrearDos" CssClass="control-label">MONTO 30%</asp:Label>
                      <input runat="server" id="txtCrearDos" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP2" runat="server" ControlToValidate="txtCrearDos"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 2 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtCrearTres" CssClass="control-label">MONTO 20%</asp:Label>
                      <input runat="server" id="txtCrearTres" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP2" runat="server" ControlToValidate="txtCrearTres"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 3 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtCrearCuatro" CssClass="control-label">MONTO 100%</asp:Label>
                      <input runat="server" id="txtCrearCuatro" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearP2" runat="server" ControlToValidate="txtCrearCuatro"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 4 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtCrearFinanciamiento" CssClass="control-label">FINANCIMIENTO</asp:Label>
                      <input runat="server" id="txtCrearFinanciamiento" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus />
                    </div>
                    <div class="col-md-2">
                      <asp:LinkButton runat="server" ID="verificarCrearP2" CssClass="btn btn-info btn-outline-info btn-lg" Text="VERIFICAR" OnClick="verificarCrearP2_Click"></asp:LinkButton>
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearP2" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearP2_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearP2" ID="crearP2" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearP2_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditP2">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR P2 EGRESOS POR RENGLÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12" style="text-align: center;">
                      <h3>
                        <asp:Label runat="server" ID="lblEgresoEdit"></asp:Label></h3>
                    </div>
                  </div>
                  <br />
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" ID="idEdit"></asp:Label>
                      <asp:Label runat="server" AssociatedControlID="dropEditTipoProyecto" CssClass="control-label"><span style="color:red">*</span> TIPO DE PROYECTO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditTipoProyecto" CssClass="form-control" OnSelectedIndexChanged="dropEditTipoProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP2" runat="server" ControlToValidate="dropEditTipoProyecto"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Proyecto" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropEditProyecto" CssClass="control-label"><span style="color:red">*</span> PROYECTO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditProyecto" CssClass="form-control" OnSelectedIndexChanged="dropEditProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP2" runat="server" ControlToValidate="dropEditProyecto"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Proyecto" />
                    </div>
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="dropEditRenglon" CssClass="control-label"><span style="color:red">*</span> RENGLÓN DEL PROYECTO:</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditRenglon" CssClass="form-control" OnSelectedIndexChanged="dropEditRenglon_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP2" runat="server" ControlToValidate="dropEditRenglon"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Renglon del Proyecto" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtEditUno" CssClass="control-label"><span style="color:red">*</span> MONTO 50%</asp:Label>
                      <input runat="server" id="txtEditUno" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP2" runat="server" ControlToValidate="txtEditUno"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 1 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtEditDos" CssClass="control-label">MONTO 30%</asp:Label>
                      <input runat="server" id="txtEditDos" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP2" runat="server" ControlToValidate="txtEditDos"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 2 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtEditTres" CssClass="control-label">MONTO 20%</asp:Label>
                      <input runat="server" id="txtEditTres" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP2" runat="server" ControlToValidate="txtEditTres"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 3 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtEditCuatro" CssClass="control-label">MONTO 100%</asp:Label>
                      <input runat="server" id="txtEditCuatro" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditP2" runat="server" ControlToValidate="txtEditCuatro"
                        CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 4 es obligatorio" />
                    </div>
                    <div class="col-md-2">
                      <asp:Label runat="server" AssociatedControlID="txtEditFinanciamiento" CssClass="control-label">FINANCIMIENTO</asp:Label>
                      <input runat="server" id="txtEditFinanciamiento" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus />
                    </div>
                    <div class="col-md-2">
                      <asp:LinkButton runat="server" ID="verificarEditP2" CssClass="btn btn-info btn-outline-info btn-lg" Text="VERIFICAR" OnClick="verificarEditP2_Click"></asp:LinkButton>
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditP2" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditP2_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditP2" ID="editP2" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editP2_Click">
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
      <div class="row" style="text-align: center;">
        <div class="col-md-12" style="color: black;">
          <h5>
            <asp:Label runat="server" ForeColor="Black" Text="1. - PROYECCIÓN DE EGRESOS POR RENGLON CON BASE AL PRESUPUESTO APROBADO DE CDAG"></asp:Label></h5>
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
                <div class="col-md-12">
                  <table class="table table-bordered dataTable">
                    <tr>
                      <th style="text-align: center"><b>GRUPO RENGLON</b></th>
                      <th style="width: 603px; text-align: center"><b>CONCEPTO</b></th>
                      <th style="width: 135px; text-align: center"><b>50%</b></th>
                      <th style="width: 135px; text-align: center"><b>30%</b></th>
                      <th style="width: 133px; text-align: center"><b>20%</b></th>
                      <th style="width: 131px; text-align: center"><b>100%</b></th>
                      <th style="width: 131px; text-align: center"><b>FINANC.</b></th>
                    </tr>
                  </table>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:GridView ID="gridFADN1" runat="server" AutoGenerateColumns="False" DataKeyNames="idnumero2" Width="1000%" OnRowDataBound="gridFADN1_RowDataBound" OnRowCommand="gridFADN1_RowCommand"
                    CssClass="table table-bordered dataTable" GridLines="None" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                    <HeaderStyle CssClass="gradiant" />
                    <Columns>
                      <asp:BoundField DataField="idnumero2" />
                      <asp:TemplateField>
                        <ItemStyle Width="71px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("renglon") %>'></asp:Label></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="482px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("nombre") %>'></asp:Label></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto1") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto2") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto3") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto4") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="110px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("finanza") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
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
                <div class="col-md-12">
                  <asp:GridView ID="gridFADN2" runat="server" AutoGenerateColumns="False" DataKeyNames="idnumero2" Width="1000%" OnRowDataBound="gridFADN2_RowDataBound" OnRowCommand="gridFADN2_RowCommand"
                    CssClass="table table-bordered dataTable" GridLines="None" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                    <Columns>
                      <asp:BoundField DataField="idnumero2" />
                      <asp:TemplateField>
                        <ItemStyle Width="71px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("renglon") %>'></asp:Label></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="482px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label runat="server" Text='<%# Eval("nombre") %>'></asp:Label></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto1") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto2") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto3") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("monto4") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="110px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q
                          <asp:Label runat="server" Text='<%# Eval("finanza") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
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

                <div class="col-md-12">
                  <asp:GridView ID="gridFADN3" runat="server" AutoGenerateColumns="False" DataKeyNames="idnumero2" Width="1000%" OnRowDataBound="gridFADN3_RowDataBound"
                    CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" GridLines="None" ShowHeader="false">
                    <Columns>
                      <asp:TemplateField>
                        <ItemStyle Width="576px" Font-Size="Large" />
                        <ItemTemplate><asp:Label ID="remarks" runat="server" Text='<%# Eval("nombre") %>'></asp:Label></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="115px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q <asp:Label ID="total1" runat="server" Text='<%# Eval("total1") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="115px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q <asp:Label ID="total2" runat="server" Text='<%# Eval("total2") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="113px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q <asp:Label ID="total3" runat="server" Text='<%# Eval("total3") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="113px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q <asp:Label ID="total4" runat="server" Text='<%# Eval("total4") %>'></asp:Label></span></ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="112px" Font-Size="Smaller" />
                        <ItemTemplate><span>Q <asp:Label ID="lbl7" runat="server" Text='<%# Eval("total5") %>'></asp:Label></span></ItemTemplate>
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
