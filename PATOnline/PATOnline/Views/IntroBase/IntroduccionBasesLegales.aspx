<%@ Page Title="INTRODUCCIÓN - BASE LEGAL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IntroduccionBasesLegales.aspx.cs" Inherits="PATOnline.Views.IntroBase.IntroduccionBasesLegales" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-md-10">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
        <div class="col-md-1">
          <asp:LinkButton runat="server" ID="btPDF" CausesValidation="false">
            <span class="btn btn-block btn-info btn-sm"><i class="fa  fa-file-pdf-o"></i></span>
          </asp:LinkButton>
        </div>
        <div class="col-md-1">
          <asp:LinkButton runat="server" ID="btExcel" CausesValidation="false">
            <span class="btn btn-block btn-info btn-sm"><i class="fa  fa-file-excel-o"></i></span>
          </asp:LinkButton>
        </div>
      </div>
    </div>
  </div>

  <section class="content" runat="server" id="secctionCrear">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Introducción y Base Legal</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaIntroBaseLegal" CausesValidation="false" OnClick="nuevaIntroBaseLegal_Click">
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
          <div class="card card-outline card-primary" runat="server" id="mostrarIntroBaseLegal">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">AGREGAR <%: Title %></span></h3>
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
                  <asp:Label runat="server" ID="lblIntroduccion" AssociatedControlID="TxtIntroduccion" CssClass="control-label">INTRODUCCIÓN</asp:Label>
                  <textarea runat="server" id="TxtIntroduccion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir la introduccion" maxlength="250" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validarUno" ControlToValidate="TxtIntroduccion"
                    CssClass="text-danger" ErrorMessage="* La introduccion es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="lblMarco" AssociatedControlID="TxtMarco" CssClass="control-label">MARCO JURÍDICO SORE EL QUE SE DESARROLLA LA FADN</asp:Label>
                  <textarea runat="server" id="TxtMarco" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir el marco juridico" maxlength="250" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validarUno" ControlToValidate="TxtMarco"
                    CssClass="text-danger" ErrorMessage="* El Marco Juridico es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="lblAfiliacion" AssociatedControlID="TxtAfiliacion" CssClass="control-label">AFILIACIONES A ORGANIZACIONES NACIONALES E INTERNACIONALES</asp:Label>
                  <textarea runat="server" id="TxtAfiliacion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir la afiliacion" maxlength="250" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validarUno" ControlToValidate="TxtAfiliacion"
                    CssClass="text-danger" ErrorMessage="* La Afiliacion Organizacional es obligatoria" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearIntroBaseLegal_Click" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearIntroBaseLegal_Click_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarUno" ID="crearIntroBaseLegal" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearIntroBaseLegal_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditIntroBaseLegal">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR <%: Title %></span></h3>
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
                  <asp:Label runat="server" ID="idIntroBase"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtEditIntroduccion" CssClass="control-label">INTRODUCCIÓN</asp:Label>
                  <textarea runat="server" id="txtEditIntroduccion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir la introduccion" maxlength="250" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validar" ControlToValidate="txtEditIntroduccion"
                    CssClass="text-danger" ErrorMessage="* La introduccion es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditMarco" CssClass="control-label">MARCO JURÍDICO SORE EL QUE SE DESARROLLA LA FADN</asp:Label>
                  <textarea runat="server" id="txtEditMarco" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir el marco juridico" maxlength="250" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validar" ControlToValidate="txtEditMarco"
                    CssClass="text-danger" ErrorMessage="* El Marco Juridico es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditAfiliacion" CssClass="control-label">AFILIACIONES A ORGANIZACIONES NACIONALES E INTERNACIONALES</asp:Label>
                  <textarea runat="server" id="txtEditAfiliacion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir la afiliacion" maxlength="250" autofocus required></textarea>
                  <asp:RequiredFieldValidator runat="server" ValidationGroup="validar" ControlToValidate="txtEditAfiliacion"
                    CssClass="text-danger" ErrorMessage="* La Afiliacion Organizacional es obligatoria" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditIntroBaseLegal" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditIntroBaseLegal_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditIntroBaseLegal" ID="editIntroBaseLegal" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editIntroBaseLegal_Click">
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
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idIntroObservacionRechazo"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacion" CssClass="control-label">OBSERVACIÓN</asp:Label>
                  <textarea runat="server" id="txtCrearObservacion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="observación" maxlength="250" autofocus required></textarea>
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
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idIntroObservacionSinRechazo"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtCrearObservacionSinRechazo" CssClass="control-label">OBSERVACIÓN</asp:Label>
                  <textarea runat="server" id="txtCrearObservacionSinRechazo" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="observación" maxlength="250" autofocus required></textarea>
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
              <asp:GridView ID="gridFADN" runat="server" AutoGenerateColumns="False" DataKeyNames="numero"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridFADN_RowCommand">
                <Columns>
                  <asp:BoundField DataField="numero" ShowHeader="false" />
                  <asp:BoundField DataField="introduccion" HeaderText="INTRODUCCIÓN">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="marco" HeaderText="MARCO JURÍDICO">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="afiliacion" HeaderText="AFILIACIÓN ORGANIZACIONAL">
                    <ItemStyle Width="302px" />
                  </asp:BoundField>
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

              <asp:GridView ID="gridCEFADN" runat="server" AutoGenerateColumns="False" DataKeyNames="numero"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridCEFADN_RowCommand">
                <Columns>
                  <asp:BoundField DataField="numero" ShowHeader="false" />
                  <asp:BoundField DataField="introduccion" HeaderText="INTRODUCCIÓN">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="marco" HeaderText="MARCO JURÍDICO">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="afiliacion" HeaderText="AFILIACIÓN ORGANIZACIONAL">
                    <ItemStyle Width="302px" />
                  </asp:BoundField>
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

              <asp:GridView ID="gridAcompaniamiento" runat="server" AutoGenerateColumns="False" DataKeyNames="numero"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridAcompaniamiento_RowCommand">
                <Columns>
                  <asp:BoundField DataField="numero" ShowHeader="false" />
                  <asp:BoundField DataField="introduccion" HeaderText="INTRODUCCIÓN">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="marco" HeaderText="MARCO JURÍDICO">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="afiliacion" HeaderText="AFILIACIÓN ORGANIZACIONAL">
                    <ItemStyle Width="302px" />
                  </asp:BoundField>
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

              <asp:GridView ID="gridEvaluacion" runat="server" AutoGenerateColumns="False" DataKeyNames="numero"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridEvaluacion_RowCommand">
                <Columns>
                  <asp:BoundField DataField="numero" ShowHeader="false" />
                  <asp:BoundField DataField="introduccion" HeaderText="INTRODUCCIÓN">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="marco" HeaderText="MARCO JURÍDICO">
                    <ItemStyle Width="310px" />
                  </asp:BoundField>
                  <asp:BoundField DataField="afiliacion" HeaderText="AFILIACIÓN ORGANIZACIONAL">
                    <ItemStyle Width="302px" />
                  </asp:BoundField>
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
                  <h3 class="card-title" style="text-align: right;"><span class="info-box-number">Primer Nivel</span></h3>
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
                  <h3 class="card-title" style="text-align: right;"><span class="info-box-number">Segundo Nivel</span></h3>
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
                  <h3 class="card-title" style="text-align: right;"><span class="info-box-number">Tercer Nivel</span></h3>
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
