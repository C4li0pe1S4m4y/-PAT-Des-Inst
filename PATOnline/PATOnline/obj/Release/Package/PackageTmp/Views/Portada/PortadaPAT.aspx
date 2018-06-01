<%@ Page Title="PORTADA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PortadaPAT.aspx.cs" Inherits="PATOnline.Views.Portada.PortadaPAT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0 text-dark"><%: Title %></h1>
        </div>
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item">Home</li>
            <li class="breadcrumb-item active">Portada</li>
          </ol>
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
            <div class="card-body" style="align-items:center; align-content:center; text-align:center">
              <div class="row">
                <div class="col-md-12">
                  <asp:Image runat="server" ID="Imagelogo" CssClass="logo" Width="200" Height="200" />
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <h1> <b> <asp:Label runat="server" ID="lblFederacion"></asp:Label> </b> </h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <h1> <b>PLAN ANUAL DE TRABAJO</b> </h1>
                </div>
              </div>
              <div class="row">
                <div class="col-md-12">
                  <h1> <b> <asp:Label runat="server" ID="lblAnio"></asp:Label> </b> </h1>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</asp:Content>
