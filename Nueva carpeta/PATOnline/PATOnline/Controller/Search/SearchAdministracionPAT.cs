using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Search
{
    public class SearchAdministracionPAT
    {
        public string query = "";
        public bool BrechaSearch(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * " +
            "FROM admin_brecha " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool CargoSearch(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * " +
            "FROM admin_cargo " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool CategoriaSearch(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * " +
            "FROM admin_categoria " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool CategoriaFormatoSearch(string nombre, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * " +
            "FROM admin_categoria " +
            "WHERE nombre='{0}' AND idpadre='{1}';", nombre, id);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool NivelSearch(string nombre, int idpadre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * " +
            "FROM admin_nivel " +
            "WHERE nombre='{0}' AND idpadre='{1}';", nombre, idpadre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool TipoPersonalSearch(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT * " +
            "FROM admin_tipo_personal_fadn " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("nombre")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public DataTable BrechaInformacionSearch(string nombre)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idbrecha, nombre " +
            "FROM admin_brecha " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CargoInformacionSearch(string nombre)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idcargo, nombre " +
            "FROM admin_cargo " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CategoriaInformacionSearch(string nombre)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idcategoria, nombre " +
            "FROM admin_categoria " +
            "WHERE nombre='{0}' AND idpadre = 1;", nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable NivelInformacionSearch(string nombre)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idnivel, nombre, idpadre " +
            "FROM admin_nivel " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable TipoPersonaInformacionSearch(string nombre)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idtipo_personal_fadn, nombre " +
            "FROM admin_tipo_personal_fadn " +
            "WHERE nombre='{0}';", nombre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}