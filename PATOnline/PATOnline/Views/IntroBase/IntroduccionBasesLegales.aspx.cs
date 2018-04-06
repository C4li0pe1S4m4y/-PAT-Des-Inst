using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using PATOnline.Controller.Read;
using PATOnline.DBConnection;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;

namespace PATOnline.Views.IntroBase
{
    public partial class IntroduccionBasesLegales : System.Web.UI.Page
    {
        ConexionMysql mysql = new ConexionMysql();
        ReadIBL all = new ReadIBL();
        public string SubTitulo = "MOSTRAR INFORMACIÓN";
        public string federacion = "";
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
                lblSubTitulo.Text = SubTitulo;
            }
        }

        protected void CargarGrid()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all.IBLRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.IBLRead(federacion, ano);
                gvListadoInfo.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListadoInfo.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoInfo.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListadoInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvListadoInfo_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoInfo.Rows[index];
            }
        }

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
    }
}