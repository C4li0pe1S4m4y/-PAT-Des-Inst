<%@ Page Title="LOGRO Y BRECHA - CREAR ANALISIS SOBRE PUESTOS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPuesto.aspx.cs" Inherits="PATOnline.Views.LogroBrecha.CrearPuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title white">
            <asp:Label runat="server" ID="lblTitulo"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <div class="row">
            <div class="col-md-6">
              <asp:Label runat="server" AssociatedControlID="DropAnio" CssClass="control-label">AÑO</asp:Label>
              <asp:DropDownList runat="server" ID="DropAnio" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="Puesto" runat="server" ControlToValidate="DropAnio"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Año" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPuesto" CssClass="control-label">PUESTO OBTENIDO</asp:Label>
              <input runat="server" id="TxtPuesto" class="form-control" type="text" onkeypress="return numeros(event)" placeholder="ingresar numero" maxlength="3" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="Puesto" runat="server" ControlToValidate="TxtPuesto"
                CssClass="text-danger" ErrorMessage="* El Puesto Obtenido es obligatorio y deber ser menor a 47" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPunteoPuesto" CssClass="control-label">PUNTOS</asp:Label>
              <input runat="server" id="TxtPunteoPuesto" class="form-control" type="text" onkeypress="return numerosypunto(event)" placeholder="ingresar numero" maxlength="8" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="Puesto" runat="server" ControlToValidate="TxtPunteoPuesto"
                CssClass="text-danger" ErrorMessage="* El Punteo es obligatorio y debe ser menor a 1001" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtObservacionPuesto" CssClass="control-label">OBSERVACIONES</asp:Label>
              <textarea runat="server" id="TxtObservacionPuesto" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="escribir la introduccion" maxlength="250" autofocus required></textarea>         
            </div>
          </div>
        </div>
        <div class="modal-footer gradiant-inver">
          <asp:LinkButton runat="server" ValidationGroup="Puesto" ID="SavePuesto" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SavePuesto_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
          </asp:LinkButton>
          <asp:LinkButton runat="server" CausesValidation="false" ID="CancelPuesto" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" OnClick="CancelPuesto_Click">
              <span class="glyphicon glyphicon-ban-circle"></span>
          </asp:LinkButton>
        </div>
      </div>
  </div>
</asp:Content>
