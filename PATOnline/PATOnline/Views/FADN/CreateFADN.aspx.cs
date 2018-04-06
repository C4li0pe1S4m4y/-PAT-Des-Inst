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

namespace PATOnline.Views.FADN
{
    public partial class CreateFADN : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        CreateFA nuevo = new CreateFA();
        CreateLogotipo nuevo_logo = new CreateLogotipo();
        ModeloFADN modelo = new ModeloFADN();
        ModeloLogotipo modelo_logo = new ModeloLogotipo();
        SearchFADN busccar = new SearchFADN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drop.Drop_TipoFADN(DropTipo);
                drop.Drop_FADNLogo(DropFADN, "0");
                lblModal2.Text = "CREAR FEDERACIÓN / ASOSIACIÓN";
                lblModal4.Text = "AGREGAR LOGOTIPO A LA FEDERACIÓN / ASOSIACIÓN";
            }
        }

        protected void SaveFADN_Click(object sender, EventArgs e)
        {
            modelo.nombre = TxtNombre.Text;
            modelo.direccion = TxtDireccion.Text;
            modelo.fecha = DateTime.Now.ToString("yyyy/MM/dd");
            modelo.telefono = TxtTelefono.Text;
            modelo.correo = TxtCorreo.Text;

            if (busccar.FADNSearch(TxtNombre.Text) == true)
            {
                Response.Write("<script>window.alert('El FDN o ADN ya existe','Crear Nuevo FDN o ADN');</script>");
            }
            else
            {
                try
                {
                    nuevo.FACreate(modelo);
                    Response.Write("<script>window.alert('La FDN o ADN se creo exitosamente','Crear Nuevo FDN o ADN')" +
                    ";</script>" + "<script>window.setTimeout(location.href='FADN.aspx', 1);</script>");
                }
                catch
                {
                    Response.Write("<script>window.alert('Error al Crear FDN o ADN','Crear Nuevo FDN o ADN')" +
                    ";</script>" + "<script>window.setTimeout(location.href='FADN.aspx', 1);</script>");
                }
            }
        }

        protected void DropTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_FADNLogo(DropFADN, DropTipo.SelectedValue);
        }

        protected void SaveLogo_Click(object sender, EventArgs e)
        {
            System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            modelo_logo.logo = "data:image/png;base64," + base64String;
            modelo_logo.fkfadn = int.Parse(DropFADN.SelectedValue.ToString());

            try
            {
                nuevo_logo.LogoCreate(modelo_logo);
                Response.Write("<script>window.alert('Se asigno el logo exitosamente','Asginar Logotipo')" +
                ";</script>" + "<script>window.setTimeout(location.href='FADN.aspx', 1);</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al asignar logo','Asginar Logotipo')" +
                ";</script>" + "<script>window.setTimeout(location.href='FADN.aspx', 1);</script>");
            }

        }
    }
}