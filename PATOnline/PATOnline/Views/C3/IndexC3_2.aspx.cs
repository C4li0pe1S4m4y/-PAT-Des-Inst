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

namespace PATOnline.Views.C3
{
    public partial class IndexC3_2 : System.Web.UI.Page
    {
        public string federacion = null;
        public string nuevo_codigo;
        DropDown drop = new DropDown();
        ReadC3_2 formato = new ReadC3_2();
        SearchC3_2 ultimo_codigo = new SearchC3_2();
        SearchFederacion buscar = new SearchFederacion();
        CreateC3_2 nuevo = new CreateC3_2();
        ModeloC3 modelo = new ModeloC3();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                Message.Visible = false;
                lblTitulo2.Text = "C3.2 SISTEMA DE JUEGOS DEPORTIVOS NACIONALES";
                TxtCodigo.Enabled = false;
                TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                drop.Drop_ActividadPAT(DropActividad, 21);
                drop.Drop_Categoria(DropCategoria, 11);
                drop.Drop_Departamento(DropDepartamento, 2);
                drop.Drop_Dia(DropIDia);
                drop.Drop_Mes(DropIMes);
                drop.Drop_Dia(DropFDia);
                drop.Drop_Mes(DropFMes);
                CargarGrid1(federacion, ano);
                TxtDepartamento.Enabled = false;
            }
        }

        public string generarCodigo(string fadn, string ano)
        {
            int codigo = ultimo_codigo.CodigoC3_2(fadn, ano);
            if (codigo > 99)
            {
                nuevo_codigo = "-C3.1-" + Convert.ToString(codigo + 1);
            }
            else if (codigo > 9 && codigo < 100)
            {
                nuevo_codigo = "-C3.1-0" + Convert.ToString(codigo + 1);
            }
            else
            {
                nuevo_codigo = "-C3.1-00" + Convert.ToString(codigo + 1);
            }
            return nuevo_codigo;
        }

        public void CargarGrid1(string fadn, string ano)
        {
            if (formato.C3_2Read(fadn, ano).Rows.Count != 0)
            {
                gvP2.DataSource = formato.C3_2Read(fadn, ano);
                gvP2.DataBind();
                gvP3.DataSource = formato.C3_2TotalRead(fadn, ano);
                gvP3.DataBind();
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.codigo = TxtCodigo.Text;
            modelo.fkactividad = int.Parse(DropActividad.SelectedValue);
            modelo.fkcategoria = int.Parse(DropCategoria.SelectedValue);
            modelo.edades = TxtEdades.Text;
            modelo.masculino = int.Parse(TxtMasculino.Text);
            modelo.femenino = int.Parse(TxtFemenino.Text);
            modelo.total = int.Parse(TxtMasculino.Text) + int.Parse(TxtFemenino.Text);
            modelo.registro = TxtRegistros.Text; 
            modelo.inicio_dia = int.Parse(DropIDia.SelectedValue);
            modelo.inicio_mes = Convert.ToString(DropIMes.SelectedItem);
            modelo.fin_dia = int.Parse(DropFDia.SelectedValue);
            modelo.fin_mes = Convert.ToString(DropFMes.SelectedItem);
            modelo.departamento = TxtDepartamento.Text;
            modelo.lugar = TxtLugar.Text;
            modelo.presupuesto = Convert.ToDouble(TxtPresupuesto.Text);
            modelo.fadn = federacion;
            modelo.ano = ano;

            try
            {
                if (ultimo_codigo.ExisteCodigoC3_2(TxtCodigo.Text, federacion, ano) != true)
                {
                    nuevo.C3_2Create(modelo);
                    limpiar();
                    TxtCodigo.Enabled = false;
                    TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                    CargarGrid1(federacion, ano);
                }
            }
            catch
            {
                limpiar();
                TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                Message.Visible = true;
            }
        }

        public void limpiar()
        {
            Message.Visible = false;
            TxtCodigo.Text = null;
            DropActividad.SelectedValue = null;
            DropCategoria.SelectedValue = null;
            TxtEdades.Text = null;
            TxtMasculino.Text = null;
            TxtFemenino.Text = null;
            TxtRegistros.Text = null;
            DropIDia.SelectedValue = null;
            DropIMes.SelectedValue = null;
            DropFDia.SelectedValue = null;
            DropFMes.SelectedValue = null;
            DropDepartamento.SelectedValue = null;
            TxtDepartamento.Text = null;
            TxtLugar.Text = null;
            TxtPresupuesto.Text = null;
        }

        protected void DropDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtDepartamento.Text = TxtDepartamento.Text + DropDepartamento.SelectedItem + ", ";
        }
    }
}