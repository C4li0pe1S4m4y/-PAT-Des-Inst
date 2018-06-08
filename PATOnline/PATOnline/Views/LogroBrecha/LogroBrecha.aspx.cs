using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.LogroBrecha
{
    public partial class LogroBrecha : System.Web.UI.Page
    {
        PuestoLogroAnalisisBrecha pat = new PuestoLogroAnalisisBrecha();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloPuestoLogrado modelop = new ModeloPuestoLogrado();
        ModeloBrechaCategoria modelob = new ModeloBrechaCategoria();
        ModeloObservacion obseracion = new ModeloObservacion();
        DropDown drop = new DropDown();
        Usuario id = new Usuario();
        public string year = Convert.ToString(DateTime.Now.Year);
        public bool encontro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
            anio.Text = year;
            CargarGrid();
        }

        protected void CargarGrid()
        {
            gridPuestoLogrado.Columns[0].Visible = true;
            gridAnalisisBrecha.Columns[0].Visible = true;

            btPDF.Visible = false;
            btExcel.Visible = false;
            crearLogroBrechaNew.Visible = false;
            mostrarCrearPuesto.Visible = false;
            crearPuesto.Visible = false;
            mostrarCrearBrecha.Visible = false;
            crearBrecha.Visible = false;
            mostrarEditPuesto.Visible = false;
            mostrarEditBrecha.Visible = false;
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
                    gridPuestoLogrado.DataSource = pat.PuestoLogradoRead(Session["Federacion"].ToString(), 0);
                    gridPuestoLogrado.DataBind();
                    gridAnalisisBrecha.DataSource = pat.BrechaRead(Session["Federacion"].ToString(), year, 0);
                    gridAnalisisBrecha.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "LOGROS Y BRECHAS");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearPuesto.Visible = true;
                                crearBrecha.Visible = true;
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
                                crearLogroBrechaNew.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridPuestoLogrado.DataSource = pat.PuestoLogradoRead(Session["Federacion"].ToString(), 3);
                    gridPuestoLogrado.DataBind();
                    gridAnalisisBrecha.DataSource = pat.BrechaRead(Session["Federacion"].ToString(), year, 3);
                    gridAnalisisBrecha.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "LOGROS Y BRECHAS");

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
                    gridPuestoLogrado.DataSource = pat.PuestoLogradoRead(Session["FederacionAsignada"].ToString(), 6);
                    gridPuestoLogrado.DataBind();
                    gridAnalisisBrecha.DataSource = pat.BrechaRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridAnalisisBrecha.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "LOGROS Y BRECHAS");

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
                    gridPuestoLogrado.DataSource = pat.PuestoLogradoRead(Session["FederacionAsignada"].ToString(), 9);
                    gridPuestoLogrado.DataBind();
                    gridAnalisisBrecha.DataSource = pat.BrechaRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridAnalisisBrecha.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "LOGROS Y BRECHAS");

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
            gridPuestoLogrado.Columns[0].Visible = false;
            gridAnalisisBrecha.Columns[0].Visible = false;
        }

        protected void nuevoPuesto_Click(object sender, EventArgs e)
        {
            drop.Drop_Anio(dropCrearAnioPuesto);
            mostrarCrearPuesto.Visible = true;
        }

        protected void nuevaBrecha_Click(object sender, EventArgs e)
        {
            drop.Drop_Brecha(dropCrearAnalisisBrechaBrecha);
            mostrarCrearBrecha.Visible = true;
        }

        protected void cancelCrearPuesto_Click(object sender, EventArgs e)
        {
            mostrarCrearPuesto.Visible = false;
        }

        protected void crearPuesto_Click(object sender, EventArgs e)
        {
            try
            {
                modelop.fkanio = int.Parse(dropCrearAnioPuesto.SelectedValue);
                modelop.puesto = int.Parse(txtCrearPuestoObtenidoPuesto.Value);
                modelop.punteo = double.Parse(txtCrearPuntosPuesto.Value);
                modelop.observacion = txtCrearObservacionPuesto.Value;
                modelop.fadn = Session["Federacion"].ToString();
                modelop.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.PuestoLogradoRead(Session["Federacion"].ToString(), 0);
                for (int i=0; i<data.Rows.Count; i++)
                {
                    if(dropCrearAnioPuesto.SelectedValue == data.Rows[i][1].ToString())
                    {
                        encontro = true;
                    }
                    else
                    {
                        encontro = false;
                    }
                }

                if(encontro == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.PuestoLogradoCreate(modelop);
                    txtCrearPuestoObtenidoPuesto.Value = null;
                    txtCrearPuntosPuesto.Value = null;
                    txtCrearObservacionPuesto.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelCrearBrecha_Click(object sender, EventArgs e)
        {
            mostrarCrearBrecha.Visible = false;
        }

        protected void crearBrecha_Click(object sender, EventArgs e)
        {
            try
            {
                modelob.fkbrecha = int.Parse(dropCrearAnalisisBrechaBrecha.SelectedValue);
                modelob.punteo = double.Parse(txtCrearPuntosBrecha.Value);
                modelob.puntos = double.Parse(txtCrearPuntosObtenidosBrecha.Value);
                modelob.comparacion = double.Parse(txtCrearComparacionBrecha.Value);
                modelob.observacion = txtCrearObservacionBrecha.Value;
                modelob.fadn = Session["Federacion"].ToString();
                modelob.anio = year;
                modelob.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.BrechaRead(Session["Federacion"].ToString(), year, 0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (dropCrearAnioPuesto.SelectedValue == data.Rows[i][0].ToString())
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
                    pat.BrechaCreate(modelob);
                    txtCrearPuntosBrecha.Value = null;
                    txtCrearPuntosObtenidosBrecha.Value = null;
                    txtCrearObservacionPuesto.Value = null;
                    txtCrearComparacionBrecha.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelEditPuesto_Click(object sender, EventArgs e)
        {
            mostrarEditPuesto.Visible = false;
        }

        protected void editPuesto_Click(object sender, EventArgs e)
        {
            try
            {
                modelop.fkanio = int.Parse(dropEditAnioPuesto.SelectedValue);
                modelop.puesto = int.Parse(txtEditPuestoObtenidoPuesto.Value);
                modelop.punteo = double.Parse(txtEditPuntosPuesto.Value);
                modelop.observacion = txtEditObservacionPuesto.Value;
                modelop.fadn = Session["Federacion"].ToString();
                modelop.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.PuestoLogradoRead(Session["Federacion"].ToString(), 0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (dropEditAnioPuesto.SelectedValue == data.Rows[i][1].ToString())
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
                    pat.PuestoLogroUpdate(modelop, int.Parse(idEditPuesto.Text), 0);
                    txtEditPuestoObtenidoPuesto.Value = null;
                    txtEditPuntosPuesto.Value = null;
                    txtEditObservacionPuesto.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelEditBrecha_Click(object sender, EventArgs e)
        {
            mostrarEditBrecha.Visible = false;
        }

        protected void editBrecha_Click(object sender, EventArgs e)
        {
            try
            {
                modelob.fkbrecha = int.Parse(dropEditAnalisisBrechaBrecha.SelectedValue);
                modelob.punteo = double.Parse(txtEditPuntosBrecha.Value);
                modelob.puntos = double.Parse(txtEditPuntosObtenidosBrecha.Value);
                modelob.comparacion = double.Parse(txtEditComparacionBrecha.Value);
                modelob.observacion = txtEditObservacionBrecha.Value;
                modelob.fadn = Session["Federacion"].ToString();
                modelob.anio = year;
                modelob.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.BrechaRead(Session["Federacion"].ToString(), year, 0);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (dropCrearAnioPuesto.SelectedValue == data.Rows[i][0].ToString())
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
                    pat.BrechaUpdate(modelob, int.Parse(idEditBrecha.Text), 0);
                    txtEditPuntosBrecha.Value = null;
                    txtEditPuntosObtenidosBrecha.Value = null;
                    txtEditObservacionBrecha.Value = null;
                    txtEditComparacionBrecha.Value = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modifcada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modifcada', 'error');", true);
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
                if(idIntroObservacionRechazoPuesto.Text != "")
                {
                    obseracion.id2 = int.Parse(idIntroObservacionRechazoPuesto.Text);
                }
                if (idIntroObservacionRechazoPuesto.Text != "")
                {
                    obseracion.id1 = int.Parse(idIntroObservacionRechazoBrecha.Text);
                }
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                if (idIntroObservacionRechazoPuesto.Text != "")
                {
                    pat.PuestoLogroUpdate(modelop, int.Parse(idIntroObservacionRechazoPuesto.Text), 13);
                }
                if (idIntroObservacionRechazoPuesto.Text != "")
                {
                    pat.BrechaUpdate(modelob, int.Parse(idIntroObservacionRechazoBrecha.Text), 13);
                }
                crearObservacionRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
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
                if (idIntroObservacionRechazoPuesto.Text != "")
                {
                    obseracion.id2 = int.Parse(idIntroObservacionRechazoPuesto.Text);
                }
                if (idIntroObservacionRechazoBrecha.Text != "")
                {
                    obseracion.id1 = int.Parse(idIntroObservacionRechazoBrecha.Text);
                }
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    if (idIntroObservacionRechazoPuesto.Text != "")
                    {
                        pat.PuestoLogroUpdate(modelop, int.Parse(idIntroObservacionRechazoPuesto.Text), 2);
                    }
                    if (idIntroObservacionRechazoBrecha.Text != "")
                    {
                        pat.BrechaUpdate(modelob, int.Parse(idIntroObservacionRechazoBrecha.Text), 2);
                    }
                    crearObservacionRechazo.Visible = false;
                    CargarGrid();
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
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
                if (idIntroObservacionSinRechazoPuesto.Text != "")
                {
                    obseracion.id2 = int.Parse(idIntroObservacionSinRechazoPuesto.Text);
                }
                if (idIntroObservacionSinRechazoBrecha.Text != "")
                {
                    obseracion.id1 = int.Parse(idIntroObservacionSinRechazoBrecha.Text);
                }
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                if (idIntroObservacionSinRechazoPuesto.Text != "")
                {
                    pat.PuestoLogroUpdate(modelop, int.Parse(idIntroObservacionSinRechazoPuesto.Text), 9);
                }
                if (idIntroObservacionSinRechazoBrecha.Text != "")
                {
                    pat.BrechaUpdate(modelob, int.Parse(idIntroObservacionSinRechazoBrecha.Text), 9);
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

        protected void btObservacionSinRechazoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (idIntroObservacionSinRechazoPuesto.Text != "")
                {
                    obs.observacionUpdateAcompaniamiento(int.Parse(idIntroObservacionSinRechazoPuesto.Text), txtCrearObservacionSinRechazo.Value);
                }
                if (idIntroObservacionSinRechazoBrecha.Text != "")
                {
                    obs.observacionUpdateAcompaniamiento(int.Parse(idIntroObservacionSinRechazoBrecha.Text), txtCrearObservacionSinRechazo.Value);
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

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }

        protected void gridPuestoLogrado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "LOGROS Y BRECHAS");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridPuestoLogrado.Columns[0].Visible = true;

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
                            if (pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 3) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 3) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 3) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.PuestoLogroSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
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

        protected void gridPuestoLogrado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridPuestoLogrado.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridPuestoLogrado.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Anio(dropEditAnioPuesto);
                        data = pat.PuestoLogroSeleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditPuesto.Text = data.Rows[i][0].ToString();
                            dropEditAnioPuesto.SelectedValue = data.Rows[i][1].ToString();
                            txtEditPuestoObtenidoPuesto.Value = data.Rows[i][2].ToString();
                            txtEditPuntosBrecha.Value = data.Rows[i][3].ToString();
                            txtEditObservacionPuesto.Value = data.Rows[i][4].ToString();
                        }

                        idEditPuesto.Visible = false;
                        mostrarEditPuesto.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 3);

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoPuesto.Text = data.Rows[i][0].ToString();
                            txtCrearObservacionSinRechazo.Value = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoPuesto.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazoUpdate.Visible = true;
                        break;
                }
            }
            if (e.CommandName == "Mostrar")
            {
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 3);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 3);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 3);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.PuestoLogroSeleccionar(int.Parse(row.Cells[0].Text));

                switch (Session["Rol"].ToString())
                {
                    case "Usuario CE de FADN":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoPuesto.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoPuesto.Visible = false;
                        crearObservacionRechazo.Visible = true;
                        btcrearObservacionRechazo.Visible = true;
                        break;

                    case "Técnico Acompañamiento":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoPuesto.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoPuesto.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazo.Visible = true;
                        break;

                    case "Técnico Evaluación":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoPuesto.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoPuesto.Visible = false;
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
                        obseracion.id2 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.PuestoLogroUpdate(modelop, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id2 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.PuestoLogroUpdate(modelop, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.PuestoLogroUpdate(modelop, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id2 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.PuestoLogroUpdate(modelop, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            gridPuestoLogrado.Columns[0].Visible = false;
        }

        protected void gridAnalisisBrecha_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "LOGROS Y BRECHAS");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridAnalisisBrecha.Columns[0].Visible = true;

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
                            if (pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 2) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 2) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 2) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.BrechaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
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

        protected void gridAnalisisBrecha_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridAnalisisBrecha.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridAnalisisBrecha.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Brecha(dropEditAnalisisBrechaBrecha);
                        data = pat.BrechaSeleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditBrecha.Text = data.Rows[i][0].ToString();
                            dropEditAnalisisBrechaBrecha.SelectedValue = data.Rows[i][1].ToString();
                            txtEditPuntosBrecha.Value = data.Rows[i][2].ToString();
                            txtEditPuntosObtenidosBrecha.Value = data.Rows[i][3].ToString();
                            txtEditComparacionBrecha.Value = data.Rows[i][4].ToString();
                            txtEditObservacionBrecha.Value = data.Rows[i][5].ToString();
                        }

                        idEditBrecha.Visible = false;
                        mostrarEditBrecha.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 2);

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoBrecha.Text = data.Rows[i][0].ToString();
                            txtCrearObservacionSinRechazo.Value = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoBrecha.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazoUpdate.Visible = true;
                        break;
                }
            }
            if (e.CommandName == "Mostrar")
            {
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 2);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 2);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 2);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.BrechaSeleccionar(int.Parse(row.Cells[0].Text));

                switch (Session["Rol"].ToString())
                {
                    case "Usuario CE de FADN":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoBrecha.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoBrecha.Visible = false;
                        crearObservacionRechazo.Visible = true;
                        btcrearObservacionRechazo.Visible = true;
                        break;

                    case "Técnico Acompañamiento":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazoBrecha.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionSinRechazoBrecha.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazo.Visible = true;
                        break;

                    case "Técnico Evaluación":

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionRechazoBrecha.Text = data.Rows[i][0].ToString();
                        }

                        idIntroObservacionRechazoBrecha.Visible = false;
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
                        obseracion.id1 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.BrechaUpdate(modelob, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id1 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.BrechaUpdate(modelob, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.BrechaUpdate(modelob, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id1 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.BrechaUpdate(modelob, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            gridAnalisisBrecha.Columns[0].Visible = false;
        }
    }
}