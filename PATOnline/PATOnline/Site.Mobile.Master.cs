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
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        public void CargarNombreFederacion()
        {
            lblUsuario.Text = Convert.ToString(this.Session["Usuario"]);
            SearchFederacion buscar = new SearchFederacion();
            lblFADN.Text = Convert.ToString(buscar.NombreFederacion(Convert.ToString(this.Session["Usuario"])));
        }

        public void CargarLogotipoFederacion()
        {
            SearchLogotipo buscar = new SearchLogotipo();
            logo.ImageUrl = Convert.ToString(buscar.LogotipoFederacion(lblFADN.Text));
        }

        public string menu = null;
        public void CargarMenu()
        {
            var mysql = new DBConnection.ConexionMysql();
            string query = String.Format("SELECT m.nombre as menu " +
            "FROM seg_usuario u INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_menu m ON m.idmenu = mb.fkmenu " +
            "WHERE u.username = '{0}'; ", this.Session["Usuario"]);
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
                            case "Usuarios":
                                OpcionUsuario.Visible = true;
                                OpcionUsuario.HRef = "~/Views/Usuarios/Usuario";
                                break;
                            case "Rol-Permiso":
                                OpcionRol.Visible = true;
                                OpcionRol.HRef = "~/Views/RolPermiso/RolPermiso.aspx";
                                break;

                            case "FADN":
                                OpcionFADN.Visible = true;
                                OpcionFADN.HRef = "~/Views/FADN/FADN.aspx";
                                break;
                            case "Administracion PAT":
                                OpcionAdministrar.Visible = true;
                                OpcionAdministrar.HRef = "~/Views/AdministracionPAT/AdministracionPAT.aspx";
                                break;

                            case "Portada":
                                OpcionPortada.Visible = true;
                                OpcionPortada.HRef = "~/Views/Portada/PortadaPAT.aspx";
                                break;
                            case "Introduccion":
                                OpcionIntroduccion.Visible = true;
                                OpcionIntroduccion.HRef = "~/Views/IntroBase/IntroduccionBasesLegales.aspx";
                                break;
                            case "Organigrama":
                                OpcionOrga.Visible = true;
                                OpcionOrga.HRef = "~/Views/Cronograma/Organigrama.aspx";
                                break;
                            case "Dirigencia Deportiva":
                                OpcionDir.Visible = true;
                                OpcionDir.HRef = "~/Views/DirigentesFADN/DirigenciaDeportiva.aspx";
                                break;
                            case "Logro - Brecha":
                                OpcionLB.Visible = true;
                                OpcionLB.HRef = "~/Views/LogroBrecha/LogroBrecha.aspx";
                                break;
                            case "Potencia":
                                OpcionPotencia.Visible = true;
                                OpcionPotencia.HRef = "~/Views/ResultadoPotencia/ResultadoPotencia.aspx";
                                break;
                            case "FODA - Base Estrategica":
                                OpcionFODA.Visible = true;
                                OpcionFODA.HRef = "~/Views/FODABEstrategica/FODABEstrategica.aspx";
                                break;
                        }
                    }
                }
            }
            mysql.CerrarConexion();
        }

        public void EsconderMenu()
        {
            OpcionUsuario.Visible = false;
            OpcionRol.Visible = false;

            OpcionFADN.Visible = false;
            OpcionAdministrar.Visible = false;

            OpcionPortada.Visible = false;
            OpcionIntroduccion.Visible = false;
            OpcionOrga.Visible = false;
            OpcionDir.Visible = false;
            OpcionLB.Visible = false;
            OpcionPotencia.Visible = false;
            OpcionFODA.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                EsconderMenu();
                CargarMenu();
                CargarNombreFederacion();
                CargarLogotipoFederacion();
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
            this.Session["Usuario"] = null;
            Response.Redirect("~/Login.aspx");
        }

        public int rol;
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            SearchRol buscar = new SearchRol();
            rol = int.Parse(buscar.NombreRol(Convert.ToString(this.Session["Usuario"])));
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