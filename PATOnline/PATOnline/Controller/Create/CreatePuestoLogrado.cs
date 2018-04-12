using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PATOnline.Models;

namespace PATOnline.Controller.Create
{
    public class CreatePuestoLogrado
    {
        public string query = "";
        public DataTable PuestoLogradoCreate(ModeloPuestoLogrado objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_analisis_puesto (puesto_obtenido, puntos, observacion, fkanio, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'); ",
            objCrear.puesto, objCrear.punteo, objCrear.observacion, objCrear.fkanio, objCrear.fadn, objCrear.anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}