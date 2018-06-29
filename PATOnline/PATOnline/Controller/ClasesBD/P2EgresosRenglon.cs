using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class P2EgresosRenglon
    {
        public string query = "";
        private string opcion;
        private double monto_50;
        private double monto_30;
        private double monto_20;
        private double monto_100;

        public DataTable ContarP2Read(string fadn, string anio, int estado)
        {
            query = "";
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            if (estado > 1)
            {
                query = String.Format("SELECT idp2 FROM pat_p2 WHERE fadn = '{0}' AND anio = '{1}' AND fkestado = '{2}';",
                    fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT idp2 FROM pat_p2 WHERE fadn = '{0}' AND anio = '{1}' AND fkestado IN (1,2);",
                    fadn, anio, estado);
            }
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable P2Parte1Read(string fadn, string anio, int estado)
        {
            query = "";
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            for(int i=4; i < 9; i++)
            {
                if (estado > 1)
                {
                    query = String.Format(query + " SELECT p.idp2 AS idnumero2, pac.renglon AS renglon, " +
                    "pac.proyeccion_egresos AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, " +
                    "p.col_tres AS monto3, p.col_cuatro AS monto4, p.col_cinco AS finanza " +
                    "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac WHERE p.fkestado = '{0}' AND idpadre = '11' AND subpadre = '{1}' OR idprograma_ac = '{1}' GROUP BY(pac.idprograma_ac) " +
                    "UNION ALL " +
                    "SELECT null AS idnumero2, null, CONCAT('SUB TOTAL Q') AS nombre, " +
                    "SUM(p.col_uno) AS monto1, SUM(p.col_dos) AS monto2," +
                    "SUM(p.col_tres) AS monto3, SUM(p.col_cuatro) AS monto4, SUM(p.col_cinco) AS finanza " +
                    "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac " +
                    "WHERE p.fkestado = '{0}' AND idpadre = '1' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '1' ", estado, i, fadn, anio);
                    if (i == 8)
                    {
                        mysql.AbrirConexion();
                        MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
                        consulta.Fill(dt);
                        mysql.CerrarConexion();
                        return dt;
                    }
                    else
                    {
                        query = String.Format(query + " UNION ALL");
                    }
                }
                else
                {
                    query = String.Format(query + " SELECT p.idp2 AS idnumero2, pac.renglon AS renglon, " +
                    "pac.proyeccion_egresos AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, " +
                    "p.col_tres AS monto3, p.col_cuatro AS monto4, p.col_cinco AS finanza " +
                    "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac WHERE p.fkestado IN (1,2) AND idpadre = '1' AND subpadre = '{1}' OR idprograma_ac = '{1}' GROUP BY(pac.idprograma_ac) " +
                    "UNION ALL " +
                    "SELECT null AS idnumero2, null, CONCAT('SUB TOTAL Q') AS nombre, " +
                    "SUM(p.col_uno) AS monto1, SUM(p.col_dos) AS monto2," +
                    "SUM(p.col_tres) AS monto3, SUM(p.col_cuatro) AS monto4, SUM(p.col_cinco) AS finanza " +
                    "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac " +
                    "WHERE p.fkestado IN (1,2) AND idpadre = '1' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '1'", estado, i, fadn, anio);
                    if (i == 8)
                    {
                        mysql.AbrirConexion();
                        MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
                        consulta.Fill(dt);
                        mysql.CerrarConexion();
                        return dt;
                    }
                    else
                    {
                        query = String.Format(query + " UNION ALL");
                    }
                }
            }
            return dt;
        }

        public DataTable P2Parte2Read(string fadn, string anio, int estado)
        {
            query = "";
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            for (int i = 4; i < 9; i++)
            {
                if (estado > 1)
                {
                    query = String.Format(query + " SELECT p.idp2 AS idnumero2, pac.renglon AS renglon, " +
                    "pac.proyeccion_egresos AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, " +
                    "p.col_tres AS monto3, p.col_cuatro AS monto4, p.col_cinco AS finanza " +
                    "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac WHERE p.fkestado = '{0}' AND idpadre = '2' AND subpadre = '{1}' OR idprograma_ac = '{1}' GROUP BY(pac.idprograma_ac) " +
                    "UNION ALL " +
                    "SELECT null AS idnumero2, null, CONCAT('SUB TOTAL Q') AS nombre, " +
                    "SUM(p.col_uno) AS monto1, SUM(p.col_dos) AS monto2," +
                    "SUM(p.col_tres) AS monto3, SUM(p.col_cuatro) AS monto4, SUM(p.col_cinco) AS finanza " +
                    "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac " +
                    "WHERE p.fkestado = '{0}' AND idpadre = '2' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '2'", estado, i, fadn, anio);
                    if (i == 8)
                    {
                        mysql.AbrirConexion();
                        MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
                        consulta.Fill(dt);
                        mysql.CerrarConexion();
                        return dt;
                    }
                    else
                    {
                        query = String.Format(query + " UNION ALL");
                    }
                }
                else
                {
                    query = String.Format(query + " SELECT p.idp2 AS idnumero2, pac.renglon AS renglon, " +
                    "pac.proyeccion_egresos AS nombre, p.col_uno AS monto1, p.col_dos AS monto2, " +
                    "p.col_tres AS monto3, p.col_cuatro AS monto4, p.col_cinco AS finanza " +
                    "FROM pat_p2 p RIGHT JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac WHERE p.fkestado IN (1,2) AND idpadre = '2' AND subpadre = '{1}' OR idprograma_ac = '{1}' GROUP BY(pac.idprograma_ac) " +
                    "UNION ALL " +
                    "SELECT null AS idnumero2, null, CONCAT('SUB TOTAL Q') AS nombre, " +
                    "SUM(p.col_uno) AS monto1, SUM(p.col_dos) AS monto2," +
                    "SUM(p.col_tres) AS monto3, SUM(p.col_cuatro) AS monto4, SUM(p.col_cinco) AS finanza " +
                    "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                    "ON pac.idprograma_ac = p.fkprograma_ac " +
                    "WHERE p.fkestado IN (1,2) AND idpadre = '2' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '2'", estado, i, fadn, anio);
                    if (i == 8)
                    {
                        mysql.AbrirConexion();
                        MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
                        consulta.Fill(dt);
                        mysql.CerrarConexion();
                        return dt;
                    }
                    else
                    {
                        query = String.Format(query + " UNION ALL");
                    }
                }
            }
            return dt;
        }

        public DataTable P2TotalRead(string fadn, string anio, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT idp2 AS idnumero2, CONCAT('TOTAL EGRESOS POR RENGLON Q') AS nombre, " +
                "SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
                "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
                "FROM pat_p2 INNER JOIN admin_programa_ac ON idprograma_ac = fkprograma_ac " +
                "WHERE fkestado = '{0}' AND fadn = '{1}' AND anio = '{2}' AND idpadre = '1' " +
                "UNION " +
                "SELECT idp2 AS idnumero2, CONCAT('TOTAL EGRESOS OTRAS FUENTES Q') AS nombre, SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
                "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
                "FROM pat_p2 INNER JOIN admin_programa_ac ON idprograma_ac = fkprograma_ac " +
                "WHERE fkestado = '{0}' AND fadn = '{1}' AND anio = '{2}' AND idpadre = '2' " +
                "UNION " +
                "SELECT idp2 AS idnumero2, CONCAT('TOTAL GENERAL Q') AS nombre, SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
                "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
                "FROM pat_p2 WHERE fkestado = '{0}' AND fadn = '{1}' AND anio = '{2}'; ", estado, fadn, anio);
            }
            else
            {
                query = String.Format("SELECT idp2 AS idnumero2, CONCAT('TOTAL EGRESOS POR RENGLON Q') AS nombre, " +
                "SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
                "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
                "FROM pat_p2 INNER JOIN admin_programa_ac ON idprograma_ac = fkprograma_ac " +
                "WHERE fkestado IN (1,2) AND fadn = '{1}' AND anio = '{2}' AND idpadre = '1' " +
                "UNION " +
                "SELECT idp2 AS idnumero2, CONCAT('TOTAL EGRESOS OTRAS FUENTES Q') AS nombre, SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
                "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
                "FROM pat_p2 INNER JOIN admin_programa_ac ON idprograma_ac = fkprograma_ac " +
                "WHERE fkestado IN (1,2) AND fadn = '{1}' AND anio = '{2}' AND idpadre = '2' " +
                "UNION " +
                "SELECT idp2 AS idnumero2, CONCAT('TOTAL GENERAL Q') AS nombre, SUM(col_uno) AS total1, SUM(col_dos) AS total2, " +
                "SUM(col_tres) AS total3, SUM(col_cuatro) AS total4, SUM(col_cinco) AS total5 " +
                "FROM pat_p2 WHERE fkestado IN (1,2) AND fadn = '{1}' AND anio = '{2}'; ", estado, fadn, anio);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable P2Create(ModeloP2 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_p2 (col_uno, col_dos, col_tres, col_cuatro, col_cinco, fkprograma_ac, fadn, anio, fkestado) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}'); ",
            objCrear.col_uno, objCrear.col_dos, objCrear.col_tres, objCrear.col_cuatro, objCrear.col_cinco, objCrear.fkprograma, objCrear.fadn, objCrear.ano, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable P2Seleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT p.idp2, pac.idpadre, pac.subpadre, p.fkprograma_ac, p.col_uno, p.col_dos, " +
            "p.col_tres, p.col_cuatro, p.col_cinco " +
            "FROM pat_p2 p " +
            "INNER JOIN admin_programa_ac pac ON pac.idprograma_ac = p.fkprograma_ac " +
            "WHERE p.idp2 = '{0}'; ", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean P2Update(ModeloP2 o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_p2 SET fkestado = '{0}' WHERE idp2 = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_p2 SET fkprograma_ac = '{0}', col_uno = '{1}', col_dos = '{2}', " +
                "col_tres = '{3}', col_cuatro = '{4}', col_cinco = '{5}' WHERE idp2 = '{6}'; ",
                o.fkprograma, o.col_uno, o.col_dos, o.col_tres, o.col_cuatro, o.col_cinco, id);
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

        public int P2Estado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_p2 WHERE idp2 = '{0}'", id);
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

        public bool P2Search(int ingreso, string fadn, string anio)
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

        public string P2VerificarMonto50(string raiz, string fadn, string anio, int estado)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE pac.proyeccion_egresos = '{0}' AND p.fadn = '{1}' AND p.anio = '{2}' AND o.fkestado = '{3}';", raiz, fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE pac.proyeccion_egresos = '{0}' AND p.fadn = '{1}' AND p.anio = '{2}' AND o.fkestado IN (1,2);", raiz, fadn, anio, estado);
            }

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

        public string P2VerificarMonto30(int raiz, int id, string fadn, string anio, int estado)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}' AND p.fkestado = '{4}';", 
                raiz, id, fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}' AND p.fkestado IN (1,2);",
                raiz, id, fadn, anio, estado);
            }
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

        public string P2VerificarMonto20(int raiz, int id, string fadn, string anio, int estado)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}' AND p.fkestado = '{4}'; ", 
                raiz, id, fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}' AND p.fkestado IN (1,2); ",
                raiz, id, fadn, anio, estado);
            }
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

        public string P2VerificarMonto100(int raiz, int id, string fadn, string anio, int estado)
        {
            opcion = null;
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}' AND p.fkestado = '{4}'; ", 
                raiz, id, fadn, anio, estado);
            }
            else
            {
                query = String.Format("SELECT p.col_uno AS monto1, p.col_dos AS monto2, " +
                "p.col_tres AS monto3, p.col_cuatro AS monto4 " +
                "FROM pat_p2 p INNER JOIN admin_programa_ac pac " +
                "ON pac.idprograma_ac = p.fkprograma_ac " +
                "WHERE idpadre = '{0}' AND subpadre = '{1}' AND fadn = '{2}' AND anio = '{3}' AND idprograma_ac != '{0}' AND p.fkestado IN (1,2); ",
                raiz, id, fadn, anio, estado);
            }
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