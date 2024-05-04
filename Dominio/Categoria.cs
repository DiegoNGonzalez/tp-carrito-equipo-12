using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {
        [DisplayName("ID")]
        public int IDCategoria { get; set; }
        [DisplayName("Categoria")]
        public string NombreCategoria { get; set; }
        
        public override string ToString()
        {
            return NombreCategoria;
        }

    }

    
}
