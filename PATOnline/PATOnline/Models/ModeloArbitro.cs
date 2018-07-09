using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloArbitro
    {
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string nacionalidad { get; set; }
        public string departamento { get; set; }
        public int fknivel { get; set; }
        public string observacion { get; set; }
        public string fadn { get; set; }
        public string anio { get; set; }
        public int fkestado { get; set; }
    }
}