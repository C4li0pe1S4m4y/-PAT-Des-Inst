<%@ Page Title="DASHBOARD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardFADN.aspx.cs" Inherits="PATOnline.DashboardFADN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <script type="text/javascript">
    google.charts.load('current', { 'packages': ['bar'] });

    google.charts.setOnLoadCallback(drawChart1);

    function drawChart1() {
      var data = google.visualization.arrayToDataTable(<%=graficasAprobadoRechazadoIntroduccion()%>);

      var options = {
        chart: {
          title: <%=federacionGrafica()%>,
          subtitle: 'Acciones en los documentos del PAT',
          colors: ['#ea4808', '#44b241', '#90c320', '#0bafb8', '#f08600', '#dc0615', '#f6ed12'],
        }
      };

      var chart = new google.charts.Bar(document.getElementById('graficasAprobadoRechazado'));
      chart.draw(data, options);
    }

    $(window).resize(function () {
      drawChart();
    });

  </script>

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
                  <asp:TemplateField HeaderText="FEDERACIONES ASIGNADAS" ItemStyle-Width="100%">
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

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12" style="width: 800px; height: 500px;">
          <div id="graficasAprobadoRechazado" class="chart"></div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
