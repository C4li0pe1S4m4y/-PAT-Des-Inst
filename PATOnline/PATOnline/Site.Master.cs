using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using MySql.Data.MySqlClient;
using PATOnline.Controller.Search;
using PATOnline.Controller.ClasesBD;
using System.Data;

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
                            case "ASIGNAR FADN":
                                OPCIONES_PAT.Visible = true;
                                ASIGNAR_FADN.Visible = true;
                                ASIGNAR_FADN.HRef = "~/Views/AsignarFADN/AsignarUsuarioFADN.aspx";
                                break;
                            case "ADMINISTRACION PAT":
                                OPCIONES_PAT.Visible = true;
                                ADMINISTRACIÓN_PAT.Visible = true;
                                ADMINISTRACIÓN_PAT.HRef = "~/Views/AdministracionPAT/AdministracionPAT.aspx";
                                break;
                            case "ADMINISTRACION PARTE 3":
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
                            case "INTRODUCCION":
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
                                DIRIGENCIA_DEPORTIVA.HRef = "~/Views/DirigentesFADN/DirigenteFADN.aspx";
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
                            case "P2: EGRESOS POR RENGLON":
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
                                CPEINDEX.Visible = true;
                                CPE.Visible = true;
                                CPE.HRef = "~/Views/CPE/IndexCPE.aspx";
                                break;
                            case "PE1: GAD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                CPEINDEX.Visible = true;
                                PE1_GAD.Visible = true;
                                PE1_GAD.HRef = "~/Views/CPE/IndexPE1.aspx";
                                break;
                            case "PE2: AGP":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                CPEINDEX.Visible = true;
                                PE2_AGP.Visible = true;
                                PE2_AGP.HRef = "~/Views/CPE/IndexPE2.aspx";
                                break;


                            case "C1":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C1INDEX.Visible = true;
                                C1.Visible = true;
                                C1.HRef = "~/Views/C1/IndexC1.aspx";
                                break;
                            case "C1.1: DCH":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C1INDEX.Visible = true;
                                C11_DCH.Visible = true;
                                C11_DCH.HRef = "~/Views/C1/IndexC1_1.aspx";
                                break;


                            case "C2":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C2INDEX.Visible = true;
                                C2.Visible = true;
                                C2.HRef = "~/Views/C2/IndexC2.aspx";
                                break;
                            case "C2.1: AFDF":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C2INDEX.Visible = true;
                                C21_AFDF.Visible = true;
                                C21_AFDF.HRef = "~/Views/C2/IndexC2_1.aspx";
                                break;
                            case "C2.2: PAD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C2INDEX.Visible = true;
                                C22_PAD.Visible = true;
                                C22_PAD.HRef = "~/Views/C2/IndexC2_2.aspx";
                                break;
                            case "C2.3: AFDPD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C2INDEX.Visible = true;
                                C23_AFDPD.Visible = true;
                                C23_AFDPD.HRef = "~/Views/C2/IndexC2_3.aspx";
                                break;


                            case "C3":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C3INDEX.Visible = true;
                                C3.Visible = true;
                                C3.HRef = "~/Views/C3/IndexC3.aspx";
                                break;
                            case "C3.1: SCN":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C3INDEX.Visible = true;
                                C31_SCN.Visible = true;
                                C31_SCN.HRef = "~/Views/C3/IndexC3_1.aspx";
                                break;
                            case "C3.2: SJDN":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C3INDEX.Visible = true;
                                C32_SJDN.Visible = true;
                                C32_SJDN.HRef = "~/Views/C3/IndexC3_2.aspx";
                                break;

                            case "C4":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C4INDEX.Visible = true;
                                C4.Visible = true;
                                C4.HRef = "~/Views/C4/IndexC4.aspx";
                                break;
                            case "C4.1: CEAPD":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C4INDEX.Visible = true;
                                C41_CEAPD.Visible = true;
                                C41_CEAPD.HRef = "~/Views/C4/IndexC4_1.aspx";
                                break;
                            case "C4.2: CP":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C4INDEX.Visible = true;
                                C42_CP.Visible = true;
                                C42_CP.HRef = "~/Views/C4/IndexC4_2.aspx";
                                break;
                            case "C4.3: CI":
                                PAT.Visible = true;
                                PARTE_3.Visible = true;
                                C4INDEX.Visible = true;
                                C43_CI.Visible = true;
                                C43_CI.HRef = "~/Views/C4/IndexC4_3.aspx";
                                break;
                        }
                    }
                }
            }
            mysql.CerrarConexion();

            if (Session["Rol"].ToString() == "Administrador")
            {
                DASHBOARD.HRef = "~/DashboardAdmin.aspx";
            }
            else
            {
                DASHBOARD.HRef = "~/DashboardFADN.aspx";
            }
        }

        public void EsconderMenu()
        {
            SEGURIDAD.Visible = false;
            USUARIO.Visible = false;
            ROL_Y_PERMISOS.Visible = false;

            OPCIONES_PAT.Visible = false;
            FADN.Visible = false;
            ASIGNAR_FADN.Visible = false;
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
            CPEINDEX.Visible = false;
            CPE.Visible = false;
            PE1_GAD.Visible = false;
            PE2_AGP.Visible = false;
            C1INDEX.Visible = false;
            C1.Visible = false;
            C11_DCH.Visible = false;
            C2INDEX.Visible = false;
            C2.Visible = false;
            C21_AFDF.Visible = false;
            C22_PAD.Visible = false;
            C23_AFDPD.Visible = false;
            C3INDEX.Visible = false;
            C3.Visible = false;
            C31_SCN.Visible = false;
            C32_SJDN.Visible = false;
            C4INDEX.Visible = false;
            C4.Visible = false;
            C41_CEAPD.Visible = false;
            C42_CP.Visible = false;
            C43_CI.Visible = false;
        }

        public void countarInformacion()
        {
            DataTable data = new DataTable();
            IntroduccionBaseLegal intro = new IntroduccionBaseLegal();
            Organigrama organi = new Organigrama();
            DirigenciaDeportivas dir = new DirigenciaDeportivas();
            PuestoLogroAnalisisBrecha logrobrecha = new PuestoLogroAnalisisBrecha();
            ResultadosPotencias resultpoten = new ResultadosPotencias();
            FODABE fodabe = new FODABE();
            P1Ingresos p1 = new P1Ingresos();
            P2EgresosRenglon p2 = new P2EgresosRenglon();
            P3EgresosActividad p3 = new P3EgresosActividad();
            CPEAccion cpe = new CPEAccion();
            PE1 pe1 = new PE1();
            PE2 pe2 = new PE2();
            C1Accion c1 = new C1Accion();
            C1_1 c11 = new C1_1();
            C2Accion c2 = new C2Accion();
            C2_1 c21 = new C2_1();
            C2_2 c22 = new C2_2();
            C2_3 c23 = new C2_3();
            C3Accion c3 = new C3Accion();
            C3_1 c31 = new C3_1();
            C3_2 c32 = new C3_2();
            C4Accion c4 = new C4Accion();
            C4_1 c41 = new C4_1();
            C4_2 c42 = new C4_2();
            C4_3 c43 = new C4_3();

            switch (Session["Rol"].ToString())
            {
                case "Usuario Interno de FADN":
                    data = intro.IBLRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countIntroduccion.Text = data.Rows.Count.ToString();

                    data = organi.OrgranigramaRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countOrganigrama.Text = data.Rows.Count.ToString();

                    data = dir.DirigenciaRead(1, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countDirigente.Text = "0";
                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));
                    else
                        countDirigente.Text = "0";

                    data = dir.DirigenciaRead(2, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = dir.DirigenciaRead(3, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = dir.DirigenciaRead(4, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = dir.DirigenciaRead(5, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = logrobrecha.PuestoLogradoRead(Session["Federacion"].ToString(), 1);
                    countLogroBrecha.Text = "0";
                    if (data.Rows.Count > 0)
                        countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));
                    else
                        countLogroBrecha.Text = "0";

                    data = logrobrecha.BrechaRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);

                    if (data.Rows.Count > 0)
                        countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = resultpoten.ResultadoRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countResultadoPotencia.Text = "0";
                    if (data.Rows.Count > 0)
                        countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));
                    else
                        countResultadoPotencia.Text = "0";

                    data = resultpoten.PotenciaRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);

                    if (data.Rows.Count > 0)
                        countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = fodabe.FODABERead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countFODABE.Text = data.Rows.Count.ToString();

                    data = p1.ContaP1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countP1.Text = data.Rows.Count.ToString();

                    data = p2.ContarP2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countP2.Text = data.Rows.Count.ToString();

                    data = p3.P3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countP3.Text = data.Rows.Count.ToString();

                    data = cpe.CPERead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countCPE.Text = data.Rows.Count.ToString();

                    data = pe1.PE1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countPE1.Text = data.Rows.Count.ToString();

                    data = pe2.PE2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countPE2.Text = data.Rows.Count.ToString();

                    data = c1.C1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC1.Text = data.Rows.Count.ToString();

                    data = c11.C1_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC11.Text = data.Rows.Count.ToString();

                    data = c2.C2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC2.Text = data.Rows.Count.ToString();

                    data = c21.C2_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC21.Text = data.Rows.Count.ToString();

                    data = c22.C2_2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC22.Text = data.Rows.Count.ToString();

                    data = c23.C2_3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC23.Text = data.Rows.Count.ToString();

                    data = c3.C3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC3.Text = data.Rows.Count.ToString();

                    data = c31.C3_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC31.Text = data.Rows.Count.ToString();

                    data = c32.C3_2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC32.Text = data.Rows.Count.ToString();

                    data = c4.C4Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC4.Text = data.Rows.Count.ToString();

                    data = c41.C4_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC41.Text = data.Rows.Count.ToString();

                    data = c42.C4_2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC42.Text = data.Rows.Count.ToString();

                    data = c43.C4_3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 1);
                    countC43.Text = data.Rows.Count.ToString();
                    break;

                case "Usuario CE de FADN":
                    data = intro.IBLRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countIntroduccion.Text = data.Rows.Count.ToString();

                    data = organi.OrgranigramaRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countOrganigrama.Text = data.Rows.Count.ToString();

                    data = dir.DirigenciaRead(1, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countDirigente.Text = "0";
                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));
                    else
                        countDirigente.Text = "0";

                    data = dir.DirigenciaRead(2, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = dir.DirigenciaRead(3, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = dir.DirigenciaRead(4, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = dir.DirigenciaRead(5, Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);

                    if (data.Rows.Count > 0)
                        countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = logrobrecha.PuestoLogradoRead(Session["Federacion"].ToString(), 3);
                    countLogroBrecha.Text = "0";
                    if (data.Rows.Count > 0)
                        countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));
                    else
                        countLogroBrecha.Text = "0";

                    data = logrobrecha.BrechaRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);

                    if (data.Rows.Count > 0)
                        countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = resultpoten.ResultadoRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countResultadoPotencia.Text = "0";
                    if (data.Rows.Count > 0)
                        countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));
                    else
                        countResultadoPotencia.Text = "0";

                    data = resultpoten.PotenciaRead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);

                    if (data.Rows.Count > 0)
                        countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));

                    data = fodabe.FODABERead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countFODABE.Text = data.Rows.Count.ToString();

                    data = p1.ContaP1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countP1.Text = data.Rows.Count.ToString();

                    data = p2.ContarP2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countP2.Text = data.Rows.Count.ToString();

                    data = p3.P3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countP3.Text = data.Rows.Count.ToString();

                    data = cpe.CPERead(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countCPE.Text = data.Rows.Count.ToString();

                    data = pe1.PE1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countPE1.Text = data.Rows.Count.ToString();

                    data = pe2.PE2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countPE2.Text = data.Rows.Count.ToString();

                    data = c1.C1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC1.Text = data.Rows.Count.ToString();

                    data = c11.C1_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC11.Text = data.Rows.Count.ToString();

                    data = c2.C2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC2.Text = data.Rows.Count.ToString();

                    data = c21.C2_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC21.Text = data.Rows.Count.ToString();

                    data = c22.C2_2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC22.Text = data.Rows.Count.ToString();

                    data = c23.C2_3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC23.Text = data.Rows.Count.ToString();

                    data = c3.C3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC3.Text = data.Rows.Count.ToString();

                    data = c31.C3_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC31.Text = data.Rows.Count.ToString();

                    data = c32.C3_2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC32.Text = data.Rows.Count.ToString();

                    data = c4.C4Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC4.Text = data.Rows.Count.ToString();

                    data = c41.C4_1Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC41.Text = data.Rows.Count.ToString();

                    data = c42.C4_2Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC42.Text = data.Rows.Count.ToString();

                    data = c43.C4_3Read(Session["Federacion"].ToString(), DateTime.Now.Year.ToString(), 3);
                    countC43.Text = data.Rows.Count.ToString();
                    break;

                case "Técnico Acompañamiento":
                    if (Session["FederacionAsignada"] != null)
                    {
                        data = intro.IBLRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countIntroduccion.Text = data.Rows.Count.ToString();
                        data = organi.OrgranigramaRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countOrganigrama.Text = data.Rows.Count.ToString();

                        data = dir.DirigenciaRead(1, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countDirigente.Text = "0";
                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));
                        else
                            countDirigente.Text = "0";

                        data = dir.DirigenciaRead(2, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = dir.DirigenciaRead(3, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = dir.DirigenciaRead(4, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = dir.DirigenciaRead(5, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = logrobrecha.PuestoLogradoRead(Session["FederacionAsignada"].ToString(), 6);
                        countLogroBrecha.Text = "0";
                        if (data.Rows.Count > 0)
                            countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));
                        else
                            countLogroBrecha.Text = "0";

                        data = logrobrecha.BrechaRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);

                        if (data.Rows.Count > 0)
                            countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = resultpoten.ResultadoRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countResultadoPotencia.Text = "0";
                        if (data.Rows.Count > 0)
                            countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));
                        else
                            countResultadoPotencia.Text = "0";

                        data = resultpoten.PotenciaRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);

                        if (data.Rows.Count > 0)
                            countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = fodabe.FODABERead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countFODABE.Text = data.Rows.Count.ToString();

                        data = p1.ContaP1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countP1.Text = data.Rows.Count.ToString();

                        data = p2.ContarP2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countP2.Text = data.Rows.Count.ToString();

                        data = p3.P3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countP3.Text = data.Rows.Count.ToString();

                        data = cpe.CPERead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countCPE.Text = data.Rows.Count.ToString();

                        data = pe1.PE1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countPE1.Text = data.Rows.Count.ToString();

                        data = pe2.PE2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countPE2.Text = data.Rows.Count.ToString();

                        data = c1.C1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC1.Text = data.Rows.Count.ToString();

                        data = c11.C1_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC11.Text = data.Rows.Count.ToString();

                        data = c2.C2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC2.Text = data.Rows.Count.ToString();

                        data = c21.C2_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC21.Text = data.Rows.Count.ToString();

                        data = c22.C2_2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC22.Text = data.Rows.Count.ToString();

                        data = c23.C2_3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC23.Text = data.Rows.Count.ToString();

                        data = c3.C3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC3.Text = data.Rows.Count.ToString();

                        data = c31.C3_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC31.Text = data.Rows.Count.ToString();

                        data = c32.C3_2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC32.Text = data.Rows.Count.ToString();

                        data = c4.C4Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC4.Text = data.Rows.Count.ToString();

                        data = c41.C4_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC41.Text = data.Rows.Count.ToString();

                        data = c42.C4_2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC42.Text = data.Rows.Count.ToString();

                        data = c43.C4_3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 6);
                        countC43.Text = data.Rows.Count.ToString();
                    }
                    break;

                case "Técnico Evaluación":
                    if (Session["FederacionAsignada"] != null)
                    {
                        data = intro.IBLRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countIntroduccion.Text = data.Rows.Count.ToString();
                        data = organi.OrgranigramaRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countOrganigrama.Text = data.Rows.Count.ToString();

                        data = dir.DirigenciaRead(1, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countDirigente.Text = "0";
                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));
                        else
                            countDirigente.Text = "0";

                        data = dir.DirigenciaRead(2, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = dir.DirigenciaRead(3, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = dir.DirigenciaRead(4, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = dir.DirigenciaRead(5, Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);

                        if (data.Rows.Count > 0)
                            countDirigente.Text = Convert.ToString(int.Parse(countDirigente.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = logrobrecha.PuestoLogradoRead(Session["FederacionAsignada"].ToString(), 9);
                        countLogroBrecha.Text = "0";
                        if (data.Rows.Count > 0)
                            countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));
                        else
                            countLogroBrecha.Text = "0";

                        data = logrobrecha.BrechaRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);

                        if (data.Rows.Count > 0)
                            countLogroBrecha.Text = Convert.ToString(int.Parse(countLogroBrecha.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = resultpoten.ResultadoRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countResultadoPotencia.Text = "0";
                        if (data.Rows.Count > 0)
                            countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));
                        else
                            countResultadoPotencia.Text = "0";

                        data = resultpoten.PotenciaRead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);

                        if (data.Rows.Count > 0)
                            countResultadoPotencia.Text = Convert.ToString(int.Parse(countResultadoPotencia.Text) + int.Parse(data.Rows.Count.ToString()));

                        data = fodabe.FODABERead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countFODABE.Text = data.Rows.Count.ToString();

                        data = p1.ContaP1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countP1.Text = data.Rows.Count.ToString();

                        data = p2.ContarP2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countP2.Text = data.Rows.Count.ToString();

                        data = p3.P3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countP3.Text = data.Rows.Count.ToString();

                        data = cpe.CPERead(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countCPE.Text = data.Rows.Count.ToString();

                        data = pe1.PE1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countPE1.Text = data.Rows.Count.ToString();

                        data = pe2.PE2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countPE2.Text = data.Rows.Count.ToString();

                        data = c1.C1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC1.Text = data.Rows.Count.ToString();

                        data = c11.C1_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC11.Text = data.Rows.Count.ToString();

                        data = c2.C2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC2.Text = data.Rows.Count.ToString();

                        data = c21.C2_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC21.Text = data.Rows.Count.ToString();

                        data = c22.C2_2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC22.Text = data.Rows.Count.ToString();

                        data = c23.C2_3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC23.Text = data.Rows.Count.ToString();

                        data = c3.C3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC3.Text = data.Rows.Count.ToString();

                        data = c31.C3_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC31.Text = data.Rows.Count.ToString();

                        data = c32.C3_2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC32.Text = data.Rows.Count.ToString();

                        data = c4.C4Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC4.Text = data.Rows.Count.ToString();

                        data = c41.C4_1Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC41.Text = data.Rows.Count.ToString();

                        data = c42.C4_2Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC42.Text = data.Rows.Count.ToString();

                        data = c43.C4_3Read(Session["FederacionAsignada"].ToString(), DateTime.Now.Year.ToString(), 9);
                        countC43.Text = data.Rows.Count.ToString();
                    }
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pageTitle.Text = "PATOnline";
                if (Session["FederacionAsignada"] != null)
                {
                    federacion.Text = Session["FederacionAsignada"].ToString();
                }
                lblUsuario.Text = Convert.ToString(Session["Usuario"]);
                CargarLogotipoFederacion(lblUsuario.Text);
                EsconderMenu();
                CargarMenu();
                Session["Menu"] = "0";
                countarInformacion();
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
            if (this.Session["Usuario"] == null || this.Session["Usuario"].ToString() == "")
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

        public void CargarLogotipoFederacion(string usuario)
        {
            SearchFederacion buscar_usuario = new SearchFederacion();
            string nombre = Convert.ToString(buscar_usuario.NombreFederacion(usuario));

            SearchLogotipo buscar_logo = new SearchLogotipo();
            logo.ImageUrl = Convert.ToString(buscar_logo.LogotipoFederacion(nombre));
        }

        protected void titleCorto_Click(object sender, EventArgs e)
        {
            pageTitle.Text = "PATOnline";
        }

        protected void titleLargo_Click(object sender, EventArgs e)
        {
            pageTitle.Text = "PAT";
        }
    }

}