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
    public class CreatRolPermiso
    {
        public string query = "";
        public DataTable RolPermisoCreate(ModeloRolPermiso objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO seg_menu_boton (fkmenu, fkboton, fkrol) " +
            "VALUES('{0}', '{1}', '{2}'); ", objCrear.idmenu, objCrear.idboton, objCrear.idrol);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}