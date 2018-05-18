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
    public class CreateP2
    {
        public string query = "";
        public DataTable P2Create(ModeloP2 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_p2 (col_uno, col_dos, col_tres, col_cuatro, col_cinco, fkprograma_ac, fadn, anio) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'); ",
            objCrear.col_uno, objCrear.col_dos, objCrear.col_tres, objCrear.col_cuatro, objCrear.col_cinco, objCrear.fkprograma, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}