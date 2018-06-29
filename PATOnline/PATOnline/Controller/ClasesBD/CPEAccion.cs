using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class CPEAccion
    {
        public string query = "";
        private double total_p1;
        private double total_p3;

        public DataTable CPERead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT '0' as numero, fc.nombre as formato, " +
                "null as mes1, null as mes2, null as mes3, null as anual, null as presupuesto " +
                "FROM admin_formato_c fc WHERE fc.idformato_c = '1' " +
                "UNION ALL " +
                "SELECT cpe.idcpe as numero, fc.nombre as formato, " +
                "cpe.ene_abr as mes1, cpe.may_ago as mes2, cpe.sep_dic as mes3, " +
                "cpe.anual as anual, CONCAT('Q ', cpe.presupuesto) as presupuesto " +
                "FROM pat_cpe cpe " +
                "INNER JOIN admin_formato_c fc ON fc.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' " +
                "AND cpe.ano = '{1}' AND cpe.fkestado = '{2}';", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT '0' as numero, fc.nombre as formato, " +
                "null as mes1, null as mes2, null as mes3, null as anual, null as presupuesto " +
                "FROM admin_formato_c fc WHERE fc.idformato_c = '1' " +
                "UNION ALL " +
                "SELECT cpe.idcpe as numero, fc.nombre as formato, " +
                "cpe.ene_abr as mes1, cpe.may_ago as mes2, cpe.sep_dic as mes3, " +
                "cpe.anual as anual, CONCAT('Q ', cpe.presupuesto) as presupuesto " +
                "FROM pat_cpe cpe " +
                "INNER JOIN admin_formato_c fc ON fc.idformato_c = cpe.fkformato_c " +
                "WHERE cpe.fadn = '{0}' " +
                "AND cpe.ano = '{1}' AND cpe.fkestado IN(1, 2);", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CPETotalRead(string fadn, string ano, int estado)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(estado > 1)
            {
                query = String.Format("SELECT cpe.idcpe AS numero, SUM(cpe.presupuesto) AS total " +
                "FROM pat_cpe cpe WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '{2}'; ", fadn, ano, estado);
            }
            else
            {
                query = String.Format("SELECT cpe.idcpe AS numero, SUM(cpe.presupuesto) AS total " +
                "FROM pat_cpe cpe WHERE fadn = '{0}' AND ano = '{1}' AND fkestado IN(1, 2); ", fadn, ano, estado);
            }

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CPECreate(ModeloCPE objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_cpe (ene_abr, may_ago, sep_dic, presupuesto, fkformato_c, fadn, ano, anual, fkestado) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}'); ",
            objCrear.mes1, objCrear.mes2, objCrear.mess3, objCrear.presupuesto, objCrear.fkformato_ce, objCrear.fadn, objCrear.ano, objCrear.anual, objCrear.fkestado);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable CPESeleccionar(int id)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();

            query = String.Format("SELECT cpe.idcpe as numero, fc.nombre as formato, " +
            "cpe.ene_abr as mes1, cpe.may_ago as mes2, cpe.sep_dic as mes3, " +
            "cpe.anual as anual, cpe.presupuesto as presupuesto " +
            "FROM pat_cpe cpe " +
            "INNER JOIN admin_formato_c fc ON fc.idformato_c = cpe.fkformato_c " +
            "WHERE cpe.idcpe = '{0}';", id);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public Boolean CPEUpdate(ModeloCPE o, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();
            if (estado > 1)
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_cpe SET fkestado = '{0}' WHERE idcpe = '{1}'",
                estado, id);
            }
            else
            {
                query = String.Format("SET SQL_SAFE_UPDATES=0; " +
                "UPDATE pat_cpe SET ene_abr = '{1}', may_ago = '{2}', " +
                "sep_dic = '{3}', anual = '{4}', presupuesto = '{5}' WHERE idcpe = '{6}';",
                o.mes1, o.mes2, o.mess3, o.anual, o.presupuesto, id);
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

        public int CPEEstado(int id)
        {
            try
            {
                var mysql = new DBConnection.ConexionMysql();
                query = String.Format("SELECT fkestado FROM pat_cpe " +
                "WHERE idcpe = '{0}'", id);
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

        public bool ExisteCPE(int formato, string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT fkformato_c FROM pat_cpe WHERE fkformato_c = '{0}' AND ano = '{1}' AND fadn = '{2}';", formato, anio, fadn);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("fkformato_c")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public double VerificarMontoP1(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT p1.col_uno AS total_p1 FROM pat_p1 p1 INNER JOIN admin_ingreso_corriente ic " +
            "ON ic.idingreso_corriente = p1.fkingreso_corriente " +
            "WHERE ic.fadn = '{0}' AND ic.nombre = 'De Gobierno Central (Aprobado en Asamblea de CDAG)' " +
            "AND p1.fadn = '{0}' AND p1.ano = '{1}'; ", fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    total_p1 = Convert.ToDouble(buscar["total_p1"].ToString());
                }
            }
            mysql.CerrarConexion();
            return total_p1;
        }

        public double VerificarMontoP3(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT SUM(p3.total) AS total_p3 FROM pat_p3 p3 " +
            "WHERE p3.fadn = '{0}' AND p3.ano = '{1}'; ", fadn, anio);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                if (buscar.Read())
                {
                    total_p3 = Convert.ToDouble(buscar["total_p3"].ToString());
                }
            }
            mysql.CerrarConexion();
            return total_p3;
        }

        public double MontoP1_Igual_P3(string fadn, string anio)
        {
            double monto = VerificarMontoP1(fadn, anio) - VerificarMontoP3(fadn, anio);
            return monto;
        }
    }
}