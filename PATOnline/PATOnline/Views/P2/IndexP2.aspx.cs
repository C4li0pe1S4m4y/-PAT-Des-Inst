using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Read;
using PATOnline.Models;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.P2
{
    public partial class IndexP2 : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        P2EgresosRenglon pat = new P2EgresosRenglon();
        IngresoCorriente ingreso = new IngresoCorriente();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloP2 modelo = new ModeloP2();
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
            gridFADN1.Columns[0].Visible = true;
            gridFADN2.Columns[0].Visible = true;

            crearP2New.Visible = false;
            mostrarCrearP2.Visible = false;
            mostrarEditP2.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            mostrarObservacion.Visible = false;

            crearP2.Visible = false;
            editP2.Visible = false;
            btPDF.Visible = false;
            btExcel.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridFADN1.DataSource = pat.P2Parte1Read(Session["Federacion"].ToString(), year, 0);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P2Parte2Read(Session["Federacion"].ToString(), year, 0);
                    gridFADN2.DataBind();
                    gridFADN3.DataSource = pat.P2TotalRead(Session["Federacion"].ToString(), year, 0);
                    gridFADN3.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P2: EGRESOS POR RENGLON");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearP2.Visible = true;
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
                                crearP2New.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridFADN1.DataSource = pat.P2Parte1Read(Session["Federacion"].ToString(), year, 3);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P2Parte2Read(Session["Federacion"].ToString(), year, 3);
                    gridFADN2.DataBind();
                    gridFADN3.DataSource = pat.P2TotalRead(Session["Federacion"].ToString(), year, 3);
                    gridFADN3.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P2: EGRESOS POR RENGLON");

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

                    gridFADN1.DataSource = pat.P2Parte1Read(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P2Parte2Read(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN2.DataBind();
                    gridFADN3.DataSource = pat.P2TotalRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN3.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P2: EGRESOS POR RENGLON");

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

                    gridFADN1.DataSource = pat.P2Parte1Read(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN1.DataBind();
                    gridFADN2.DataSource = pat.P2Parte2Read(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN2.DataBind();
                    gridFADN3.DataSource = pat.P2TotalRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN3.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P2: EGRESOS POR RENGLON");

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
            gridFADN2.Columns[0].Visible = false;
        }
        protected void nuevoP2_Click(object sender, EventArgs e)
        {
            drop.Drop_TipoProyecto(dropCrearTipoProyecto);
            drop.Drop_Proyecto(dropCrearProyecto, 0);
            drop.Drop_CodigoProyecto(dropCrearRenglon, 0);
            mostrarCrearP2.Visible = true;
        }
        protected void dropCrearTipoProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Proyecto(dropCrearProyecto, int.Parse(dropCrearTipoProyecto.SelectedValue));
        }
        protected void dropCrearProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_CodigoProyecto(dropCrearRenglon, int.Parse(dropCrearProyecto.SelectedValue));
        }
        protected void dropCrearRenglon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pat.P2Search(int.Parse(dropCrearRenglon.SelectedValue), Session["Federacion"].ToString(), year) == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Ya existe un registro igual', 'warning');", true);
            }
        }
        protected void verificarCrearP2_Click(object sender, EventArgs e)
        {
            try
            {
                double monto_50 = (double.Parse(txtCrearUno.Value) * 50) / 100;
                double restante = (double.Parse(txtCrearCuatro.Value) - double.Parse(txtCrearDos.Value)) - double.Parse(txtCrearTres.Value);

                if (double.Parse(txtCrearUno.Value) == monto_50)
                {
                    txtCrearUno.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtCrearUno.Attributes.Add(" style", "color: red;");
                }

                double monto_30 = (double.Parse(txtCrearCuatro.Value) * 30) / 100;

                if (double.Parse(txtCrearDos.Value) == monto_30)
                {
                    txtCrearDos.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtCrearDos.Attributes.Add(" style", "color: red;");
                }

                double monto_20 = (double.Parse(txtCrearCuatro.Value) * 20) / 100;

                if (double.Parse(txtCrearTres.Value) == monto_20)
                {
                    txtCrearTres.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtCrearTres.Attributes.Add(" style", "color: red;");
                }

                double monto_100 = double.Parse(txtCrearUno.Value) + double.Parse(txtCrearDos.Value) + double.Parse(txtCrearTres.Value);

                if (double.Parse(txtCrearCuatro.Value) == monto_100)
                {
                    txtCrearCuatro.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtCrearCuatro.Attributes.Add(" style", "color: red;");
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Los montos no son correctos', 'warning');", true);
            }
        }
        protected void cancelCrearP2_Click(object sender, EventArgs e)
        {
            txtCrearUno.Value = null;
            txtCrearDos.Value = null;
            txtCrearTres.Value = null;
            txtCrearCuatro.Value = null;
            txtCrearFinanciamiento.Value = null;
            mostrarCrearP2.Visible = false;
        }
        protected void crearP2_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.col_uno = Convert.ToDouble(txtCrearUno.Value);
                modelo.col_dos = Convert.ToDouble(txtCrearDos.Value);
                modelo.col_tres = Convert.ToDouble(txtCrearTres.Value);
                modelo.col_cuatro = Convert.ToDouble(txtCrearCuatro.Value);
                if (txtCrearFinanciamiento.Value == null || txtCrearFinanciamiento.Value == "")
                {
                    modelo.col_cinco = 0;
                }
                else
                {
                    modelo.col_cinco = Convert.ToDouble(txtCrearFinanciamiento.Value);
                }
                modelo.fkprograma = int.Parse(dropCrearRenglon.SelectedValue);
                modelo.fadn = Session["Federacion"].ToString();
                modelo.ano = year;
                modelo.fkestado = 1;

                if (pat.P2Search(int.Parse(dropCrearRenglon.SelectedValue), Session["Federacion"].ToString(), year) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Ya existe un registro igual', 'warning');", true);
                }
                else
                {
                    pat.P2Create(modelo);
                    CargarGrid();
                    mostrarCrearP2.Visible = false;
                    txtCrearUno.Value = null;
                    txtCrearDos.Value = null;
                    txtCrearTres.Value = null;
                    txtCrearCuatro.Value = null;
                    txtCrearFinanciamiento.Value = null;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }
        protected void dropEditTipoProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Proyecto(dropEditProyecto, int.Parse(dropEditTipoProyecto.SelectedValue));
        }
        protected void dropEditProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_CodigoProyecto(dropEditRenglon, int.Parse(dropEditProyecto.SelectedValue));
        }
        protected void dropEditRenglon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pat.P2Search(int.Parse(dropEditRenglon.SelectedValue), Session["Federacion"].ToString(), year) == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Ya existe un registro igual', 'warning');", true);
            }
        }
        protected void verificarEditP2_Click(object sender, EventArgs e)
        {
            try
            {
                double monto_50 = (double.Parse(txtEditUno.Value) * 50) / 100;
                double restante = (double.Parse(txtEditCuatro.Value) - double.Parse(txtEditDos.Value)) - double.Parse(txtEditTres.Value);

                if (double.Parse(txtEditUno.Value) == monto_50)
                {
                    txtEditUno.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtEditUno.Attributes.Add(" style", "color: red;");
                }

                double monto_30 = (double.Parse(txtEditCuatro.Value) * 30) / 100;

                if (double.Parse(txtEditDos.Value) == monto_30)
                {
                    txtEditDos.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtEditDos.Attributes.Add(" style", "color: red;");
                }

                double monto_20 = (double.Parse(txtEditCuatro.Value) * 20) / 100;

                if (double.Parse(txtEditTres.Value) == monto_20)
                {
                    txtEditTres.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtEditTres.Attributes.Add(" style", "color: red;");
                }

                double monto_100 = double.Parse(txtEditUno.Value) + double.Parse(txtEditDos.Value) + double.Parse(txtEditTres.Value);

                if (double.Parse(txtEditCuatro.Value) == monto_100)
                {
                    txtEditCuatro.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    txtEditCuatro.Attributes.Add(" style", "color: red;");
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Los montos no son correctos', 'warning');", true);
            }
        }
        protected void cancelEditP2_Click(object sender, EventArgs e)
        {
            txtEditUno.Value = null;
            txtEditDos.Value = null;
            txtEditTres.Value = null;
            txtEditCuatro.Value = null;
            mostrarEditP2.Visible = false;
        }
        protected void editP2_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.col_uno = Convert.ToDouble(txtEditUno.Value);
                modelo.col_dos = Convert.ToDouble(txtEditDos.Value);
                modelo.col_tres = Convert.ToDouble(txtEditTres.Value);
                modelo.col_cuatro = Convert.ToDouble(txtEditCuatro.Value);
                if (txtEditFinanciamiento.Value == null || txtEditFinanciamiento.Value == "")
                {
                    modelo.col_cinco = 0;
                }
                else
                {
                    modelo.col_cinco = Convert.ToDouble(txtEditFinanciamiento.Value);
                }
                modelo.fkprograma = int.Parse(dropEditRenglon.SelectedValue);

                pat.P2Update(modelo, int.Parse(idEdit.Text), 0);
                CargarGrid();
                mostrarEditP2.Visible = false;
                txtEditUno.Value = null;
                txtEditDos.Value = null;
                txtEditTres.Value = null;
                txtEditCuatro.Value = null;
                txtEditFinanciamiento.Value = null;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);           
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
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
                obseracion.id21 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.P2Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
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
                obseracion.id21 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    pat.P2Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
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
                obseracion.id21 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.P2Update(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
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
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P2: EGRESOS POR RENGLON");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridFADN1.Columns[0].Visible = true;

                (e.Row.FindControl("btEditar") as LinkButton).Visible = false;
                (e.Row.FindControl("btVer") as LinkButton).Visible = false;
                (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                (e.Row.FindControl("btObservacion") as LinkButton).Visible = false;
                (e.Row.FindControl("btAprobar") as LinkButton).Visible = false;
                (e.Row.FindControl("btEnviar") as LinkButton).Visible = false;


                if (e.Row.Cells[0].Text != "&nbsp;")
                {
                    if(int.Parse(e.Row.Cells[0].Text) > 0)
                    {
                        for (int j = 0; j < mostra.Rows.Count; j++)
                        {
                            switch (mostra.Rows[j][0].ToString())
                            {
                                case "Guardar":
                                    break;

                                case "Editar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                    {
                                        (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Ver":
                                    if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 22) == true
                                                || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 22) == true
                                                || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 22) == true)
                                    {
                                        (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Eliminar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                    {
                                        (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Enviar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 1
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 2
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                    {
                                        (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Aprobar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                    {
                                        (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                                    }

                                    break;

                                case "Observación":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                    {
                                        (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                                    }
                                    break;
                            }
                        }
                    }                 
                }
            }
        }
        protected void gridFADN1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridFADN1.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridFADN1.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_TipoProyecto(dropEditTipoProyecto);
                        data = pat.P2Seleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEdit.Text = data.Rows[i][0].ToString();
                            dropEditTipoProyecto.SelectedValue = data.Rows[i][1].ToString();
                            drop.Drop_Proyecto(dropEditProyecto, int.Parse(dropEditTipoProyecto.SelectedValue));
                            dropEditProyecto.SelectedValue = data.Rows[i][2].ToString();
                            drop.Drop_CodigoProyecto(dropEditRenglon, int.Parse(dropEditProyecto.SelectedValue));
                            dropEditRenglon.SelectedValue = data.Rows[i][3].ToString();
                            txtEditUno.Value = data.Rows[i][4].ToString();
                            txtEditDos.Value = data.Rows[i][5].ToString();
                            txtEditTres.Value = data.Rows[i][6].ToString();
                            txtEditCuatro.Value = data.Rows[i][7].ToString();
                            txtEditFinanciamiento.Value = data.Rows[i][8].ToString();
                        }
                        idEdit.Visible = false;
                        dropEditTipoProyecto.Enabled = false;
                        dropEditProyecto.Enabled = false;
                        dropEditRenglon.Enabled = false;
                        mostrarEditP2.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 22);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 22);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 22);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 22);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.P2Seleccionar(int.Parse(row.Cells[0].Text));

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
                        obseracion.id21 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id21 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id21 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Eliminar")
            {
                pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 12);
                CargarGrid();
            }
            gridFADN1.Columns[0].Visible = false;
        }
        protected void gridFADN2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable mostra = new DataTable();
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "P2: EGRESOS POR RENGLON");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                gridFADN2.Columns[0].Visible = true;

                (e.Row.FindControl("btEditar") as LinkButton).Visible = false;
                (e.Row.FindControl("btVer") as LinkButton).Visible = false;
                (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                (e.Row.FindControl("btObservacion") as LinkButton).Visible = false;
                (e.Row.FindControl("btAprobar") as LinkButton).Visible = false;
                (e.Row.FindControl("btEnviar") as LinkButton).Visible = false;


                if (e.Row.Cells[0].Text != "&nbsp;")
                {
                    if (int.Parse(e.Row.Cells[0].Text) > 0)
                    {
                        for (int j = 0; j < mostra.Rows.Count; j++)
                        {
                            switch (mostra.Rows[j][0].ToString())
                            {
                                case "Guardar":
                                    break;

                                case "Editar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                    {
                                        (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Ver":
                                    if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 22) == true
                                                || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 22) == true
                                                || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 22) == true)
                                    {
                                        (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Eliminar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                    {
                                        (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Enviar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 1
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 2
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                    {
                                        (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                                    }
                                    break;

                                case "Aprobar":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                    {
                                        (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                                    }

                                    break;

                                case "Observación":
                                    if (pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                            || pat.P2Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                    {
                                        (e.Row.FindControl("btObservacion") as LinkButton).Visible = true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
        protected void gridFADN2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridFADN2.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridFADN2.Rows[index];
            DataTable data = new DataTable();

            if (e.CommandName == "Editar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        drop.Drop_TipoProyecto(dropEditTipoProyecto);
                        data = pat.P2Seleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEdit.Text = data.Rows[i][0].ToString();
                            dropEditTipoProyecto.SelectedValue = data.Rows[i][1].ToString();
                            drop.Drop_Proyecto(dropEditProyecto, int.Parse(dropEditTipoProyecto.SelectedValue));
                            dropEditProyecto.SelectedValue = data.Rows[i][2].ToString();
                            drop.Drop_CodigoProyecto(dropEditRenglon, int.Parse(dropEditProyecto.SelectedValue));
                            dropEditRenglon.SelectedValue = data.Rows[i][3].ToString();
                            txtEditUno.Value = data.Rows[i][4].ToString();
                            txtEditDos.Value = data.Rows[i][5].ToString();
                            txtEditTres.Value = data.Rows[i][6].ToString();
                            txtEditCuatro.Value = data.Rows[i][7].ToString();
                            txtEditFinanciamiento.Value = data.Rows[i][8].ToString();
                        }
                        idEdit.Visible = false;
                        dropEditTipoProyecto.Enabled = false;
                        dropEditProyecto.Enabled = false;
                        dropEditRenglon.Enabled = false;
                        mostrarEditP2.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 22);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 22);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 22);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 22);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.P2Seleccionar(int.Parse(row.Cells[0].Text));

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
                        obseracion.id21 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id21 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id21 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Eliminar")
            {
                pat.P2Update(modelo, int.Parse(row.Cells[0].Text), 12);
                CargarGrid();
            }
            gridFADN2.Columns[0].Visible = false;
        }
        protected void gridFADN3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = int.Parse(e.Row.RowIndex.ToString());

            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                string f = (e.Row.FindControl("total1") as Label).Text;
                if ((e.Row.FindControl("total1") as Label).Text != "")
                {
                    switch (index)
                    {
                        case 0:
                            if (double.Parse((e.Row.FindControl("total4") as Label).Text) * 50 / 100 == double.Parse((e.Row.FindControl("total1") as Label).Text))
                            {
                                (e.Row.FindControl("total1") as Label).ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                (e.Row.FindControl("total1") as Label).ForeColor = System.Drawing.Color.Red;
                            }

                            if (double.Parse((e.Row.FindControl("total4") as Label).Text) * 30 / 100 == double.Parse((e.Row.FindControl("total2") as Label).Text))
                            {
                                (e.Row.FindControl("total2") as Label).ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                (e.Row.FindControl("total2") as Label).ForeColor = System.Drawing.Color.Red;
                            }

                            if (double.Parse((e.Row.FindControl("total4") as Label).Text) * 20 / 100 == double.Parse((e.Row.FindControl("total3") as Label).Text))
                            {
                                (e.Row.FindControl("total3") as Label).ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                (e.Row.FindControl("total3") as Label).ForeColor = System.Drawing.Color.Red;
                            }

                            double suma = double.Parse((e.Row.FindControl("total1") as Label).Text) + double.Parse((e.Row.FindControl("total2") as Label).Text) + double.Parse((e.Row.FindControl("total3") as Label).Text);
                            if (suma == double.Parse((e.Row.FindControl("total4") as Label).Text))
                            {
                                (e.Row.FindControl("total4") as Label).ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                (e.Row.FindControl("total4") as Label).ForeColor = System.Drawing.Color.Red;
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