using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Drawing;
using System.Data;

using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using PATOnline.Controller.Read;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Models;
using PATOnline.DBConnection;
using PATOnline.Controller.Search;
using MySql.Data.MySqlClient;

namespace PATOnline.Views.FODA
{
    public partial class FODA : System.Web.UI.Page
    {
        public string federacion = null;
        ConexionMysql mysql = new ConexionMysql();
        ReadFodaBEstrategica all = new ReadFodaBEstrategica();
        ModeloFodaBEstrategica modelo = new ModeloFodaBEstrategica();
        CreateFodaBEstrategica nuevo = new CreateFodaBEstrategica();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            lblSubTitulo.Text = "MOSTRAR INFORMACIÓN";
            lblgvListadoInfo.Text = "FODA";
            lblgvListadoInfo2.Text = "BASE ESTRATÉGICA";
            CargarGrid1();
            CargarGrid2();
        }

        public void CargarGrid1()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all.FODABEstrategicaRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.FODABEstrategicaRead(federacion, ano);
                gvListadoInfo.DataBind();

                //Attribute to show the Plus Minus Button.
                gvListadoInfo.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                gvListadoInfo.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
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

            if (all.FODABEstrategicaRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo2.DataSource = all.FODABEstrategicaRead(federacion, ano);
                gvListadoInfo2.DataBind();

                //Attribute to show the Plus Minus Button.
                gvListadoInfo2.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                gvListadoInfo2.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                gvListadoInfo2.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoInfo2.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                gvListadoInfo2.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
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

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo.PageIndex = e.NewPageIndex;
            CargarGrid1();
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
        protected void gvListadoInfo2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo2.PageIndex = e.NewPageIndex;
            CargarGrid2();
        }
    }
}