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

namespace PATOnline.Views.RolPermiso
{
    public partial class RolPermiso : System.Web.UI.Page
    {
        public string SubTitulo = "MOSTRAR INFORMACIÓN";
        ReadRolPermiso all = new ReadRolPermiso();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
                    CargarGrid();
                    lblSubTitulo.Text = SubTitulo;
                }
            }
            catch
            {
                Response.Write("<script>window.alert('Problema al cargar la informacion','Error')" +
                ";</script>" + "<script>window.setTimeout(location.href='Login.aspx', 1);</script>");
            }
        }

        protected void CargarGrid()
        {
            if(all.RolPermisoRead().Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.RolPermisoRead();
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