using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;


namespace PATOnline.Views.FODA
{
    public partial class FODA : System.Web.UI.Page
    {
        FODABE pat = new FODABE();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloFodaBEstrategica modelo = new ModeloFodaBEstrategica();
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
            gridFODABE.Columns[0].Visible = true;

            btPDF.Visible = false;
            btExcel.Visible = false;
            crearFODABENew.Visible = false;
            mostrarCrearFODABE.Visible = false;
            crearFODABE.Visible = false;
            mostrarEditFODABE.Visible = false;
            crearObservacionRechazo.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;
            mostrarObservacion.Visible = false;

            vistaPreviaFODABE.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridFODABE.DataSource = pat.FODABERead(Session["Federacion"].ToString(), year, 0);
                    gridFODABE.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "FODA");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearFODABE.Visible = true;
                                crearFODABE.Visible = true;
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
                                crearFODABENew.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridFODABE.DataSource = pat.FODABERead(Session["Federacion"].ToString(), year, 3);
                    gridFODABE.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "FODA");

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
                    gridFODABE.DataSource = pat.FODABERead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFODABE.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "FODA");

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
                    gridFODABE.DataSource = pat.FODABERead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFODABE.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "FODA");

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
            gridFODABE.Columns[0].Visible = false;
        }

        protected void nuevoFODABE_Click(object sender, EventArgs e)
        {
            mostrarCrearFODABE.Visible = true;
        }

        protected void cancelCrearFODABE_Click(object sender, EventArgs e)
        {
            mostrarCrearFODABE.Visible = true;
        }

        protected void crearFODABE_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fortaleza = txtCrearFortalezaFODABE.Text;
                modelo.oportunidad = txtCrearOportunidadFODABE.Text;
                modelo.debilidad = txtCrearDebilidadFODABE.Text;
                modelo.amenaza = txtCrearAmenazaFODABE.Text;
                modelo.vision = txtCrearVisionFODABE.Text;
                modelo.mision = txtCrearMisionFODABE.Text;
                modelo.valor = txtCrearValorFODABE.Text;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.ano = year;
                modelo.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.FODABERead(Session["Federacion"].ToString(), year, 0);
                if (data.Rows.Count > 0)
                {
                    encontro = true;
                }

                if (encontro == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.FODABECreate(modelo);
                    txtCrearFortalezaFODABE.Text = null;
                    txtCrearOportunidadFODABE.Text = null;
                    txtCrearDebilidadFODABE.Text = null;
                    txtCrearAmenazaFODABE.Text = null;
                    txtCrearVisionFODABE.Text = null;
                    txtCrearMisionFODABE.Text = null;
                    txtCrearValorFODABE.Text = null;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelEditFODABE_Click(object sender, EventArgs e)
        {
            mostrarEditFODABE.Visible = false;
        }

        protected void editFODABE_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fortaleza = txtEditFortalezaFODABE.Text;
                modelo.oportunidad = txtEditOportunidadFODABE.Text;
                modelo.debilidad = txtEditDebilidadFODABE.Text;
                modelo.amenaza = txtEditAmenazaFODABE.Text;
                modelo.vision = txtEditVisionFODABE.Text;
                modelo.mision = txtEditMisionFODABE.Text;
                modelo.valor = txtEditValorFODABE.Text;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.ano = year;
                modelo.fkestado = 1;
                DataTable data = new DataTable();
                data = pat.FODABERead(Session["Federacion"].ToString(), year, 0);
                if (data.Rows.Count > 0)
                {
                    encontro = true;
                }

                if (encontro == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.FODABEUpdate(modelo, int.Parse(idEditFODABE.Text), 0);
                    txtEditFortalezaFODABE.Text = null;
                    txtEditOportunidadFODABE.Text = null;
                    txtEditDebilidadFODABE.Text = null;
                    txtEditAmenazaFODABE.Text = null;
                    txtEditVisionFODABE.Text = null;
                    txtEditMisionFODABE.Text = null;
                    txtEditValorFODABE.Text = null;
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
                obseracion.id17 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Text;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.FODABEUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
                crearObservacionRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                txtCrearObservacion.Text = null;
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
                obseracion.id17 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Text;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    pat.FODABEUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
                    crearObservacionRechazo.Visible = false;
                    CargarGrid();
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                txtCrearObservacion.Text = null;
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
                obseracion.id17 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Text;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.FODABEUpdate(modelo, int.Parse(txtCrearObservacionSinRechazo.Text), 9);
                crearObservacionSinRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                txtCrearObservacionSinRechazo.Text = null;
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
                obs.observacionUpdateAcompaniamiento(int.Parse(idIntroObservacionSinRechazo.Text), txtCrearObservacionSinRechazo.Text);
                crearObservacionSinRechazo.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }

        protected void gridFODABE_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "FODA");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridFODABE.Columns[0].Visible = true;

                (e.Row.FindControl("btEditar") as LinkButton).Visible = false;
                (e.Row.FindControl("btVer") as LinkButton).Visible = false;
                (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                (e.Row.FindControl("btObservacion") as LinkButton).Visible = false;
                (e.Row.FindControl("btAprobar") as LinkButton).Visible = false;
                (e.Row.FindControl("btEnviar") as LinkButton).Visible = false;
                (e.Row.FindControl("btPreview") as LinkButton).Visible = false;

                for (int j = 0; j < mostra.Rows.Count; j++)
                {
                    switch (mostra.Rows[j][0].ToString())
                    {
                        case "Guardar":
                            break;

                        case "Editar":
                            if (pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 19) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 19) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 19) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.FODABESearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                                (e.Row.FindControl("btPreview") as LinkButton).Visible = true;
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

        protected void gridFODABE_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            gridFODABE.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridFODABE.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Previa")
            {
                data = pat.FODABESeleccionar(int.Parse(row.Cells[0].Text));

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    txtPreviewFortaleza.Text = data.Rows[i][1].ToString();
                    txtPreviewOportunida.Text = data.Rows[i][2].ToString();
                    txtPreviewDebilidad.Text = data.Rows[i][3].ToString();
                    txtPreviewAmenaza.Text = data.Rows[i][4].ToString();
                    txtPreviewMision.Text = data.Rows[i][5].ToString();
                    txtPreviewVision.Text = data.Rows[i][6].ToString();
                    txtPreviewValor.Text = data.Rows[i][7].ToString();
                }
                vistaPreviaFODABE.Visible = true;
            }
            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        data = pat.FODABESeleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditFODABE.Text = data.Rows[i][0].ToString();
                            txtEditFortalezaFODABE.Text = data.Rows[i][1].ToString();
                            txtEditOportunidadFODABE.Text = data.Rows[i][2].ToString();
                            txtEditDebilidadFODABE.Text = data.Rows[i][3].ToString();
                            txtEditAmenazaFODABE.Text = data.Rows[i][4].ToString();
                            txtEditMisionFODABE.Text = data.Rows[i][5].ToString();
                            txtEditVisionFODABE.Text = data.Rows[i][6].ToString();
                            txtEditValorFODABE.Text = data.Rows[i][7].ToString();
                        }

                        idEditFODABE.Visible = false;
                        mostrarEditFODABE.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 27);

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idIntroObservacionSinRechazo.Text = data.Rows[i][0].ToString();
                            txtCrearObservacionSinRechazo.Text = data.Rows[i][1].ToString();
                        }

                        idIntroObservacionSinRechazo.Visible = false;
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
                data = pat.FODABESeleccionar(int.Parse(row.Cells[0].Text));

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
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.FODABEUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.FODABEUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.FODABEUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.FODABEUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }

            if (e.CommandName == "Eliminar")
            {
                pat.FODABEUpdate(modelo, int.Parse(row.Cells[0].Text), 12);
                CargarGrid();
            }
            gridFODABE.Columns[0].Visible = false;
        }

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }

        protected void cancelVistaPrevia_Click(object sender, EventArgs e)
        {
            vistaPreviaFODABE.Visible = false;
        }
    }
}