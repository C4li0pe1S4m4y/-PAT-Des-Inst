<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministracionPAT.aspx.cs" Inherits="PATOnline.Views.AdministracionPAT.AdministracionPAT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row">
    <div class="col-md-6 col-md-offset-3">
      <!-- Nav tabs category -->
      <ul class="nav nav-tabs faq-cat-tabs">
        <li class="active"><a href="#faq-cat-1" data-toggle="tab">Brecha</a></li>
        <li><a href="#faq-cat-2" data-toggle="tab">Cargo</a></li>
        <li><a href="#faq-cat-3" data-toggle="tab">Categoria</a></li>
        <li><a href="#faq-cat-4" data-toggle="tab">Nivel</a></li>
        <li><a href="#faq-cat-5" data-toggle="tab">Tipo Personal</a></li>
      </ul>

      <!-- Tab panes -->
      <div class="tab-content faq-cat-content">
        
        <div class="tab-pane active in fade" id="faq-cat-1">
          <div class="panel-group" id="accordion-cat-1">
            <div class="panel panel-default panel-faq">
              <div class="modal-content">
                <div class="modal-header gradiant">
                  <h4 class="modal-title black">
                    <asp:Label runat="server" ID="lblBrecha"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="TxtBrecha" CssClass="control-label">Nombre</asp:Label>
                      <asp:TextBox runat="server" ID="TxtBrecha" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ValidationGroup="Brecha" runat="server" ControlToValidate="TxtBrecha"
                      CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ValidationGroup="Brecha" ID="SaveBrecha" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveBrecha_Click">
                    <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default panel-faq">
              <div class="panel-heading">
                <a data-toggle="collapse" data-parent="#accordion-cat-1" href="#faq-cat-1-sub-1">
                  <h4 class="panel-title">Ver Informacion
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                  </h4>
                </a>
              </div>
              <div id="faq-cat-1-sub-1" class="row collapse in panel panel-default">
                <div class="panel-body">
                  <asp:GridView ID="gvListBrecha" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" PageSize="5" OnPageIndexChanging="gvListBrecha_PageIndexChanging"
                    CssClass="footable" AllowCustomPaging="False" BorderStyle="Groove" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
                    <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                      <asp:BoundField DataField="numero" HeaderText="Correlativo">
                        <ItemStyle Width="1%" />
                      </asp:BoundField>
                      <asp:BoundField DataField="brecha" HeaderText="Nombre Brecha" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="40%" />
                      </asp:BoundField>
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
                  <h4 class="modal-title black">
                    <asp:Label runat="server" ID="lblCargo"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="TxtCargo" CssClass="control-label">Nombre</asp:Label>
                      <asp:TextBox runat="server" ID="TxtCargo" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ValidationGroup="Cargo" runat="server" ControlToValidate="TxtCargo"
                      CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ValidationGroup="Cargo" ID="SaveCargo" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveCargo_Click">
                    <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default panel-faq">
              <div class="panel-heading">
                <a data-toggle="collapse" data-parent="#accordion-cat-2" href="#faq-cat-2-sub-1">
                  <h4 class="panel-title">Ver Informacion
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                  </h4>
                </a>
              </div>
              <div id="faq-cat-2-sub-1" class="row collapse in panel panel-default">
                <div class="panel-body">
                  <asp:GridView ID="gvListCargo" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" PageSize="5" OnPageIndexChanging="gvListCargo_PageIndexChanging"
                    CssClass="footable" AllowCustomPaging="False" BorderStyle="Groove" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
                    <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                      <asp:BoundField DataField="numero" HeaderText="Correlativo">
                        <ItemStyle Width="1%" />
                      </asp:BoundField>
                      <asp:BoundField DataField="cargo" HeaderText="Nombre Cargo" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="40%" />
                      </asp:BoundField>
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
                  <h4 class="modal-title black">
                    <asp:Label runat="server" ID="lblCategoria"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="TxtCategoria" CssClass="control-label">Nombre</asp:Label>
                      <asp:TextBox runat="server" ID="TxtCategoria" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ValidationGroup="Categoria" runat="server" ControlToValidate="TxtCategoria"
                      CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ValidationGroup="Categoria" ID="SaveCategoria" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveCategoria_Click">
                    <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default panel-faq">
              <div class="panel-heading">
                <a data-toggle="collapse" data-parent="#accordion-cat-3" href="#faq-cat-3-sub-1">
                  <h4 class="panel-title">Ver Informacion
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                  </h4>
                </a>
              </div>
              <div id="faq-cat-3-sub-1" class="row collapse in panel panel-default">
                <div class="panel-body">
                  <asp:GridView ID="gvListCategoria" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" PageSize="5" OnPageIndexChanging="gvListCategoria_PageIndexChanging"
                    CssClass="footable" AllowCustomPaging="False" BorderStyle="Groove" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
                    <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                      <asp:BoundField DataField="numero" HeaderText="Correlativo">
                        <ItemStyle Width="1%" />
                      </asp:BoundField>
                      <asp:BoundField DataField="categoria" HeaderText="Nombre Categoria" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="40%" />
                      </asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>
          </div>
        </div>
        </div>

        <div class="tab-pane fade" id="faq-cat-4">
          <div class="panel-group" id="accordion-cat-4">
            <div class="panel panel-default panel-faq">
              <div class="modal-content">
                <div class="modal-header gradiant">
                  <h4 class="modal-title black">
                    <asp:Label runat="server" ID="lblNivel"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="TxtNivel" CssClass="control-label">Nombre</asp:Label>
                      <asp:TextBox runat="server" ID="TxtNivel" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ValidationGroup="Nivel" runat="server" ControlToValidate="TxtNivel"
                      CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ValidationGroup="Nivel" ID="SaveNivel" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveNivel_Click">
                    <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default panel-faq">
              <div class="panel-heading">
                <a data-toggle="collapse" data-parent="#accordion-cat-4" href="#faq-cat-4-sub-1">
                  <h4 class="panel-title">Ver Informacion
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                  </h4>
                </a>
              </div>
              <div id="faq-cat-4-sub-1" class="row collapse in panel panel-default">
                <div class="panel-body">
                  <asp:GridView ID="gvListNivel" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" PageSize="5" OnPageIndexChanging="gvListNivel_PageIndexChanging"
                    CssClass="footable" AllowCustomPaging="False" BorderStyle="Groove" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
                    <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                      <asp:BoundField DataField="numero" HeaderText="Correlativo">
                        <ItemStyle Width="1%" />
                      </asp:BoundField>
                      <asp:BoundField DataField="nivel" HeaderText="Nombre Nivel" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="40%" />
                      </asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>
          </div>
        </div>
      </div>

        <div class="tab-pane fade" id="faq-cat-5">
          <div class="panel-group" id="accordion-cat-5">
            <div class="panel panel-default panel-faq">
              <div class="modal-content">
                <div class="modal-header gradiant">
                  <h4 class="modal-title black">
                    <asp:Label runat="server" ID="lblTipoPersonal"></asp:Label></h4>
                </div>
                <div class="modal-body">
                  <div class="row">
                    <div class="col-md-12">
                      <asp:Label runat="server" AssociatedControlID="TxtTipoPersonal" CssClass="control-label">Nombre</asp:Label>
                      <asp:TextBox runat="server" ID="TxtTipoPersonal" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ValidationGroup="TipoPersonal" runat="server" ControlToValidate="TxtTipoPersonal"
                      CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                    </div>
                  </div>
                  <br />
                  <div style="text-align: center">
                    <asp:LinkButton runat="server" ValidationGroup="TipoPersonal" ID="SaveTipoPersonal" type="button" class="btn btn-save" data-toggle="tooltip" data-placement="bottom" title="¡Guardar!" OnClick="SaveTipoPersonal_Click">
                    <span class="glyphicon glyphicon-floppy-disk"></span>
                    </asp:LinkButton>
                  </div>
                </div>
              </div>
            </div>
            <div class="panel panel-default panel-faq">
              <div class="panel-heading">
                <a data-toggle="collapse" data-parent="#accordion-cat-5" href="#faq-cat-5-sub-1">
                  <h4 class="panel-title">Ver Informacion
                    <span class="pull-right"><i class="glyphicon glyphicon-plus"></i></span>
                  </h4>
                </a>
              </div>
              <div id="faq-cat-5-sub-1" class="row collapse in panel panel-default">
                <div class="panel-body">
                  <asp:GridView ID="gvListTipoPersonal" runat="server" AllowPaging="true" AutoGenerateColumns="False" DataKeyNames="numero" PageSize="5" OnPageIndexChanging="gvListTipoPersonal_PageIndexChanging"
                    CssClass="footable" AllowCustomPaging="False" BorderStyle="Groove" GridLines="None" HorizontalAlign="Center" EditRowStyle-HorizontalAlign="Center" AllowSorting="True">
                    <HeaderStyle CssClass="gradiant" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                      <asp:BoundField DataField="numero" HeaderText="Correlativo">
                        <ItemStyle Width="1%" />
                      </asp:BoundField>
                      <asp:BoundField DataField="tipo_personal" HeaderText="Nombre Tipo Personal" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="40%" />
                      </asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </div>
              </div>
          </div>
        </div>
      </div>

    </div>
  </div>
</div>
</asp:Content>
