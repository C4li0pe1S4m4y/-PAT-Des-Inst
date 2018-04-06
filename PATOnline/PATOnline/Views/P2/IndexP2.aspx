<%@ Page Title="P2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP2.aspx.cs" Inherits="PATOnline.Views.P2.IndexP2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row col-lg-offset-1">
    <h1>
      <asp:Label runat="server" ForeColor="Black" Text="P2: PROYECCIÓN DE EGRESOS POR RENGLÓN"></asp:Label></h1>
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
  <div class="row">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header gradiant">
        <h4 class="modal-title black">
          <asp:Label runat="server" ID="lblTitulo2"></asp:Label></h4>
      </div>
      <div class="modal-body">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
          <ContentTemplate>
            <div class="row" style="text-align: center">
              <h3><b>
                <asp:Label runat="server" ID="Message" BackColor="Red">Ya Existe un Renglon Ingresado</asp:Label>
              </b></h3>
            </div>
            <div class="row" style="text-align: center">
              <h3><b>
                <asp:Label runat="server" ID="lblNombreIngreso"></asp:Label>
              </b></h3>
            </div>
            <div class="row">
              <div class="col-md-12">
                <asp:Label runat="server" AssociatedControlID="DropTipoProyecto" CssClass="control-label">Tipo de Proyecto:</asp:Label>
                <asp:DropDownList runat="server" ID="DropTipoProyecto" CssClass="form-control" OnSelectedIndexChanged="DropTipoProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropTipoProyecto"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Proyecto" />
              </div>
            </div>
            <div class="row">
              <div class="col-md-7">
                <asp:Label runat="server" AssociatedControlID="DropProyecto" CssClass="control-label">Proyecto:</asp:Label>
                <asp:DropDownList runat="server" ID="DropProyecto" CssClass="form-control" OnSelectedIndexChanged="DropProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropProyecto"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Proyecto" />
              </div>
              <div class="col-md-5">
                <asp:Label runat="server" AssociatedControlID="DropRenglonProyecto" CssClass="control-label">Renglon del Proyecto:</asp:Label>
                <asp:DropDownList runat="server" ID="DropRenglonProyecto" CssClass="form-control" OnSelectedIndexChanged="DropRenglonProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropRenglonProyecto"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Renglon del Proyecto" />
              </div>
            </div>

            <div class="row">
              <div class="col-md-3">
                <asp:Label runat="server" AssociatedControlID="TxtColUno" CssClass="control-label">Monto Columna No. 1</asp:Label>
                <asp:TextBox runat="server" ID="TxtColUno" CssClass="form-control" Width="100" />
                <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColUno"
                  CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 1 es obligatorio" />
              </div>
              <div class="col-md-2">
                <asp:Label runat="server" AssociatedControlID="TxtColDos" CssClass="control-label">Monto Columna No. 2</asp:Label>
                <asp:TextBox runat="server" ID="TxtColDos" CssClass="form-control" Width="100" />
                <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColDos"
                  CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 2 es obligatorio" />
              </div>
              <div class="col-md-2">
                <asp:Label runat="server" AssociatedControlID="TxtColTres" CssClass="control-label">Monto Columna No. 3</asp:Label>
                <asp:TextBox runat="server" ID="TxtColTres" CssClass="form-control" Width="100" />
                <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColTres"
                  CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 3 es obligatorio" />
              </div>
              <div class="col-md-2">
                <asp:Label runat="server" AssociatedControlID="TxtColCuatro" CssClass="control-label">Monto Columna No. 4</asp:Label>
                <asp:TextBox runat="server" ID="TxtColCuatro" CssClass="form-control" Width="100" />
                <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColCuatro"
                  CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 4 es obligatorio" />
              </div>
              <div class="col-md-2">
                <asp:Label runat="server" AssociatedControlID="TxtColFinanza" CssClass="control-label">Finanza</asp:Label>
                <asp:TextBox runat="server" ID="TxtColFinanza" CssClass="form-control" Width="100" />
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
    <br />
    <div class="row">
      <asp:GridView Width="1000%" runat="server" ID="gvP1" AutoGenerateColumns="False" DataKeyNames="idnumero1" OnRowDataBound="gvP1_RowDataBound" GridLines="None">
        <Columns>
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="NotSet">
            <ItemTemplate>
              <asp:GridView ID="gvP2" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2"
                CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
                <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>
                  <asp:TemplateField HeaderText="GRUPO RENGLON">
                    <ItemStyle Width="8%" />
                    <ItemTemplate>               
                      <asp:Label ID="remarks" runat="server" Text='<%# Eval("renglon") %>' ></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="CONCEPTO">
                    <ItemStyle Width="42%" />
                    <ItemTemplate>               
                      <asp:Label ID="remarks" runat="server" Text='<%# Eval("nombre") %>' ></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto1") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField>  
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto2") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField> 
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto3") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField> 
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto4") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField> 
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <asp:Label ID="remarks" runat="server" Text='<%# Eval("finanza") %>' ></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField> 
                </Columns>
              </asp:GridView>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <asp:GridView Width="1000%" runat="server" ID="gvp4" AutoGenerateColumns="False" DataKeyNames="idnumero1" OnRowDataBound="gvp4_RowDataBound" GridLines="None">
        <Columns>
          <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="NotSet">
            <ItemTemplate>
              <asp:GridView ID="gvp5" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2"
                CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
                <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                <Columns>
                  <asp:TemplateField HeaderText="GRUPO RENGLON">
                    <ItemStyle Width="8%" />
                    <ItemTemplate>               
                      <asp:Label ID="remarks" runat="server" Text='<%# Eval("renglon") %>' ></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="CONCEPTO">
                    <ItemStyle Width="42%" />
                    <ItemTemplate>               
                      <asp:Label ID="remarks" runat="server" Text='<%# Eval("nombre") %>' ></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField>
                  <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto1") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField>  
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto2") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField> 
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto3") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField> 
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <span>Q <asp:Label ID="remarks" runat="server" Text='<%# Eval("monto4") %>' ></asp:Label></span>
                    </ItemTemplate>
                  </asp:TemplateField> 
                  <asp:TemplateField>
                    <ItemStyle Width="10%" />
                    <ItemTemplate>               
                      <asp:Label ID="remarks" runat="server" Text='<%# Eval("finanza") %>' ></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField> 
                </Columns>
              </asp:GridView>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <asp:GridView ID="gvP3" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2"
        CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" ShowHeader="false" HorizontalAlign="Center" AllowSorting="True">
        <Columns>
          <asp:TemplateField HeaderStyle-Width="52%">
            <ItemTemplate>
              <p style="text-align: right; align-content: inherit;">
                <h2>
                  <asp:Label Width="52%" runat="server" Text="TOTAL Q"></asp:Label></h2>
              </p>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="total1">
            <ItemStyle Width="10%" />
          </asp:BoundField>
          <asp:BoundField DataField="total2">
            <ItemStyle Width="10%" />
          </asp:BoundField>
          <asp:BoundField DataField="total3">
            <ItemStyle Width="10%" />
          </asp:BoundField>
          <asp:BoundField DataField="total4">
            <ItemStyle Width="10%" />
          </asp:BoundField>
          <asp:BoundField>
            <ItemStyle Width="10%" />
          </asp:BoundField>
        </Columns>
      </asp:GridView>
    </div>
  </div>
</asp:Content>
