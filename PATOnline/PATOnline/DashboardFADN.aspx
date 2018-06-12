<%@ Page Title="DASHBOARD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardFADN.aspx.cs" Inherits="PATOnline.DashboardFADN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <script src="Content/Highcharts-6.1.0/code/highcharts.js"></script>

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
          <div id="container" class="chart"></div>
        </div>
      </div>
    </div>
  </section>

<script type="text/javascript">

  Highcharts.chart('container', {
    chart: {
      type: 'column'
    },
    title: {
      text: 'Documentos del PAT'
    },
    subtitle: {
      text: 'Aprovados / Rechazados'
    },
    xAxis: {
      categories: [
        'INTRODUCCIÓN',
        'ORGANIGRAMA',
        'DIRIGENTES DEPORTIVOS',
        'LOGROS Y BRECHAS',
        'RESULTADOS Y POTENCIAS',
        'FODA Y BASE LEGAL'
      ],
      crosshair: true
    },
    yAxis: {
      min: 0,
      title: {
        text: 'cantidad'
      }
    },
    tooltip: {
      headerFormat: '<span style="font-size:10px">{point.key} </span><table>',
      pointFormat: '<tr><td style="color:{series.color};padding:0"> {series.name}: </td>' +
        '<td style="padding:0"><b> {point.y:.f} total</b></td></tr>',
      footerFormat: '</table>',
      shared: true,
      useHTML: true
    },
    plotOptions: {
      column: {
        pointPadding: 0.2,
        borderWidth: 0
      }
    },
    series: [<%=graficasAprobadoRechazadoIntroduccion()%>]
  });
		</script>
</asp:Content>
