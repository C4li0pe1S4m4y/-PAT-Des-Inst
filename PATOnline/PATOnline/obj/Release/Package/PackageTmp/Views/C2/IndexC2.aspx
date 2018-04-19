<%@ Page Title="C1" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexC2.aspx.cs" Inherits="PATOnline.Views.C2.IndexC2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="container">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header gradiant">
        <h4 class="modal-title">
          <asp:Label runat="server" ID="lblTitulo2"></asp:Label></h4>
      </div>
      <div class="modal-body">
        <div class="row" style="text-align: center">
          <h3><b>
            <asp:Label runat="server" ID="Message" BackColor="Red">Ya Existe una Actividad</asp:Label>
          </b></h3>
        </div>
        <div class="row">
          <div class="col-md-12">
            <asp:Label runat="server" AssociatedControlID="DropFormato" CssClass="control-label">FORMATO C</asp:Label>
            <asp:DropDownList runat="server" ID="DropFormato" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropFormato"
              CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Formato" />
          </div>
        </div>
        <div class="row">
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="TxtEA" CssClass="control-label">ENE-ABR</asp:Label>
            <asp:TextBox runat="server" ID="TxtEA" CssClass="form-control" TextMode="Number" />
            <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtEA"
              CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un valor o 0" />
          </div>
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="TxtMA" CssClass="control-label">MAYO-AGO</asp:Label>
            <asp:TextBox runat="server" ID="TxtMA" CssClass="form-control" TextMode="Number" />
            <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtMA"
              CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un valor o 0" />
          </div>
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="TxtSD" CssClass="control-label">SEP-DIC</asp:Label>
            <asp:TextBox runat="server" ID="TxtSD" CssClass="form-control" TextMode="Number" />
            <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtSD"
              CssClass="text-danger" ErrorMessage="* El es obligatorio ingresar un valor o 0" />
          </div>
          <div class="col-md-3">
            <asp:Label runat="server" AssociatedControlID="TxtPresupuesto" CssClass="control-label">PRESUPUESTO</asp:Label>
            <asp:TextBox runat="server" ID="TxtPresupuesto" CssClass="form-control" TextMode="Number" />
            <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtPresupuesto"
              CssClass="text-danger" ErrorMessage="* El Presupuesto es obligatorio" />
          </div>
        </div>
      </div>
      <div class="modal-footer gradiant-inver">
        <asp:LinkButton runat="server" ValidationGroup="validar" ID="SaveIngreso" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveIngreso_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
        </asp:LinkButton>
      </div>
    </div>
  </div>
  <br />
  <div class="container">
    <div class="row" style="align-content: center; text-align: center; border: solid; background-color: aquamarine; color: black;">
      <h3>
        <asp:Label runat="server" ForeColor="Black" Text="2. POTENCIAL DEPORTIVO"></asp:Label>
      </h3>
    </div>
    <br />
    <div class="row" style="align-content: center; text-align: center; border: solid; background-color: #1E90FF; color: black;">
      <h3>
        <asp:Label runat="server" ForeColor="Black" Text="ACTIVIDADES CUATRIMESTRALES"></asp:Label>
      </h3>
    </div>
    <br />
    <br />
    <div class="row">
      <table id="tableTitulo" class="footable gradiant" style="color: white;">
        <tr>
          <td style="text-align: center" rowspan="2"><b>ÁREAS CLAVE</b></td>
          <td style="width: 362px; text-align: center" rowspan="2"><b>FORMATO "C"</b></td>
          <td style="text-align: center" colspan="4"><b>ACTIVIDADES</b></td>
          <td style="width: 183px; text-align: center" rowspan="2"><b>PRESUPUESTO</b></td>
        </tr>
        <tr>
          <td style="width: 91px; text-align: center"><b>ENE-ABR</b></td>
          <td style="width: 91px; text-align: center"><b>MAY-AGO</b></td>
          <td style="width: 91px; text-align: center"><b>SEP-DIC</b></td>
          <td style="width: 91px; text-align: center"><b>ANUAL</b></td>
        </tr>
      </table>
    </div>
    <div class="row">
      <asp:GridView Width="1000%" BackColor="white" runat="server" ID="gvP1" AutoGenerateColumns="False" DataKeyNames="idformato_c" OnRowDataBound="gvP1_RowDataBound" GridLines="None" ShowHeader="false">
        <Columns>
          <asp:BoundField DataField="nombre">
            <ItemStyle Width="20%" />
          </asp:BoundField>
          <asp:TemplateField>
            <ItemTemplate>
              <asp:GridView ID="gvP2" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" ShowHeader="false"
                CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" AllowSorting="True">
                <Columns>
                  <asp:BoundField DataField="formato">
                    <ItemStyle Width="40%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="bimestre1">
                    <ItemStyle Width="10%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="bimestre2">
                    <ItemStyle Width="10%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="bimestre3">
                    <ItemStyle Width="10%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="anual">
                    <ItemStyle Width="10%" />
                  </asp:BoundField>
                  <asp:TemplateField>
                    <ItemStyle Width="20%" />
                    <ItemTemplate>
                      <span>Q
                        <asp:Label ID="remarks" runat="server" Text='<%# Eval("presupuesto") %>'></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
    <div class="row">
      <asp:GridView ID="gvP3" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" ShowHeader="false"
        CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" AllowSorting="True">
        <Columns>
          <asp:TemplateField>
            <ItemTemplate>
              <p style="text-align:right; color:black;"><b><asp:Label ID="remarks" runat="server" Text="PRESUPUESTO GENERAL"></asp:Label></b></p>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>
            <ItemStyle Width="183px" />
            <ItemTemplate>
              <p style="text-align:center; color:black;"><b>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("total") %>'></asp:Label></b></p>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
  </div>
</asp:Content>
