using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Models;
using PATOnline.Controller.DropdownList;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.C4
{
    public partial class IndexC4 : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        C4Accion pat = new C4Accion();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloCPE modelo = new ModeloCPE();
        ModeloObservacion obseracion = new ModeloObservacion();
        Usuario id = new Usuario();

        public string year = Convert.ToString(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
                CargarGrid();
            }
        }

        protected void CargarGrid()
        {
            gridFADN.Columns[0].Visible = true;

            crearC4New.Visible = false;
            mostrarCrearC4.Visible = false;
            mostrarEditC4.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            mostrarObservacion.Visible = false;

            crearC4.Visible = false;
            editC4.Visible = false;
            btPDF.Visible = false;
            btExcel.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridFADN.DataSource = pat.C4Read(Session["Federacion"].ToString(), year, 0);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C4TotalRead(Session["Federacion"].ToString(), year, 0);
                    gridFADNTotal.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C4");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearC4.Visible = true;
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
                                crearC4New.Visible = true;
                                nuevoC4.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridFADN.DataSource = pat.C4Read(Session["Federacion"].ToString(), year, 3);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C4TotalRead(Session["Federacion"].ToString(), year, 3);
                    gridFADNTotal.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C4");

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

                    gridFADN.DataSource = pat.C4Read(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C4TotalRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADNTotal.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C4");

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

                    gridFADN.DataSource = pat.C4Read(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C4TotalRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADNTotal.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C4");

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
            gridFADN.Columns[0].Visible = false;
        }

        protected void nuevoC4_Click(object sender, EventArgs e)
        {
            drop.Drop_FormatoC(dropCrearFormato, 5);
            mostrarCrearC4.Visible = true;
        }

        protected void dropCrearFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pat.ExisteC4(int.Parse(dropCrearFormato.SelectedValue), Session["Federacion"].ToString(), year) == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                crearC4.Visible = false;
            }
            else
            {
                crearC4.Visible = true;
            }
        }

        protected void cancelCrearC4_Click(object sender, EventArgs e)
        {
            mostrarCrearC4.Visible = false;
        }

        protected void crearC4_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fkformato_ce = int.Parse(dropCrearFormato.SelectedValue);
                modelo.mes1 = int.Parse(txtCrearEneroAbril.Value);
                modelo.mes2 = int.Parse(txtCrearMayoAgosto.Value);
                modelo.mess3 = int.Parse(txtCrearSeptiembreDiciembre.Value);
                modelo.presupuesto = double.Parse(txtCrearPresupuesto.Value);
                modelo.anual = modelo.mes1 + modelo.mes2 + modelo.mess3;
                modelo.ano = year;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.fkestado = 1;

                if (pat.ExisteC4(int.Parse(dropCrearFormato.SelectedValue), Session["Federacion"].ToString(), year) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.C4Create(modelo);
                    CargarGrid();
                    mostrarCrearC4.Visible = false;
                    txtCrearEneroAbril.Value = null;
                    txtCrearMayoAgosto.Value = null;
                    txtCrearSeptiembreDiciembre.Value = null;
                    txtCrearPresupuesto.Value = null;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void cancelEditC4_Click(object sender, EventArgs e)
        {
            mostrarEditC4.Visible = false;
        }

        protected void editC4_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.mes1 = int.Parse(txtEditEneroAbril.Value);
                modelo.mes2 = int.Parse(txtEditMayoAgosto.Value);
                modelo.mess3 = int.Parse(txtEditSeptiembreDiciembre.Value);
                modelo.presupuesto = double.Parse(txtEditPresupuesto.Value);
                modelo.anual = modelo.mes1 + modelo.mes2 + modelo.mess3;
                modelo.ano = year;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.fkestado = 1;

                pat.C4Update(modelo, int.Parse(idEditCPE.Text), 0);
                CargarGrid();
                mostrarEditC4.Visible = false;
                txtEditEneroAbril.Value = null;
                txtEditMayoAgosto.Value = null;
                txtEditSeptiembreDiciembre.Value = null;
                txtEditPresupuesto.Value = null;
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
                obseracion.id12 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.C4Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
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
                obseracion.id12 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    pat.C4Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
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
                obseracion.id12 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.C4Update(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
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
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C4");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridFADN.Columns[0].Visible = true;

                (e.Row.FindControl("btEditar") as LinkButton).Visible = false;
                (e.Row.FindControl("btVer") as LinkButton).Visible = false;
                (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                (e.Row.FindControl("btObservacion") as LinkButton).Visible = false;
                (e.Row.FindControl("btAprobar") as LinkButton).Visible = false;
                (e.Row.FindControl("btEnviar") as LinkButton).Visible = false;

                if (int.Parse(e.Row.Cells[0].Text) > 0)
                {
                    for (int j = 0; j < mostra.Rows.Count; j++)
                    {
                        switch (mostra.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                break;

                            case "Editar":
                                if (pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                {
                                    (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                                }
                                break;

                            case "Ver":
                                if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 13) == true
                                            || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 13) == true
                                            || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 13) == true)
                                {
                                    (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                                }
                                break;

                            case "Eliminar":
                                if (pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                {
                                    (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                                }
                                break;

                            case "Enviar":
                                if (pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 1
                                        || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 2
                                        || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                                }
                                break;

                            case "Aprobar":
                                if (pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                                }

                                break;

                            case "Observación":
                                if (pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || pat.C4Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                                }
                                break;
                        }
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
                        drop.Drop_FormatoC(dropEditFormato, 5);
                        data = pat.C4Seleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEditCPE.Text = data.Rows[i][0].ToString();
                            dropEditFormato.SelectedValue = data.Rows[i][1].ToString();
                            txtEditEneroAbril.Value = data.Rows[i][2].ToString();
                            txtEditMayoAgosto.Value = data.Rows[i][3].ToString();
                            txtEditSeptiembreDiciembre.Value = data.Rows[i][4].ToString();
                            txtEditPresupuesto.Value = data.Rows[i][6].ToString();
                        }
                        dropEditFormato.Enabled = false;
                        idEditCPE.Visible = false;
                        mostrarEditC4.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 4);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 13);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 13);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 13);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.C4Seleccionar(int.Parse(row.Cells[0].Text));

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
                        obseracion.id12 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.C4Update(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id12 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.C4Update(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.C4Update(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id12 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.C4Update(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Eliminar")
            {
                pat.C4Update(modelo, int.Parse(row.Cells[0].Text), 12);
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