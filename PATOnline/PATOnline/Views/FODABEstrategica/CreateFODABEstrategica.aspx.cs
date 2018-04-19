using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.DBConnection;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Models;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;

namespace PATOnline.Views.FODABEstrategica
{
    public partial class CreateFODABEstrategica : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        CreateFodaBEstrategica nuevo = new CreateFodaBEstrategica();
        ModeloFodaBEstrategica modelo = new ModeloFodaBEstrategica();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            lblModal.Text = "CREAR FODA - BASE ESTRATÉGICA";
            lblFODA.Text = "FODA (FORTALEZA - OPORTUNIDAD - DEBILIDAD - AMENAZA)";
            lblfortaleza.Text = "FORTALEZA";
            lbloportunidad.Text = "OPORTUNIDAD";
            lbldebilidad.Text = "DEBILIDAD";
            lblamenaza.Text = "AMENAZA";
            lblBEstrategica.Text = "BASE ESTRATÉGICA";
            lblvision.Text = "VISIÓN";
            lblmision.Text = "MISIÓN";
            lblvalor.Text = "VALOR";
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.fortaleza = TxtFortaleza.Text;
            modelo.oportunidad = TxtOportunidad.Text;
            modelo.debilidad = TxtDebilidad.Text;
            modelo.amenaza = TxtAmenaza.Text;

            modelo.vision = TxtVision.Text;
            modelo.mision = TxtMision.Text;
            modelo.valor = TxtValor.Text;

            try
            {
                nuevo.FODABEstrategicaCreate(modelo);
                Response.Write("<script>window.alert('El FODA - Base Estrategica se Creo Exitosamente','Crear FODA - Base Estrategica')" +
                                ";</script>" + "<script>window.setTimeout(location.href='FODABEstrategica.aspx', 1);</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear FODA - Base Estrategica','Crear FODA - Base Estrategica')" +
                                ";</script>" + "<script>window.setTimeout(location.href='FODABEstrategica.aspx', 1);</script>");
            }
        }
    }
}