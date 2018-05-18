﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.Read;
using PATOnline.Controller.Create;
using PATOnline.Controller.DropdownList;
using PATOnline.DBConnection;
using PATOnline.Models;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;

namespace PATOnline.Views.DirigentesFADN
{
    public partial class CrearOrgano : System.Web.UI.Page
    {
        public string federacion = null;
        ReadDirigencia all = new ReadDirigencia();
        CreateDirigencia nuevo = new CreateDirigencia();
        DropDown drop = new DropDown();
        ConexionMysql mysql = new ConexionMysql();
        ModeloDirigencia modelo = new ModeloDirigencia();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                lbl.Text = "CREAR ÓRGANO DISCIPLINARIO";
                lblInfo.Text = "MOSTRAR INFORMACIÓN DE ÓRGANO DISCIPLINARIO";
                drop.Drop_Cargo(DropCargo);
                CargarGrid1();
            }
        }

        public void CargarGrid1()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all.DirigenciaRead(2, federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.DirigenciaRead(2, federacion, ano);
                gvListadoInfo.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListadoInfo.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoInfo.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListadoInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo.PageIndex = e.NewPageIndex;
            CargarGrid1();
        }

        protected void gvListadoInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoInfo.Rows[index];
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            int sumar_dias = 365 * (int.Parse(TxtPeriodo.Value)*4);
            modelo.fk_cargo = int.Parse(DropCargo.SelectedValue);
            modelo.nombre1 = TxtNombre1.Value;
            modelo.nombre2 = TxtNombre2.Value;
            modelo.apellido1 = TxtApellido1.Value;
            modelo.apellido2 = TxtApellido2.Value;
            modelo.inicio = TxtFecha.Text;
            modelo.fin = sumar_dias;
            modelo.periodo = int.Parse(TxtPeriodo.Value);
            modelo.fk_persona = 2;
            modelo.fk_estado = 1;
            modelo.fadn = federacion;
            modelo.anio = ano;

            try
            {
                nuevo.DirigenciaCreate(modelo);
                CargarGrid1();
                limpiar();
            }
            catch
            {
                Response.Write("<script>window.alert('Error al agregar registro al Organo','Crear Organo')" +
                ";</script>" + "<script>window.setTimeout(location.href='DirigenciaDeportiva.aspx', 1);</script>");
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            limpiar();
            Response.Redirect("DirigenciaDeportiva.aspx");
        }

        public void limpiar()
        {
            DropCargo.SelectedValue = null;
            DropCargo.Attributes.Clear();
            TxtNombre1.Value = null;
            TxtNombre2.Value = null;
            TxtApellido1.Value = null;
            TxtApellido2.Value = null;
            TxtFecha.Text = null;
            TxtPeriodo.Value = null;
        }
    }
}