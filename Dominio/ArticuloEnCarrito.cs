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

        public ArticuloEnCarrito() : base()
        {
            this.NombreArticulo = base.NombreArticulo;
            this.DescripcionArticulo = base.DescripcionArticulo;
            this.PrecioArticulo = base.PrecioArticulo;
            this.MarcaArticulo = base.MarcaArticulo;
            this.CategoriaArticulo = base.CategoriaArticulo;
            this.Imagenes = base.Imagenes;
            Cantidad = 0;
            Subtotal = 0;
        }
        public ArticuloEnCarrito(Articulo aux)
        {
            this.NombreArticulo = aux.NombreArticulo;
            this.DescripcionArticulo = aux.DescripcionArticulo;
            this.PrecioArticulo = aux.PrecioArticulo;
            this.MarcaArticulo = aux.MarcaArticulo;
            this.CategoriaArticulo = aux.CategoriaArticulo;
            this.Imagenes = aux.Imagenes;
            Cantidad = 1;
            Subtotal = Cantidad * aux.PrecioArticulo;
        }
    }
}
