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
    public class SearchBoton
    {
        public string query = "";
        public bool BotonGuardar(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Guardar' GROUP BY (b.nombre); ", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonEditar(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Editar' GROUP BY (b.nombre); ", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonVer(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Ver' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonPDF(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'PDF' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonExcel(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Excel' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonEliminar(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Eliminar' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonCrear(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Crear' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonRechazar(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Rechazar' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonAprobar(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Aprobar' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool BotonEnviar(string username)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT u.username As Usuario, b.nombre AS Boton " +
            "FROM seg_usuario u " +
            "INNER JOIN seg_rol r ON r.idrol = u.fkrol " +
            "INNER JOIN seg_menu_boton mb ON mb.fkrol = r.idrol " +
            "INNER JOIN seg_boton b ON b.idboton = mb.fkboton " +
            "WHERE u.username = '{0}' AND b.nombre = 'Enviar' GROUP BY (b.nombre);", username);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool ExisteBoton(string boton)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT b.nombre As Boton " +
            "FROM seg_boton b " +
            "WHERE b.nombre = '{0}'", boton);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if ((!string.IsNullOrEmpty(buscar.GetString("Usuario"))) && (!string.IsNullOrEmpty(buscar.GetString("Boton"))))
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