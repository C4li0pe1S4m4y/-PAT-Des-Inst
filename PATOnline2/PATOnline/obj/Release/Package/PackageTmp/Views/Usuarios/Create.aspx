<%@ Page Title="USUARIO - CREAR USUARIO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="PATOnline.Views.Usuarios.Create" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <!-- Modal content-->
  <div class="modal-content">
    <div class="modal-header gradiant">
      <h4 class="modal-title">
        <asp:Label runat="server" ID="lblModal"></asp:Label></h4>
    </div>
    <div class="modal-body">
      <div class="row">
        <div class="col-md-3">
          <label class="control-label">Primer Nombre</label>
          <input runat="server" id="TxtNombre1" name="TxtNombre1" class="form-control" type="text" onkeypress="return letras(event)" placeholder="nombre" maxlength="40" autofocus required />
          <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtNombre1"
            CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />        
        </div>
        <div class="col-md-3">
          <label class="control-label">Segundo Nombre</label>
          <input runat="server" id="TxtNombre2" name="TxtNombre2" class="form-control" type="text" onkeypress="return letras(event)" placeholder="nombre" maxlength="40" autofocus />
        </div>
        <div class="col-md-3">
          <label class="control-label">Primer Apellido</label>
          <input runat="server" id="TxtApellido1" class="form-control" type="text" onkeypress="return letras(event)" placeholder="apellido" maxlength="40" autofocus required />
          <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtApellido1"
            CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
        </div>
        <div class="col-md-3">
          <label class="control-label">Segundo Apellido</label>
          <input runat="server" id="TxtApellido2" class="form-control" type="text" onkeypress="return letras(event)" placeholder="apellido" maxlength="40" autofocus />
        </div>
      </div>
      <div class="row">
        <asp:UpdatePanel ID="UpdatePanelPais" runat="server">
          <ContentTemplate>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="DropPais" CssClass="control-label">País</asp:Label>
              <asp:DropDownList runat="server" ID="DropPais" CssClass="form-control" OnSelectedIndexChanged="DropPais_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropPais"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un País" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="DropDepartamento" CssClass="control-label">Departamento</asp:Label>
              <asp:DropDownList runat="server" ID="DropDepartamento" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropDepartamento"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Departamento" />
            </div>
          </ContentTemplate>
        </asp:UpdatePanel>
        <div class="col-md-6">
          <asp:Label runat="server" CssClass="control-label">Dirección</asp:Label>
          <textarea runat="server" id="TxtDireccion" class="form-control" maxlength="125" placeholder="12a. Ave. 25-50, zona 5, Gimnasio Teodoro Palacios Flores"></textarea>
        </div>
      </div>
      <asp:UpdatePanel ID="UpdatePanelTipoFADN" runat="server">
        <ContentTemplate>
          <div class="row">
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="DropTipoFADN" CssClass="control-label">Tipo FADN</asp:Label>
              <asp:DropDownList runat="server" ID="DropTipoFADN" CssClass="form-control" OnSelectedIndexChanged="DropTipoFADN_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropTipoFADN"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FADN" />
            </div>
            <div class="col-md-9">
              <asp:Label runat="server" AssociatedControlID="DropFADN" CssClass="control-label">Federación / Asociación</asp:Label>
              <asp:DropDownList runat="server" ID="DropFADN" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropFADN"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Federación o Asociación" />
            </div>
          </div>
        </ContentTemplate>
      </asp:UpdatePanel>
      <div class="row">
        <div class="col-md-4">
          <asp:Label runat="server" AssociatedControlID="DropRol" CssClass="control-label">Rol</asp:Label>
          <asp:DropDownList runat="server" ID="DropRol" CssClass="form-control"></asp:DropDownList>
          <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="DropRol"
            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Rol" />
        </div>
        <div class="col-md-3">
          <asp:Label runat="server" AssociatedControlID="TxtUsuario" CssClass="control-label">Usuario</asp:Label>
          <input runat="server" id="TxtUsuario" name="TxtUsuario" class="form-control" type="text" placeholder="UPrueba" onkeypress="return letras(event)" maxlength="10" autofocus required />
          <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtUsuario"
            CssClass="text-danger" ErrorMessage="* El Usuario es obligatorio" />
        </div>
        <div class="col-md-3">
          <asp:Label runat="server" AssociatedControlID="TxtEmail" CssClass="control-label">E-mail</asp:Label>
          <input runat="server" id="TxtEmail" name="TxtEmail" class="form-control" type="text" placeholder="prueba@email.com" maxlength="75" autofocus required />
          <asp:RequiredFieldValidator ValidationGroup="usuario" runat="server" ControlToValidate="TxtEmail"
            CssClass="text-danger" ErrorMessage="* El Correo Electrónico es obligatorio" />
        </div>
        <div class="col-md-2">
          <asp:Label runat="server" AssociatedControlID="TxtTelefono" CssClass="control-label">Teléfono</asp:Label>
          <input runat="server" id="TxtTelefono" name="TxtTelefono" class="form-control" type="text" onkeypress="return numeros(event)" minlength="8" placeholder="0000000" maxlength="8" autofocus />
        </div>
      </div>
      <br />
      <div style="text-align: center">
        <asp:LinkButton runat="server" ValidationGroup="usuario" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
                                <span class="glyphicon glyphicon-floppy-disk"></span>
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="Cancel" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" PostBackUrl="~/Views/Usuarios/Usuario.aspx" CausesValidation="false">
                                <span class="glyphicon glyphicon-ban-circle"></span>
        </asp:LinkButton>
      </div>
    </div>
  </div>
</asp:Content>
