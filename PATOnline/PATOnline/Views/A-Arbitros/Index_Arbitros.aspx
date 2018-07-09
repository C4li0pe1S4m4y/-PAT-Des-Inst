<%@ Page Title="A-ARBITROS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index_Arbitros.aspx.cs" Inherits="PATOnline.Views.A_Arbitros.Index_Arbitros" %>

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
            <li class="breadcrumb-item active">A-Arbitro</li>
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

  <section class="content" runat="server" id="crearArbitroNew">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">CREAR</span>
              <span class="info-box-number">ARBITRO</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoArbitro" CausesValidation="false" OnClick="nuevoArbitro_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearArbitro">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO ARBITRO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPrimerNombre" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearPrimerNombre" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="30" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrear" runat="server" ControlToValidate="txtCrearPrimerNombre"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un nombre" />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtCrearSegundoNombre" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtCrearSegundoNombre" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="30" autofocus />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtCrearPrimerApellido" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearPrimerApellido" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="30" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrear" runat="server" ControlToValidate="txtCrearPrimerApellido"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un apellido" />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtCrearSegundoApellido" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtCrearSegundoApellido" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="30" autofocus />
                </div>
              </div>
              <div class="row">
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtCrearNacionalidad" CssClass="control-label"><span style="color:red">*</span> NACIONALIDAD</asp:Label>
                  <input runat="server" id="txtCrearNacionalidad" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar nacionalidad" maxlength="45" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrear" runat="server" ControlToValidate="txtCrearNacionalidad"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar una nacionalidad" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtCrearDepartamentoLaboral" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO LABORAL</asp:Label>
                  <input runat="server" id="txtCrearDepartamentoLaboral" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar departamento laboral" maxlength="45" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarCrear" runat="server" ControlToValidate="txtCrearDepartamentoLaboral"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un departamento laboral" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="dropCrearNivel" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropCrearNivel" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrear" runat="server" ControlToValidate="dropCrearNivel"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacion" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtCrearObservacion" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="1500" autofocus></textarea>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearArbitro" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearArbitro_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrear" ID="crearArbitro" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearArbitro_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditArbitro">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR ENTRENADOR</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <asp:TextBox runat="server" ID="idEdit"></asp:TextBox>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtEditPrimerNombre" CssClass="control-label"><span style="color:red">*</span> PRIMER NOMBRE</asp:Label>
                  <input runat="server" id="txtEditPrimerNombre" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer nombre" maxlength="30" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEdit" runat="server" ControlToValidate="txtEditPrimerNombre"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un nombre" />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtEditSegundoNombre" CssClass="control-label">SEGUNDO NOMBRE</asp:Label>
                  <input runat="server" id="txtEditSegundoNombre" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo nombre" maxlength="30" autofocus />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtEditPrimerApellido" CssClass="control-label"><span style="color:red">*</span> PRIMER APELLIDO</asp:Label>
                  <input runat="server" id="txtEditPrimerApellido" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar primer apellido" maxlength="30" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEdit" runat="server" ControlToValidate="txtEditPrimerApellido"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un apellido" />
                </div>
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="txtEditSegundoApellido" CssClass="control-label">SEGUNDO APELLIDO</asp:Label>
                  <input runat="server" id="txtEditSegundoApellido" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar segundo apellido" maxlength="30" autofocus />
                </div>
              </div>
              <div class="row">
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtEditNacionalidad" CssClass="control-label"><span style="color:red">*</span> NACIONALIDAD</asp:Label>
                  <input runat="server" id="txtEditNacionalidad" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar nacionalidad" maxlength="45" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEdit" runat="server" ControlToValidate="txtEditNacionalidad"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar una nacionalidad" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="txtEditDepartamentoLaboral" CssClass="control-label"><span style="color:red">*</span> DEPARTAMENTO LABORAL</asp:Label>
                  <input runat="server" id="txtEditDepartamentoLaboral" class="form-control" type="text" onkeypress="return letras(event)" placeholder="ingresar departamento laboral" maxlength="45" autofocus required />
                  <asp:RequiredFieldValidator ValidationGroup="validarEdit" runat="server" ControlToValidate="txtEditDepartamentoLaboral"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un departamento laboral" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="dropEditNivel" CssClass="control-label"><span style="color:red">*</span> NIVEL</asp:Label>
                  <asp:DropDownList runat="server" ID="dropEditNivel" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEdit" runat="server" ControlToValidate="dropEditNivel"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un nivel" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditObservacion" CssClass="control-label">OBSERVACIONES</asp:Label>
                  <textarea runat="server" style="height: 150px;" id="txtEditObservacion" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la observacion" maxlength="1500" autofocus></textarea>
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditArbitro" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditArbitro_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEdit" ID="editArbitro" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editArbitro_Click">
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
                  <textarea runat="server" id="Textarea1" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="observación" maxlength="1000" autofocus required></textarea>
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
              <div class="row">
                <div class="col-md-12">
                  <asp:GridView ID="gridFADN" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridFADN_RowDataBound"
                    CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridFADN_RowCommand">
                    <Columns>
                      <asp:BoundField DataField="numero" />
                      <asp:BoundField DataField="nombre" HeaderText="NOMBRE Y APELLIDOS" ItemStyle-HorizontalAlign="Center" />
                      <asp:BoundField DataField="nacionalidad" HeaderText="NACIONALIDAD" />
                      <asp:BoundField DataField="departamento" HeaderText="DEPARTAMENTO DONDE LABORA" />
                      <asp:BoundField DataField="nivel" HeaderText="NIVEL" />
                      <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES" />
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
