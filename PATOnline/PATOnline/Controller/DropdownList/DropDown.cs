using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.DropdownList
{
    public class DropDown
    {
        public string query = "";
        //DropDown llenar el Pais
        public void Drop_Pais(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idpais_departamento, nombre FROM admin_pais_departamento WHERE idpadre = '1' and nombre != 'Ninguno';");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar País --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idpais_departamento";
            ddl.DataBind();
        }
        //Dropdown llenar el Departamento
        public void Drop_Departamento(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idpais_departamento, nombre FROM admin_pais_departamento WHERE idpadre = {0};", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Departamento --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idpais_departamento";
            ddl.DataBind();
        }
        //Dropdown llenar Federacion/Asociacion
        public string add = "";
        public void Drop_FADN(DropDownList drop, string nombre)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar FADN --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            if(nombre == "Federación")
            {
                add = " LIKE '%{0}%' AND dbsecretaria.sg_fadn.id_fand != '47';";
            }
            if (nombre == "Asociación" || nombre == "Confederación")
            {
                add = " LIKE '%{0}%';";
            }
            string query = String.Format("SELECT nombre FROM dbsecretaria.sg_fadn WHERE dbsecretaria.sg_fadn.nombre" + add, nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "nombre";
            drop.DataBind();
        }
        //Dropdown llenar Rol
        public void Drop_Rol(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idrol, nombre FROM seg_rol");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Rol --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idrol";
            ddl.DataBind();
        }
        //Dropdown llenar Tipo Federacion/Asociacion
        public void Drop_TipoFADN(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT nombre FROM admin_tipo_fadn");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Tipo FADN --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "nombre";
            ddl.DataBind();
        }

        public void Drop_Menu(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idmenu, nombre FROM seg_menu");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Rol --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idmenu";
            ddl.DataBind();
        }

        public void Drop_Boton(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idboton, nombre FROM seg_boton");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Rol --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idboton";
            ddl.DataBind();
        }

        public void Drop_FADNLogo(DropDownList drop, string nombre)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar FADN --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            if (nombre == "Federación")
            {
                add = " LIKE '%{0}%' AND dbsecretaria.sg_fadn.id_fand != '47';";
            }
            if (nombre == "Asociación" || nombre == "Confederación")
            {
                add = " LIKE '%{0}%';";
            }
            string query = String.Format("SELECT id_fand, nombre FROM dbsecretaria.sg_fadn WHERE dbsecretaria.sg_fadn.nombre" + add, nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "id_fand";
            drop.DataBind();
        }

        public void Drop_Anio(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Año --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idanio, YEAR(anio) AS valor FROM admin_anio;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "valor";
            drop.DataValueField = "idanio";
            drop.DataBind();
        }

        public void Drop_Brecha(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Brecha --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idbrecha, nombre FROM admin_brecha;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idbrecha";
            drop.DataBind();
        }

        public void Drop_Nivel(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Nivel --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idnivel, nombre FROM admin_nivel;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idnivel";
            drop.DataBind();
        }

        public void Drop_Categoria(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Categoria --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idcategoria, nombre FROM admin_categoria;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idcategoria";
            drop.DataBind();
        }

        public void Drop_Cargo(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Categoria --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idcargo, nombre FROM admin_cargo;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idcargo";
            drop.DataBind();
        }

        public void Drop_TipoPersona(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Categoria --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idtipo_personal_fadn, nombre FROM admin_tipo_personal_fadn;");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idtipo_personal_fadn";
            drop.DataBind();
        }

        public void Drop_TipoIngreso(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Tipo de Ingreso --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idingreso_corriente, nombre FROM admin_ingreso_corriente WHERE codigo ='CODIGO';");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idingreso_corriente";
            drop.DataBind();
        }

        public void Drop_Ingreso(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idingreso_corriente, nombre FROM admin_ingreso_corriente WHERE idpadre = {0} AND subpadre = 0 AND idpadre != 0;", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Ingreso --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idingreso_corriente";
            ddl.DataBind();
        }

        public void Drop_CodigoIngreso(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idingreso_corriente, CONCAT(codigo,' | ',nombre) as ingreso FROM admin_ingreso_corriente WHERE subpadre = {0} AND idpadre != 0;", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Codigo de Ingreso --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "ingreso";
            ddl.DataValueField = "idingreso_corriente";
            ddl.DataBind();
        }

        public void Drop_TipoProyecto(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Tipo de Proyecto --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idprograma_ac, proyeccion_egresos FROM admin_programa_ac WHERE idpadre ='0' AND subpadre = '0';");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "proyeccion_egresos";
            drop.DataValueField = "idprograma_ac";
            drop.DataBind();
        }

        public void Drop_Proyecto(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idprograma_ac, proyeccion_egresos FROM admin_programa_ac WHERE idpadre = '{0}' AND subpadre = 0 AND idpadre != 0;", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Proyecto --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "proyeccion_egresos";
            ddl.DataValueField = "idprograma_ac";
            ddl.DataBind();
        }

        public void Drop_CodigoProyecto(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idprograma_ac, CONCAT(renglon,' | ',proyeccion_egresos) as ingreso FROM admin_programa_ac WHERE subpadre = '{0}' AND idpadre != 0;", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Renglon de Proyecto --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "ingreso";
            ddl.DataValueField = "idprograma_ac";
            ddl.DataBind();
        }
    }
}