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
        SearchCPE monto = new SearchCPE();
        ModeloP3 modelo = new ModeloP3();
        public string error = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                fadn.Text = federacion;
                anio.Text = ano;
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

        protected void gvP3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (monto.MontoP1_Igual_P3(federacion, ano) == 0)
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void gvP1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            error = "Ingresar ";
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

                if (e.CommandName == "AGREGAR")
                {
                    string seleccionar = e.CommandArgument.ToString();
                    int index = int.Parse(seleccionar);

                    GridViewRow row = gvP1.Rows[index];

                    modelo.codigo = (row.FindControl("lblCodigo") as Label).Text;

                    if ((row.FindControl("TxtPromocion") as TextBox).Text == "" || (row.FindControl("TxtPromocion") as TextBox).Text == null)
                    {
                        error = error + " Promoción ";
                    }
                    else
                    {
                        modelo.promocion = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text);
                    }
                    if ((row.FindControl("TxtPrograma") as TextBox).Text == "" || (row.FindControl("TxtPrograma") as TextBox).Text == null)
                    {
                        error = error + " Programa, ";
                    }
                    else
                    {
                        modelo.programa = Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text);
                    }
                    if ((row.FindControl("TxtActividad") as TextBox).Text == "" || (row.FindControl("TxtActividad") as TextBox).Text == null)
                    {
                        error = error + " Actividad, ";
                    }
                    else
                    {
                        modelo.actividad = Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text);
                    }
                    if ((row.FindControl("TxtActividad") as TextBox).Text == "" || (row.FindControl("TxtActividad") as TextBox).Text == null)
                    {
                        error = error + " Otra Fuente ";
                    }
                    else
                    {
                        modelo.otra_fuente = Convert.ToDouble((row.FindControl("TxtOtraFuente") as TextBox).Text);
                    }

                    modelo.subtoltal = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text);
                    modelo.total = Convert.ToDouble((row.FindControl("TxtPromocion") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtPrograma") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtActividad") as TextBox).Text) + Convert.ToDouble((row.FindControl("TxtOtraFuente") as TextBox).Text);

                    if (error == "Ingresar ")
                    {
                        try
                        {
                            nuevo.P3Create(modelo);
                            (row.FindControl("MessageError") as Label).Visible = false;
                            CargarGrid1(federacion, ano);
                        }
                        catch
                        {
                            error = "Error un dato es incorrecto ";
                            (row.FindControl("MessageError") as Label).Visible = false;
                        }
                    }
                    else
                    {
                        (row.FindControl("MessageError") as Label).Visible = true;
                    }
                }

        }

        protected void gvP1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (int.Parse(e.Row.RowIndex.ToString()) >= 0)
            {
                (e.Row.FindControl("MessageError") as Label).Visible = false;
                string ver = (e.Row.FindControl("TxtPromocion") as TextBox).Text;

                if (ver == "")
                {
                    (e.Row.FindControl("AgregarInfo") as Button).Visible = true;
                    (e.Row.FindControl("TxtPromocion") as TextBox).Enabled = true;
                    (e.Row.FindControl("TxtPrograma") as TextBox).Enabled = true;
                    (e.Row.FindControl("TxtActividad") as TextBox).Enabled = true;
                    (e.Row.FindControl("TxtOtraFuente") as TextBox).Enabled = true;
                }
                else
                {
                    (e.Row.FindControl("AgregarInfo") as Button).Visible = false;
                    (e.Row.FindControl("TxtPromocion") as TextBox).Enabled = false;
                    (e.Row.FindControl("TxtPrograma") as TextBox).Enabled = false;
                    (e.Row.FindControl("TxtActividad") as TextBox).Enabled = false;
                    (e.Row.FindControl("TxtOtraFuente") as TextBox).Enabled = false;
                }
            }
        }
    }
}