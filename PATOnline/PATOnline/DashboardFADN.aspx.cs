using System;
using PATOnline.Controller.ClasesBD;
using PATOnline.Controller.Read;
using System.Web.UI.WebControls;
using System.Data;

namespace PATOnline
{
    public partial class DashboardFADN : System.Web.UI.Page
    {
        ReadRolPermiso rol = new ReadRolPermiso();
        Usuario id = new Usuario();
        FederacionAsiganada asignado = new FederacionAsiganada();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            gridFederacionAsignado.Visible = false;
            DataTable data = new DataTable();
            data = rol.RolReadUsuario(Session["Usuario"].ToString());

            if (Session["Rol"].ToString() == "Técnico Acompañamiento" || Session["Rol"].ToString() == "Técnico Evaluación")
            {
                gridFederacionAsignado.DataSource = asignado.FederacionAsigandasRead(id.idUsuario(Session["Usuario"].ToString()));
                gridFederacionAsignado.DataBind();
                gridFederacionAsignado.Visible = true;
                gridFederacionAsignado.Columns[0].Visible = false;
            }
        }

        protected void gridFederacionAsignado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gridFederacionAsignado.Columns[0].Visible = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = gridFederacionAsignado.Rows[index];

            if (e.CommandName == "Asignado")
            {
                this.Session["FederacionAsignada"] = (row.FindControl("idFederacion") as LinkButton).Text;
            }

            gridFederacionAsignado.Columns[0].Visible = false;
        }
    }
}