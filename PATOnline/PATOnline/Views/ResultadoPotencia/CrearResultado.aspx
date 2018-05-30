<%@ Page Title="POTENCIA Y RESULTADO - CREAR RESULTADO DEPORTIVO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearResultado.aspx.cs" Inherits="PATOnline.Views.ResultadoPotencia.CrearResultado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
      <!-- Modal content-->
      <div class="row modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title">
            <asp:Label runat="server" ID="lblResultado"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <div class="row">
            <div class="col-md-6">
              <asp:Label runat="server" AssociatedControlID="DropNivel" CssClass="control-label">NIVEL</asp:Label>
              <asp:DropDownList runat="server" ID="DropNivel" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="DropNivel"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtCompetencia" CssClass="control-label">NOMBRE DE LA COMPETENCIA</asp:Label>
              <input runat="server" id="TxtCompetencia" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="competencia" maxlength="75" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtCompetencia"
                CssClass="text-danger" ErrorMessage="* La Competencia es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtSede" CssClass="control-label">SEDE</asp:Label>
              <input runat="server" id="TxtSede" class="form-control" type="text" onkeypress="return letrasycomapunto(event)" placeholder="sede" maxlength="75" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtSede"
                CssClass="text-danger" ErrorMessage="* La Sede es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtFecha" CssClass="control-label">FECHA</asp:Label>
              <asp:TextBox runat="server" ID="TxtFecha" CssClass="form-control" TextMode="Date" />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtFecha"
                CssClass="text-danger" ErrorMessage="* La Fecha es obligatoria" />
            </div>
            <div class="col-md-6">
              <asp:Label runat="server" AssociatedControlID="DropCategoria" CssClass="control-label">CATEGORIA</asp:Label>
              <asp:DropDownList runat="server" ID="DropCategoria" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="DropCategoria"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtResultado" CssClass="control-label">RESULTADO OBTENIDO</asp:Label>
              <input runat="server" id="TxtResultado" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="resultado" maxlength="75" autofocus required />
              <asp:RequiredFieldValidator ValidationGroup="Resultado" runat="server" ControlToValidate="TxtResultado"
                CssClass="text-danger" ErrorMessage="* El Resultado Obtenido es obligatorio" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="TxtObservacion" CssClass="control-label">Observacion</asp:Label>
              <textarea runat="server" id="TxtObservacion" class="form-control" type="text" onkeypress="return descripcion(event)" placeholder="observaciones" maxlength="250" autofocus required></textarea>
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
