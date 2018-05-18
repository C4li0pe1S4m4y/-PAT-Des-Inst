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
    public class CreateC3_1
    {
        public string query = "";
        public DataTable C3_1Create(ModeloC3 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c3_1 (codigo, nombre_competencia, edades, fase_evento, resultado, " +
            "registro, inicio_dia, inicio_mes, fin_dia, fin_mes, lugar, presupuesto, fkclasificacion, " +
            "fknivel, fkcategoria, fkpais_departamento, fadn, ano) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');",
            objCrear.codigo, objCrear.nombre_competencia, objCrear.edades, objCrear.fase_evento, objCrear.resultado,
            objCrear.registro, objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes, objCrear.lugar, objCrear.presupuesto, objCrear.fkclasificacion,
            objCrear.fknivel, objCrear.fkcategoria, objCrear.fkdepartamento, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}