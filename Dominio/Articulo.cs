using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        [DisplayName("ID")]
        public int IDArticulo { get; set; }
        [DisplayName("Código")]
        public string CodigoArticulo { get; set; }
        [DisplayName("Nombre")]
        public string NombreArticulo { get; set; }
        [DisplayName("Descripción")]
        public string DescripcionArticulo { get; set; }
        [DisplayName("Precio")]
        public decimal PrecioArticulo { get; set; }
        [DisplayName("Marca")]
        public Marca MarcaArticulo { get; set; }
        [DisplayName("Categoría")]
        public Categoria CategoriaArticulo { get; set; }
        public List<Imagen> Imagenes { get; set; }
    }
}
