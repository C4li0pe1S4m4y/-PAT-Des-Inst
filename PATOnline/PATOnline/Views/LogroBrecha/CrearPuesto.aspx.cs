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
using PATOnline.Controller.Read;
using PATOnline.Models;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;

namespace PATOnline.Views.LogroBrecha
{
    public partial class CrearPuesto : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        CreatePuestoLogrado nuevo_puesto = new CreatePuestoLogrado();
        ModeloPuestoLogrado modelo = new ModeloPuestoLogrado();
        DropDown drop = new DropDown();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                lblTitulo.Text = "CREAR ANALISIS SOBRE PUESTOS";
                drop.Drop_Anio(DropAnio);
            }
        }

        protected void SavePuesto_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.puesto = TxtPuesto.Text;
            modelo.punteo = Convert.ToDouble(TxtPunteoPuesto.Text);
            modelo.observacion = TxtObservacionPuesto.Text;
            modelo.fkanio = int.Parse(DropAnio.SelectedValue.ToString());
            modelo.fadn = federacion;
            modelo.anio = ano;

            try
            {
                nuevo_puesto.PuestoLogradoCreate(modelo);
                Response.Write("<script>window.alert('El Puesto Logrado se Creo Exitosamente','Crear Puesto Logrado')" +
                ";</script>" + "<script>window.setTimeout(location.href='LogroBrecha.aspx', 1);</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Puesto Logrado','Crear Puesto Logrado')" +
                ";</script>" + "<script>window.setTimeout(location.href='LogroBrecha.aspx', 1);</script>");
            }
        }
        protected void CancelPuesto_Click(object sender, EventArgs e)
        {
            DropAnio.Attributes.Clear();
            TxtPunteoPuesto.Text = null;
            TxtPuesto.Text = null;
            TxtObservacionPuesto.Text = null;

            Response.Redirect("LogroBrecha.aspx");
        }
    }
}