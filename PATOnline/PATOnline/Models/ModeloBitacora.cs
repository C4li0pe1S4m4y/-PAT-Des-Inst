using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloBitacora
    {
        public string tabla { get; set; }
        public string accion { get; set; }
        public int id { get; set; }
        public string info { get; set; }
        public DateTime fecha { get; set; }
        public string usuario { get; set; }
    }
}