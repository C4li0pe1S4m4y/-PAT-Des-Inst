using System;
using System.Web.UI.WebControls;
using PATOnline.Controller.Read;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Update;
using PATOnline.Controller.Search;
using PATOnline.Models;
using System.Web.UI;
using System.Data;

namespace PATOnline.Views.FADN
{
    public partial class FADN : System.Web.UI.Page
    {
        DropDown drop = new DropDown();
        CreateLogotipo nuevo_logo = new CreateLogotipo();
        UpdateFADN update = new UpdateFADN();
        ModeloLogotipo modelo_logo = new ModeloLogotipo();
        SearchFADN busccar = new SearchFADN();
        ReadFADN all = new ReadFADN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

                CargarGrid();
                mostrarCrearLogotipo.Visible = false;
                mostrarEditLogotipo.Visible = false;
                idLogotipo.Visible = false;
            }
        }

        public string convertirImagenBase64(FileUpload imagen)
        {
            try
            {
                System.IO.Stream fs = imagen.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string convertir = Convert.ToBase64String(bytes, 0, bytes.Length);

                return "data:image/png;base64," + convertir;
            }
            catch
            {
                return "";
            }
        }

        protected void CargarGrid()
        {
            if(Session["FederacionAsignada"] == null)
            {
                gvListadoInfo.DataSource = all.FADNRead(Session["Usuario"].ToString(), Session["Federacion"].ToString());
            }
            else
            {
                gvListadoInfo.DataSource = all.FADNRead(Session["Usuario"].ToString(), Session["FederacionAsignada"].ToString());
            }

            gvListadoInfo.DataBind();
        }

        protected void gvListadoInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListadoInfo.PageIndex = e.NewPageIndex;
            CargarGrid();
        }

        protected void gvListadoInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Editar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridViewRow row = gvListadoInfo.Rows[index];

                DataTable logo = new DataTable();
                logo = busccar.LgotipoSearch(Server.HtmlDecode(row.Cells[0].Text));
         
                for (int i = 0; i < logo.Rows.Count; i++)
                {
                    idLogotipo.Text = logo.Rows[i][0].ToString();
                    precargarLogoEdit.ImageUrl = logo.Rows[i][1].ToString();
                }

                drop.Drop_TipoFADN(dropEditTipo);
                drop.Drop_FADNEditLogo(dropEditFADN, Server.HtmlDecode(row.Cells[0].Text));
                mostrarEditLogotipo.Visible = true;
            }
        }

        protected void nuevoLogotipo_Click(object sender, EventArgs e)
        {
            drop.Drop_TipoFADN(dropCrearTipo);
            drop.Drop_FADNLogo(dropCrearFADN, "0");
            mostrarCrearLogotipo.Visible = true;
        }

        protected void dropCrearTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_FADNLogo(dropCrearFADN, dropCrearTipo.SelectedValue);
        }

        protected void crearLogotipo_Click(object sender, EventArgs e)
        {
            if(convertirImagenBase64(FileUpload2) != "")
            {
                try
                {
                    modelo_logo.logo = convertirImagenBase64(FileUpload2);
                    modelo_logo.fkfadn = int.Parse(dropCrearFADN.SelectedValue);
                    nuevo_logo.LogoCreate(modelo_logo);
                    CargarGrid();
                    mostrarCrearLogotipo.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El logotipo fue asginado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El logotipo no fue asginado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El logotipo no puede ser almacenado', 'warning');", true);
            }
        }

        protected void cancelCrearLogotipo_Click(object sender, EventArgs e)
        {
            mostrarCrearLogotipo.Visible = false;
        }

        protected void dropEditTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            drop.Drop_FADNLogo(dropEditFADN, dropEditTipo.SelectedValue);
        }

        protected void FileUpload1_PreRender(object sender, EventArgs e)
        {
            precargarLogoEdit.ImageUrl = convertirImagenBase64(FileUpload1);
        }

        protected void editLogotipo_Click(object sender, EventArgs e)
        {
            if(convertirImagenBase64(FileUpload1) != "")
            {
                try
                {
                    modelo_logo.logo = convertirImagenBase64(FileUpload1);
                    modelo_logo.fkfadn = int.Parse(dropEditFADN.SelectedValue);
                    update.UpdateLogotipo(modelo_logo, int.Parse(idLogotipo.Text));
                    CargarGrid();
                    mostrarEditLogotipo.Visible = false;
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Completo!', 'El logotipo fue modificado', 'success');", true);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Error!', 'El logotipo no fue modificado', 'error');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', 'El logotipo no puede ser almacenado', 'warning');", true);
            }
        }

        protected void cancelEditLogotipo_Click(object sender, EventArgs e)
        {
            mostrarEditLogotipo.Visible = false;
        }

    }
}