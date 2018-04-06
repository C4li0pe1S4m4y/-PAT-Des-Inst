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
    public class CreateP3
    {
        public string query = "";
        public DataTable P3Create(ModeloP3 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_p3 (codigo, promocion, programa, actividad, subtotal, otra_fuente, total, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}');",
            objCrear.codigo, objCrear.promocion, objCrear.programa, objCrear.actividad, objCrear.subtoltal, objCrear.otra_fuente, objCrear.total, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}