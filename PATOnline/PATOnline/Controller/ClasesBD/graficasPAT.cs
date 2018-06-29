using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace PATOnline.Controller.ClasesBD
{
    public class graficasPAT
    {
        public string query = "";
        public DataTable graficaAprobadoRechazadoComite(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT (SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_informacion pat ON pat.idinformacion = s.fkinformacion " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkinformacion)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_informacion pat ON pat.idinformacion = s.fkinformacion " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkinformacion)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_organigrama pat ON pat.idorganigrama = s.fkorganigrama " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkorganigrama)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_organigrama pat ON pat.idorganigrama = s.fkorganigrama " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkorganigrama)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_dirigencia_deportiva_fadn pat ON pat.idasamblea_personal_fadn = s.fkdirigencia_deportiva_fadn " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkdirigencia_deportiva_fadn)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_dirigencia_deportiva_fadn pat ON pat.idasamblea_personal_fadn = s.fkdirigencia_deportiva_fadn " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkdirigencia_deportiva_fadn)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_analisis_puesto pat ON pat.idanalisis_puesto = s.fkanalisis_puesto " +
            "WHERE pat.fadn = '{0}' AND s.observacion = '' GROUP BY(s.fkanalisis_puesto)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_analisis_puesto pat ON pat.idanalisis_puesto = s.fkanalisis_puesto " +
            "WHERE pat.fadn = '{0}' AND s.observacion != '' GROUP BY(s.fkanalisis_puesto)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_analisis_brecha pat ON pat.idanalisis_brecha = s.fkanalisis_brecha " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkanalisis_brecha)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_analisis_brecha pat ON pat.idanalisis_brecha = s.fkanalisis_brecha " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkanalisis_brecha)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_resultado_dih pat ON pat.idresultado_dih = s.fkresultado_dih " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkresultado_dih)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_resultado_dih pat ON pat.idresultado_dih = s.fkresultado_dih " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkresultado_dih)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_potencia_ag pat ON pat.idpotencia_ag = s.fkpotencia_ag " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkpotencia_ag)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_potencia_ag pat ON pat.idpotencia_ag = s.fkpotencia_ag " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkpotencia_ag)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_foda_baestrategica pat ON pat.idfoda_bestrategica = s.fkfoda_baestrategica " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkfoda_baestrategica)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_fadn) AS aprobado " +
            "FROM seg_observacion_fadn s " +
            "INNER JOIN pat_foda_baestrategica pat ON pat.idfoda_bestrategica = s.fkfoda_baestrategica " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkfoda_baestrategica)) AS APROBADO " +
            "FROM seg_observacion_fadn GROUP BY(APROBADO)", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaAprobadoRechazadoAcompaniamiento(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT (SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_informacion pat ON pat.idinformacion = s.fkinformacion " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkinformacion)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_informacion pat ON pat.idinformacion = s.fkinformacion " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkinformacion)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_organigrama pat ON pat.idorganigrama = s.fkorganigrama " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkorganigrama)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_organigrama pat ON pat.idorganigrama = s.fkorganigrama " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkorganigrama)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_dirigencia_deportiva_fadn pat ON pat.idasamblea_personal_fadn = s.fkdirigencia_deportiva_fadn " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkdirigencia_deportiva_fadn)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_dirigencia_deportiva_fadn pat ON pat.idasamblea_personal_fadn = s.fkdirigencia_deportiva_fadn " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkdirigencia_deportiva_fadn)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_analisis_puesto pat ON pat.idanalisis_puesto = s.fkanalisis_puesto " +
            "WHERE pat.fadn = '{0}' AND s.observacion = '' GROUP BY(s.fkanalisis_puesto)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_analisis_puesto pat ON pat.idanalisis_puesto = s.fkanalisis_puesto " +
            "WHERE pat.fadn = '{0}' AND s.observacion != '' GROUP BY(s.fkanalisis_puesto)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_analisis_brecha pat ON pat.idanalisis_brecha = s.fkanalisis_brecha " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkanalisis_brecha)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_analisis_brecha pat ON pat.idanalisis_brecha = s.fkanalisis_brecha " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkanalisis_brecha)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_resultado_dih pat ON pat.idresultado_dih = s.fkresultado_dih " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkresultado_dih)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_resultado_dih pat ON pat.idresultado_dih = s.fkresultado_dih " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkresultado_dih)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_potencia_ag pat ON pat.idpotencia_ag = s.fkpotencia_ag " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkpotencia_ag)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_potencia_ag pat ON pat.idpotencia_ag = s.fkpotencia_ag " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkpotencia_ag)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_foda_baestrategica pat ON pat.idfoda_bestrategica = s.fkfoda_baestrategica " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkfoda_baestrategica)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_acompaniamiento) AS aprobado " +
            "FROM seg_observacion_acompaniamiento s " +
            "INNER JOIN pat_foda_baestrategica pat ON pat.idfoda_bestrategica = s.fkfoda_baestrategica " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkfoda_baestrategica)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO)", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaAprobadoRechazadoEvaluador(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT (SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_informacion pat ON pat.idinformacion = s.fkinformacion " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkinformacion)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_informacion pat ON pat.idinformacion = s.fkinformacion " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkinformacion)) AS APROBADO " +
            "FROM seg_observacion_evaluador GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_organigrama pat ON pat.idorganigrama = s.fkorganigrama " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkorganigrama)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_organigrama pat ON pat.idorganigrama = s.fkorganigrama " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkorganigrama)) AS APROBADO " +
            "FROM seg_observacion_evaluador GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_dirigencia_deportiva_fadn pat ON pat.idasamblea_personal_fadn = s.fkdirigencia_deportiva_fadn " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkdirigencia_deportiva_fadn)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_dirigencia_deportiva_fadn pat ON pat.idasamblea_personal_fadn = s.fkdirigencia_deportiva_fadn " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkdirigencia_deportiva_fadn)) AS APROBADO " +
            "FROM seg_observacion_evaluador GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_analisis_puesto pat ON pat.idanalisis_puesto = s.fkanalisis_puesto " +
            "WHERE pat.fadn = '{0}' AND s.observacion = '' GROUP BY(s.fkanalisis_puesto)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_analisis_puesto pat ON pat.idanalisis_puesto = s.fkanalisis_puesto " +
            "WHERE pat.fadn = '{0}' AND s.observacion != '' GROUP BY(s.fkanalisis_puesto)) AS APROBADO " +
            "FROM seg_observacion_acompaniamiento GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_analisis_brecha pat ON pat.idanalisis_brecha = s.fkanalisis_brecha " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkanalisis_brecha)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_analisis_brecha pat ON pat.idanalisis_brecha = s.fkanalisis_brecha " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkanalisis_brecha)) AS APROBADO " +
            "FROM seg_observacion_evaluador GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_resultado_dih pat ON pat.idresultado_dih = s.fkresultado_dih " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkresultado_dih)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_resultado_dih pat ON pat.idresultado_dih = s.fkresultado_dih " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkresultado_dih)) AS APROBADO " +
            "FROM seg_observacion_evaluador GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_potencia_ag pat ON pat.idpotencia_ag = s.fkpotencia_ag " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkpotencia_ag)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_potencia_ag pat ON pat.idpotencia_ag = s.fkpotencia_ag " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkpotencia_ag)) AS APROBADO " +
            "FROM seg_observacion_evaluador GROUP BY(APROBADO) " +
            "UNION ALL " +
            "SELECT(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_foda_baestrategica pat ON pat.idfoda_bestrategica = s.fkfoda_baestrategica " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion = '' GROUP BY(s.fkfoda_baestrategica)) AS RECHAZADO, " +
            "(SELECT COUNT(s.idobservacion_evaluador) AS aprobado " +
            "FROM seg_observacion_evaluador s " +
            "INNER JOIN pat_foda_baestrategica pat ON pat.idfoda_bestrategica = s.fkfoda_baestrategica " +
            "WHERE pat.fadn = '{0}' AND pat.ano = '{1}' AND s.observacion != '' GROUP BY(s.fkfoda_baestrategica)) AS APROBADO " +
            "FROM seg_observacion_evaluador GROUP BY(APROBADO)", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaPorcentajeEstado(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();
            query = String.Format("SELECT " +
            "(SELECT COUNT(pat.idinformacion) " +
            "FROM pat_informacion pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idinformacion) " +
            "FROM pat_informacion pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_informacion GROUP BY(LISTO) " +
            "UNION ALL " +
            "SELECT " +
            "(SELECT COUNT(pat.idorganigrama) " +
            "FROM pat_organigrama pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idorganigrama) " +
            "FROM pat_organigrama pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_organigrama GROUP BY(LISTO) " +
            "UNION ALL " +
            "SELECT " +
            "(SELECT COUNT(pat.idasamblea_personal_fadn) " +
            "FROM pat_dirigencia_deportiva_fadn pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idasamblea_personal_fadn) " +
            "FROM pat_dirigencia_deportiva_fadn pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_dirigencia_deportiva_fadn GROUP BY(LISTO) " +
            "UNION ALL " +
            "SELECT " +
            "(SELECT COUNT(pat.idanalisis_puesto) " +
            "FROM pat_analisis_puesto pat " +
            "WHERE pat.fadn = '{0}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idanalisis_puesto) " +
            "FROM pat_analisis_puesto pat " +
            "WHERE pat.fadn = '{0}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_analisis_puesto GROUP BY(LISTO) " +
            "UNION ALL " +
            "SELECT " +
            "(SELECT COUNT(pat.idanalisis_brecha) " +
            "FROM pat_analisis_brecha pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idanalisis_brecha) " +
            "FROM pat_analisis_brecha pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_analisis_brecha GROUP BY(LISTO) " +
            "UNION ALL " +
            "SELECT " +
            "(SELECT COUNT(pat.idresultado_dih) " +
            "FROM pat_resultado_dih pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idresultado_dih) " +
            "FROM pat_resultado_dih pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_resultado_dih GROUP BY(LISTO) " +
            "UNION ALL " +
            "SELECT " +
            "(SELECT COUNT(pat.idpotencia_ag) " +
            "FROM pat_potencia_ag pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idpotencia_ag) " +
            "FROM pat_potencia_ag pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_potencia_ag GROUP BY(LISTO) " +
            "UNION ALL " +
            "SELECT " +
            "(SELECT COUNT(pat.idfoda_bestrategica) " +
            "FROM pat_foda_baestrategica pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado = 13) " +
            "/ " +
            "(SELECT COUNT(pat.idfoda_bestrategica) " +
            "FROM pat_foda_baestrategica pat " +
            "WHERE pat.fadn = '{0}' " +
            "AND pat.ano = '{1}' AND pat.fkestado != 12)  AS LISTO " +
            "FROM pat_foda_baestrategica GROUP BY(LISTO)", fadn, anio);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATIntroduccion(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idinformacion) FROM pat_informacion " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idinformacion) FROM pat_informacion " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idinformacion) FROM pat_informacion " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idinformacion) FROM pat_informacion " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idinformacion) FROM pat_informacion " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATOrganigrama(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idorganigrama) FROM pat_organigrama " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idorganigrama) FROM pat_organigrama " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idorganigrama) FROM pat_organigrama " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idorganigrama) FROM pat_organigrama " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idorganigrama) FROM pat_organigrama " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATDirigencia(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idasamblea_personal_fadn) FROM pat_dirigencia_deportiva_fadn " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idasamblea_personal_fadn) FROM pat_dirigencia_deportiva_fadn " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idasamblea_personal_fadn) FROM pat_dirigencia_deportiva_fadn " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idasamblea_personal_fadn) FROM pat_dirigencia_deportiva_fadn " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idasamblea_personal_fadn) FROM pat_dirigencia_deportiva_fadn " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATLogros(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idanalisis_puesto) FROM pat_analisis_puesto " +
            "WHERE fadn = '{0}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idanalisis_puesto) FROM pat_analisis_puesto " +
            "WHERE fadn = '{0}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idanalisis_puesto) FROM pat_analisis_puesto " +
            "WHERE fadn = '{0}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idanalisis_puesto) FROM pat_analisis_puesto " +
            "WHERE fadn = '{0}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idanalisis_puesto) FROM pat_analisis_puesto " +
            "WHERE fadn = '{0}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATBrechas(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idanalisis_brecha) FROM pat_analisis_brecha " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idanalisis_brecha) FROM pat_analisis_brecha " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idanalisis_brecha) FROM pat_analisis_brecha " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idanalisis_brecha) FROM pat_analisis_brecha " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idanalisis_brecha) FROM pat_analisis_brecha " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATPotencia(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idpotencia_ag) FROM pat_potencia_ag " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idpotencia_ag) FROM pat_potencia_ag " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idpotencia_ag) FROM pat_potencia_ag " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idpotencia_ag) FROM pat_potencia_ag " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idpotencia_ag) FROM pat_potencia_ag " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATResultado(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idresultado_dih) FROM pat_resultado_dih " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idresultado_dih) FROM pat_resultado_dih " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idresultado_dih) FROM pat_resultado_dih " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idresultado_dih) FROM pat_resultado_dih " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idresultado_dih) FROM pat_resultado_dih " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }

        public DataTable graficaEstadosPATFODA(string fadn, string anio)
        {
            var mysql = new DBConnection.ConexionMysql();
            DataTable dt = new DataTable();

            query = String.Format("SELECT 'INGRESADOS',COUNT(idfoda_bestrategica) FROM pat_foda_baestrategica " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '1' " +
            "UNION ALL " +
            "SELECT 'EDICIÓN', COUNT(idfoda_bestrategica) FROM pat_foda_baestrategica " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '2' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN CE', COUNT(idfoda_bestrategica) FROM pat_foda_baestrategica " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '3' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN A', COUNT(idfoda_bestrategica) FROM pat_foda_baestrategica " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '6' " +
            "UNION ALL " +
            "SELECT 'REVISIÓN E', COUNT(idfoda_bestrategica) FROM pat_foda_baestrategica " +
            "WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '9'", fadn, anio);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}