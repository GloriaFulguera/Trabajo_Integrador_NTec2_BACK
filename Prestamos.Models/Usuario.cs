using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Models
{
    public class Usuario
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public string Fe_alta { get; set; }
        public string Fe_ultimoLogin { get; set; }
        public string Estado { get; set; }
    }
}
