<%@ Page Title="FEDERACIÓN / ASOCIACIÓN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FADN.aspx.cs" Inherits="PATOnline.Views.FADN.FADN" %>

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
            <li class="breadcrumb-item active">Federaciones y Asociaciones</li>
          </ol>
        </div>
      </div>
    </div>
  </div>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Logotipo</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoLogotipo" CausesValidation="false" OnClick="nuevoLogotipo_Click">
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
          <div class="card card-outline card-primary" runat="server" id="mostrarCrearLogotipo">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">AGREGAR LOGOTIPO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <asp:UpdatePanel runat="server" ID="cargarDropCrear">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-3">
                      <asp:Label runat="server" AssociatedControlID="dropCrearTipo" CssClass="control-label"><span style="color:red">*</span> TIPO FADN</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearTipo" CssClass="form-control" OnSelectedIndexChanged="dropCrearTipo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearLogotipo" runat="server" ControlToValidate="dropCrearTipo"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FDN o ADN" />
                    </div>

                    <div class="col-md-9">
                      <asp:Label runat="server" AssociatedControlID="dropCrearFADN" CssClass="control-label"><span style="color:red">*</span> FEDERACIÓN / ASOSIACIÓN</asp:Label>
                      <asp:DropDownList runat="server" ID="dropCrearFADN" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearLogotipo" runat="server" ControlToValidate="dropCrearFADN"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una FDN o ADN" />
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>

              <div class="row">
                <div class="col-md-6">
                  <span style="color:red">*</span> 
                  <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                  <asp:RegularExpressionValidator ValidationGroup="validarCrearLogotipo" ID="REGEXFileUploadLogo" runat="server"
                    ErrorMessage="Solo se permiten imagenes .png" ControlToValidate="FileUpload2"
                    ValidationExpression="(.*).(.png)$" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearLogotipo" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearLogotipo_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearLogotipo" ID="crearLogotipo" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearLogotipo_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditLogotipo">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR LOGOTIPO</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-3">
                      <asp:Label runat="server" ID="idLogotipo"></asp:Label>
                      <asp:Label runat="server" AssociatedControlID="dropEditTipo" CssClass="control-label"><span style="color:red">*</span> TIPO FADN</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditTipo" CssClass="form-control" OnSelectedIndexChanged="dropEditTipo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditLogotipo" runat="server" ControlToValidate="dropEditTipo"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FDN o ADN" />
                    </div>

                    <div class="col-md-9">
                      <asp:Label runat="server" AssociatedControlID="dropEditFADN" CssClass="control-label"><span style="color:red">*</span> FEDERACIÓN / ASOSIACIÓN</asp:Label>
                      <asp:DropDownList runat="server" ID="dropEditFADN" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditLogotipo" runat="server" ControlToValidate="dropEditFADN"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una FDN o ADN" />
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
              <div class="row">
                <div class="col-md-6">
                  <span style="color:red">*</span> 
                  <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" OnPreRender="FileUpload1_PreRender" />
                  <asp:RegularExpressionValidator ValidationGroup="validarEditLogotipo" ID="RegularExpressionValidator1" runat="server"
                    ErrorMessage="Solo se permiten imagenes .png" ControlToValidate="FileUpload1"
                    ValidationExpression="(.*).(.png)$" />

                  <div class="col-md-6">
                    <asp:Image runat="server" ID="precargarLogoEdit" Width="20px" Height="20px" />
                  </div>

                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditLogotipo" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditLogotipo_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditLogotipo" ID="editLogotipo" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editLogotipo_Click">
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
              <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id_fand" OnPageIndexChanging="gvListadoInfo_PageIndexChanging" PageSize="5"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gvListadoInfo_RowCommand">
                <Columns>
                  <asp:BoundField DataField="nombre" HeaderText="FEDERACIÓN" HeaderStyle-Font-Size="Medium">
                    <ItemStyle Width="30%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Direccion" HeaderText="UBICACIÓN" HeaderStyle-Font-Size="Medium">
                    <ItemStyle Width="30%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="telefono" HeaderText="TÉLEFONO" HeaderStyle-Font-Size="Medium">
                    <ItemStyle Width="8%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="correo_electronico" HeaderText="CORREO ELECTRÓNICO" HeaderStyle-Font-Size="Medium"></asp:BoundField>
                  <asp:TemplateField HeaderText="LOGOTIPO">
                    <ItemTemplate>
                      <asp:Image ID="image1" runat="server" ImageUrl='<%# Eval("logo") %>' Width="100" Height="100" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                    <ItemTemplate>
                      <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                        CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
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
</asp:Content>
