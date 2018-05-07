﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Controller.Read;
using PATOnline.Models;

namespace PATOnline.Views.P1
{
    public partial class IndexP1 : System.Web.UI.Page
    {
        public string federacion = null;
        DropDown drop = new DropDown();
        CreateP1 nuevo = new CreateP1();
        CreateIngreso nuevo_codigo = new CreateIngreso();
        SearchFederacion buscar = new SearchFederacion();
        SearchP1 verificar = new SearchP1();
        SearchIngreso existe = new SearchIngreso();
        ModeloP1 modelo = new ModeloP1();
        ModeloIngreso modelo_codigo = new ModeloIngreso();
        ReadP1 read = new ReadP1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);
                fadn.Text = federacion;
                anio.Text = ano;
                Message.Visible = false;
                lblTitulo2.Text = "CREAR NUEVO INGRESO";
                drop.Drop_TipoIngreso(DropTipoIngreso);
                drop.Drop_Ingreso(DropIngreso, 0);
                drop.Drop_CodigoIngreso(DropCodigoIngreso, 0);
                CargarGrid1();
                limpiar();
                drop.Drop_TipoIngreso(DropTipoIngresoCodigo);
                drop.Drop_Ingreso(DropList, 0);
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
                gvP3.DataSource = read.TotalP1Read(federacion, ano);
                gvP3.DataBind();
            }
        }

        protected void DropTipoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNombreIngreso.Text = DropTipoIngreso.SelectedItem.ToString();
            drop.Drop_Ingreso(DropIngreso, int.Parse(DropTipoIngreso.SelectedValue));
        }

        protected void DropIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_CodigoIngreso(DropCodigoIngreso, int.Parse(DropIngreso.SelectedValue));
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.col1 = Convert.ToDouble(TxtColUno.Text);
            modelo.col2 = Convert.ToDouble(TxtColDos.Text);
            modelo.col3 = Convert.ToDouble(TxtColTres.Text);
            modelo.fkingreso = int.Parse(DropCodigoIngreso.SelectedValue);
            modelo.fadn = federacion;
            modelo.ano = ano;

            try
            {
                if(verificar.ExisteP1(int.Parse(DropCodigoIngreso.SelectedValue), federacion, ano) == true)
                {
                    limpiar();
                }
                else
                {
                    nuevo.P1Create(modelo);
                    limpiar();
                    CargarGrid1();
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Error al crear Ingreso','Crear Ingreso')</script>");
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
                if(int.Parse(customerId) != 2)
                {
                    gvP2.DataSource = read.Part11Read(int.Parse(customerId), federacion, ano);
                    gvP2.DataBind();
                }
            }
        }

        public void limpiar()
        {
            DropCodigoIngreso.SelectedValue = null;
            TxtColUno.Text = null;
            TxtColDos.Text = null;
            TxtColTres.Text = null;
            Message.Visible = false;
        }

        protected void DropCodigoIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (verificar.ExisteP1(int.Parse(DropCodigoIngreso.SelectedValue), federacion, ano) == true)
            {
                limpiar();
                Message.Visible = true;
            }       
        }

        protected void SaveCodigo_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            try
            {
                modelo_codigo.codigo = TxtCodigo.Text;
                modelo_codigo.nombre = TxtNombre.Text;
                modelo_codigo.idpadre = int.Parse(DropTipoIngresoCodigo.SelectedValue);
                modelo_codigo.subpadre = int.Parse(DropList.SelectedValue);
                modelo_codigo.fadn = federacion;
                if(existe.ExisteCodigoIngreso(TxtCodigo.Text, federacion) == true)
                {
                    Response.Write("<script>window.alert('El Codigo Ya Existe','Crear Nuevo Codigo')" +
                    ";</script>" + "<script>window.setTimeout(location.href='IndexP1.aspx', 1);</script>");
                }
                else
                {
                    if(existe.ExisteNombreIngreso(TxtNombre.Text, federacion) == true)
                    {
                        Response.Write("<script>window.alert('El Nombre Ya Existe','Crear Nuevo Codigo')" +
                        ";</script>" + "<script>window.setTimeout(location.href='IndexP1.aspx', 1);</script>");
                    }
                    else
                    {
                        nuevo_codigo.IngresoCreate(modelo_codigo);
                        drop.Drop_CodigoIngreso(DropCodigoIngreso, int.Parse(DropIngreso.SelectedValue));
                        CargarGrid1();
                    }
                }
            }
            catch
            {

            }
        }

        protected void DropTipoIngresoCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_Ingreso(DropList, int.Parse(DropTipoIngresoCodigo.SelectedValue));
        }
    }
}