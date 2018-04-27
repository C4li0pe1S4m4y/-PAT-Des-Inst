<%@ Page Title="ADMINSITRACIÓN DEL PAT PARTE 3" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministracionParte3.aspx.cs" Inherits="PATOnline.Views.AdministracionPAT.AdministracionParte3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <div class="col-md-6 col-md-offset-3">
        <!-- Nav tabs category -->
        <ul class="nav nav-tabs faq-cat-tabs">
          <li class="active"><a href="#faq-cat-1" data-toggle="tab">FORMATO C</a></li>
          <li><a href="#faq-cat-2" data-toggle="tab">CATEGORÍA</a></li>
          <li><a href="#faq-cat-3" data-toggle="tab">ACTIVIDAD</a></li>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content faq-cat-content">

          <div class="tab-pane active in fade" id="faq-cat-1">
            <div class="panel-group" id="accordion-cat-1">
              <div class="panel panel-default panel-faq">
                <div class="modal-content">
                  <div class="modal-header gradiant">
                    <h4 class="modal-title">
                      <asp:Label runat="server" ID="lblFomartoC"></asp:Label></h4>
                  </div>
                  <div class="modal-body">
                    <div class="row">
                      <div class="col-md-12">
                        <asp:Label runat="server" AssociatedControlID="DropIDPadreFormatoC" CssClass="control-label">FORMATO C</asp:Label>
                        <asp:DropDownList runat="server" ID="DropIDPadreFormatoC" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ValidationGroup="formato" runat="server" ControlToValidate="DropIDPadreFormatoC"
                          CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar formato c" />
                      </div>
                      <div class="col-md-12">
                        <asp:Label runat="server" AssociatedControlID="TxtFormatoC" CssClass="control-label">NOMBRE</asp:Label>
                        <asp:TextBox runat="server" ID="TxtFormatoC" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="formato" runat="server" ControlToValidate="TxtFormatoC"
                          CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                      </div>
                    </div>
                    <br />
                    <div style="text-align: center">
                      <asp:LinkButton runat="server" ValidationGroup="formato" ID="SaveFormato" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveFormato_Click">
                    <span class="glyphicon glyphicon-floppy-disk"></span>
                      </asp:LinkButton>
                    </div>
                  </div>
                </div>
              </div>
              <div class="panel panel-default panel-faq">
                <div class="panel-heading gradiant">
                  <a data-toggle="collapse" data-parent="#accordion-cat-1" href="#faq-cat-1-sub-1">
                    <h4 class="panel-title white">VER INFORMACIÓN
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                    </h4>
                  </a>
                </div>
                <div id="faq-cat-1-sub-1" class="row collapse in panel panel-default">
                  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                      <div class="panel-body">
                        <asp:GridView runat="server" ID="gvFormatoTitulo" AutoGenerateColumns="False" DataKeyNames="idformato_c" OnRowDataBound="gvFormatoTitulo_RowDataBound"
                          CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" AllowSorting="True">
                          <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE DEL FORMATO C">
                              <ItemStyle Width="40%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="DESCRIPCIÓN DEL FORMATO C">
                              <ItemTemplate>
                                <asp:GridView ID="gvFormatoBody" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idformato_c" ShowHeader="false"
                                  HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" AllowSorting="True">
                                  <Columns>
                                    <asp:BoundField DataField="nombre">
                                      <ItemStyle Width="60%" />
                                    </asp:BoundField>
                                  </Columns>
                                </asp:GridView>
                              </ItemTemplate>
                            </asp:TemplateField>
                          </Columns>
                        </asp:GridView>
                      </div>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </div>
              </div>
            </div>
          </div>

          <div class="tab-pane fade" id="faq-cat-2">
            <div class="panel-group" id="accordion-cat-2">
              <div class="panel panel-default panel-faq">
                <div class="modal-content">
                  <div class="modal-header gradiant">
                    <h4 class="modal-title">
                      <asp:Label runat="server" ID="lblCategoria"></asp:Label></h4>
                  </div>
                  <div class="modal-body">
                    <div class="row">
                      <div class="col-md-12">
                        <asp:Label runat="server" AssociatedControlID="DropIDPadreCategoria" CssClass="control-label">CATEGORÍA</asp:Label>
                        <asp:DropDownList runat="server" ID="DropIDPadreCategoria" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ValidationGroup="categoria" runat="server" ControlToValidate="DropIDPadreCategoria"
                          CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar categoria" />
                      </div>
                      <div class="col-md-12">
                        <asp:Label runat="server" AssociatedControlID="TxtCategoria" CssClass="control-label">NOMBRE</asp:Label>
                        <asp:TextBox runat="server" ID="TxtCategoria" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="categoria" runat="server" ControlToValidate="TxtCategoria"
                          CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                      </div>
                    </div>
                    <br />
                    <div style="text-align: center">
                      <asp:LinkButton runat="server" ValidationGroup="categoria" ID="SaveCategoria" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveCategoria_Click">
                        <span class="glyphicon glyphicon-floppy-disk"></span>
                      </asp:LinkButton>
                    </div>
                  </div>
                </div>
              </div>
              <div class="panel panel-default panel-faq">
                <div class="panel-heading gradiant">
                  <a data-toggle="collapse" data-parent="#accordion-cat-2" href="#faq-cat-1-sub-2">
                    <h4 class="panel-title white">VER INFORMACIÓN
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                    </h4>
                  </a>
                </div>
                <div id="faq-cat-1-sub-2" class="row collapse in panel panel-default">
                  <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                    <ContentTemplate>
                      <div class="panel-body">
                        <asp:GridView runat="server" ID="gvCategoriaTitulo" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gvCategoriaTitulo_RowDataBound"
                          CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" AllowSorting="True">
                          <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE DEL FORMATO">
                              <ItemStyle Width="40%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="CATEGORÍA">
                              <ItemTemplate>
                                <asp:GridView ID="gvCategoriaBody" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="numero" ShowHeader="false"
                                  HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" AllowSorting="True">
                                  <Columns>
                                    <asp:BoundField DataField="nombre">
                                      <ItemStyle Width="60%" />
                                    </asp:BoundField>
                                  </Columns>
                                </asp:GridView>
                              </ItemTemplate>
                            </asp:TemplateField>
                          </Columns>
                        </asp:GridView>
                      </div>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </div>
              </div>
            </div>
          </div>

          <div class="tab-pane fade" id="faq-cat-3">
            <div class="panel-group" id="accordion-cat-3">
              <div class="panel panel-default panel-faq">
                <div class="modal-content">
                  <div class="modal-header gradiant">
                    <h4 class="modal-title">
                      <asp:Label runat="server" ID="lblActividad"></asp:Label></h4>
                  </div>
                  <div class="modal-body">
                    <div class="row">
                      <div class="col-md-12">
                        <asp:Label runat="server" AssociatedControlID="DropActividad" CssClass="control-label">ACTIVIDAD</asp:Label>
                        <asp:DropDownList runat="server" ID="DropActividad" CssClass="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ValidationGroup="actvidad" runat="server" ControlToValidate="DropActividad"
                          CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar actividad" />
                      </div>
                      <div class="col-md-12">
                        <asp:Label runat="server" AssociatedControlID="TxtActividad" CssClass="control-label">NOMBRE</asp:Label>
                        <asp:TextBox runat="server" ID="TxtActividad" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="actvidad" runat="server" ControlToValidate="TxtActividad"
                          CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                      </div>
                    </div>
                    <br />
                    <div style="text-align: center">
                      <asp:LinkButton runat="server" ValidationGroup="actvidad" ID="SaveActividad" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveActividad_Click">
                        <span class="glyphicon glyphicon-floppy-disk"></span>
                      </asp:LinkButton>
                    </div>
                  </div>
                </div>
              </div>
              <div class="panel panel-default panel-faq">
                <div class="panel-heading gradiant">
                  <a data-toggle="collapse" data-parent="#accordion-cat-3" href="#faq-cat-1-sub-3">
                    <h4 class="panel-title white">VER INFORMACIÓN
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                    </h4>
                  </a>
                </div>
                <div id="faq-cat-1-sub-3" class="row collapse in panel panel-default">
                  <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                    <ContentTemplate>
                      <div class="panel-body">
                        <asp:GridView runat="server" ID="gvActividadTitulo" AutoGenerateColumns="False" DataKeyNames="idactividad_pat" OnRowDataBound="gvActividadTitulo_RowDataBound"
                          CssClass="footable gradiant" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" AllowSorting="True">
                          <Columns>
                            <asp:BoundField DataField="nombre" HeaderText="NOMBRE DEL FORMATO">
                              <ItemStyle Width="40%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ACTIVIDAD">
                              <ItemTemplate>
                                <asp:GridView ID="gvActividadBody" runat="server" AllowPaging="false" AutoGenerateColumns="False" DataKeyNames="idactividad_pat" ShowHeader="false"
                                  HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" AllowSorting="True">
                                  <Columns>
                                    <asp:BoundField DataField="nombre">
                                      <ItemStyle Width="60%" />
                                    </asp:BoundField>
                                  </Columns>
                                </asp:GridView>
                              </ItemTemplate>
                            </asp:TemplateField>
                          </Columns>
                        </asp:GridView>
                      </div>
                    </ContentTemplate>
                  </asp:UpdatePanel>
                </div>
              </div>
            </div>
          </div>

        </div>
      </div>
    </div>
  </div>
</asp:Content>

