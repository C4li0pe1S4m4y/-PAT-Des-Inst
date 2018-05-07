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
      <div class="row" style="height: 400px; width: 103%; overflow-x: auto;">
        <asp:GridView ID="gvP1" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" ShowHeader="false" OnRowCommand="gvP1_RowCommand" OnRowDataBound="gvP1_RowDataBound"
          CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
          <Columns>
            <asp:TemplateField>
              <ItemStyle Width="189px" Font-Size="Small" />
              <ItemTemplate>
                <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("codigo") %>'></asp:Label>
                <asp:Button ID="AgregarInfo" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="AGREGAR" Text="AGREGAR" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!"/>
                <b><asp:Label ID="MessageError" runat="server" Font-Size="XX-Small" ForeColor="Red"></asp:Label></b>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="164px" Font-Size="Small" />
              <ItemTemplate>
                <asp:TextBox ID="TxtPromocion" runat="server" Text='<%# Eval("promocion") %>' CssClass="form-control"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="149px" Font-Size="Small" />
              <ItemTemplate>
                <asp:TextBox ID="TxtPrograma" runat="server" Text='<%# Eval("programa") %>' CssClass="form-control"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="148px" Font-Size="Small" />
              <ItemTemplate>
                <asp:TextBox ID="TxtActividad" runat="server" Text='<%# Eval("actividad") %>' CssClass="form-control"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="163px" Font-Size="Small" />
              <ItemTemplate>
                <asp:Label ID="TxtSubtotal" runat="server" Text='<%# Eval("subtotal") %>'></asp:Label>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="135px" Font-Size="Small" />
              <ItemTemplate>
                <asp:TextBox ID="TxtOtraFuente" runat="server" Text='<%# Eval("otra_fuente") %>' CssClass="form-control"></asp:TextBox>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemStyle Width="147px" Font-Size="Small" />
              <ItemTemplate>
                <span>Q
                <asp:Label ID="TxtTotal" runat="server" Text='<%# Eval("total") %>'></asp:Label></span>
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

