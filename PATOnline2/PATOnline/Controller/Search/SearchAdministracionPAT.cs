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
    }
}