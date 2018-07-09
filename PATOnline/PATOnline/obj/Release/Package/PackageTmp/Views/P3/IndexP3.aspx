<%@ Page Title="P3" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP3.aspx.cs" Inherits="PATOnline.Views.P3.IndexP3" %>

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
            <asp:Label runat="server" ForeColor="Black" Text="P3 - PROYECCIÓN DE EGRESOS POR ACTIVIDAD (Art. 132)"></asp:Label></h5>
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
                      <th style="text-align: center" rowspan="4"><b>ACTIVIDAD CODIFICADA DEL PAT</b></th>
                      <th style="text-align: center" colspan="6"><b>PROPUESTA GENERAL</b></th>
                    </tr>
                    <tr>
                      <th style="text-align: center" colspan="4"><b>PRESUPUESTO CDAG</b></th>
                      <th style="width: 176px; text-align: center" rowspan="3"><b>OTRAS FUENTES</b></th>
                      <th style="width: 180px; text-align: center" rowspan="3"><b>TOTAL GENERAL</b></th>
                    </tr>
                    <tr>
                      <th style="text-align: center"><b>PROMOCIÓN DEPORTIVA (PD)</b></th>
                      <td style="text-align: center"><b>PROGRAMAS TÉCNICOS (PT)</b></td>
                      <td style="text-align: center"><b>ACIVIDADES ADMINISTRATIVAS (AA)</b></td>
                      <td style="width: 176px; text-align: center" rowspan="2"><b>TOTAL</b></td>
                    </tr>
                    <tr>
                      <th style="width: 180px; text-align: center"><b>20</b></th>
                      <th style="width: 180px; text-align: center"><b>30</b></th>
                      <th style="width: 180px; text-align: center"><b>50</b></th>
                    </tr>
                  </table>
                </div>
              </div>
              <asp:UpdatePanel runat="server" ID="cargaGrid">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-12">
                      <asp:GridView ID="gridFADN1" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" Width="1000%" OnRowDataBound="gridFADN1_RowDataBound" OnRowCommand="gridFADN1_RowCommand"
                        CssClass="table table-bordered dataTable" GridLines="None" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false">
                        <HeaderStyle CssClass="gradiant" />
                        <Columns>
                          <asp:BoundField DataField="numero" />
                          <asp:TemplateField>
                            <ItemStyle Width="124px" Font-Size="Small" />
                            <ItemTemplate>
                              <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>'></asp:Label>
                              <br />
                              <br />
                              <asp:LinkButton runat="server" ID="nuevoP3" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Nuevo"
                                data-toggle="tooltip" data-placement="bottom" title="¡Nuevo!" CausesValidation="false">
                            <span class="bg-info btn-lg"><i class="fa fa-plus-circle"></i></span>
                          <br /><br />
                              </asp:LinkButton>
                              <asp:LinkButton runat="server" ID="crearP3" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="CrearP3" ValidationGroup="validar"
                                type="button" class="btn btn-info btn-outline-primary btn-sm float-right" data-toggle="tooltip" data-placement="bottom" title="¡Guardar Nuevo!">
                            <span class="fa fa-save"></span>
                              </asp:LinkButton>
                              <asp:LinkButton runat="server" ID="editP3" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="EditarP3" ValidationGroup="validar"
                                type="button" class="btn btn-info btn-outline-primary btn-sm float-right" data-toggle="tooltip" data-placement="bottom" title="¡Guardar Editar!">
                            <span class="fa fa-save"></span>
                              </asp:LinkButton>
                              <asp:LinkButton runat="server" ID="cancelCrearP3" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="CancelarCrearP3" CausesValidation="false"
                                type="button" class="btn btn-info btn-outline-danger btn-sm" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar Crear!">
                            <span class="fa fa-close"></span>
                              </asp:LinkButton>
                              <asp:LinkButton runat="server" ID="cancelEditP3" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="CancelarEditP3" CausesValidation="false"
                                type="button" class="btn btn-info btn-outline-danger btn-sm" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar Edit!">
                            <span class="fa fa-close"></span>
                              </asp:LinkButton>

                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="154px" Font-Size="Small" />
                            <ItemTemplate>
                              <asp:TextBox ID="TxtPromocion" runat="server" Text='<%# Eval("promocion") %>' CssClass="form-control" MaxLength="12"></asp:TextBox>
                              <asp:RegularExpressionValidator runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                ErrorMessage="Ingrese un monto decimal" ForeColor="Red" ControlToValidate="TxtPromocion" ValidationGroup="validar" />
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="149px" Font-Size="Small" />
                            <ItemTemplate>
                              <asp:TextBox ID="TxtPrograma" runat="server" Text='<%# Eval("programa") %>' CssClass="form-control" MaxLength="12"></asp:TextBox>
                              <asp:RegularExpressionValidator runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                ErrorMessage="Ingrese un monto decimal" ForeColor="Red" ControlToValidate="TxtPrograma" ValidationGroup="validar" />
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="148px" Font-Size="Small" />
                            <ItemTemplate>
                              <asp:TextBox ID="TxtActividad" runat="server" Text='<%# Eval("actividad") %>' CssClass="form-control" MaxLength="12"></asp:TextBox>
                              <asp:RegularExpressionValidator runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                ErrorMessage="Ingrese un monto decimal" ForeColor="Red" ControlToValidate="TxtActividad" ValidationGroup="validar" />
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="143px" />
                            <ItemTemplate>
                              Q <asp:Label ID="TxtSubtotal" runat="server" Text='<%# Eval("subtotal") %>'></asp:Label>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="149px" Font-Size="Small" />
                            <ItemTemplate>
                              <asp:TextBox ID="TxtOtraFuente" runat="server" Text='<%# Eval("otra_fuente") %>' CssClass="form-control" MaxLength="12"></asp:TextBox>
                              <asp:RegularExpressionValidator runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                                ErrorMessage="Ingrese un monto decimal" ForeColor="Red" ControlToValidate="TxtOtraFuente" ValidationGroup="validar" />
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="145px" />
                            <ItemTemplate>
                              <span>Q
                            <asp:Label ID="TxtTotal" runat="server" Text='<%# Eval("total") %>'></asp:Label></span>
                            </ItemTemplate>
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
                              <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-block btn-danger btn-sm" CausesValidation="false"
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
                      <asp:GridView ID="gridFADN2" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" Width="1000%" OnRowDataBound="gridFADN2_RowDataBound"
                        CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" GridLines="None" ShowHeader="false">
                        <Columns>
                          <asp:TemplateField>
                            <ItemTemplate>
                              <asp:Label ID="remarks" runat="server" Text='TOTAL'></asp:Label>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="184px" Font-Size="Small" />
                            <ItemTemplate>
                              <span>Q
                            <asp:Label ID="remarks" runat="server" Text='<%# Eval("total1") %>'></asp:Label></span>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="179px" Font-Size="Small" />
                            <ItemTemplate>
                              <span>Q
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("total2") %>'></asp:Label></span>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="178px" Font-Size="Small" />
                            <ItemTemplate>
                              <span>Q
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("total3") %>'></asp:Label></span>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="169px" Font-Size="Small" />
                            <ItemTemplate>
                              <span>Q
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("total4") %>'></asp:Label></span>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="178px" Font-Size="Small" />
                            <ItemTemplate>
                              <span>Q
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("total5") %>'></asp:Label></span>
                            </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemStyle Width="181px" Font-Size="Small" />
                            <ItemTemplate>
                              <span>Q
                            <asp:Label ID="lblMontoGeneral" runat="server" Text='<%# Eval("total6") %>'></asp:Label></span>
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
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

