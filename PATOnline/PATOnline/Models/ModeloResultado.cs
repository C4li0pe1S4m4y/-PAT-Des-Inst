using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloResultado
    {
        public string nombre { get; set; }
        public string sede { get; set; }
        public int fecha { get; set; }
        public string resultado { get; set; }
        public string observacion { get; set; }
        public int fknivel { get; set; }
        public int fkcategoria { get; set; }
        public string fadn { get; set; }
        public string anio { get; set; }
        public int fkestado { get; set; }
    }
}