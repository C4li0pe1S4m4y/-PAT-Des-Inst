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
    public class CreateIngreso
    {
        public string query = "";
        public DataTable IngresoCreate(ModeloIngreso objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO admin_ingreso_corriente (codigo, nombre, idpadre, subpadre, fadn) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}'); ",
            objCrear.codigo, objCrear.nombre, objCrear.idpadre, objCrear.subpadre, objCrear.fadn);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}