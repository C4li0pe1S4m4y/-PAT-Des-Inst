using System;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Controller.Update;
using PATOnline.Controller.Read;
using PATOnline.Models;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.AdministracionPAT
{
    public partial class AdministracionPAT : System.Web.UI.Page
    {
        ReadAdministracionPAT all = new ReadAdministracionPAT();
        CreateAdministracionPAT nuevo = new CreateAdministracionPAT();
        SearchAdministracionPAT buscar = new SearchAdministracionPAT();
        ModeloBrecha modelo_brecha = new ModeloBrecha();
        ModeloCargo modelo_cargo = new ModeloCargo();
        ModeloCategoria modelo_categoria = new ModeloCategoria();
        ModeloNivel modelo_nivel = new ModeloNivel();
        ModeloTipoPersonal modelo_tipo = new ModeloTipoPersonal();
        UpdateAdministracion update = new UpdateAdministracion();
        DropDown drop = new DropDown();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            if (!IsPostBack)
            {
                CargarGridAll();

                mostrarCrearBrecha.Visible = false;
                mostrarCrearCargo.Visible = false;
                mostrarCrearCategoria.Visible = false;
                mostrarCrearNivel.Visible = false;
                mostrarCrearTipoPersona.Visible = false;

                mostrarEditarBrecha.Visible = false;
                mostrarEditarCargo.Visible = false;
                mostrarEditarCategoria.Visible = false;
                mostrarEditarNivel.Visible = false;
                mostrarEditTipoPersona.Visible = false;

                mostrarGridNivel.Visible = false;
            }
        }

        public void CargarGridAll()
        {
            CargarGridBrecha();
            CargarGridCargo();
            CargarGridCategoria();
            CargarGridTipoPersona();
        }

        public void CargarGridBrecha()
        {
            if (all.BrechaRead().Rows.Count != 0)
            {
                gvListBrecha.DataSource = all.BrechaRead();
                gvListBrecha.DataBind();
            }
        }

        public void CargarGridCargo()
        {
            if (all.CargoRead().Rows.Count != 0)
            {
                gvListCargo.DataSource = all.CargoRead();
                gvListCargo.DataBind();
            }
        }

        public void CargarGridCategoria()
        {
            if (all.CategoriaRead(1).Rows.Count != 0)
            {
                gvListCategoria.DataSource = all.CategoriaRead(1);
                gvListCategoria.DataBind();
            }
        }

        public void CargarGridNivel(int id)
        {
            if (all.NivelRead(id).Rows.Count != 0)
            {
                gvListNivel.DataSource = all.NivelRead(id);
                gvListNivel.DataBind();
            }
        }

        public void CargarGridTipoPersona()
        {
            if (all.TipoPersonalRead().Rows.Count != 0)
            {
                gvListTipoPersonal.DataSource = all.TipoPersonalRead();
                gvListTipoPersonal.DataBind();
            }
        }

        protected void gvListBrecha_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListBrecha.PageIndex = e.NewPageIndex;
            CargarGridBrecha();
        }

        protected void gvListCargo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListCargo.PageIndex = e.NewPageIndex;
            CargarGridCargo();
        }

        protected void gvListCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListCategoria.PageIndex = e.NewPageIndex;
            CargarGridCategoria();
        }

        protected void gvListNivel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListNivel.PageIndex = e.NewPageIndex;
            if(int.Parse(DropNivel.SelectedValue) != 0)
            {
                CargarGridNivel(int.Parse(DropNivel.SelectedValue));
            }else
            {
                CargarGridNivel(0);
            }
        }

        protected void gvListTipoPersonal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListTipoPersonal.PageIndex = e.NewPageIndex;
            CargarGridTipoPersona();
        }

        protected void nuevaBrecha_Click(object sender, EventArgs e)
        {
            txtCrearBrecha.Value = null;
            mostrarCrearBrecha.Visible = true;
        }

        protected void nuevoCargo_Click(object sender, EventArgs e)
        {
            txtCrearCargo.Value = null;
            mostrarCrearCargo.Visible = true;
        }

        protected void nuevaCategoria_Click(object sender, EventArgs e)
        {
            txtCrearCategoria.Value = null;
            mostrarCrearCategoria.Visible = true;
        }

        protected void nuevoNivel_Click(object sender, EventArgs e)
        {
            drop.Drop_Nivel(DropNivel, 0);
            txtCrearNivel.Value = null;
            mostrarCrearNivel.Visible = true;
        }

        protected void nuevoTipoPersona_Click(object sender, EventArgs e)
        {
            txtCrearTipoPersona.Value = null;
            mostrarCrearTipoPersona.Visible = true;
        }

        protected void crearBrecha_Click(object sender, EventArgs e)
        {
            if (buscar.BrechaSearch(txtCrearBrecha.Value) == false)
            {
                try
                {
                    modelo_brecha.nombre_brecha = txtCrearBrecha.Value;
                    nuevo.BrechaCreate(modelo_brecha);
                    CargarGridBrecha();
                    mostrarCrearBrecha.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La brecha fue creada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La brecha no fue creada', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La brecha ya existe', 'warning');", true);
            }
        }

        protected void crearCargo_Click(object sender, EventArgs e)
        {
            if (buscar.CargoSearch(txtCrearCargo.Value) == false)
            {
                try
                {
                    modelo_cargo.nombre_cargo = txtCrearCargo.Value;
                    nuevo.CargoCreate(modelo_cargo);
                    CargarGridCargo();
                    mostrarCrearCargo.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El cargo fue creado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El cargo no fue creado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El cargo ya existe', 'warning');", true);
            }
        }

        protected void crearCategoria_Click(object sender, EventArgs e)
        {
            if (buscar.CategoriaSearch(txtCrearCategoria.Value) == false)
            {
                try
                {
                    modelo_categoria.nombre_categoria = txtCrearCategoria.Value;
                    nuevo.CategoriaCreate(modelo_categoria);
                    CargarGridCategoria();
                    mostrarCrearCategoria.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La categoria fue creada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La categoria no fue creada', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La categoria ya existe', 'warning');", true);
            }
        }

        protected void crearNivel_Click(object sender, EventArgs e)
        {
            if (buscar.NivelSearch(txtCrearNivel.Value, int.Parse(DropNivel.SelectedValue)) == false)
            {
                try
                {
                    modelo_nivel.nombre_nivel = txtCrearNivel.Value;
                    modelo_nivel.idpadre = int.Parse(DropNivel.SelectedValue);
                    nuevo.NivelCreate(modelo_nivel);
                    CargarGridNivel(0);
                    mostrarCrearNivel.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El nivel fue creado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El nivel no fue creado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El nivel ya existe', 'warning');", true);
            }
        }

        protected void crearTipoPersona_Click(object sender, EventArgs e)
        {
            if (buscar.TipoPersonalSearch(txtCrearTipoPersona.Value) == false)
            {
                try
                {
                    modelo_tipo.nombre_tipopersonal = txtCrearTipoPersona.Value;
                    nuevo.TipoPersonalCreate(modelo_tipo);
                    CargarGridTipoPersona();
                    mostrarCrearTipoPersona.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El tipo de persona fue creado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El tipo de persona no fue creado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El tipo de persona ya existe', 'warning');", true);
            }
        }

        protected void gvListBrecha_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;

            if(e.CommandName == "Editar")
            {
                index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvListBrecha.Rows[index];

                DataTable data = new DataTable();
                data = buscar.BrechaInformacionSearch(row.Cells[0].Text);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idBrecha.Text = data.Rows[i][0].ToString();
                    txtEditBrecha.Value = data.Rows[i][1].ToString();
                }

                idBrecha.Visible = false;
                mostrarEditarBrecha.Visible = true;
            }
        }

        protected void gvListCargo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;

            if (e.CommandName == "Editar")
            {
                index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvListCargo.Rows[index];

                DataTable data = new DataTable();
                data = buscar.CargoInformacionSearch(row.Cells[0].Text);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idCargo.Text = data.Rows[i][0].ToString();
                    txtEditCargo.Value = data.Rows[i][1].ToString();
                }

                idCargo.Visible = false;
                mostrarEditarCargo.Visible = true;
            }
        }

        protected void gvListCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;

            if (e.CommandName == "Editar")
            {
                index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvListCategoria.Rows[index];

                DataTable data = new DataTable();
                data = buscar.CategoriaInformacionSearch(row.Cells[0].Text);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idCategoria.Text = data.Rows[i][0].ToString();
                    txtEditCategoria.Value = data.Rows[i][1].ToString();
                }

                idCategoria.Visible = false;
                mostrarEditarCategoria.Visible = true;
            }
        }

        protected void gvListNivel_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;

            if (e.CommandName == "Editar")
            {
                index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvListNivel.Rows[index];

                DataTable data = new DataTable();
                data = buscar.NivelInformacionSearch(row.Cells[0].Text);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idNivel.Text = data.Rows[i][0].ToString();
                    txtEditNivel.Value = data.Rows[i][1].ToString();
                }

                drop.Drop_Nivel(DropNivelEdit, 0);
                idNivel.Visible = false;
                mostrarEditarNivel.Visible = true;
            }
        }

        protected void gvListTipoPersonal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;

            if (e.CommandName == "Editar")
            {
                index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvListTipoPersonal.Rows[index];

                DataTable data = new DataTable();
                data = buscar.TipoPersonaInformacionSearch(row.Cells[0].Text);

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idTipoPersona.Text = data.Rows[i][0].ToString();
                    txtEditTipoPersona.Value = data.Rows[i][1].ToString();
                }

                idTipoPersona.Visible = false;
                mostrarEditTipoPersona.Visible = true;
            }
        }

        protected void editBrecha_Click(object sender, EventArgs e)
        {
            if (buscar.BrechaSearch(txtEditBrecha.Value) == false)
            {
                try
                {
                    modelo_brecha.nombre_brecha = txtEditBrecha.Value;
                    update.UpdateBrecha(modelo_brecha, int.Parse(idBrecha.Text));
                    CargarGridBrecha();
                    mostrarEditarBrecha.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La brecha fue modificada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La brecha no fue modificada', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La brecha ya existe', 'warning');", true);
            }
        }

        protected void editCargo_Click(object sender, EventArgs e)
        {
            if (buscar.CargoSearch(txtEditCargo.Value) == false)
            {
                try
                {
                    modelo_cargo.nombre_cargo = txtEditCargo.Value;
                    update.UpdateCargo(modelo_cargo, int.Parse(idCargo.Text));
                    CargarGridCargo();
                    mostrarEditarCargo.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El cargo fue modificado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El cargo no fue modificado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El cargo ya existe', 'warning');", true);
            }
        }

        protected void editCategoria_Click(object sender, EventArgs e)
        {
            if (buscar.CategoriaSearch(txtEditCategoria.Value) == false)
            {
                try
                {
                    modelo_categoria.nombre_categoria = txtEditCategoria.Value;
                    update.UpdateCategoria(modelo_categoria, int.Parse(idCategoria.Text));
                    CargarGridCategoria();
                    mostrarEditarCategoria.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La categoria fue modificada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La categoria no fue modificada', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La categoria ya existe', 'warning');", true);
            }
        }

        protected void editNivel_Click(object sender, EventArgs e)
        {
            if (buscar.NivelSearch(txtEditNivel.Value, int.Parse(DropNivelEdit.SelectedValue)) == false)
            {
                try
                {
                    modelo_nivel.nombre_nivel = txtEditNivel.Value;
                    modelo_nivel.idpadre = int.Parse(DropNivelEdit.SelectedValue);
                    update.UpdateNivel(modelo_nivel, int.Parse(idNivel.Text));
                    CargarGridNivel(int.Parse(DropNivelEdit.SelectedValue));
                    mostrarEditarNivel.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El nivel fue modificado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El nivel no fue modificado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El nivel ya existe', 'warning');", true);
            }
        }

        protected void editTipoPersona_Click(object sender, EventArgs e)
        {
            if (buscar.TipoPersonalSearch(txtEditTipoPersona.Value) == false)
            {
                try
                {
                    modelo_tipo.nombre_tipopersonal = txtEditTipoPersona.Value;
                    update.UpdateTipoPersona(modelo_tipo, int.Parse(idTipoPersona.Text));
                    CargarGridTipoPersona();
                    mostrarEditTipoPersona.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El tipo de persona fue modificado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El tipo de persona no fue modificado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El tipo de persona ya existe', 'warning');", true);
            }
        }

        protected void DropNivelEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridNivel(int.Parse(DropNivelEdit.SelectedValue));
            mostrarGridNivel.Visible = true;
            mostrarGridNivel.Attributes.Add("class", "col-md-6");
        }

        protected void DropNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGridNivel(int.Parse(DropNivel.SelectedValue));
            mostrarGridNivel.Visible = true;
            mostrarGridNivel.Attributes.Add("class", "col-md-6");
        }

        protected void cancelCrearBrecha_Click(object sender, EventArgs e)
        {
            mostrarCrearBrecha.Visible = false;
        }

        protected void cancelCrearCargo_Click(object sender, EventArgs e)
        {
            mostrarCrearCargo.Visible = false;
        }

        protected void cancelCrearCategoria_Click(object sender, EventArgs e)
        {
            mostrarCrearCategoria.Visible = false;
        }

        protected void cancelCrearNivel_Click(object sender, EventArgs e)
        {
            mostrarCrearNivel.Visible = false;
        }

        protected void cancelCrearTipoPersona_Click(object sender, EventArgs e)
        {
            mostrarCrearTipoPersona.Visible = false;
        }

        protected void cancelEditBrecha_Click(object sender, EventArgs e)
        {
            mostrarEditarBrecha.Visible = false;
        }

        protected void cancelEditCargo_Click(object sender, EventArgs e)
        {
            mostrarEditarCargo.Visible = false;
        }

        protected void cancelEditCategoria_Click(object sender, EventArgs e)
        {
            mostrarEditarCategoria.Visible = false;
        }

        protected void cancelEditNivel_Click(object sender, EventArgs e)
        {
            mostrarEditarNivel.Visible = false;
        }

        protected void cancelEditTipoPersona_Click(object sender, EventArgs e)
        {
            mostrarEditTipoPersona.Visible = false;
        }
    }
}