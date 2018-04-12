<%@ Page Title="RESULTADOS DEPORTIVOS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearResultado.aspx.cs" Inherits="PATOnline.Views.ResultadoPotencia.CrearResultado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title black">
            <asp:Label runat="server" ID="lblResultado"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="DropNivel" CssClass="control-label">Nivel</asp:Label>
              <asp:DropDownList runat="server" ID="DropNivel" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="DropNivel"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtCompetencia" CssClass="control-label">Nombre de la Competencia</asp:Label>
              <asp:TextBox runat="server" ID="TxtCompetencia" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtCompetencia"
                CssClass="text-danger" ErrorMessage="* La Competencia es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtSede" CssClass="control-label">Sede</asp:Label>
              <asp:TextBox runat="server" ID="TxtSede" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtSede"
                CssClass="text-danger" ErrorMessage="* La Sede es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtFecha" CssClass="control-label">Fecha</asp:Label>
              <asp:TextBox runat="server" ID="TxtFecha" CssClass="form-control" TextMode="Date" />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtFecha"
                CssClass="text-danger" ErrorMessage="* La Fecha es obligatoria" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="DropCategoria" CssClass="control-label">Categoria</asp:Label>
              <asp:DropDownList runat="server" ID="DropCategoria" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="DropCategoria"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtResultado" CssClass="control-label">Resultado Obtenido</asp:Label>
              <asp:TextBox runat="server" ID="TxtResultado" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtResultado"
                CssClass="text-danger" ErrorMessage="* El Resultado Obtenido es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtObservacion" CssClass="control-label">Observacion</asp:Label>
              <asp:TextBox runat="server" ID="TxtObservacion" CssClass="form-control" TextMode="MultiLine" />
            </div>
          </div>
        </div>
        <div class="modal-footer gradiant-inver">
          <asp:LinkButton runat="server" ValidationGroup="Resultado" ID="SaveResultado" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveResultado_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
          </asp:LinkButton>
          <asp:LinkButton runat="server" CausesValidation="false" ID="CancelResultado" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" OnClick="CancelResultado_Click">
              <span class="glyphicon glyphicon-ban-circle"></span>
          </asp:LinkButton>
        </div>
      </div>
  </div>
</asp:Content>
