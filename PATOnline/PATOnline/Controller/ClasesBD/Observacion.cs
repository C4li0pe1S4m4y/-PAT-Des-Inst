using MySql.Data.MySqlClient;
using System;
using System.Data;
using PATOnline.Models;

namespace PATOnline.Controller.ClasesBD
{
    public class Observacion
    {
        public string query = "";
        public string where;

        //Funcion para crear un nuevo registro en Observacion FADN
        public DataTable observacionCreateFADN(ModeloObservacion o)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("INSERT INTO seg_observacion_fadn (fkinformacion, fkanalisis_brecha, fkanalisis_puesto, fkc1, " +
            "fkc1_1, fkc2, fkc2_1, fkc2_2, fkc2_3, fkc3, fkc3_1, fkc3_2, fkc4, " +
            "fkc4_1, fkc4_2, fkc4_3, fkcpe, fkdirigencia_deportiva_fadn, " +
            "fkfoda_baestrategica, fkorganigrama, fkp1, fkp2, fkp3, fkpe1, fkpe2, " +
            "fkpotencia_ag, fkresultado_dih, fkusuario, observacion) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', " +
            "'{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', " +
            "'{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}')", o.id0, o.id1, o.id2, o.id3, o.id4, o.id5, 
            o.id6, o.id7, o.id8, o.id9, o.id10, o.id11, o.id12, o.id13, o.id14, o.id15, o.id16, o.id17, o.id18, o.id19, o.id20,
            o.id21, o.id22, o.id23, o.id24, o.id25, o.id26, o.usuario, o.observacion);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable observacionCreateAcompaniamiento(ModeloObservacion o)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            o.fecha = DateTime.Now;
            query = String.Format("INSERT INTO seg_observacion_acompaniamiento (fkinformacion, fkanalisis_brecha, fkanalisis_puesto, fkc1, " +
            "fkc1_1, fkc2, fkc2_1, fkc2_2, fkc2_3, fkc3, fkc3_1, fkc3_2, fkc4, " +
            "fkc4_1, fkc4_2, fkc4_3, fkcpe, fkdirigencia_deportiva_fadn, " +
            "fkfoda_baestrategica, fkorganigrama, fkp1, fkp2, fkp3, fkpe1, fkpe2, " +
            "fkpotencia_ag, fkresultado_dih, fkusuario, observacion) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', " +
            "'{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', " +
            "'{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}')", o.id0, o.id1, o.id2, o.id3, o.id4, o.id5,
            o.id6, o.id7, o.id8, o.id9, o.id10, o.id11, o.id12, o.id13, o.id14, o.id15, o.id16, o.id17, o.id18, o.id19, o.id20,
            o.id21, o.id22, o.id23, o.id24, o.id25, o.id26, o.usuario, o.observacion);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable observacionCreateEvaluador(ModeloObservacion o)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            o.fecha = DateTime.Now;
            query = String.Format("INSERT INTO seg_observacion_evaluador (fkinformacion, fkanalisis_brecha, fkanalisis_puesto, fkc1, " +
            "fkc1_1, fkc2, fkc2_1, fkc2_2, fkc2_3, fkc3, fkc3_1, fkc3_2, fkc4, " +
            "fkc4_1, fkc4_2, fkc4_3, fkcpe, fkdirigencia_deportiva_fadn, " +
            "fkfoda_baestrategica, fkorganigrama, fkp1, fkp2, fkp3, fkpe1, fkpe2, " +
            "fkpotencia_ag, fkresultado_dih, fkusuario, observacion) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', " +
            "'{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', " +
            "'{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}')", o.id0, o.id1, o.id2, o.id3, o.id4, o.id5,
            o.id6, o.id7, o.id8, o.id9, o.id10, o.id11, o.id12, o.id13, o.id14, o.id15, o.id16, o.id17, o.id18, o.id19, o.id20,
            o.id21, o.id22, o.id23, o.id24, o.id25, o.id26, o.usuario, o.observacion);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }


