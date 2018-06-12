using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.ResultadoPotencia
{
    public partial class ResultadoPotencia : System.Web.UI.Page
    {
        ResultadosPotencias pat = new ResultadosPotencias();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloResultado modelor = new ModeloResultado();
        ModeloPotencia modelop = new ModeloPotencia();
        ModeloObservacion obseracion = new ModeloObservacion();
        DropDown drop = new DropDown();
        Usuario id = new Usuario();
        public string year = Convert.ToString(DateTime.Now.Year);
        public bool encontro;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
            CargarGrid();
        }

        protected void CargarGrid()
        {
            gridResultado.Columns[0].Visible = true;
            gridPotencia.Columns[0].Visible = true;

            txtCrearFechaResultado.Text = year;
            txtEditFechaResultado.Text = year;

            btPDF.Visible = false;
            btExcel.Visible = false;
            crearResultadoPotenciaNew.Visible = false;
            mostrarCrearResultado.Visible = false;
            crearResultado.Visible = false;
            mostrarCrearPotencia.Visible = false;
            crearPotencia.Visible = false;
            mostrarEditResultado.Visible = false;
            mostrarEditPotencia.Visible = false;
            crearObservacionRechazo.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;
            mostrarObservacion.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridResultado.DataSource = pat.ResultadoRead(Session["Federacion"].ToString(), year, 0);
                    gridResultado.DataBind();
                    gridPotencia.DataSource = pat.PotenciaRead(Session["Federacion"].ToString(), year, 0);
                    gridPotencia.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "PRINCIPALES POTENCIAS");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearResultado.Visible = true;
                                crearPotencia.Visible = true;
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
                                crearResultadoPotenciaNew.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridResultado.DataSource = pat.ResultadoRead(Session["Federacion"].ToString(), year, 3);
                    gridResultado.DataBind();
                    gridPotencia.DataSource = pat.PotenciaRead(Session["Federacion"].ToString(), year, 3);
                    gridPotencia.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "PRINCIPALES POTENCIAS");

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
                    gridResultado.DataSource = pat.ResultadoRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridResultado.DataBind();
                    gridPotencia.DataSource = pat.PotenciaRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridPotencia.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "PRINCIPALES POTENCIAS");

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
                    gridResultado.DataSource = pat.ResultadoRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridResultado.DataBind();
                    gridPotencia.DataSource = pat.PotenciaRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridPotencia.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "PRINCIPALES POTENCIAS");

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
            gridResultado.Columns[0].Visible = false;
            gridPotencia.Columns[0].Visible = false;
        }

        protected void nuevoResultado_Click(object sender, EventArgs e)
        {
            drop.Drop_Nivel(dropCrearNivelResultado, 1);
            drop.Drop_Categoria(dropCrearCategoriaResultado, 1);
            mostrarCrearResultado.Visible = true;
        }

        protected void nuevaBrecha_Click(object sender, EventArgs e)
        {
            drop.Drop_Nivel(dropCrearNivelPotencia, 1);
            mostrarCrearPotencia.Visible = true;
        }

        protected void cancelCrearResultado_Click(object sender, EventArgs e)
        {
            mostrarCrearResultado.Visible = false;
        }

        protected void crearResultado_Click(object sender, EventArgs e)
        {
            try
            {
                modelor.fknivel = int.Parse(dropCrearNivelResultado.SelectedValue);
                modelor.nombre = txtCrearCompetenciaResultado.Value;
                modelor.sede = txtCrearSedeResultado.Value;
                modelor.fecha = int.Parse(txtCrearFechaResultado.Text);
                modelor.fkcategoria = int.Parse(dropCrearCategoriaResultado.SelectedValue);
                modelor.resultado = txtCrearResultadoResultado.Value;
                modelor.observacion = txtCrearObservacionResultado.Value;
                modelor.fadn = Session["Federacion"].ToString();
                modelor.anio = year;
                modelor.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.ResultadoRead(Session["Federacion"].ToString(), year, 0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (dropCrearNivelResultado.SelectedValue == data.Rows[i][1].ToString())
                    {
                        encontro = true;
                    }
                    else
                    {
                        encontro = false;
                    }
                }

                if (encontro == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.ResultadoCreate(modelor);
                    txtCrearCompetenciaResultado.Value = null;
                    txtCrearSedeResultado.Value = null;
                    txtCrearFechaResultado.Text = null;
                    txtCrearResultadoResultado.Value = null;
                    txtCrearObservacionResultado.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelCrearPotencia_Click(object sender, EventArgs e)
        {
            mostrarCrearPotencia.Visible = false;
        }

        protected void crearPotencia_Click(object sender, EventArgs e)
        {
            try
            {
                modelop.primera = txtCrearPrimeraPotencia.Value;
                modelop.segunda = txtCrearSegundaPotencia.Value;
                modelop.tercera = txtCrearTerceraPotencia.Value;
                modelop.potencia = txtCrearPosicionPotencia.Value;
                modelop.fknivel = int.Parse(dropCrearNivelPotencia.SelectedValue);
                modelop.fadn = Session["Federacion"].ToString();
                modelop.anio = year;
                modelop.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.PotenciaRead(Session["Federacion"].ToString(), year, 0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (dropCrearNivelPotencia.SelectedValue == data.Rows[i][1].ToString())
                    {
                        encontro = true;
                    }
                    else
                    {
                        encontro = false;
                    }
                }

                if (encontro == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.PotenciaCreate(modelop);
                    txtCrearPrimeraPotencia.Value = null;
                    txtCrearSegundaPotencia.Value = null;
                    txtCrearTerceraPotencia.Value = null;
                    txtCrearPosicionPotencia.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelEditResultado_Click(object sender, EventArgs e)
        {
            mostrarEditResultado.Visible = false;
        }

        protected void editResultado_Click(object sender, EventArgs e)
        {
            try
            {
                modelor.fknivel = int.Parse(dropEditNivelResultado.SelectedValue);
                modelor.nombre = txtEditCompetenciaResultado.Value;
                modelor.sede = txtEditSedeResultado.Value;
                modelor.fecha = int.Parse(txtEditFechaResultado.Text);
                modelor.fkcategoria = int.Parse(dropEditCategoriaResultado.SelectedValue);
                modelor.resultado = txtEditResultadoResultado.Value;
                modelor.observacion = txtEditObservacionResultado.Value;

                DataTable data = new DataTable();
                data = pat.ResultadoRead(Session["Federacion"].ToString(), year, 0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (dropEditNivelResultado.SelectedValue == data.Rows[i][1].ToString())
                    {
                        encontro = true;
                    }
                    else
                    {
                        encontro = false;
                    }
                }

                if (encontro == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.ResultadoUpdate(modelor, int.Parse(idEditResultado.Text), 0);
                    txtEditCompetenciaResultado.Value = null;
                    txtEditSedeResultado.Value = null;
                    txtEditFechaResultado.Text = null;
                    txtEditResultadoResultado.Value = null;
                    txtEditObservacionResultado.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelEditPotencia_Click(object sender, EventArgs e)
        {
            mostrarEditPotencia.Visible = false;
        }

        protected void editPotencia_Click(object sender, EventArgs e)
        {
            try
            {
                modelop.primera = txtEditPrimeraPotencia.Value;
                modelop.segunda = txtEditSegundaPotencia.Value;
                modelop.tercera = txtEditTerceraPotencia.Value;
                modelop.potencia = txtEditPosicionPotencia.Value;
                modelop.fknivel = int.Parse(dropEditNivelPotencia.SelectedValue);

                DataTable data = new DataTable();
                data = pat.PotenciaRead(Session["Federacion"].ToString(), year, 0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (dropEditNivelPotencia.SelectedValue == data.Rows[i][1].ToString())
                    {
                        encontro = true;
                    }
                    else
                    {
                        encontro = false;
                    }
                }

                if (encontro == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.PotenciaUpdate(modelop, int.Parse(idEditPotencia.Text), 0);
                    txtEditPrimeraPotencia.Value = null;
                    txtEditSegundaPotencia.Value = null;
                    txtEditTerceraPotencia.Value = null;
                    txtEditPosicionPotencia.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelarObservacionRechazo_Click(object sender, EventArgs e)
        {
            crearObservacionRechazo.Visible = false;
        }

        protected void guardarObservacionRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                if (idIntroObservacionRechazoResultado.Text != "")
                {
                    obseracion.id26 = int.Parse(idIntroObservacionRechazoResultado.Text);
                }
                if (idIntroObservacionRechazoPotencia.Text != "")
                {
                    obseracion.id25 = int.Parse(idIntroObservacionRechazoPotencia.Text);
                }
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                if (idIntroObservacionRechazoResultado.Text != "")
                {
                    pat.ResultadoUpdate(modelor, int.Parse(idIntroObservacionRechazoResultado.Text), 13);
                }
                if (idIntroObservacionRechazoPotencia.Text != "")
                {
                    pat.PotenciaUpdate(modelop, int.Parse(idIntroObservacionRechazoPotencia.Text), 13);
                }
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
                if (idIntroObservacionRechazoResultado.Text != "")
                {
                    obseracion.id26 = int.Parse(idIntroObservacionRechazoResultado.Text);
                }
                if (idIntroObservacionRechazoPotencia.Text != "")
                {
                    obseracion.id25 = int.Parse(idIntroObservacionRechazoPotencia.Text);
                }
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    if (idIntroObservacionRechazoResultado.Text != "")
                    {
                        pat.ResultadoUpdate(modelor, int.Parse(idIntroObservacionRechazoResultado.Text), 2);
                    }
                    if (idIntroObservacionRechazoPotencia.Text != "")
                    {
                        pat.PotenciaUpdate(modelop, int.Parse(idIntroObservacionRechazoPotencia.Text), 2);
                    }
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
                if (idIntroObservacionSinRechazoResultado.Text != "")
                {
                    obseracion.id26 = int.Parse(idIntroObservacionSinRechazoResultado.Text);
                }
                if (idIntroObservacionSinRechazoPotencia.Text != "")
                {
                    obseracion.id25 = int.Parse(idIntroObservacionSinRechazoPotencia.Text);
                }
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                if (idIntroObservacionSinRechazoResultado.Text != "")
                {
                    pat.ResultadoUpdate(modelor, int.Parse(idIntroObservacionSinRechazoResultado.Text), 9);
                }
                if (idIntroObservacionSinRechazoPotencia.Text != "")
                {
                    pat.PotenciaUpdate(modelop, int.Parse(idIntroObservacionSinRechazoPotencia.Text), 9);
                }
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
                if (idIntroObservacionSinRechazoResultado.Text != "")
                {
                    obs.observacionUpdateAcompaniamiento(int.Parse(idIntroObservacionSinRechazoResultado.Text), txtCrearObservacionSinRechazo.Value);
                }
                if (idIntroObservacionSinRechazoPotencia.Text != "")
                {
                    obs.observacionUpdateAcompaniamiento(int.Parse(idIntroObservacionSinRechazoPotencia.Text), txtCrearObservacionSinRechazo.Value);
                }
                crearObservacionSinRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }

        protected void gridResultado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "PRINCIPALES POTENCIAS");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridResultado.Columns[0].Visible = true;

                (e.Row.FindControl("btEditar") as LinkButton).Visible = false;
                (e.Row.FindControl("btVer") as LinkButton).Visible = false;
                (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                (e.Row.FindControl("btObservacion") as LinkButton).Visible = false;
                (e.Row.FindControl("btAprobar") as LinkButton).Visible = false;
                (e.Row.FindControl("btEnviar") as LinkButton).Visible = false;

                for (int j = 0; j < mostra.Rows.Count; j++)
                {
                    switch (mostra.Rows[j][0].ToString())
                    {
                        case "Guardar":
                            break;

                        case "Editar":
                            if (pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 27) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 27) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 27) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.ResultadoSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
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

        protected void gridResultado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridResultado.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridResultado.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Nivel(dropEditNivelResultado, 1);
                        drop.Drop_Categoria(dropEditCategoriaResultado, 1);
                        data = pat.ResultadoSeleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditResultado.Text = data.Rows[i][0].ToString();
                            dropEditNivelResultado.SelectedValue = data.Rows[i][1].ToString();
                            txtEditCompetenciaResultado.Value = data.Rows[i][2].ToString();
                            txtEditSedeResultado.Value = data.Rows[i][3].ToString();
                            txtEditFechaResultado.Text = data.Rows[i][4].ToString();
                            dropEditCategoriaResultado.SelectedValue = data.Rows[i][5].ToString();
                            txtEditResultadoResultado.Value = data.Rows[i][6].ToString();
                            txtEditObservacionResultado.Value = data.Rows[i][7].ToString();
                        }

                        idEditResultado.Visible = false;
                        mostrarEditResultado.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 27);

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoResultado.Text = data.Rows[i][0].ToString();
                            txtCrearObservacionSinRechazo.Value = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoResultado.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazoUpdate.Visible = true;
                        break;
                }
            }
            if (e.CommandName == "Mostrar")
            {
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 27);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 27);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 27);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.ResultadoSeleccionar(int.Parse(row.Cells[0].Text));

                switch (Session["Rol"].ToString())
                {
                    case "Usuario CE de FADN":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoResultado.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoResultado.Visible = false;
                        crearObservacionRechazo.Visible = true;
                        btcrearObservacionRechazo.Visible = true;
                        break;

                    case "Técnico Acompañamiento":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoResultado.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoResultado.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazo.Visible = true;
                        break;

                    case "Técnico Evaluación":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoResultado.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoResultado.Visible = false;
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
                        obseracion.id26 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.ResultadoUpdate(modelor, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id26 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.ResultadoUpdate(modelor, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.ResultadoUpdate(modelor, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id26 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.ResultadoUpdate(modelor, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            gridResultado.Columns[0].Visible = false;
        }

        protected void gridPotencia_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "PRINCIPALES POTENCIAS");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridPotencia.Columns[0].Visible = true;

                (e.Row.FindControl("btEditar") as LinkButton).Visible = false;
                (e.Row.FindControl("btVer") as LinkButton).Visible = false;
                (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                (e.Row.FindControl("btObservacion") as LinkButton).Visible = false;
                (e.Row.FindControl("btAprobar") as LinkButton).Visible = false;
                (e.Row.FindControl("btEnviar") as LinkButton).Visible = false;

                for (int j = 0; j < mostra.Rows.Count; j++)
                {
                    switch (mostra.Rows[j][0].ToString())
                    {
                        case "Guardar":
                            break;

                        case "Editar":
                            if (pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 26) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 26) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 26) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.PotenciaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
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

        protected void gridPotencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridPotencia.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridPotencia.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Nivel(dropEditNivelPotencia, 1);
                        data = pat.PotenciaSeleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditPotencia.Text = data.Rows[i][0].ToString();
                            dropEditNivelPotencia.SelectedValue = data.Rows[i][1].ToString();
                            txtEditPrimeraPotencia.Value = data.Rows[i][2].ToString();
                            txtEditSegundaPotencia.Value = data.Rows[i][3].ToString();
                            txtEditTerceraPotencia.Value = data.Rows[i][4].ToString();
                            txtEditPosicionPotencia.Value = data.Rows[i][5].ToString();
                        }

                        idEditPotencia.Visible = false;
                        mostrarEditPotencia.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoPotencia.Text = data.Rows[i][0].ToString();
                            txtCrearObservacionSinRechazo.Value = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoPotencia.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazoUpdate.Visible = true;
                        break;
                }
            }
            if (e.CommandName == "Mostrar")
            {
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 26);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 26);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 26);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.PotenciaSeleccionar(int.Parse(row.Cells[0].Text));

                switch (Session["Rol"].ToString())
                {
                    case "Usuario CE de FADN":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoPotencia.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoPotencia.Visible = false;
                        crearObservacionRechazo.Visible = true;
                        btcrearObservacionRechazo.Visible = true;
                        break;

                    case "Técnico Acompañamiento":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoPotencia.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoPotencia.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazo.Visible = true;
                        break;

                    case "Técnico Evaluación":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoPotencia.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoPotencia.Visible = false;
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
                        obseracion.id25 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.PotenciaUpdate(modelop, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id25 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.PotenciaUpdate(modelop, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.PotenciaUpdate(modelop, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id25 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.PotenciaUpdate(modelop, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            gridPotencia.Columns[0].Visible = false;
        }

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }
    }
}