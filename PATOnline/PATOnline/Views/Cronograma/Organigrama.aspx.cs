using System.Web.UI.WebControls;
using PATOnline.Controller.Read;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Models;
using System;
using System.Web.UI;

namespace PATOnline.Views.Cronograma
{
    public partial class Cronograma : System.Web.UI.Page
    {
        ReadOrganigrama all = new ReadOrganigrama();
        CreateOrganigrama nuevo = new CreateOrganigrama();
        ModeloOrganigrama modelo = new ModeloOrganigrama();
        SearchFederacion buscar = new SearchFederacion();
        public string mysql = "";       
        public string federacion = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
            federacion = buscar.NombreFederacion(Convert.ToString(this.Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            mostrarCrearOrganigrama.Visible = false;
            mostrarEditarOrganigrama.Visible = false;

            CargarGrid(federacion, ano);
        }

        public string convertirImagenBase64(FileUpload imagen)
        {
            try
            {
                System.IO.Stream fs = imagen.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string convertir = Convert.ToBase64String(bytes, 0, bytes.Length);

                return "data:image/png;base64," + convertir;
            }
            catch
            {
                return "";
            }
        }

        protected void CargarGrid(string federacion, string anio)
        {
            if(all.OrgranigramaRead(federacion, anio).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.OrgranigramaRead(federacion, anio);
                gvListadoInfo.DataBind();
            }
        }

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(this.Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            gvListadoInfo.PageIndex = e.NewPageIndex;
            CargarGrid(federacion, ano);
        }

        protected void nuevoOrganigrama_Click(object sender, EventArgs e)
        {
            mostrarCrearOrganigrama.Visible = true;
        }

        protected void cancelCrearOrganigrama_Click(object sender, EventArgs e)
        {
            mostrarCrearOrganigrama.Visible = false;
        }

        protected void crearOrganigrama_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(this.Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            try
            {
                modelo.imagen = convertirImagenBase64(FileUpload1);
                modelo.fadn = federacion;
                modelo.anio = ano;
                nuevo.OrganigramaCreate(modelo);
                CargarGrid(federacion, ano);
                mostrarCrearOrganigrama.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El organigrama fue guardado', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El organigrama no fue guardado', 'error');", true);
            }
        }

        protected void cancelEditOrganigrama_Click(object sender, EventArgs e)
        {
            mostrarEditarOrganigrama.Visible = false;
        }

        protected void editOrganigrama_Click(object sender, EventArgs e)
        {

        }

        protected void gvListadoInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}