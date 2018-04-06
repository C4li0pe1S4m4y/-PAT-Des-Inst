using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.Create;
using PATOnline.Controller.Read;
using PATOnline.Controller.Search;
using PATOnline.Models;

namespace PATOnline.Views.P3
{
    public partial class IndexP3 : System.Web.UI.Page
    {
        public string federacion = null;
        CreateP3 nuevo = new CreateP3();
        ReadP3 read = new ReadP3();
        SearchFederacion buscar = new SearchFederacion();
        SearchP3 verificar = new SearchP3();
        ModeloP3 modelo = new ModeloP3();
        protected void Page_Load(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);
            fadn.Text = federacion;
            anio.Text = ano;
            Message.Visible = false;
            lblTitulo2.Text = "CREAR EGRESOS POR ACTIVIDAD";
            CargarGrid1();
        }

        public void CargarGrid1()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (read.Part3Read(federacion, ano).Rows.Count != 0)
            {   
                gvP1.DataSource = read.Part3Read(federacion, ano);
                gvP1.DataBind();
                gvP3.DataSource = read.PartTotalRead(federacion, ano);
                gvP3.DataBind();
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);
            double subtotal = Convert.ToDouble(TxtPromocion.Text) + Convert.ToDouble(TxtPrograma.Text) + Convert.ToDouble(TxtActividad.Text);

            modelo.codigo = TxtCodigo.Text;
            modelo.promocion = Convert.ToDouble(TxtPromocion.Text);
            modelo.programa = Convert.ToDouble(TxtPrograma.Text);
            modelo.actividad = Convert.ToDouble(TxtActividad.Text);
            
            if(TxtFuente.Text == null || TxtFuente.Text == "")
            {
                TxtFuente.Text = "0";
            }

            modelo.otra_fuente = Convert.ToDouble(TxtFuente.Text);
            modelo.subtoltal = subtotal;
            modelo.total = subtotal + Convert.ToDouble(TxtFuente.Text);
            modelo.fadn = federacion;
            modelo.ano = ano;

            try
            {
                if (verificar.ExisteP3(TxtCodigo.Text, federacion, ano) == true)
                {
                    limpiar();
                }
                else
                {
                    nuevo.P3Create(modelo);
                    limpiar();
                    CargarGrid1();
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Egreso por Actividad','Crear Egreso por Actividad')</script>");
            }
        }

        public void limpiar()
        {
            TxtCodigo.Text = null;
            TxtPromocion.Text = null;
            TxtPrograma.Text = null;
            TxtFuente.Text = null;
            TxtActividad.Text = null;
            Message.Visible = false;
        }
    }
}