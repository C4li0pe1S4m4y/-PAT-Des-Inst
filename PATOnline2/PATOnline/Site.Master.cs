using System.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using MySql.Data.MySqlClient;
using PATOnline.DBConnection;
using PATOnline.Controller.Search;

namespace PATOnline
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    Response.Redirect("~/Login.aspx");
                    //throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        public string menu = null;
        public void CargarMenu()
        {
            var mysql = new DBConnection.ConexionMysql();
            string query = String.Format("SELECT m.nombre as menu " +
            "FROM seg_usuario u INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_menu m ON m.idmenu = mb.fkmenu " +
            "WHERE u.username = '{0}'; ", lblUsuario.Text);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            using (var buscar = consulta.ExecuteReader())
            {
                using (buscar)
                {
                    while (buscar.Read())
                    {
                        menu = buscar["menu"].ToString();

                        switch (menu)
                        {
                            case "USUARIO":
                                SEGURIDAD.Visible = true;
                                USUARIO.Visible = true;
                                USUARIO.HRef = "~/Views/Usuarios/Usuario";
                                break;
                            case "ROL Y PERMISOS":
                                SEGURIDAD.Visible = true;
                                ROL_Y_PERMISOS.Visible = true;
                                ROL_Y_PERMISOS.HRef = "~/Views/RolPermiso/RolPermiso.aspx";
                                break;


                            case "FADN":
                                OPCIONES_PAT.Visible = true;
                                FADN.Visible = true;
                                FADN.HRef = "~/Views/FADN/FADN.aspx";
                                break;
                            case "ADMINISTRACIÓN PAT":
                                OPCIONES_PAT.Visible = true;
                                ADMINISTRACIÓN_PAT.Visible = true;
                                ADMINISTRACIÓN_PAT.HRef = "~/Views/AdministracionPAT/AdministracionPAT.aspx";
                                break;
                            case "ADMINISTRACIÓN PARTE 3":
                                OPCIONES_PAT.Visible = true;
                                ADMINISTRACIÓN_PARTE_3.Visible = true;
                                ADMINISTRACIÓN_PARTE_3.HRef = "~/Views/AdministracionPAT/AdministracionParte3.aspx";
                                break;


                            case "PORTADA":
                                PAT.Visible = true;
                                PARTE_1.Visible = true;
                                PORTADA.Visible = true;
                                PORTADA.HRef = "~/Views/Portada/PortadaPAT.aspx";
                                break;
                            case "INTRODUCCIÓN":
                                PAT.Visible = true;
                                PARTE_1.Visible = true;
                                INTRODUCCIÓN.Visible = true;
                                INTRODUCCIÓN.HRef = "~/Views/IntroBase/IntroduccionBasesLegales.aspx";
                                break;
                            case "ORGANIGRAMA":
                                PAT.Visible = true;
                                PARTE_1.Visible = true;
                                ORGANIGRAMA.Visible = true;
                                ORGANIGRAMA.HRef = "~/Views/Cronograma/Organigrama.aspx";
                                break;
                            case "DIRIGENCIA DEPORTIVA":
                                PAT.Visible = true;
                                PARTE_1.Visible = true;
                                DIRIGENCIA_DEPORTIVA.Visible = true;
                                DIRIGENCIA_DEPORTIVA.HRef = "~/Views/DirigentesFADN/DirigenciaDeportiva.aspx";
                                break;
                            case "LOGROS Y BRECHAS":
                                PAT.Visible = true;
                                PARTE_1.Visible = true;
                                LOGROS_Y_BRECHAS.Visible = true;
                                LOGROS_Y_BRECHAS.HRef = "~/Views/LogroBrecha/LogroBrecha.aspx";
                                break;
                            case "PRINCIPALES POTENCIAS":
                                PAT.Visible = true;
                                PARTE_1.Visible = true;
                                PRINCIPALES_POTENCIAS.Visible = true;
                                PRINCIPALES_POTENCIAS.HRef = "~/Views/ResultadoPotencia/ResultadoPotencia.aspx";
                                break;
                            case "FODA":
                                PAT.Visible = true;
                                PARTE_1.Visible = true;
                                FODA.Visible = true;
                                FODA.HRef = "~/Views/FODABEstrategica/FODABEstrategica.aspx";
                                break;


                            case "P1: INGRESOS":
                                PAT.Visible = true;
                                PARTE_2.Visible = true;
                                P1_INGRESOS.Visible = true;
                                P1_INGRESOS.HRef = "~/Views/P1/IndexP1.aspx";
                                break;
                            case "P2: EGRESOS POR RENGLÓN":
                                PAT.Visible = true;
                                PARTE_2.Visible = true;
                                P2_EGRESOS_POR_RENGLÓN.Visible = true;
                                P2_EGRESOS_POR_RENGLÓN.HRef = "~/Views/P2/IndexP2.aspx";
                                break;
                            case "P3: EGRESOS POR ACTIVIDAD":
                                PAT.Visible = true;
                                PARTE_2.Visible = true;
                                P3_EGRESOS_POR_ACTIVIDAD.Visible = true;
                                P3_EGRESOS_POR_ACTIVIDAD.HRef = "~/Views/P3/IndexP3.aspx";
                                break;


                            case "CPE":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                CPE.Visible = true;
                                CPE.HRef = "~/Views/CPE/IndexCPE.aspx";
                                break;
                            case "PE1: GAD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                PE1_GAD.Visible = true;
                                PE1_GAD.HRef = "~/Views/CPE/IndexPE1.aspx";
                                break;
                            case "PE2: AGP":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                PE2_AGP.Visible = true;
                                PE2_AGP.HRef = "~/Views/CPE/IndexPE2.aspx";
                                break;


                            case "C1":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C1.Visible = true;
                                C1.HRef = "~/Views/C1/IndexC1.aspx";
                                break;
                            case "C1.1: DCH":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C11_DCH.Visible = true;
                                C11_DCH.HRef = "~/Views/C1/IndexC1_1.aspx";
                                break;


                            case "C2":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C2.Visible = true;
                                C2.HRef = "~/Views/C2/IndexC2.aspx";
                                break;
                            case "C2.1: AFDF":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C21_AFDF.Visible = true;
                                C21_AFDF.HRef = "~/Views/C2/IndexC2_1.aspx";
                                break;
                            case "C2.2: PAD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C22_PAD.Visible = true;
                                C22_PAD.HRef = "~/Views/C2/IndexC2_2.aspx";
                                break;
                            case "C2.3: AFDPD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C23_AFDPD.Visible = true;
                                C23_AFDPD.HRef = "~/Views/C2/IndexC2_3.aspx";
                                break;


                            case "C3":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C3.Visible = true;
                                C3.HRef = "~/Views/C3/IndexC3.aspx";
                                break;
                            case "C3.1: SCN":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C31_SCN.Visible = true;
                                C31_SCN.HRef = "~/Views/C3/IndexC3_1.aspx";
                                break;
                            case "C3.2: SJDN":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C32_SJDN.Visible = true;
                                C32_SJDN.HRef = "~/Views/C3/IndexC3_2.aspx";
                                break;

                            case "C4":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C4.Visible = true;
                                C4.HRef = "~/Views/C4/IndexC4.aspx";
                                break;
                            case "C4.1: CEAPD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C41_CEAPD.Visible = true;
                                C41_CEAPD.HRef = "~/Views/C4/IndexC4_1.aspx";
                                break;
                            case "C4.2: CP":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C42_CP.Visible = true;
                                C42_CP.HRef = "~/Views/C4/IndexC4_2.aspx";
                                break;
                            case "C4.3: CI":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C43_CI.Visible = true;
                                C43_CI.HRef = "~/Views/C4/IndexC4_3.aspx";
                                break;
                        }
                    }
                }
            }
            mysql.CerrarConexion();
        }

        public void EsconderMenu()
        {
            SEGURIDAD.Visible = false;
            USUARIO.Visible = false;
            ROL_Y_PERMISOS.Visible = false;

            OPCIONES_PAT.Visible = false;
            FADN.Visible = false;
            ADMINISTRACIÓN_PAT.Visible = false;
            ADMINISTRACIÓN_PARTE_3.Visible = false;


            PAT.Visible = false;
            PARTE_1.Visible = false;
            PORTADA.Visible = false;
            INTRODUCCIÓN.Visible = false;
            ORGANIGRAMA.Visible = false;
            DIRIGENCIA_DEPORTIVA.Visible = false;
            LOGROS_Y_BRECHAS.Visible = false;
            PRINCIPALES_POTENCIAS.Visible = false;
            FODA.Visible = false;

            PARTE_2.Visible = false;
            P1_INGRESOS.Visible = false;
            P2_EGRESOS_POR_RENGLÓN.Visible = false;
            P3_EGRESOS_POR_ACTIVIDAD.Visible = false;
            P3_EGRESOS_POR_ACTIVIDAD.HRef = "~/Views/P3/IndexP3.aspx";

            PARTE_3.Visible = false;
            CPE.Visible = false;
            PE1_GAD.Visible = false;
            PE2_AGP.Visible = false;
            C1.Visible = false;
            C11_DCH.Visible = false;
            C2.Visible = false;
            C21_AFDF.Visible = false;
            C22_PAD.Visible = false;
            C23_AFDPD.Visible = false;
            C3.Visible = false;
            C31_SCN.Visible = false;
            C32_SJDN.Visible = false;
            C4.Visible = false;
            C41_CEAPD.Visible = false;
            C42_CP.Visible = false;
            C43_CI.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                lblUsuario.Text = Convert.ToString(Session["Usuario"]);
                EsconderMenu();
                CargarMenu();
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            lblUsuario.Text = null;
            Response.Redirect("~/Login.aspx");
        }

        public int rol;
        protected void Unnamed_Click(object sender, EventArgs e)
        {          
            SearchRol buscar = new SearchRol();
            if(this.Session["Usuario"] == null || this.Session["Usuario"].ToString() == "")
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                rol = int.Parse(buscar.NombreRol(this.Session["Usuario"].ToString()));
                if (rol == 1)
                {
                    Response.Redirect("~/DashboardAdmin.aspx");
                }
                else
                {
                    Response.Redirect("~/DashboardFADN.aspx");
                }
            }
        }
    }

}