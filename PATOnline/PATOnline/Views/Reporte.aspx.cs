using MySql.Data.MySqlClient;
using PATOnline.DataSet;
using PATOnline.imprimirPAT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PATOnline.Views
{
    public partial class Reporte : System.Web.UI.Page
    {
        private string query;
        public string year = Convert.ToString(DateTime.Now.Year);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void reporte()
        {
            imprimirIntroduccion objRpt;
            objRpt = new imprimirIntroduccion();

            var mysql = new DBConnection.ConexionMysql();
            dataSIntroduccion ds = new dataSIntroduccion();
            query = String.Format("SELECT idinformacion, introduccion, marco_juridico, afiliacion_organizacion " +
            "FROM pat_informacion WHERE fadn = '{0}' AND ano = '{1}' AND fkestado = '13';", Session["Federacion"].ToString(), year);

            mysql.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, mysql.conectar);
            consulta.Fill(ds, "Reporte");
            mysql.CerrarConexion();

            objRpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = objRpt;
            CrystalReportViewer1.Visible = true;
        }

        protected void prueba_Click(object sender, EventArgs e)
        {
            reporte();
        }
    }
}