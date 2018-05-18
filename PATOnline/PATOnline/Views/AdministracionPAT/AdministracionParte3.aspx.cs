using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Read;
using PATOnline.Controller.Search;
using PATOnline.Models;

namespace PATOnline.Views.AdministracionPAT
{
    public partial class AdministracionParte3 : System.Web.UI.Page
    {
        public string federacion;
        DropDown drop = new DropDown();
        ReadFormatoC read = new ReadFormatoC();
        ReadAdministracionPAT read_categoria = new ReadAdministracionPAT();
        ReadActividadPAT read_actividad = new ReadActividadPAT();
        CreateFormatoC nuevo = new CreateFormatoC();
        CreateAdministracionPAT nueva_categoria = new CreateAdministracionPAT();
        CreateActividadPAT nueva_actividad = new CreateActividadPAT();
        SearchFormatoC verficar = new SearchFormatoC();
        SearchAdministracionPAT verficar_categoria = new SearchAdministracionPAT();
        SearchActividadPAT verificar_actidiad = new SearchActividadPAT();
        SearchFederacion buscar = new SearchFederacion();
        ModeloFormatoC modelo = new ModeloFormatoC();
        ModeloCategoria modelo_categoria = new ModeloCategoria();
        ModeloActividadPAT modelo_actividad = new ModeloActividadPAT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                lblFomartoC.Text = "CREAR NUEVO FORMATO C";
                lblCategoria.Text = "CREAR NUEVA CATEGORÍA";
                lblActividad.Text = "CREAR NUEVA ACTIVIDAD";
                CargarGrid1(0);
                CargarGrid2(0);
                CargarGrid3(0);
                drop.Drop_FormatoC(DropIDPadreFormatoC, 0);
                drop.Drop_CategoriaFormato(DropIDPadreCategoria, 0);
                drop.Drop_ActividadPAT(DropActividad, 0);
            }
        }

        public void CargarGrid1(int id)
        {
            if (read.FormatoCRead(id, "idpadre").Rows.Count != 0)
            {
                gvFormatoTitulo.DataSource = read.FormatoCRead(id, "idpadre");
                gvFormatoTitulo.DataBind();
            }
        }

        public void CargarGrid2(int id)
        {
            if (read_categoria.CategoriaFormatoRead(id).Rows.Count != 0)
            {
                gvCategoriaTitulo.DataSource = read_categoria.CategoriaFormatoRead(id);
                gvCategoriaTitulo.DataBind();
            }
        }

        public void CargarGrid3(int id)
        {
            if (read_actividad.ActividadPATRead(id).Rows.Count != 0)
            {
                gvActividadTitulo.DataSource = read_actividad.ActividadPATRead(id);
                gvActividadTitulo.DataBind();
            }
        }

        protected void SaveFormato_Click(object sender, EventArgs e)
        {
            if (verficar.ExisteFormatoCPAT(TxtFormatoC.Value) == true)
            {
                Response.Write("<script>window.alert('El Nombre Ya Existe','Crear Nuevo Formato C')" +
                ";</script>" + "<script>window.setTimeout(location.href='AdministracionParte3.aspx', 1);</script>");
            }
            else
            {
                modelo.nombre = TxtFormatoC.Value;
                modelo.idpadre = int.Parse(DropIDPadreFormatoC.SelectedValue);
                nuevo.FormatoCCreate(modelo);
                TxtFormatoC.Value = null;
                CargarGrid1(0);
            }
        }

        protected void gvFormatoTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvFormatoTitulo.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvFormatoBody = e.Row.FindControl("gvFormatoBody") as GridView;
                gvFormatoBody.DataSource = read.FormatoCRead(int.Parse(customerId), "idpadre");
                gvFormatoBody.DataBind();
            }
        }

        protected void SaveCategoria_Click(object sender, EventArgs e)
        {
            if (verficar_categoria.CategoriaFormatoSearch(TxtCategoria.Value, int.Parse(DropIDPadreCategoria.SelectedValue)) == true)
            {
                Response.Write("<script>window.alert('El Registro Ya Existe','Crear Nueva Categoria')" +
                ";</script>" + "<script>window.setTimeout(location.href='AdministracionParte3.aspx', 1);</script>");
            }
            else
            {
                modelo_categoria.nombre_categoria = TxtCategoria.Value;
                modelo_categoria.idpadre = int.Parse(DropIDPadreCategoria.SelectedValue);
                nueva_categoria.CategoriaFormatoCreate(modelo_categoria);
                TxtCategoria.Value = null;
                CargarGrid2(0);
            }
        }

        protected void gvCategoriaTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvCategoriaTitulo.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvCategoriaBody = e.Row.FindControl("gvCategoriaBody") as GridView;
                gvCategoriaBody.DataSource = read_categoria.CategoriaFormatoRead(int.Parse(customerId));
                gvCategoriaBody.DataBind();
            }
        }

        protected void SaveActividad_Click(object sender, EventArgs e)
        {
            if (verificar_actidiad.ExisteActividadPAT(int.Parse(DropActividad.SelectedValue), TxtFormatoC.Value) == true)
            {
                Response.Write("<script>window.alert('El Registro Ya Existe','Crear Nueva Actividad')" +
                ";</script>" + "<script>window.setTimeout(location.href='AdministracionParte3.aspx', 1);</script>");
            }
            else
            {
                modelo_actividad.nombre = TxtActividad.Value;
                modelo_actividad.idpadre = int.Parse(DropActividad.SelectedValue);
                nueva_actividad.ActividadPATCreate(modelo_actividad);
                TxtActividad.Value = null;
                CargarGrid3(0);
            }
        }

        protected void gvActividadTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvActividadTitulo.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvActividadBody = e.Row.FindControl("gvActividadBody") as GridView;
                gvActividadBody.DataSource = read_actividad.ActividadPATRead(int.Parse(customerId));
                gvActividadBody.DataBind();
            }
        }
    }
}