<%@ Page Title="C3.1 SISTEMA COMPETITIVO NACIONAL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IndexC3_1.aspx.cs" Inherits="PATOnline.Views.C3.IndexC3_1" %>

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
              <asp:Label runat="server" ID="Message" BackColor="Red">Error al ingresar C3.1</asp:Label>
            </b></h3>
          </div>
          <div class="row">
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="TxtCodigo" CssClass="control-label">CÓDIGO</asp:Label>
              <asp:TextBox runat="server" ID="TxtCodigo" CssClass="form-control" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="TxtCompetencia" CssClass="control-label">NOMBRE DE LA COMPETENCIA</asp:Label>
              <asp:TextBox runat="server" ID="TxtCompetencia" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtCompetencia"
                CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar una competencia" />
            </div>
            <div class="col-md-3">
              <asp:Label runat="server" AssociatedControlID="DropClasificacion" CssClass="control-label">CLASIFICACIÓN</asp:Label>
              <asp:DropDownList runat="server" ID="DropClasificacion" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropClasificacion"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una clasificación" />
            </div>
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="DropNivel" CssClass="control-label">NIVEL</asp:Label>
              <asp:DropDownList runat="server" ID="DropNivel" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropNivel"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un nivel" />
            </div>
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="DropCategoria" CssClass="control-label">CATEGORÍA</asp:Label>
              <asp:DropDownList runat="server" ID="DropCategoria" CssClass="form-control"></asp:DropDownList>
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropCategoria"
                CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una categoria" />
            </div>
          </div>
          <div class="row">
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="TxtEdades" CssClass="control-label">EDADES</asp:Label>
              <asp:TextBox runat="server" ID="TxtEdades" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtEdades"
                CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar las edades" />
            </div>
            <div class="col-md-4">
              <asp:Label runat="server" AssociatedControlID="TxtFase" CssClass="control-label" Font-Size="Small">FASES QUE CUBRE EL EVENTO</asp:Label>
              <asp:TextBox runat="server" ID="TxtFase" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtFase"
                CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar la fase del evento" />
            </div>
            <div class="col-md-4">
              <asp:Label runat="server" AssociatedControlID="TxtResultados" CssClass="control-label">RESULTADOS ESPERADOS</asp:Label>
              <asp:TextBox runat="server" ID="TxtResultados" CssClass="form-control" />
              <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="TxtResultados"
                CssClass="text-danger" ErrorMessage="* Es obligatorio ingresar el resultado" />
            </div>
            <div class="col-md-2">
              <asp:Label runat="server" AssociatedControlID="TxtRegistros" CssClass="control-label">REGISTROS</asp:Label>
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

          <div class="row">
            <div class="col-md-7">
              <p style="text-align: center;">
                <asp:Label runat="server" CssClass="control-label">UBICACIÓN</asp:Label>
              </p>
              <div class="col-md-4">
                <asp:Label runat="server" AssociatedControlID="DropDepartamento" CssClass="control-label">DEPARTAMENTO</asp:Label>
                <asp:DropDownList runat="server" ID="DropDepartamento" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ValidationGroup="validar" runat="server" ControlToValidate="DropDepartamento"
                  CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un país" />
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
          <th style=" text-align: center; font-size: 10px;" rowspan="3"><b>CÓDIGO</b></th>
          <th style="width: 83px; text-align: center; font-size: 10px;" rowspan="3"><b>NOMBRE DE LA COMPETENCIA</b></th>
          <th style="width: 88px; text-align: center; font-size: 10px;" rowspan="3"><b>CLASIFICACIÓN</b></th>
          <th style="width: 85px; text-align: center; font-size: 10px;" rowspan="3"><b>NIVEL</b></th>
          <th style="width: 70px; text-align: center; font-size: 10px;" rowspan="3"><b>CATEGORÍA</b></th>
          <th style="width: 60px; text-align: center; font-size: 10px;" rowspan="3"><b>EDADES</b></th>
          <th style="width: 64px; text-align: center; font-size: 10px;" rowspan="3"><b>FASES QUE CUBRE EL EVENTO</b></th>
          <th style="width: 139px; text-align: center; font-size: 10px;" rowspan="3"><b>RESULTADOS ESPERADOS</b></th>
          <th style="width: 70px; text-align: center; font-size: 10px;" rowspan="3"><b>REGISTRO</b></th>
          <th style=" text-align: center; font-size: 10px;" colspan="4"><b>FECHA</b></th>
          <th style=" text-align: center; font-size: 10px;" rowspan="2" colspan="3"><b>UBICACIÓN</b></th>
          <th style="width: 110px; text-align: center; font-size: 10px;" rowspan="3"><b>PRESUPUESTO</b></th>
        </tr>
        <tr>
          <td style="text-align: center; font-size: 10px;" colspan="2"><b>INICIA</b></td>
          <td style="text-align: center; font-size: 10px;" colspan="2"><b>FINALIZA</b></td>
        </tr>
        <tr>
          <td style="width: 36px; text-align: center; font-size: 10px;"><b>DÍA</b></td>
          <td style="width: 37px; text-align: center; font-size: 10px;"><b>MES</b></td>
          <td style="width: 36px; text-align: center; font-size: 10px;"><b>DÍA</b></td>
          <td style="width: 37px; text-align: center; font-size: 10px;"><b>MES</b></td>
          <td style="width: 85px; text-align: center; font-size: 10px;"><b>DEPARTAMENTO</b></td>
          <td style="width: 79px; text-align: center; font-size: 10px;"><b>LUGAR</b></td>
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
          <asp:BoundField DataField="competencia">
            <ItemStyle Width="84px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="clasificacion">
            <ItemStyle Width="88px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="nivel">
            <ItemStyle Width="84px" Font-Size="XX-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="categoria">
            <ItemStyle Width="70px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="edades">
            <ItemStyle Width="60px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="fase">
            <ItemStyle Width="65px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="resultado">
            <ItemStyle Width="140px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="registro">
            <ItemStyle Width="70px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="inicio_dia">
            <ItemStyle Width="36px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="inicio_mes">
            <ItemStyle Width="36px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="fin_dia">
            <ItemStyle Width="36px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="fin_mes">
            <ItemStyle Width="36px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="departamento">
            <ItemStyle Width="86px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:BoundField DataField="lugar">
            <ItemStyle Width="80px" Font-Size="X-Small" />
          </asp:BoundField>
          <asp:TemplateField>
            <ItemStyle Width="110px" Font-Size="X-Small" />
            <ItemTemplate>
              <span>Q
                        <asp:Label ID="remarks" runat="server" Text='<%# Eval("presupuesto") %>'></asp:Label></span>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
    <div class="row">
      <asp:GridView ID="gvP3" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" ShowHeader="false" OnRowDataBound="gvP3_RowDataBound"
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
            <ItemStyle Width="110px" Font-Size="X-Small"/>
            <ItemTemplate>
              <p style="text-align: center;">
                <b>Q
                <asp:Label ID="lblPresupuesto" runat="server" Text='<%# Eval("total") %>'></asp:Label></b>
              </p>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </div>
  </div>
</asp:Content>

