using System;
using System.Web.UI.WebControls;
using PATOnline.Controller.Read;
using PATOnline.Controller.Create;
using PATOnline.Controller.Update;
using PATOnline.Controller.Search;
using PATOnline.Models;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.IntroBase
{
    public partial class IntroduccionBasesLegales : System.Web.UI.Page
    {
        ReadIBL all = new ReadIBL();
        ModeloIntroBaseLegal modelo = new ModeloIntroBaseLegal();
        CreateInfoBaseLegal nuevo = new CreateInfoBaseLegal();
        UpdateIntroduccionBaseLegal update = new UpdateIntroduccionBaseLegal();
        public string federacion = "";
        SearchFederacion buscar = new SearchFederacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }
                mostrarIntroBaseLegal.Visible = false;
                mostrarEditIntroBaseLegal.Visible = false;
                idIntroBase.Visible = false;
                CargarGrid();
            }
        }

        protected void CargarGrid()
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            if (all.IBLRead(federacion, ano).Rows.Count != 0)
            {
                gvListadoInfo.DataSource = all.IBLRead(federacion, ano);
                gvListadoInfo.DataBind();
            }
        }

        protected void gvListadoInfo_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvListadoInfo.Rows[index];

                DataTable data = new DataTable();
                data = all.IBLSeleccionadoRead(int.Parse(row.Cells[0].Text));

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    idIntroBase.Text = data.Rows[i][0].ToString();
                    txtEditIntroduccion.Value = data.Rows[i][1].ToString();
                    txtEditMarco.Value = data.Rows[i][1].ToString();
                    txtEditAfiliacion.Value = data.Rows[i][1].ToString();
                }

                mostrarEditIntroBaseLegal.Visible = true;
            }
        }

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void nuevaIntroBaseLegal_Click(object sender, EventArgs e)
        {
            mostrarIntroBaseLegal.Visible = true;
        }

        protected void cancelCrearIntroBaseLegal_Click_Click(object sender, EventArgs e)
        {
            mostrarIntroBaseLegal.Visible = false;
        }

        protected void crearIntroBaseLegal_Click(object sender, EventArgs e)
        {
            federacion = buscar.NombreFederacion(Convert.ToString(Session["Usuario"]));
            string ano = Convert.ToString(DateTime.Now.Year);

            try
            {
                modelo.intro = TxtIntroduccion.Value;
                modelo.marco = TxtMarco.Value;
                modelo.afiliacion = TxtAfiliacion.Value;
                modelo.fadn = federacion;
                modelo.ano = ano;

                nuevo.InfoCreate(modelo);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La introduccion y la base legal fueron creadas', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La introduccion y la base legal no fueron creadas', 'error');", true);
            }
        }

        protected void cancelEditIntroBaseLegal_Click(object sender, EventArgs e)
        {
            mostrarEditIntroBaseLegal.Visible = false;
        }

        protected void editIntroBaseLegal_Click(object sender, EventArgs e)
        {
            try
            {
                modelo.intro = txtEditIntroduccion.Value;
                modelo.marco = txtEditMarco.Value;
                modelo.afiliacion = txtEditAfiliacion.Value;

                update.UpdateIntroBaseLegal(modelo, int.Parse(idIntroBase.Text));
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'La introduccion y la base legal fueron modificadas', 'success');", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'La introduccion y la base legal no fueron modificadas', 'error');", true);
            }
        }
    }
}