<%@ Page Title="C3.2 SISTEMA DE JUEGOS DEPORTIVOS NACIONALES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexC3_2.aspx.cs" Inherits="PATOnline.Views.C3.IndexC3_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="container">
    <div class="row">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header gradiant">
          <h4 class="modal-title">
            <asp:Label runat="server" ID="lblTitulo2"></asp:Label></h4>
        </div>
        <div class="modal-body">
          <div class="row" style="text-align: center">
            <h3><b>
              <asp:Label runat="server" ID="Message" BackColor="Red">Error al ingresar C3.2</asp:Label>
            </b></h3>
          </div>
          <div class="row">
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="TxtCodigo" CssClass="control-label">CÓDIGO</asp:Label>
              <asp:TextBox runat="server" ID="TxtCodigo" CssClass="form-control" />
            </div>
            <div class="col-md-4">
              <asp:Label runat="server" AssociatedControlID="DropActividad" CssClass="control-label">NOMBRE DE LA ACTIVIDAD</asp:Label>
              <asp:DropDownList runat="server" ID="DropActividad" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropActividad"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una actividad" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="DropCategoria" CssClass="control-label">CATEGORÍA</asp:Label>
              <asp:DropDownList runat="server" ID="DropCategoria" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropCategoria"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una categoria" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtEdades" CssClass="control-label">EDADES</asp:Label>
              <asp:TextBox runat="server" ID="TxtEdades" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtEdades"
                CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar las edades" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-9">
              <p style="text-align: center;">
                <asp:Label runat="server" CssClass="control-label">PROYECCIÓN DE PARTICIPANTES</asp:Label>
              </p>
              <div class="col-md-4">
                <asp:Label runat="server" AssociatedControlID="TxtMasculino" CssClass="control-label">MASCULINO</asp:Label>
                <asp:TextBox runat="server" ID="TxtMasculino" CssClass="form-control" />
                <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtMasculino"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un numero" />
              </div>
              <div class="col-md-4">
                <asp:Label runat="server" AssociatedControlID="TxtFemenino" CssClass="control-label">FEMENINO</asp:Label>
                <asp:TextBox runat="server" ID="TxtFemenino" CssClass="form-control" />
                <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtFemenino"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un numero" />
              </div>
            </div>
            <div class="col-md-3">
              <br />
              <asp:Label runat="server" AssociatedControlID="TxtRegistros" CssClass="control-label">REGISTRO</asp:Label>
              <asp:TextBox runat="server" ID="TxtRegistros" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtRegistros"
                CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar el registro" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-6">
              <p style="text-align: center;">
                <asp:Label runat="server" CssClass="control-label">FECHA INICIA</asp:Label>
              </p>
              <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="DropIDia" CssClass="control-label">DÍA</asp:Label>
                <asp:DropDownList runat="server" ID="DropIDia" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropIDia"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
              </div>
              <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="DropIMes" CssClass="control-label">MES</asp:Label>
                <asp:DropDownList runat="server" ID="DropIMes" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropIMes"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
              </div>
            </div>
            <div class="col-md-6">
              <p style="text-align: center;">
                <asp:Label runat="server" CssClass="control-label">FECHA FINALIZA</asp:Label>
              </p>
              <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="DropFDia" CssClass="control-label">DÍA</asp:Label>
                <asp:DropDownList runat="server" ID="DropFDia" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropFDia"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un día" />
              </div>
              <div class="col-md-6">
                <asp:Label runat="server" AssociatedControlID="DropFMes" CssClass="control-label">MES</asp:Label>
                <asp:DropDownList runat="server" ID="DropFMes" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropFMes"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un mes" />
              </div>
            </div>
          </div>
          <asp:UpdatePanel runat="server" ID="AgregarDepartamento">
            <ContentTemplate>
              <div class="row">
                <div class="col-md-7">
                  <p style="text-align: center;">
                    <asp:Label runat="server" CssClass="control-label">UBICACIÓN</asp:Label>
                  </p>
                  <div class="col-md-5">
                    <asp:Label runat="server" AssociatedControlID="DropDepartamento" CssClass="control-label">DEPARTAMENTO</asp:Label>
                    <asp:DropDownList runat="server" ID="DropDepartamento" CssClass="form-control" OnSelectedIndexChanged="DropDepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropDepartamento"
                      CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
                  </div>
                  <div class="col-md-3">
                    <br />
                    <asp:TextBox runat="server" ID="TxtDepartamento" CssClass="form-control" />
                    <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtDepartamento"
                      CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un lugar" />
                  </div>
                  <div class="col-md-3">
                    <asp:Label runat="server" AssociatedControlID="TxtLugar" CssClass="control-label">LUGAR</asp:Label>
                    <asp:TextBox runat="server" ID="TxtLugar" CssClass="form-control" />
                    <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtLugar"
                      CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un lugar" />
                  </div>
                </div>
                <div class="col-md-3">
                  <br />
                  <asp:Label runat="server" AssociatedControlID="TxtPresupuesto" CssClass="control-label">PRESUPUESTO</asp:Label>
                  <asp:TextBox runat="server" ID="TxtPresupuesto" CssClass="form-control" />
                  <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtPresupuesto"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar un presupuesto" />
                </div>
              </div>
              </div>
            </ContentTemplate>
          </asp:UpdatePanel>
          <div class="modal-footer gradiant-inver">
            <asp:LinkButton runat="server" ValidationGroup="validar" ID="SaveIngreso" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveIngreso_Click">
              <span class="glyphicon glyphicon-floppy-disk"></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
  </div>
  <br />
  <div class="container">
    <div class="row">
      <table id="tableTitulo" class="table-bordered gradiant" style="color: white; width: 100%">
        <tr>
          <th style="text-align: center; font-size: 10px;" rowspan="3"><b>CÓDIGO</b></th>
          <th style="width: 108px; text-align: center; font-size: 10px;" rowspan="3"><b>NOMBRE DE LA ACTIVIDAD</b></th>
          <th style="width: 86px; text-align: center; font-size: 10px;" rowspan="3"><b>CATEGORÍA</b></th>
          <th style="width: 96px; text-align: center; font-size: 10px;" rowspan="3"><b>EDADES</b></th>
          <th style="text-align: center; font-size: 10px;" rowspan="2" colspan="3"><b>RPOYECCIÓN DE PARTICIPANTES</b></th>
          <th style="width: 66px; text-align: center; font-size: 10px;" rowspan="3"><b>REGISTRO</b></th>
          <th style="text-align: center; font-size: 10px;" colspan="4"><b>FECHA</b></th>
          <th style="text-align: center; font-size: 10px;" rowspan="2" colspan="3"><b>UBICACIÓN</b></th>
          <th style="width: 136px; text-align: center; font-size: 10px;" rowspan="3"><b>PRESUPUESTO</b></th>
        </tr>
        <tr>
          <td style="text-align: center; font-size: 10px;" colspan="2"><b>INICIA</b></td>
          <td style="text-align: center; font-size: 10px;" colspan="2"><b>FINALIZA</b></td>
        </tr>
        <tr>
          <td style="width: 47px; text-align: center; font-size: 10px;"><b>MAS</b></td>
          <td style="width: 47px; text-align: center; font-size: 10px;"><b>FEM</b></td>
          <td style="width: 46px; text-align: center; font-size: 10px;"><b>TOTAL</b></td>
          <td style="width: 48px; text-align: center; font-size: 10px;"><b>DÍA</b></td>
          <td style="width: 48px; text-align: center; font-size: 10px;"><b>MES</b></td>
          <td style="width: 47px; text-align: center; font-size: 10px;"><b>DÍA</b></td>
          <td style="width: 48px; text-align: center; font-size: 10px;"><b>MES</b></td>
          <td style="width: 133px; text-align: center; font-size: 10px;"><b>DEPARTAMENTO</b></td>
          <td style="width: 121px; text-align: center; font-size: 10px;"><b>LUGAR</b></td>
        </tr>
      </table>
    </div>
    <div class="row">
      <asp:GridView ID="gvP2" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" ShowHeader="false"
        CssClass="footable" BackColor="white" AllowCustomPaging="False" GridLines="None" AllowSorting="True" Width="100%">
        <Columns>
          <asp:BoundField DataField="codigo">
            <ItemStyle Font-Size="X-Small" Font-Underline="true" />
          </asp:BoundField>
          <asp:BoundField DataField="actividad">
            <ItemStyle Width="110px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="categoria">
            <ItemStyle Width="87px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="edades">
            <ItemStyle Width="98px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="mas">
            <ItemStyle Width="48px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="fem">
            <ItemStyle Width="48px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="total">
            <ItemStyle Width="48px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="registro">
            <ItemStyle Width="58px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="inicio_dia">
            <ItemStyle Width="49px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="inicio_mes">
            <ItemStyle Width="49px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="fin_dia">
            <ItemStyle Width="48px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="fin_mes">
            <ItemStyle Width="48px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="departamento">
            <ItemStyle Width="137px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="lugar">
            <ItemStyle Width="125px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:TemplateField>
            <ItemStyle Width="140px" Font-Size="X-Small" />
            <ItemTemplate>
              <span>Q
                        <asp:Label ID="remarks" runat="server" Text='<%# Eval("presupuesto") %>'></asp:Label></span>
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
              <p style="text-align: right; color: black;">
                <b>
                  <asp:Label ID="remarks" runat="server" Text="TOTALES"></asp:Label></b>
              </p>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField>
            <ItemStyle Width="136px" Font-Size="Medium" />
            <ItemTemplate>
              <p style="text-align: center; color: black;">
                <b>Q
                <asp:Label ID="remarks" runat="server" Text='<%# Eval("total") %>'></asp:Label></b>
              </p>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
  </div>
</asp:Content>

