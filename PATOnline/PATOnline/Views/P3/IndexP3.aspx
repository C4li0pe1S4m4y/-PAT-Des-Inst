<%@ Page Title="P3" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP3.aspx.cs" Inherits="PATOnline.Views.P3.IndexP3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h1 class="modal-title" style="text-align: center;">P3: PROYECCIÓN DE EGRESOS POR ACTIVIDAD (Art. 132)</h1>
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
          <h4 class="modal-title black">
            <asp:Label runat="server" ID="lblTitulo2"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <asp:UpdatePanel ID="UpdatePanelPais" runat="server">
            <ContentTemplate>
              <div class="row" style="text-align: center">
                <h3><b>
                  <asp:Label runat="server" ID="Message" BackColor="Red">Ya Existe un Codigo Ingresado</asp:Label>
                </b></h3>
              </div>
              <div class="row">
                <div class="col-md-7">
                  <asp:Label runat="server" AssociatedControlID="DropActividad" CssClass="control-label">GRUPOS DE CÓDIGO</asp:Label>
                  <asp:DropDownList runat="server" ID="DropActividad" CssClass="form-control" OnSelectedIndexChanged="DropActividad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropActividad"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un grupo de codigos" />
                </div>
                <div class="col-md-5">
                  <asp:Label runat="server" AssociatedControlID="DropCodigo" CssClass="control-label">ACTIVIDAD CODIFICADA DEL PAT</asp:Label>
                  <asp:DropDownList runat="server" ID="DropCodigo" CssClass="form-control" OnSelectedIndexChanged="DropCodigo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropCodigo"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un codigo" />
                </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
          <div class="row">
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtFuente" CssClass="control-label">OTRAS FUENTES</asp:Label>
              <asp:TextBox runat="server" ID="TxtFuente" CssClass="form-control" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPromocion" CssClass="control-label">PROMOCIÓN DEPORTIVA (PD)</asp:Label>
              <asp:TextBox runat="server" ID="TxtPromocion" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="pat3" runat="server" ControlToValidate="TxtPromocion"
                CssClass="text-danger" ErrorMessage="* La Promoción Deportiva es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtPrograma" CssClass="control-label">PROGRAMAS TÉCNICOS (PT)</asp:Label>
              <asp:TextBox runat="server" ID="TxtPrograma" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="pat3" runat="server" ControlToValidate="TxtPrograma"
                CssClass="text-danger" ErrorMessage="* El Programa Técnico es obligatorio" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtActividad" CssClass="control-label">ACTIVIDADES ADMINISTRATIVAS (AA)</asp:Label>
              <asp:TextBox runat="server" ID="TxtActividad" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="pat3" runat="server" ControlToValidate="TxtActividad"
                CssClass="text-danger" ErrorMessage="* La Actividad Administrativa es obligatorio" />
            </div>
          </div>
        </div>
        <div class="modal-footer gradiant-inver">
          <asp:LinkButton runat="server" ValidationGroup="ingreso" ID="SaveIngreso" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveIngreso_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
          </asp:LinkButton>
        </div>
      </div>
    </div>
    <br />
    <div class="container">
      <div class="row">
        <table id="tableTitulo" class="table-bordered gradiant" style="color: white;">
          <tr>
            <th style="text-align: center" rowspan="4"><b>ACTIVIDAD CODIFICADA DEL PAT</b></th>
            <th style="text-align: center" colspan="6"><b>PROPUESTA GENERAL</b></th>
          </tr>
          <tr>
            <th style="text-align: center" colspan="4"><b>PRESUPUESTO CDAG</b></th>
            <th style="width: 135px; text-align: center" rowspan="3"><b>OTRAS FUENTES</b></th>
            <th style="width: 162px; text-align: center" rowspan="3"><b>TOTAL GENERAL</b></th>
          </tr>
          <tr>
            <th style="text-align: center"><b>PROMOCIÓN DEPORTIVA (PD)</b></th>
            <td style="text-align: center"><b>PROGRAMAS TÉCNICOS (PT)</b></td>
            <td style="text-align: center"><b>ACIVIDADES ADMINISTRATIVAS (AA)</b></td>
            <td style="width: 163px; text-align: center" rowspan="2"><b>TOTAL</b></td>
          </tr>
          <tr>
            <th style="width: 164px; text-align: center"><b>20</b></th>
            <th style="width: 149px; text-align: center"><b>30</b></th>
            <th style="width: 148px; text-align: center"><b>50</b></th>
          </tr>
        </table>
      </div>
      <div class="row" style="height: 200px; width: 103%; overflow-x: auto;">
        <asp:GridView ID="gvP1" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" ShowHeader="false"
          CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
          <Columns>
            <asp:TemplateField>
              <ItemStyle Font-Size="Small" />
              <ItemTemplate>
                <asp:Label ID="remarks" runat="server" Text='<%# Eval("codigo") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="164px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="remarks" runat="server" Text='<%# Eval("promocion") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="149px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label1" runat="server" Text='<%# Eval("programa") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="148px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label2" runat="server" Text='<%# Eval("actividad") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="163px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("subtotal") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="135px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label4" runat="server" Text='<%# Eval("otra_fuente") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="164px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label5" runat="server" Text='<%# Eval("total") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>
      <div class="row">
        <asp:GridView ID="gvP3" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" BorderWidth="2" BorderColor="Black" ShowHeader="false"
          CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True" OnRowDataBound="gvP3_RowDataBound">
          <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:Label ID="remarks" runat="server" Text='TOTAL Q'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="164px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="remarks" runat="server" Text='<%# Eval("total1") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="149px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label1" runat="server" Text='<%# Eval("total2") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="148px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label2" runat="server" Text='<%# Eval("total3") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="163px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("total4") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="135px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="Label4" runat="server" Text='<%# Eval("total5") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="161px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
              <asp:Label ID="lblMontoGeneral" runat="server" Text='<%# Eval("total6") %>'></asp:Label></span>
              </ItemTemplate>
            </asp:TemplateField>

          </Columns>
        </asp:GridView>
      </div>
    </div>
  </div>
</asp:Content>

