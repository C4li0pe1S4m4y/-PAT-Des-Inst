using System;
using System.Data;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Controller.Read;
using PATOnline.Controller.Delete;
using PATOnline.Models;
using System.Web.UI;

namespace PATOnline.Views.RolPermiso
{
    public partial class RolPermiso : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        ModeloRolPermiso modelo = new ModeloRolPermiso();
        ModeloRol modelo_rol = new ModeloRol();
        CreatRolPermiso nuevo = new CreatRolPermiso();
        CreateRol nuevo_rol = new CreateRol();
        SearchPermisoRol buscar = new SearchPermisoRol();
        SearchRol buscar_rol = new SearchRol();
        ReadMenu leer_menu = new ReadMenu();
        ReadBoton leer_boton = new ReadBoton();
        DeleteBotonAccion boton_viejo = new DeleteBotonAccion();
        ReadRolPermiso all = new ReadRolPermiso();
        ReadRol rol = new ReadRol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
                mostrarCrearRol.Visible = false;
                mostrarEditarRol.Visible = false;
                mostrarCrearPermiso.Visible = false;
                mostrarEditarPermiso.Visible = false;
                mostrarEliminarPermisoRol.Visible = false;
                CargarGrid();
            }
        }

        protected void CargarGrid()
        {
            if (rol.RolRead().Rows.Count != 0)
            {
                gvListadoInfo.DataSource = rol.RolRead();
                gvListadoInfo.DataBind();
            }
        }

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void gvListadoInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvListadoInfo.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvListSub = e.Row.FindControl("gvListSub") as GridView;
                gvListSub.DataSource = all.MenuPermisoRead(int.Parse(customerId));
                gvListSub.DataBind();

                gvListSub.Columns[0].Visible = false;
            }
        }

        public string texto;
        protected void gvListSub_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = true;
                if (Server.HtmlDecode(e.Row.Cells[0].Text) != texto)
                {
                    GridView gvListSubSub = e.Row.FindControl("gvListSubSub") as GridView;
                    gvListSubSub.DataSource = all.BotonPermisoRead(int.Parse(e.Row.Cells[0].Text));
                    gvListSubSub.DataBind();
                }
                else
                {
                    e.Row.Cells[0].Enabled = false;
                    e.Row.Cells[0].Visible = false;
                }

                texto = Server.HtmlDecode(e.Row.Cells[0].Text);
                e.Row.Cells[0].Visible = false;
            }

        }

        protected void nuevoRol_Click(object sender, EventArgs e)
        {
            mostrarCrearRol.Visible = true;
        }

        protected void nuevoPermiso_Click(object sender, EventArgs e)
        {
            mostrarCrearPermiso.Visible = true;
            drop.Drop_Rol(DropRol);
            BotonOpcion();
        }

        protected void DropRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pintar_Check(int.Parse(DropRol.SelectedValue));
        }

        public void Pintar_Check(int id_rol)
        {
            DataTable MenuActivar = new DataTable();
            MenuActivar = buscar.ExisteMenuenPermisoSearch(id_rol);

            foreach (ListItem item in checkboxOneInput.Items)
            {
                for (int i = 0; i < MenuActivar.Rows.Count; i++)
                {
                    if (item.Text == MenuActivar.Rows[i][0].ToString())
                    {
                        item.Enabled = false;
                    }
                }
            }
        }

        public void PintarBoton_Check(int id_rol, int id_menu)
        {
            DataTable BotonActivar = new DataTable();
            BotonActivar = buscar.ExisteBotonenPermisoSearch(id_rol, id_menu);

            foreach (ListItem item in checkboxEditarPermisoBoton.Items)
            {
                for (int i = 0; i < BotonActivar.Rows.Count; i++)
                {
                    if (item.Text == BotonActivar.Rows[i][0].ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        public void BotonOpcion()
        {
            checkboxOneInput.DataSource = leer_menu.MenuRead();
            checkboxOneInput.DataBind();

            checkboxTwoInput.DataSource = leer_boton.BotonRead();
            checkboxTwoInput.DataBind();
        }

        protected void cerrarRol_Click(object sender, EventArgs e)
        {
            mostrarCrearRol.Visible = false;
            TxtRol.Value = null;
        }

        protected void cerrarPermiso_Click(object sender, EventArgs e)
        {
            mostrarCrearPermiso.Visible = false;
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (buscar_rol.ExisteRol(TxtRol.Value) == false)
            {
                modelo_rol.nombre = TxtRol.Value;
                try
                {
                    nuevo_rol.RolCreate(modelo_rol);
                    mostrarCrearRol.Visible = false;
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El Rol fue creado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Rol no fue creado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Ya existe un Rol con este nombre', 'warning');", true);
            }
        }

        protected void savePermiso_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem MList in checkboxOneInput.Items)
                {
                    foreach (ListItem BtnList in checkboxTwoInput.Items)
                    {
                        if (MList.Selected == true)
                        {
                            if (BtnList.Selected == true)
                            {
                                if (buscar.RolPermisoExiste(int.Parse(DropRol.SelectedValue), int.Parse(MList.Value), int.Parse(BtnList.Value)) != true)
                                {
                                    modelo.idrol = int.Parse(DropRol.SelectedValue);
                                    modelo.idmenu = int.Parse(MList.Value);
                                    modelo.idboton = int.Parse(BtnList.Value);
                                    nuevo.RolPermisoCreate(modelo);
                                }
                            }
                        }
                    }
                }

                mostrarCrearPermiso.Visible = false;
                CargarGrid();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El Permiso fue creado', 'success');", true);
                this.Session["Menu"] = null;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Permiso no fue creado', 'error');", true);
            }
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            drop.Drop_Rol(DropEditarPermisoRol);
            drop.Drop_Menu(DropEditarPermisoMenu);
            checkboxEditarPermisoBoton.DataSource = leer_boton.BotonRead();
            checkboxEditarPermisoBoton.DataBind();
            mostrarEditarPermiso.Visible = true;
        }

        protected void editRol_Click(object sender, EventArgs e)
        {
            try
            {
                modelo_rol.nombre = TxtmodificarRol.Value;
                nuevo_rol.RolCreate(modelo_rol);
                TxtmodificarRol.Value = null;
                mostrarEditarRol.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El Rol fue modificado', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Rol no fue modificado', 'error');", true);
            }
        }

        protected void editarPermiso_Click(object sender, EventArgs e)
        {
            foreach (ListItem BtnList in checkboxEditarPermisoBoton.Items)
            {
                try
                {
                    if (buscar.RolPermisoExiste(int.Parse(DropEditarPermisoRol.SelectedValue), int.Parse(DropEditarPermisoMenu.SelectedValue), int.Parse(BtnList.Value)) != true)
                    {
                        if (BtnList.Selected == true)
                        {
                            modelo.idrol = int.Parse(DropEditarPermisoRol.SelectedValue);
                            modelo.idmenu = int.Parse(DropEditarPermisoMenu.SelectedValue);
                            modelo.idboton = int.Parse(BtnList.Value);
                            nuevo.RolPermisoCreate(modelo);
                        }
                    }
                    if (buscar.RolPermisoExiste(int.Parse(DropEditarPermisoRol.SelectedValue), int.Parse(DropEditarPermisoMenu.SelectedValue), int.Parse(BtnList.Value)) == true)
                    {
                        if (BtnList.Selected == false)
                        {
                            boton_viejo.MenuAccionDelete(int.Parse(BtnList.Value), int.Parse(DropEditarPermisoMenu.SelectedValue), int.Parse(DropEditarPermisoRol.SelectedValue));
                        }
                    }
                    CargarGrid();
                    mostrarEditarPermiso.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El Permiso fue modificado', 'success');", true);
                    this.Session["Menu"] = null;
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Permiso no fue modificado', 'error');", true);
                }
            }
        }

        protected void DropEditarPermisoRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(DropEditarPermisoMenu.SelectedValue) > 0)
            {
                PintarBoton_Check(int.Parse(DropEditarPermisoRol.SelectedValue), int.Parse(DropEditarPermisoMenu.SelectedValue));
            }
        }

        protected void DropEditarPermisoMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(DropEditarPermisoRol.SelectedValue) > 0)
            {
                PintarBoton_Check(int.Parse(DropEditarPermisoRol.SelectedValue), int.Parse(DropEditarPermisoMenu.SelectedValue));
            }
        }

        protected void cancelCrearRol_Click(object sender, EventArgs e)
        {
            mostrarCrearRol.Visible = false;
        }

        protected void cancelEditRol_Click(object sender, EventArgs e)
        {
            mostrarEditarRol.Visible = false;
        }

        protected void cancelCrearPermiso_Click(object sender, EventArgs e)
        {
            mostrarCrearPermiso.Visible = false;
        }

        protected void cancelEditPermiso_Click(object sender, EventArgs e)
        {
            mostrarEditarPermiso.Visible = false;
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {
            drop.Drop_Rol(DropEliminarPermisoRol);
            drop.Drop_Menu(DropEliminarPermisoMenu);
            mostrarEliminarPermisoRol.Visible = true;
        }

        protected void cancelarEliminarPermisoRol_Click(object sender, EventArgs e)
        {
            mostrarEliminarPermisoRol.Visible = false;
        }

        protected void eliminarPermisoRol_Click(object sender, EventArgs e)
        {
            try
            {
                nuevo_rol.PermisoRolDelete(int.Parse(DropEliminarPermisoRol.SelectedValue), int.Parse(DropEliminarPermisoMenu.SelectedValue));
                CargarGrid();
                mostrarEliminarPermisoRol.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El Permiso fue eliminado', 'success');", true);
                this.Session["Menu"] = null;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Permiso no fue eliminado', 'error');", true);
            }
        }
    }
}