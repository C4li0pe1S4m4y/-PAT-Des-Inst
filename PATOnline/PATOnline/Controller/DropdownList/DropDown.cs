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

        public void Drop_Nivel(DropDownList drop, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Nivel --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idnivel, nombre FROM admin_nivel WHERE idpadre='{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idnivel";
            drop.DataBind();
        }

        public void Drop_Categoria(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idcategoria, nombre FROM admin_categoria WHERE idpadre='{0}';", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Categoria --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idcategoria";
            ddl.DataBind();
        }

        public void Drop_CategoriaFormato(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idcategoria, nombre FROM admin_categoria WHERE idpadre='{0}' AND idcategoria!=1;", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Categoria --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idcategoria";
            ddl.DataBind();
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
            string query = String.Format("SELECT idingreso_corriente, nombre FROM admin_ingreso_corriente WHERE codigo ='0 CODIGO';");
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

        public void Drop_Dia(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Dia --");
            drop.Items[0].Value = "0";
            DataTable tabla = getDia();
            drop.DataSource = tabla;
            drop.DataTextField = "Texto";
            drop.DataValueField = "Valor";
            drop.DataBind();
        }

        static DataTable getDia()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Valor", typeof(int));
            table.Columns.Add("Texto", typeof(int));

            table.Rows.Add(1, "1"); table.Rows.Add(2, "2"); table.Rows.Add(3, "3"); table.Rows.Add(4, "4"); table.Rows.Add(5, "5");
            table.Rows.Add(6, "6"); table.Rows.Add(7, "7"); table.Rows.Add(8, "8"); table.Rows.Add(9, "9"); table.Rows.Add(10, "10");
            table.Rows.Add(11, "11"); table.Rows.Add(12, "12"); table.Rows.Add(13, "13"); table.Rows.Add(14, "14"); table.Rows.Add(15, "15");
            table.Rows.Add(16, "16"); table.Rows.Add(17, "17"); table.Rows.Add(18, "18"); table.Rows.Add(19, "19"); table.Rows.Add(20, "20");
            table.Rows.Add(21, "21"); table.Rows.Add(22, "22"); table.Rows.Add(23, "23"); table.Rows.Add(24, "24"); table.Rows.Add(25, "25");
            table.Rows.Add(26, "26"); table.Rows.Add(27, "27"); table.Rows.Add(28, "28"); table.Rows.Add(29, "29"); table.Rows.Add(30, "30");
            table.Rows.Add(31, "31");

            return table;
        }

        public void Drop_Mes(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar Mes --");
            drop.Items[0].Value = "0";
            DataTable tabla = getMes();
            drop.DataSource = tabla;
            drop.DataTextField = "Texto";
            drop.DataValueField = "Valor";
            drop.DataBind();
        }

        static DataTable getMes()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Valor", typeof(int));
            table.Columns.Add("Texto", typeof(string));

            table.Rows.Add(1, "Ene"); table.Rows.Add(2, "Feb"); table.Rows.Add(3, "Mar"); table.Rows.Add(4, "Abr"); table.Rows.Add(5, "May");
            table.Rows.Add(6, "Jun"); table.Rows.Add(7, "Jul"); table.Rows.Add(8, "Ago"); table.Rows.Add(9, "Sep"); table.Rows.Add(10, "Oct");
            table.Rows.Add(11, "Nov"); table.Rows.Add(12, "Dic");

            return table;
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
            string query = String.Format("SELECT idprograma_ac, proyeccion_egresos FROM admin_programa_ac WHERE idpadre=0 AND subpadre=0;");
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
            query = String.Format("SELECT idprograma_ac, proyeccion_egresos FROM admin_programa_ac WHERE idpadre = '{0}' AND subpadre = 0 AND idpadre != 0 AND idprograma_ac != 3;", id);
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

        public void Drop_FormatoC(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idformato_c, nombre FROM admin_formato_c WHERE idpadre='{0}';", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Formato C --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idformato_c";
            ddl.DataBind();
        }

        public void Drop_ActividadPAT(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idactividad_pat, nombre FROM admin_actividad_pat WHERE idpadre = '{0}';", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Actividad PAT --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idactividad_pat";
            ddl.DataBind();
        }

        public void Drop_ActividadPATPE(DropDownList drop)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("-- Seleccionar PE --");
            drop.Items[0].Value = "0";
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT idactividad_pat, nombre FROM admin_actividad_pat WHERE idpadre=0");
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(tabla);
            mysql.CerrarConexion();
            drop.DataSource = tabla;
            drop.DataTextField = "nombre";
            drop.DataValueField = "idactividad_pat";
            drop.DataBind();
        }

        public void Drop_FiltrarActividadPAT(DropDownList ddl, string table, string fadn, string ano, string buscar, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            if(buscar == "SI")
            {
                query = String.Format("SELECT codigo, CONCAT(codigo,' | ',nombre) AS mostrar " +
                "FROM {0} p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "WHERE fadn = '{1}' AND ano = '{2}' AND idpadre = '{3}';", table, fadn, ano, id);
            }
            else
            {
                query = String.Format("SELECT codigo, CONCAT(codigo,' | ',nombre) AS mostrar " +
                "FROM {0} p INNER JOIN admin_actividad_pat a ON a.idactividad_pat = p.fkactividad_pat " +
                "WHERE fadn = '{1}' AND ano = '2000';", table, fadn, ano);
            }
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Codigo de la Actividad PE --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "mostrar";
            ddl.DataValueField = "codigo";
            ddl.DataBind();
        }

        public void Drop_Clasifiacion(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idclasificacion, nombre FROM admin_clasificacion WHERE idpadre='{0}';", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Clasificación --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idclasificacion";
            ddl.DataBind();
        }

        public void Drop_Etapa(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idetapa_preparacion, nombre FROM admin_etapa_preparacion WHERE idpadre='{0}';", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Etapa --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idetapa_preparacion";
            ddl.DataBind();
        }

        public void Drop_Objetivo(DropDownList ddl, int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT idobjetivo, nombre FROM admin_objetivo WHERE idpadre='{0}';", id);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();

            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            ddl.Items.Add("-- Seleccionar Objetivo --");
            ddl.Items[0].Value = "-1";
            ddl.DataSource = dt;
            ddl.DataTextField = "nombre";
            ddl.DataValueField = "idobjetivo";
            ddl.DataBind();
        }
    }
}