        public DataTable observacionMostrarFADN(int id, int posicion)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            switch (posicion)
            {
                case 1:
                    where = "oe.fkinformacion";
                    break;
                case 2:
                    where = "oe.fkanalisis_brecha";
                    break;
                case 3:
                    where = "oe.fkanalisis_puesto";
                    break;
                case 4:
                    where = "oe.fkc1";
                    break;
                case 5:
                    where = "oe.fkc1_1";
                    break;
                case 6:
                    where = "oe.fkc2";
                    break;
                case 7:
                    where = "oe.fkc2_1";
                    break;
                case 8:
                    where = "oe.fkc2_2";
                    break;
                case 9:
                    where = "oe.fkc2_3";
                    break;

                case 10:
                    where = "oe.fkc3";
                    break;
                case 11:
                    where = "oe.fkc3_1";
                    break;
                case 12:
                    where = "oe.fkc3_2";
                    break;
                case 13:
                    where = "oe.fkc4";
                    break;
                case 14:
                    where = "oe.fkc4_1";
                    break;
                case 15:
                    where = "oe.fkc4_2";
                    break;
                case 16:
                    where = "oe.fkc4_3";
                    break;
                case 17:
                    where = "oe.fkcpe";
                    break;
                case 18:
                    where = "oe.fkdirigencia_deportiva_fadn";
                    break;
                case 19:
                    where = "oe.fkfoda_baestrategica";
                    break;

                case 20:
                    where = "oe.fkorganigrama";
                    break;
                case 21:
                    where = "oe.fkp1";
                    break;
                case 22:
                    where = "oe.fkp2";
                    break;
                case 23:
                    where = "oe.fkp3";
                    break;
                case 24:
                    where = "oe.fkpe1";
                    break;
                case 25:
                    where = "oe.fkpe2";
                    break;
                case 26:
                    where = "oe.fkpotencia_ag";
                    break;
                case 27:
                    where = "oe.fkresultado_dih";
                    break;
            }

            query = String.Format("SELECT oe.idobservacion_fadn AS numero, oe.observacion AS observacion, oe.fecha AS fecha, " +
            "CONCAT(u.primer_nombre, ' ', u.segundo_nombre, ' ', u.primer_apellido, ' ', segundo_apellido) " +
            "AS usuario FROM seg_observacion_fadn oe " +
            "INNER JOIN seg_usuario u ON u.idusuario = oe.fkusuario " +
            "WHERE " + where + " = '{0}'", id);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable observacionMostrarAcompaniamiento(int id, int posicion)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            switch (posicion)
            {
                case 1:
                    where = "oe.fkinformacion";
                    break;
                case 2:
                    where = "oe.fkanalisis_brecha";
                    break;
                case 3:
                    where = "oe.fkanalisis_puesto";
                    break;
                case 4:
                    where = "oe.fkc1";
                    break;
                case 5:
                    where = "oe.fkc1_1";
                    break;
                case 6:
                    where = "oe.fkc2";
                    break;
                case 7:
                    where = "oe.fkc2_1";
                    break;
                case 8:
                    where = "oe.fkc2_2";
                    break;
                case 9:
                    where = "oe.fkc2_3";
                    break;

                case 10:
                    where = "oe.fkc3";
                    break;
                case 11:
                    where = "oe.fkc3_1";
                    break;
                case 12:
                    where = "oe.fkc3_2";
                    break;
                case 13:
                    where = "oe.fkc4";
                    break;
                case 14:
                    where = "oe.fkc4_1";
                    break;
                case 15:
                    where = "oe.fkc4_2";
                    break;
                case 16:
                    where = "oe.fkc4_3";
                    break;
                case 17:
                    where = "oe.fkcpe";
                    break;
                case 18:
                    where = "oe.fkdirigencia_deportiva_fadn";
                    break;
                case 19:
                    where = "oe.fkfoda_baestrategica";
                    break;

                case 20:
                    where = "oe.fkorganigrama";
                    break;
                case 21:
                    where = "oe.fkp1";
                    break;
                case 22:
                    where = "oe.fkp2";
                    break;
                case 23:
                    where = "oe.fkp3";
                    break;
                case 24:
                    where = "oe.fkpe1";
                    break;
                case 25:
                    where = "oe.fkpe2";
                    break;
                case 26:
                    where = "oe.fkpotencia_ag";
                    break;
                case 27:
                    where = "oe.fkresultado_dih";
                    break;
            }

