using System;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PATOnline.Views.DirigentesFADN
{
    public partial class DirigenteFADN : System.Web.UI.Page
    {
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        DropDown drop = new DropDown();
        DirigenciaDeportivas dirigencia = new DirigenciaDeportivas();
        ModeloDirigencia modelo = new ModeloDirigencia();
        ModeloObservacion obseracion = new ModeloObservacion();
        Usuario id = new Usuario();

        public string year = Convert.ToString(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            CargarGrid();
        }

        protected void CargarGrid()
        {
            gridCE.Columns[0].Visible = true;
            gridAsamblea.Columns[0].Visible = true;
            gridDisciplina.Columns[0].Visible = true;
            gridComision.Columns[0].Visible = true;
            gridPersonal.Columns[0].Visible = true;
            gridDirigente.Columns[0].Visible = true;

            btPDF.Visible = false;
            btExcel.Visible = false;

            crearAsambleaNew.Visible = false;
            mostrarCrearAsamblea.Visible = false;
            mostrarCrearComision.Visible = false;
            mostrarCrearDirigente.Visible = false;
            mostrarCrearOrgano.Visible = false;
            mostrarCrearPersonal.Visible = false;

            mostrarEditAsamblea.Visible = false;
            mostrarEditComision.Visible = false;
            mostrarEditDirigente.Visible = false;
            mostrarEditOrgano.Visible = false;
            mostrarEditPersonal.Visible = false;

            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;

            mostrarObservacion.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;

            crearAsamblea.Visible = false;
            crearComision.Visible = false;
            crearDirigente.Visible = false;
            crearOrgano.Visible = false;
            crearPersonal.Visible = false;


            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":

                    gridCE.DataSource = dirigencia.ComiteEjecutivoRead(Session["Federacion"].ToString());
                    gridCE.DataBind();
                    gridAsamblea.DataSource = dirigencia.DirigenciaRead(1, Session["Federacion"].ToString(), year, 0);
                    gridAsamblea.DataBind();
                    gridDisciplina.DataSource = dirigencia.DirigenciaRead(2, Session["Federacion"].ToString(), year, 0);
                    gridDisciplina.DataBind();
                    gridComision.DataSource = dirigencia.DirigenciaRead(3, Session["Federacion"].ToString(), year, 0);
                    gridComision.DataBind();
                    gridPersonal.DataSource = dirigencia.DirigenciaRead(4, Session["Federacion"].ToString(), year, 0);
                    gridPersonal.DataBind();
                    gridDirigente.DataSource = dirigencia.DirigenciaRead(5, Session["Federacion"].ToString(), year, 0);
                    gridDirigente.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearAsamblea.Visible = true;
                                crearComision.Visible = true;
                                crearDirigente.Visible = true;
                                crearOrgano.Visible = true;
                                crearPersonal.Visible = true;
                                break;

                            case "PDF":
                                btPDF.Visible = true;
                                break;

                            case "Excel":
                                btExcel.Visible = true;
                                break;

                            case "Rechazar":
                                btObservacionSinRechazo.Visible = false;
                                break;

                            case "Crear":
                                crearAsambleaNew.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridCE.DataSource = dirigencia.ComiteEjecutivoRead(Session["Federacion"].ToString());
                    gridCE.DataBind();
                    gridAsamblea.DataSource = dirigencia.DirigenciaRead(1, Session["Federacion"].ToString(), year, 3);
                    gridAsamblea.DataBind();
                    gridDisciplina.DataSource = dirigencia.DirigenciaRead(2, Session["Federacion"].ToString(), year, 3);
                    gridDisciplina.DataBind();
                    gridComision.DataSource = dirigencia.DirigenciaRead(3, Session["Federacion"].ToString(), year, 3);
                    gridComision.DataBind();
                    gridPersonal.DataSource = dirigencia.DirigenciaRead(4, Session["Federacion"].ToString(), year, 3);
                    gridPersonal.DataBind();
                    gridDirigente.DataSource = dirigencia.DirigenciaRead(5, Session["Federacion"].ToString(), year, 3);
                    gridDirigente.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

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
                                btObservacionSinRechazo.Visible = false;
                                break;

                            case "Crear":
                                break;
                        }
                    }
                    break;

                case "Técnico Acompañamiento":
                    if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }

                    gridCE.DataSource = dirigencia.ComiteEjecutivoRead(Session["FederacionAsignada"].ToString());
                    gridCE.DataBind();
                    gridAsamblea.DataSource = dirigencia.DirigenciaRead(1, Session["FederacionAsignada"].ToString(), year, 6);
                    gridAsamblea.DataBind();
                    gridDisciplina.DataSource = dirigencia.DirigenciaRead(2, Session["FederacionAsignada"].ToString(), year, 6);
                    gridDisciplina.DataBind();
                    gridComision.DataSource = dirigencia.DirigenciaRead(3, Session["FederacionAsignada"].ToString(), year, 6);
                    gridComision.DataBind();
                    gridPersonal.DataSource = dirigencia.DirigenciaRead(4, Session["FederacionAsignada"].ToString(), year, 6);
                    gridPersonal.DataBind();
                    gridDirigente.DataSource = dirigencia.DirigenciaRead(5, Session["FederacionAsignada"].ToString(), year, 6);
                    gridDirigente.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

                    for (int j = 0; j < mostrar3.Rows.Count; j++)
                    {
                        switch (mostrar3.Rows[j][0].ToString())
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

                    gridCE.DataSource = dirigencia.ComiteEjecutivoRead(Session["FederacionAsignada"].ToString());
                    gridCE.DataBind();
                    gridAsamblea.DataSource = dirigencia.DirigenciaRead(1, Session["FederacionAsignada"].ToString(), year, 9);
                    gridAsamblea.DataBind();
                    gridDisciplina.DataSource = dirigencia.DirigenciaRead(2, Session["FederacionAsignada"].ToString(), year, 9);
                    gridDisciplina.DataBind();
                    gridComision.DataSource = dirigencia.DirigenciaRead(3, Session["FederacionAsignada"].ToString(), year, 9);
                    gridComision.DataBind();
                    gridPersonal.DataSource = dirigencia.DirigenciaRead(4, Session["FederacionAsignada"].ToString(), year, 9);
                    gridPersonal.DataBind();
                    gridDirigente.DataSource = dirigencia.DirigenciaRead(5, Session["FederacionAsignada"].ToString(), year, 9);
                    gridDirigente.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

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
                                btObservacionSinRechazo.Visible = false;
                                break;

                            case "Crear":
                                break;
                        }
                    }
                    break;
            }

            gridCE.Columns[0].Visible = false;
            gridAsamblea.Columns[0].Visible = false;
            gridDisciplina.Columns[0].Visible = false;
            gridComision.Columns[0].Visible = false;
            gridPersonal.Columns[0].Visible = false;
            gridDirigente.Columns[0].Visible = false;
        }

        protected void gridCE_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

        }

        protected void gridCE_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

        }

        protected void gridAsamblea_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridAsamblea.Columns[0].Visible = true;

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
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 18) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                            }

                            break;
                    }
                }
            }
        }

        protected void gridAsamblea_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            gridAsamblea.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridAsamblea.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Departamento(dropEditDepartamentoAsamblea, 2);
                        data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditAsamblea.Text = data.Rows[i][0].ToString();
                            txtEditNombre1Asamblea.Value = data.Rows[i][2].ToString();
                            txtEditNombre2Asamblea.Value = data.Rows[i][3].ToString();
                            txtEditApellido1Asamblea.Value = data.Rows[i][4].ToString();
                            txtEditApellido2Asamblea.Value = data.Rows[i][5].ToString();
                            dropEditDepartamentoAsamblea.SelectedValue = data.Rows[i][7].ToString();
                        }

                        idEditAsamblea.Visible = false;
                        mostrarEditAsamblea.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 18);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 18);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

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
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }

            if (e.CommandName == "Eliminar")
            {
                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 12);

                CargarGrid();
            }
            gridAsamblea.Columns[0].Visible = false;
        }

        protected void gridDisciplina_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridDisciplina.Columns[0].Visible = true;

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
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 18) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                            }

                            break;
                    }
                }
            }
        }

        protected void gridDisciplina_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            gridDisciplina.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridDisciplina.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Cargo(dropEditCargoOrgano);
                        data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditDisciplina.Text = data.Rows[i][0].ToString();
                            dropEditCargoOrgano.SelectedValue = data.Rows[i][1].ToString();
                            txtEditNombre1Organo.Value = data.Rows[i][2].ToString();
                            txtEditNombre2Organo.Value = data.Rows[i][3].ToString();
                            txtEditApellido1Organo.Value = data.Rows[i][4].ToString();
                            txtEditApellido2Organo.Value = data.Rows[i][5].ToString();
                        }

                        idEditDisciplina.Visible = false;
                        mostrarEditOrgano.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 18);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 18);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

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
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }

            if (e.CommandName == "Eliminar")
            {
                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 12);

                CargarGrid();
            }
            gridAsamblea.Columns[0].Visible = false;
        }

        protected void gridComision_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            gridComision.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridComision.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Cargo(dropEditCargoComision);
                        data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditComision.Text = data.Rows[i][0].ToString();
                            dropEditCargoComision.SelectedValue = data.Rows[i][1].ToString();
                            txtEditNombre1Comision.Value = data.Rows[i][2].ToString();
                            txtEditNombre2Comision.Value = data.Rows[i][3].ToString();
                            txtEditApellido1Comision.Value = data.Rows[i][4].ToString();
                            txtEditApellido2Comision.Value = data.Rows[i][5].ToString();
                        }

                        idEditComision.Visible = false;
                        mostrarEditComision.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 18);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 18);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

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
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }

            if (e.CommandName == "Eliminar")
            {
                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 12);

                CargarGrid();
            }
            gridAsamblea.Columns[0].Visible = false;
            gridComision.Columns[0].Visible = false;
        }

        protected void gridComision_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridComision.Columns[0].Visible = true;

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
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 18) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                            }

                            break;
                    }
                }
            }
        }

        protected void gridPersonal_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            gridPersonal.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridPersonal.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Cargo(dropEditCargoPersonal);
                        data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditPersonal.Text = data.Rows[i][0].ToString();
                            dropEditCargoPersonal.SelectedValue = data.Rows[i][1].ToString();
                            txtEditNombre1Personal.Value = data.Rows[i][2].ToString();
                            txtEditNombre2Personal.Value = data.Rows[i][3].ToString();
                            txtEditApellido1Personal.Value = data.Rows[i][4].ToString();
                            txtEditApellido2Personal.Value = data.Rows[i][5].ToString();
                        }

                        idEditPersonal.Visible = false;
                        mostrarEditPersonal.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 18);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 18);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

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
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }

            if (e.CommandName == "Eliminar")
            {
                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 12);

                CargarGrid();
            }
            gridAsamblea.Columns[0].Visible = false;
            gridPersonal.Columns[0].Visible = false;
        }

        protected void gridPersonal_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridPersonal.Columns[0].Visible = true;

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
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 18) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                            }

                            break;
                    }
                }
            }
        }

        protected void gridDirigente_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            gridDirigente.Columns[0].Visible = true;

            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridDirigente.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_Cargo(dropEditCargoDirigente);
                        data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditDirigente.Text = data.Rows[i][0].ToString();
                            dropEditCargoDirigente.SelectedValue = data.Rows[i][1].ToString();
                            txtEditNombre1Dirigente.Value = data.Rows[i][2].ToString();
                            txtEditNombre2Dirigente.Value = data.Rows[i][3].ToString();
                            txtEditApellido1Dirigente.Value = data.Rows[i][4].ToString();
                            txtEditApellido2Dirigente.Value = data.Rows[i][5].ToString();
                        }

                        idEditDirigente.Visible = false;
                        mostrarEditDirigente.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 18);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 18);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 18);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = dirigencia.SeleccionarDirigenciaDeportiva(int.Parse(row.Cells[0].Text));

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
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id17 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }

            if (e.CommandName == "Eliminar")
            {
                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(row.Cells[0].Text), 12);

                CargarGrid();
            }
            gridAsamblea.Columns[0].Visible = false;
            gridDirigente.Columns[0].Visible = false;
        }

        protected void gridDirigente_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "DIRIGENCIA DEPORTIVA");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridDirigente.Columns[0].Visible = true;

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
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Ver":
                            if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 18) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 18) == true)
                            {
                                (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                            }
                            break;

                        case "Eliminar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2)
                            {
                                (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Enviar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6)
                            {
                                (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                            }
                            break;

                        case "Aprobar":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3 || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                            }

                            break;

                        case "Observación":
                            if (dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || dirigencia.DirigenciaDeportivaSearch(int.Parse(e.Row.Cells[0].Text)) == 9)
                            {
                                (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                            }

                            break;
                    }
                }
            }
        }

        protected void nuevaAsamblea_Click(object sender, EventArgs e)
        {
            drop.Drop_Departamento(dropCrearDepartamentoAsamblea, 2);
            mostrarCrearAsamblea.Visible = true;
        }

        protected void nuevoOrgano_Click(object sender, EventArgs e)
        {
            drop.Drop_Cargo(dropCrearCargoOrgano);
            mostrarCrearOrgano.Visible = true;
        }

        protected void nuevoTecnico_Click(object sender, EventArgs e)
        {
            drop.Drop_Cargo(dropCrearCargoComision);
            mostrarCrearComision.Visible = true;
        }

        protected void nuevaAdministracion_Click(object sender, EventArgs e)
        {
            drop.Drop_Cargo(dropCrearCargoPersonal);
            mostrarCrearPersonal.Visible = true;
        }

        protected void nuevoDirigente_Click(object sender, EventArgs e)
        {
            drop.Drop_Cargo(dropCrearCargoDirigente);
            mostrarCrearDirigente.Visible = true;
        }

        protected void cancelCrearAsamblea_Click(object sender, EventArgs e)
        {
            mostrarCrearAsamblea.Visible = false;
        }

        protected void crearAsamblea_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = 0;
                modelo.fk_departamento = int.Parse(dropCrearDepartamentoAsamblea.SelectedValue);
                modelo.nombre1 = txtCrearNombre1Asamblea.Value;
                modelo.nombre2 = txtCrearNombre2Asamblea.Value;
                modelo.apellido1 = txtCrearApellido1Asamblea.Value;
                modelo.apellido2 = txtCrearApellido2Asamblea.Value;
                modelo.fk_persona = 1;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;
                dirigencia.DirigenciaCreate(modelo);

                drop.Drop_Departamento(dropCrearDepartamentoAsamblea, 2);
                txtCrearNombre1Asamblea.Value = null;
                txtCrearNombre2Asamblea.Value = null;
                txtCrearApellido1Asamblea.Value = null;
                txtCrearApellido2Asamblea.Value = null;

                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelCrearOrgano_Click(object sender, EventArgs e)
        {
            mostrarCrearOrgano.Visible = true;
        }

        protected void crearOrgano_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropCrearCargoOrgano.SelectedValue);
                modelo.nombre1 = txtCrearNombre1Organo.Value;
                modelo.nombre2 = txtCrearNombre2Organo.Value;
                modelo.apellido1 = txtCrearApellido1Organo.Value;
                modelo.apellido2 = txtCrearApellido2Organo.Value;
                modelo.fk_persona = 2;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;
                dirigencia.DirigenciaCreate(modelo);

                drop.Drop_Cargo(dropCrearCargoOrgano);
                txtCrearNombre1Organo.Value = null;
                txtCrearNombre2Organo.Value = null;
                txtCrearApellido1Organo.Value = null;
                txtCrearApellido2Organo.Value = null;

                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelCrearComision_Click(object sender, EventArgs e)
        {
            mostrarCrearComision.Visible = false;
        }

        protected void crearComision_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropCrearCargoComision.SelectedValue);
                modelo.nombre1 = txtCrearNombre1Comision.Value;
                modelo.nombre2 = txtCrearNombre2Comision.Value;
                modelo.apellido1 = txtCrearApellido1Comision.Value;
                modelo.apellido2 = txtCrearApellido2Comision.Value;
                modelo.fk_persona = 3;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;
                dirigencia.DirigenciaCreate(modelo);

                drop.Drop_Cargo(dropCrearCargoComision);
                txtCrearNombre1Comision.Value = null;
                txtCrearNombre2Comision.Value = null;
                txtCrearApellido1Comision.Value = null;
                txtCrearApellido2Comision.Value = null;

                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelCrearPersonal_Click(object sender, EventArgs e)
        {
            mostrarCrearPersonal.Visible = false;
        }

        protected void crearPersonal_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropCrearCargoPersonal.SelectedValue);
                modelo.nombre1 = txtCrearNombre1Personal.Value;
                modelo.nombre2 = txtCrearNombre2Personal.Value;
                modelo.apellido1 = txtCrearApellido1Personal.Value;
                modelo.apellido2 = txtCrearApellido2Personal.Value;
                modelo.fk_persona = 4;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;
                dirigencia.DirigenciaCreate(modelo);

                drop.Drop_Cargo(dropCrearCargoPersonal);
                txtCrearNombre1Personal.Value = null;
                txtCrearNombre2Personal.Value = null;
                txtCrearApellido1Personal.Value = null;
                txtCrearApellido2Personal.Value = null;

                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelCrearDirigente_Click(object sender, EventArgs e)
        {
            mostrarCrearDirigente.Visible = false;
        }

        protected void crearDirigente_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropCrearCargoDirigente.SelectedValue);
                modelo.nombre1 = txtCrearNombre1Dirigente.Value;
                modelo.nombre2 = txtCrearNombre2Dirigente.Value;
                modelo.apellido1 = txtCrearApellido1Dirigente.Value;
                modelo.apellido2 = txtCrearApellido2Dirigente.Value;
                modelo.fk_persona = 5;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;
                dirigencia.DirigenciaCreate(modelo);

                drop.Drop_Cargo(dropCrearCargoDirigente);
                txtCrearNombre1Dirigente.Value = null;
                txtCrearNombre2Dirigente.Value = null;
                txtCrearApellido1Dirigente.Value = null;
                txtCrearApellido2Dirigente.Value = null;

                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelEditAsamblea_Click(object sender, EventArgs e)
        {
            mostrarEditAsamblea.Visible = false;
        }

        protected void editAsamblea_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = 0;
                modelo.fk_departamento = int.Parse(dropEditDepartamentoAsamblea.SelectedValue);
                modelo.nombre1 = txtEditNombre1Asamblea.Value;
                modelo.nombre2 = txtEditNombre2Asamblea.Value;
                modelo.apellido1 = txtEditApellido1Asamblea.Value;
                modelo.apellido2 = txtEditApellido2Asamblea.Value;
                modelo.fk_persona = 1;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;

                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idEditAsamblea.Text), 0);

                txtEditNombre1Asamblea.Value = null;
                txtEditNombre2Asamblea.Value = null;
                txtEditApellido1Asamblea.Value = null;
                txtEditApellido2Asamblea.Value = null;

                mostrarEditAsamblea.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelEditOrgano_Click(object sender, EventArgs e)
        {
            mostrarEditOrgano.Visible = false;
        }

        protected void editOrgano_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropEditCargoOrgano.SelectedValue);
                modelo.nombre1 = txtEditNombre1Organo.Value;
                modelo.nombre2 = txtEditNombre2Organo.Value;
                modelo.apellido1 = txtEditApellido1Organo.Value;
                modelo.apellido2 = txtEditApellido2Organo.Value;
                modelo.fk_persona = 2;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;

                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idEditDisciplina.Text), 0);

                txtCrearNombre1Organo.Value = null;
                txtCrearNombre2Organo.Value = null;
                txtCrearApellido1Organo.Value = null;
                txtCrearApellido2Organo.Value = null;

                mostrarEditOrgano.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificado', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificado', 'error');", true);
            }
        }

        protected void cancelEditComision_Click(object sender, EventArgs e)
        {
            mostrarEditComision.Visible = false;
        }

        protected void editComision_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropEditCargoComision.SelectedValue);
                modelo.nombre1 = txtEditNombre1Comision.Value;
                modelo.nombre2 = txtEditNombre2Comision.Value;
                modelo.apellido1 = txtEditApellido1Comision.Value;
                modelo.apellido2 = txtEditApellido2Comision.Value;
                modelo.fk_persona = 3;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;

                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idEditComision.Text), 0);

                txtEditNombre1Comision.Value = null;
                txtEditNombre2Comision.Value = null;
                txtEditApellido1Comision.Value = null;
                txtEditApellido2Comision.Value = null;

                mostrarEditComision.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelEditPersonal_Click(object sender, EventArgs e)
        {
            mostrarEditPersonal.Visible = false;
        }

        protected void editPersonal_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropEditCargoPersonal.SelectedValue);
                modelo.nombre1 = txtEditNombre1Personal.Value;
                modelo.nombre2 = txtEditNombre2Personal.Value;
                modelo.apellido1 = txtEditApellido1Personal.Value;
                modelo.apellido2 = txtEditApellido2Personal.Value;
                modelo.fk_persona = 4;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;

                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idEditPersonal.Text), 0);

                txtEditNombre1Personal.Value = null;
                txtEditNombre2Personal.Value = null;
                txtEditApellido1Personal.Value = null;
                txtEditApellido2Personal.Value = null;

                mostrarEditPersonal.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelEditDirigente_Click(object sender, EventArgs e)
        {
            mostrarEditDirigente.Visible = false;
        }

        protected void editDirigente_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fk_cargo = int.Parse(dropEditCargoDirigente.SelectedValue);
                modelo.nombre1 = txtEditNombre1Dirigente.Value;
                modelo.nombre2 = txtEditNombre2Dirigente.Value;
                modelo.apellido1 = txtEditApellido1Dirigente.Value;
                modelo.apellido2 = txtEditApellido2Dirigente.Value;
                modelo.fk_persona = 5;
                modelo.fk_estado = 1;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.anio = year;

                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idEditDirigente.Text), 0);

                txtEditNombre1Dirigente.Value = null;
                txtEditNombre2Dirigente.Value = null;
                txtEditApellido1Dirigente.Value = null;
                txtEditApellido2Dirigente.Value = null;

                mostrarEditDirigente.Visible = false;
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
                obseracion.id17 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
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
                obseracion.id17 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN")
                {
                    obs.observacionCreateFADN(obseracion);
                    dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
                    crearObservacionRechazo.Visible = false;
                    CargarGrid();
                }
                if (Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateEvaluador(obseracion);
                    dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
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
                obseracion.id17 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                dirigencia.DirigenciaDeportivaUpdate(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
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

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }
    }
}