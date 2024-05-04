using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Marca
    {
        [DisplayName("ID")]
        public int IDMarca { get; set; }
        [DisplayName("Marca")]
        public string NombreMarca { get; set; }

        public override string ToString()
        {
            return NombreMarca;
        }
    }
}