            query = String.Format("SELECT oe.idobservacion_acompaniamiento AS numero, oe.observacion AS observacion, oe.fecha AS fecha,  " +
            "CONCAT(u.primer_nombre, ' ', u.segundo_nombre, ' ', u.primer_apellido, ' ', segundo_apellido) " +
            "AS usuario FROM seg_observacion_acompaniamiento oe " +
            "INNER JOIN seg_usuario u ON u.idusuario = oe.fkusuario " +
            "WHERE " + where + " = '{0}'", id);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable observacionMostrarEvaluador(int id, int posicion)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            switch (posicion)
            {
                case 1:
                    where = "oe.fkinformacion";
                    break;
                case 2:
                    where = "oe.fkanalisis_brecha";
                    break;
                case 3:
                    where = "oe.fkanalisis_puesto";
                    break;
                case 4:
                    where = "oe.fkc1";
                    break;
                case 5:
                    where = "oe.fkc1_1";
                    break;
                case 6:
                    where = "oe.fkc2";
                    break;
                case 7:
                    where = "oe.fkc2_1";
                    break;
                case 8:
                    where = "oe.fkc2_2";
                    break;
                case 9:
                    where = "oe.fkc2_3";
                    break;

                case 10:
                    where = "oe.fkc3";
                    break;
                case 11:
                    where = "oe.fkc3_1";
                    break;
                case 12:
                    where = "oe.fkc3_2";
                    break;
                case 13:
                    where = "oe.fkc4";
                    break;
                case 14:
                    where = "oe.fkc4_1";
                    break;
                case 15:
                    where = "oe.fkc4_2";
                    break;
                case 16:
                    where = "oe.fkc4_3";
                    break;
                case 17:
                    where = "oe.fkcpe";
                    break;
                case 18:
                    where = "oe.fkdirigencia_deportiva_fadn";
                    break;
                case 19:
                    where = "oe.fkfoda_baestrategica";
                    break;

                case 20:
                    where = "oe.fkorganigrama";
                    break;
                case 21:
                    where = "oe.fkp1";
                    break;
                case 22:
                    where = "oe.fkp2";
                    break;
                case 23:
                    where = "oe.fkp3";
                    break;
                case 24:
                    where = "oe.fkpe1";
                    break;
                case 25:
                    where = "oe.fkpe2";
                    break;
                case 26:
                    where = "oe.fkpotencia_ag";
                    break;
                case 27:
                    where = "oe.fkresultado_dih";
                    break;
            }

