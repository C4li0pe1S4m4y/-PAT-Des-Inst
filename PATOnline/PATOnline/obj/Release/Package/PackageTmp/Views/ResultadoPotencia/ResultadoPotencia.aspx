<%@ Page Title="RESULTADOS DEPORTIVOS - ANÁLISIS DE PRINCIPALES POTENCIAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultadoPotencia.aspx.cs" Inherits="PATOnline.Views.ResultadoPotencia.ResultadoPotencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="container">
    <div class="jumbheader">
      <div class="row" style="text-align: center;">
        <h2 class="white"><%: Title %></h2>
      </div>
      <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
      <% if (boton.BotonCrear(this.Session["Usuario"].ToString()) == true)
          { %>
      <br />
      <div class="row" style="text-align: center; align-content: center; color:white;">
        <div class="col-md-5">
          <h4>
            <asp:Label runat="server" ID="lblResultado"></asp:Label>
            <a href="CrearResultado.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h4>
        </div>
        <div class="col-md-7">
          <h4>
            <asp:Label runat="server" ID="lblPotencia"></asp:Label>
            <a href="CrearPotencia.aspx" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a></h4>
        </div>
      </div>
      <% } %>
    </div>
    <!--ShowModel Ver-->
    <div class="containere">
      <div class="row gradiant titulo">
        <div class="col-md-8">
          <h3>
            <asp:Label runat="server" ID="lblInfoResultado"></asp:Label>
          </h3>
        </div>
        <div class="col-sm-4" style="text-align-last: right;">
          <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
        </div>
      </div>

      <div id="demo" class="row collapse in panel panel-default">
        <div class="row" style="text-align: center">
          <h5><b>
            <asp:Label runat="server" ID="lblSubResultado"></asp:Label>
          </b></h5>
        </div>
        <div class="panel-body">
          <asp:GridView ID="gvListadoInfo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging"
            CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" OnRowCommand="gvListadoInfo_RowCommand" AllowSorting="True">
            <Columns>
              <asp:BoundField DataField="numero" HeaderText="NO.">
                <ItemStyle Width="1%" />
              </asp:BoundField>
              <asp:BoundField DataField="nivel" HeaderText="NIVEL">
                <ItemStyle Width="4%" />
              </asp:BoundField>
              <asp:BoundField DataField="competencia" HeaderText="NOMBRE DE LA COMPETENCIA">
                <ItemStyle Width="15%" />
              </asp:BoundField>
              <asp:BoundField DataField="sed" HeaderText="SEDE">
                <ItemStyle Width="10%" />
              </asp:BoundField>
              <asp:BoundField DataField="fecha_resultado" HeaderText="FECHA">
                <ItemStyle Width="3%" />
              </asp:BoundField>
              <asp:BoundField DataField="categoria" HeaderText="CATEGORIA">
                <ItemStyle Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="resultado_obtenido" HeaderText="RESULTADO OBTENIDO">
                <ItemStyle Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="observar" HeaderText="OBSERVACIONES">
                <ItemStyle Width="20%" />
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
          <h3>
            <asp:Label runat="server" ID="lblInfoPotencia"></asp:Label>
          </h3>
        </div>
        <div class="col-sm-4" style="text-align-last: right;">
          <a data-toggle="collapse" data-target="#demo2" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
        </div>
      </div>

      <div id="demo2" class="row collapse in panel panel-default">
        <div class="row" style="text-align: center">
          <h5><b>
            <asp:Label runat="server" ID="lblSubPotencia"></asp:Label>
          </b></h5>
        </div>
        <div class="panel-body">
          <asp:GridView ID="gvListadoInfo2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo2_PageIndexChanging"
            CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" OnRowCommand="gvListadoInfo2_RowCommand" AllowSorting="True">
            <Columns>
              <asp:BoundField DataField="numero" HeaderText="NO.">
                <ItemStyle Width="1%" />
              </asp:BoundField>
              <asp:BoundField DataField="nivel" HeaderText="NIVEL">
                <ItemStyle Width="5%" />
              </asp:BoundField>
              <asp:BoundField DataField="primera" HeaderText="PRIMERA POTENCIA">
                <ItemStyle Width="20%" />
              </asp:BoundField>
              <asp:BoundField DataField="segunda" HeaderText="SEGUNDA POTENCIA">
                <ItemStyle Width="20%" />
              </asp:BoundField>
              <asp:BoundField DataField="tercera" HeaderText="TERCERA POTENCIA">
                <ItemStyle Width="20%" />
              </asp:BoundField>
              <asp:BoundField DataField="posicion" HeaderText="PSICIÓN GUATEMALA">
                <ItemStyle Width="20%" />
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
