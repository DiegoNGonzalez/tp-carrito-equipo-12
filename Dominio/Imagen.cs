using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        [DisplayName("ID")]
        public int IDImagen { get; set; }
        [DisplayName("ID Artículo")]
        public int IDArticulo { get; set; }
        [DisplayName("URL Imagen")]
        public string URLImagen { get; set; }
    }
}
