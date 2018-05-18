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
    public class CreateCPE
    {
        public string query = "";
        public DataTable CPECreate(ModeloCPE objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_cpe (ene_abr, may_ago, sep_dic, presupuesto, fkformato_c, fadn, ano, anual) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'); ",
            objCrear.mes1, objCrear.mes2, objCrear.mess3, objCrear.presupuesto, objCrear.fkformato_ce, objCrear.fadn, objCrear.ano, objCrear.anual);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}