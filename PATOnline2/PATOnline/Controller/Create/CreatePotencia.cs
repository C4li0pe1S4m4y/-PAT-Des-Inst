using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PATOnline.Models;

namespace PATOnline.Controller.Create
{
    public class CreatePotencia
    {
        public string query = "";
        public DataTable PotenciaCreate(ModeloPotencia objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_potencia_ag (primera_potencia, segunda_potencia, tercera_potencia, posicion_guatemala, fknivel, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
            objCrear.primera, objCrear.segunda, objCrear.tercera, objCrear.potencia, objCrear.fknivel, objCrear.fadn, objCrear.anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}