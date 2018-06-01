using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class IntroduccionBaseLegal
    {
        Bitacora bitacora = new Bitacora();
        public string query = "";
        ModeloBitacora modelo = new ModeloBitacora();

        //Funcion para crear un nuevo registro
        public DataTable InfoCreate(ModeloIntroBaseLegal objCrear, string usuario)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_informacion (introduccion, marco_juridico, afiliacion_organizacion, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '1');", objCrear.intro, objCrear.marco, objCrear.afiliacion, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();


            query = String.Format("SELECT idinformacion FROM pat_informacion ORDER BY idinformacion DESC LIMIT 1;");
            mysql.AbrirConexion();
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    modelo.id = int.Parse(reader["idinformacion"].ToString());
                }
            }
            mysql.CerrarConexion();

            modelo.tabla = "pat_informacion";
            modelo.accion = "Crear";
            modelo.info = objCrear.intro + " - " + objCrear.marco + " - " + objCrear.afiliacion;
            modelo.fecha = DateTime.Now;
            modelo.usuario = usuario;

            bitacora.historialBitacora(modelo);

            return dt;
        }

        //Funcion para cambiar de estado la informacion al eliminar
        public Boolean InfoBaseLegalDelete(int id, string usuario)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE pat_informacion SET fkestado = '11' WHERE idinformacion = '{0}';", id);

            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();

                modelo.tabla = "pat_informacion";
                modelo.accion = "Update";
                modelo.id = id;
                modelo.info = "Cambio de estado";
                modelo.fecha = DateTime.Now;
                modelo.usuario = usuario;

                bitacora.historialBitacora(modelo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Funcion para llenar el grid
        public DataTable IBLRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado == 1)
            {
                query = String.Format("SELECT idinformacion as numero, introduccion as introduccion, marco_juridico as marco, afiliacion_organizacion as afiliacion " +
                "FROM pat_informacion WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}' OR fkestado = 2;", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT idinformacion as numero, introduccion as introduccion, marco_juridico as marco, afiliacion_organizacion as afiliacion " +
                "FROM pat_informacion WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        //Funcion para seleccionar la informacion de un id en especifico
        public DataTable IBLSeleccionadoRead(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idinformacion as numero, introduccion as introduccion, marco_juridico as marco, afiliacion_organizacion as afiliacion " +
            "FROM pat_informacion WHERE idinformacion = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        //Funcion para verificar si existe el registro
        public int IntroBaseLegalSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_informacion " +
                "WHERE idinformacion = '{0}'", id);
                mysql.AbrirConexion();
                MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
                MySqlDataReader buscar = consulta.ExecuteReader();
                using (buscar)
                {
                    while (buscar.Read())
                    {
                        if (!string.IsNullOrEmpty(buscar.GetString("fkestado")))
                        {
                            return int.Parse(buscar["fkestado"].ToString());
                        }
                    }
                }
                mysql.CerrarConexion();
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        //Funcion para actualizar la informacion
        public Boolean UpdateIntroBaseLegal(ModeloIntroBaseLegal objEditar, int id, int estado, string usuario)
        {
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("UPDATE pat_informacion SET fkestado = '{0}' WHERE idinformacion = '{1}'; ", estado, id);
            }
            else
            {
                query = String.Format("UPDATE pat_informacion SET introduccion = '{0}', marco_juridico = '{1}', " +
                "afiliacion_organizacion = '{2}' WHERE idinformacion = '{3}'; ",
                objEditar.intro, objEditar.marco, objEditar.afiliacion, id);
            }

            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();

                modelo.tabla = "pat_informacion";
                modelo.accion = "Update";
                modelo.id = id;
                modelo.info = objEditar.intro + " - " + objEditar.marco + " - " + objEditar.afiliacion; ;
                modelo.fecha = DateTime.Now;
                modelo.usuario = usuario;

                bitacora.historialBitacora(modelo);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}