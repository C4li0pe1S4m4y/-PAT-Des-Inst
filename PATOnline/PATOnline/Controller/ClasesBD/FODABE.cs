using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class FODABE
    {
        public string query = "";
        public DataTable FODABERead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("SELECT idfoda_bestrategica AS numero, fortaleza, oportunidad, debilidad, amenaza, " +
                "mision, vision, valor " +
                "FROM pat_foda_baestrategica  WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT idfoda_bestrategica AS numero, fortaleza, oportunidad, debilidad, amenaza, " +
                "mision, vision, valor " +
                "FROM pat_foda_baestrategica  WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN (1,2);", fadn, ano);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable FODABECreate(ModeloFodaBEstrategica objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_foda_baestrategica (fortaleza, oportunidad, debilidad, amenaza, mision, vision, valor, fadn, ano, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');",
            objCrear.fortaleza, objCrear.oportunidad, objCrear.debilidad, objCrear.amenaza, objCrear.mision, objCrear.vision, 
            objCrear.valor, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable FODABESeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT idfoda_bestrategica AS numero, fortaleza, oportunidad, debilidad, amenaza, " +
                "mision, vision, valor FROM pat_foda_baestrategica  WHERE idfoda_bestrategica = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean FODABEUpdate(ModeloFodaBEstrategica o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_foda_baestrategica SET fkestado = '{0}' WHERE idfoda_bestrategica = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_foda_baestrategica SET fortaleza = '{0}', oportunidad = '{1}', " +
                "debilidad = '{2}', amenaza = '{3}', mision = '{4}', vision = '{5}', " +
                "valor = '{6}' WHERE idfoda_bestrategica = '{7}'",
                o.fortaleza, o.oportunidad, o.debilidad, o.amenaza, o.mision, o.vision, o.vision, id);
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

        public int FODABESearch(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_foda_baestrategica " +
                "WHERE idfoda_bestrategica = '{0}'", id);
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
    }
}