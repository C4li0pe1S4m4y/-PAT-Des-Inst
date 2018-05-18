using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Search
{
    public class SearchP2
    {
        public string query = "";
        public string opcion;
        public double monto_50;
        public double monto_30;
        public double monto_20;
        public double monto_100;
        public bool ExisteP2(int ingreso, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT fkprograma_ac FROM pat_p2 " +
            "WHERE fadn = '{0}' AND anio = '{1}' AND fkprograma_ac = '{2}'; ", fadn, anio, ingreso);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("fkprograma_ac")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public string VerificarMonto50P2(string raiz, string fadn, string anio)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
            "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
            "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " +
            "WHERE pac.proyeccion_egresos = '{0}' AND p.fadn = '{1}' AND p.anio = '{2}'; ", raiz, fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    monto_50 = Convert.ToDouble(buscar["monto1"].ToString());
                    monto_30 = Convert.ToDouble(buscar["monto2"].ToString());
                    monto_20 = Convert.ToDouble(buscar["monto3"].ToString());
                    monto_100 = Convert.ToDouble(buscar["monto4"].ToString());
                }
            }
            mysql.CerrarConexion();

            double operar_50 = (monto_100 * 50) / 100;
            double restante = (monto_100 - monto_30) - monto_20;

            if (monto_50 == restante)
            {
                opcion = "IGUAL";
            }
            if ((monto_50 >= operar_50) && (monto_50 <= restante))
            {
                opcion = "RANGO";
            }
            else
            {
                opcion = "EXCEDE";
            }

            return opcion;
        }

        public string VerificarMonto30P2(int raiz, int id, string fadn, string anio)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
            "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
            "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " +
            "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}'; ", raiz, id, fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    monto_50 = Convert.ToDouble(buscar["monto1"].ToString());
                    monto_30 = Convert.ToDouble(buscar["monto2"].ToString());
                    monto_20 = Convert.ToDouble(buscar["monto3"].ToString());
                    monto_100 = Convert.ToDouble(buscar["monto4"].ToString());
                }
            }
            mysql.CerrarConexion();

            double operar_30 = (monto_100 * 30) / 100;

            if ((monto_30 >= 0) && (monto_30 <= operar_30))
            {
                opcion = "RANGO";
            }
            else if (monto_30 == operar_30)
            {
                opcion = "IGUAL";
            }
            else
            {
                opcion = "EXCEDE";
            }

            return opcion;
        }

        public string VerificarMonto20P2(int raiz, int id, string fadn, string anio)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
            "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
            "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " +
            "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}'; ", raiz, id, fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    monto_50 = Convert.ToDouble(buscar["monto1"].ToString());
                    monto_30 = Convert.ToDouble(buscar["monto2"].ToString());
                    monto_20 = Convert.ToDouble(buscar["monto3"].ToString());
                    monto_100 = Convert.ToDouble(buscar["monto4"].ToString());
                }
            }
            mysql.CerrarConexion();

            double operar_20 = (monto_100 * 20) / 100;

            if ((monto_20 >= 0) && (monto_30 <= operar_20))
            {
                opcion = "RANGO";
            }
            else if (monto_20 == operar_20)
            {
                opcion = "IGUAL";
            }
            else
            {
                opcion = "EXCEDE";
            }

            return opcion;
        }

        public string VerificarMonto100P2(int raiz, int id, string fadn, string anio)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
            "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
            "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
            "ON pac.idprograma_ac = p.fkprograma_ac " +
            "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}'; ", raiz, id, fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    monto_50 = Convert.ToDouble(buscar["monto1"].ToString());
                    monto_30 = Convert.ToDouble(buscar["monto2"].ToString());
                    monto_20 = Convert.ToDouble(buscar["monto3"].ToString());
                    monto_100 = Convert.ToDouble(buscar["monto4"].ToString());
                }
            }
            mysql.CerrarConexion();

            double operar_100 = monto_50 + monto_30 + monto_20;

            if (monto_100 == operar_100)
            {
                opcion = "IGUAL";
            }
            else
            {
                opcion = "EXCEDE";
            }

            return opcion;
        }
    }
}