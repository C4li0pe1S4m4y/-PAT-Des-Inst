using System.Web.UI.WebControls;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using PATOnline.Models;
using PATOnline.Controller.DropdownList;
using System;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.C1
{
    public partial class IndexC1_1 : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        C1_1 pat = new C1_1();
        ReadBoton boton = new ReadBoton();
        Observacion obs = new Observacion();
        ModeloC1 modelo = new ModeloC1();
        ModeloObservacion obseracion = new ModeloObservacion();
        Usuario id = new Usuario();

        public string year = Convert.ToString(DateTime.Now.Year);
        private string nuevo_codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
                    CargarGrid();
                }
            }
        }

        protected void CargarGrid()
        {
            gridFADN.Columns[0].Visible = true;

            crearC11New.Visible = false;
            mostrarCrearC11.Visible = false;
            mostrarEditC11.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            crearObservacionRechazo.Visible = false;
            crearObservacionSinRechazo.Visible = false;
            mostrarObservacion.Visible = false;

            crearC11.Visible = false;
            editC11.Visible = false;
            btPDF.Visible = false;
            btExcel.Visible = false;
            guardarObservacionRechazo.Visible = false;
            btcrearObservacionRechazo.Visible = false;
            btObservacionSinRechazo.Visible = false;
            btObservacionSinRechazoUpdate.Visible = false;

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    gridFADN.DataSource = pat.C1_1Read(Session["Federacion"].ToString(), year, 0);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C1_1TotalRead(Session["Federacion"].ToString(), year, 0);
                    gridFADNTotal.DataBind();

                    DataTable mostrar5 = new DataTable();
                    mostrar5 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C1.1: DCH");

                    for (int j = 0; j < mostrar5.Rows.Count; j++)
                    {
                        switch (mostrar5.Rows[j][0].ToString())
                        {
                            case "Guardar":
                                crearC11.Visible = true;
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
                                crearC11New.Visible = true;
                                nuevoC11.Visible = true;
                                break;
                        }
                    }
                    break;

                case "Usuario CE de FADN":
                    gridFADN.DataSource = pat.C1_1Read(Session["Federacion"].ToString(), year, 3);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C1_1TotalRead(Session["Federacion"].ToString(), year, 3);
                    gridFADNTotal.DataBind();

                    DataTable mostrar4 = new DataTable();
                    mostrar4 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C1.1: DCH");

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

                    gridFADN.DataSource = pat.C1_1Read(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C1_1TotalRead(Session["FederacionAsignada"].ToString(), year, 6);
                    gridFADNTotal.DataBind();

                    DataTable mostrar2 = new DataTable();
                    mostrar2 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C1.1: DCH");

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

                    gridFADN.DataSource = pat.C1_1Read(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADN.DataBind();
                    gridFADNTotal.DataSource = pat.C1_1TotalRead(Session["FederacionAsignada"].ToString(), year, 9);
                    gridFADNTotal.DataBind();

                    DataTable mostrar3 = new DataTable();
                    mostrar3 = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C1.1: DCH");

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

        public string generarCodigo(string fadn, string ano)
        {
            int codigo = pat.C1_1Codigo(fadn, ano);
            if (codigo > 99)
            {
                nuevo_codigo = "-C1_1-" + Convert.ToString(codigo + 1);
            }
            else if (codigo > 9 && codigo < 100)
            {
                nuevo_codigo = "-C1_1-0" + Convert.ToString(codigo + 1);
            }
            else
            {
                nuevo_codigo = "-C1_1-00" + Convert.ToString(codigo + 1);
            }
            return nuevo_codigo;
        }

        protected void nuevoC11_Click(object sender, EventArgs e)
        {
            txtCrearCodigo.Enabled = false;
            txtCrearCodigo.Text = year + generarCodigo(Session["Federacion"].ToString(), year);
            drop.Drop_ActividadPAT(dropCrearActividad, 3);
            drop.Drop_Categoria(dropCrearCategoria, 2);
            drop.Drop_Pais(dropCrearPais);
            drop.Drop_Departamento(dropCrearDepartamento, 0);
            drop.Drop_Dia(dropCrearDiaInicio);
            drop.Drop_Mes(dropCrearMesInicio);
            drop.Drop_Dia(dropCrearDiaFin);
            drop.Drop_Mes(dropCrearMesFin);
            mostrarCrearC11.Visible = true;
        }

        protected void dropCrearPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Departamento(dropCrearDepartamento, int.Parse(dropCrearPais.SelectedValue));
        }

        protected void cancelCrearC11_Click(object sender, EventArgs e)
        {
            mostrarCrearC11.Visible = false;
        }

        protected void crearC11_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.codigo = txtCrearCodigo.Text;
                modelo.fkcategoria = int.Parse(dropCrearCategoria.SelectedValue);
                modelo.fkactividad = int.Parse(dropCrearActividad.SelectedValue);
                modelo.prespuesto = double.Parse(txtCrearPresupuesto.Value);
                modelo.resultado = txtCrearResultado.Value;
                modelo.registro = txtCrearRegistro.Value;
                modelo.i_dia = int.Parse(dropCrearDiaInicio.SelectedValue);
                modelo.i_mes = dropCrearMesInicio.SelectedValue;
                modelo.f_dia = int.Parse(dropCrearDiaFin.SelectedValue);
                modelo.f_mes = dropCrearMesFin.SelectedValue;
                modelo.fkpais_departamento = int.Parse(dropCrearDepartamento.SelectedValue);
                modelo.lugar = txtCrearLugar.Value;
                modelo.descripcion = txtCrearDescripcion.Value;
                modelo.ano = year;
                modelo.fadn = Session["Federacion"].ToString();
                modelo.fkestado = 1;

                if (pat.C1_1ExisteCodigo(txtCrearCodigo.Text, Session["Federacion"].ToString(), year) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    pat.C1_1Create(modelo);
                    CargarGrid();
                    mostrarCrearC11.Visible = false;
                    txtCrearCodigo.Text = null;
                    txtCrearPresupuesto.Value = null;
                    txtCrearResultado.Value = null;
                    txtCrearRegistro.Value = null;
                    txtCrearLugar.Value = null;
                    txtCrearDescripcion.Value = null;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void dropEditPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Departamento(dropEditDepartamento, int.Parse(dropEditPais.SelectedValue));
        }

        protected void cancelEditC11_Click(object sender, EventArgs e)
        {
            mostrarEditC11.Visible = false;
        }

        protected void editC11_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fkcategoria = int.Parse(dropEditCategoria.SelectedValue);
                modelo.fkactividad = int.Parse(dropEditActividad.SelectedValue);
                modelo.prespuesto = double.Parse(txtEditPresupuesto.Value);
                modelo.resultado = txtEditResultado.Value;
                modelo.registro = txtEditRegistro.Value;
                modelo.i_dia = int.Parse(dropEditDiaInicio.SelectedValue);
                modelo.i_mes = dropEditMesInicio.SelectedValue;
                modelo.f_dia = int.Parse(dropEditDiaFin.SelectedValue);
                modelo.f_mes = dropEditMesFin.SelectedValue;
                modelo.fkpais_departamento = int.Parse(dropEditDepartamento.SelectedValue);
                modelo.lugar = txtEditLugar.Value;
                modelo.descripcion = txtEditDescripcion.Value;

                pat.C1_1Update(modelo, int.Parse(idEdit.Text), 0);
                CargarGrid();
                mostrarEditC11.Visible = false;
                txtEditCodigo.Text = null;
                txtEditPresupuesto.Value = null;
                txtEditResultado.Value = null;
                txtEditRegistro.Value = null;
                txtEditLugar.Value = null;
                txtEditDescripcion.Value = null;
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
                obseracion.id4 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateEvaluador(obseracion);
                pat.C1_1Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 13);
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
                obseracion.id4 = int.Parse(idIntroObservacionRechazo.Text);
                obseracion.observacion = txtCrearObservacion.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));

                if (Session["Rol"].ToString() == "Usuario CE de FADN" || Session["Rol"].ToString() == "Técnico Evaluación")
                {
                    obs.observacionCreateFADN(obseracion);
                    pat.C1_1Update(modelo, int.Parse(idIntroObservacionRechazo.Text), 2);
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
                obseracion.id4 = int.Parse(idIntroObservacionSinRechazo.Text);
                obseracion.observacion = txtCrearObservacionSinRechazo.Value;
                obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                obs.observacionCreateAcompaniamiento(obseracion);
                pat.C1_1Update(modelo, int.Parse(idIntroObservacionSinRechazo.Text), 9);
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
            mostra = boton.BotonReadUsuario(Session["Usuario"].ToString(), "C1.1: DCH");

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
                                if (pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                {
                                    (e.Row.FindControl("btEditar") as LinkButton).Visible = true;
                                }
                                break;

                            case "Ver":
                                if (obs.ObservacionCEFADNExiste(int.Parse(e.Row.Cells[0].Text), 5) == true
                                            || obs.ObservacionAcompaniamientoExiste(int.Parse(e.Row.Cells[0].Text), 5) == true
                                            || obs.ObservacionEvaluadorExiste(int.Parse(e.Row.Cells[0].Text), 5) == true)
                                {
                                    (e.Row.FindControl("btVer") as LinkButton).Visible = true;
                                }
                                break;

                            case "Eliminar":
                                if (pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 1 || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 2)
                                {
                                    (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                                }
                                break;

                            case "Enviar":
                                if (pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 1
                                        || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 2
                                        || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btEnviar") as LinkButton).Visible = true;
                                }
                                break;

                            case "Aprobar":
                                if (pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 3 || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
                                {
                                    (e.Row.FindControl("btAprobar") as LinkButton).Visible = true;
                                }

                                break;

                            case "Observación":
                                if (pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 3
                                        || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 6
                                        || pat.C1_1Estado(int.Parse(e.Row.Cells[0].Text)) == 9)
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
                        drop.Drop_ActividadPAT(dropEditActividad, 3);
                        drop.Drop_Categoria(dropEditCategoria, 2);
                        drop.Drop_Pais(dropEditPais);
                        drop.Drop_Dia(dropEditDiaInicio);
                        drop.Drop_Mes(dropEditMesInicio);
                        drop.Drop_Dia(dropEditDiaFin);
                        drop.Drop_Mes(dropEditMesFin);
                        drop.Drop_Pais(dropEditPais);
                        data = pat.C1_1Seleccionar(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idEdit.Text = data.Rows[i][0].ToString();
                            txtEditCodigo.Text = data.Rows[i][1].ToString();
                            dropEditActividad.SelectedValue = data.Rows[i][2].ToString();
                            dropEditCategoria.SelectedValue = data.Rows[i][3].ToString();
                            txtEditPresupuesto.Value = data.Rows[i][4].ToString();
                            txtEditResultado.Value = data.Rows[i][5].ToString();
                            txtEditRegistro.Value = data.Rows[i][6].ToString();
                            dropEditDiaInicio.SelectedValue = data.Rows[i][7].ToString();
                            dropEditMesInicio.SelectedValue = data.Rows[i][8].ToString();
                            dropEditDiaFin.SelectedValue = data.Rows[i][9].ToString();
                            dropEditMesFin.SelectedValue = data.Rows[i][10].ToString();
                            dropEditPais.SelectedValue = data.Rows[i][11].ToString();
                            drop.Drop_Departamento(dropEditDepartamento, int.Parse(dropEditPais.SelectedValue));
                            dropEditDepartamento.SelectedValue = data.Rows[i][12].ToString();
                            txtEditLugar.Value = data.Rows[i][13].ToString();
                            txtEditDescripcion.Value = data.Rows[i][14].ToString();
                        }
                        idEdit.Visible = false;
                        txtEditCodigo.Enabled = false;
                        mostrarEditC11.Visible = true;
                        break;

                    case "Técnico Evaluación":
                        data = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 5);

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
                listObservacionesFADN.DataSource = obs.observacionMostrarFADN(int.Parse(row.Cells[0].Text), 5);
                listObservacionesAcompaniamiento.DataSource = obs.observacionMostrarAcompaniamiento(int.Parse(row.Cells[0].Text), 5);
                listObservacionesEvaluacion.DataSource = obs.observacionMostrarEvaluador(int.Parse(row.Cells[0].Text), 5);

                listObservacionesFADN.DataBind();
                listObservacionesAcompaniamiento.DataBind();
                listObservacionesEvaluacion.DataBind();

                mostrarObservacion.Visible = true;
            }
            if (e.CommandName == "Observacion")
            {
                data = pat.C1_1Seleccionar(int.Parse(row.Cells[0].Text));

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
                        obseracion.id4 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateFADN(obseracion);
                        pat.C1_1Update(modelo, int.Parse(row.Cells[0].Text), 6);
                        break;

                    case "Técnico Evaluación":
                        obseracion.id4 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateEvaluador(obseracion);
                        pat.C1_1Update(modelo, int.Parse(row.Cells[0].Text), 13);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Enviar")
            {
                switch (Session["Rol"].ToString())
                {
                    case "Usuario Interno de FADN":
                        pat.C1_1Update(modelo, int.Parse(row.Cells[0].Text), 3);
                        break;

                    case "Técnico Acompañamiento":
                        obseracion.id4 = int.Parse(row.Cells[0].Text);
                        obseracion.usuario = id.idUsuario(Convert.ToString(Session["Usuario"]));
                        obs.observacionCreateAcompaniamiento(obseracion);
                        pat.C1_1Update(modelo, int.Parse(row.Cells[0].Text), 9);
                        break;
                }

                CargarGrid();
            }
            if (e.CommandName == "Eliminar")
            {
                pat.C1_1Update(modelo, int.Parse(row.Cells[0].Text), 12);
                CargarGrid();
            }
            gridFADN.Columns[0].Visible = false;
        }

        protected void gridFADNTotal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.FindControl("lblPresupuesto") as Label).Text != "")
                {
                    switch (Session["Rol"].ToString())
                    {
                        case "Usuario Interno de FADN":
                            if (double.Parse((e.Row.FindControl("lblPresupuesto") as Label).Text) == pat.C1_1Presupuesto(Session["Federacion"].ToString(), year, 0))
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                            }
                            break;

                        case "Usuario CE de FADN":
                            if (double.Parse((e.Row.FindControl("lblPresupuesto") as Label).Text) == pat.C1_1Presupuesto(Session["Federacion"].ToString(), year, 3))
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                            }
                            break;

                        case "Técnico Acompañamiento":
                            if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                            if (double.Parse((e.Row.FindControl("lblPresupuesto") as Label).Text) == pat.C1_1Presupuesto(Session["FederacionAsignada"].ToString(), year, 6))
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                            }
                            break;

                        case "Técnico Evaluación":
                            if (this.Session["FederacionAsignada"] == null) { Response.Redirect("~/DashboardFADN.aspx"); }
                            if (double.Parse((e.Row.FindControl("lblPresupuesto") as Label).Text) == pat.C1_1Presupuesto(Session["FederacionAsignada"].ToString(), year, 9))
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
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