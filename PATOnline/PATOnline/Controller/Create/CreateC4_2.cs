using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using PATOnline.Models;

namespace PATOnline.Controller.Create
{
    public class CreateC4_2
    {
        public string query = "";
        public DataTable C4_2Create(ModeloC4 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c4_2 (codigo, actividad, fknivel, fkobjetivo, fketapa_prepacion, " +
            "fkcategoria, linea, registro, inicio_dia, inicio_mes, fin_dia, fin_mes, departamento, " +
            "fkpais_departamento, lugar, presupuesto, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');",
            objCrear.codigo, objCrear.actividad, objCrear.fknivel, objCrear.fkobjetivo, objCrear.fketapa_prepacion,
            objCrear.fkcategoria, objCrear.linea, objCrear.registro, objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes, objCrear.departamento,
            objCrear.fkpais_departamento, objCrear.lugar, objCrear.presupuesto, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}