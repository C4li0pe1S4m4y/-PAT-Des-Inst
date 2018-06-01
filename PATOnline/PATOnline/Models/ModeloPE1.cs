using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloPE1
    {
        public string codigo { get; set; }
        public string resultado { get; set; }
        public string registro { get; set; }
        public int i_dia { get; set; }
        public string i_mes { get; set; }
        public int f_dia { get; set; }
        public string f_mes { get; set; }
        public string lugar { get; set; }
        public double prespuesto { get; set; }
        public int fkactividad { get; set; }
        public int fkpais_departamento { get; set; }
        public int categoria { get; set; }
        public string fadn { get; set; }
        public string ano { get; set; }
    }
}