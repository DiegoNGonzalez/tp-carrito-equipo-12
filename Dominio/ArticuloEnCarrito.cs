using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticuloEnCarrito: Articulo
    {
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
