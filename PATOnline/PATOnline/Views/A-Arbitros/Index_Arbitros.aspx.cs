using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.A_Arbitros
{
    public partial class Index_Arbitros : System.Web.UI.Page
    {
        Arbitro pat = new Arbitro();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloArbitro modelo = new ModeloArbitro();
        ModeloObservacion obseracion = new ModeloObservacion();
        DropDown drop = new DropDown();
        Usuario id = new Usuario();

        public string year = Convert.ToString(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
            CargarGrid();
        }

        protected void CargarGrid()
        {
            gridFADN.Columns[0].Visible = true;

            btPDF.Visible = false;
            btExcel.Visible = false;
            crearArbitroNew.Visible = false;
            mostrarCrearArbitro.Visible = false;
            crearArbitro.Visible = false;
            mostrarEditArbitro.Visible = false;
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
                    gridFADN.DataSource = pat.ArbitroRead(Session["Federacion"].ToString(), year, 0);
                    gridFADN.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ARBITROS");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearArbitro.Visible = true;
                                break;

                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;

                            case "Crear":
                                crearArbitroNew.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridFADN.DataSource = pat.ArbitroRead(Session["Federacion"].ToString(), year, 3);
                    gridFADN.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ARBITROS");

                    for (int j = 0; j < mostrar4.Rows.Count; j++)
                    {
                        switch (mostrar4.Rows[j][0].ToString())
                        {
                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;

                            case "Rechazar":
                                btcrearObservacionRechazo.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Técnico Acompañamiento":
                    if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                    gridFADN.DataSource = pat.ArbitroRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ARBITROS");

                    for (int j = 0; j < mostrar2.Rows.Count; j++)
                    {
                        switch (mostrar2.Rows[j][0].ToString())
                        {
                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Técnico Evaluación":
                    if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                    gridFADN.DataSource = pat.ArbitroRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ARBITROS");

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
                        }
                    }
                    break;
            }
            gridFADN.Columns[0].Visible = false;
        }

        protected void nuevoArbitro_Click(object sender, EventArgs e)
        {
            drop.Drop_Nivel(dropCrearNivel, 15);
            mostrarCrearArbitro.Visible = true;
        }

        protected void cancelCrearArbitro_Click(object sender, EventArgs e)
        {
            mostrarCrearArbitro.Visible = false;
        }

        protected void crearArbitro_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.nombre1 = txtCrearPrimerNombre.Value;
                modelo.nombre2 = txtCrearSegundoNombre.Value;
                modelo.apellido1 = txtCrearPrimerApellido.Value;
                modelo.apellido2 = txtCrearSegundoApellido.Value;
                modelo.nacionalidad = txtCrearNacionalidad.Value;
                modelo.departamento = txtCrearDepartamentoLaboral.Value;
                modelo.fknivel = int.Parse(dropCrearNivel.SelectedValue);
                modelo.observacion = txtCrearObservacion.Value;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;
                modelo.fkestado = 1;

                pat.ArbitroCreate(modelo);
                txtCrearPrimerNombre.Value = null;
                txtCrearSegundoNombre.Value = null;
                txtCrearPrimerApellido.Value = null;
                txtCrearSegundoApellido.Value = null;
                txtCrearNacionalidad.Value = null;
                txtCrearDepartamentoLaboral.Value = null;
                txtCrearObservacion.Value = null;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelEditArbitro_Click(object sender, EventArgs e)
        {
            mostrarEditArbitro.Visible = false;
        }

        protected void editArbitro_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.nombre1 = txtEditPrimerNombre.Value;
                modelo.nombre2 = txtEditSegundoNombre.Value;
                modelo.apellido1 = txtEditPrimerApellido.Value;
                modelo.apellido2 = txtEditSegundoApellido.Value;
                modelo.nacionalidad = txtEditNacionalidad.Value;
                modelo.departamento = txtEditDepartamentoLaboral.Value;
                modelo.fknivel = int.Parse(dropEditNivel.SelectedValue);
                modelo.observacion = txtEditObservacion.Value;

                pat.ArbitroUpdate(modelo, int.Parse(dropEditNivel.SelectedValue), 0);
                txtEditPrimerNombre.Value = null;
                txtEditSegundoNombre.Value = null;
                txtEditPrimerApellido.Value = null;
                txtEditSegundoApellido.Value = null;
                txtEditNacionalidad.Value = null;
                txtEditDepartamentoLaboral.Value = null;
                txtEditObservacion.Value = null;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
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
                obseracion.id28 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.ArbitroUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
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
                obseracion.id28 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                pat.ArbitroUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
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

        protected void cancelObservacionSinRechazo_Click(object sender, EventArgs e)
        {
            crearObservacionSinRechazo.Visible = false;
        }

        protected void btObservacionSinRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                obseracion.id28 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.ArbitroUpdate(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
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
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ARBITROS");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridFADN.Columns[0].Visible = true;

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
                        case "Editar":
                            if (pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 29) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 29) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 29) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.ArbitroEstado(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                            }

                            break;
                    }
                }
            }
        }

        protected void gridFADN_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridFADN.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridFADN.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Nivel(dropEditNivel, 15);
                        data = pat.ArbitroSeleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEdit.Text = data.Rows[i][0].ToString();
                            txtEditPrimerNombre.Value = data.Rows[i][1].ToString();
                            txtEditSegundoNombre.Value = data.Rows[i][2].ToString();
                            txtEditPrimerApellido.Value = data.Rows[i][3].ToString();
                            txtEditSegundoApellido.Value = data.Rows[i][4].ToString();
                            txtEditNacionalidad.Value = data.Rows[i][5].ToString();
                            txtEditDepartamentoLaboral.Value = data.Rows[i][6].ToString();
                            dropEditNivel.SelectedValue = data.Rows[i][7].ToString();
                            txtEditObservacion.Value = data.Rows[i][8].ToString();
                        }

                        idEdit.Visible = false;
                        mostrarEditArbitro.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 29);

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazo.Text = data.Rows[i][0].ToString();
                            txtCrearObservacionSinRechazo.Value = data.Rows[i][1].ToString();
                        }

                        idIntroObservacionSinRechazo.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazoUpdate.Visible = true;
                        break;
                }
            }
            if (e.CommandName == "Mostrar")
            {
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 29);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 29);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 29);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario CE de FADN":

                        idIntroObservacionRechazo.Text = row.Cells[0].Text;

                        idIntroObservacionRechazo.Visible = false;
                        crearObservacionRechazo.Visible = true;
                        btcrearObservacionRechazo.Visible = true;
                        break;

                    case "Técnico Acompañamiento":

                        idIntroObservacionSinRechazo.Text = row.Cells[0].Text;

                        idIntroObservacionSinRechazo.Visible = false;
                        crearObservacionSinRechazo.Visible = true;
                        btObservacionSinRechazo.Visible = true;
                        break;

                    case "Técnico Evaluación":

                        idIntroObservacionRechazo.Text = row.Cells[0].Text;

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
                        obseracion.id28 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.ArbitroUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id28 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.ArbitroUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.ArbitroUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id28 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.ArbitroUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }

            if (e.CommandName == "Eliminar")
            {
                pat.ArbitroUpdate(modelo, int.Parse(row.Cells[0].Text), 12);
                CargarGrid();
            }
            gridFADN.Columns[0].Visible = false;
        }

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }
    }
}