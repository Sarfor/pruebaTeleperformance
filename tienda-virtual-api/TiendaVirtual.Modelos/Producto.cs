using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaVirtual.Modelos
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public bool EsActivo { get; set; }
        public string ImagenUrl { get; set; }
    }
}
