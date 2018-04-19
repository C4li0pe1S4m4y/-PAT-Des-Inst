using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Controller.Read;
using PATOnline.Models;

namespace PATOnline.Views.RolPermiso
{
    public partial class CreateRolPermiso : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        ModeloRolPermiso modelo = new ModeloRolPermiso();
        ModeloRol modelo_rol = new ModeloRol();
        ModeloMenu modelo_menu = new ModeloMenu();
        ModeloBoton modelo_boton = new ModeloBoton();
        CreatRolPermiso nuevo = new CreatRolPermiso();
        CreateRol nuevo_rol = new CreateRol();
        CreateMenu nuevo_menu = new CreateMenu();
        CreateBoton nuevo_boton = new CreateBoton();
        SearchPermisoRol buscar = new SearchPermisoRol();
        SearchRol buscar_rol = new SearchRol();
        SearchMenu buscar_menu = new SearchMenu();
        SearchBoton buscar_boton = new SearchBoton();
        ReadRol leer_rol = new ReadRol();
        ReadMenu leer_menu = new ReadMenu();
        ReadBoton leer_boton = new ReadBoton();
        public string Modal = "CREAR PERMISO";

        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                    drop.Drop_Rol(DropRol);
                    drop.Drop_Menu(DropMenu);
                    drop.Drop_Boton(DropBoton);

                    lblModal.Text = Modal;
                    lblModal2.Text = "CREAR ROL";
                    lblModal4.Text = "CREAR MÉNU";
                    lblModal3.Text = "CREAR ACCIÓN";

                    GridRol();
                    GridMenu();
                    GridBoton();
                }
            
        }

        public void Preguntar(int id1, int id2)
        {
            try
            {
                if(buscar.RolPermisoSearch(id1, id2).Rows.Count != 0)
                {
                    gvListPermiso.DataSource = buscar.RolPermisoSearch(id1, id2);
                    gvListPermiso.DataBind();
                }
                else
                {
                    gvListPermiso.Attributes.Clear();
                }
            }
            catch
            {

            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int id_rol = int.Parse(DropRol.SelectedValue);
            int id_menu = int.Parse(DropMenu.SelectedValue);
            int id_boton = int.Parse(DropBoton.SelectedValue);

            modelo.idrol = int.Parse(DropRol.SelectedValue);
            modelo.idmenu = int.Parse(DropMenu.SelectedValue);
            modelo.idboton = int.Parse(DropBoton.SelectedValue);

            if (buscar.RolPermisoExiste(id_rol, id_menu, id_boton) == true)
            {
                Response.Write("<script>window.alert('Ya existe un registro de este tipo','Permiso Ya Existe')" +
                ";</script>" + "<script>window.setTimeout(location.href='CreateRolPermiso.aspx', 1);</script>");
            }
            else
            {
                try
                {
                    nuevo.RolPermisoCreate(modelo);
                    Preguntar(id_rol, id_menu);
                }
                catch
                {
                    Response.Write("<script>window.alert('Error al Crear el Permiso','Crear Nuevo Permiso')" +
                    ";</script>" + "<script>window.setTimeout(location.href='RolPermiso.aspx', 1);</script>");
                }
            }
        }

        protected void gvListadoInfo_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListPermiso.Rows[index];
            }
        }

        protected void limpiar()
        {
            DropRol.Items.Clear();
            DropMenu.Items.Clear();
            DropBoton.Items.Clear();
        }

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int id_rol = int.Parse(DropRol.SelectedValue.ToString());
            int id_menu = int.Parse(DropMenu.SelectedValue.ToString());

            gvListPermiso.PageIndex = e.NewPageIndex;
            Preguntar(id_rol, id_menu);
        }

        protected void DropRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_rol = int.Parse(DropRol.SelectedValue.ToString());
            int id_menu = int.Parse(DropMenu.SelectedValue.ToString());
            if(id_menu != 0)
            {
                Preguntar(id_rol, id_menu);
            }
        }

        protected void DropMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_rol = int.Parse(DropRol.SelectedValue.ToString());
            int id_menu = int.Parse(DropMenu.SelectedValue.ToString());

            Preguntar(id_rol, id_menu);
        }

        public void GridRol()
        {
            if(leer_rol.RolRead().Rows.Count != 0)
            {
                gvListRol.DataSource = leer_rol.RolRead();
                gvListRol.DataBind();
            }
        }

        protected void SaveRol_Click(object sender, EventArgs e)
        {
            if (TxtRol.Text != "")
            {
                modelo_rol.nombre = TxtRol.Text;
                if (buscar_rol.ExisteRol(TxtRol.Text) == true)
                {
                }
                else
                {
                    try
                    {
                        nuevo_rol.RolCreate(modelo_rol);
                        GridRol();
                        drop.Drop_Rol(DropRol);
                    }
                    catch
                    {
                        Response.Write("<script>window.alert('Error al Crear el Rol','Crear Nuevo Rol')" +
                        ";</script>" + "<script>window.setTimeout(location.href='RolPermiso.aspx', 1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>window.alert('Por Favor Ingrese el nombre del Rol','ADVERTENCIA')" +
                ";</script>");
            }
        }

        protected void gvListRol_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListRol.PageIndex = e.NewPageIndex;
            GridRol();
        }

        public void GridMenu()
        {
            if(leer_menu.MenuRead().Rows.Count != 0)
            {
                gvListMenu.DataSource = leer_menu.MenuRead();
                gvListMenu.DataBind();
            }
        }

        protected void SaveMenu_Click(object sender, EventArgs e)
        {
            if (TxtMenu.Text != "")
            {
                modelo_menu.nombre = TxtMenu.Text;
                if (buscar_menu.ExisteMenu(TxtMenu.Text) == true)
                {
                }
                else
                {
                    try
                    {
                        nuevo_menu.MenuCreate(modelo_menu);
                        GridMenu();
                        drop.Drop_Menu(DropMenu);
                    }
                    catch
                    {
                        Response.Write("<script>window.alert('Error al Crear el Menu','Crear Nuevo Menu')" +
                        ";</script>" + "<script>window.setTimeout(location.href='RolPermiso.aspx', 1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>window.alert('Por Favor Ingrese el nombre del Menu','ADVERTENCIA')" +
                ";</script>");
            }
        }
        protected void gvListMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListMenu.PageIndex = e.NewPageIndex;
            GridMenu();
        }

        public void GridBoton()
        {
            if(leer_boton.BotonRead().Rows.Count != 0)
            {
                gvListBoton.DataSource = leer_boton.BotonRead();
                gvListBoton.DataBind();
            }
        }

        protected void SaveBoton_Click(object sender, EventArgs e)
        {
            if (TxtBoton.Text != "")
            {
                modelo_boton.nombre = TxtBoton.Text;
                if (buscar_menu.ExisteMenu(TxtBoton.Text) == true)
                {
                }
                else
                {
                    try
                    {
                        nuevo_boton.BotonCreate(modelo_boton);
                        GridBoton();
                        drop.Drop_Boton(DropBoton);
                    }
                    catch
                    {
                        Response.Write("<script>window.alert('Error al Crear el Boton','Crear Nuevo Boton')" +
                        ";</script>" + "<script>window.setTimeout(location.href='RolPermiso.aspx', 1);</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script>window.alert('Por Favor Ingrese el nombre del Boton','ADVERTENCIA')" +
                ";</script>");
            }
        }

        protected void gvListBoton_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListBoton.PageIndex = e.NewPageIndex;
            GridBoton();
        }
    }
}