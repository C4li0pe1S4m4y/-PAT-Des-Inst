﻿using MySql.Data.MySqlClient;
using System;
using PATOnline.Models;

namespace PATOnline.Controller.Update
{
    public class UpdateIntroduccionBaseLegal
    {
        public string query = "";
        public Boolean UpdateIntroBaseLegal(ModeloIntroBaseLegal objEditar, int id, int estado)
        {
            var mysql = new DBConnection.ConexionMysql();

            if(estado > 1)
            {
                query = String.Format("UPDATE pat_informacion SET fkestado = '{0}' WHERE idinformacion = '{1}'; ", estado, id);
            }
            else
            {
                query = String.Format("UPDATE pat_informacion SET introduccion = '{0}', marco_juridico = '{1}', " +
                "afiliacion_organizacion = '{2}' WHERE idinformacion = '{3}'; ",
                objEditar.intro, objEditar.marco, objEditar.afiliacion, id);
            }

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