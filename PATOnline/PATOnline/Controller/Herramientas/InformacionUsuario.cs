using PATOnline.Controller.Read;
using System.Data;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Herramientas
{
    public class InformacionUsuario
    {
        ReadBoton boton = new ReadBoton();
        public void mostrarBotonera(string usuario, string pantalla, LinkButton bt)
        {
            DataTable mostrar = new DataTable();
            mostrar = boton.BotonReadUsuario(usuario, pantalla);

            for (int i = 0; i < mostrar.Rows.Count; i++)
            {
                switch (mostrar.Rows[i][0].ToString())
                {
                    case "Guardar":
                        bt.Visible = true;
                        break;

                    case "PDF":
                        bt.Visible = true;
                        break;

                    case "Excel":
                        bt.Visible = true;
                        break;

                    case "Rechazar":
                        bt.Visible = true;
                        break;

                    case "Crear":
                        bt.Visible = true;
                        break;
                }
            }
        }
    }
}