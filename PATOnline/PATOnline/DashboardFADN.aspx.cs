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
        graficasPAT grafica = new graficasPAT();
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
                Response.Redirect("~/Views/IntroBase/IntroduccionBasesLegales.aspx");
            }

            gridFederacionAsignado.Columns[0].Visible = false;
        }

        protected string graficasAprobadoRechazadoIntroduccion()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaAprobadoRechazadoIntroducccion(Session["Usuario"].ToString(), Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaAprobadoRechazadoIntroducccion(Session["Usuario"].ToString(), Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos="";
            strDatos = "[['Documentos PAT','Aprobado','Rechazado'],";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" +dr[0] + "'" + "," + "'" + dr[1] + "'" + "," + dr[2];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;
        }

        public string federacionGrafica()
        {
            if(Session["FederacionAsignada"] != null)
            {
                return "'" + Session["FederacionAsignada"].ToString() + "'";
            }
            else
            {
                return "'" + Session["Federacion"].ToString() + "'";
            }
        }
    }
}