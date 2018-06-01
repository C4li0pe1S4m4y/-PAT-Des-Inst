<%@ Page Title="USUARIO - CREAR USUARIO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="PATOnline.Views.Usuarios.Create" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <div class="col-sm-6">
    <h1 class="m-0 text-dark"><%: Title %></h1>
  </div>
  <div class="col-sm-6">
    <ol class="breadcrumb float-sm-right">
      <li class="breadcrumb-item">Home</li>
      <li class="breadcrumb-item">Usuario</li>
      <li class="breadcrumb-item active">Crear Usuario</li>
    </ol>
  </div>
  <section class="content">
    <div class="container-fluid">
      <div class="card card-primary">
        <div class="card-header">
          <h3 class="card-title">
            <asp:Label runat="server" ID="lblModal"></asp:Label></h3>
        </div>
        <div class="card-body">
          <div class="row">
            <div class="col-md-3">
              <label class="control-label"><span style="color: red">*</span> Primer Nombre</label>
              <input runat="server" id="TxtNombre1" name="TxtNombre1" class="form-control" type="text" onkeypress="return letras(event)" placeholder="nombre" maxlength="40" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtNombre1"
                CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
            </div>
            <div class="col-md-3">
              <label class="control-label">Segundo Nombre</label>
              <input runat="server" id="TxtNombre2" name="TxtNombre2" class="form-control" type="text" onkeypress="return letras(event)" placeholder="nombre" maxlength="40" autofocus />
            </div>
            <div class="col-md-3">
              <label class="control-label"><span style="color: red">*</span> Primer Apellido</label>
              <input runat="server" id="TxtApellido1" class="form-control" type="text" onkeypress="return letras(event)" placeholder="apellido" maxlength="40" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtApellido1"
                CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
            </div>
            <div class="col-md-3">
              <label class="control-label">Segundo Apellido</label>
              <input runat="server" id="TxtApellido2" class="form-control" type="text" onkeypress="return letras(event)" placeholder="apellido" maxlength="40" autofocus />
            </div>
          </div>

          <asp:UpdatePanel ID="UpdatePanelTipoFADN" runat="server">
            <ContentTemplate>
              <div class="row">
                <div class="col-md-3">
                  <asp:Label runat="server" AssociatedControlID="DropTipoFADN" CssClass="control-label"><span style="color:red">*</span> Tipo FADN</asp:Label>
                  <asp:DropDownList runat="server" ID="DropTipoFADN" CssClass="form-control" OnSelectedIndexChanged="DropTipoFADN_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropTipoFADN"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FADN" />
                </div>
                <div class="col-md-9">
                  <asp:Label runat="server" AssociatedControlID="DropFADN" CssClass="control-label"><span style="color:red">*</span> Federación / Asociación</asp:Label>
                  <asp:DropDownList runat="server" ID="DropFADN" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropFADN"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Federación o Asociación" />
                </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>

          <div class="row">
            <div class="col-md-4">
              <asp:Label runat="server" AssociatedControlID="DropRol" CssClass="control-label"><span style="color:red">*</span> Rol</asp:Label>
              <asp:DropDownList runat="server" ID="DropRol" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropRol"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Rol" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtUsuario" CssClass="control-label"><span style="color:red">*</span> Usuario</asp:Label>
              <input runat="server" id="TxtUsuario" name="TxtUsuario" class="form-control" type="text" placeholder="UPrueba" onkeypress="return letras(event)" maxlength="10" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtUsuario"
                CssClass="text-danger" ErrorMessage="* El Usuario es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtEmail" CssClass="control-label">E-mail</asp:Label>
              <input runat="server" id="TxtEmail" name="TxtEmail" class="form-control" type="text" placeholder="prueba@email.com" maxlength="75" autofocus required />
            </div>
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="TxtTelefono" CssClass="control-label">Teléfono</asp:Label>
              <input runat="server" id="TxtTelefono" name="TxtTelefono" class="form-control" type="text" onkeypress="return numeros(event)" minlength="8" placeholder="0000000" maxlength="8" autofocus />
            </div>
          </div>
        </div>
        <div class="card-footer">
          <asp:LinkButton runat="server" ID="Cancel" type="button" class="btn btn-info btn-outline-danger btn-lg" PostBackUrl="~/Views/Usuarios/Usuario.aspx" CausesValidation="false">
            <span class="fa fa-close"></span>
          </asp:LinkButton>
          <asp:LinkButton runat="server" ValidationGroup="usuario" ID="Save" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="Save_Click">
            <span class="fa fa-save"></span>
          </asp:LinkButton>
        </div>
      </div>
    </div>
  </section>
</asp:Content>

