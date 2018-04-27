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
    public partial class IndexPE1 : System.Web.UI.Page
    {
        public string federacion = null;
        public string nuevo_codigo;
        DropDown drop = new DropDown();
        ReadPE1 formato = new ReadPE1();
        SearchPE1 ultimo_codigo = new SearchPE1();
        SearchFederacion buscar = new SearchFederacion();
        CreatePE1 nuevo = new CreatePE1();
        ModeloPE1 modelo = new ModeloPE1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                Message.Visible = false;
                lblTitulo2.Text = "PE1 GESTIÓN DE LA ALTA DIRECCIÓN";
                TxtCodigo.Enabled = false;
                TxtCodigo.Text = ano+generarCodigo(federacion, ano);
                drop.Drop_ActividadPAT(DropActividad, 1);
                drop.Drop_Pais(DropPais);
                drop.Drop_Departamento(DropDepartamento,0);
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
                nuevo_codigo = "-PE1-" + Convert.ToString(codigo + 1);
            }
            else if (codigo > 9 && codigo < 100)
            {
                nuevo_codigo = "-PE1-0" + Convert.ToString(codigo + 1);
            }
            else
            {
                nuevo_codigo = "-PE1-00" + Convert.ToString(codigo + 1);
            }
            return nuevo_codigo;
        }

        public void CargarGrid1(string fadn, string ano)
        {
            if (formato.PE1Read(fadn, ano).Rows.Count != 0)
            {
                gvP2.DataSource = formato.PE1Read(fadn, ano);
                gvP2.DataBind();
                gvP3.DataSource = formato.PE1TotalRead(fadn, ano);
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
                if (ultimo_codigo.ExisteCodigoPE1(TxtCodigo.Text, federacion, ano) != true)
                {
                    nuevo.PE1Create(modelo);
                    limpiar();
                    TxtCodigo.Enabled = false;
                    TxtCodigo.Text = ano + generarCodigo(federacion, ano);
                    CargarGrid1(federacion, ano);
                }
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

        protected void gvP3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if((ultimo_codigo.PE1Total(federacion, ano) > 0) && (ultimo_codigo.PE1Total(federacion, ano) < ultimo_codigo.PresupuestoPE1(federacion, ano)))
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Orange;
                }
                else if(ultimo_codigo.PE1Total(federacion, ano) == ultimo_codigo.PresupuestoPE1(federacion, ano))
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