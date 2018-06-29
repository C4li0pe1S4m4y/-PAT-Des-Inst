using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace PATOnline.Controller.Read
{
    public class ReadFADN
    {
        public string query = "";
        public string add = "";
        public DataTable FADNRead(string username, string fadn)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if(fadn == "Confederación Deportiva Autónoma de Guatemala")
            {
                add = ";";
            }
            else
            {
                add = " WHERE nombre = {0};";
            }
            query = String.Format("SELECT id_fand, nombre, Direccion, telefono, correo_electronico, logo " +
            "FROM dbsecretaria.sg_fadn " +
            "LEFT JOIN dbsecretaria.sg_logotipo ON fkfadn = id_fand" + add, username);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}
