using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PATOnline.Controller.DropdownList;
using PATOnline.Controller.Create;
using PATOnline.Controller.Search;
using PATOnline.Controller.Read;
using PATOnline.Models;

namespace PATOnline.Views.AdministracionPAT
{
    public partial class AdministracionPAT : System.Web.UI.Page
    {
        ReadAdministracionPAT all = new ReadAdministracionPAT();
        CreateAdministracionPAT nuevo = new CreateAdministracionPAT();
        SearchAdministracionPAT buscar = new SearchAdministracionPAT();
        ModeloBrecha modelo_brecha = new ModeloBrecha();
        ModeloCargo modelo_cargo = new ModeloCargo();
        ModeloCategoria modelo_categoria = new ModeloCategoria();
        ModeloNivel modelo_nivel = new ModeloNivel();
        ModeloTipoPersonal modelo_tipo = new ModeloTipoPersonal();
        DropDown drop = new DropDown();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["Usuario"] == null) { Response.Redirect("~/Login.aspx"); }

            if (!IsPostBack)
            {
                lblBrecha.Text = "CREAR NUEVA BRECHA";
                lblCargo.Text = "CREAR NUEVA CARGO";
                lblCategoria.Text = "CREAR NUEVA CATEGORIA";
                lblNivel.Text = "CREAR NUEVO NIVEL";
                lblTipoPersonal.Text = "NUEVO TIPO PERSONAL";

                drop.Drop_Nivel(DropNivel, 0);
                CargaGridB();
                CargaGridC();
                CargaGridCa();
                CargaGridT();
            }
        }

        public void CargaGridB()
        {
            if(all.BrechaRead().Rows.Count != 0)
            {
                gvListBrecha.DataSource = all.BrechaRead();
                gvListBrecha.DataBind();
            }
        }

        protected void SaveBrecha_Click(object sender, EventArgs e)
        {
            modelo_brecha.nombre_brecha = TxtBrecha.Value;
            if(buscar.BrechaSearch(TxtBrecha.Value) == true)
            {
            }
            else
            {
                try
                {
                    nuevo.BrechaCreate(modelo_brecha);
                }
                catch
                {
                    Response.Write("<script>window.alert('Error al crear Brecha','Crear Nueva Brecha');</script>" +
                    "<script>window.setTimeout(location.href='AdministracionPAT.aspx', 1);</script>");
                }
            }
        }

        protected void gvListBrecha_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListBrecha.PageIndex = e.NewPageIndex;
            CargaGridB();
        }

        public void CargaGridC()
        {
            if(all.CargoRead().Rows.Count != 0)
            {
                gvListCargo.DataSource = all.CargoRead();
                gvListCargo.DataBind();
            }
        }

        protected void SaveCargo_Click(object sender, EventArgs e)
        {
            modelo_cargo.nombre_cargo = TxtCargo.Value;
            if (buscar.CargoSearch(TxtCargo.Value) == true)
            {
            }
            else
            {
                try
                {
                    nuevo.BrechCreate(modelo_brecha);
                }
                catch
                {
                    Response.Write("<script>window.alert('Error al crear Cargo','Crear Nuevo Cargo');</script>" +
                    "<script>window.setTimeout(location.href='AdministracionPAT.aspx', 1);</script>");
                }
            }
        }

        protected void gvListCargo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListCargo.PageIndex = e.NewPageIndex;
            CargaGridC();
        }

        public void CargaGridCa()
        {
            if(all.CategoriaRead(1).Rows.Count != 0)
            {
                gvListCategoria.DataSource = all.CategoriaRead(1);
                gvListCategoria.DataBind();          
            }
        }

        protected void SaveCategoria_Click(object sender, EventArgs e)
        {
            modelo_categoria.nombre_categoria = TxtCategoria.Value;
            if (buscar.CategoriaSearch(TxtCategoria.Value) == true)
            {
            }
            else
            {
                try
                {
                    nuevo.BrechaCreate(modelo_brecha);
                }
                catch
                {
                    Response.Write("<script>window.alert('Error al crear Categoria','Crear Nueva Categoria');</script>" +
                    "<script>window.setTimeout(location.href='AdministracionPAT.aspx', 1);</script>");
                }
            }
        }

        protected void gvListCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListCategoria.PageIndex = e.NewPageIndex;
            CargaGridCa();
        }

        protected void SaveNivel_Click(object sender, EventArgs e)
        {
            modelo_nivel.nombre_nivel = TxtNivel.Value;
            modelo_nivel.idpadre = int.Parse(DropNivel.SelectedValue);
            if (buscar.NivelSearch(TxtNivel.Value, int.Parse(DropNivel.SelectedValue)) == true)
            {
            }
            else
            {
                try
                {
                    nuevo.BrechaCreate(modelo_brecha);
                }
                catch
                {
                    Response.Write("<script>window.alert('Error al crear Nivel','Crear Nuevo Nivel');</script>" +
                    "<script>window.setTimeout(location.href='AdministracionPAT.aspx', 1);</script>");
                }
            }
        }

        protected void gvListNivel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListNivel.PageIndex = e.NewPageIndex;
            gvListNivel.DataSource = all.NivelRead(int.Parse(DropNivel.SelectedValue));
            gvListNivel.DataBind();
        }

        public void CargaGridT()
        {
            if(all.TipoPersonalRead().Rows.Count != 0)
            {
                gvListTipoPersonal.DataSource = all.TipoPersonalRead();
                gvListTipoPersonal.DataBind();
            }
        }

        protected void SaveTipoPersonal_Click(object sender, EventArgs e)
        {
            modelo_tipo.nombre_tipopersonal = TxtTipoPersonal.Value;
            if (buscar.TipoPersonalSearch(TxtTipoPersonal.Value) == true)
            {
            }
            else
            {
                try
                {
                    nuevo.BrechaCreate(modelo_brecha);
                }
                catch
                {
                    Response.Write("<script>window.alert('Error al crear Tipo Persona','Crear Nuevo Tipo Persona');</script>" +
                    "<script>window.setTimeout(location.href='AdministracionPAT.aspx', 1);</script>");
                }
            }
        }

        protected void gvListTipoPersonal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListTipoPersonal.PageIndex = e.NewPageIndex;
            CargaGridT();
        }

        protected void DropNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (all.NivelRead(int.Parse(DropNivel.SelectedValue)).Rows.Count != 0)
            {
                gvListNivel.DataSource = all.NivelRead(int.Parse(DropNivel.SelectedValue));
                gvListNivel.DataBind();
            }
        }
    }
}