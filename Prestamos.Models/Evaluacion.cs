using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Models
{
    public class Evaluacion
    {
        public int Id { get; set; }
        public string Regla { get; set; }
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Tipo_riesgo { get; set; }
    }
}
