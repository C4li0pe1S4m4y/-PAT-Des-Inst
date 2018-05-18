using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloUsuario
    {
        public string nombre1 { get; set; }
        public string nombre2 { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int fkpais { get; set; }
        public string fkfadn { get; set; }
        public int fkestado { get; set; }
        public int fkrol { get; set; }
        public string user { get; set; }
        public string verifica { get; set; }
    }
}