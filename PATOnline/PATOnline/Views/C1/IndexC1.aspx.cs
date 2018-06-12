﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.Search;
using PATOnline.Controller.Read;
using PATOnline.Controller.Create;
using PATOnline.Controller.DropdownList;
using PATOnline.Models;

namespace PATOnline.Views.C1
{
    public partial class IndexC1 : System.Web.UI.Page
    {
        public string federacion = null;
        DropDown drop = new DropDown();
        ReadFormatoC formato = new ReadFormatoC();
        ReadC1 read = new ReadC1();
        SearchFederacion buscar = new SearchFederacion();
        SearchC1 verficiar = new SearchC1();
        CreateC1 nuevo = new CreateC1();
        ModeloCPE modelo = new ModeloCPE();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                Message.Visible = false;
                lblTitulo2.Text = "CREAR NUEVA ACTIVIDAD";
                drop.Drop_FormatoC(DropFormato, 2);
                CargarGrid1();
            }
        }

        public void CargarGrid1()
        {
            if (formato.FormatoCRead(2, "idformato_c").Rows.Count != 0)
            {
                federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
                string ano = Convert.ToString(DateTime.Now.Year);

                gvP1.DataSource = formato.FormatoCRead(2, "idformato_c");
                gvP1.DataBind();
                gvP3.DataSource = read.C1TotalRead(federacion, ano);
                gvP3.DataBind();
            }
        }

        protected void SaveIngreso_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            modelo.mes1 = int.Parse(TxtEA.Text);
            modelo.mes2 = int.Parse(TxtMA.Text);
            modelo.mess3 = int.Parse(TxtSD.Text);
            modelo.presupuesto = Convert.ToDouble(TxtPresupuesto.Text);
            modelo.fkformato_ce = int.Parse(DropFormato.SelectedValue);
            modelo.fadn = federacion;
            modelo.ano = ano;
            modelo.anual = int.Parse(TxtEA.Text) + int.Parse(TxtMA.Text) + int.Parse(TxtSD.Text);

            if (verficiar.ExisteC1(int.Parse(DropFormato.SelectedValue), federacion, ano) == true)
            {
                limpiar();
                Message.Visible = true;
            }
            else
            {
                nuevo.C1Create(modelo);
                limpiar();
                CargarGrid1();
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
                gvP2.DataSource = read.C1Read(federacion, ano, int.Parse(customerId));
                gvP2.DataBind();
            }
        }

        public void limpiar()
        {
            TxtEA.Text = null;
            TxtMA.Text = null;
            TxtSD.Text = null;
            TxtPresupuesto.Text = null;
            DropFormato.SelectedValue = null;
            Message.Visible = false;
        }
    }
}