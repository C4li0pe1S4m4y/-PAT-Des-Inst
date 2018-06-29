using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloCPE
    {
        public int mes1 { get; set; }
        public int mes2 { get; set; }
        public int mess3 { get; set; }
        public int anual { get; set; }
        public double presupuesto { get; set; }
        public int fkformato_ce { get; set; }
        public string fadn { get; set; }
        public string ano { get; set; }
        public int fkestado { get; set; }
    }
}