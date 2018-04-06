<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateInfo.aspx.cs" Inherits="PATOnline.Views.IntroBase.Create" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <!-- Modal content-->
  <div class="modal-content">
    <div class="modal-header gradiant">
      <h4 class="modal-title black">
        <asp:Label runat="server" ID="lblModal"></asp:Label></h4>
    </div>
    <div class="modal-body">
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblIntroduccion" AssociatedControlID="TxtIntroduccion" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtIntroduccion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtIntroduccion"
            CssClass="text-danger" ErrorMessage="* La introduccion es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblMarco" AssociatedControlID="TxtMarco" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtMarco" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtMarco"
            CssClass="text-danger" ErrorMessage="* El Marco Juridico es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblAfiliacion" AssociatedControlID="TxtAfiliacion" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtAfiliacion" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtAfiliacion"
            CssClass="text-danger" ErrorMessage="* La Afiliacion Organizacional es obligatoria" />
        </div>
      </div>
      <div style="text-align: center">
        <asp:LinkButton runat="server" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
                                <span class="glyphicon glyphicon-floppy-disk"></span>
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="Cancel" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" PostBackUrl="~/Views/IntroBase/IntroduccionBasesLegales.aspx" CausesValidation="false">
                                <span class="glyphicon glyphicon-ban-circle"></span>
        </asp:LinkButton>
      </div>
    </div>
  </div>
</asp:Content>
