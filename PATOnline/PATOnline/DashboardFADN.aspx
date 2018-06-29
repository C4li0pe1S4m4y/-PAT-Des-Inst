<%@ Page Title="DASHBOARD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardFADN.aspx.cs" Inherits="PATOnline.DashboardFADN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <script src="Content/Highcharts-6.1.0/code/highcharts.js"></script>
  <script src="Content/Highcharts-6.1.0/code/highcharts-3d.js"></script>
  <script src="Content/Highcharts-6.1.0/code/modules/xrange.js"></script>
  <script src="Content/Highcharts-6.1.0/code/modules/export-data.js"></script>
  <script src="Content/Highcharts-6.1.0/code/modules/exporting.js"></script>

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-md-10">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
      </div>
    </div>
  </div>

  <section class="content" runat="server" id="mostrarAsignados">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-success">
            <div class="card-header" style="text-align: center;">
              <h3 class="card-title"><span class="info-box-number">FEDERACIONES / ASOCIACIONES ASIGNADAS</span></h3>
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
        <div class="col-md-12">
          <div class="card card-outline card-danger">
            <div class="card-header" style="align-content: center; text-align: center;">
              <h3 class="card-title"><span class="info-box-number">GRÁFICAS DE ESTADOS DEL PAT</span></h3>
            </div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-4">
          <div class="callout callout-info">
            <h5>INTRODUCCIÓN</h5>
            <div id="graficaEstadosPATIntroduccion"></div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="callout callout-warning">
            <h5>ORGANIGRAMA</h5>
            <div id="graficaEstadosPATOrganigrama"></div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="callout callout-success">
            <h5>DIRIGENCIA DEPORTIVA</h5>
            <div id="graficaEstadosPATDirigencia"></div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-4">
          <div class="callout callout-danger">
            <h5>ANÁLISIS DE PUESTOS LOGRADOS</h5>
            <div id="graficaEstadosPATLogros"></div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="callout callout-info">
            <h5>ANÁLISIS DE BRECHAS</h5>
            <div id="graficaEstadosPATBrechas"></div>
          </div>
        </div>
        <div class="col-md-4">
          <div class="callout callout-warning">
            <h5>ANÁLISIS DE POTENCIAS</h5>
            <div id="graficaEstadosPATPotencia"></div>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <div class="callout callout-success">
            <h5>RESULTADOS DEPORTIVOS</h5>
            <div id="graficaEstadosPATResultado"></div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="callout callout-danger">
            <h5>FODA Y BASE ESTRATÉGICA</h5>
            <div id="graficaEstadosPATFODA"></div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <div class="card card-outline card-warning">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">GRÁFICAS DE PORCENTAJE DE IMPRESIÓN PAT</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <div id="graficaPorcentajeEstado"></div>
                </div>
              </div>
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
          <div class="card card-outline card-info">
            <div class="card-header">
              <h3 class="card-title"><span class="info-box-number">GRÁFICAS DE CANTIDAD DE DOCUMENTOS APROBADOS O RECHAZADOS</span></h3>
              <div class="card-tools">
                <button type="button" class="btn btn-tool btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i>
                </button>
              </div>
            </div>

            <div class="card-body pad" style="display: block;">
              <div class="row">
                <div class="col-md-12">
                  <div id="graficaComite"></div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <hr />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <div id="graficaAcompaniamiento"></div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <hr />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <div id="graficaEvaluador"></div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>

  <script type="text/javascript">

    Highcharts.chart('graficaComite', {
      chart: {
        type: 'column'
      },
      title: {
        text: 'Comite Ejecutivo'
      },
      subtitle: {
        text: 'Aprovados / Rechazados'
      },
      xAxis: {
        categories: [
          'INTRODUCCIÓN',
          'ORGANIGRAMA',
          'DIRIGENTES DEPORTIVOS',
          'LOGROS',
          'BRECHAS',
          'RESULTADOS',
          'POTENCIAS',
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
      series: [<%=graficasAprobadoRechazadoComite()%>]
    });

    Highcharts.chart('graficaAcompaniamiento', {
      chart: {
        type: 'column'
      },
      title: {
        text: 'Acompañamiento'
      },
      subtitle: {
        text: 'Aprovados / Rechazados'
      },
      xAxis: {
        categories: [
          'INTRODUCCIÓN',
          'ORGANIGRAMA',
          'DIRIGENTES DEPORTIVOS',
          'LOGROS',
          'BRECHAS',
          'RESULTADOS',
          'POTENCIAS',
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
      series: [<%=graficasAprobadoRechazadoAcompaniamiento()%>]
    });

    Highcharts.chart('graficaEvaluador', {
      chart: {
        type: 'column'
      },
      title: {
        text: 'Evaluador'
      },
      subtitle: {
        text: 'Aprovados / Rechazados'
      },
      xAxis: {
        categories: [
          'INTRODUCCIÓN',
          'ORGANIGRAMA',
          'DIRIGENTES DEPORTIVOS',
          'LOGROS',
          'BRECHAS',
          'RESULTADOS',
          'POTENCIAS',
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
      series: [<%=graficasAprobadoRechazadoEvaluador()%>]
    });

    Highcharts.chart('graficaPorcentajeEstado', {
      chart: {
        type: 'xrange'
      },
      title: {
        text: 'Estado de Impresión'
      },
      xAxis: {
        crosshair: true,
        type: 'column'
      },
      yAxis: {
        title: {
          text: ''
        },
        categories: [
          'INTRODUCCIÓN',
          'ORGANIGRAMA',
          'DIRIGENTES DEPORTIVOS',
          'LOGROS',
          'BRECHAS',
          'RESULTADOS',
          'POTENCIAS',
          'FODA Y BASE LEGAL'
        ],
        reversed: true
      },
      series: [{
        name: 'Imprimir',
        pointWidth: 16,
        data: [<%=graficasPorcentajeEstado()%>],
        dataLabels: {
          enabled: true
        }
      }]

    });

    Highcharts.chart('graficaEstadosPATIntroduccion', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATIntroduccion()%>]
      }]
    });

    Highcharts.chart('graficaEstadosPATOrganigrama', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATOrganigrama()%>]
      }]
    });

    Highcharts.chart('graficaEstadosPATDirigencia', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATDirigencia()%>]
      }]
    });

    Highcharts.chart('graficaEstadosPATLogros', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATLogros()%>]
      }]
    });

    Highcharts.chart('graficaEstadosPATBrechas', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATBrechas()%>]
      }]
    });

    Highcharts.chart('graficaEstadosPATPotencia', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATPotencia()%>]
      }]
    });

    Highcharts.chart('graficaEstadosPATResultado', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATResultado()%>]
      }]
    });

    Highcharts.chart('graficaEstadosPATFODA', {
      chart: {
        plotBackgroundColor: null,
        plotBorderWidth: 0,
        plotShadow: false
      },
      title: {
        text: 'ESTADOS',
        align: 'center',
        verticalAlign: 'middle',
        y: 80
      },
      tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
      },
      plotOptions: {
        pie: {
          dataLabels: {
            enabled: true,
            distance: -50,
            style: {
              fontWeight: 'bold',
              color: 'white'
            }
          },
          startAngle: -90,
          endAngle: 90,
          center: ['50%', '75%']
        }
      },
      series: [{
        type: 'pie',
        name: 'Porcentaje de Estado',
        innerSize: '50%',
        data: [<%=graficaEstadosPATFODA()%>]
      }]
    });
  </script>
</asp:Content>
