<%@ Page Title="CREAR FODA - BASE ESTRATÉGICA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFODABEstrategica.aspx.cs" Inherits="PATOnline.Views.FODABEstrategica.CreateFODABEstrategica" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="container">
  <!-- Modal content-->
  <div class="modal-content">
    <div class="modal-header gradiant">
      <h4 class="modal-title">
        <asp:Label runat="server" ID="lblModal"></asp:Label></h4>
    </div>
    <div class="modal-body">
      <div class="row" style="text-align:center;">
        <h3> <b> <asp:Label runat="server" ID="lblFODA"></asp:Label> </b> </h3>
      </div>
      <div class="row">
        <div class="col-md-6">
          <asp:Label runat="server" ID="lblfortaleza" AssociatedControlID="TxtFortaleza" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtFortaleza" CssClass="form-control" TextMode="MultiLine" BackColor="#5d82bc"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtFortaleza"
            CssClass="text-danger" ErrorMessage="* La Fortaleza es obligatoria" />
        </div>
        <div class="col-md-6">
          <asp:Label runat="server" ID="lbloportunidad" AssociatedControlID="TxtOportunidad" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtOportunidad" CssClass="form-control" TextMode="MultiLine" BackColor="#5d82bc"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtOportunidad"
            CssClass="text-danger" ErrorMessage="* La Oportunidad es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <asp:Label runat="server" ID="lbldebilidad" AssociatedControlID="TxtDebilidad" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtDebilidad" CssClass="form-control" TextMode="MultiLine" BackColor="#5d82bc"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtDebilidad"
            CssClass="text-danger" ErrorMessage="* La Debilidad es obligatoria" />
        </div>
        <div class="col-md-6">
          <asp:Label runat="server" ID="lblamenaza" AssociatedControlID="TxtAmenaza" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtAmenaza" CssClass="form-control" TextMode="MultiLine" BackColor="#5d82bc"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtAmenaza"
            CssClass="text-danger" ErrorMessage="* La Amenaza es obligatoria" />
        </div>
      </div>

      <div class="row" style="text-align:center;">
        <h3> <b> <asp:Label runat="server" ID="lblBEstrategica"></asp:Label> </b> </h3>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblvision" AssociatedControlID="TxtVision" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtVision" CssClass="form-control" TextMode="MultiLine" BackColor="#5d82bc"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtVision"
            CssClass="text-danger" ErrorMessage="* La Vision es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblmision" AssociatedControlID="TxtMision" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtMision" CssClass="form-control" TextMode="MultiLine" BackColor="#5d82bc"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtMision"
            CssClass="text-danger" ErrorMessage="* La Mision es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblvalor" AssociatedControlID="TxtValor" CssClass="control-label"></asp:Label>
          <asp:TextBox runat="server" ID="TxtValor" CssClass="form-control" TextMode="MultiLine" BackColor="#5d82bc"></asp:TextBox>
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtValor"
            CssClass="text-danger" ErrorMessage="* El Valor es obligatoria" />
        </div>
      </div>

      <div style="text-align: center">
        <asp:LinkButton runat="server" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
                                <span class="glyphicon glyphicon-floppy-disk"></span>
        </asp:LinkButton>
        <asp:LinkButton runat="server" ID="Cancel" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" PostBackUrl="~/Views/FODABEstrategica/FODABEstrategica.aspx" CausesValidation="false">
                                <span class="glyphicon glyphicon-ban-circle"></span>
        </asp:LinkButton>
      </div>
    </div>
  </div>
</div>
</asp:Content>
