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

namespace PATOnline.Views.C4
{
    public partial class IndexC4_2 : System.Web.UI.Page
    {
        public string federacion = null;
        public string nuevo_codigo;
        DropDown drop = new DropDown();
        ReadC4_2 formato = new ReadC4_2();
        SearchC4_2 ultimo_codigo = new SearchC4_2();
        SearchFederacion buscar = new SearchFederacion();
        CreateC4_2 nuevo = new CreateC4_2();
        ModeloC4 modelo = new ModeloC4();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                Message.Visible = false;
                lblTitulo2.Text = "C4.2 CAMPAMENTOS DE PREPARACIÓN";
                TxtCodigo.Enabled = false;
                TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                drop.Drop_Nivel(DropNivel, 3);
                drop.Drop_Objetivo(DropObjetivo, 7);
                drop.Drop_Etapa(DropEtapa, 12);
                drop.Drop_Categoria(DropCategoria, 16);
                drop.Drop_Pais(DropPais);
                drop.Drop_Departamento(DropDepartamento, 0);
                drop.Drop_Dia(DropIDia);
                drop.Drop_Mes(DropIMes);
                drop.Drop_Dia(DropFDia);
                drop.Drop_Mes(DropFMes);
                TxtDepartamento.Enabled = false;
                CargarGrid1(federacion, ano);
            }
        }


        public string generarCodigo(string fadn, string ano)
        {
            int codigo = ultimo_codigo.CodigoC4_2(fadn, ano);
            if (codigo > 99)
            {
                nuevo_codigo = "-C4.2-" + Convert.ToString(codigo + 1);
            }
            else if (codigo > 9 && codigo < 100)
            {
                nuevo_codigo = "-C4.2-0" + Convert.ToString(codigo + 1);
            }
            else
            {
                nuevo_codigo = "-C4.2-00" + Convert.ToString(codigo + 1);
            }
            return nuevo_codigo;
        }

        public void CargarGrid1(string fadn, string ano)
        {
            if (formato.C4_2Read(fadn, ano).Rows.Count != 0)
            {
                gvP2.DataSource = formato.C4_2Read(fadn, ano);
                gvP2.DataBind();
                gvP3.DataSource = formato.C4_2TotalRead(fadn, ano);
                gvP3.DataBind();
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.codigo = TxtCodigo.Text;
            modelo.actividad = TxtActividad.Text;
            modelo.fknivel = int.Parse(DropNivel.SelectedValue);
            modelo.fkobjetivo = int.Parse(DropObjetivo.SelectedValue);
            modelo.fketapa_prepacion = int.Parse(DropEtapa.SelectedValue);
            modelo.fkcategoria = int.Parse(DropCategoria.SelectedValue);
            modelo.linea = TxtLinea.Text;
            modelo.registro = TxtRegistro.Text;
            modelo.inicio_dia = int.Parse(DropIDia.SelectedValue);
            modelo.inicio_mes = Convert.ToString(DropIMes.SelectedItem);
            modelo.fin_dia = int.Parse(DropFDia.SelectedValue);
            modelo.fin_mes = Convert.ToString(DropFMes.SelectedItem);
            modelo.fkpais_departamento = int.Parse(DropPais.SelectedValue);
            modelo.departamento = TxtDepartamento.Text;
            modelo.lugar = TxtLugar.Text;
            modelo.presupuesto = Convert.ToDouble(TxtPresupuesto.Text);
            modelo.fadn = federacion;
            modelo.ano = ano;

            try
            {
                if (ultimo_codigo.ExisteCodigoC4_2(TxtCodigo.Text, federacion, ano) != true)
                {
                    nuevo.C4_2Create(modelo);
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
            TxtActividad.Text = null;
            DropNivel.SelectedValue = null;
            DropObjetivo.SelectedValue = null;
            DropEtapa.SelectedValue = null;
            DropCategoria.SelectedValue = null;
            TxtLinea.Text = null;
            TxtRegistro.Text = null;
            DropIDia.SelectedValue = null;
            DropIMes.SelectedValue = null;
            DropFDia.SelectedValue = null;
            DropFMes.SelectedValue = null;
            DropPais.SelectedValue = null;
            TxtDepartamento.Text = null;
            TxtLugar.Text = null;
            TxtPresupuesto.Text = null;
        }

        protected void DropPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Departamento(DropDepartamento, int.Parse(DropPais.SelectedValue));
        }

        protected void DropDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtDepartamento.Text = TxtDepartamento.Text + Convert.ToString(DropDepartamento.SelectedItem) + ", ";
        }

        protected void gvP3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (double.Parse((e.Row.FindControl("lblPresupuesto") as Label).Text) == ultimo_codigo.PresupuestoC4_2(federacion, ano))
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