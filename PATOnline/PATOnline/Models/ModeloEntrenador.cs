using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloEntrenador
    {
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string nacionalidad { get; set; }
        public string departamento_laboral { get; set; }
        public string modalidad { get; set; }
        public string categoria { get; set; }
        public int fkresponsabilidad { get; set; }
        public int fklinea { get; set; }
        public string fadn { get; set; }
        public string anion { get; set; }
        public int fkestado { get; set; }
    }
}