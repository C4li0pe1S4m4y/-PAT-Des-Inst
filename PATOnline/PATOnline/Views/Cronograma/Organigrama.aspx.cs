using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.Cronograma
{
    public partial class Cronograma : System.Web.UI.Page
    {
        Organigrama pat = new Organigrama();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloOrganigrama modelo = new ModeloOrganigrama();
        ModeloObservacion obseracion = new ModeloObservacion();
        Usuario id = new Usuario();

        public string year = Convert.ToString(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            CargarGrid();
        }

        public string convertirImagenBase64(FileUpload imagen)
        {
            try
            {
                System.IO.Stream fs = imagen.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string convertir = Convert.ToBase64String(bytes, 0, bytes.Length);

                return "data:image/png;base64," + convertir;
            }
            catch
            {
                return "";
            }
        }

        protected void CargarGrid()
        {
            gridFADN.Columns[0].Visible = true;

            crearOrganigramaNew.Visible = false;
            mostrarCrearOrganigrama.Visible = false;
            mostrarEditarOrganigrama.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            mostrarObservacion.Visible = false;

            crearOrganigrama.Visible = false;
            editOrganigrama.Visible = false;
            btPDF.Visible = false;
            btExcel.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridFADN.DataSource = pat.OrgranigramaRead(Session["Federacion"].ToString(), year, 1);
                    gridFADN.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ORGANIGRAMA");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearOrganigrama.Visible = true;
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
                                DataTable data = new DataTable();
                                data = pat.OrgranigramaRead(Session["Federacion"].ToString(), year, 12);

                                if (data.Rows.Count > 0)
                                {
                                    crearOrganigramaNew.Visible = true;
                                    nuevoOrganigrama.Visible = true;
                                }
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridFADN.DataSource = pat.OrgranigramaRead(Session["Federacion"].ToString(), year, 3);
                    gridFADN.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ORGANIGRAMA");

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

                    gridFADN.DataSource = pat.OrgranigramaRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ORGANIGRAMA");

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

                    gridFADN.DataSource = pat.OrgranigramaRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ORGANIGRAMA");

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

        protected void nuevoOrganigrama_Click(object sender, EventArgs e)
        {
            mostrarCrearOrganigrama.Visible = true;
        }

        protected void cancelCrearOrganigrama_Click(object sender, EventArgs e)
        {
            mostrarCrearOrganigrama.Visible = false;
        }

        protected void crearOrganigrama_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.imagen = convertirImagenBase64(FileUpload1);
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;

                DataTable data = new DataTable();
                data = pat.OrgranigramaRead(Session["Federacion"].ToString(), year, 12);

                if (data.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.OrganigramaCreate(modelo);
                    CargarGrid();
                    mostrarCrearOrganigrama.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelEditOrganigrama_Click(object sender, EventArgs e)
        {
            mostrarEditarOrganigrama.Visible = false;
        }

        protected void editOrganigrama_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.imagen = convertirImagenBase64(FileUpload2);
                pat.OrganigramaUpdate(modelo, int.Parse(idOrganigrama.Text), 0);
                CargarGrid();
                mostrarCrearOrganigrama.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
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
                        data = pat.OrgranigramaSeleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idOrganigrama.Text = data.Rows[i][0].ToString();
                        }

                        idOrganigrama.Visible = false;
                        mostrarEditarOrganigrama.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 20);

                        for(int i = 0; i < data.Rows.Count; i++)
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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 20);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 20);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 20);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.OrgranigramaSeleccionar(int.Parse(row.Cells[0].Text));

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
                        pat.OrganigramaUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id19 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.OrganigramaUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.OrganigramaUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id19 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.OrganigramaUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            gridFADN.Columns[0].Visible = false;
        }

        protected void gridFADN_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "ORGANIGRAMA");

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
                        case "Guardar":
                            break;

                        case "Editar":
                            if (pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 20) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 20) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 20) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.OrganigramaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
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
                gridFADN.Columns[0].Visible = false;
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
                obseracion.id19 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.OrganigramaUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
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
                obseracion.id19 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN")
                {
                    obs.observacionCreateFADN(obseracion);
                    pat.OrganigramaUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 20);
                    crearObservacionRechazo.Visible = false;
                    CargarGrid();
                }
                if (Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateEvaluador(obseracion);
                    pat.OrganigramaUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 20);
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
                obseracion.id19 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.OrganigramaUpdate(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
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

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }
    }
}