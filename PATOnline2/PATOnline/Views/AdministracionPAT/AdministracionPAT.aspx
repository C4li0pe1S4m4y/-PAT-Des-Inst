  <section class="content">
    <div class="container-fluid">
      <div class="row">
        <div class="col-2 col-sm-2 col-md-2">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Brecha</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevaBrecha" CausesValidation="false" OnClick="nuevaBrecha_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-2 col-sm-2 col-md-2">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Cargo</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoCargo" CausesValidation="false" OnClick="nuevoCargo_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-2 col-sm-2 col-md-2">
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
        <div class="col-2 col-sm-2 col-md-2">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Nivel</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoNivel" CausesValidation="false" OnClick="nuevoNivel_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
        <div class="col-2 col-sm-2 col-md-2">
          <div class="info-box">
            <div class="info-box-content">
              <span class="info-box-text">Agregar</span>
              <span class="info-box-number">Nivel</span>
            </div>
            <asp:LinkButton runat="server" ID="nuevoTipoPersona" CausesValidation="false" OnClick="nuevoTipoPersona_Click">
              <span class="info-box-icon bg-info elevation-1"><i class="fa fa-plus-circle"></i></span>
            </asp:LinkButton>
          </div>
        </div>
      </div>
    </div>
  </section>