<%@ Page Title="ROL - ADMINISTRACIÓN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateRolPermiso.aspx.cs" Inherits="PATOnline.Views.RolPermiso.CreateRolPermiso" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

  <div class="row">
    <div class="col-md-6 col-md-offset-3">
      <!-- Nav tabs category -->
      <ul class="nav nav-tabs faq-cat-tabs">
        <li><a href="#faq-cat-1" data-toggle="tab">ROL</a></li>
        <li><a href="#faq-cat-2" data-toggle="tab">MÉNU</a></li>
        <li><a href="#faq-cat-3" data-toggle="tab">ACCIÓN</a></li>
        <li><a href="#faq-cat-4" data-toggle="tab">PERMISO</a></li>
      </ul>

      <!-- Tab panes -->
      <div class="tab-content faq-cat-content">
        <div class="tab-pane fade" id="faq-cat-1">
          <div class="panel-group" id="accordion-cat-1">
            <div class="panel panel-default panel-faq">
              <div class="modal-content">
                <div class="modal-header gradiant">
                  <h4 class="modal-title">
                    <asp:Label runat="server" ID="lblModal2"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" CssClass="control-label">ROL</asp:Label>
                      <input runat="server" id="TxtRol" name="TxtRol" class="form-control" type="text" onkeypress="return letras(event)" minlength="4" placeholder="nombre del rol" maxlength="25" autofocus />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ID="SaveRol" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveRol_Click">
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
                <div class="panel-body">
                  <asp:GridView ID="gvListRol" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListRol_PageIndexChanging" PageSize="5"
                    CssClass="footable" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None">
                    <Columns>
                      <asp:BoundField DataField="rol" HeaderText="NOMBRE ROL"></asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </div>
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
                    <asp:Label runat="server" ID="lblModal4"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" CssClass="control-label">MÉNU</asp:Label>
                      <input runat="server" id="TxtMenu" name="TxtMenu" class="form-control" type="text" onkeypress="return letras(event)" minlength="4" placeholder="nombre del ménu" maxlength="25" autofocus />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ID="SaveMenu" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveMenu_Click">
                                        <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default panel-faq">
              <div class="panel-heading gradiant">
                <a data-toggle="collapse" data-parent="#accordion-cat-2" href="#faq-cat-2-sub-1">
                  <h4 class="panel-title white">VER INFORMACIÓN                  
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                  </h4>
                </a>
              </div>
              <div id="faq-cat-2-sub-1" class="row collapse in panel panel-default">
                <div class="panel-body">
                  <asp:GridView ID="gvListMenu" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListMenu_PageIndexChanging" PageSize="5"
                    CssClass="footable" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" HorizontalAlign="Center" AllowSorting="True">
                    <Columns>
                      <asp:BoundField DataField="menu" HeaderText="NOMBRE DEL MÉNU"></asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </div>
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
                    <asp:Label runat="server" ID="lblModal3"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" CssClass="control-label">BOTÓN</asp:Label>
                      <input runat="server" id="TxtBoton" name="TxtBoton" class="form-control" type="text" onkeypress="return letras(event)" minlength="4" placeholder="nombre del botón" maxlength="12" autofocus />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ID="SaveBoton" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveBoton_Click">
                    <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default panel-faq">
              <div class="panel-heading gradiant">
                <a data-toggle="collapse" data-parent="#accordion-cat-3" href="#faq-cat-3-sub-1">
                  <h4 class="panel-title white">VER INFORMACIÓN
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                  </h4>
                </a>
              </div>
              <div id="faq-cat-3-sub-1" class="row collapse in panel panel-default">
                <div class="panel-body">
                  <asp:GridView ID="gvListBoton" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListBoton_PageIndexChanging" PageSize="5"
                    CssClass="footable" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" GridLines="None" AllowSorting="True">
                    <Columns>
                      <asp:BoundField DataField="boton" HeaderText="NOMBRE DEL BOTÓN"></asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="tab-pane active in fade" id="faq-cat-4">
          <asp:UpdatePanel runat="server" ID="UpdatePanelPermiso">
            <ContentTemplate>
              <div class="panel-group" id="accordion-cat-4">
                <div class="panel panel-default panel-faq">
                  <div class="modal-content">
                    <div class="modal-header gradiant">
                      <h4 class="modal-title">
                        <asp:Label runat="server" ID="lblModal"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                      <div class="row">
                        <div class="col-md-12">
                          <asp:Label runat="server" AssociatedControlID="DropRol" CssClass="control-label">ROL</asp:Label>
                          <asp:DropDownList runat="server" ID="DropRol" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropRol_SelectedIndexChanged"></asp:DropDownList>
                          <asp:RequiredFieldValidator runat="server" ControlToValidate="DropRol"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar un Rol" />
                        </div>
                        <div class="col-md-12">
                          <asp:Label runat="server" AssociatedControlID="DropMenu" CssClass="control-label">PANTALLA</asp:Label>
                          <asp:DropDownList runat="server" ID="DropMenu" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="DropMenu_SelectedIndexChanged"></asp:DropDownList>
                          <asp:RequiredFieldValidator runat="server" ControlToValidate="DropMenu"
                            CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar una Pantalla" />
                        </div>
                        <div class="col-md-12">
                          <asp:Label runat="server" CssClass="control-label">BOTÓN</asp:Label>
                          <div class="checkbox checkbox-primary" style="border: groove;">
                            <asp:CheckBoxList runat="server" CssClass="styled" ID="checkboxTwoInput" DataTextField="boton" TextAlign="Right" CellPadding="16"
                                  DataValueField="numero" CausesValidation="false" RepeatDirection="Horizontal" RepeatColumns="5" Font-Size="Large" >
                            </asp:CheckBoxList>
                          </div>
                        </div>
                        <br />
                        <div style="text-align: center">
                          <asp:LinkButton runat="server" ID="Save" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="Save_Click">
                            <span class="glyphicon glyphicon-floppy-disk"></span>
                          </asp:LinkButton>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div class="panel panel-default panel-faq">
                    <div class="panel-heading gradiant">
                      <a data-toggle="collapse" data-parent="#accordion-cat-4" href="#faq-cat-4-sub-1">
                        <h4 class="panel-title white">VER INFORMACIÓN    
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                        </h4>
                      </a>
                    </div>
                    <div id="faq-cat-4-sub-1" class="row collapse in panel panel-default">
                      <div class="panel-body">
                        <asp:GridView ID="gvListPermiso" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" OnPageIndexChanging="gvListadoInfo_PageIndexChanging" PageSize="4"
                          CssClass="footable" HeaderStyle-ForeColor="Black" PagerStyle-ForeColor="Black" ForeColor="Black" OnRowCommand="gvListadoInfo_RowCommand1" GridLines="None" AllowSorting="True">
                          <Columns>
                            <asp:BoundField DataField="rol" HeaderText="NOMBRE DEL ROL">
                              <ItemStyle Width="8%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pantalla" HeaderText="NOMBRE DE LA PANTALLA">
                              <ItemStyle Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="boton" HeaderText="NOMBRE DEL BOTÓN">
                              <ItemStyle Width="12%" />
                            </asp:BoundField>
                          </Columns>
                        </asp:GridView>
                      </div>
                    </div>
                  </div>
                </div>
            </ContentTemplate>
          </asp:UpdatePanel>
        </div>
      </div>
    </div>
  </div>

</asp:Content>
