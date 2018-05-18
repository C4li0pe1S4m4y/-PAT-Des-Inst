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
    public partial class IndexC3_1 : System.Web.UI.Page
    {
        public string federacion = null;
        public string nuevo_codigo;
        DropDown drop = new DropDown();
        ReadC3_1 formato = new ReadC3_1();
        SearchC3_1 ultimo_codigo = new SearchC3_1();
        SearchFederacion buscar = new SearchFederacion();
        CreateC3_1 nuevo = new CreateC3_1();
        ModeloC3 modelo = new ModeloC3();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                Message.Visible = false;
                lblTitulo2.Text = "C3.1 SISTEMA COMPETITIVO NACIONAL";
                TxtCodigo.Enabled = false;
                TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                drop.Drop_Clasifiacion(DropClasificacion, 1);
                drop.Drop_Nivel(DropNivel, 2);
                drop.Drop_Categoria(DropCategoria, 8);
                drop.Drop_Departamento(DropDepartamento, 2);
                drop.Drop_Dia(DropIDia);
                drop.Drop_Mes(DropIMes);
                drop.Drop_Dia(DropFDia);
                drop.Drop_Mes(DropFMes);
                CargarGrid1(federacion, ano);
            }
        }

        public string generarCodigo(string fadn, string ano)
        {
            int codigo = ultimo_codigo.CodigoC3_1(fadn, ano);
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
            if (formato.C3_1Read(fadn, ano).Rows.Count != 0)
            {
                gvP2.DataSource = formato.C3_1Read(fadn, ano);
                gvP2.DataBind();
                gvP3.DataSource = formato.C3_1TotalRead(fadn, ano);
                gvP3.DataBind();
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.codigo = TxtCodigo.Text;
            modelo.nombre_competencia = TxtCompetencia.Text;
            modelo.fkclasificacion = int.Parse(DropClasificacion.SelectedValue);
            modelo.fknivel = int.Parse(DropNivel.SelectedValue);
            modelo.fkcategoria = int.Parse(DropCategoria.SelectedValue);
            modelo.edades = TxtEdades.Text;
            modelo.fase_evento = TxtFase.Text;
            modelo.resultado = TxtResultados.Text;
            modelo.registro = TxtRegistros.Text;
            modelo.inicio_dia = int.Parse(DropIDia.SelectedValue);
            modelo.inicio_mes = Convert.ToString(DropIMes.SelectedItem);
            modelo.fin_dia = int.Parse(DropFDia.SelectedValue);
            modelo.fin_mes = Convert.ToString(DropFMes.SelectedItem);
            modelo.fkdepartamento = int.Parse(DropDepartamento.SelectedValue);
            modelo.lugar = TxtLugar.Text;
            modelo.presupuesto = Convert.ToDouble(TxtPresupuesto.Text);
            modelo.fadn = federacion;
            modelo.ano = ano;

            try
            {
                if (ultimo_codigo.ExisteCodigoC3_1(TxtCodigo.Text, federacion, ano) != true)
                {
                    nuevo.C3_1Create(modelo);
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
            TxtCompetencia.Text = null;
            DropClasificacion.SelectedValue = null;
            DropNivel.SelectedValue = null;
            DropCategoria.SelectedValue = null;
            TxtEdades.Text = null;
            TxtFase.Text = null;
            TxtResultados.Text = null;
            TxtRegistros.Text = null;
            DropIDia.SelectedValue = null;
            DropIMes.SelectedValue = null;
            DropFDia.SelectedValue = null;
            DropFMes.SelectedValue = null;
            DropDepartamento.SelectedValue = null;
            TxtLugar.Text = null;
            TxtPresupuesto.Text = null;
        }

        protected void gvP3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (double.Parse((e.Row.FindControl("lblPresupuesto") as Label).Text) == ultimo_codigo.PresupuestoC3_1(federacion, ano))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}