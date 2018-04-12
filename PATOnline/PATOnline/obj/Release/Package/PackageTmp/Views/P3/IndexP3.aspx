<%@ Page Title="P3" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP3.aspx.cs" Inherits="PATOnline.Views.P3.IndexP3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row col-lg-offset-1">
    <h1>
      <asp:Label runat="server" ForeColor="Black" Text="P3: PROYECCIÓN DE EGRESOS POR ACTIVIDAD (Art. 132)"></asp:Label></h1>
  </div>
  <div class="row col-lg-offset-1">
    <div class="row">
      <div class="col-md-1" style="border: solid; border-color: black">
        <h3>
          <asp:Label runat="server" ForeColor="Black" Text="FADN:"></asp:Label></h3>
      </div>
      <div class="col-md-7" style="border: solid; border-color: black">
        <h3>
          <asp:Label runat="server" ForeColor="Black" ID="fadn"></asp:Label></h3>
      </div>
    </div>
    <div class="row">
      <div class="col-md-1" style="border: solid; border-color: black">
        <h3>
          <asp:Label runat="server" ForeColor="Black" Text="Año:"></asp:Label></h3>
      </div>
      <div class="col-md-7" style="border: solid; border-color: black">
        <h3>
          <asp:Label runat="server" ForeColor="Black" ID="anio"></asp:Label></h3>
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
        <div class="row" style="text-align: center">
          <h3><b>
            <asp:Label runat="server" ID="Message" BackColor="Red">Ya Existe un Codigo Ingresado</asp:Label>
          </b></h3>
        </div>
        <div class="row">
          <div class="col-md-4">
            <asp:Label runat="server" AssociatedControlID="TxtCodigo" CssClass="control-label">Actividad Codificada del PAT</asp:Label>
            <asp:TextBox runat="server" ID="TxtCodigo" CssClass="form-control" />
            <asp:RequiredFieldValidator ValidationGroup="pat3" runat="server" ControlToValidate="TxtCodigo"
              CssClass="text-danger" ErrorMessage="* El Codigo es obligatorio" />
          </div>
          <div class="col-md-4">
            <asp:Label runat="server" AssociatedControlID="TxtFuente" CssClass="control-label">Otras Fuentes</asp:Label>
            <asp:TextBox runat="server" ID="TxtFuente" CssClass="form-control" />
          </div>
        </div>
        <div class="row">
          <div class="col-md-4">
            <asp:Label runat="server" AssociatedControlID="TxtPromocion" CssClass="control-label">Promoción Deportiva (PD)</asp:Label>
            <asp:TextBox runat="server" ID="TxtPromocion" CssClass="form-control" />
            <asp:RequiredFieldValidator ValidationGroup="pat3" runat="server" ControlToValidate="TxtPromocion"
              CssClass="text-danger" ErrorMessage="* La Promoción Deportiva es obligatorio" />
          </div>
          <div class="col-md-4">
            <asp:Label runat="server" AssociatedControlID="TxtPrograma" CssClass="control-label">Programas Técnicos (PT)</asp:Label>
            <asp:TextBox runat="server" ID="TxtPrograma" CssClass="form-control" />
            <asp:RequiredFieldValidator ValidationGroup="pat3" runat="server" ControlToValidate="TxtPrograma"
              CssClass="text-danger" ErrorMessage="* El Programa Técnico es obligatorio" />
          </div>
          <div class="col-md-4">
            <asp:Label runat="server" AssociatedControlID="TxtActividad" CssClass="control-label">Actividades Administrativas (AA)</asp:Label>
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
  <div class="row">
    <asp:GridView ID="gvP1" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" OnRowCreated="gvP1_RowCreated"
      CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
      <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
      <Columns>
        <asp:TemplateField HeaderText="Actividad Codificada del PAT">
          <ItemStyle Width="15%" HorizontalAlign="Center" />
          <ItemTemplate>
            <asp:Label ID="remarks" runat="server" Text='<%# Eval("codigo") %>'></asp:Label>
          </ItemTemplate>           
        </asp:TemplateField>
        <asp:TemplateField HeaderText="50" ItemStyle-HorizontalAlign="Center">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="remarks" runat="server" Text='<%# Eval("promocion") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="30" ItemStyle-HorizontalAlign="Center">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label1" runat="server" Text='<%# Eval("programa") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="20">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label2" runat="server" Text='<%# Eval("actividad") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("subtotal") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Otras Fuentes">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label4" runat="server" Text='<%# Eval("otra_fuente") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total General">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label5" runat="server" Text='<%# Eval("total") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>

      </Columns>
      <SortedAscendingHeaderStyle HorizontalAlign="Center" />
      <SortedDescendingHeaderStyle HorizontalAlign="Center" />
    </asp:GridView>
  </div>
  <div class="row">
    <asp:GridView ID="gvP3" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero"
      CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" ShowHeader="false" HorizontalAlign="Center" AllowSorting="True">
<Columns>
        <asp:TemplateField HeaderText="Actividad Codificada del PAT">
          <ItemStyle Width="15%" />
          <ItemTemplate>
            <asp:Label ID="remarks" runat="server" Text='TOTAL Q'></asp:Label>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="50" ItemStyle-HorizontalAlign="Center">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="remarks" runat="server" Text='<%# Eval("total1") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="30" ItemStyle-HorizontalAlign="Center">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label1" runat="server" Text='<%# Eval("total2") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="20">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label2" runat="server" Text='<%# Eval("total3") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label3" runat="server" Text='<%# Eval("total4") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Otras Fuentes">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label4" runat="server" Text='<%# Eval("total5") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Total General">
          <ItemStyle Width="10%" />
          <ItemTemplate>
            <span>Q
              <asp:Label ID="Label5" runat="server" Text='<%# Eval("total6") %>'></asp:Label></span>
          </ItemTemplate>
        </asp:TemplateField>

      </Columns>
    </asp:GridView>
  </div>
</asp:Content>

