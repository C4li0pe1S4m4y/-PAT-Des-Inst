<%@ Page Title="DASHBOARD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardAdmin.aspx.cs" Inherits="PATOnline.DashboardAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <script type="text/javascript">
    google.charts.load('current', { 'packages': ['corechart'] });

    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
      var data = google.visualization.arrayToDataTable(<%=graficaUsuarioActivoInactivo()%>);

      var options = {
        title: 'Usuario Activos e Inactivos en el Sistema PATOnline',
        chartArea: { left: 5, right: 5, top: 25, bottom: 10 },
        colors: ['#ea4808', '#44b241', '#90c320', '#0bafb8', '#f08600', '#dc0615', '#f6ed12'],
      };

      var chart = new google.visualization.PieChart(document.getElementById('graficaUsuarioActivoInactivo'));
      chart.draw(data, options);
    }

    $(window).resize(function () {
      drawChart();
    });

  </script>

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-md-6">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item active">Dashboard</li>
          </ol>
        </div>
      </div>
    </div>
  </div>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-lg-3 col-6">
          <!-- small box -->
          <div class="small-box bg-info">
            <div class="inner">
              <h3>150</h3>

              <p>New Orders</p>
            </div>
            <div class="icon">
              <i class="ion ion-bag"></i>
            </div>
            <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-6">
          <!-- small box -->
          <div class="small-box bg-success">
            <div class="inner">
              <h3>53<sup style="font-size: 20px">%</sup></h3>

              <p>Bounce Rate</p>
            </div>
            <div class="icon">
              <i class="ion ion-stats-bars"></i>
            </div>
            <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-6">
          <!-- small box -->
          <div class="small-box bg-warning">
            <div class="inner">
              <h3><asp:Label runat="server" ID="cantidadUsuario"></asp:Label></h3>

              <p>Usuarios Registrados</p>
            </div>
            <div class="icon">
              <i class="ion ion-person-add"></i>
            </div>
            <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-6">
          <!-- small box -->
          <div class="small-box bg-danger">
            <div class="inner">
              <h3>65</h3>

              <p>Unique Visitors</p>
            </div>
            <div class="icon">
              <i class="ion ion-pie-graph"></i>
            </div>
            <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
      </div>
    </div>
  </section>

  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-6">
          <div id="graficaUsuarioActivoInactivo" class="chart"></div>
        </div>
      </div>
    </div>
  </section>

</asp:Content>
