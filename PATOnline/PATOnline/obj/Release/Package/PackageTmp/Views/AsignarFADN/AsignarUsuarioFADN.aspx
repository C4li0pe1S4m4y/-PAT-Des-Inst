<%@ Page Title="ASIGNAR USUARIO A FADN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarUsuarioFADN.aspx.cs" Inherits="PATOnline.Views.AsignarFADN.AsignarUsuarioFADN" ValidateRequest="false" EnableEventValidation="false" %>

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
            <li class="breadcrumb-item active">Asignar Usuario</li>
          </ol>
        </div>
      </div>
    </div>
  </div>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Asignar</span>
              <span class="info-box-number">Usuario a Federación</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaAsignacinFADN" CausesValidation="false" OnClick="nuevaAsignacinFADN_Click">
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
          <div class="card card-outline card-primary" runat="server" id="mostrarAsignacionFADN">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">AGREGAR USUARIO A FADN</span></h3>
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
                  <asp:Label runat="server" AssociatedControlID="DropUsuario" CssClass="control-label"><span style="color:red">*</span> Usuario</asp:Label>
                  <asp:DropDownList runat="server" ID="DropUsuario" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearAsignacionFADN" runat="server" ControlToValidate="DropUsuario"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Usuario" />
                </div>
              </div>
              <asp:UpdatePanel ID="otroUpdate" runat="server">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="DropTipoFADN" CssClass="control-label"><span style="color:red">*</span> Tipo FADN</asp:Label>
                      <asp:DropDownList runat="server" ID="DropTipoFADN" CssClass="form-control" OnSelectedIndexChanged="DropTipoFADN_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearAsignacionFADN" runat="server" ControlToValidate="DropTipoFADN"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FADN" />
                    </div>
                    <div class="col-md-8">
                      <asp:Label runat="server" AssociatedControlID="DropFADN" CssClass="control-label"><span style="color:red">*</span> Federación / Asociación</asp:Label>
                      <asp:DropDownList runat="server" ID="DropFADN" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarCrearAsignacionFADN" runat="server" ControlToValidate="DropFADN"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Federación o Asociación" />
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelAsignacionFADN" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelAsignacionFADN_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ID="crearAsignacionFADN" ValidationGroup="validarCrearAsignacionFADN" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearAsignacionFADN_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-6">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditAsignacionUsuario">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR INFORMACIÓN</span></h3>
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
                  <asp:Label runat="server" ID="idAsiganacionFADN"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="DropEditUsuario" CssClass="control-label"><span style="color:red">*</span> Usuario</asp:Label>
                  <asp:DropDownList runat="server" ID="DropEditUsuario" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditAsignacionFADN" runat="server" ControlToValidate="DropEditUsuario"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Usuario" />
                </div>
              </div>
              <asp:UpdatePanel ID="EditUpdate" runat="server">
                <ContentTemplate>
                  <div class="row">
                    <div class="col-md-4">
                      <asp:Label runat="server" AssociatedControlID="DropEditTipoFADN" CssClass="control-label"><span style="color:red">*</span> Tipo FADN</asp:Label>
                      <asp:DropDownList runat="server" ID="DropEditTipoFADN" CssClass="form-control" OnSelectedIndexChanged="DropEditTipoFADN_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditAsignacionFADN" runat="server" ControlToValidate="DropEditTipoFADN"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FADN" />
                    </div>
                    <div class="col-md-8">
                      <asp:Label runat="server" AssociatedControlID="DropEditFADN" CssClass="control-label"><span style="color:red">*</span> Federación / Asociación</asp:Label>
                      <asp:DropDownList runat="server" ID="DropEditFADN" CssClass="form-control"></asp:DropDownList>
                      <asp:RequiredFieldValidator ValidationGroup="validarEditAsignacionFADN" runat="server" ControlToValidate="DropEditFADN"
                        CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Federación o Asociación" />
                    </div>
                  </div>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditAsignarUsuario" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditAsignarUsuario_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditIntroBaseLegal" ID="editAsignarUsuario" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editAsignarUsuario_Click">
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
              <h3 class="card-title">MOSTRAR INFORMACIÓN</h3>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvList_PageIndexChanging" PageSize="5"
                CssClass="table table-bordered table-responsive dataTable" OnRowCommand="gvList_RowCommand" HeaderStyle-BackColor="#e8f2fc">
                <Columns>
                  <asp:BoundField DataField="numero" HeaderStyle-Font-Size="Medium" />
                  <asp:BoundField DataField="usuario" HeaderText="EVALUADOR / ACOMPAÑANTE" HeaderStyle-Font-Size="Medium" ItemStyle-Width="20%" />
                  <asp:BoundField DataField="federacion" HeaderText="FEDERACIÓN / ASOCIACIÓN" HeaderStyle-Font-Size="Medium" ItemStyle-Width="70%" />
                  <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                    <ItemTemplate>
                      <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                        CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                      </asp:LinkButton>
                      <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-block btn-danger btn-sm"
                        CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-trash-o"></span></span>
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

