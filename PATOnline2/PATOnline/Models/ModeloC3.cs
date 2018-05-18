using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloC3
    {
        public string codigo { get; set; }
        public string nombre_competencia { get; set; }
        public int fkclasificacion { get; set; }
        public int fknivel { get; set; }
        public int fkcategoria { get; set; }
        public string edades { get; set; }
        public string fase_evento { get; set; }
        public string resultado { get; set; }
        public string registro { get; set; }
        public int inicio_dia { get; set; }
        public string inicio_mes { get; set; }
        public int fin_dia { get; set; }
        public string fin_mes { get; set; }
        public int fkdepartamento { get; set; }
        public string lugar { get; set; }
        public double presupuesto { get; set; }
        public string fadn { get; set; }
        public string ano { get; set; }
        public int fkactividad { get; set; }
        public int masculino { get; set; }
        public int femenino { get; set; }
        public int total { get; set; }
        public string departamento { get; set; }
    }
}