using MySql.Data.MySqlClient;
using System;
using PATOnline.Models;

namespace PATOnline.Controller.Update
{
    public class UpdateFADN
    {
        public string query = "";

        public Boolean UpdateLogotipo(ModeloLogotipo objEditar, int id)
        {
            var mysql = new DBConnection.ConexionMysql();
            query = String.Format("SET SQL_SAFE_UPDATES=0; " +
            "UPDATE dbsecretaria.sg_logotipo SET logo = '{0}', fkfadn = '{1}' WHERE idbrecha = '{2}';",
            objEditar.logo, objEditar.fkfadn, id);
            try
            {
                mysql.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
                cmd.ExecuteNonQuery();
                mysql.CerrarConexion();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}