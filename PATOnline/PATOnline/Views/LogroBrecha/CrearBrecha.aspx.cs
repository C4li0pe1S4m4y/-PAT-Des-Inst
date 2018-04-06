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
    public partial class CrearBrecha : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        CreateBrecha nuevo_brecha = new CreateBrecha();
        ModeloBrechaCategoria modelo_brecha = new ModeloBrechaCategoria();
        DropDown drop = new DropDown();
        SearchFederacion buscar = new SearchFederacion();
        float comparar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTitulo2.Text = "CREAR ANALISIS DE BRECHAS";
                drop.Drop_Brecha(DropBrecha);
                if ((TxtPuntosBrecha.Text == null || TxtPuntosBrecha.Text == "") && (TxtPuntosObtenidos.Text == null || TxtPuntosObtenidos.Text == ""))
                {
                    TxtPuntosBrecha.Text = null;
                    TxtPuntosObtenidos.Text = null;
                }
                else
                {
                    comparar = float.Parse(TxtPuntosBrecha.Text) - float.Parse(TxtPuntosObtenidos.Text);
                    TxtComparacion.Text = comparar.ToString();
                    TxtComparacion.Attributes.Add("Visible", "true");
                }            
            }
        }

        protected void SaveBrecha_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo_brecha.fkbrecha = int.Parse(DropBrecha.SelectedValue.ToString());
            modelo_brecha.punteo = Convert.ToDouble(TxtPuntosBrecha.Text);
            modelo_brecha.puntos = Convert.ToDouble(TxtPuntosObtenidos.Text);
            modelo_brecha.comparacion = Convert.ToDouble(TxtComparacion.Text);
            modelo_brecha.observacion = TxtObservacionBrecha.Text;
            modelo_brecha.fadn = federacion;
            modelo_brecha.anio = ano;

            try
            {
                nuevo_brecha.BrechaCreate(modelo_brecha);
                Response.Write("<script>window.alert('La Brecha se Creo Exitosamente','Crear Brecha')" +
                ";</script>" + "<script>window.setTimeout(location.href='LogroBrecha.aspx', 1);</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Brecha','Crear Brecha')" +
                ";</script>" + "<script>window.setTimeout(location.href='LogroBrecha.aspx', 1);</script>");
            }
        }

        protected void CancelBrecha_Click(object sender, EventArgs e)
        {
            DropBrecha.Attributes.Clear();
            TxtPuntosBrecha.Text = null;
            TxtPuntosObtenidos.Text = null;
            TxtComparacion.Text = null;
            TxtObservacionBrecha.Text = null;

            Response.Redirect("LogroBrecha.aspx");
        }
    }
}