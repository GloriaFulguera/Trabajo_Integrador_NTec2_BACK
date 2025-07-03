using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Models.DTO
{
    public class SolicitudDTO
    {
        public int Dni { get; set; }
        public int Edad { get; set; }
        public string Ingresos { get; set; }
        public string Tipo_empleo { get; set; }
        public string Monto { get; set; }
        public int Cuotas { get; set; }
        public string Motivo { get; set; }

    }
}
