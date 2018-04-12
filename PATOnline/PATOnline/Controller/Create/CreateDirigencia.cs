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
    public class CreateDirigencia
    {
        public string query = "";
        public DataTable DirigenciaCreate(ModeloDirigencia objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_dirigencia_deportiva_fadn " +
            "(primer_nombre, segundo_nombre, primer_apellido, segundo_apellido, inicio_cargo, fin_cargo, " +
            "periodo, fktipo_personal_fadn, fkcargo, fkestado, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', STR_TO_DATE('{4}', '%Y-%m-%d'), DATE_ADD('{5}', INTERVAL {6} DAY), " +
            "'{7}', '{8}', '{9}', '{10}', '{11}', '{12}'); ",
            objCrear.nombre1, objCrear.nombre2, objCrear.apellido1, objCrear.apellido2, objCrear.inicio, objCrear.inicio, objCrear.fin,
            objCrear.periodo, objCrear.fk_persona, objCrear.fk_cargo, objCrear.fk_estado, objCrear.fadn, objCrear.anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}