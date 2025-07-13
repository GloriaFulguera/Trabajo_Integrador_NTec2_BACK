using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Models.DTO
{
    public class SolicitudEditDTO
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public string Motivo_rechazo { get; set; }
    }
}
