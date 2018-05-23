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
    public class CreateFodaBEstrategica
    {
        public string query = "";
        public DataTable FODABEstrategicaCreate(ModeloFodaBEstrategica objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_foda_baestrategica (fortaleza, oportunidad, debilidad, amenaza, mision, vision, valor) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');", 
            objCrear.fortaleza, objCrear.oportunidad, objCrear.debilidad, objCrear.amenaza, objCrear.mision, objCrear.vision, objCrear.valor);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}