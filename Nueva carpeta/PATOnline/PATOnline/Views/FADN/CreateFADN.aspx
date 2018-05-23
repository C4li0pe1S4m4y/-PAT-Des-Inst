<%@ Page Title="FEDERACIÓN / ASOSIACIÓN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFADN.aspx.cs" Inherits="PATOnline.Views.FADN.CreateFADN" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="row">
    <div class="col-md-12">
      <!-- Nav tabs category -->
      <ul class="nav nav-tabs faq-cat-tabs">
        <!--<li><a href="#faq-cat-1" data-toggle="tab">Federacion/Asociacion</a></li>-->
        <li class="active"><a href="#faq-cat-2" data-toggle="tab">LOGOTIPO</a></li>
      </ul>

      <!-- Tab panes -->
      <div class="tab-content faq-cat-content">
        <div class="tab-pane fade" id="faq-cat-1">
          <div class="panel-group" id="accordion-cat-1">
            <div class="panel panel-default panel-faq">
              <div class="modal-content">
                <div class="modal-header gradiant">
                  <h4 class="modal-title white">
                    <asp:Label runat="server" ID="lblModal2"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="TxtNombre" CssClass="control-label">Nombre</asp:Label>
                      <asp:TextBox runat="server" ID="TxtNombre" CssClass="form-control" TextMode="MultiLine" />
                      <asp:RequiredFieldValidator ValidationGroup="FADN" runat="server" ControlToValidate="TxtNombre"
                        ValidationExpression="a-zZ-A" CssClass="text-danger" ErrorMessage="* El Nombre es obligatoria" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="TxtDireccion" CssClass="control-label">Dirección</asp:Label>
                      <asp:TextBox runat="server" ID="TxtDireccion" CssClass="form-control" TextMode="MultiLine" />
                      <asp:RequiredFieldValidator ValidationGroup="FADN" runat="server" ControlToValidate="TxtDireccion"
                        CssClass="text-danger" ErrorMessage="* La direccion es obligatoria" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="TxtTelefono" CssClass="control-label">Telefono</asp:Label>
                      <asp:TextBox runat="server" ID="TxtTelefono" CssClass="form-control" />
                      <asp:RequiredFieldValidator ValidationGroup="FADN" runat="server" ControlToValidate="TxtTelefono"
                        CssClass="text-danger" ErrorMessage="* El telefono es obligatorio" />
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <asp:Label runat="server" AssociatedControlID="TxtCorreo" CssClass="control-label">Correo Electronico</asp:Label>
                      <asp:TextBox runat="server" ID="TxtCorreo" CssClass="form-control" />
                      <asp:RequiredFieldValidator ValidationGroup="FADN" runat="server" ControlToValidate="TxtCorreo"
                        CssClass="text-danger" ErrorMessage="* El correo electronicos es obligatorio" />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ValidationGroup="FADN" ID="SaveFADN" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveFADN_Click">
                      <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="tab-pane active in fade" id="faq-cat-2">
          <div class="panel-group" id="accordion-cat-2">
            <div class="panel panel-default panel-faq">
              <div class="modal-content">
                <div class="modal-header gradiant">
                  <h4 class="modal-title white">
                    <asp:Label runat="server" ID="lblModal4"></asp:Label></h4>
                </div>

                    <div class="modal-body">
                      <div class="row">
                        <div class="col-md-12">
                          <asp:Label runat="server" AssociatedControlID="DropTipo" CssClass="control-label">TIPO FADN</asp:Label>
                          <asp:DropDownList runat="server" ID="DropTipo" CssClass="form-control" OnSelectedIndexChanged="DropTipo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                          <asp:RequiredFieldValidator ValidationGroup="FADN" runat="server" ControlToValidate="DropTipo"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo FDN o ADN" />
                        </div>
                      </div>
                      <div class="row">
                        <div class="col-md-12">
                          <asp:Label runat="server" AssociatedControlID="DropFADN" CssClass="control-label">FEDERACIÓN / ASOSIACIÓN</asp:Label>
                          <asp:DropDownList runat="server" ID="DropFADN" CssClass="form-control"></asp:DropDownList>

                          <asp:RequiredFieldValidator ValidationGroup="Logo" runat="server" ControlToValidate="DropFADN"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una FDN o ADN" />
                        </div>
                      </div>
                      <div class="row">
                        <div class="col-md-12">
                          <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" Height="110" />
                          <asp:RegularExpressionValidator ValidationGroup="Logo" ID="REGEXFileUploadLogo" runat="server"
                            ErrorMessage="Solo se permiten imagenes .png" ControlToValidate="FileUpload2"
                            ValidationExpression="(.*).(.png)$" />
                        </div>
                      </div>
                      <br />
                      <div style="text-align: center">
                        <asp:LinkButton runat="server" ValidationGroup="Logo" ID="SaveLogo" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveLogo_Click">
                      <span class="glyphicon glyphicon-floppy-disk"></span>
                        </asp:LinkButton>
                      </div>
                    </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
