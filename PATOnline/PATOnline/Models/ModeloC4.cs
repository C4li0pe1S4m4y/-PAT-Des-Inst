using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloC4
    {
        public string codigo { get; set; }
        public int fkactividad { get; set; }
        public string descripcion { get; set; }
        public int fkobjetivo { get; set; }
        public int fketapa_prepacion { get; set; }
        public string dirigido { get; set; }
        public string linea { get; set; }
        public int fkcategoria { get; set; }
        public string registro { get; set; }
        public int inicio_dia { get; set; }
        public string inicio_mes { get; set; }
        public int fin_dia { get; set; }
        public string fin_mes { get; set; }
        public int fkpais_departamento { get; set; }
        public string lugar { get; set; }
        public double presupuesto { get; set; }
        public string actividad { get; set; }
        public int fknivel { get; set; }
        public string departamento { get; set; }
        public string competicion { get; set; }
        public int fkclasificacion { get; set; }
        public string edades { get; set; }
        public string resultado { get; set; }
        public string fadn { get; set; }
        public string ano { get; set; }

    }
}