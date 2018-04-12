using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.Create;
using PATOnline.Controller.Read;
using PATOnline.Controller.Search;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;

namespace PATOnline.Views.CPE
{
    public partial class IndexPE2 : System.Web.UI.Page
    {
        public string federacion = null;
        public string nuevo_codigo;
        DropDown drop = new DropDown();
        ReadPE2 formato = new ReadPE2();
        SearchPE2 ultimo_codigo = new SearchPE2();
        SearchFederacion buscar = new SearchFederacion();
        CreatePE2 nuevo = new CreatePE2();
        ModeloPE1 modelo = new ModeloPE1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                Message.Visible = false;
                lblTitulo2.Text = "PE2 ACTIVIDADES GENERALES PRESUPUESTADAS";
                TxtCodigo.Enabled = false;
                TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                drop.Drop_ActividadPAT(DropActividad, 2);
                drop.Drop_Pais(DropPais);
                drop.Drop_Departamento(DropDepartamento, 0);
                drop.Drop_Dia(DropIDia);
                drop.Drop_Mes(DropIMes);
                drop.Drop_Dia(DropFDia);
                drop.Drop_Mes(DropFMes);
                CargarGrid1(federacion, ano);
            }
        }

        public string generarCodigo(string fadn, string ano)
        {
            int codigo = ultimo_codigo.CodigoPE1(fadn, ano);
            if (codigo > 99)
            {
                nuevo_codigo = "-PE2-" + Convert.ToString(codigo + 1);
            }
            else if (codigo > 9 && codigo < 100)
            {
                nuevo_codigo = "-PE2-0" + Convert.ToString(codigo + 1);
            }
            else
            {
                nuevo_codigo = "-PE2-00" + Convert.ToString(codigo + 1);
            }
            return nuevo_codigo;
        }

        public void CargarGrid1(string fadn, string ano)
        {
            if (formato.PE2Read(fadn, ano).Rows.Count != 0)
            {
                gvP2.DataSource = formato.PE2Read(fadn, ano);
                gvP2.DataBind();
                gvP3.DataSource = formato.PE2TotalRead(fadn, ano);
                gvP3.DataBind();
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.codigo = TxtCodigo.Text;
            modelo.fkactividad = int.Parse(DropActividad.SelectedValue);
            modelo.resultado = TxtResultado.Text;
            modelo.registro = TxtRegistro.Text;
            modelo.i_dia = int.Parse(DropIDia.SelectedValue);
            modelo.i_mes = Convert.ToString(DropIMes.SelectedItem);
            modelo.f_dia = int.Parse(DropFDia.SelectedValue);
            modelo.f_mes = Convert.ToString(DropFMes.SelectedItem);
            modelo.fkpais_departamento = int.Parse(DropDepartamento.SelectedValue);
            modelo.lugar = TxtLugar.Text;
            modelo.prespuesto = Convert.ToDouble(TxtPresupuesto.Text);
            modelo.fadn = federacion;
            modelo.ano = ano;

            try
            {
                nuevo.PE2Create(modelo);
                limpiar();
                TxtCodigo.Enabled = false;
                TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                CargarGrid1(federacion, ano);
            }
            catch
            {
                limpiar();
                Message.Visible = true;
            }
        }

        protected void DropPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Departamento(DropDepartamento, int.Parse(DropPais.SelectedValue));
        }

        public void limpiar()
        {
            Message.Visible = false;
            TxtCodigo.Text = null;
            DropActividad.SelectedValue = null;
            TxtResultado.Text = null;
            TxtRegistro.Text = null;
            DropIDia.SelectedValue = null;
            DropIMes.SelectedValue = null;
            DropFDia.SelectedValue = null;
            DropFMes.SelectedValue = null;
            DropDepartamento.SelectedValue = null;
            TxtLugar.Text = null;
            TxtPresupuesto.Text = null;
        }
    }
}