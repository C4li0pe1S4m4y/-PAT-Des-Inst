using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class Bitacora
    {

        public string query = "";

        //Funcion para crear un nuevo registro
        public DataTable historialBitacora(ModeloBitacora o)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO reg_bitacora (tabla, accion, id, info, usuario) " +
            "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", o.tabla, o.accion, o.id, o.info, o.usuario);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

    }
}