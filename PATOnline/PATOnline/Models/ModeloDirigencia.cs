using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloDirigencia
    {
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public int fk_persona { get; set; }
        public int fk_cargo { get; set; }
        public int fk_estado { get; set; }
        public int fk_departamento { get; set; }
        public string fadn { get; set; }
        public string anio { get; set; }
    }
}