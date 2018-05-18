<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PATOnline.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-horizontal">
    <div class="jumbheader">
        <h1 class="black">
            <%: Title %>
            <a data-toggle="modal" data-target="#myModal" data-placement="bottom" title="¡Crear Nuevo!"><span class="glyphicon glyphicon-plus-sign white"></span></a>
        </h1>
    </div>
    <div class="container">
        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header gradiant">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title black">Titulo</h4>
                    </div>
                    <div class="modal-body">
                        <p>Some text in the modal.</p>
                    </div>
                    <div class="modal-footer gradiant-inver">
                        <button type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" style="width:auto;">
                            <span class="glyphicon glyphicon-floppy-disk"></span>
                        </button>
                        <button type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" data-dismiss="modal" style="width:auto;">
                            <span class="glyphicon glyphicon-ban-circle"></span>
                        </button>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <asp:GridView ID="GridView1" CssClass="footable mdi-tablet-ipad " runat="server" AutoGenerateColumns="false"
        Style="max-width: 500px">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Customer Id" />
            <asp:BoundField DataField="Name" HeaderText="Customer Name" />
            <asp:BoundField DataField="Country" HeaderText="Country" />
            <asp:BoundField DataField="Salary" HeaderText="Salary" />
        </Columns>
    </asp:GridView>


    <div class="jumbotron">
        <div class="row gradiant titulo">
            <div class="col-sm-8 gris">
                <h3><asp:label runat="server" ID="lblSubTitulo"></asp:label> </h3>
            </div>
            <div class="col-sm-4" style="text-align-last:right;">
                <a data-toggle="collapse" data-target="#demo" data-placement="bottom" title="¡Ocultar Informacion!"><span class="glyphicon glyphicon-minus-sign white"></span></a>
            </div>
        </div>

        <div id="demo" class="row collapse in panel panel-default">
            <div class="panel-body">

            </div>
        </div>

          
    <div class="jumbotron">
        <% PATOnline.Controller.Search.SearchBoton boton = new PATOnline.Controller.Search.SearchBoton(); %>
        <div id="demo" class="collapse in">
          <% if (boton.BotonExcel(this.Session["Usuario"].ToString()) == true) { %>  
            <button type="button" class="btn btn-excel" data-toggle="tooltip" data-placement="bottom" title="¡Descargar Excel!"><span class="glyphicon glyphicon-file"></span></button>
          <% } %>  
          <% if (boton.BotonPDF(this.Session["Usuario"].ToString()) == true) { %>  
            <button type="button" class="btn btn-pdf" data-toggle="tooltip" data-placement="bottom" title="¡Descargar PDF!"><span class="glyphicon glyphicon-list-alt"></span></button>
          <% } %>    
          <% if (boton.BotonGuardar(this.Session["Usuario"].ToString()) == true) { %> 
            <button type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!"><span class="glyphicon glyphicon-floppy-disk"></span></button>
          <% } %>  
          <% if (boton.BotonAprobar(this.Session["Usuario"].ToString()) == true) { %>    
            <button type="button" class="btn btn-revisar" data-toggle="tooltip" data-placement="bottom" title="¡Revisar!"><span class="glyphicon glyphicon-ok-circle"></span></button>
          <% } %>  
          <% if (boton.BotonEditar(this.Session["Usuario"].ToString()) == true) { %>   
            <button type="button" class="btn btn-edit" data-toggle="tooltip" data-placement="bottom" title="¡Editar!"><span class="glyphicon glyphicon-pencil"></span></button>
          <% } %>  
          <% if (boton.BotonVer(this.Session["Usuario"].ToString()) == true) { %>   
            <button type="button" class="btn btn-view" data-toggle="tooltip" data-placement="bottom" title="¡Ver!"><span class="glyphicon glyphicon-eye-open"></span></button>
          <% } %>  
          <% if (boton.BotonRechazar(this.Session["Usuario"].ToString()) == true) { %>   
            <button type="button" class="btn btn-rechazar" data-toggle="tooltip" data-placement="bottom" title="¡Rechazar!"><span class="glyphicon glyphicon-remove-circle"></span></button>
          <% } %>  
          <% if (boton.BotonEliminar(this.Session["Usuario"].ToString()) == true) { %>   
            <button type="button" class="btn btn-delete" data-toggle="tooltip" data-placement="bottom" title="¡Eliminar!"><span class="glyphicon glyphicon-trash"></span></button>
          <% } %>    
            <button type="button" class="btn btn-cancel" data-toggle="tooltip" data-placement="bottom" title="¡Cancelar!" data-dismiss="modal"><span class="glyphicon glyphicon-ban-circle"></span></button>
          <% if (boton.BotonEnviar(this.Session["Usuario"].ToString()) == true) { %>   
            <button type="button" class="btn btn-enviar" data-toggle="tooltip" data-placement="bottom" title="¡Enviar!" data-dismiss="modal"><span class="glyphicon glyphicon-send"></span></button>
          <% } %>   
        </div>
    </div>

        
    </div>
</div>
</asp:Content>
