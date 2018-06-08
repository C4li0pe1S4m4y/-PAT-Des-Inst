using System;
using PATOnline.Controller.ClasesBD;
using System.Data;

namespace PATOnline
{
    public partial class DashboardAdmin : System.Web.UI.Page
    {
        Usuario grafica_usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            graficaUsuarioActivoInactivo();
            usuarioCantidad();
        }

        protected string graficaUsuarioActivoInactivo()
        {
            DataTable Datos = grafica_usuario.graficaUsuarioActivoInactivo();

            string strDatos;
            strDatos = "[['Usuario','Cantidad'],";
            foreach (DataRow dr in Datos.Rows)
            {
                strDatos = strDatos + "[";
                strDatos = strDatos + "'" + dr[0] + " (" + dr[1] + ")'" + "," + dr[1];
                strDatos = strDatos + "],";
            }
            strDatos = strDatos + "]";
            return strDatos;
        }

        public void usuarioCantidad()
        {
            DataTable data = grafica_usuario.UsuarioRead();

            cantidadUsuario.Text = data.Rows.Count.ToString();
        }

    }
}