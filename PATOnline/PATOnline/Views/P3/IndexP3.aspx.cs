using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Read;
using PATOnline.Controller.Search;
using PATOnline.Models;

namespace PATOnline.Views.P3
{
    public partial class IndexP3 : System.Web.UI.Page
    {
        public string federacion = null;
        DropDown drop = new DropDown();
        CreateP3 nuevo = new CreateP3();
        ReadP3 read = new ReadP3();
        SearchFederacion buscar = new SearchFederacion();
        SearchP3 verificar = new SearchP3();
        ModeloP3 modelo = new ModeloP3();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                fadn.Text = federacion;
                anio.Text = ano;
                Message.Visible = false;
                lblTitulo2.Text = "CREAR EGRESOS POR ACTIVIDAD";
                drop.Drop_ActividadPATPE(DropActividad);
                drop.Drop_FiltrarActividadPAT(DropCodigo, "pat_pe1", federacion, ano, "NO", 0);
                CargarGrid1(federacion, ano);
            }
        }

        public void CargarGrid1(string fadn, string ano)
        {
            if (read.Part3Read(fadn, ano).Rows.Count != 0)
            {   
                gvP1.DataSource = read.Part3Read(fadn, ano);
                gvP1.DataBind();
                gvP3.DataSource = read.PartTotalRead(fadn, ano);
                gvP3.DataBind();
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);
            double subtotal = Convert.ToDouble(TxtPromocion.Text) + Convert.ToDouble(TxtPrograma.Text) + Convert.ToDouble(TxtActividad.Text);

            modelo.codigo = Convert.ToString(DropCodigo.SelectedValue);
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
                if (verificar.ExisteP3(Convert.ToString(DropCodigo.SelectedValue), federacion, ano) == true)
                {
                    limpiar();
                }
                else
                {
                    nuevo.P3Create(modelo);
                    limpiar();
                    CargarGrid1(federacion, ano);
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Egreso por Actividad','Crear Egreso por Actividad')</script>");
            }
        }

        public void limpiar()
        {
            DropActividad.SelectedValue = null;
            DropCodigo.SelectedValue = null;
            TxtPromocion.Text = null;
            TxtPrograma.Text = null;
            TxtFuente.Text = null;
            TxtActividad.Text = null;
            Message.Visible = false;
        }

        protected void DropActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            drop.Drop_FiltrarActividadPAT(DropCodigo, "pat_pe1", federacion, ano, "SI", int.Parse(DropActividad.SelectedValue));
        }

        protected void DropCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (verificar.ExisteP3(Convert.ToString(DropCodigo.SelectedValue), federacion, ano) == true)
            {
                Message.Visible = true;
            }
            else
            {
                Message.Visible = false;
            }
        }
    }
}