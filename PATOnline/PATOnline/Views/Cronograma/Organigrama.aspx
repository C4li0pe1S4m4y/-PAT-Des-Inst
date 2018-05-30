<%@ Page Title="ORGANIGRAMA INSTITUCIONAL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Organigrama.aspx.cs" Inherits="PATOnline.Views.Cronograma.Cronograma" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-12">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
      </div>
    </div>
  </div>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Organigrama</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoOrganigrama" CausesValidation="false" OnClick="nuevoOrganigrama_Click">
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
          <div class="card card-outline card-info" runat="server" id="mostrarCrearOrganigrama">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">CREAR NUEVO ORGANIGRAMA</span></h3>
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
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="FileUpload1" CssClass="control-label">Subir Archivo</asp:Label>
                  <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                  <asp:RegularExpressionValidator ID="REGEXFileUploadLogo" runat="server" ValidationGroup="validarCrearOrganigrama"
                    ErrorMessage="Solo se permiten imagenes .jpeg, .png,.jpg" ControlToValidate="FileUpload1"
                    ValidationExpression="(.*).(.png).(.jpeg).(.jpg)$" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearOrganigrama" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearOrganigrama_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarCrearOrganigrama" ID="crearOrganigrama" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearOrganigrama_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditarOrganigrama">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR ORGANIGRAMA</span></h3>
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
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idOrganigrama"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="FileUpload2" CssClass="control-label">Subir Archivo</asp:Label>
                  <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                  <asp:RegularExpressionValidator runat="server" ValidationGroup="validarEditOrganigrama"
                    ErrorMessage="Solo se permiten imagenes .jpeg, .png, .jpg" ControlToValidate="FileUpload2"
                    ValidationExpression="(.*).(.png).(.jpeg).(.jpg)$" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditOrganigrama" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditOrganigrama_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditOrganigrama" ID="editOrganigrama" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editOrganigrama_Click">
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
                <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging" PageSize="2"
                  CssClass="table table-bordered dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gvListadoInfo_RowCommand">
                  <Columns>
                    <asp:TemplateField HeaderText="ORGANIGRAMA" ItemStyle-Width="100%" ItemStyle-HorizontalAlign="Center">
                      <ItemTemplate>
                        <asp:Image ID="image1" runat="server" ImageUrl='<%# Eval("organigrama") %>' Width="400" Height="400" />
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
    </div>
  </section>
</asp:Content>
