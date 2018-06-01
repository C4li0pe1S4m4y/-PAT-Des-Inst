using System;
using System.Web.UI;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Models;
using PATOnline.Controller.Herramientas;
using System.Text;

namespace PATOnline.Views.Usuarios
{
    public partial class Create : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        ModeloUsuario modelo = new ModeloUsuario();
        CreateUsuario nuevo = new CreateUsuario();
        SerachUsuario buscar = new SerachUsuario();
        Correo correo = new Correo();
        public string Modal = "CREAR NUEVO USUARIO";
        public string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@!/#*";
        public int contador=6;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                cargarDrop();
                lblModal.Text = Modal;
            }
        }

        protected void DropTipoFADN_SelectedIndexChanged(object sender, EventArgs e)
        {           
            drop.Drop_FADN(DropFADN, DropTipoFADN.SelectedValue);        
        }
        public string verificar;
        protected void Save_Click(object sender, EventArgs e)
        {
            int id_rol = int.Parse(DropRol.SelectedValue.ToString());
            verificar = "CDAG-" + toke();
            //Crear Nuevo Usuario
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
                if(TxtEmail.Value != "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Problema!', 'El E-mail ya existe', 'warning');", true);
                    TxtEmail.Value = "";
                }
            }
            else
            {
                BuscarUsuario();
            }     
        }

        public void BuscarUsuario()
        {
            if (buscar.BuscarUsuario(TxtUsuario.Value) == true)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Problema!', 'El Usuario existe', 'warning');", true);
                TxtUsuario.Value = "";
            }
            else
            {
                try
                {
                    nuevo.UsuarioCreate(modelo);
                    //Correo
                    if (TxtEmail.Value != "" || TxtEmail.Value != null)
                    {
                        correo.CorreoResetPassword(TxtEmail.Value, verificar);
                    }
                    limpiar();
                    cargarDrop();
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El Usuario fue creado', 'success');", true);
                }
                catch
                {
                    if (TxtEmail.Value == "")
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'Se creó un usuario sin Email', 'warning');", true);
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El Usuario no fue creado', 'error');", true);
                }
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
            TxtUsuario.Value = null;
            TxtTelefono.Value = null;
            DropFADN.Items.Clear();
            DropRol.Items.Clear();
            DropTipoFADN.Items.Clear();
        }

        public void cargarDrop()
        {
            drop.Drop_TipoFADN(DropTipoFADN);
            drop.Drop_FADN(DropFADN, "0");
            drop.Drop_Rol(DropRol);
        }
    }
}