using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;

namespace PATOnline.Controller.Read
{
    public class ReadComiteEjectuvio
    {
        public string query = "";
        public string add = "";
        public DataTable ComiteEjecutivoRead(string fadn)
        {
            DataTable dt = new DataTable();
            var mysql = new DBConnection.ConexionMysql();
            if (fadn == "Confederación Deportiva Autónoma de Guatemala")
            {
                add = " ORDER BY (tipo);";
            }
            else
            {
                add = " AND dbsecretaria.f.nombre = '{0}' ORDER BY (tipo);";
            }
            query = String.Format("SELECT dbsecretaria.t.descripcion AS tipo, CONCAT(dbsecretaria.d.Nombres,' ',dbsecretaria.d.Apellidos) AS nombre, " +
            "CONCAT(DAY(dbsecretaria.c.Fecha_inicio), '/', MONTH(dbsecretaria.c.Fecha_inicio), '/', YEAR(dbsecretaria.c.Fecha_inicio)) AS posesion, " +
            "CONCAT(DAY(dbsecretaria.c.Fecha_final), '/', MONTH(dbsecretaria.c.Fecha_final), '/', YEAR(dbsecretaria.c.Fecha_final)) AS entrega, " +
            "dbsecretaria.c.Periodo AS periodo, dbsecretaria.f.nombre AS federacion " +
            "FROM dbsecretaria.sg_comite_ejecutivo c " +
            "INNER JOIN dbsecretaria.sg_dirigente d ON dbsecretaria.d.idDirigente = dbsecretaria.c.id_dirigente " +
            "INNER JOIN dbsecretaria.sg_fadn f ON dbsecretaria.f.id_fand = dbsecretaria.c.id_fadn " +
            "INNER JOIN dbsecretaria.sg_tipo_dirigente t ON dbsecretaria.t.idTipo_dirigente = dbsecretaria.d.Tipo_dirigente " +
            "WHERE dbsecretaria.c.Estado_Comite = 1 AND dbsecretaria.d.Estado = 'Activo'" + add, fadn);
            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(dt);
            mysql.CerrarConexion();
            return dt;
        }
    }
}