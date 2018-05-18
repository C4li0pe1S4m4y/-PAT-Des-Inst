using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloBrechaCategoria
    {
        public double punteo { get; set; }
        public double puntos { get; set; }
        public double comparacion { get; set; }
        public string observacion { get; set; }
        public int fkbrecha { get; set; }
        public string fadn { get; set; }
        public string anio { get; set; }
    }
}