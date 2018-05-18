<%@ Page Title="CREAR FODA - BASE ESTRATÉGICA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateFODABEstrategica.aspx.cs" Inherits="PATOnline.Views.FODABEstrategica.CreateFODABEstrategica" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<div class="row">
  <!-- Modal content-->
  <div class="row modal-content">
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
          <textarea runat="server" id="TxtFortaleza" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la fortaleza" maxlength="125" autofocus required></textarea>         
          <asp:RequiredFieldValidator runat="server" ControlToValidate="TxtFortaleza"
            CssClass="text-danger" ErrorMessage="* La Fortaleza es obligatoria" />
        </div>
        <div class="col-md-6">
          <asp:Label runat="server" ID="lbloportunidad" AssociatedControlID="TxtOportunidad" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtOportunidad" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la oportunidad" maxlength="125" autofocus required></textarea>         
          <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtOportunidad"
            CssClass="text-danger" ErrorMessage="* La Oportunidad es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <asp:Label runat="server" ID="lbldebilidad" AssociatedControlID="TxtDebilidad" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtDebilidad" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la debilidad" maxlength="125" autofocus required></textarea>         
          <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtDebilidad"
            CssClass="text-danger" ErrorMessage="* La Debilidad es obligatoria" />
        </div>
        <div class="col-md-6">
          <asp:Label runat="server" ID="lblamenaza" AssociatedControlID="TxtAmenaza" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtAmenaza" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la amenaza" maxlength="125" autofocus required></textarea>         
          <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtAmenaza"
            CssClass="text-danger" ErrorMessage="* La Amenaza es obligatoria" />
        </div>
      </div>

      <div class="row" style="text-align:center;">
        <h3> <b> <asp:Label runat="server" ID="lblBEstrategica"></asp:Label> </b> </h3>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblvision" AssociatedControlID="TxtVision" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtVision" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la vision" maxlength="125" autofocus required></textarea>         
          <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtVision"
            CssClass="text-danger" ErrorMessage="* La Vision es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblmision" AssociatedControlID="TxtMision" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtMision" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la mision" maxlength="125" autofocus required></textarea>         
          <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtMision"
            CssClass="text-danger" ErrorMessage="* La Mision es obligatoria" />
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <asp:Label runat="server" ID="lblvalor" AssociatedControlID="TxtValor" CssClass="control-label"></asp:Label>
          <textarea runat="server" id="TxtValor" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir el valor" maxlength="125" autofocus required></textarea>         
          <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtValor"
            CssClass="text-danger" ErrorMessage="* El Valor es obligatoria" />
        </div>
      </div>

      <div style="text-align: center">
        <asp:LinkButton runat="server" ValidationGroup="validar" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
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
