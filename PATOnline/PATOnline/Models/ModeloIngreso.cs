using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloIngreso
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public int idpadre { get; set; }
        public int subpadre { get; set; }
        public string fadn { get; set; }
    }
}