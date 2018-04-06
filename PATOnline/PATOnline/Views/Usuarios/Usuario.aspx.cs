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

namespace PATOnline.Views.Usuarios
{
    public partial class Usuario : System.Web.UI.Page
    {
        public string Titulo = "INFORMACIÓN DEL USUARIO ";
        public string SubTitulo = "MOSTRAR INFORMACIÓN DEL USUARIO";
        ReadUsuario all_usuario = new ReadUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
                lblSubTitulo.Text = SubTitulo;
                lblTitulo.Text = Titulo;
            }
        }

        protected void CargarGrid()
        {
            if(all_usuario.UsuarioRead().Rows.Count != 0)
            {
                gvListadoUsuarios.DataSource = all_usuario.UsuarioRead();
                gvListadoUsuarios.DataBind();
                gvListadoUsuarios.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                //Attribute to hide column in Phone.
                gvListadoUsuarios.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                gvListadoUsuarios.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                gvListadoUsuarios.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                gvListadoUsuarios.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                gvListadoUsuarios.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListadoUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvListadoUsuarios_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                string seleccionar = e.CommandArgument.ToString();
                int index = int.Parse(seleccionar);
                GridViewRow row = gvListadoUsuarios.Rows[index];

                lbl.Text = "You selected " + row.Cells[0].Text + ".";
            }
        }

        protected void gvListadoUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoUsuarios.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
    }
}
