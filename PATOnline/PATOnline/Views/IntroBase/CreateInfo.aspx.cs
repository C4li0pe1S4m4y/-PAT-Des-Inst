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

namespace PATOnline.Views.IntroBase
{
    public partial class Create : System.Web.UI.Page
    {
        ModeloIntroBaseLegal modelo = new ModeloIntroBaseLegal();
        CreateInfoBaseLegal nuevo = new CreateInfoBaseLegal();
        ConexionMysql mysql = new ConexionMysql();
        public string Modal = "CREAR INTRODUCCIÓN - BASE LEGAL";
        public string federacion = "";
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblModal.Text = Modal;
                lblIntroduccion.Text = "INTRODUCCIÓN";
                lblMarco.Text = "MARCO JURÍDICO SORE EL QUE SE DESARROLLA LA FADN";
                lblAfiliacion.Text = "AFILIACIONES A ORGANIZACIONES NACIONALES E INTERNACIONALES";
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.intro = TxtIntroduccion.Text;
            modelo.marco = TxtMarco.Text;
            modelo.afiliacion = TxtAfiliacion.Text;
            modelo.fadn = federacion;
            modelo.ano = ano;
     
            try
            {
                nuevo.InfoCreate(modelo);
                Response.Write("<script>window.alert('La Informacion se Creo Exitosamente','Crear Nueva Informacion')" +
                                ";</script>" + "<script>window.setTimeout(location.href='IntroduccionBasesLegales.aspx', 1);</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al Crear la Nueva Informacion','Crear Nueva Informacion')" +
                                ";</script>" + "<script>window.setTimeout(location.href='IntroduccionBasesLegales.aspx', 1);</script>");
            }
        }
    }
}