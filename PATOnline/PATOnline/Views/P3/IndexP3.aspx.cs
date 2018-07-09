using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Read;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.P3
{
    public partial class IndexP3 : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        P3EgresosActividad pat = new P3EgresosActividad();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloP3 modelo = new ModeloP3();
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

        public void CargarGrid()
        {
            gridFADN1.Columns[0].Visible = true;

            crearObservacionSinRechazo.Visible = false;
            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            mostrarObservacion.Visible = false;

            btPDF.Visible = false;
            btExcel.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridFADN1.DataSource = pat.P3Read(Session["Federacion"].ToString(), year, 0);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P3TotalRead(Session["Federacion"].ToString(), year, 0);
                    gridFADN2.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P3: EGRESOS POR ACTIVIDAD");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
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

                case "Usuario CE de FADN":
                    gridFADN1.DataSource = pat.P3Read(Session["Federacion"].ToString(), year, 3);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P3TotalRead(Session["Federacion"].ToString(), year, 3);
                    gridFADN2.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P3: EGRESOS POR ACTIVIDAD");

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

                    gridFADN1.DataSource = pat.P3Read(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P3TotalRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN2.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P3: EGRESOS POR ACTIVIDAD");

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

                    gridFADN1.DataSource = pat.P3Read(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P3TotalRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN2.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P3: EGRESOS POR ACTIVIDAD");

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

            gridFADN1.Columns[0].Visible = false;
        }

        protected void cancelarObservacionRechazo_Click(object sender, EventArgs e)
        {
            crearObservacionRechazo.Visible = false;
        }

        protected void guardarObservacionRechazo_Click(object sender, EventArgs e)
        {
            try
            {
                obseracion.id22 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.P3Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
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
                obseracion.id22 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    pat.P3Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
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
                obseracion.id22 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.P3Update(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
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

        protected void gridFADN1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P3: EGRESOS POR ACTIVIDAD");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridFADN1.Columns[0].Visible = true;

                (e.Row.FindControl("nuevoP3") as LinkButton).Visible = false;
                (e.Row.FindControl("crearP3") as LinkButton).Visible = false;
                (e.Row.FindControl("editP3") as LinkButton).Visible = false;
                (e.Row.FindControl("cancelCrearP3") as LinkButton).Visible = false;
                (e.Row.FindControl("cancelEditP3") as LinkButton).Visible = false;

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
                            switch (Session["Rol"].ToString())
                            {
                                case "Usuario Interno de FADN":
                                    (e.Row.FindControl("nuevoP3") as LinkButton).Visible = true;
                                    break;

                                case "Usuario CE de FADN":

                                    break;

                                case "Técnico Acompañamiento":

                                    break;

                                case "Técnico Evaluación":

                                    break;
                            }
                            break;

                        case "Editar":
                            if (e.Row.Cells[0].Text != "&nbsp;")
                            {
                                if (pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                {
                                    (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                                }
                            }
                            break;

                        case "Ver":
                            if (e.Row.Cells[0].Text != "&nbsp;")
                            {
                                if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 23) == true
                                        || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 23) == true
                                        || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 23) == true)
                                {
                                    (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                                }
                            }
                            break;

                        case "Eliminar":
                            if (e.Row.Cells[0].Text != "&nbsp;")
                            {
                                if (pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                {
                                    (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                                }
                            }
                            break;

                        case "Enviar":
                            if (e.Row.Cells[0].Text != "&nbsp;")
                            {
                                if (pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 1
                                    || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 2
                                    || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                                }
                            }
                            break;

                        case "Aprobar":
                            if (e.Row.Cells[0].Text != "&nbsp;")
                            {
                                if (pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                                }
                            }

                            break;

                        case "Observación":
                            if (e.Row.Cells[0].Text != "&nbsp;")
                            {
                                if (pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                    || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                    || pat.P3Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                                }
                            }
                            break;
                    }
                }

                if (Session["FederacionAsignada"] == null)
                {
                    if (pat.P3Search((e.Row.FindControl("lblCodigo") as Label).Text, Session["Federacion"].ToString(), year) == true)
                    {
                        (e.Row.FindControl("TxtPromocion") as TextBox).Enabled = false;
                        (e.Row.FindControl("TxtPrograma") as TextBox).Enabled = false;
                        (e.Row.FindControl("TxtActividad") as TextBox).Enabled = false;
                        (e.Row.FindControl("TxtOtraFuente") as TextBox).Enabled = false;
                    }
                }
                else
                {
                    (e.Row.FindControl("TxtPromocion") as TextBox).Enabled = false;
                    (e.Row.FindControl("TxtPrograma") as TextBox).Enabled = false;
                    (e.Row.FindControl("TxtActividad") as TextBox).Enabled = false;
                    (e.Row.FindControl("TxtOtraFuente") as TextBox).Enabled = false;
                }

            }
        }

        protected void gridFADN1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridFADN1.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridFADN1.Rows[index];
            DataTable data = new DataTable();

            if(e.CommandName == "Nuevo")
            {
                (row.FindControl("nuevoP3") as LinkButton).Visible = false;
                (row.FindControl("crearP3") as LinkButton).Visible = true;
                (row.FindControl("cancelCrearP3") as LinkButton).Visible = true;
            }

            if (e.CommandName == "CrearP3")
            {
                try
                {
                    modelo.codigo = (row.FindControl("lblCodigo") as Label).Text;
                    modelo.promocion = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text);
                    modelo.programa = Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text);
                    modelo.actividad = Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text);
                    modelo.otra_fuente = Convert.ToDouble((row.FindControl("TxtOtraFuente") as TextBox).Text);
                    modelo.subtoltal = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text);
                    modelo.total = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtOtraFuente") as TextBox).Text);
                    modelo.fadn = Session["Federacion"].ToString();
                    modelo.ano = year;
                    modelo.fkestado = 1;

                    pat.P3Create(modelo);
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
                }
            }

            if (e.CommandName == "CancelarCrearP3")
            {
                CargarGrid();
            }

            if (e.CommandName == "EditarP3")
            {
                try
                {
                    modelo.promocion = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text);
                    modelo.programa = Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text);
                    modelo.actividad = Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text);
                    modelo.otra_fuente = Convert.ToDouble((row.FindControl("TxtOtraFuente") as TextBox).Text);
                    modelo.subtoltal = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text);
                    modelo.total = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtOtraFuente") as TextBox).Text);

                    pat.P3Update(modelo, int.Parse(row.Cells[0].Text), 0);
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
                }
            }

            if (e.CommandName == "cancelEditP3")
            {
                CargarGrid();
            }

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        (row.FindControl("TxtPromocion") as TextBox).Enabled = true;
                        (row.FindControl("TxtPrograma") as TextBox).Enabled = true;
                        (row.FindControl("TxtActividad") as TextBox).Enabled = true;
                        (row.FindControl("TxtOtraFuente") as TextBox).Enabled = true;

                        (row.FindControl("nuevoP3") as LinkButton).Visible = false;
                        (row.FindControl("btEditar") as LinkButton).Visible = false;
                        (row.FindControl("editP3") as LinkButton).Visible = true;
                        (row.FindControl("cancelEditP3") as LinkButton).Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 23);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 23);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 23);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 23);

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
                        obseracion.id22 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.P3Update(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id22 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.P3Update(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }
                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.P3Update(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id22 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.P3Update(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Eliminar")
            {
                pat.P3Update(modelo, int.Parse(row.Cells[0].Text), 12);
                CargarGrid();
            }
            gridFADN1.Columns[0].Visible = false;
        }

        protected void gridFADN2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[0].Text != "")
                {
                    switch (Session["Rol"].ToString())
                    {
                        case "Usuario Interno de FADN":
                            if (pat.MontoP1_Igual_P3(Session["Federacion"].ToString(), year, 0) == 0)
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                            }
                            break;

                        case "Usuario CE de FADN":
                            if (pat.MontoP1_Igual_P3(Session["Federacion"].ToString(), year, 3) == 0)
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                            }
                            break;

                        case "Técnico Acompañamiento":
                            if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                            if (pat.MontoP1_Igual_P3(Session["FederacionAsignada"].ToString(), year, 6) == 0)
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                            }
                            break;

                        case "Técnico Evaluación":
                            if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                            if (pat.MontoP1_Igual_P3(Session["FederacionAsignada"].ToString(), year, 9) == 0)
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                            }
                            break;
                    }
                }
            }
        }

        protected void cancelMostrarObservacion_Click(object sender, EventArgs e)
        {
            mostrarObservacion.Visible = false;
        }
    }
}