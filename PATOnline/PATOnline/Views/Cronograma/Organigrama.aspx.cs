using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Drawing;
using System.Data;

using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using PATOnline.Controller.Read;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Models;
using PATOnline.DBConnection;
using MySql.Data.MySqlClient;
using System;

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

            lblTitulo.Text = "MOSTRAR INFORMACIÓN";
            lblSubTitulo.Text = "CREAR ORGANIGRAMA INSTITUCIONAL";
            CargarGrid();
        }

        protected void CargarGrid()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(this.Session["Usuario"]));

            string ano = Convert.ToString(DateTime.Now.Year);

            if(all.OrgranigramaRead(federacion, ano).Rows.Count != 0)
            {
                gvOrganigrama.DataSource = all.OrgranigramaRead(federacion, ano);
                gvOrganigrama.DataBind();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            System.IO.Stream fs = FileUpload1.PostedFile.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

            federacion = buscar.NombreFederacion(Convert.ToString(this.Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            try
            {
                modelo.imagen = "data:image/png;base64," + base64String;
                modelo.fadn = federacion;
                modelo.anio = ano;
                nuevo.OrganigramaCreate(modelo);
                CargarGrid();
                Response.Write("<script>window.alert('El Organigrama fue guardado Exitosamente','Nuevo Ogranigrama')" +
                ";</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al guardar el Organigrama','Nuevo Ogranigrama')" +
                ";</script>");
            }
        }

        protected void gvOrganigrama_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOrganigrama.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void gvOrganigrama_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            FileUpload1.Attributes.Clear();
            Response.Redirect("~/Views/Cronograma/Organigrama.aspx");
        }
    }
}