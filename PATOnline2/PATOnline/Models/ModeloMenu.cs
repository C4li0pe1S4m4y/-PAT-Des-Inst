using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PATOnline.Models
{
    public class ModeloMenu
    {
        public string idmenu { get; set; }
        public string nombre { get; set; }
        public string url { get; set; }
        public string id_padre { get; set; }
    }
}