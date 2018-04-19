﻿using System;
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

            modelo.col_uno = Convert.ToDouble(TxtColUno.Text);
            modelo.col_dos = Convert.ToDouble(TxtColDos.Text);
            modelo.col_tres = Convert.ToDouble(TxtColTres.Text);
            modelo.col_cuatro = Convert.ToDouble(TxtColCuatro.Text);
            if (TxtColFinanza.Text == null || TxtColFinanza.Text == "")
            {
                modelo.col_cinco = 0;
            }
            else
            {
                modelo.col_cinco = Convert.ToDouble(TxtColFinanza.Text);
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
            TxtColUno.Text = null;
            TxtColDos.Text = null;
            TxtColTres.Text = null;
            TxtColCuatro.Text = null;
            TxtColFinanza.Text = null;
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

                double monto_50 = (double.Parse(TxtColCuatro.Text) * 50) / 100;
                double restante = (double.Parse(TxtColCuatro.Text) - double.Parse(TxtColDos.Text)) - double.Parse(TxtColTres.Text);

                if (double.Parse(TxtColUno.Text) == monto_50)
                {
                    TxtColUno.ForeColor = System.Drawing.Color.Green;
                }
                else if (double.Parse(TxtColUno.Text) >= 0 && double.Parse(TxtColUno.Text) < restante)
                {
                    TxtColUno.ForeColor = System.Drawing.Color.Orange;
                }
                else
                {
                    TxtColUno.ForeColor = System.Drawing.Color.Red;
                }

                double monto_30 = (double.Parse(TxtColCuatro.Text) * 30) / 100;

                if (double.Parse(TxtColDos.Text) >= 0 && double.Parse(TxtColUno.Text) < monto_30)
                {
                    TxtColDos.ForeColor = System.Drawing.Color.Orange;
                }
                else if (double.Parse(TxtColDos.Text) == monto_30)
                {
                    TxtColDos.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    TxtColDos.ForeColor = System.Drawing.Color.Red;
                }

                double monto_20 = (double.Parse(TxtColCuatro.Text) * 20) / 100;

                if (double.Parse(TxtColTres.Text) >= 0 && double.Parse(TxtColUno.Text) < monto_20)
                {
                    TxtColTres.ForeColor = System.Drawing.Color.Orange;
                }
                else if (double.Parse(TxtColTres.Text) == monto_20)
                {
                    TxtColTres.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    TxtColTres.ForeColor = System.Drawing.Color.Red;
                }

                double monto_100 = double.Parse(TxtColUno.Text) + double.Parse(TxtColDos.Text) + double.Parse(TxtColTres.Text);

                if (double.Parse(TxtColCuatro.Text) == monto_100)
                {
                    TxtColCuatro.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    TxtColCuatro.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                verificarmonto.Visible = true;
            }
        }
    }
}