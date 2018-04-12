<%@ Page Title="P1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP1.aspx.cs" Inherits="PATOnline.Views.P1.IndexP1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h1 class="modal-title" style="text-align: center;">P1:INGRESOS</h1>
        </div>
        <div class="modal-body" style="text-align: center; align-items: center;">
          <div class="row col-md-offset-2">
            <div class="col-md-2" style="border: solid; border-color: #99CCCC">
              <h4>
                <asp:Label runat="server" ForeColor="Black" Text="FADN:"></asp:Label></h4>
            </div>
            <div class="col-md-7" style="border: solid; border-color: #99CCCC">
              <h4>
                <asp:Label runat="server" ForeColor="Black" ID="fadn"></asp:Label></h4>
            </div>
          </div>
          <div class="row col-md-offset-2">
            <div class="col-md-2" style="border: solid; border-color: #99CCCC">
              <h4>
                <asp:Label runat="server" ForeColor="Black" Text="AÑO:"></asp:Label></h4>
            </div>
            <div class="col-md-7" style="border: solid; border-color: #99CCCC">
              <h4>
                <asp:Label runat="server" ForeColor="Black" ID="anio"></asp:Label></h4>
            </div>
          </div>
        </div>
      </div>
    </div>
    <br />
    <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title">
            <asp:Label runat="server" ID="lblTitulo2"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
              <div class="row" style="text-align: center">
                <h3><b>
                  <asp:Label runat="server" ID="Message" BackColor="Red">Ya Existe un Ingreso</asp:Label>
                </b></h3>
              </div>
              <div class="row" style="text-align: center">
                <h3><b>
                  <asp:Label runat="server" ID="lblNombreIngreso"></asp:Label>
                </b></h3>
              </div>
              <div class="row">
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="DropTipoIngreso" CssClass="control-label">Tipo de Ingresos:</asp:Label>
                  <asp:DropDownList runat="server" ID="DropTipoIngreso" CssClass="form-control" OnSelectedIndexChanged="DropTipoIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropTipoIngreso"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Ingreso" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="DropIngreso" CssClass="control-label">Ingresos:</asp:Label>
                  <asp:DropDownList runat="server" ID="DropIngreso" CssClass="form-control" OnSelectedIndexChanged="DropIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropIngreso"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Ingreso" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="DropCodigoIngreso" CssClass="control-label">Codigo de Ingreso:</asp:Label>
                  <asp:DropDownList runat="server" ID="DropCodigoIngreso" CssClass="form-control" OnSelectedIndexChanged="DropCodigoIngreso_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropCodigoIngreso"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Codigo de Ingreso" />
                </div>
              </div>

              <div class="row col-sm-offset-1">
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="TxtColUno" CssClass="control-label">Monto Columna No. 1</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColUno" CssClass="form-control" Width="100" />
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColUno"
                    CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 1 es obligatorio" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="TxtColDos" CssClass="control-label">Monto Columna No. 2</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColDos" CssClass="form-control" Width="100" />
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColDos"
                    CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 2 es obligatorio" />
                </div>
                <div class="col-md-4">
                  <asp:Label runat="server" AssociatedControlID="TxtColTres" CssClass="control-label">Monto Columna No. 3</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColTres" CssClass="form-control" Width="100" />
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColTres"
                    CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 3 es obligatorio" />
                </div>
              </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
          <div class="modal-footer gradiant-inver">
            <asp:LinkButton runat="server" ValidationGroup="ingreso" ID="SaveIngreso" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveIngreso_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
    </div>
    <div class="container">
      <div class="row" style="height: 250px; width: 104%; overflow-x: auto;">
        <asp:GridView Width="1000%" runat="server" ID="gvP1" AutoGenerateColumns="False" DataKeyNames="idnumero1" OnRowDataBound="gvP1_RowDataBound" GridLines="None">
          <Columns>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="NotSet">
              <ItemTemplate>
                <asp:GridView ID="gvP2" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2"
                  CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
                  <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                  <Columns>
                    <asp:BoundField DataField="codigo">
                      <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nombre">
                      <ItemStyle Width="57%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="monto1">
                      <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="monto2">
                      <ItemStyle Width="11%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="monto3">
                      <ItemStyle Width="10%" />
                    </asp:BoundField>
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>
      <div class="row" style="width: 104%;">
        <asp:GridView Width="1000%" ID="gvP3" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2" BorderWidth="2" BorderColor="Black"
          CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" ShowHeader="false" HorizontalAlign="Center" AllowSorting="True">
          <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                <h4>
                  <asp:Label runat="server" Text="TOTAL Q"></asp:Label></h4>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="total1">
              <ItemStyle Width="116px" />
            </asp:BoundField>
            <asp:BoundField DataField="total2">
              <ItemStyle Width="127px" />
            </asp:BoundField>
            <asp:BoundField DataField="total3">
              <ItemStyle Width="133px" />
            </asp:BoundField>
          </Columns>
        </asp:GridView>
      </div>
    </div>
  </div>
</asp:Content>
