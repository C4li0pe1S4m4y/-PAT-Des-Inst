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
            cargarGrid();
        }

        protected void cargarGrid()
        {
            mostrarAsignados.Visible = false;
            gridFederacionAsignado.Visible = false;
            DataTable data = new DataTable();
            data = rol.RolReadUsuario(Session["Usuario"].ToString());

            if (Session["Rol"].ToString() == "Técnico Acompañamiento" || Session["Rol"].ToString() == "Técnico Evaluación")
            {
                gridFederacionAsignado.DataSource = asignado.FederacionAsigandasRead(id.idUsuario(Session["Usuario"].ToString()));
                gridFederacionAsignado.DataBind();
                data = asignado.FederacionAsigandasRead(id.idUsuario(Session["Usuario"].ToString()));
                if(data.Rows.Count > 0)
                {
                    mostrarAsignados.Visible = true;
                }
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

        protected string graficasAprobadoRechazadoComite()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaAprobadoRechazadoComite(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaAprobadoRechazadoComite(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos="{";
            strDatos = strDatos + "name: 'Aprovado',";
            strDatos = strDatos + "data: [";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + dr[0] + ", ";
                
            }
            strDatos = strDatos + "]},";

            strDatos = strDatos + "{";
            strDatos = strDatos + "name: 'Rechazado',";
            strDatos = strDatos + "data: [";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + dr[1] + ", ";

            }
            strDatos = strDatos + "]}";
            return strDatos;
        }

        protected string graficasAprobadoRechazadoAcompaniamiento()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaAprobadoRechazadoAcompaniamiento(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaAprobadoRechazadoAcompaniamiento(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = "{";
            strDatos = strDatos + "name: 'Aprovado',";
            strDatos = strDatos + "data: [";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + dr[0] + ", ";

            }
            strDatos = strDatos + "]},";

            strDatos = strDatos + "{";
            strDatos = strDatos + "name: 'Rechazado',";
            strDatos = strDatos + "data: [";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + dr[1] + ", ";

            }
            strDatos = strDatos + "]}";
            return strDatos;
        }

        protected string graficasAprobadoRechazadoEvaluador()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaAprobadoRechazadoEvaluador(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaAprobadoRechazadoEvaluador(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = "{";
            strDatos = strDatos + "name: 'Aprovado',";
            strDatos = strDatos + "data: [";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + dr[0] + ", ";

            }
            strDatos = strDatos + "]},";

            strDatos = strDatos + "{";
            strDatos = strDatos + "name: 'Rechazado',";
            strDatos = strDatos + "data: [";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + dr[1] + ", ";

            }
            strDatos = strDatos + "]}";
            return strDatos;
        }

        protected string graficasPorcentajeEstado()
        {
            int cantidad_inicial = 0;
            int cantidad_final = 0;
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaPorcentajeEstado(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaPorcentajeEstado(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                if(cantidad_final > 0)
                {
                    cantidad_inicial++;
                }
                cantidad_final = cantidad_inicial + 1;
                strDatos = strDatos + "{ ";
                strDatos = strDatos + "x: " + cantidad_inicial + ", ";
                strDatos = strDatos + "x2: " + cantidad_final + ", ";
                strDatos = strDatos + "y: " + cantidad_inicial + ", ";
                strDatos = strDatos + "partialFill: " + dr[0] + " }, ";
            }

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

        protected string graficaEstadosPATIntroduccion()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATIntroduccion(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATIntroduccion(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }

        protected string graficaEstadosPATOrganigrama()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATOrganigrama(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATOrganigrama(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }

        protected string graficaEstadosPATDirigencia()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATDirigencia(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATDirigencia(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }

        protected string graficaEstadosPATLogros()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATLogros(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATLogros(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }

        protected string graficaEstadosPATBrechas()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATBrechas(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATBrechas(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }

        protected string graficaEstadosPATPotencia()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATPotencia(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATPotencia(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }

        protected string graficaEstadosPATResultado()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATResultado(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATResultado(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }

        protected string graficaEstadosPATFODA()
        {
            DataTable Datos = new DataTable();
            if (Session["FederacionAsignada"] != null)
            {
                Datos = grafica.graficaEstadosPATFODA(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString());
            }
            else
            {
                Datos = grafica.graficaEstadosPATFODA(Session["Federacion"].ToString(), DateTime.Now.Year.ToString());
            }

            string strDatos = " ";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[ " + "'" + dr[0] + "'" + ", " + dr[1] + " ], ";
            }

            return strDatos;
        }
    }
}