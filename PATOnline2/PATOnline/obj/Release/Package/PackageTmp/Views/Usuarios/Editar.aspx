<%@ Page Title="Editar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="PATOnline.Views.Usuarios.Editar" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header gradiant">                       
                        <h4 class="modal-title black"><asp:label runat="server" ID="lblModal"></asp:label></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                          <div class="col-sm-3">
                              <asp:Label runat="server" AssociatedControlID="TxtNombre1" CssClass="control-label">Primer Nombre</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtNombre1" CssClass="form-control"/>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtNombre1"
                                CssClass="text-danger" ErrorMessage="* El Primer Nombre es obligatorio" />
                            </div>
                          </div>
                          <div class="col-sm-3">
                              <asp:Label runat="server" AssociatedControlID="TxtNombre2" CssClass="control-label">Segundo Nombre</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtNombre2" CssClass="form-control" />
                            </div>
                          </div>
                          <div class="col-sm-3">
                              <asp:Label runat="server" AssociatedControlID="TxtApellido1" CssClass="control-label">Primer Apellido</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtApellido1" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtApellido1"
                                CssClass="text-danger" ErrorMessage="* El Primer Apellido es obligatorio" />
                            </div>
                          </div>
                          <div class="col-sm-3">
                              <asp:Label runat="server" AssociatedControlID="TxtApellido2" CssClass="control-label">Segundo Apellido</asp:Label>                
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtApellido2" CssClass="form-control" />
                            </div>
                          </div>
                        </div> 
                        <div class="row">
                          <div class="col-sm-3">
                              <asp:Label runat="server" AssociatedControlID="DropPais" CssClass="control-label">País</asp:Label>
                            <div class="col-md-10">
                                <asp:DropDownList runat="server" ID="DropPais" CssClass="form-control" OnSelectedIndexChanged="DropPais_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropPais"
                                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un País" />
                            </div>
                          </div>
                          <div class="col-sm-3">
                              <asp:Label runat="server" AssociatedControlID="DropDepartamento" CssClass="control-label">Departamento</asp:Label>
                            <div class="col-md-10">
                                <asp:DropDownList runat="server" ID="DropDepartamento" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDepartamento"
                                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Departamento" />
                            </div>
                          </div>
                          <div class="col-sm-3">
                              <asp:Label runat="server" AssociatedControlID="TxtDireccion" CssClass="control-label">Dirección</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtDireccion" Width="100%" CssClass="form-control" />
                            </div>
                          </div>
                          <div class="col-sm-3">
                            <div class="col-md-6">
                              <asp:Label runat="server" AssociatedControlID="TxtTelefono" CssClass="control-label">Teléfono</asp:Label>                      
                              <asp:TextBox runat="server" ID="TxtTelefono" CssClass="form-control" />
                            </div>
                          </div>
                        </div>
                        <div class="row">
                          <div class="col-sm-4">
                              <asp:Label runat="server" AssociatedControlID="DropTipoFADN" CssClass="control-label">Tipo FADN</asp:Label>
                            <div class="col-md-10">
                                <asp:DropDownList runat="server" ID="DropTipoFADN" CssClass="form-control" OnSelectedIndexChanged="DropTipoFADN_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropTipoFADN"
                                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FADN" />
                            </div>
                          </div>
                          <div class="col-sm-5">
                              <asp:Label runat="server" AssociatedControlID="DropFADN" CssClass="control-label">Federación / Asociación</asp:Label>
                            <div class="col-md-12">
                                <asp:DropDownList runat="server" ID="DropFADN" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropFADN"
                                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Federación o Asociación" />
                            </div>
                          </div>
                          <div class="col-sm-3">
                            <div class="col-md-10">
                              <asp:Label runat="server" AssociatedControlID="DropRol" CssClass="control-label">Rol</asp:Label>
                                <asp:DropDownList runat="server" ID="DropRol" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropRol"
                                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Rol" />
                            </div>
                          </div>
                        </div> 
                        <div class="row">
                          <div class="col-sm-4">
                              <asp:Label runat="server" AssociatedControlID="TxtEmail" CssClass="control-label">E-mail</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control" TextMode="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtEmail"
                                CssClass="text-danger" ErrorMessage="* El Correo Electrónico es obligatorio" />
                            </div>
                          </div>
                          <div class="col-sm-4">
                              <asp:Label runat="server" AssociatedControlID="TxtPassword" CssClass="control-label">Password</asp:Label>
                            <div class="col-md-12">
                                <asp:TextBox runat="server" ID="TxtPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtPassword"
                                CssClass="text-danger" ErrorMessage="* El Password es obligatorio" />
                            </div>
                          </div>
                          <div class="col-sm-4">  
                              <asp:Label runat="server" AssociatedControlID="TxtConfirPassword" CssClass="control-label">Confirmar Password</asp:Label>
                            <div class="col-md-12">
                                <asp:TextBox runat="server" ID="TxtConfirPassword" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtConfirPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="La Confirmación de Password es obligatoria" />
                                <asp:CompareValidator runat="server" ControlToCompare="TxtPassword" ControlToValidate="TxtConfirPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="El Password y la Confirmación no coinciden" />
                            </div>
                          </div>
                        </div>
                        <div style="text-align:center">
                            <asp:LinkButton runat="server" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click" >
                                <span class="glyphicon glyphicon-floppy-disk"></span>
                            </asp:LinkButton>
                        </div>                     
                    </div>
                </div>
 </asp:Content>
