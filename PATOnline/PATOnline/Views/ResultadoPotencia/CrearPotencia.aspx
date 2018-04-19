<%@ Page Title="POTENCIA Y RESULTADO - CREAR ANÁLISIS DE PRINCIPAL POTENCIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPotencia.aspx.cs" Inherits="PATOnline.Views.ResultadoPotencia.CrearPotencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title">
            <asp:Label runat="server" ID="lblPotencia"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <div class="row">
            <div class="col-md-12">
              <asp:Label runat="server" AssociatedControlID="DropNivel" CssClass="control-label">NIVEL</asp:Label>
              <asp:DropDownList runat="server" ID="DropNivel" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="Potencia" runat="server" ControlToValidate="DropNivel"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Nivel" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPotencia1" CssClass="control-label">PRIMERA POTENCIA</asp:Label>
              <asp:TextBox runat="server" ID="TxtPotencia1" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="Potencia" runat="server" ControlToValidate="TxtPotencia1"
                CssClass="text-danger" ErrorMessage="* La Primera Potencia es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPotencia2" CssClass="control-label">SEGUNDA POTENCIA</asp:Label>
              <asp:TextBox runat="server" ID="TxtPotencia2" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="Potencia" runat="server" ControlToValidate="TxtPotencia2"
                CssClass="text-danger" ErrorMessage="* La Segunda Potencia es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPotencia3" CssClass="control-label">TERCERA POTENCIA</asp:Label>
              <asp:TextBox runat="server" ID="TxtPotencia3" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="Potencia" runat="server" ControlToValidate="TxtPotencia3"
                CssClass="text-danger" ErrorMessage="* La Tercera Potencia es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPosicion" CssClass="control-label">POSICIÓN GUATEMALA</asp:Label>
              <asp:TextBox runat="server" ID="TxtPosicion" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="Potencia" runat="server" ControlToValidate="TxtPosicion"
                CssClass="text-danger" ErrorMessage="* La Tercera Potencia es obligatorio" />
            </div>
          </div>
        </div>
        <div class="modal-footer gradiant-inver">
          <asp:LinkButton runat="server" ValidationGroup="Potencia" ID="SavePotencia" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SavePotencia_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
          </asp:LinkButton>
          <asp:LinkButton runat="server" CausesValidation="false" ID="CancelPotencia" type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" OnClick="CancelPotencia_Click">
              <span class="glyphicon glyphicon-ban-circle"></span>
          </asp:LinkButton>
        </div>
      </div>
  </div>
</asp:Content>
