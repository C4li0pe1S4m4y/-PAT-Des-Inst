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

namespace PATOnline.Views.FADN
{
    public partial class FADN : System.Web.UI.Page
    {
        public string SubTitulo = "MOSTRAR INFORMACIÓN DE FEDERACIÓN / ASOSIACIÓN";
        ReadFADN all = new ReadFADN();
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
            if(all.FADNRead(this.Session["Usuario"].ToString()).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.FADNRead(this.Session["Usuario"].ToString());
                gvListadoInfo.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListadoInfo.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoInfo.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListadoInfo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvListadoInfo_RowCommand1(object sender, GridViewCommandEventArgs e)
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