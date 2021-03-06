﻿using MySql.Data.MySqlClient;
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
    public class CreateC4_1
    {
        public string query = "";
        public DataTable C4_1Create(ModeloC4 objCrear)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("INSERT INTO pat_c4_1 (codigo, fkactividad, descripcion, fkobjetivo, fketapa_preparacion, " +
            "dirigido, linea, fkcategoria, registro, inicio_dia, inicio_mes, fin_dia, fin_mes, " +
            "fkpais_departamento, lugar, presupuesto, fadn, ano) " +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', " +
            "'{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}');",
            objCrear.codigo, objCrear.fkactividad, objCrear.descripcion, objCrear.fketapa_prepacion,
            objCrear.dirigido, objCrear.linea, objCrear.fkcategoria, objCrear.registro, objCrear.inicio_dia, objCrear.inicio_mes, objCrear.fin_dia, objCrear.fin_mes,
            objCrear.fkpais_departamento, objCrear.lugar, objCrear.presupuesto, objCrear.fadn, objCrear.ano);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}