            query = String.Format("SELECT oe.idobservacion_evaluador AS numero, oe.observacion AS observacion, oe.fecha AS fecha, " +
            "CONCAT(u.primer_nombre, ' ', u.segundo_nombre, ' ', u.primer_apellido, ' ', segundo_apellido) " +
            "AS usuario FROM seg_observacion_evaluador oe " +
            "INNER JOIN seg_usuario u ON u.idusuario = oe.fkusuario " +
            "WHERE " + where + " = '{0}'", id);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public bool ObservacionCEFADNExiste(int observacion, int posicion)
        {
            var mysql = new DBConnection.ConexionMysql();
            switch (posicion)
            {
                case 1:
                    where = "oe.fkinformacion";
                    break;
                case 2:
                    where = "oe.fkanalisis_brecha";
                    break;
                case 3:
                    where = "oe.fkanalisis_puesto";
                    break;
                case 4:
                    where = "oe.fkc1";
                    break;
                case 5:
                    where = "oe.fkc1_1";
                    break;
                case 6:
                    where = "oe.fkc2";
                    break;
                case 7:
                    where = "oe.fkc2_1";
                    break;
                case 8:
                    where = "oe.fkc2_2";
                    break;
                case 9:
                    where = "oe.fkc2_3";
                    break;

                case 10:
                    where = "oe.fkc3";
                    break;
                case 11:
                    where = "oe.fkc3_1";
                    break;
                case 12:
                    where = "oe.fkc3_2";
                    break;
                case 13:
                    where = "oe.fkc4";
                    break;
                case 14:
                    where = "oe.fkc4_1";
                    break;
                case 15:
                    where = "oe.fkc4_2";
                    break;
                case 16:
                    where = "oe.fkc4_3";
                    break;
                case 17:
                    where = "oe.fkcpe";
                    break;
                case 18:
                    where = "oe.fkdirigencia_deportiva_fadn";
                    break;
                case 19:
                    where = "oe.fkfoda_baestrategica";
                    break;

                case 20:
                    where = "oe.fkorganigrama";
                    break;
                case 21:
                    where = "oe.fkp1";
                    break;
                case 22:
                    where = "oe.fkp2";
                    break;
                case 23:
                    where = "oe.fkp3";
                    break;
                case 24:
                    where = "oe.fkpe1";
                    break;
                case 25:
                    where = "oe.fkpe2";
                    break;
                case 26:
                    where = "oe.fkpotencia_ag";
                    break;
                case 27:
                    where = "oe.fkresultado_dih";
                    break;
            }

            query = String.Format("SELECT oe.observacion AS observacion " +
            "FROM seg_observacion_fadn oe " +
            "WHERE " + where + " = '{0}'", observacion);

            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("observacion")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool ObservacionAcompaniamientoExiste(int observacion, int posicion)
        {
            var mysql = new DBConnection.ConexionMysql();
            switch (posicion)
            {
                case 1:
                    where = "oe.fkinformacion";
                    break;
                case 2:
                    where = "oe.fkanalisis_brecha";
                    break;
                case 3:
                    where = "oe.fkanalisis_puesto";
                    break;
                case 4:
                    where = "oe.fkc1";
                    break;
                case 5:
                    where = "oe.fkc1_1";
                    break;
                case 6:
                    where = "oe.fkc2";
                    break;
                case 7:
                    where = "oe.fkc2_1";
                    break;
                case 8:
                    where = "oe.fkc2_2";
                    break;
                case 9:
                    where = "oe.fkc2_3";
                    break;

                case 10:
                    where = "oe.fkc3";
                    break;
                case 11:
                    where = "oe.fkc3_1";
                    break;
                case 12:
                    where = "oe.fkc3_2";
                    break;
                case 13:
                    where = "oe.fkc4";
                    break;
                case 14:
                    where = "oe.fkc4_1";
                    break;
                case 15:
                    where = "oe.fkc4_2";
                    break;
                case 16:
                    where = "oe.fkc4_3";
                    break;
                case 17:
                    where = "oe.fkcpe";
                    break;
                case 18:
                    where = "oe.fkdirigencia_deportiva_fadn";
                    break;
                case 19:
                    where = "oe.fkfoda_baestrategica";
                    break;

                case 20:
                    where = "oe.fkorganigrama";
                    break;
                case 21:
                    where = "oe.fkp1";
                    break;
                case 22:
                    where = "oe.fkp2";
                    break;
                case 23:
                    where = "oe.fkp3";
                    break;
                case 24:
                    where = "oe.fkpe1";
                    break;
                case 25:
                    where = "oe.fkpe2";
                    break;
                case 26:
                    where = "oe.fkpotencia_ag";
                    break;
                case 27:
                    where = "oe.fkresultado_dih";
                    break;
            }

            query = String.Format("SELECT oe.observacion AS observacion " +
            "FROM seg_observacion_acompaniamiento oe " +
            "WHERE " + where + " = '{0}'", observacion);

            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
            using (buscar)
            {
                while (buscar.Read())
                {
                    if (!string.IsNullOrEmpty(buscar.GetString("observacion")))
                    {
                        return true;
                    }
                }
            }
            mysql.CerrarConexion();
            return false;
        }

        public bool ObservacionEvaluadorExiste(int observacion, int posicion)
        {
            var mysql = new DBConnection.ConexionMysql();
            switch (posicion)
            {
                case 1:
                    where = "oe.fkinformacion";
                    break;
                case 2:
                    where = "oe.fkanalisis_brecha";
                    break;
                case 3:
                    where = "oe.fkanalisis_puesto";
                    break;
                case 4:
                    where = "oe.fkc1";
                    break;
                case 5:
                    where = "oe.fkc1_1";
                    break;
                case 6:
                    where = "oe.fkc2";
                    break;
                case 7:
                    where = "oe.fkc2_1";
                    break;
                case 8:
                    where = "oe.fkc2_2";
                    break;
                case 9:
                    where = "oe.fkc2_3";
                    break;

                case 10:
                    where = "oe.fkc3";
                    break;
                case 11:
                    where = "oe.fkc3_1";
                    break;
                case 12:
                    where = "oe.fkc3_2";
                    break;
                case 13:
                    where = "oe.fkc4";
                    break;
                case 14:
                    where = "oe.fkc4_1";
                    break;
                case 15:
                    where = "oe.fkc4_2";
                    break;
                case 16:
                    where = "oe.fkc4_3";
                    break;
                case 17:
                    where = "oe.fkcpe";
                    break;
                case 18:
                    where = "oe.fkdirigencia_deportiva_fadn";
                    break;
                case 19:
                    where = "oe.fkfoda_baestrategica";
                    break;

                case 20:
                    where = "oe.fkorganigrama";
                    break;
                case 21:
                    where = "oe.fkp1";
                    break;
                case 22:
                    where = "oe.fkp2";
                    break;
                case 23:
                    where = "oe.fkp3";
                    break;
                case 24:
                    where = "oe.fkpe1";
                    break;
                case 25:
                    where = "oe.fkpe2";
                    break;
                case 26:
                    where = "oe.fkpotencia_ag";
                    break;
                case 27:
                    where = "oe.fkresultado_dih";
                    break;
            }

            query = String.Format("SELECT oe.observacion AS observacion " +
            "FROM seg_observacion_evaluador oe " +
            "WHERE " + where + " = '{0}'", observacion);

            mysql.AbrirConexion();
            MySqlCommand consulta = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader buscar = consulta.ExecuteReader();
                using (buscar)
                {
                    while (buscar.Read())
                    {
                        if (!string.IsNullOrEmpty(buscar.GetString("observacion")))
                        {
                            return true;
                        }
                    }
                }
                mysql.CerrarConexion();
                return false;
        }

        public DataTable observacionUpdateAcompaniamiento(int id, string observacion)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("UPDATE seg_observacion_acompaniamiento oe SET oe.observacion = '{0}' WHERE idobservacion_acompaniamiento = '{1}'", observacion, id);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}