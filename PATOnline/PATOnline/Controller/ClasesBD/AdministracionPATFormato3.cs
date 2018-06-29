using System;
using System.Data;
using MySql.Data.MySqlClient;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class AdministracionPATFormato3
    {
        public string query = "";
        public string opcion;

        public DataTable FormatoCGridEditRead()
        {
            query = "";
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            for (int i = 1; i < 6; i++)
            {
                if (i == 5)
                {
                    query = String.Format(query + " SELECT idformato_c, nombre FROM admin_formato_c WHERE idformato_c = '{0}' " +
                    "UNION ALL " +
                    "SELECT idformato_c, nombre FROM admin_formato_c WHERE idpadre = '{0}'", i);
                }
                else
                {
                    query = String.Format(query + " SELECT idformato_c, nombre FROM admin_formato_c WHERE idformato_c = '{0}' " +
                    "UNION ALL " +
                    "SELECT idformato_c, nombre FROM admin_formato_c WHERE idpadre = '{0}' UNION ALL", i);
                }
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CategoriaGridEditRead()
        {
            query = "";
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            for (int i = 1; i < 20; i++)
            {
                if (i == 1 || i == 2 || i == 8 || i == 11 || i == 13 || i == 16 || i == 19)
                {
                    if (i == 19)
                    {
                        query = String.Format(query + " SELECT idcategoria as numero, nombre FROM admin_categoria WHERE idcategoria = '{0}' " +
                        "UNION ALL " +
                        "SELECT idcategoria as numero, nombre FROM admin_categoria WHERE idpadre = '{0}'", i);
                    }
                    else
                    {
                        query = String.Format(query + " SELECT idcategoria as numero, nombre FROM admin_categoria WHERE idcategoria = '{0}' " +
                        "UNION ALL " +
                        "SELECT idcategoria as numero, nombre FROM admin_categoria WHERE idpadre = '{0}' UNION ALL", i);
                    }
                }
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ActividadGridEditRead()
        {
            query = "";
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            for (int i = 1; i < 27; i++)
            {
                if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 21 || i == 26)
                {
                    if (i == 26)
                    {
                        query = String.Format(query + " SELECT idactividad_pat, nombre FROM admin_actividad_pat WHERE idactividad_pat = '{0}' " +
                        "UNION ALL " +
                        "SELECT idactividad_pat, nombre FROM admin_actividad_pat WHERE idpadre = '{0}'", i);
                    }
                    else
                    {
                        query = String.Format(query + " SELECT idactividad_pat, nombre FROM admin_actividad_pat WHERE idactividad_pat = '{0}' " +
                        "UNION ALL " +
                        "SELECT idactividad_pat, nombre FROM admin_actividad_pat WHERE idpadre = '{0}' UNION ALL", i);
                    }
                }
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable FormatoCRead(int id, string tipoid)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            switch (tipoid)
            {
                case "idformato_c":
                    opcion = "  WHERE idformato_c='{0}';";
                    break;
                case "idpadre":
                    opcion = "  WHERE idpadre='{0}';";
                    break;
            }
            query = String.Format("SELECT idformato_c, nombre FROM admin_formato_c" + opcion, id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CategoriaFormatoRead(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idcategoria as numero, nombre FROM admin_categoria WHERE idpadre='{0}' AND idcategoria!=1;", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ActividadPATRead(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idactividad_pat, nombre FROM admin_actividad_pat WHERE idpadre='{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable FormatoCCreate(ModeloFormatoC objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO admin_formato_c (nombre, idpadre) " +
            "VALUES('{0}', '{1}'); ", objCrear.nombre, objCrear.idpadre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CategoriaFormatoCreate(ModeloCategoria objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO admin_categoria (nombre, idpadre)" +
            "VALUES('{0}', '{1}');",
            objCrear.nombre_categoria, objCrear.idpadre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ActividadPATCreate(ModeloActividadPAT objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO admin_actividad_pat (nombre, idpadre) " +
            "VALUES('{0}', '{1}');", objCrear.nombre, objCrear.idpadre);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public bool ExisteFormatoCPAT(string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idformato_c FROM dbcdagpat.admin_formato_c WHERE nombre = '{0}';", nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idformato_c")))
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

        public bool ExisteActividadPAT(int id, string nombre)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idactividad_pat FROM admin_actividad_pat WHERE idpadre='{0}' AND nombre='{1}';", id, nombre);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("idactividad_pat")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public DataTable FormatoCSeleccionado(int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT idformato_c, nombre, idpadre FROM admin_formato_c WHERE idformato_c = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CategoriaSeleccionada(int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT idcategoria, nombre, idpadre FROM admin_categoria WHERE idcategoria = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable ActividadSeleccionada(int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT idactividad_pat, nombre, idpadre FROM admin_actividad_pat WHERE idactividad_pat = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean FormatoCUpdate(ModeloFormatoC o, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE admin_formato_c SET nombre = '{0}', idpadre = '{1}' WHERE idformato_c = '{2}'",
                o.nombre, o.idpadre, id);

            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean CategoriaUpdate(ModeloCategoria o, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE admin_categoria SET nombre = '{0}', idpadre = '{1}' WHERE idcategoria = '{2}'",
                o.nombre_categoria, o.idpadre, id);

            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean ActividadUpdate(ModeloActividadPAT o, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE admin_actividad_pat SET nombre = '{0}', idpadre = '{1}' WHERE idactividad_pat = '{2}'",
                o.nombre, o.idpadre, id);

            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}