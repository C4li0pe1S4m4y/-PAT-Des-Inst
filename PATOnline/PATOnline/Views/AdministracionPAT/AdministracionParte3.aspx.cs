using System;
using System.Linq;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.ClasesBD;
using PATOnline.Models;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.AdministracionPAT
{
    public partial class AdministracionParte3 : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        AdministracionPATFormato3 admin = new AdministracionPATFormato3();
        ModeloFormatoC modelo = new ModeloFormatoC();
        ModeloCategoria modelo_categoria = new ModeloCategoria();
        ModeloActividadPAT modelo_actividad = new ModeloActividadPAT();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                mostrarCrearFormatoC.Visible = false;
                mostrarCrearCategoria.Visible = false;
                mostrarCrearActividad.Visible = false;

                idFormatoC.Visible = false;
                idCategoria.Visible = false;
                idActividad.Visible = false;

                mostrarEditFormatoC.Visible = false;
                mostrarEditCategoria.Visible = false;
                mostrarEditActividad.Visible = false;

                CargarGrid1(0, "idpadre");
                CargarGrid2(0);
                CargarGrid3(0);
            }
        }

        public void CargarGrid1(int id, string palabra)
        {
            if (admin.FormatoCRead(id, palabra).Rows.Count != 0)
            {
                gvFormatoTitulo.Columns[0].Visible = true;
                gvFormatoTitulo.DataSource = admin.FormatoCRead(id, palabra);
                gvFormatoTitulo.DataBind();
                gvFormatoTitulo.Columns[0].Visible = false;
            }
        }

        public void CargarGrid2(int id)
        {
            if (admin.CategoriaFormatoRead(id).Rows.Count != 0)
            {
                gvCategoriaTitulo.Columns[0].Visible = true;
                gvCategoriaTitulo.DataSource = admin.CategoriaFormatoRead(id);
                gvCategoriaTitulo.DataBind();
                gvCategoriaTitulo.Columns[0].Visible = false;
            }
        }

        public void CargarGrid3(int id)
        {
            if (admin.ActividadPATRead(id).Rows.Count != 0)
            {
                gvActividadTitulo.Columns[0].Visible = true;
                gvActividadTitulo.DataSource = admin.ActividadPATRead(id);
                gvActividadTitulo.DataBind();
                gvActividadTitulo.Columns[0].Visible = false;
            }
        }

        protected void gvFormatoTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvFormatoTitulo.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvFormatoBody = e.Row.FindControl("gvFormatoBody") as GridView;
                gvFormatoBody.DataSource = admin.FormatoCRead(int.Parse(customerId), "idpadre");
                gvFormatoBody.DataBind();
            }
        }

        protected void gvCategoriaTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvCategoriaTitulo.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvCategoriaBody = e.Row.FindControl("gvCategoriaBody") as GridView;
                gvCategoriaBody.Columns[0].Visible = true;
                gvCategoriaBody.DataSource = admin.CategoriaFormatoRead(int.Parse(customerId));
                gvCategoriaBody.DataBind();
                gvCategoriaBody.Columns[0].Visible = false;
            }
        }

        protected void gvActividadTitulo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvActividadTitulo.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvActividadBody = e.Row.FindControl("gvActividadBody") as GridView;
                gvActividadBody.Columns[0].Visible = true;
                gvActividadBody.DataSource = admin.ActividadPATRead(int.Parse(customerId));
                gvActividadBody.DataBind();
                gvActividadBody.Columns[0].Visible = false;
            }
        }

        protected void nuevoFormatoC_Click(object sender, EventArgs e)
        {
            drop.Drop_FormatoC(DropIDPadreFormatoC, 0);
            mostrarCrearFormatoC.Visible = true;
        }

        protected void nuevaCategoria_Click(object sender, EventArgs e)
        {
            drop.Drop_CategoriaFormato(DropIDPadreCategoria, 0);
            mostrarCrearCategoria.Visible = true;
        }

        protected void nuevaActividad_Click(object sender, EventArgs e)
        {
            drop.Drop_ActividadPAT(DropActividad, 0);
            mostrarCrearActividad.Visible = true;
        }

        protected void cancelCrearFormatoC_Click(object sender, EventArgs e)
        {
            mostrarCrearFormatoC.Visible = false;
        }

        protected void crearFormatoC_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin.ExisteFormatoCPAT(TxtFormatoC.Value) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    modelo.nombre = TxtFormatoC.Value;
                    modelo.idpadre = int.Parse(DropIDPadreFormatoC.SelectedValue);
                    admin.FormatoCCreate(modelo);
                    TxtFormatoC.Value = null;
                    CargarGrid1(0, "idpadre");
                    mostrarCrearFormatoC.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue creada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue creada', 'error');", true);
            }
        }

        protected void cancelCrearCategoria_Click(object sender, EventArgs e)
        {
            mostrarCrearCategoria.Visible = false;
        }

        protected void crearCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin.CategoriaFormatoSearch(TxtCategoria.Value, int.Parse(DropIDPadreCategoria.SelectedValue)) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    modelo_categoria.nombre_categoria = TxtCategoria.Value;
                    modelo_categoria.idpadre = int.Parse(DropIDPadreCategoria.SelectedValue);
                    admin.CategoriaFormatoCreate(modelo_categoria);
                    TxtCategoria.Value = null;
                    CargarGrid2(0);
                    mostrarCrearCategoria.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue creada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue creada', 'error');", true);
            }
        }

        protected void cancelCrearActividad_Click(object sender, EventArgs e)
        {
            mostrarCrearActividad.Visible = false;
        }

        protected void crearActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin.ExisteActividadPAT(int.Parse(DropActividad.SelectedValue), TxtFormatoC.Value) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    modelo_actividad.nombre = TxtActividad.Value;
                    modelo_actividad.idpadre = int.Parse(DropActividad.SelectedValue);
                    admin.ActividadPATCreate(modelo_actividad);
                    TxtActividad.Value = null;
                    CargarGrid3(0);
                    mostrarCrearActividad.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue creada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue creada', 'error');", true);
            }
        }

        protected void cancelEditFormatoC_Click(object sender, EventArgs e)
        {
            mostrarEditFormatoC.Visible = false;
        }

        protected void editFormatoC_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin.ExisteFormatoCPAT(TxtEditFormatoC.Value) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    modelo.nombre = TxtEditFormatoC.Value;
                    modelo.idpadre = int.Parse(DropEditPadreFormatoC.SelectedValue);
                    admin.FormatoCUpdate(modelo, int.Parse(idFormatoC.Text));
                    TxtEditFormatoC.Value = null;
                    CargarGrid1(0, "idpadre");
                    mostrarEditFormatoC.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelEditCategoria_Click(object sender, EventArgs e)
        {
            mostrarEditCategoria.Visible = false;
        }

        protected void editCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin.CategoriaFormatoSearch(TxtEditCategoria.Value, int.Parse(DropIDPadreCategoria.SelectedValue)) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    modelo_categoria.nombre_categoria = TxtEditCategoria.Value;
                    modelo_categoria.idpadre = int.Parse(DropEditPadreCategoria.SelectedValue);
                    admin.CategoriaUpdate(modelo_categoria, int.Parse(idCategoria.Text));
                    TxtEditCategoria.Value = null;
                    CargarGrid2(0);
                    mostrarEditCategoria.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void cancelEditActividad_Click(object sender, EventArgs e)
        {
            mostrarEditActividad.Visible = false;
        }

        protected void editActividad_Click(object sender, EventArgs e)
        {
            try
            {
                if (admin.ExisteActividadPAT(int.Parse(DropEditActividad.SelectedValue), TxtEditActividad.Value) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    modelo_actividad.nombre = TxtEditActividad.Value;
                    modelo_actividad.idpadre = int.Parse(DropEditActividad.SelectedValue);
                    admin.ActividadUpdate(modelo_actividad, int.Parse(idActividad.Text));
                    TxtEditActividad.Value = null;
                    CargarGrid3(0);
                    mostrarEditActividad.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue creada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue creada', 'error');", true);
            }
        }

        protected void gvFormatoBody_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            if(e.CommandName == "Editar")
            {
                drop.Drop_FormatoC(DropEditPadreFormatoC, 0);

                foreach (GridViewRow rowtitulo in gvFormatoTitulo.Rows)
                {
                    if (rowtitulo.RowType == DataControlRowType.DataRow)
                    {
                        GridViewRow row = (rowtitulo.FindControl("gvFormatoBody") as GridView).Rows[index];

                        DataTable data = new DataTable();
                        data = admin.FormatoCSeleccionado(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idFormatoC.Text = data.Rows[i][0].ToString();
                            TxtEditFormatoC.Value = data.Rows[i][1].ToString();
                            DropEditPadreFormatoC.SelectedValue = data.Rows[i][2].ToString();
                        }
                    }
                }
                mostrarEditFormatoC.Visible = true;
            }
        }

        protected void gvCategoriaBody_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Editar")
            {
                drop.Drop_CategoriaFormato(DropEditPadreCategoria, 0);

                foreach (GridViewRow rowtitulo in gvCategoriaTitulo.Rows)
                {
                    if (rowtitulo.RowType == DataControlRowType.DataRow)
                    {
                        GridViewRow row = (rowtitulo.FindControl("gvCategoriaBody") as GridView).Rows[index];

                        DataTable data = new DataTable();
                        data = admin.CategoriaSeleccionada(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idCategoria.Text = data.Rows[i][0].ToString();
                            TxtEditCategoria.Value = data.Rows[i][1].ToString();
                            DropEditPadreCategoria.SelectedValue = data.Rows[i][2].ToString();
                        }
                    }
                }
                mostrarEditCategoria.Visible = true;
            }
        }

        protected void gvActividadBody_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());

            if (e.CommandName == "Editar")
            {
                drop.Drop_ActividadPAT(DropEditActividad, 0);

                foreach (GridViewRow rowtitulo in gvActividadTitulo.Rows)
                {
                    if (rowtitulo.RowType == DataControlRowType.DataRow)
                    {
                        GridViewRow row = (rowtitulo.FindControl("gvActividadBody") as GridView).Rows[index];

                        DataTable data = new DataTable();
                        data = admin.ActividadSeleccionada(int.Parse(row.Cells[0].Text));

                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            idActividad.Text = data.Rows[i][0].ToString();
                            TxtEditActividad.Value = data.Rows[i][1].ToString();
                            DropEditActividad.SelectedValue = data.Rows[i][2].ToString();
                        }
                    }
                }
                mostrarEditActividad.Visible = true;
            }
        }
    }
}