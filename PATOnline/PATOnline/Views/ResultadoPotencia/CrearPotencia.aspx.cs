using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using PATOnline.DBConnection;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;

namespace PATOnline.Views.ResultadoPotencia
{
    public partial class CrearPotencia : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        DropDown drop_nivel = new DropDown();
        CreatePotencia nuevo = new CreatePotencia();
        ModeloPotencia modelo = new ModeloPotencia();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblPotencia.Text = "CREAR ANÁLISIS DE PRINCIPALES POTENCIAS";
                drop_nivel.Drop_Nivel(DropNivel);
            }
        }

        protected void SavePotencia_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.primera = TxtPotencia1.Text;
            modelo.segunda = TxtPotencia2.Text;
            modelo.tercera = TxtPotencia3.Text;
            modelo.potencia = TxtPosicion.Text;
            modelo.fknivel = int.Parse(DropNivel.SelectedValue);
            modelo.fadn = federacion;
            modelo.anio = ano;

            try
            {
                nuevo.PotenciaCreate(modelo);
                Response.Write("<script>window.alert('La Potencia se Creo Exitosamente','Crear Potencia')" +
                ";</script>" + "<script>window.setTimeout(location.href='ResultadoPotencia.aspx', 1);</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Potencia','Crear Potencia')" +
                ";</script>" + "<script>window.setTimeout(location.href='ResultadoPotencia.aspx', 1);</script>");
            }
        }

        protected void CancelPotencia_Click(object sender, EventArgs e)
        {
            TxtPotencia1.Text = null;
            TxtPotencia2.Text = null;
            TxtPotencia3.Text = null;
            TxtPosicion.Text = null;
            DropNivel.SelectedValue = null;
            Response.Redirect("~/Views/ResultadoPotencia/ResultadoPotencia");
        }
    }
}