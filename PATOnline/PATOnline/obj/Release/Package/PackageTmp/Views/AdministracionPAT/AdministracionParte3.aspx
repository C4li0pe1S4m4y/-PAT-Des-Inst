<%@ Page Title="ADMINSITRACIÓN DEL PAT PARTE 3" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministracionParte3.aspx.cs" Inherits="PATOnline.Views.AdministracionPAT.AdministracionParte3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item">Dashboard</li>
            <li class="breadcrumb-item active">Administración PAT Formatos</li>
          </ol>
        </div>
      </div>
    </div>
  </div>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Formato C</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoFormatoC" CausesValidation="false" OnClick="nuevoFormatoC_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-4">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Categoría</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaCategoria" CausesValidation="false" OnClick="nuevaCategoria_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-md-4">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Actividad</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaActividad" CausesValidation="false" OnClick="nuevaActividad_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <div class="card card-outline card-primary" runat="server" id="mostrarCrearFormatoC">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">AGREGAR FORMATO C</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="DropIDPadreFormatoC" CssClass="control-label"><span style="color:red">*</span> FORMATO C</asp:Label>
                  <asp:DropDownList runat="server" ID="DropIDPadreFormatoC" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFormatoC" runat="server" ControlToValidate="DropIDPadreFormatoC"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar formato c" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="TxtFormatoC" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <textarea runat="server" id="TxtFormatoC" class="form-control" type="text" onkeypress="return letras(event)" minlength="3" placeholder="nombre del formato" maxlength="40" autofocus required ></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearFormatoC" runat="server" ControlToValidate="TxtFormatoC"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearFormatoC" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearFormatoC_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ID="crearFormatoC" ValidationGroup="validarCrearFormatoC" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearFormatoC_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="card card-outline card-primary" runat="server" id="mostrarCrearCategoria">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">AGREGAR CATEGORÍA</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
                <button type="button" class="btn btn-tool btn-sm" data-widget="remove" data-toggle="tooltip" title="Remove">
                  <i class="fa fa-times"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="DropIDPadreCategoria" CssClass="control-label"><span style="color:red">*</span> CATEGORÍA</asp:Label>
                  <asp:DropDownList runat="server" ID="DropIDPadreCategoria" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearCategoria" runat="server" ControlToValidate="DropIDPadreCategoria"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar categoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="TxtCategoria" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <textarea runat="server" id="TxtCategoria" class="form-control" type="text" onkeypress="return letras(event)" minlength="3" placeholder="nombre de la categoria" maxlength="40" autofocus required ></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearCategoria" runat="server" ControlToValidate="TxtCategoria"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearCategoria" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearCategoria_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ID="crearCategoria" ValidationGroup="validarCrearCategoria" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearCategoria_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="card card-outline card-primary" runat="server" id="mostrarCrearActividad">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">AGREGAR ACTIVIDAD</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="DropActividad" CssClass="control-label"><span style="color:red">*</span> ACTIVIDAD</asp:Label>
                  <asp:DropDownList runat="server" ID="DropActividad" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearActividad" runat="server" ControlToValidate="DropActividad"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar actividad" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="TxtActividad" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <textarea runat="server" id="TxtActividad" class="form-control" type="text" onkeypress="return letras(event)" minlength="3" placeholder="nombre de la actividad" maxlength="40" autofocus required ></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarCrearActividad" runat="server" ControlToValidate="TxtActividad"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelCrearActividad" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelCrearActividad_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ID="crearActividad" ValidationGroup="validarCrearActividad" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="crearActividad_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditFormatoC">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR INFORMACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idFormatoC"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="DropEditPadreFormatoC" CssClass="control-label"><span style="color:red">*</span> FORMATO C</asp:Label>
                  <asp:DropDownList runat="server" ID="DropEditPadreFormatoC" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFormatoC" runat="server" ControlToValidate="DropEditPadreFormatoC"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar formato c" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="TxtEditFormatoC" CssClass="control-label"><span style="color:red">*</span> NOMBRE</asp:Label>
                  <textarea runat="server" id="TxtEditFormatoC" class="form-control" type="text" onkeypress="return letras(event)" minlength="3" placeholder="nombre del formato" maxlength="40" autofocus required ></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditFormatoC" runat="server" ControlToValidate="TxtEditFormatoC"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditFormatoC" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditFormatoC_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditFormatoC" ID="editFormatoC" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editFormatoC_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditCategoria">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR INFORMACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idCategoria"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="DropEditPadreCategoria" CssClass="control-label">CATEGORÍA</asp:Label>
                  <asp:DropDownList runat="server" ID="DropEditPadreCategoria" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditCategoria" runat="server" ControlToValidate="DropEditPadreCategoria"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar categoria" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="TxtEditCategoria" CssClass="control-label">NOMBRE</asp:Label>
                  <textarea runat="server" id="TxtEditCategoria" class="form-control" type="text" onkeypress="return letras(event)" minlength="3" placeholder="nombre de la categoria" maxlength="40" autofocus required ></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditCategoria" runat="server" ControlToValidate="TxtEditCategoria"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditCategoria" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditCategoria_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditCategoria" ID="editCategoria" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editCategoria_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>

        <div class="col-md-4">
          <div class="card card-outline card-warning" runat="server" id="mostrarEditActividad">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">MODIFICAR INFORMACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad">
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" ID="idActividad"></asp:Label>
                  <asp:Label runat="server" AssociatedControlID="DropEditActividad" CssClass="control-label">ACTIVIDAD</asp:Label>
                  <asp:DropDownList runat="server" ID="DropEditActividad" CssClass="form-control"></asp:DropDownList>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditActividad" runat="server" ControlToValidate="DropEditActividad"
                    CssClass="text-danger" ErrorMessage="* Es obligatorio seleccionar actividad" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <asp:Label runat="server" AssociatedControlID="TxtEditActividad" CssClass="control-label">NOMBRE</asp:Label>
                  <textarea runat="server" id="TxtEditActividad" class="form-control" type="text" onkeypress="return letras(event)" minlength="3" placeholder="nombre de la actividad" maxlength="40" autofocus required ></textarea>
                  <asp:RequiredFieldValidator ValidationGroup="validarEditActividad" runat="server" ControlToValidate="TxtEditActividad"
                    CssClass="text-danger" ErrorMessage="* El Nombre es obligatorio" />
                </div>
              </div>
            </div>

            <div class="card-footer">
              <asp:LinkButton runat="server" ID="cancelEditActividad" type="button" class="btn btn-info btn-outline-danger btn-lg" CausesValidation="false" OnClick="cancelEditActividad_Click">
                <span class="fa fa-close"></span>
              </asp:LinkButton>
              <asp:LinkButton runat="server" ValidationGroup="validarEditActividad" ID="editActividad" type="button" class="btn btn-info btn-outline-primary btn-lg float-right" OnClick="editActividad_Click">
                <span class="fa fa-save"></span>
              </asp:LinkButton>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>


  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title">MOSTRAR INFORMACIÓN FORMATO C</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <asp:GridView ID="gvFormatoTitulo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idformato_c" OnRowDataBound="gvFormatoTitulo_RowDataBound"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc">
                <Columns>
                  <asp:BoundField DataField="idformato_c" HeaderStyle-Font-Size="Medium" />
                  <asp:BoundField DataField="nombre" HeaderText="NOMBRE DEL FORMATO C" HeaderStyle-Font-Size="Medium">
                    <ItemStyle Width="35%" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="DESCRIPCIÓN DEL FORMATO C">
                    <ItemTemplate>
                      <asp:GridView ID="gvFormatoBody" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idformato_c" OnRowCommand="gvFormatoBody_RowCommand"
                        CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false" GridLines="None">
                        <Columns>
                          <asp:BoundField DataField="idformato_c" HeaderStyle-Font-Size="Medium" />
                          <asp:BoundField DataField="nombre" HeaderStyle-Font-Size="Medium">
                            <ItemStyle Width="100%" />
                          </asp:BoundField>
                          <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                              <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                              </asp:LinkButton>
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </div>
          </div>
        </div>
      </div>

      <div class="row">
        <div class="col-md-6">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title">MOSTRAR INFORMACIÓN CATEGORÍA</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <asp:GridView ID="gvCategoriaTitulo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnRowDataBound="gvCategoriaTitulo_RowDataBound"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc">
                <Columns>
                  <asp:BoundField DataField="numero" HeaderStyle-Font-Size="Medium" />
                  <asp:BoundField DataField="nombre" HeaderText="NOMBRE DEL FORMATO" HeaderStyle-Font-Size="Medium">
                    <ItemStyle Width="30%" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="CATEGORÍA">
                    <ItemTemplate>
                      <asp:GridView ID="gvCategoriaBody" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="numero" OnRowCommand="gvCategoriaBody_RowCommand"
                        CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false" GridLines="None">
                        <Columns>
                          <asp:BoundField DataField="numero" HeaderStyle-Font-Size="Medium" />
                          <asp:BoundField DataField="nombre" HeaderStyle-Font-Size="Medium">
                            <ItemStyle Width="100%" />
                          </asp:BoundField>
                          <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                              <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                              </asp:LinkButton>
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title">MOSTRAR INFORMACIÓN ACTIVIDAD</h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <asp:GridView ID="gvActividadTitulo" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idactividad_pat" OnRowDataBound="gvActividadTitulo_RowDataBound"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc">
                <Columns>
                  <asp:BoundField DataField="idactividad_pat" HeaderStyle-Font-Size="Medium" />
                  <asp:BoundField DataField="nombre" HeaderText="NOMBRE DEL FORMATO" HeaderStyle-Font-Size="Medium">
                    <ItemStyle Width="30%" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="ACTIVIDAD">
                    <ItemTemplate>
                      <asp:GridView ID="gvActividadBody" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idactividad_pat" OnRowCommand="gvActividadBody_RowCommand"
                        CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" ShowHeader="false" GridLines="None">
                        <Columns>
                          <asp:BoundField DataField="idactividad_pat" HeaderStyle-Font-Size="Medium" />
                          <asp:BoundField DataField="nombre" HeaderStyle-Font-Size="Medium">
                            <ItemStyle Width="100%" />
                          </asp:BoundField>
                          <asp:TemplateField HeaderText="OPCIONES" HeaderStyle-Font-Size="Medium">
                            <ItemTemplate>
                              <asp:LinkButton ID="btEditar" runat="server" type="button" class="btn btn-block btn-warning btn-sm" CausesValidation="false"
                                CommandName="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                <ItemStyle Width="1%" HorizontalAlign="Center"/><span class="fa fa-edit"></span>
                              </asp:LinkButton>
                            </ItemTemplate>
                          </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

</asp:Content>

