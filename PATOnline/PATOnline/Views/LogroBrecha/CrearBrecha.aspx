<%@ Page Title="LOGRO Y BRECHAS - CREAR ANALISIS DE BRECHAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearBrecha.aspx.cs" Inherits="PATOnline.Views.LogroBrecha.CrearBrecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <!-- Modal content-->
    <div class="row modal-content">
      <div class="modal-header gradiant">
        <h4 class="modal-title">
          <asp:Label runat="server" ID="lblTitulo2"></asp:Label></h4>
      </div>
      <div class="modal-body">
        <div class="row">
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="DropBrecha" CssClass="control-label">BRECHA RESPECTO A:</asp:Label>
            <asp:DropDownList runat="server" ID="DropBrecha" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ValidationGroup="Brecha" runat="server" ControlToValidate="DropBrecha"
              CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Brecha" />
          </div>
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="TxtPuntosBrecha" CssClass="control-label">PUNTOS</asp:Label>
            <input runat="server" id="TxtPuntosBrecha" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="ingresar numero" maxlength="8" autofocus required />
            <asp:RequiredFieldValidator ValidationGroup="Brecha" runat="server" ControlToValidate="TxtPuntosBrecha"
              CssClass="text-danger" ErrorMessage="* El Punteo es obligatorio y debe ser menor que 1,001" />
          </div>
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="TxtPuntosObtenidos" CssClass="control-label">PUNTOS OBTENIDOS POR FADN</asp:Label>
            <input runat="server" id="TxtPuntosObtenidos" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="ingresar numero" maxlength="8" autofocus required />
            <asp:RequiredFieldValidator ValidationGroup="Brecha" runat="server" ControlToValidate="TxtPuntosObtenidos"
              CssClass="text-danger" ErrorMessage="* El Punteo Obtenido por FADN es obligatorio y debe ser menor que 1001" />
          </div>
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="TxtComparacion" CssClass="control-label">COMPARACIONES</asp:Label>
            <input runat="server" id="TxtComparacion" class="form-control" type="text" onkeypress="return numerosypuntomenos(event)" placeholder="ingresar numero" maxlength="12" autofocus required />
            <asp:RequiredFieldValidator ValidationGroup="Brecha" runat="server" ControlToValidate="TxtComparacion"
              CssClass="text-danger" ErrorMessage="* La Comparacion es obligatoria" />
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <asp:Label runat="server" AssociatedControlID="TxtObservacionBrecha" CssClass="control-label">OBSERVACIONES</asp:Label>
            <textarea runat="server" id="TxtObservacionBrecha" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="observaciones" maxlength="250" autofocus required></textarea>         
          </div>
        </div>
      </div>
      <div class="modal-footer gradiant-inver">
        <asp:LinkButton runat="server" ValidationGroup="Brecha" ID="SaveBrecha" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveBrecha_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
        </asp:LinkButton>
        <asp:LinkButton runat="server" CausesValidation="false" ID="CancelBrecha" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" OnClick="CancelBrecha_Click">
              <span class="glyphicon glyphicon-ban-circle"></span>
        </asp:LinkButton>
      </div>
    </div>
  </div>
</asp:Content>
