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
    public partial class CrearResultado : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        DropDown drop = new DropDown();
        CreateResultado nuevo = new CreateResultado();
        ModeloResultado modelo = new ModeloResultado();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                lblResultado.Text = "CREAR RESULTADOS DEPORTIVOS";
                drop.Drop_Nivel(DropNivel);
                drop.Drop_Categoria(DropCategoria, 1);
            }
        }

        protected void SaveResultado_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.fknivel = int.Parse(DropNivel.SelectedValue);
            modelo.nombre = TxtCompetencia.Text;
            modelo.sede = TxtSede.Text;
            modelo.fecha = TxtFecha.Text;
            modelo.fkcategoria = int.Parse(DropCategoria.SelectedValue);
            modelo.resultado = TxtResultado.Text;
            modelo.observacion = TxtObservacion.Text;
            modelo.fadn = federacion;
            modelo.anio = ano;

            try
            {
                nuevo.ResultadoCreate(modelo);
                Response.Write("<script>window.alert('El Resultado se Creo Exitosamente','Crear Resultado')" +
                ";</script>" + "<script>window.setTimeout(location.href='ResultadoPotencia.aspx', 1);</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Resultado','Crear Resultado')" +
                ";</script>" + "<script>window.setTimeout(location.href='ResultadoPotencia.aspx', 1);</script>");
            }
        }

        protected void CancelResultado_Click(object sender, EventArgs e)
        {
            DropNivel.SelectedValue = null;
            TxtCompetencia.Text = null;
            TxtSede.Text = null;
            TxtFecha.Text = null;
            DropCategoria.SelectedValue = null;
            TxtResultado.Text = null;
            TxtObservacion.Text = null;
        }
    }
}