using System;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.ClasesBD;
using PATOnline.Models;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PATOnline.Views.AsignarFADN
{
    public partial class AsignarUsuarioFADN : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        ModeloAsignarFADN modelo = new ModeloAsignarFADN();
        AsiganarFADN asignar = new AsiganarFADN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            mostrarAsignacionFADN.Visible = false;
            mostrarEditAsignacionUsuario.Visible = false;
            idAsiganacionFADN.Visible = false;
            cargarGrid();
        }

        public void cargarGrid()
        {
            gvList.Columns[0].Visible = true;

            gvList.DataSource = asignar.AsignacionFADNRead();
            gvList.DataBind();

            gvList.Columns[0].Visible = false;
        }

        protected void nuevaAsignacinFADN_Click(object sender, EventArgs e)
        {
            drop.Drop_TipoFADN(DropTipoFADN);
            drop.Drop_FADN(DropFADN, "0");
            drop.Drop_UsuarioAsignado(DropUsuario);
            mostrarAsignacionFADN.Visible = true;
        }

        protected void DropTipoFADN_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_FADN(DropFADN, DropTipoFADN.SelectedValue);
        }

        protected void cancelAsignacionFADN_Click(object sender, EventArgs e)
        {
            mostrarAsignacionFADN.Visible = false;
        }

        protected void cancelEditAsignarUsuario_Click(object sender, EventArgs e)
        {
            mostrarEditAsignacionUsuario.Visible = false;
        }

        protected void editAsignarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.fkusuario = int.Parse(DropEditUsuario.SelectedValue);
                modelo.federacion = DropEditFADN.SelectedValue;
                if (asignar.AsignacionFADNExiste(int.Parse(DropEditUsuario.SelectedValue), DropEditFADN.SelectedValue) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    asignar.AsignacionFADNUpdate(modelo, int.Parse(idAsiganacionFADN.Text));
                    cargarGrid();
                    mostrarEditAsignacionUsuario.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue modificada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue modificada', 'error');", true);
            }
        }

        protected void crearAsignacionFADN_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.federacion = DropFADN.SelectedValue;
                modelo.fkusuario = int.Parse(DropUsuario.SelectedValue);
                if (asignar.AsignacionFADNExiste(int.Parse(DropUsuario.SelectedValue), DropFADN.SelectedValue) == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'La información ya existe', 'warning');", true);
                }
                else
                {
                    asignar.crearAsignacionUsuario(modelo);
                    cargarGrid();
                    mostrarAsignacionFADN.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue ingresada', 'success');", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue ingresada', 'error');", true);
            }
        }

        protected void DropEditTipoFADN_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_FADN(DropEditFADN, DropEditTipoFADN.SelectedValue);
        }

        protected void gvList_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            cargarGrid();
        }

        protected void gvList_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            gvList.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gvList.Rows[index];
            drop.Drop_UsuarioAsignado(DropEditUsuario);
            drop.Drop_FADN(DropEditFADN, "0");
            if (e.CommandName == "Editar")
            {
                DataTable data = new DataTable();
                data = asignar.AsignacionFADNSeleccionar(int.Parse(row.Cells[0].Text));

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idAsiganacionFADN.Text = data.Rows[i][0].ToString();
                    DropEditUsuario.SelectedValue = data.Rows[i][1].ToString();
                    DropEditFADN.SelectedValue = data.Rows[i][2].ToString();
                }
                drop.Drop_TipoFADN(DropEditTipoFADN);
                mostrarEditAsignacionUsuario.Visible = true;
            }
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    asignar.AsignacionFADNDelete(int.Parse(row.Cells[0].Text));
                    cargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La información fue eliminada', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La información no fue eliminada', 'error');", true);
                }
            }

            gvList.Columns[0].Visible = false;
        }
    }
}