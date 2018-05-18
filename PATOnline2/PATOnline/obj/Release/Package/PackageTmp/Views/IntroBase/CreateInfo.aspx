<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateInfo.aspx.cs" Inherits="PATOnline.Views.IntroBase.Create" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="row">
  <!-- Modal content-->
  <div class="row modal-content">
    <div class="modal-header gradiant">
      <h4 class="modal-title">
        <asp:Label runat="server" ID="lblModal"></asp:Label></h4>
    </div>
    <div class="modal-body">
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblIntroduccion" AssociatedControlID="TxtIntroduccion" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtIntroduccion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir la introduccion" maxlength="250" autofocus required></textarea>         
           <asp:RequiredFieldValidator runat="server" ValidationGroup="validar" ControlToValidate="TxtIntroduccion"
            CssClass="text-danger" ErrorMessage="* La introduccion es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblMarco" AssociatedControlID="TxtMarco" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtMarco" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir el marco juridico" maxlength="250" autofocus required></textarea>
          <asp:RequiredFieldValidator runat="server" ValidationGroup="validar"  ControlToValidate="TxtMarco"
            CssClass="text-danger" ErrorMessage="* El Marco Juridico es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblAfiliacion" AssociatedControlID="TxtAfiliacion" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtAfiliacion" class="form-control" type="text" onkeypress="return descripcion(event)" minlength="4" placeholder="escribir la afiliacion" maxlength="250" autofocus required></textarea>
          <asp:RequiredFieldValidator runat="server" ValidationGroup="validar" ControlToValidate="TxtAfiliacion"
            CssClass="text-danger" ErrorMessage="* La Afiliacion Organizacional es obligatoria" />
        </div>
      </div>
      <div style="text-align: center">
        <asp:LinkButton runat="server" ValidationGroup="validar" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
                                <span class="glyphicon glyphicon-floppy-disk"></span>
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="Cancel" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" PostBackUrl="~/Views/IntroBase/IntroduccionBasesLegales.aspx" CausesValidation="false">
                                <span class="glyphicon glyphicon-ban-circle"></span>
        </asp:LinkButton>
      </div>
    </div>
  </div>
</div>
</asp:Content>
