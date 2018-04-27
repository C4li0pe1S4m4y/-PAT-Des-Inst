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
    public class CreateC1_1
    {
        public string query = "";
        public DataTable C1_1Create(ModeloC1 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c1_1 (codigo, resultado, descripcion, registro, inicio_dia, inicio_mes, fin_dia, " +
            "fin_mes, lugar, presupuesto, fkactividad_pat, fkpais_departamento, fkcategoria, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}'); ",
            objCrear.codigo, objCrear.resultado, objCrear.descripcion, objCrear.registro, objCrear.i_dia, objCrear.i_mes, 
            objCrear.f_dia, objCrear.f_mes, objCrear.lugar, objCrear.prespuesto, objCrear.fkactividad, 
            objCrear.fkpais_departamento, objCrear.categoria, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}