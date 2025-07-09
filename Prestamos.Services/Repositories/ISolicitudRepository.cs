using Prestamos.Models;
using Prestamos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Services.Repositories
{
    public interface ISolicitudRepository
    {
        public Task<bool> CreateSolicitud(SolicitudDTO solicitud);
        public Task<List<Solicitud>> GetSolicitudes(int? dni, string? estado);
        public Task<bool> EditSolicitud(Solicitud solicitud);
        public Task<bool> DeleteSolicitud(int id);
    }
}
