<%@ Page Title="DASHBOARD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardFADN.aspx.cs" Inherits="PATOnline.DashboardFADN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-md-10">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
      </div>
    </div>
  </div>

    <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title"><span class="info-box-number">MOSTRAR INFORMACIÓN</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool" data-widget="collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <div class="card-body" style="overflow-x: auto;">
              <asp:GridView ID="gridFederacionAsignado" runat="server" AutoGenerateColumns="False" DataKeyNames="numero"
                CssClass="table table-bordered table-responsive dataTable" HeaderStyle-BackColor="#e8f2fc" OnRowCommand="gridFederacionAsignado_RowCommand">
                <Columns>
                  <asp:BoundField DataField="numero" ShowHeader="false" />
                  <asp:TemplateField HeaderText="FEDERACIONES ASIGNADAS">
                    <ItemTemplate>
                      <asp:LinkButton runat="server" ID="idFederacion" type="button" CausesValidation="false" Text='<%# Eval("federacion") %>'
                        CommandName="Asignado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                      </asp:LinkButton>                    
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
