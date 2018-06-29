using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class Organigrama
    {
        public string query = "";
        public DataTable OrganigramaCreate(ModeloOrganigrama objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_organigrama (organigrama, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '1'); ", objCrear.imagen, objCrear.fadn, objCrear.anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable OrgranigramaRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado == 1)
            {
                query = String.Format("SELECT idorganigrama as numero, organigrama as organigrama " +
                "FROM pat_organigrama WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2)", fadn, ano);
            }
            if (estado == 12)
            {
                query = String.Format("SELECT idorganigrama as numero, organigrama as organigrama " +
                "FROM pat_organigrama WHERE fadn = '{0}' AND ano = '{1}' AND fkestado != '{2}' OR fkestado != '13'", fadn, ano, estado);
            }
            if (estado > 1)
            {
                query = String.Format("SELECT idorganigrama as numero, organigrama as organigrama " +
                "FROM pat_organigrama WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable OrgranigramaSeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idorganigrama as numero, organigrama as organigrama " +
            "FROM pat_organigrama WHERE idorganigrama = '{0}'", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean OrganigramaUpdate(ModeloOrganigrama o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_organigrama SET fkestado = '{0}' WHERE idorganigrama = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_organigrama SET organigrama = '{0}' WHERE idorganigrama = '{1}'",
                o.imagen, id);
            }


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

        public int OrganigramaSearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_organigrama " +
                "WHERE idorganigrama = '{0}'", id);
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

        public DataTable OrgranigramaExiste(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT idorganigrama as numero, organigrama as organigrama " +
            "FROM pat_organigrama WHERE fadn = '{0}' AND ano = '{1}' AND fkestado != '{2}' OR fkestado != '13'", fadn, ano, estado);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}