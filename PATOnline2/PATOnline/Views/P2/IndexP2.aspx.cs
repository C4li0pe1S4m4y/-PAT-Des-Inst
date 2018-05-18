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

namespace PATOnline.Views.P2
{
    public partial class IndexP2 : System.Web.UI.Page
    {
        public string federacion = null;
        DropDown drop = new DropDown();
        CreateP2 nuevo = new CreateP2();
        ReadP2 read = new ReadP2();
        SearchFederacion buscar = new SearchFederacion();
        SearchP2 verificar = new SearchP2();
        ModeloP2 modelo = new ModeloP2();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                fadn.Text = federacion;
                anio.Text = ano;
                Message.Visible = false;
                lblNombreIngreso.Text = "CREAR NUEVO PROYECTO DE INGRESOS";
                drop.Drop_TipoProyecto(DropTipoProyecto);
                drop.Drop_Proyecto(DropProyecto, 0);
                drop.Drop_CodigoProyecto(DropRenglonProyecto, 0);
                verificarmonto.Visible = false;
                CargarGrid1();
            }
        }

        public void CargarGrid1()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (read.Part9Read().Rows.Count != 0)
            {
                gvP1.DataSource = read.Part9Read();
                gvP1.DataBind();
                gvp4.DataSource = read.Part10Read();
                gvp4.DataBind();
                gvP3.DataSource = read.TotalP2Read(federacion, ano);
                gvP3.DataBind();
            }
        }

        protected void DropTipoProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Proyecto(DropProyecto, int.Parse(DropTipoProyecto.SelectedValue));
        }

        protected void DropProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_CodigoProyecto(DropRenglonProyecto, int.Parse(DropProyecto.SelectedValue));
        }

        protected void DropRenglonProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);
            if (verificar.ExisteP2(int.Parse(DropRenglonProyecto.SelectedValue), federacion, ano) == true)
            {
                limpiar();
                Message.Visible = true;
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.col_uno = Convert.ToDouble(TxtColUno.Value);
            modelo.col_dos = Convert.ToDouble(TxtColDos.Value);
            modelo.col_tres = Convert.ToDouble(TxtColTres.Value);
            modelo.col_cuatro = Convert.ToDouble(TxtColCuatro.Value);
            if (TxtColFinanza.Value == null || TxtColFinanza.Value == "")
            {
                modelo.col_cinco = 0;
            }
            else
            {
                modelo.col_cinco = Convert.ToDouble(TxtColFinanza.Value);
            }
            modelo.fkprograma = int.Parse(DropRenglonProyecto.SelectedValue);
            modelo.fadn = federacion;
            modelo.ano = ano;

            try
            {
                if (verificar.ExisteP2(int.Parse(DropRenglonProyecto.SelectedValue), federacion, ano) == true)
                {
                    limpiar();
                }
                else
                {
                    nuevo.P2Create(modelo);
                    limpiar();
                    CargarGrid1();
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear la Proyeccion','Crear Proyeccion')</script>"
                    + "<script>window.setTimeout(location.href='IndexP2.aspx', 1);</script>");
            }
        }

        protected void gvP1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvP1.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvP2 = e.Row.FindControl("gvP2") as GridView;
                gvP2.DataSource = read.SubyTotalP2Read(int.Parse(customerId), federacion, ano);
                gvP2.DataBind();
            }
        }

        public void limpiar()
        {
            DropRenglonProyecto.SelectedValue = null;
            TxtColUno.Value = null;
            TxtColDos.Value = null;
            TxtColTres.Value = null;
            TxtColCuatro.Value = null;
            TxtColFinanza.Value = null;
            Message.Visible = false;
            verificarmonto.Visible = false;
        }

        protected void gvp4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string customerId = gvp4.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvp5 = e.Row.FindControl("gvp5") as GridView;
                gvp5.DataSource = read.SubyTotal2P2Read(int.Parse(customerId), federacion, ano);
                gvp5.DataBind();
            }
        }

        protected void Verficar_Click(object sender, EventArgs e)
        {
            try
            {
                verificarmonto.Visible = false;

                double monto_50 = (double.Parse(TxtColCuatro.Value) * 50) / 100;
                double restante = (double.Parse(TxtColCuatro.Value) - double.Parse(TxtColDos.Value)) - double.Parse(TxtColTres.Value);

                if (double.Parse(TxtColUno.Value) == monto_50)
                {
                    TxtColUno.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    TxtColUno.Attributes.Add(" style", "color: red;");
                }

                double monto_30 = (double.Parse(TxtColCuatro.Value) * 30) / 100;

                 if (double.Parse(TxtColDos.Value) == monto_30)
                {
                    TxtColDos.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    TxtColDos.Attributes.Add(" style", "color: red;");
                }

                double monto_20 = (double.Parse(TxtColCuatro.Value) * 20) / 100;

                if (double.Parse(TxtColTres.Value) == monto_20)
                {
                    TxtColTres.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    TxtColTres.Attributes.Add(" style", "color: red;");
                }

                double monto_100 = double.Parse(TxtColUno.Value) + double.Parse(TxtColDos.Value) + double.Parse(TxtColTres.Value);

                if (double.Parse(TxtColCuatro.Value) == monto_100)
                {
                    TxtColCuatro.Attributes.Add(" style", "color: green;");
                }
                else
                {
                    TxtColCuatro.Attributes.Add(" style", "color: red;");
                }
            }
            catch
            {
                verificarmonto.Visible = true;
            }
        }

        protected void gvP3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int index = int.Parse(e.Row.RowIndex.ToString());

            if ((e.Row.FindControl("total1") as Label).Text != null) 
            {
                switch (index)
                {
                    case 0:
                        if (double.Parse((e.Row.FindControl("total4") as Label).Text) * 50 / 100 == double.Parse((e.Row.FindControl("total1") as Label).Text))
                        {
                            (e.Row.FindControl("total1") as Label).ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            (e.Row.FindControl("total1") as Label).ForeColor = System.Drawing.Color.Red;
                        }

                        if (double.Parse((e.Row.FindControl("total4") as Label).Text) * 30 / 100 == double.Parse((e.Row.FindControl("total2") as Label).Text))
                        {
                            (e.Row.FindControl("total2") as Label).ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            (e.Row.FindControl("total2") as Label).ForeColor = System.Drawing.Color.Red;
                        }

                        if (double.Parse((e.Row.FindControl("total4") as Label).Text) * 20 / 100 == double.Parse((e.Row.FindControl("total3") as Label).Text))
                        {
                            (e.Row.FindControl("total3") as Label).ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            (e.Row.FindControl("total3") as Label).ForeColor = System.Drawing.Color.Red;
                        }

                        double suma = double.Parse((e.Row.FindControl("total1") as Label).Text) + double.Parse((e.Row.FindControl("total2") as Label).Text) + double.Parse((e.Row.FindControl("total3") as Label).Text);
                        if (suma == double.Parse((e.Row.FindControl("total4") as Label).Text))
                        {
                            (e.Row.FindControl("total4") as Label).ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            (e.Row.FindControl("total4") as Label).ForeColor = System.Drawing.Color.Red;
                        }
                        break;
                }
            }
        }
    }
}