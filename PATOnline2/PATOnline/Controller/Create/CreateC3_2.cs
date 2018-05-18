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
    public class CreateC3_2
    {
        public string query = "";
        public DataTable C3_2Create(ModeloC3 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c3_2 (codigo, edades, masculino, femenino, total_f_m, registro, " +
            "inicio_dia, inicio_mes, fin_dia, fin_mes, departamento, lugar, presupuesto, " +
            "fkactividad, fkcategoria, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}');", 
            objCrear.codigo, objCrear.edades, objCrear.masculino, objCrear.femenino, objCrear.total, objCrear.registro,
            objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes, objCrear.departamento, objCrear.lugar, objCrear.presupuesto,
            objCrear.fkactividad, objCrear.fkcategoria, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}