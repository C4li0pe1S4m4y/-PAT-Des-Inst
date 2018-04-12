using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using PATOnline.DBConnection;
using PATOnline.Controller.Read;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;

namespace PATOnline.Views.ResultadoPotencia
{
    public partial class ResultadoPotencia : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        ReadResultado all_resultado = new ReadResultado();
        ReadPontencia all_potencia = new ReadPontencia();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "CREAR RESULTADOS DEPORTIVOS ";
            lblPotencia.Text = "CREAR ANÁLISIS DE PRINCIPALES POTENCIAS ";
            lblInfoResultado.Text = "MOSTRAR INFORMACIÓN DE RESULTADOS DEPORTIVOS";
            lblSubResultado.Text = "RESULTADOS DEPORTIVOS INTERNACIONALES HISTÓRICOS";
            lblInfoPotencia.Text = "MOSTRAR INFORMACIÓN DE ANÁLISIS DE PRINCIPALES POTENCIAS";
            lblSubPotencia.Text = "ANÁLISIS DE PRINCIPALES POTENCIAS POR AREA GEOGRÁFICA PARA LA OBTENCIÓN DE RESULTADOS DEPORTIVOS";
            CargarGrid1();
            CargarGrid2();
        }

        public void CargarGrid1()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all_resultado.ResultadoRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all_resultado.ResultadoRead(federacion, ano);
                gvListadoInfo.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListadoInfo.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoInfo.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListadoInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        public void CargarGrid2()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all_potencia.PotenciaRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo2.DataSource = all_potencia.PotenciaRead(federacion, ano);
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