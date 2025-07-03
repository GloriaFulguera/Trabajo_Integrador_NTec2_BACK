using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Models
{
    public class Solicitud
    {
        public int Id { get; set; }
        public int Usuario_dni { get; set; }
        public int Usuario_edad { get; set; }
        public string Ingresos { get; set; }
        public string Tipo_empleo { get; set; }
        public string Monto { get; set; }
        public int Cuotas { get; set; }
        public string Motivo { get; set; }
        public string Fecha_alta { get; set; }
        public string Fecha_mod { get; set; }
        public string Estado { get; set; }
    }
}
