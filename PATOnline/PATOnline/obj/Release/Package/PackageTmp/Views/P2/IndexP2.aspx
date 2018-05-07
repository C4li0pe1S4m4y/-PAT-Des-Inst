<%@ Page Title="P2" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexP2.aspx.cs" Inherits="PATOnline.Views.P2.IndexP2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h1 class="modal-title" style="text-align: center;">P2: PROYECCIÓN DE EGRESOS POR RENGLÓN</h1>
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
            <asp:Label runat="server" ID="lblNombreIngreso"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
              <div class="row" style="text-align: center">
                <h3><b>
                  <asp:Label runat="server" ID="Message" BackColor="Red">Ya Existe un Renglon Ingresado</asp:Label>
                </b></h3>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="DropTipoProyecto" CssClass="control-label">TIPO DE PROYECTO:</asp:Label>
                  <asp:DropDownList runat="server" ID="DropTipoProyecto" CssClass="form-control" OnSelectedIndexChanged="DropTipoProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropTipoProyecto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Tipo de Proyecto" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-7">
                  <asp:Label runat="server" AssociatedControlID="DropProyecto" CssClass="control-label">PROYECTO:</asp:Label>
                  <asp:DropDownList runat="server" ID="DropProyecto" CssClass="form-control" OnSelectedIndexChanged="DropProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropProyecto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Proyecto" />
                </div>
                <div class="col-md-5">
                  <asp:Label runat="server" AssociatedControlID="DropRenglonProyecto" CssClass="control-label">RENGLÓN DEL PROYECTO:</asp:Label>
                  <asp:DropDownList runat="server" ID="DropRenglonProyecto" CssClass="form-control" OnSelectedIndexChanged="DropRenglonProyecto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="DropRenglonProyecto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Renglon del Proyecto" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="TxtColUno" CssClass="control-label">MONTO 50%</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColUno" CssClass="form-control" Width="100" />
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColUno"
                    CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 1 es obligatorio" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="TxtColDos" CssClass="control-label">MONTO 30%</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColDos" CssClass="form-control" Width="100" />
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColDos"
                    CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 2 es obligatorio" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="TxtColTres" CssClass="control-label">MONTO 20%</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColTres" CssClass="form-control" Width="100" />
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColTres"
                    CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 3 es obligatorio" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="TxtColCuatro" CssClass="control-label">MONTO 100%</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColCuatro" CssClass="form-control" Width="100" />
                  <asp:RequiredFieldValidator ValidationGroup="ingreso" runat="server" ControlToValidate="TxtColCuatro"
                    CssClass="text-danger" ErrorMessage="* El Monto de la Columna No. 4 es obligatorio" />
                </div>
                <div class="col-md-2">
                  <asp:Label runat="server" AssociatedControlID="TxtColFinanza" CssClass="control-label">FINANCIMIENTO</asp:Label>
                  <asp:TextBox runat="server" ID="TxtColFinanza" CssClass="form-control" Width="100" />
                </div>
                <div class="col-md-2">
                  <asp:LinkButton runat="server" ID="Verficar" CssClass="bottom" Text="VERIFICAR" OnClick="Verficar_Click"></asp:LinkButton>
                  <small>
                    <asp:Label runat="server" ID="verificarmonto" BackColor="Red">Error al verificar Montos</asp:Label></small>
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
      <br />
      <div class="container">
        <div class="row">
          <table id="tableTitulo" class="table-bordered gradiant" style="color: white;">
            <tr>
              <th style="text-align: center"><b>GRUPO RENGLON</b></th>
              <th style="width: 603px; text-align: center"><b>CONCEPTO</b></th>
              <th style="width: 135px; text-align: center"><b>50%</b></th>
              <th style="width: 135px; text-align: center"><b>30%</b></th>
              <th style="width: 133px; text-align: center"><b>20%</b></th>
              <th style="width: 131px; text-align: center"><b>100%</b></th>
              <th style="width: 131px; text-align: center"><b>FINANC.</b></th>
            </tr>
          </table>
        </div>
        <div class="row" style="height: 350px; width: 104%; overflow-x: auto;">
          <div class="modal-header gradiant">
            <h4 class="modal-title" style="text-align: center;">1. - PROYECCIÓN DE EGRESOS POR RENGLON CON BASE AL PRESUPUESTO APROBADO DE CDAG</h4>
          </div>
          <asp:GridView Width="1000%" runat="server" ID="gvP1" AutoGenerateColumns="False" DataKeyNames="idnumero1" OnRowDataBound="gvP1_RowDataBound" GridLines="None">
            <Columns>
              <asp:TemplateField>
                <ItemTemplate>
                  <asp:GridView ID="gvP2" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2" ShowHeader="false"
                    CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
                    <Columns>
                      <asp:TemplateField>
                        <ItemStyle Width="71px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label ID="lbl1" runat="server" Text='<%# Eval("renglon") %>'></asp:Label>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="482px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label ID="lbl2" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl3" runat="server" Text='<%# Eval("monto1") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl4" runat="server" Text='<%# Eval("monto2") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl5" runat="server" Text='<%# Eval("monto3") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl6" runat="server" Text='<%# Eval("monto4") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="110px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl7" runat="server" Text='<%# Eval("finanza") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
          <br />
          <div class="modal-header gradiant">
            <h4 class="modal-title" style="text-align: center;">2. - PROYECCIÓN DE EGRESOS POR RENGLON CON BASE A OTRAS FUENTES DE FINANCIAMIENTO</h4>
          </div>
          <asp:GridView Width="1000%" runat="server" ID="gvp4" AutoGenerateColumns="False" DataKeyNames="idnumero1" OnRowDataBound="gvp4_RowDataBound" GridLines="None">
            <Columns>
              <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="NotSet">
                <ItemTemplate>
                  <asp:GridView ID="gvp5" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2" ShowHeader="false"
                    CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
                    <Columns>
                      <asp:TemplateField>
                        <ItemStyle Width="71px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label ID="lbl1" runat="server" Text='<%# Eval("renglon") %>'></asp:Label>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="482px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <asp:Label ID="lbl2" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl3" runat="server" Text='<%# Eval("monto1") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="111px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl4" runat="server" Text='<%# Eval("monto2") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl5" runat="server" Text='<%# Eval("monto3") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="109px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl6" runat="server" Text='<%# Eval("monto4") %>'></asp:Label></span>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField>
                        <ItemStyle Width="110px" Font-Size="Smaller" />
                        <ItemTemplate>
                          <span>Q
                        <asp:Label ID="lbl7" runat="server" Text='<%# Eval("finanza") %>'></asp:Label></span>
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
          <asp:GridView ID="gvP3" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idnumero2" BorderWidth="2" BorderColor="Black" OnRowDataBound="gvP3_RowDataBound"
            CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" ShowHeader="false" HorizontalAlign="Center" AllowSorting="True">
            <Columns>
              <asp:TemplateField>
                <ItemStyle Width="554px" Font-Size="Large" />
                <ItemTemplate>
                  <asp:Label ID="remarks" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemStyle Width="111px" Font-Size="Smaller" />
                <ItemTemplate>
                  <span>Q
                        <asp:Label ID="total1" runat="server" Text='<%# Eval("total1") %>'></asp:Label></span>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemStyle Width="111px" Font-Size="Smaller" />
                <ItemTemplate>
                  <span>Q
                        <asp:Label ID="total2" runat="server" Text='<%# Eval("total2") %>'></asp:Label></span>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemStyle Width="109px" Font-Size="Smaller" />
                <ItemTemplate>
                  <span>Q
                        <asp:Label ID="total3" runat="server" Text='<%# Eval("total3") %>'></asp:Label></span>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemStyle Width="109px" Font-Size="Smaller" />
                <ItemTemplate>
                  <span>Q
                        <asp:Label ID="total4" runat="server" Text='<%# Eval("total4") %>'></asp:Label></span>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField>
                <ItemStyle Font-Size="Smaller" />
                <ItemTemplate>
                  <span>Q
                        <asp:Label ID="lbl7" runat="server" Text='<%# Eval("total5") %>'></asp:Label></span>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
