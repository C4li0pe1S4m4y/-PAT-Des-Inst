using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using PATOnline.DBConnection;
using PATOnline.Controller.Read;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;

namespace PATOnline.Views.LogroBrecha
{
    public partial class LogroBrecha : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        ReadPuestoLogrado all_puesto = new ReadPuestoLogrado();
        ReadBrecha all_brecha = new ReadBrecha();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPuesto.Text = "Crear Puesto Logro";
            lblBrecha.Text = "Crear Brecha";
            lblSubTitulo.Text = "Mostrar Informacion de Puestos Logrados";
            lbl1.Text = "ANALISIS SOBRE PUESTOS LOGRADOS EN EL MODELO DE EXCELENCIA EN GESTIÓN DEPORTIVA";
            lblGrid.Text = "Mostrar Informacion de Brechas";
            lbl2.Text = "ANALISIS DE BRECHAS CON RESPECTO A LAS CATEGORIAS DEL MEGD " + Convert.ToString(DateTime.Now.Year);
            CargarGrid1();
            CargarGrid2();
        }

        public void CargarGrid1()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all_puesto.PuestoLogradoRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all_puesto.PuestoLogradoRead(federacion, ano);
                gvListadoInfo.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListadoInfo.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoInfo.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListadoInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        public void CargarGrid2()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all_brecha.BrechaRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo2.DataSource = all_brecha.BrechaRead(federacion, ano);
                gvListadoInfo2.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListadoInfo2.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoInfo2.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                gvListadoInfo2.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoInfo2.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                gvListadoInfo2.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                gvListadoInfo2.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListadoInfo2.HeaderRow.TableSection = TableRowSection.TableHeader;
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

        protected void gvListadoInfo2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo2.PageIndex = e.NewPageIndex;
            CargarGrid2();
        }

        protected void gvListadoInfo2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoInfo2.Rows[index];
            }
        }
    }
}