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
    public class CreateInfoBaseLegal
    {
        public string query = "";
        public DataTable InfoCreate(ModeloIntroBaseLegal objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_informacion (introduccion, marco_juridico, afiliacion_organizacion, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}');",objCrear.intro, objCrear.marco, objCrear.afiliacion, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}