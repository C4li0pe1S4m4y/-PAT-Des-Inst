using System;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using PATOnline.Controller.Read;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Update;
using PATOnline.Controller.Search;
using PATOnline.Controller.Delete;
using PATOnline.Models;
using PATOnline.Controller.Herramientas;


namespace PATOnline.Views.Usuarios
{
    public partial class Usuario : System.Web.UI.Page
    {
        ReadUsuario all_usuario = new ReadUsuario();
        DropDown drop = new DropDown();
        ModeloUsuario modelo = new ModeloUsuario();
        UpdateUsuario update = new UpdateUsuario();
        SerachUsuario buscar = new SerachUsuario();
        DeleteUsuario delete = new DeleteUsuario();
        Correo correo = new Correo();
        public string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@!/#*";
        public int contador = 6;
        public string verificar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
                CargarGrid();
                MostrarUsuario.Visible = false;
                ModificarInformacion.Visible = false;
                idEditar.Visible = false;
                cargarDrop();
            }
        }

        protected void CargarGrid()
        {
            if (all_usuario.UsuarioRead().Rows.Count != 0)
            {
                gvListadoUsuarios.DataSource = all_usuario.UsuarioRead();
                gvListadoUsuarios.DataBind();
            }
        }

        protected void gvListadoUsuarios_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Mostrar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoUsuarios.Rows[index];

                DataTable usuario = new DataTable();
                usuario = buscar.UsuarioSearch(row.Cells[0].Text);

                MostrarUsuario.Visible = true;
                Nombrelbl.Text = row.Cells[1].Text;
                Usuariolbl.Text = row.Cells[0].Text;
                FAlbl.Text = row.Cells[2].Text;
                Direccionlbl.Text = row.Cells[3].Text;
                Correolbl.Text = row.Cells[4].Text;

                for (int i = 0; i < usuario.Rows.Count; i++)
                {
                    Telefonolbl.Text = usuario.Rows[i][6].ToString();
                    Rollbl.Text = usuario.Rows[i][10].ToString();
                    Estadolbl.Text = usuario.Rows[i][9].ToString();
                }                
            }

            if (e.CommandName == "Editar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoUsuarios.Rows[index];

                ModificarInformacion.Visible = true;
                DataTable usuario = new DataTable();
                usuario = buscar.UsuarioEditSearch(row.Cells[0].Text);

                for (int i = 0; i < usuario.Rows.Count; i++)
                {
                    idEditar.Text = usuario.Rows[i][0].ToString();
                    TxtNombre1.Value = usuario.Rows[i][1].ToString();
                    TxtNombre2.Value = usuario.Rows[i][2].ToString();
                    TxtApellido1.Value = usuario.Rows[i][3].ToString();
                    TxtApellido2.Value = usuario.Rows[i][4].ToString();
                    EditarDireccion.Text = usuario.Rows[i][5].ToString();
                    TxtTelefono.Value = usuario.Rows[i][6].ToString();
                    DropFADN.SelectedValue = usuario.Rows[i][8].ToString();
                    DropRol.SelectedValue = usuario.Rows[i][10].ToString();
                    TxtUsuario.Value = usuario.Rows[i][11].ToString();
                }
            }

            if (e.CommandName == "Eliminar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoUsuarios.Rows[index];
                try
                {
                    delete.UsuarioDelete(row.Cells[0].Text);
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'Usuario Eliminado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Usuario no fue eliminado', 'error');", true);
                }

            }

            if(e.CommandName == "Activar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoUsuarios.Rows[index];

                verificar = "CDAG-" + toke();
                modelo.verifica = verificar;

                DataTable usuario = new DataTable();
                usuario = buscar.UsuarioSearch(row.Cells[0].Text);

                try
                {
                    update.UsuarioUpdateActivar(modelo, row.Cells[0].Text);

                    for (int i = 0; i < usuario.Rows.Count; i++)
                    {
                        if(usuario.Rows[i][7].ToString() != "" || usuario.Rows[i][7].ToString() != null)
                        {
                            correo.CorreoResetPassword(usuario.Rows[i][7].ToString(), verificar);
                        }
                    }
                    CargarGrid();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'Usuario Activado', 'success');", true);
                }
                catch
                {
                    for (int i = 0; i < usuario.Rows.Count; i++)
                    {
                        if (usuario.Rows[i][7].ToString() == "" || usuario.Rows[i][7].ToString() == null)
                        {
                            CargarGrid();
                            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Se Activo el Usuario pero no tiene E-mail', 'warning');", true);
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Usuario no fue activado', 'error');", true);
                }
            }
        }

        protected void gvListadoUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoUsuarios.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void DropTipoFADN_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_FADN(DropFADN, DropTipoFADN.SelectedValue);
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            int id_rol = int.Parse(DropRol.SelectedValue.ToString());
            verificar = "CDAG-" + toke();

            modelo.nombre1 = TxtNombre1.Value;
            modelo.nombre2 = TxtNombre2.Value;
            modelo.apellido1 = TxtApellido1.Value;
            modelo.apellido2 = TxtApellido2.Value;
            modelo.telefono = TxtTelefono.Value;
            modelo.correo = TxtEmail.Value;
            modelo.fkfadn = DropFADN.SelectedValue;
            modelo.fkrol = id_rol;
            modelo.verifica = verificar;
            modelo.user = TxtUsuario.Value;

            if (buscar.BuscarCorreo(TxtEmail.Value) == true)
            {
                if (TxtEmail.Value != "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Problema!', 'El E-mail ya existe', 'warning');", true);
                    TxtEmail.Value = "";
                }
                else
                {
                    buscarUsuario();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Modifico un Usuario sin Email', 'warning');", true);
                }
            }
            else
            {
                buscarUsuario();
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Modifico un Usuario sin Email', 'warning');", true);
            }
        }

        public void buscarUsuario()
        {
            try
            {
                update.UsuarioUpdate(modelo, int.Parse(idEditar.Text));
                if (TxtEmail.Value != "")
                {
                    correo.CorreoResetPassword(TxtEmail.Value, verificar);
                }
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El Usuario fue modificado', 'info');", true);
                CargarGrid();
                limpiar();
                ModificarInformacion.Visible = false;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Usuario no fue modificado', 'error');", true);
            }

        }

        public string toke()
        {
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < contador--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            return res.ToString();
        }

        protected void limpiar()
        {
            TxtNombre1.Value = null;
            TxtNombre2.Value = null;
            TxtApellido1.Value = null;
            TxtApellido2.Value = null;
            TxtEmail.Value = null;
            TxtTelefono.Value = null;
            cargarDrop();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            ModificarInformacion.Visible = false;
            limpiar();
        }

        protected void cerrar_Click(object sender, EventArgs e)
        {
            MostrarUsuario.Visible = false;
        }

        public void cargarDrop()
        {
            drop.Drop_TipoFADN(DropTipoFADN);
            drop.Drop_FADN(DropFADN, "all");
            drop.Drop_Rol(DropRol);
        }

        protected void gvListadoUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvListadoUsuarios.DataKeys[e.Row.RowIndex].Value.ToString();

                if (buscar.EstadoUsuario(int.Parse(customerId)) == true)
                {
                    (e.Row.FindControl("btEliminar") as LinkButton).Visible = true;
                    (e.Row.FindControl("btActivar") as LinkButton).Visible = false;
                }
                else
                {
                    (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                    (e.Row.FindControl("btActivar") as LinkButton).Visible = true;
                }

                if(this.Session["Usuario"].ToString() == e.Row.Cells[0].Text)
                {
                    (e.Row.FindControl("btEliminar") as LinkButton).Visible = false;
                }
            }
        }
    }
}
