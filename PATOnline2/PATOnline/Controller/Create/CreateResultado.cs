using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PATOnline.Models;

namespace PATOnline.Controller.Create
{
    public class CreateResultado
    {
        public string query = "";
        public DataTable ResultadoCreate(ModeloResultado objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_resultado_dih (nombre, sede, fecha, resultado, observacion, fknivel, fkcategoria, fadn, ano) " +
            "VALUES('{0}', '{1}', STR_TO_DATE('{2}', '%Y-%m-%d'), '{3}', '{4}', '{5}', '{6}', '{7}', '{8}'); ",
            objCrear.nombre, objCrear.sede, objCrear.fecha, objCrear.resultado, objCrear.observacion, objCrear.fknivel, objCrear.fkcategoria, objCrear.fadn, objCrear.anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}