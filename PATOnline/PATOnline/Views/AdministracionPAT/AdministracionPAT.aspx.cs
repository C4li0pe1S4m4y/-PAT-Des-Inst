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
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBrecha.Text = "Crear Nueva Brecha";
            lblCargo.Text = "Crear Nuevo Cargo";
            lblCategoria.Text = "Crear Nueva Categoria";
            lblNivel.Text = "Crear Nuevo Nivel";
            lblTipoPersonal.Text = "Nuevo Tipo Personal";

            CargaGridB();
            CargaGridC();
            CargaGridCa();
            CargaGridN();
            CargaGridT();
        }

        public void CargaGridB()
        {
            if(all.BrechaRead().Rows.Count != 0)
            {
                gvListBrecha.DataSource = all.BrechaRead();
                gvListBrecha.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListBrecha.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                gvListBrecha.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListBrecha.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void SaveBrecha_Click(object sender, EventArgs e)
        {
            modelo_brecha.nombre_brecha = TxtBrecha.Text;
            if(buscar.BrechaSearch(TxtBrecha.Text) == true)
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
                //Attribute to show the Plus Minus Button.
                gvListCargo.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                gvListCargo.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListCargo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void SaveCargo_Click(object sender, EventArgs e)
        {
            modelo_cargo.nombre_cargo = TxtCargo.Text;
            if (buscar.CargoSearch(TxtCargo.Text) == true)
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
            if(all.CategoriaRead().Rows.Count != 0)
            {
                gvListCategoria.DataSource = all.CategoriaRead();
                gvListCategoria.DataBind();          
                //Attribute to show the Plus Minus Button.
                gvListCategoria.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                gvListCategoria.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListCategoria.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void SaveCategoria_Click(object sender, EventArgs e)
        {
            modelo_categoria.nombre_categoria = TxtCategoria.Text;
            if (buscar.CategoriaSearch(TxtCategoria.Text) == true)
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

        public void CargaGridN()
        {
            if(all.NivelRead().Rows.Count != 0)
            {
                gvListNivel.DataSource = all.NivelRead();
                gvListNivel.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListNivel.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                gvListNivel.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListNivel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void SaveNivel_Click(object sender, EventArgs e)
        {
            modelo_nivel.nombre_nivel = TxtNivel.Text;
            if (buscar.NivelSearch(TxtNivel.Text) == true)
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
            CargaGridN();
        }

        public void CargaGridT()
        {
            if(all.TipoPersonalRead().Rows.Count != 0)
            {
                gvListTipoPersonal.DataSource = all.TipoPersonalRead();
                gvListTipoPersonal.DataBind();
                //Attribute to show the Plus Minus Button.
                gvListTipoPersonal.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                gvListTipoPersonal.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                gvListTipoPersonal.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void SaveTipoPersonal_Click(object sender, EventArgs e)
        {
            modelo_tipo.nombre_tipopersonal = TxtTipoPersonal.Text;
            if (buscar.TipoPersonalSearch(TxtTipoPersonal.Text) == true)
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
    }
}