<%@ Page Title="4. ALCANCE COMPETITIVO INTERNACIONAL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexC4.aspx.cs" Inherits="PATOnline.Views.C4.IndexC4" %>

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
            <li class="breadcrumb-item active">C4</li>
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

  <section class="content" runat="server" id="crearC4New">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Crear</span>
              <span class="info-box-number">C3</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoC4" CausesValidation="false" OnClick="nuevoC4_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
    </div>
  </section>

      <section class="content">
        <div class="container-fluid">
        <asp:UpdatePanel runat="server" ID="updateCrearC4">
        <ContentTemplate>
          <div class="row">
            <div class="col-md-6">
              <div class="card card-outline card-info" runat="server" id="mostrarCrearC4">
                <div class="card-header">
                  <h3 class="card-title"><span class="info-box-number">CREAR NUEVO C4</span></h3>
                  <div class="card-tools">
                    <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                      <i class="fa fa-minus"></i>
                    </button>
                  </div>
                </div>

                <div class="card-body pad" style="display: block;">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="dropCrearFormato" CssClass="control-label"><span style="color:red">*</span> FORMATO C</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearFormato" CssClass="form-control" OnSelectedIndexChanged="dropCrearFormato_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC4" runat="server" ControlToValidate="dropCrearFormato"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Formato" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtCrearEneroAbril" CssClass="control-label"><span style="color:red">*</span> ENE-ABR</asp:Label>
                      <input runat="server" id="txtCrearEneroAbril" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC4" runat="server" ControlToValidate="txtCrearEneroAbril"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un valor o 0" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtCrearMayoAgosto" CssClass="control-label"><span style="color:red">*</span> MAYO-AGO</asp:Label>
                      <input runat="server" id="txtCrearMayoAgosto" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC4" runat="server" ControlToValidate="txtCrearMayoAgosto"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un valor o 0" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtCrearSeptiembreDiciembre" CssClass="control-label"><span style="color:red">*</span> SEP-DIC</asp:Label>
                      <input runat="server" id="txtCrearSeptiembreDiciembre" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC4" runat="server" ControlToValidate="txtCrearSeptiembreDiciembre"
                        CssClass="text-danger" ErrorMessage="* El es obligatorio ingresar un valor o 0" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtCrearPresupuesto" CssClass="control-label"><span style="color:red">*</span> PRESUPUESTO</asp:Label>
                      <input runat="server" id="txtCrearPresupuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearC4" runat="server" ControlToValidate="txtCrearPresupuesto"
                        CssClass="text-danger" ErrorMessage="* El Presupuesto es obligatorio" />
                    </div>
                  </div>
                </div>

                <div class="card-footer">
                  <asp:LinkButton runat="server" ID="cancelCrearC4" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearC4_Click">
                <span class="fa fa-close"></span>
                  </asp:LinkButton>
                  <asp:LinkButton runat="server" ValidationGroup="validarCrearC4" ID="crearC4" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearC4_Click">
                <span class="fa fa-save"></span>
                  </asp:LinkButton>
                </div>
              </div>
            </div>

            <div class="col-md-6">
              <div class="card card-outline card-warning" runat="server" id="mostrarEditC4">
                <div class="card-header">
                  <h3 class="card-title"><span class="info-box-number">MODIFICAR C4</span></h3>
                  <div class="card-tools">
                    <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                      <i class="fa fa-minus"></i>
                    </button>
                  </div>
                </div>

                <div class="card-body pad" style="display: block;">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="dropEditFormato" CssClass="control-label"><span style="color:red">*</span> FORMATO C</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditFormato" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC4" runat="server" ControlToValidate="dropEditFormato"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Formato" />
                    </div>
                  </div>
                  <div class="row">
                    <asp:Label runat="server" ID="idEditCPE"></asp:Label>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtEditEneroAbril" CssClass="control-label"><span style="color:red">*</span> ENE-ABR</asp:Label>
                      <input runat="server" id="txtEditEneroAbril" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC4" runat="server" ControlToValidate="txtEditEneroAbril"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un valor o 0" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtEditMayoAgosto" CssClass="control-label"><span style="color:red">*</span> MAYO-AGO</asp:Label>
                      <input runat="server" id="txtEditMayoAgosto" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC4" runat="server" ControlToValidate="txtEditMayoAgosto"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un valor o 0" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtEditSeptiembreDiciembre" CssClass="control-label"><span style="color:red">*</span> SEP-DIC</asp:Label>
                      <input runat="server" id="txtEditSeptiembreDiciembre" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="000" maxlength="3" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC4" runat="server" ControlToValidate="txtEditSeptiembreDiciembre"
                        CssClass="text-danger" ErrorMessage="* El es obligatorio ingresar un valor o 0" />
                    </div>
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="txtEditPresupuesto" CssClass="control-label"><span style="color:red">*</span> PRESUPUESTO</asp:Label>
                      <input runat="server" id="txtEditPresupuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="0,000,000.00" maxlength="12" autofocus required />
                      <asp:RequiredFieldValidator ValidationGroup="validarEditC4" runat="server" ControlToValidate="txtEditPresupuesto"
                        CssClass="text-danger" ErrorMessage="* El Presupuesto es obligatorio" />
                    </div>
                  </div>
                </div>

                <div class="card-footer">
                  <asp:LinkButton runat="server" ID="cancelEditC4" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditC4_Click">
                <span class="fa fa-close"></span>
                  </asp:LinkButton>
                  <asp:LinkButton runat="server" ValidationGroup="validarEditC4" ID="editC4" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editC4_Click">
                <span class="fa fa-save"></span>
                  </asp:LinkButton>
                </div>
              </div>
            </div>
          </div>
            </ContentTemplate>
          </asp:UpdatePanel>
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

  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
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

                  <div class="row" style="text-align: center;">
                    <div class="col-md-12" style="background-color: darkturquoise; color: black;">
                      <h4>
                        <asp:Label runat="server" ForeColor="Black" Text="4. ALCANCE COMPETITIVO INTERNACIONAL"></asp:Label></h4>
                    </div>
                    <div class="col-md-12" style="background-color: lightseagreen; color: black;">
                      <h4>
                        <asp:Label runat="server" ForeColor="Black">ACTIVIDADES CUATRIMESTRALES</asp:Label></h4>
                    </div>
                  </div>

                  <br />
                  <br />

                  <div class="row">
                    <div class="col-md-12">
                      <table class="table table-bordered">
                        <tr>
                          <td style="width: 38%; text-align: center" rowspan="2"><b>FORMATO "C"</b></td>
                          <td style="text-align: center" colspan="4"><b>ACTIVIDADES</b></td>
                          <td style="width: 23%; text-align: center" rowspan="2"><b>PRESUPUESTO</b></td>
                        </tr>
                        <tr>
                          <td style="width: 9%; text-align: center; font-size: 14px;""><b>ENE-ABR</b></td>
                          <td style="width: 9%; text-align: center; font-size: 14px;""><b>MAY-AGO</b></td>
                          <td style="width: 9%; text-align: center; font-size: 14px;""><b>SEP-DIC</b></td>
                          <td style="width: 9%; text-align: center; font-size: 14px;""><b>ANUAL</b></td>
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
                          <asp:BoundField DataField="formato" ItemStyle-Width="39%" />
                          <asp:BoundField DataField="mes1" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="mes2" ItemStyle-Width="9%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="mes3" ItemStyle-Width="9%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="anual" ItemStyle-Width="9%" ItemStyle-HorizontalAlign="Center" />
                          <asp:BoundField DataField="presupuesto" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="presupuesto" DataFormatString="{0:c}" />
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
                      <asp:GridView ID="gridFADNTotal" runat="server" AutoGenerateColumns="False" DataKeyNames="numero"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                        <Columns>
                          <asp:TemplateField>
                            <ItemTemplate>
                              <p style="text-align: right; color: black;">
                                <b>
                                  <asp:Label ID="remarks" runat="server" Text="PRESUPUESTO GENERAL"></asp:Label></b>
                              </p>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="24%" />
                            <ItemTemplate>
                              <p style="text-align: center; color: black;">
                                <b>Q
                                <asp:Label ID="remarks" runat="server" Text='<%# Eval("total") %>'></asp:Label></b>
                              </p>
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
      </section>
    </ContentTemplate>
  </asp:UpdatePanel>

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


