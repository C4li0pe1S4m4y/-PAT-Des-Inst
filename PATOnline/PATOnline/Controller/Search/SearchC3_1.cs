﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Search
{
    public class SearchC3_1
    {
        public string query = "";
        public int codigo;
        public double presupuesto;
        public int CodigoC3_1(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT RIGHT(codigo,3) AS numero FROM pat_c3_1 " +
            "WHERE idc3_1 = (SELECT MAX(idc3_1) FROM pat_c3_1 WHERE fadn = '{0}' AND ano = '{1}'); ", fadn, ano);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    codigo = int.Parse(reader["numero"].ToString());
                }
            }
            mysql.CerrarConexion();
            return codigo;
        }

        public bool ExisteCodigoC3_1(string codigo, string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SELECT codigo FROM pat_c3_1 WHERE codigo='{0}' AND fadn='{1}' AND ano='{2}';", codigo, fadn, ano);
            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("codigo")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public double PresupuestoC3_1(string fadn, string ano)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            query = String.Format("SELECT cpe.presupuesto AS numero FROM pat_c3 cpe " +
            "INNER JOIN admin_formato_c f ON f.idformato_c = cpe.fkformato_c " +
            "WHERE cpe.fadn = '{0}' AND cpe.ano = '{1}' " +
            "AND f.nombre = 'C3.1 Sistema Competitivo Nacional';", fadn, ano);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                presupuesto = double.Parse(reader["numero"].ToString());
            }
            else
            {
                presupuesto = 0;
            }
            mysql.CerrarConexion();
            return presupuesto;
        }
    }
}