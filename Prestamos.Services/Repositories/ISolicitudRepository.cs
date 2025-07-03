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
    }
}
