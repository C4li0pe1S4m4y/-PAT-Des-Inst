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
    public class CreateFA
    {
        public string query = "";
        public DataTable FACreate(ModeloFADN objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO dbsecretaria.sg_fadn (nombre, Direccion, Fecha_creacion, telefono, correo_electronico) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}');", objCrear.nombre, objCrear.direccion, objCrear.fecha, objCrear.telefono, objCrear.correo);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}