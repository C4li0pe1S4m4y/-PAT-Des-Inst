using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Read;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.P1
{
    public partial class IndexP1 : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        P1Ingresos pat = new P1Ingresos();
        IngresoCorriente ingreso = new IngresoCorriente();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloP1 modelo = new ModeloP1();
        ModeloObservacion obseracion = new ModeloObservacion();
        ModeloIngreso modelo_ingreso = new ModeloIngreso();
        Usuario id = new Usuario();

        public string year = Convert.ToString(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                fadn.Text = Session["Federacion"].ToString();
                anio.Text = year;
                CargarGrid();
            }
        }

        protected void CargarGrid()
        {
            crearP1IngresoNew.Visible = false;
            mostrarCrearP1Ingreso.Visible = false;
            mostrarCrearCodigo.Visible = false;
            mostrarEditP1Ingreso.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            mostrarObservacion.Visible = false;

            crearP1Ingreso.Visible = false;
            crearCodigo.Visible = false;
            editP1Ingreso.Visible = false;
            btPDF.Visible = false;
            btExcel.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridFADN.DataSource = pat.Part9Read();
                    gridFADN.DataBind();
                    gridFADN3.DataSource = pat.TotalP1Read(Session["Federacion"].ToString(), year, 0);
                    gridFADN3.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P1: INGRESOS");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearP1Ingreso.Visible = true;
                                crearCodigo.Visible = true;
                                guardarObservacionRechazo.Visible = true;
                                break;

                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;

                            case "Rechazar":
                                btcrearObservacionRechazo.Visible = true;
                                break;

                            case "Crear":
                                crearP1IngresoNew.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridFADN.DataSource = pat.Part9Read();
                    gridFADN.DataBind();
                    gridFADN3.DataSource = pat.TotalP1Read(Session["Federacion"].ToString(), year, 3);
                    gridFADN3.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P1: INGRESOS");

                    for (int j = 0; j < mostrar4.Rows.Count; j++)
                    {
                        switch (mostrar4.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                break;

                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;

                            case "Rechazar":
                                btcrearObservacionRechazo.Visible = true;
                                break;

                            case "Crear":
                                break;
                        }
                    }
                    break;

                case "Técnico Acompañamiento":
                    if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }

                    gridFADN.DataSource = pat.Part9Read();
                    gridFADN.DataBind();
                    gridFADN3.DataSource = pat.TotalP1Read(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN3.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P1: INGRESOS");

                    for (int j = 0; j < mostrar2.Rows.Count; j++)
                    {
                        switch (mostrar2.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                break;

                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;

                            case "Rechazar":
                                break;

                            case "Crear":
                                break;
                        }
                    }
                    break;

                case "Técnico Evaluación":
                    if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }

                    gridFADN.DataSource = pat.Part9Read();
                    gridFADN.DataBind();
                    gridFADN3.DataSource = pat.TotalP1Read(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN3.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P1: INGRESOS");

                    for (int j = 0; j < mostrar3.Rows.Count; j++)
                    {
                        switch (mostrar3.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                guardarObservacionRechazo.Visible = true;
                                break;

                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;

                            case "Rechazar":
                                btcrearObservacionRechazo.Visible = true;
                                break;

                            case "Crear":
                                break;
                        }
                    }
                    break;
            }
        }

        protected void nuevoP1Ingreso_Click(object sender, EventArgs e)
        {
            drop.Drop_TipoIngreso(dropCrearTipoIngreso);
            drop.Drop_Ingreso(dropCrearIngreso, 0);
            if(Session["FederacionAsignada"] == null)
            {
                drop.Drop_CodigoIngreso(dropCrearCodigoIngreso, 0, Session["Federacion"].ToString());
            }
            else
            {
                drop.Drop_CodigoIngreso(dropCrearCodigoIngreso, 0, Session["FederacionAsignada"].ToString());
            }
            mostrarCrearP1Ingreso.Visible = true;
        }

        protected void dropCrearTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTipoIngresoSelectCrear.Text = dropCrearTipoIngreso.SelectedItem.ToString();
            drop.Drop_Ingreso(dropCrearIngreso, int.Parse(dropCrearTipoIngreso.SelectedValue));
        }

        protected void dropCrearIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["FederacionAsignada"] == null)
            {
                drop.Drop_CodigoIngreso(dropCrearCodigoIngreso, int.Parse(dropCrearIngreso.SelectedValue), Session["Federacion"].ToString());
            }
            else
            {
                drop.Drop_CodigoIngreso(dropCrearCodigoIngreso, int.Parse(dropCrearIngreso.SelectedValue), Session["FederacionAsignada"].ToString());
            }
        }

        protected void dropCrearCodigoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pat.P1Search(int.Parse(dropCrearCodigoIngreso.SelectedValue), Session["Federacion"].ToString(), year) == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
            }
        }

        protected void crearP1Ingreso_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.col1 = double.Parse(txtCrearMonto1.Value);
                modelo.col2 = double.Parse(txtCrearMonto2.Value);
                modelo.col3 = double.Parse(txtCrearMonto3.Value);
                modelo.fkingreso = int.Parse(dropCrearCodigoIngreso.SelectedValue);
                modelo.fadn = Session["Federacion"].ToString();
                modelo.ano = year;
                modelo.fkestado = 1;

                pat.P1Create(modelo);
                CargarGrid();
                mostrarCrearP1Ingreso.Visible = false;
                txtCrearMonto1.Value = null;
                txtCrearMonto2.Value = null;
                txtCrearMonto3.Value = null;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelCrearP1Ingreso_Click(object sender, EventArgs e)
        {
            txtCrearMonto1.Value = null;
            txtCrearMonto2.Value = null;
            txtCrearMonto3.Value = null;
            mostrarCrearP1Ingreso.Visible = false;
        }

        protected void dropEditTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTipoIngresoSelectEdit.Text = dropEditTipoIngreso.SelectedItem.ToString();
            drop.Drop_Ingreso(dropEditIngreso, int.Parse(dropEditTipoIngreso.SelectedValue));
        }

        protected void dropEditIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["FederacionAsignada"] == null)
            {
                drop.Drop_CodigoIngreso(dropEditCodigoIngreso, int.Parse(dropEditIngreso.SelectedValue), Session["Federacion"].ToString());
            }
            else
            {
                drop.Drop_CodigoIngreso(dropEditCodigoIngreso, int.Parse(dropEditIngreso.SelectedValue), Session["FederacionAsignada"].ToString());
            }
        }

        protected void dropEditCodigoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pat.P1Search(int.Parse(dropEditCodigoIngreso.SelectedValue), Session["Federacion"].ToString(), year) == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
            }
        }

        protected void editP1Ingreso_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.col1 = double.Parse(txtEditMonto1.Value);
                modelo.col2 = double.Parse(txtEditMonto2.Value);
                modelo.col3 = double.Parse(txtEditMonto3.Value);
                modelo.fkingreso = int.Parse(dropEditCodigoIngreso.SelectedValue);
                modelo.fadn = Session["Federacion"].ToString();
                modelo.ano = year;
                modelo.fkestado = 1;

                pat.P1Update(modelo, int.Parse(idEditP1Ingreso.Text), 0);
                CargarGrid();
                mostrarEditP1Ingreso.Visible = false;
                txtEditMonto1.Value = null;
                txtEditMonto2.Value = null;
                txtEditMonto3.Value = null;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificado', 'success');", true);

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificado', 'error');", true);
            }
        }

        protected void cancelEditP1Ingreso_Click(object sender, EventArgs e)
        {
            txtEditMonto1.Value = null;
            txtEditMonto2.Value = null;
            txtEditMonto3.Value = null;
            mostrarEditP1Ingreso.Visible = false;
        }


        protected void cancelarObservacionRechazo_Click(object sender, EventArgs e)
        {
            crearObservacionRechazo.Visible = false;
        }

        protected void guardarObservacionRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                obseracion.id20 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.P1Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
                crearObservacionRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                txtCrearObservacion.Value = null;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }

        protected void btcrearObservacionRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                obseracion.id20 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    pat.P1Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
                    crearObservacionRechazo.Visible = false;
                    CargarGrid();
                }

                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                txtCrearObservacion.Value = null;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }

        protected void cancelObservacionSinRechazo_Click(object sender, EventArgs e)
        {
            crearObservacionSinRechazo.Visible = false;
        }

        protected void btObservacionSinRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                obseracion.id20 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.P1Update(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
                crearObservacionSinRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                txtCrearObservacionSinRechazo.Value = null;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }

        protected void btObservacionSinRechazoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                obs.observacionUpdateAcompaniamiento(int.Parse(idIntroObservacionSinRechazo.Text), txtCrearObservacionSinRechazo.Value);
                crearObservacionSinRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }

        protected void gridFADN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gridFADN2 = new GridView();
            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string customerId = gridFADN.DataKeys[e.Row.RowIndex].Value.ToString();
                        gridFADN2 = e.Row.FindControl("gridFADN2") as GridView;
                        gridFADN2.DataSource = pat.Part11Read(int.Parse(customerId), Session["Federacion"].ToString(), year, 0);
                        gridFADN2.DataBind();
                    }
                    break;

                case "Usuario CE de FADN":
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string customerId = gridFADN.DataKeys[e.Row.RowIndex].Value.ToString();
                        gridFADN2 = e.Row.FindControl("gridFADN2") as GridView;
                        gridFADN2.DataSource = pat.Part11Read(int.Parse(customerId), Session["Federacion"].ToString(), year, 3);
                        gridFADN2.DataBind();
                    }
                    break;

                case "Técnico Acompañamiento":
                    if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string customerId = gridFADN.DataKeys[e.Row.RowIndex].Value.ToString();
                        gridFADN2 = e.Row.FindControl("gridFADN2") as GridView;
                        gridFADN2.DataSource = pat.Part11Read(int.Parse(customerId), Session["FederacionAsignada"].ToString(), year, 6);
                        gridFADN2.DataBind();
                    }
                    break;

                case "Técnico Evaluación":
                    if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        string customerId = gridFADN.DataKeys[e.Row.RowIndex].Value.ToString();
                        gridFADN2 = e.Row.FindControl("gridFADN2") as GridView;
                        gridFADN2.DataSource = pat.Part11Read(int.Parse(customerId), Session["FederacionAsignada"].ToString(), year, 9);
                        gridFADN2.DataBind();
                    }
                    break;
            }

            foreach (GridViewRow row in gridFADN2.Rows)
            {
                gridFADN2.Columns[0].Visible = true;
                DataTable mostra = new DataTable();
                mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P1: INGRESOS");

                if (row.RowType == DataControlRowType.DataRow)
                {
                    (row.FindControl("btEditar") as LinkButton).Visible = false;
                    (row.FindControl("btVer") as LinkButton).Visible = false;
                    (row.FindControl("btEliminar") as LinkButton).Visible = false;
                    (row.FindControl("btObservacion") as LinkButton).Visible = false;
                    (row.FindControl("btAprobar") as LinkButton).Visible = false;
                    (row.FindControl("btEnviar") as LinkButton).Visible = false;
                    if(row.Cells[3].Text != "" || row.Cells[4].Text != "" || row.Cells[5].Text != "")
                    {
                        for (int j = 0; j < mostra.Rows.Count; j++)
                        {
                            switch (mostra.Rows[j][0].ToString())
                            {
                                case "Guardar":
                                    break;

                                case "Editar":
                                    if (pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 2)
                                    {
                                        (row.FindControl("btEditar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Ver":
                                    if (obs.ObservacionCEFADNExiste(int.Parse(row.Cells[0].Text), 21) == true
                                                || obs.ObservacionAcompaniamientoExiste(int.Parse(row.Cells[0].Text), 21) == true
                                                || obs.ObservacionEvaluadorExiste(int.Parse(row.Cells[0].Text), 21) == true)
                                    {
                                        (row.FindControl("btVer") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Eliminar":
                                    if (pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 1 || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 2)
                                    {
                                        (row.FindControl("btEliminar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Enviar":
                                    if (pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 1
                                            || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 2
                                            || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 3
                                            || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 6
                                            || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btEnviar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Aprobar":
                                    if (pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 3 || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btAprobar") as LinkButton).Visible = true;
                                    }

                                    break;

                                case "Observación":
                                    if (pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 3
                                            || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 6
                                            || pat.P1EstadoSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btObservacion") as LinkButton).Visible = true;
                                    }

                                    break;

                                case "PDF":
                                    break;

                                case "Excel":
                                    break;

                                case "Rechazar":
                                    break;

                                case "Crear":
                                    break;
                            }
                        }
                    }
                }
                gridFADN2.Columns[0].Visible = false;
            }
        }

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }

        protected void agregarCodigo_Click(object sender, EventArgs e)
        {
            drop.Drop_TipoIngreso(dropCrearTipoCodigo);
            drop.Drop_Ingreso(dropCrearListCodigo, 0);
            mostrarCrearCodigo.Visible = true;
        }

        protected void dropCrearTipoCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Ingreso(dropCrearListCodigo, int.Parse(dropCrearTipoCodigo.SelectedValue));
        }

        protected void cancelCrearCodigo_Click(object sender, EventArgs e)
        {
            mostrarCrearCodigo.Visible = false;
        }

        protected void crearCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                modelo_ingreso.codigo = txtCrearNumeroCodigo.Value;
                modelo_ingreso.nombre = txtCrearNombreCodigo.Value;
                modelo_ingreso.fadn = Session["Federacion"].ToString();
                modelo_ingreso.idpadre = int.Parse(dropCrearTipoCodigo.SelectedValue);
                modelo_ingreso.subpadre = int.Parse(dropCrearListCodigo.SelectedValue);

                ingreso.IngresoCreate(modelo_ingreso);
                CargarGrid();
                mostrarCrearCodigo.Visible = false;
                txtCrearNumeroCodigo.Value = null;
                txtCrearNombreCodigo.Value = null;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }


        public string Id;
        protected void gridFADN2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView gridFADN2 = new GridView();
            if (Session["Rol"].ToString() == "Usuario Interno de FADN")
            {
                foreach (GridViewRow ee in gridFADN.Rows)
                {
                    Id = gridFADN.DataKeys[ee.RowIndex].Value.ToString();
                    gridFADN2 = ee.FindControl("gridFADN2") as GridView;
                    gridFADN2.DataSource = pat.Part11Read(int.Parse(Id), Session["Federacion"].ToString(), year, 0);
                    gridFADN2.DataBind();
                }
            }
            if (Session["Rol"].ToString() == "Usuario CE de FADN")
            {
                foreach (GridViewRow ee in gridFADN.Rows)
                {
                    Id = gridFADN.DataKeys[ee.RowIndex].Value.ToString();
                    gridFADN2 = ee.FindControl("gridFADN2") as GridView;
                    gridFADN2.DataSource = pat.Part11Read(int.Parse(Id), Session["Federacion"].ToString(), year, 3);
                    gridFADN2.DataBind();
                }
            }
            if (Session["Rol"].ToString() == "Técnico Acompañamiento")
            {
                foreach (GridViewRow ee in gridFADN.Rows)
                {
                    Id = gridFADN.DataKeys[ee.RowIndex].Value.ToString();
                    gridFADN2 = ee.FindControl("gridFADN2") as GridView;
                    gridFADN2.DataSource = pat.Part11Read(int.Parse(Id), Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN2.DataBind();
                }
            }
            if (Session["Rol"].ToString() == "Técnico Evaluación")
            {
                foreach (GridViewRow ee in gridFADN.Rows)
                {
                    Id = gridFADN.DataKeys[ee.RowIndex].Value.ToString();
                    gridFADN2 = ee.FindControl("gridFADN2") as GridView;
                    gridFADN2.DataSource = pat.Part11Read(int.Parse(Id), Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN2.DataBind();
                }
            }

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridFADN2.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        data = pat.P1Seleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditP1Ingreso.Text = data.Rows[i][0].ToString();
                        }

                        idEditP1Ingreso.Visible = false;
                        mostrarEditP1Ingreso.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 21);

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazo.Text = data.Rows[i][0].ToString();
                            txtCrearObservacionSinRechazo.Value = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazo.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazoUpdate.Visible = true;
                        break;
                }
            }
            if (e.CommandName == "Mostrar")
            {
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 21);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 21);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 21);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.P1Seleccionar(int.Parse(row.Cells[0].Text));

                switch (Session["Rol"].ToString())
                {
                    case "Usuario CE de FADN":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazo.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazo.Visible = false;
                        crearObservacionRechazo.Visible = true;
                        btcrearObservacionRechazo.Visible = true;
                        break;

                    case "Técnico Acompañamiento":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazo.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazo.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazo.Visible = true;
                        break;

                    case "Técnico Evaluación":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazo.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazo.Visible = false;
                        crearObservacionRechazo.Visible = true;
                        guardarObservacionRechazo.Visible = true;
                        btcrearObservacionRechazo.Visible = true;
                        break;
                }
            }
            if (e.CommandName == "Aprobar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario CE de FADN":
                        obseracion.id19 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.P1Update(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id19 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.P1Update(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.P1Update(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id19 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.P1Update(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            gridFADN2.Columns[0].Visible = false;
        }
    }
}
