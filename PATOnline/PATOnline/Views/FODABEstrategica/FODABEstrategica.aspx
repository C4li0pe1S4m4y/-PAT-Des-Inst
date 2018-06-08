<%@ Page Title="FODA - BASE ESTRATÉGICA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FODABEstrategica.aspx.cs" Inherits="PATOnline.Views.FODA.FODA" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item">Dashboard</li>
            <li class="breadcrumb-item active">FODA y Base Estratégica</li>
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

  <section class="content" runat="server" id="vistaPreviaFODABE">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-error">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">VISTA PREVIA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <h1 style="text-align: center;"><b>FODA</b></h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" CssClass="control-label">FORTALEZAS</asp:Label>
                  <asp:TextBox runat="server" ID="txtPreviewFortaleza" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" CssClass="control-label">OPORTUNIDADES</asp:Label>
                  <asp:TextBox runat="server" ID="txtPreviewOportunida" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" CssClass="control-label">DEBILIDADES</asp:Label>
                  <asp:TextBox runat="server" ID="txtPreviewDebilidad" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" CssClass="control-label">AMENAZAS</asp:Label>
                  <asp:TextBox runat="server" ID="txtPreviewAmenaza" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
              </div>
              <br />
              <div class="row">
                <div class="col-md-12">
                  <h1 style="text-align: center;"><b>BASE ESTRATÉGICA</b></h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" CssClass="control-label">VISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtPreviewVision" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" CssClass="control-label">MISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtPreviewMision" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" CssClass="control-label">VALOR</asp:Label>
                  <asp:TextBox runat="server" ID="txtPreviewValor" CssClass="form-control" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </div>
              </div>


              <div class="card-footer">
                <asp:LinkButton runat="server" ID="cancelVistaPrevia" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelVistaPrevia_Click">
                <span class="fa fa-close"></span>
                </asp:LinkButton>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content" runat="server" id="crearFODABENew">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">FODA y Base Estratégica</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoFODABE" CausesValidation="false" OnClick="nuevoFODABE_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearFODABE">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO FODA Y BASE ESTRATÉGICA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <h1 style="text-align: center;"><b>FODA</b></h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearFortalezaFODABE" CssClass="control-label"><span style="color:red">*</span> FORTALEZAS</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearFortalezaFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la fortaleza" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFODABE" runat="server" ControlToValidate="txtCrearFortalezaFODABE"
                    CssClass="text-danger" ErrorMessage="* La Fortaleza es obligatoria" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearOportunidadFODABE" CssClass="control-label"><span style="color:red">*</span> OPORTUNIDADES</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearOportunidadFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la oportunidad" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFODABE" runat="server" ControlToValidate="txtCrearOportunidadFODABE"
                    CssClass="text-danger" ErrorMessage="* La Oportunidad es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearDebilidadFODABE" CssClass="control-label"><span style="color:red">*</span> DEBILIDADES</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearDebilidadFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la debilidad" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFODABE" runat="server" ControlToValidate="txtCrearDebilidadFODABE"
                    CssClass="text-danger" ErrorMessage="* La Debilidad es obligatoria" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtCrearAmenazaFODABE" CssClass="control-label"><span style="color:red">*</span> AMENAZAS</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearAmenazaFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la amenaza" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFODABE" runat="server" ControlToValidate="txtCrearAmenazaFODABE"
                    CssClass="text-danger" ErrorMessage="* La Amenaza es obligatoria" />
                </div>
              </div>
              <br />
              <div class="row">
                <div class="col-md-12">
                  <h1 style="text-align: center;"><b>BASE ESTRATÉGICA</b></h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearVisionFODABE" CssClass="control-label"><span style="color:red">*</span> VISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearVisionFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la visión" MaxLength="1500"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFODABE" runat="server" ControlToValidate="txtCrearVisionFODABE"
                    CssClass="text-danger" ErrorMessage="* La Visión es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearMisionFODABE" CssClass="control-label"><span style="color:red">*</span> MISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearMisionFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la misión" MaxLength="1500"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFODABE" runat="server" ControlToValidate="txtCrearMisionFODABE"
                    CssClass="text-danger" ErrorMessage="* La Misión es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtCrearValorFODABE" CssClass="control-label"><span style="color:red">*</span> MISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtCrearValorFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir el valor" MaxLength="1500"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFODABE" runat="server" ControlToValidate="txtCrearValorFODABE"
                    CssClass="text-danger" ErrorMessage="* La Valor es obligatoria" />
                </div>
              </div>


              <div class="card-footer">
                <asp:LinkButton runat="server" ID="cancelCrearFODABE" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearFODABE_Click">
                <span class="fa fa-close"></span>
                </asp:LinkButton>
                <asp:LinkButton runat="server" ValidationGroup="validarCrearFODABE" ID="crearFODABE" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearFODABE_Click">
                <span class="fa fa-save"></span>
                </asp:LinkButton>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditFODABE">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR FODA Y BASE ESTRATÉGICA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <h1 style="text-align: center;"><b>FODA</b></h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" ID="idEditFODABE"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="txtEditFortalezaFODABE" CssClass="control-label"><span style="color:red">*</span> FORTALEZAS</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditFortalezaFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la fortaleza" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFODABE" runat="server" ControlToValidate="txtEditFortalezaFODABE"
                    CssClass="text-danger" ErrorMessage="* La Fortaleza es obligatoria" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditOportunidadFODABE" CssClass="control-label"><span style="color:red">*</span> OPORTUNIDADES</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditOportunidadFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la oportunidad" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFODABE" runat="server" ControlToValidate="txtEditOportunidadFODABE"
                    CssClass="text-danger" ErrorMessage="* La Oportunidad es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditDebilidadFODABE" CssClass="control-label"><span style="color:red">*</span> DEBILIDADES</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditDebilidadFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la debilidad" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFODABE" runat="server" ControlToValidate="txtEditDebilidadFODABE"
                    CssClass="text-danger" ErrorMessage="* La Debilidad es obligatoria" />
                </div>
                <div class="col-md-6">
                  <asp:Label runat="server" AssociatedControlID="txtEditAmenazaFODABE" CssClass="control-label"><span style="color:red">*</span> AMENAZAS</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditAmenazaFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la amenaza" MaxLength="3500" Height="350px"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFODABE" runat="server" ControlToValidate="txtEditAmenazaFODABE"
                    CssClass="text-danger" ErrorMessage="* La Amenaza es obligatoria" />
                </div>
              </div>
              <br />
              <div class="row">
                <div class="col-md-12">
                  <h1 style="text-align: center;"><b>BASE ESTRATÉGICA</b></h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditVisionFODABE" CssClass="control-label"><span style="color:red">*</span> VISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditVisionFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la visión" MaxLength="1500"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFODABE" runat="server" ControlToValidate="txtEditVisionFODABE"
                    CssClass="text-danger" ErrorMessage="* La Visión es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditMisionFODABE" CssClass="control-label"><span style="color:red">*</span> MISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditMisionFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir la misión" MaxLength="1500"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFODABE" runat="server" ControlToValidate="txtEditMisionFODABE"
                    CssClass="text-danger" ErrorMessage="* La Misión es obligatoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="txtEditValorFODABE" CssClass="control-label"><span style="color:red">*</span> MISIÓN</asp:Label>
                  <asp:TextBox runat="server" ID="txtEditValorFODABE" CssClass="form-control" TextMode="MultiLine" Text="escribir el valor" MaxLength="1500"></asp:TextBox>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFODABE" runat="server" ControlToValidate="txtEditValorFODABE"
                    CssClass="text-danger" ErrorMessage="* La Valor es obligatoria" />
                </div>
              </div>


              <div class="card-footer">
                <asp:LinkButton runat="server" ID="cancelEditFODABE" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditFODABE_Click">
                <span class="fa fa-close"></span>
                </asp:LinkButton>
                <asp:LinkButton runat="server" ValidationGroup="validarEditFODABE" ID="editFODABE" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editFODABE_Click">
                <span class="fa fa-save"></span>
                </asp:LinkButton>
              </div>
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
                  <asp:TextBox runat="server" ID="txtCrearObservacion" CssClass="form-control" TextMode="MultiLine" MaxLength="1000" Text="observación"></asp:TextBox>
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
                  <asp:TextBox runat="server" ID="txtCrearObservacionSinRechazo" CssClass="form-control" TextMode="MultiLine" Text="observación" MaxLength="1000"></asp:TextBox>
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
              <h3 class="card-title"><span class="info-box-number">FODA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <div class="col-md-12">
                <asp:GridView ID="gridFODABE" runat="server" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gridFODABE_RowDataBound"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridFODABE_RowCommand">
                  <Columns>
                    <asp:BoundField DataField="numero" ShowHeader="false" />
                    <asp:BoundField DataField="fortaleza" HeaderText="FORTALEZA" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="oportunidad" HeaderText="OPORTUNIDAD" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="debilidad" HeaderText="DÉBILIDAD" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="amenaza" HeaderText="AMENAZA" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="vision" HeaderText="VISIÓN" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="mision" HeaderText="MISIÓN" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="valor" HeaderText="VALOR" ItemStyle-Width="14%" ItemStyle-HorizontalAlign="Center" />
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
                        <asp:LinkButton ID="btPreview" runat="server" type="button" class="btn btn-block btn-info btn-sm" CausesValidation="false"
                          CommandName="Previa" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                  <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-th-large"></span>
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

