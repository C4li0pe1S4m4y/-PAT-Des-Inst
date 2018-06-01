<%@ Page Title="USUARIO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="PATOnline.Views.Usuarios.Usuario" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item">Home</li>
            <li class="breadcrumb-item active">Usuario</li>
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
              <span class="info-box-number">Nuevo Usuario</span>
            </div>
            <a href="Create.aspx"><span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span></a>
          </div>
        </div>
        <div class="col-md-9" runat="server" id="MostrarUsuario">
          <div class="card">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">INFORMACIÓN SELECCIONADA</span></h3>

              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <asp:LinkButton runat="server" ID="cerrar" CssClass="btn btn-tool" OnClick="cerrar_Click">
                  <i class="fa fa-times"></i>
                </asp:LinkButton>
              </div>
            </div>
            <div class="card-body">
              <div class="row">
                <div class="col-md-6">
                  <div class="info-box-content">
                    <span class="info-box-number">Nombre Completo: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="Nombrelbl"></asp:Label>
                    <span class="info-box-number">Usuario: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="Usuariolbl"></asp:Label>
                    <span class="info-box-number">Federación o Asociación: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="FAlbl"></asp:Label>
                    <span class="info-box-number">Dirección: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="Direccionlbl"></asp:Label>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="info-box-content">
                    <span class="info-box-number">Correo Electrónico: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="Correolbl"></asp:Label>
                    <span class="info-box-number">Teléfono: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="Telefonolbl"></asp:Label>
                    <span class="info-box-number">Rol: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="Rollbl"></asp:Label>
                    <span class="info-box-number">Estado: </span>
                    <span class="fa fa-circle-o text-info"></span>
                    <asp:Label runat="server" ID="Estadolbl"></asp:Label>
                  </div>
                </div>
              </div>
            </div>
            <div class="card-footer bg-white p-0">
            </div>
          </div>
        </div>
      </div>

      <div class="card card-warning" runat="server" id="ModificarInformacion">
        <div class="card-header" style="text-align: center;">
          <h3 class="card-title">MODIFICAR INFORMACIÓN</h3>
        </div>
        <div class="card-body">
          <asp:Label runat="server" ID="idEditar"></asp:Label>
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

          <div class="row">
            <div class="col-md-12">
              <label class="control-label">Dirección</label>
              <asp:TextBox runat="server" CssClass="form-control" ID="EditarDireccion" TextMode="MultiLine"></asp:TextBox>
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
          <asp:LinkButton runat="server" ID="Cancel" type="button" class="btn btn-info btn-outline-danger btn-lg" OnClick="Cancel_Click" CausesValidation="false">
            <span class="fa fa-close"></span>
          </asp:LinkButton>
          <asp:LinkButton runat="server" ValidationGroup="usuario" ID="Save" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="Save_Click">
            <span class="fa fa-save"></span>
          </asp:LinkButton>
        </div>
      </div>

      <div class="card card-success">
        <div class="card-header" style="text-align: center;">
          <h3 class="card-title">USUARIOS INGRESADOS</h3>
        </div>
        <div class="card-body" style="overflow-x: auto;">
          <asp:GridView ID="gvListadoUsuarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoUsuarios_PageIndexChanging"
            CssClass="table table-bordered table-responsive dataTable" OnRowCommand="gvListadoUsuarios_RowCommand" HeaderStyle-BackColor="#e8f2fc" OnRowDataBound="gvListadoUsuarios_RowDataBound">
            <Columns>
              <asp:BoundField DataField="user" HeaderText="USUARIO" HeaderStyle-Font-Size="Medium">
                <ItemStyle Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="nombre_completo" HeaderText="NOMBRE" HeaderStyle-Font-Size="Medium">
                <ItemStyle Width="20%" />
              </asp:BoundField>
              <asp:BoundField DataField="fadn" HeaderText="FEDERACIÓN / ASOCIACIÓN" HeaderStyle-Font-Size="Medium">
                <ItemStyle Width="25%" />
              </asp:BoundField>
              <asp:BoundField DataField="direccion" HeaderText="DOMICILIO" HeaderStyle-Font-Size="Medium">
                <ItemStyle Width="25%" />
              </asp:BoundField>
              <asp:BoundField DataField="correo" HeaderText="CORREO ELECTRÓNICO" HeaderStyle-Font-Size="Medium">
                <ItemStyle Width="10%" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
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
                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-trash-o"></span></span>
                  </asp:LinkButton>
                  <asp:LinkButton ID="btActivar" runat="server" type="button" class="btn btn-block btn-info btn-sm"
                    CommandName="Activar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                    <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-flash"></span></span>
                  </asp:LinkButton>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
