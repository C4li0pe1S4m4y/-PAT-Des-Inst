using System;
using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Models;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.IntroBase
{
    public partial class IntroduccionBasesLegales : System.Web.UI.Page
    {
        IntroduccionBaseLegal clase = new IntroduccionBaseLegal();
        Observacion obs = new Observacion();
        ModeloIntroBaseLegal modelo = new ModeloIntroBaseLegal();
        Usuario id = new Usuario();
        ModeloObservacion observacion = new ModeloObservacion();

        public string user;
        public string fede;
        public string year = Convert.ToString(DateTime.Now.Year);

        ReadRolPermiso rol = new ReadRolPermiso();
        ReadBoton boton = new ReadBoton();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                user = Convert.ToString(Session["Usuario"]);
                fede = Convert.ToString(Session["Federacion"]);

                mostrarInformacionUsuario(user, fede, year);
            }
        }

        public void mostrarInformacionUsuario(string usuario, string federacion, string anio)
        {
            //Informacion
            secctionCrear.Visible = false;
            mostrarIntroBaseLegal.Visible = false;
            mostrarEditIntroBaseLegal.Visible = false;
            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            gridFADN.Visible = false;
            gridCEFADN.Visible = false;
            gridAcompaniamiento.Visible = false;
            gridEvaluacion.Visible = false;
            mostrarObservacion.Visible = false;

            idIntroObservacionSinRechazo.Visible = false;
            idIntroObservacionRechazo.Visible = false;

            //Boton
            nuevaIntroBaseLegal.Visible = false;
            crearIntroBaseLegal.Visible = false;
            btPDF.Visible = false;
            btExcel.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;
            btObservacionSinRechazo.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":

                    gridFADN.Columns[0].Visible = true;
                    gridFADN.DataSource = clase.IBLRead(federacion, anio, 1);
                    gridFADN.DataBind();
                    
                    foreach (GridViewRow row in gridFADN.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            (row.FindControl("btEditar") as LinkButton).Visible = false;
                            (row.FindControl("btVer") as LinkButton).Visible = false;
                            (row.FindControl("btEliminar") as LinkButton).Visible = false;
                            (row.FindControl("btObservacion") as LinkButton).Visible = false;
                            (row.FindControl("btAprobar") as LinkButton).Visible = false;
                            (row.FindControl("btEnviar") as LinkButton).Visible = false;
                        }
                    }

                    DataTable mostrar = new DataTable();
                    mostrar = boton.BotonReadUsuario(usuario, "INTRODUCCION");

                    for (int j = 0; j < mostrar.Rows.Count; j++)
                    {
                        switch (mostrar.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearIntroBaseLegal.Visible = true;
                                break;

                            case "Editar":
                                foreach (GridViewRow row in gridFADN.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2)
                                        {
                                            (row.FindControl("btEditar") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Ver":
                                foreach (GridViewRow row in gridFADN.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (obs.ObservacionCEFADNExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionAcompaniamientoExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionEvaluadorExiste(int.Parse(row.Cells[0].Text), 1) == true)
                                        {
                                            (row.FindControl("btVer") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Eliminar":
                                foreach (GridViewRow row in gridFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2)
                                    {
                                        (row.FindControl("btEliminar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Enviar":
                                foreach (GridViewRow row in gridFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 6
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btEnviar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Aprobar":
                                foreach (GridViewRow row in gridFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btAprobar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Observación":
                                foreach (GridViewRow row in gridFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btObservacion") as LinkButton).Visible = true;
                                    }
                                }
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
                                secctionCrear.Visible = true;
                                nuevaIntroBaseLegal.Visible = true;
                                break;
                        }
                    }

                    gridFADN.Columns[0].Visible = false;
                    gridFADN.Visible = true;
                    break;

                case "Usuario CE de FADN":

                    gridCEFADN.Columns[0].Visible = true;
                    gridCEFADN.DataSource = clase.IBLRead(federacion, anio, 3);
                    gridCEFADN.DataBind();

                    foreach (GridViewRow row in gridCEFADN.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            (row.FindControl("btEditar") as LinkButton).Visible = false;
                            (row.FindControl("btVer") as LinkButton).Visible = false;
                            (row.FindControl("btEliminar") as LinkButton).Visible = false;
                            (row.FindControl("btObservacion") as LinkButton).Visible = false;
                            (row.FindControl("btAprobar") as LinkButton).Visible = false;
                            (row.FindControl("btEnviar") as LinkButton).Visible = false;
                        }
                    }

                    DataTable mostrar1 = new DataTable();
                    mostrar1 = boton.BotonReadUsuario(usuario, "INTRODUCCION");

                    for (int j = 0; j < mostrar1.Rows.Count; j++)
                    {
                        switch (mostrar1.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearIntroBaseLegal.Visible = true;
                                break;

                            case "Editar":
                                foreach (GridViewRow row in gridCEFADN.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2)
                                        {
                                            (row.FindControl("btEditar") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Ver":
                                foreach (GridViewRow row in gridCEFADN.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (obs.ObservacionCEFADNExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionAcompaniamientoExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionEvaluadorExiste(int.Parse(row.Cells[0].Text), 1) == true)
                                        {
                                            (row.FindControl("btVer") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Eliminar":
                                foreach (GridViewRow row in gridCEFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2)
                                    {
                                        (row.FindControl("btEliminar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Enviar":
                                foreach (GridViewRow row in gridCEFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 6
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btEnviar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Aprobar":
                                foreach (GridViewRow row in gridCEFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btAprobar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Observación":
                                foreach (GridViewRow row in gridCEFADN.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 6
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btObservacion") as LinkButton).Visible = true;
                                    }
                                }
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
                                secctionCrear.Visible = true;
                                nuevaIntroBaseLegal.Visible = true;
                                break;
                        }
                    }

                    gridCEFADN.Columns[0].Visible = false;
                    gridCEFADN.Visible = true;
                    break;

                case "Técnico Acompañamiento":

                    if (this.Session["FederacionAsignada"] == null)
                    {
                        Response.Redirect("~/DashboardFADN.aspx");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advetencia!', 'Debe de seleccionar una Federación para poder ver la información', 'warning');", true);
                    }
                    else
                    {
                        gridAcompaniamiento.Columns[0].Visible = true;
                        gridAcompaniamiento.DataSource = clase.IBLRead(Session["FederacionAsignada"].ToString(), anio, 6);
                        gridAcompaniamiento.DataBind();
                    }

                    foreach (GridViewRow row in gridAcompaniamiento.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            (row.FindControl("btEditar") as LinkButton).Visible = false;
                            (row.FindControl("btVer") as LinkButton).Visible = false;
                            (row.FindControl("btEliminar") as LinkButton).Visible = false;
                            (row.FindControl("btObservacion") as LinkButton).Visible = false;
                            (row.FindControl("btAprobar") as LinkButton).Visible = false;
                            (row.FindControl("btEnviar") as LinkButton).Visible = false;
                        }
                    }

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(usuario, "INTRODUCCION");

                    for (int j = 0; j < mostrar2.Rows.Count; j++)
                    {
                        switch (mostrar2.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearIntroBaseLegal.Visible = true;
                                break;

                            case "Editar":
                                foreach (GridViewRow row in gridAcompaniamiento.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2)
                                        {
                                            (row.FindControl("btEditar") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Ver":
                                foreach (GridViewRow row in gridAcompaniamiento.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (obs.ObservacionCEFADNExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionAcompaniamientoExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionEvaluadorExiste(int.Parse(row.Cells[0].Text), 1) == true)
                                        {
                                            (row.FindControl("btVer") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Eliminar":
                                foreach (GridViewRow row in gridAcompaniamiento.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2)
                                    {
                                        (row.FindControl("btEliminar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Enviar":
                                foreach (GridViewRow row in gridAcompaniamiento.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 6
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btEnviar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Aprobar":
                                foreach (GridViewRow row in gridAcompaniamiento.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btAprobar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Observación":
                                foreach (GridViewRow row in gridAcompaniamiento.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 6
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btObservacion") as LinkButton).Visible = true;
                                    }
                                }
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
                                secctionCrear.Visible = true;
                                nuevaIntroBaseLegal.Visible = true;
                                break;
                        }
                    }

                    gridAcompaniamiento.Columns[0].Visible = false;
                    gridAcompaniamiento.Visible = true;
                    break;

                case "Técnico Evaluación":

                    if (this.Session["FederacionAsignada"] == null)
                    {
                        Response.Redirect("~/DashboardFADN.aspx");
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advetencia!', 'Debe de seleccionar una Federación para poder ver la información', 'warning');", true);
                    }
                    else
                    {
                        gridEvaluacion.Columns[0].Visible = true;
                        gridEvaluacion.DataSource = clase.IBLRead(Session["FederacionAsignada"].ToString(), anio, 9);
                        gridEvaluacion.DataBind();
                    }

                    foreach (GridViewRow row in gridEvaluacion.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            (row.FindControl("btEditar") as LinkButton).Visible = false;
                            (row.FindControl("btVer") as LinkButton).Visible = false;
                            (row.FindControl("btEliminar") as LinkButton).Visible = false;
                            (row.FindControl("btObservacion") as LinkButton).Visible = false;
                            (row.FindControl("btAprobar") as LinkButton).Visible = false;
                            (row.FindControl("btEnviar") as LinkButton).Visible = false;
                        }
                    }

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(usuario, "INTRODUCCION");

                    for (int j = 0; j < mostrar3.Rows.Count; j++)
                    {
                        switch (mostrar3.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearIntroBaseLegal.Visible = true;
                                guardarObservacionRechazo.Visible = true;
                                break;

                            case "Editar":
                                foreach (GridViewRow row in gridEvaluacion.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (obs.ObservacionAcompaniamientoExiste(int.Parse(row.Cells[0].Text), 1) == true)
                                        {
                                            (row.FindControl("btEditar") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Ver":
                                foreach (GridViewRow row in gridEvaluacion.Rows)
                                {
                                    if (row.RowType == DataControlRowType.DataRow)
                                    {
                                        if (obs.ObservacionCEFADNExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionAcompaniamientoExiste(int.Parse(row.Cells[0].Text), 1) == true
                                            || obs.ObservacionEvaluadorExiste(int.Parse(row.Cells[0].Text), 1) == true)
                                        {
                                            (row.FindControl("btVer") as LinkButton).Visible = true;
                                        }
                                    }
                                }
                                break;

                            case "Eliminar":
                                foreach (GridViewRow row in gridEvaluacion.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2)
                                    {
                                        (row.FindControl("btEliminar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Enviar":
                                foreach (GridViewRow row in gridEvaluacion.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 1
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 2
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 6
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btEnviar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Aprobar":
                                foreach (GridViewRow row in gridEvaluacion.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3 || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btAprobar") as LinkButton).Visible = true;
                                    }
                                }
                                break;

                            case "Observación":
                                foreach (GridViewRow row in gridEvaluacion.Rows)
                                {
                                    if (clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 3
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 6
                                        || clase.IntroBaseLegalSearch(int.Parse(row.Cells[0].Text)) == 9)
                                    {
                                        (row.FindControl("btObservacion") as LinkButton).Visible = true;
                                    }
                                }
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
                                secctionCrear.Visible = true;
                                nuevaIntroBaseLegal.Visible = true;
                                break;
                        }
                    }

                    gridEvaluacion.Columns[0].Visible = false;
                    gridEvaluacion.Visible = true;
                    break;
            }
        }

        protected void nuevaIntroBaseLegal_Click(object sender, EventArgs e)
        {
            mostrarIntroBaseLegal.Visible = true;
        }

        protected void cancelCrearIntroBaseLegal_Click_Click(object sender, EventArgs e)
        {
            mostrarIntroBaseLegal.Visible = false;
        }

        protected void crearIntroBaseLegal_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.intro = TxtIntroduccion.Value;
                modelo.marco = TxtMarco.Value;
                modelo.afiliacion = TxtAfiliacion.Value;
                modelo.fadn = Convert.ToString(Session["Federacion"]);
                modelo.ano = year;

                clase.InfoCreate(modelo, Session["Usuario"].ToString());
                mostrarIntroBaseLegal.Visible = false;
                mostrarInformacionUsuario(Session["Usuario"].ToString(), Session["Federacion"].ToString(), year);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue creada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue creada', 'error');", true);
            }
        }

        protected void cancelEditIntroBaseLegal_Click(object sender, EventArgs e)
        {
            mostrarEditIntroBaseLegal.Visible = false;
        }

        protected void editIntroBaseLegal_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.intro = txtEditIntroduccion.Value;
                modelo.marco = txtEditMarco.Value;
                modelo.afiliacion = txtEditAfiliacion.Value;

                clase.UpdateIntroBaseLegal(modelo, int.Parse(idIntroBase.Text), 0, Session["Usuario"].ToString());
                mostrarEditIntroBaseLegal.Visible = false;
                mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["Federacion"]), year);
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

            if (e.CommandName == "Editar")
            {
                DataTable data = new DataTable();
                data = clase.IBLSeleccionadoRead(int.Parse(row.Cells[0].Text));

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idIntroBase.Text = data.Rows[i][0].ToString();
                    txtEditIntroduccion.Value = data.Rows[i][1].ToString();
                    txtEditMarco.Value = data.Rows[i][2].ToString();
                    txtEditAfiliacion.Value = data.Rows[i][3].ToString();
                }

                mostrarEditIntroBaseLegal.Visible = true;
            }
            if (e.CommandName == "Mostrar")
            {
                mostrarObservacion.Visible = true;

                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 1);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 1);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 1);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();
            }
            if (e.CommandName == "Eliminar")
            {
                clase.InfoBaseLegalDelete(int.Parse(row.Cells[0].Text), Session["Usuario"].ToString());
                mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["Federacion"]), year);
            }
            if (e.CommandName == "Observacion")
            {
                crearObservacionRechazo.Visible = true;
            }
            if (e.CommandName == "Aprobar")
            {

            }
            if (e.CommandName == "Enviar")
            {
                try
                {
                    clase.UpdateIntroBaseLegal(modelo, int.Parse(row.Cells[0].Text), 3, Session["Usuario"].ToString());
                    mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["Federacion"]), year);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
                }
            }
            gridFADN.Columns[0].Visible = false;
        }

        protected void gridCEFADN_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridCEFADN.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridCEFADN.Rows[index];

            if (e.CommandName == "Editar")
            {

            }
            if (e.CommandName == "Mostrar")
            {
                mostrarObservacion.Visible = true;

                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 1);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 1);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 1);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();
            }
            if (e.CommandName == "Eliminar")
            {

            }
            if (e.CommandName == "Observacion")
            {
                idIntroObservacionRechazo.Text = row.Cells[0].Text;
                crearObservacionRechazo.Visible = true;
            }
            if (e.CommandName == "Aprobar")
            {
                try
                {
                    clase.UpdateIntroBaseLegal(modelo, int.Parse(row.Cells[0].Text), 6, Session["Usuario"].ToString());
                    mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["Federacion"]), year);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
                }
            }
            if (e.CommandName == "Enviar")
            {

            }
            gridCEFADN.Columns[0].Visible = false;
        }

        protected void gridAcompaniamiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridAcompaniamiento.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridAcompaniamiento.Rows[index];

            if (e.CommandName == "Editar")
            {

            }
            if (e.CommandName == "Mostrar")
            {
                mostrarObservacion.Visible = true;

                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 1);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 1);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 1);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();
            }
            if (e.CommandName == "Eliminar")
            {

            }
            if (e.CommandName == "Observacion")
            {
                idIntroObservacionSinRechazo.Text = row.Cells[0].Text;
                crearObservacionSinRechazo.Visible = true;
                btObservacionSinRechazo.Visible = true;
            }
            if (e.CommandName == "Aprobar")
            {

            }
            if (e.CommandName == "Enviar")
            {
                try
                {
                    clase.UpdateIntroBaseLegal(modelo, int.Parse(row.Cells[0].Text), 9, Session["Usuario"].ToString());
                    mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["FederacionAsignada"]), year);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
                }
            }
            gridAcompaniamiento.Columns[0].Visible = false;
        }

        protected void gridEvaluacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridEvaluacion.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridEvaluacion.Rows[index];

            if (e.CommandName == "Editar")
            {
                DataTable data = new DataTable();
                data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 1);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idIntroObservacionSinRechazo.Text = data.Rows[i][0].ToString();
                    txtCrearObservacionSinRechazo.Value = data.Rows[i][1].ToString();
                }

                btObservacionSinRechazoUpdate.Visible = true;
                crearObservacionSinRechazo.Visible = true;
            }
            if (e.CommandName == "Mostrar")
            {
                mostrarObservacion.Visible = true;

                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 1);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 1);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 1);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();
            }
            if (e.CommandName == "Eliminar")
            {

            }
            if (e.CommandName == "Observacion")
            {
                idIntroObservacionRechazo.Text = row.Cells[0].Text;
                crearObservacionRechazo.Visible = true;
            }
            if (e.CommandName == "Aprobar")
            {
                try
                {
                    clase.UpdateIntroBaseLegal(modelo, int.Parse(row.Cells[0].Text), 13, Session["Usuario"].ToString());
                    mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["FederacionAsignada"]), year);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
                }
            }
            if (e.CommandName == "Enviar")
            {

            }
            gridEvaluacion.Columns[0].Visible = false;
        }

        protected void cancelObservacionSinRechazo_Click(object sender, EventArgs e)
        {
            crearObservacionSinRechazo.Visible = false;
        }

        protected void btObservacionSinRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                observacion.id0 = int.Parse(idIntroObservacionSinRechazo.Text);
                observacion.observacion = txtCrearObservacionSinRechazo.Value;
                observacion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(observacion);
                clase.UpdateIntroBaseLegal(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9, Session["Usuario"].ToString());
                crearObservacionSinRechazo.Visible = false;
                mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["FederacionAsignada"]), year);
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
                observacion.id0 = int.Parse(idIntroObservacionRechazo.Text);
                observacion.observacion = txtCrearObservacion.Value;
                observacion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN")
                {
                    obs.observacionCreateFADN(observacion);
                    clase.UpdateIntroBaseLegal(modelo, int.Parse(idIntroObservacionRechazo.Text), 2, Session["Usuario"].ToString());
                    crearObservacionRechazo.Visible = false;
                    mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["Federacion"]), year);
                }
                if (Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateEvaluador(observacion);
                    clase.UpdateIntroBaseLegal(modelo, int.Parse(idIntroObservacionRechazo.Text), 2, Session["Usuario"].ToString());
                    crearObservacionRechazo.Visible = false;
                    mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["FederacionAsignada"]), year);
                }

                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'error');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }

        protected void cancelarObservacionRechazo_Click(object sender, EventArgs e)
        {
            crearObservacionRechazo.Visible = false;
        }

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }

        protected void guardarObservacionRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                observacion.id0 = int.Parse(idIntroObservacionRechazo.Text);
                observacion.observacion = txtCrearObservacion.Value;
                observacion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(observacion);
                clase.UpdateIntroBaseLegal(modelo, int.Parse(idIntroObservacionRechazo.Text), 13, Session["Usuario"].ToString());
                crearObservacionRechazo.Visible = false;
                mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["FederacionAsignada"]), year);
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
                mostrarInformacionUsuario(Convert.ToString(Session["Usuario"]), Convert.ToString(Session["FederacionAsignada"]), year);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La informaicón fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La informaicón no fue ingresada', 'error');", true);
            }
        }
    }
}