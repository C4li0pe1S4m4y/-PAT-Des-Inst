using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

                drop.Drop_Pais(DropPais);
                drop.Drop_Departamento(DropDepartamento, 0);
                drop.Drop_TipoFADN(DropTipoFADN);
                drop.Drop_FADN(DropFADN, "0");
                drop.Drop_Rol(DropRol);
                lblModal.Text = Modal;
            }
        }

        protected void DropPais_SelectedIndexChanged(object sender, EventArgs e)
        {           
            int id = Int32.Parse(DropPais.SelectedValue.ToString());
            drop.Drop_Departamento(DropDepartamento, id);

        }
        protected void DropTipoFADN_SelectedIndexChanged(object sender, EventArgs e)
        {           
            drop.Drop_FADN(DropFADN, DropTipoFADN.SelectedValue);        
        }
        public string verificar;
        protected void Save_Click(object sender, EventArgs e)
        {
            int id_pais = int.Parse(DropDepartamento.SelectedValue.ToString());
            int id_rol = int.Parse(DropRol.SelectedValue.ToString());
            verificar = "CDAG-" + toke();
            //Crear Nuevo Usuario
            modelo.nombre1 = TxtNombre1.Value;
            modelo.nombre2 = TxtNombre2.Value;
            modelo.apellido1 = TxtApellido1.Value;
            modelo.apellido2 = TxtApellido2.Value;
            modelo.direccion = TxtDireccion.Value;
            modelo.telefono = TxtTelefono.Value;
            if (buscar.BuscarCorreo(TxtEmail.Value) == true)
            {
                Response.Write("<script>window.alert('El Correo ya Existe, por favor ingrese otro Correo'" +
                    ",'Crear Nuevo Usuario')</script>");
                TxtEmail = null;
            }
            else
            {
                modelo.correo = TxtEmail.Value;
                modelo.fkpais = id_pais;
                modelo.fkfadn = DropFADN.SelectedValue;
                modelo.fkrol = id_rol;
                modelo.verifica = verificar;
                if (buscar.BuscarUsuario(TxtUsuario.Value) == true)
                {
                    Response.Write("<script>window.alert('El Usuario ya Existe, por favor ingrese otro Usuario'" +
                        ",'Crear Nuevo Usuario')</script>");
                    TxtUsuario.Value = null;
                }
                else
                {
                    modelo.user = TxtUsuario.Value;
                    try
                    {
                        nuevo.UsuarioCreate(modelo);
                        //Correo
                        correo.CorreoResetPassword(TxtEmail.Value, verificar);
                        Response.Redirect("~/Views/Usuarios/Usuario.aspx");
                    }
                    catch
                    {
                        Response.Write("<script>window.alert('Error al Crear al Nuevo Usuario','Crear Nuevo Usuario')" +
                        ";</script>" + "<script>window.setTimeout(location.href='Usuario.aspx', 1);</script>");
                    }
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
            TxtDireccion.Value = null;
            TxtEmail.Value = null;
            TxtTelefono.Value = null;
            DropPais.Items.Clear();
            DropDepartamento.Items.Clear();
            DropFADN.Items.Clear();
            DropRol.Items.Clear();
            DropTipoFADN.Items.Clear();
        }
    }
}