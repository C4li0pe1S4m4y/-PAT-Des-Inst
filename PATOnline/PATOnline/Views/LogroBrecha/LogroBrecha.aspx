<%@ Page Title="ANALISIS SOBRE PUESTOS - ANALISIS DE BRECHAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogroBrecha.aspx.cs" Inherits="PATOnline.Views.LogroBrecha.LogroBrecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="container">
    <div class="jumbheader">
      <div class="row" style="text-align: center;">
        <h1 class="white"><%: Title %></h1>
      </div>
      <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
      <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
          { %>
      <br />
      <div class="row" style="text-align: center; align-content: center;">
        <div class="col-md-6">
          <h3>
            <asp:Label runat="server" ID="lblPuesto" ForeColor="White"></asp:Label>
            <a href="CrearPuesto.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h3>
        </div>
        <div class="col-md-6">
          <h3>
            <asp:Label runat="server" ID="lblBrecha" ForeColor="White"></asp:Label>
            <a href="CrearBrecha.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h3>
        </div>
      </div>
      <% } %>
    </div>
    <!--ShowModel Ver-->
    <div class="container">
      <div class="row gradiant titulo">
        <div class="col-md-8">
          <h4>
            <asp:Label runat="server" ID="lbl1"></asp:Label>
          </h4>
        </div>
        <div class="col-sm-4" style="text-align-last: right;">
          <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
        </div>
      </div>

      <div id="demo" class="row collapse in panel panel-default">
        <div class="panel-body">
          <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
            CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" OnRowCommand="gvListadoInfo_RowCommand" AllowSorting="True">
            <Columns>
              <asp:BoundField DataField="anio" HeaderText="AÑO">
                <ItemStyle Width="5%"/>
              </asp:BoundField>
              <asp:BoundField DataField="puesto" HeaderText="PUESTO OBTENIDO">
                <ItemStyle Width="10%"/>
              </asp:BoundField>
              <asp:BoundField DataField="punteo" HeaderText="PUNTOS">
                <ItemStyle Width="10%"/>
              </asp:BoundField>
              <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES">
                <ItemStyle Width="75%"/>
              </asp:BoundField>
              <asp:TemplateField HeaderText="OPCIONES">
                <ItemTemplate>
                  <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
                  <% if (boton.BotonEditar(this.Session["Usuario"].ToString()) == true)
                      { %>
                  <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-edit" data-toggle="tooltip" data-placement="bottom" title="¡Editar!" CausesValidation="false"
                    CommandName="Editar" CommandArgument="numero" Text="Editar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-pencil"></span>
                  </asp:LinkButton>
                  <% } %>
                  <% if (boton.BotonVer(this.Session["Usuario"].ToString()) == true)
                      { %>
                  <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-view" data-toggle="modal" data-placement="bottom" title="¡Ver!" CausesValidation="false"
                    CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Mostrar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-eye-open"></span>
                  </asp:LinkButton>
                  <% } %>
                  <% if (boton.BotonEliminar(this.Session["Usuario"].ToString()) == true)
                      { %>
                  <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-delete" data-toggle="tooltip" data-placement="bottom" title="¡Eliminar!" CausesValidation="false"
                    OnClientClick="¿Está seguro que desea Eliminar el registro?" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-trash"></span></span>
                  </asp:LinkButton>
                  <% } %>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </div>

      <div class="row gradiant titulo">
        <div class="col-md-8">
          <h4>
            <asp:Label runat="server" ID="lbl2"></asp:Label>
          </h4>
        </div>
        <div class="col-sm-4" style="text-align-last: right;">
          <a data-toggle="collapse" data-target="#demo2" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
        </div>
      </div>

      <div id="demo2" class="row collapse in panel panel-default">
        <div class="panel-body">
          <asp:GridView ID="gvListadoInfo2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo2_PageIndexChanging"
            CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" OnRowCommand="gvListadoInfo2_RowCommand" AllowSorting="True">
            <Columns>
              <asp:BoundField DataField="brecha" HeaderText="BRECHA CON RESPECTO A:">
                <ItemStyle Width="20%"/>
              </asp:BoundField>
              <asp:BoundField DataField="punteo" HeaderText="PUNTOS">
                <ItemStyle Width="10%"/>
              </asp:BoundField>
              <asp:BoundField DataField="punteo_obtenido" HeaderText="PUNTOS OBTENIDOS POR FADN">
                <ItemStyle Width="10%"/>
              </asp:BoundField>
              <asp:BoundField DataField="comparacion" HeaderText="COMPARACIONES">
                <ItemStyle Width="10"/>
              </asp:BoundField>
              <asp:BoundField DataField="observacion" HeaderText="OBSERVACIONES">
                <ItemStyle Width="50%"/>
              </asp:BoundField>
              <asp:TemplateField HeaderText="OPCIONES"> 
                <ItemTemplate>
                  <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
                  <% if (boton.BotonEditar(this.Session["Usuario"].ToString()) == true)
                      { %>
                  <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-edit" data-toggle="tooltip" data-placement="bottom" title="¡Editar!" CausesValidation="false"
                    CommandName="Editar" CommandArgument="numero" Text="Editar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-pencil"></span>
                  </asp:LinkButton>
                  <% } %>
                  <% if (boton.BotonVer(this.Session["Usuario"].ToString()) == true)
                      { %>
                  <asp:LinkButton ID="btVer" runat="server" type="button" class="btn btn-view" data-toggle="modal" data-placement="bottom" title="¡Ver!" CausesValidation="false"
                    CommandName="Mostrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Mostrar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-eye-open"></span>
                  </asp:LinkButton>
                  <% } %>
                  <% if (boton.BotonEliminar(this.Session["Usuario"].ToString()) == true)
                      { %>
                  <asp:LinkButton ID="btEliminar" runat="server" type="button" class="btn btn-delete" data-toggle="tooltip" data-placement="bottom" title="¡Eliminar!" CausesValidation="false"
                    OnClientClick="¿Está seguro que desea Eliminar el registro?" CommandName="Eliminar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Eliminar">
                          <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="glyphicon glyphicon-trash"></span></span>
                  </asp:LinkButton>
                  <% } %>
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
