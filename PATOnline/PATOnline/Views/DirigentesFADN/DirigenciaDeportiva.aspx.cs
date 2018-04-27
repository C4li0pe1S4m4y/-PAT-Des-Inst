using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.Read;
using PATOnline.DBConnection;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;

namespace PATOnline.Views.DirigentesFADN
{
    public partial class DirigenciaDeportiva : System.Web.UI.Page
    {
        public string federacion = null;
        ReadComiteEjectuvio all = new ReadComiteEjectuvio();
        ConexionMysql mysql = new ConexionMysql();
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            lblAsamblea.Text = "ASAMBLEA DE FADN";
            lblComision.Text = "COMISIÓN TÉCNICO DEPORTIVA";
            lblDirigente.Text = "DIRIGENTES INTERNACIONALES";
            lblInfoComite.Text = "MOSTRAR INFORMACIÓN DEL COMITÉ EJECUTIVO DE FADN";
            lblOrgano.Text = "ÓRGANO DISCIPLINARIO";
            lblPersonal.Text = "PERSONAL TÉCNICO ADMINISTRATIVO";
            CargarGrid1();
        }

        public void CargarGrid1()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));

            if (all.ComiteEjecutivoRead(federacion).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.ComiteEjecutivoRead(federacion);
                gvListadoInfo.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListadoInfo.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoInfo.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                gvListadoInfo.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
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
    }
}