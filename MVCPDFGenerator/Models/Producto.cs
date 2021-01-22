using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPDFGenerator.Models
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionCompleta { get; set; }
        public string Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Variedad { get; set; }
        public string ImageSource { get; set; }
    }
}
